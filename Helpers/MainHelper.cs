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
        }

        public Path GeneratePath(int startingCityId)
        {
            var bestPath = new Path();
            bestPath.GeneratePath(startingCityId, citiesDictionary);

            for(var numberOfRetries = 0; numberOfRetries < 10; numberOfRetries++)
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
            for(int i = 0; i < 10; i++)
            {
                var pathLocal = GeneratePath(startingCityId);
                LocalSearch(pathLocal);
                
                for(int j = 0; j < 20; j++)
                {
                    var path = pathLocal.CopyPath();
                    DisturbHelper.Disturb(path);
                    LocalSearch(path);
                    
                    if(path.GetTotalLengthOfPath() < bestPath.GetTotalLengthOfPath()) // todo: make some updateable property for length
                    {
                        bestPath = path;
                        pathLocal = path;
                    }
                    else if(path.GetTotalLengthOfPath() < pathLocal.GetTotalLengthOfPath())
                    {
                        pathLocal = path;
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
