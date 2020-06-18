using Helpers.Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Helpers
{
    public class MainHelper
    {
        private Dictionary<int, City> citiesDictionary;

        public void Initiate(string filepath)
        {
            citiesDictionary = FileLoader.LoadCitiesFromTestFile(filepath);
            citiesDictionary = ShortestPathHelper.FillEuclideanDistances(citiesDictionary);

            
        }

        public Path GeneratePath(int startingCityId)
        {
            //var bestPath = new Path();
            //bestPath.GeneratePath(startingCityId, citiesDictionary);

            //for(var numberOfRetries = 0; numberOfRetries < 1; numberOfRetries++)
            //{
            //    var newPath = new Path();
            //    newPath.GeneratePath(startingCityId, citiesDictionary);

            //    if(newPath.GetTotalLengthOfPath() < bestPath.GetTotalLengthOfPath())
            //    {
            //        bestPath = newPath;
            //    }

            //}

            //return bestPath;

            var firstPath = new Path();
            var secondPath = new Path();

            firstPath.GeneratePath(startingCityId, citiesDictionary);
            secondPath.GeneratePath(startingCityId, citiesDictionary);

            return firstPath.GetTotalLengthOfPath() < secondPath.GetTotalLengthOfPath() ? firstPath : secondPath;
        }

        public Path ILS(int startingCityId)
        {
            Path bestPath = new Path();
            var bestPathLength = int.MaxValue;

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 2; i++)
            {
                var pathLocal = GeneratePath(startingCityId);
                LocalSearchHelper.LocalSearch(pathLocal, citiesDictionary);
                var pathLocalLength = pathLocal.GetTotalLengthOfPath();
                
                for(int j = 0; j < 10; j++)
                {
                    if (stopwatch.Elapsed.Seconds > 17)
                    {
                        stopwatch.Stop();
                        return bestPath;
                    }

                    var path = pathLocal.CopyPath();
                    DisturbHelper.Disturb(path);
                    LocalSearchHelper.LocalSearch(path, citiesDictionary);
                    var pathLength = path.GetTotalLengthOfPath();
                    
                    if(pathLength < bestPathLength)
                    {
                        bestPath = path;
                        pathLocal = path;

                        bestPathLength = pathLength;
                        pathLocalLength = pathLength;
                    }
                    else if(pathLength < pathLocalLength)
                    {
                        pathLocal = path;
                        pathLocalLength = pathLength;
                    }
                }
            }

            stopwatch.Stop();
            return bestPath;

        }

        public Path Basic_VNS(int startingCityId)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var bestPath = GeneratePath(startingCityId);
            var bestPathLength = bestPath.GetTotalLengthOfPath();

            while(true)
            {
                var k = 1;
                while (k < 4)
                {
                    if (stopwatch.Elapsed.Seconds > 18)
                    {
                        stopwatch.Stop();
                        return bestPath;
                    }

                    var path = bestPath.CopyPath();
                    DisturbHelper.Disturb(path, k);
                    LocalSearchHelper.LocalSearch(path, citiesDictionary);

                    var pathLength = path.GetTotalLengthOfPath();

                    if(pathLength < bestPathLength)
                    {
                        bestPath = path;
                        bestPathLength = pathLength;
                        k = 1;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
        }

        public void LocalSearch(Path path)
        {

        }
    }
}
