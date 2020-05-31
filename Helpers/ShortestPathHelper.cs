using Helpers.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public class ShortestPathHelper
    {
        public static Dictionary<int, City> FillEuclideanDistances(Dictionary<int, City> citiesList)
        {
            for(int i = 1; i < citiesList.Count + 1; i++)
            {
                for (int j = i + 1; j < citiesList.Count + 1; j++)
                {
                    var distance = EuclideanDistance(citiesList[i].CoordinateX, citiesList[i].CoordinateY, citiesList[j].CoordinateX, citiesList[j].CoordinateY);
                    citiesList[i].Connections.Add(j, distance);
                    citiesList[j].Connections.Add(i, distance);
                }
            }
            return citiesList;
        }

        private static int EuclideanDistance(float x1, float y1, float x2, float y2)
        {
            return Convert.ToInt32(Math.Floor((Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)))));
        }

    }
}
