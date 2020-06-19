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

        public static Dictionary<int, City> FillRealDistances(Dictionary<int,City> citiesList)
        {
            for (int i = 1; i < citiesList.Count + 1; i++)
            {
                for (int j = i + 1; j < citiesList.Count + 1; j++)
                {
                    if (!citiesList[i].Connections.ContainsKey(j))
                    {
                        var distance = GetRealDistance(i, j, citiesList);
                        citiesList[i].Connections.Add(j, distance);
                        citiesList[j].Connections.Add(i, distance);
                    }
                    
                }
            }
            return citiesList;
        }

        public static int GetRealDistance(int fromCityId, int toCityId, Dictionary<int, City> citiesList)
        {

            var heuristicValuation = GetHeuristicsValuation(toCityId, citiesList);

            var arraysLength = citiesList.Count + 1;

            var estimatedDistanceArray = new int[arraysLength];
            var distancesArray = new int[arraysLength];

            for (int i = 0; i < arraysLength; ++i)
            {
                estimatedDistanceArray[i] = distancesArray[i] = int.MaxValue;
            }

            var predecessorsArray = new int[arraysLength];
            var visitedArray = new bool[arraysLength];
            var isAlreadyAddedInCityDistances = new bool[arraysLength];

            distancesArray[fromCityId] = 0;
            estimatedDistanceArray[fromCityId] = heuristicValuation[fromCityId];

            var processedCollection = new SortedSet<AlgorithmCity>(new AlgorithmCityComparer());
            processedCollection.Add(new AlgorithmCity(fromCityId, estimatedDistanceArray[fromCityId]));

            while (processedCollection.Count != 0)
            {
                var currentCity = processedCollection.Min;
                processedCollection.Remove(currentCity);

                visitedArray[currentCity.CityId] = true;

                if (currentCity.CityId == toCityId)
                {
                    break;
                }

                foreach (var neighbour in citiesList[currentCity.CityId].Connections)
                {
                    var newPossibleDistance = distancesArray[currentCity.CityId] + neighbour.Value;

                    if (newPossibleDistance < distancesArray[neighbour.Key])
                    {
                        processedCollection.Remove(new AlgorithmCity(neighbour.Key, estimatedDistanceArray[neighbour.Key]));
                        isAlreadyAddedInCityDistances[neighbour.Key] = false;

                        distancesArray[neighbour.Key] = newPossibleDistance;
                        estimatedDistanceArray[neighbour.Key] = newPossibleDistance + heuristicValuation[neighbour.Key];
                        predecessorsArray[neighbour.Key] = currentCity.CityId;

                        if (visitedArray[neighbour.Key] == false && isAlreadyAddedInCityDistances[neighbour.Key] == false)
                        {
                            processedCollection.Add(new AlgorithmCity(neighbour.Key, estimatedDistanceArray[neighbour.Key]));
                            isAlreadyAddedInCityDistances[neighbour.Key] = true;
                        }
                    }
                }
            }

            return distancesArray[toCityId];
        }

        private static int GetDistanceToTheCity(City from, City to)
        {
            return (int)Math.Round(Math.Sqrt(Math.Pow((to.CoordinateY - from.CoordinateY), 2) + Math.Pow((to.CoordinateX - from.CoordinateX), 2)));
        }

        private static int[] GetHeuristicsValuation(int cityToValuate, Dictionary<int, City> coordinatesDict)
        {
            var arrayLength = coordinatesDict.Count + 1;
            var result = new int[arrayLength];

            var cityToCalculateDistanceTo = coordinatesDict[cityToValuate];

            for (int i = 1; i < arrayLength; ++i)
            {
                result[i] = GetDistanceToTheCity(coordinatesDict[i], cityToCalculateDistanceTo);
            }

            return result;
        }

        private class AlgorithmCity
        {
            public AlgorithmCity(int cityId, int heuristicDistance)
            {
                CityId = cityId;
                HeuristicDistance = heuristicDistance;
            }

            public int CityId { get; set; }

            public int HeuristicDistance { get; set; }
        }

        private class AlgorithmCityComparer : IComparer<AlgorithmCity>
        {
            public int Compare(AlgorithmCity x, AlgorithmCity y)
            {
                var compare = Comparer<int>.Default.Compare(x.HeuristicDistance, y.HeuristicDistance);
                if(compare == 0)
                {
                    compare = Comparer<int>.Default.Compare(x.CityId, y.CityId);
                }

                return compare;
            }
        }
    }
}
