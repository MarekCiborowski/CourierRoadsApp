using Helpers.Structures;
using System;
using System.Collections.Generic;
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

            var path = ILS(1);
            var x = path.GetTotalLengthOfPath();
        }

        public Path GeneratePath(int startingCityId)
        {
            var bestPath = new Path();
            bestPath.GeneratePath(startingCityId, citiesDictionary);

            for(var numberOfRetries = 0; numberOfRetries < 3; numberOfRetries++)
            {
                var newPath = new Path();
                newPath.GeneratePath(startingCityId, citiesDictionary);

                var newPathLength = newPath.GetTotalLengthOfPath();

                if(newPath.GetTotalLengthOfPath() < bestPath.GetTotalLengthOfPath())
                {
                    bestPath = newPath;
                }

            }
            return bestPath;
        }

        public Path ILS(int startingCityId)
        {
            Path bestPath = new Path();
            var bestPathLength = int.MaxValue;
            
            for(int i = 0; i < 10; i++)
            {
                var pathLocal = GeneratePath(startingCityId);
                LocalSearchHelper.LocalSearch(pathLocal, citiesDictionary);
                var pathLocalLength = pathLocal.GetTotalLengthOfPath();
                
                for(int j = 0; j < 20; j++)
                {
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

            return bestPath;

        }

        public void VNS()
        {

        }

        public void LocalSearch(Path path)
        {

        }
    }
}
