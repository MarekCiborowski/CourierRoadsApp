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

        public void ILS()
        {
            Path bestPath = new Path();

        }

        public void VNS()
        {

        }
        
    }
}
