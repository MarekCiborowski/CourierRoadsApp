using Helpers.Structures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public class MainHelper
    {
        private Dictionary<int, City> citiesDictionary;
        private Path bestPath;

        public void Initiate(string filepath)
        {
            citiesDictionary = FileLoader.LoadCitiesFromTestFile(filepath);
            citiesDictionary = ShortestPathHelper.FillEuclideanDistances(citiesDictionary);
        }


        public void GeneratePath(int startingCityId)
        {
            bestPath = new Path();
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
        }

        
    }
}
