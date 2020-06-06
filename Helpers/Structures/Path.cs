using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers.Structures
{
    public class Path
    {
        private Dictionary<int, City> citiesDictionary;
        private List<CityInPath> wholePath;

        public Path CopyPath(Path path)
        {
            var newPath = new List<CityInPath>();
            foreach(var city in path.GetWholePath())
            {
                newPath.Add(new CityInPath((City)city));
            }


            return new Path
            {
                citiesDictionary = path.citiesDictionary,
                wholePath = newPath
            };
        }

        public void GeneratePath(int startingCityId, Dictionary<int, City> _citiesDictionary)
        {
            this.citiesDictionary = _citiesDictionary;
            wholePath = new List<CityInPath>();
            var startingCity = new CityInPath(citiesDictionary[startingCityId]);
            wholePath.Add(startingCity);

            var numberOfCitiesOutsidePath = GetCityIdsOutsidePath().Count();
            var random = new Random();

            while (numberOfCitiesOutsidePath != 0)
            {
                var closestNeighboursIds = GetClosestNeighboursIdsOfLastElement(4);
                var randomCityIndex = closestNeighboursIds.ElementAt(random.Next(closestNeighboursIds.Count));            //taking one random city from best results
                var randomCityToAdd = citiesDictionary[randomCityIndex];

                AddCityToPath(randomCityToAdd);
                numberOfCitiesOutsidePath--;
            }

        }

        private void AddCityToPath(City cityToAdd)
        {
            var lastElement = GetLastElementOfPath();
            lastElement.DistanceToNextCity = cityToAdd.Connections[lastElement.CityId]; //update distance
            wholePath.Add(new CityInPath(cityToAdd));
        }

        public int GetTotalLengthOfPath()
        {
            return wholePath.Select(wp => wp.DistanceToNextCity).Sum();
        }

        private CityInPath GetLastElementOfPath()
        {
            return wholePath[wholePath.Count - 1];
        }

        private List<int> GetCityIdsOutsidePath()
        {
            var cityIds = citiesDictionary.Where(cd => !wholePath.Select(wp => wp.CityId).Contains(cd.Key)).Select(cd => cd.Key).ToList();

            return cityIds;
        }

        public List<int> GetClosestNeighboursIdsOfLastElement(int numberOfReturnedCities)
        {
            var lastElement = GetLastElementOfPath();
            var cityIdsOutsidePath = GetCityIdsOutsidePath();

            var closestNeighboursIds = lastElement.Connections
                .Where(c => cityIdsOutsidePath.Contains(c.Key))                             //only cities that have not been added already
                .OrderBy(c => c.Value)
                .Select(c => c.Key)
                .Take(numberOfReturnedCities)                                                   // taking only few of the cities
                .ToList();

            return closestNeighboursIds;
        }

        public List<CityInPath> GetWholePath()
        {
            return this.wholePath;
        }
    }
}
