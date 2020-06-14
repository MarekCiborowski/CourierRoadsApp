using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers.Structures
{
    public class Path
    {
        private Dictionary<int, City> citiesDictionary;
        private Dictionary<int, CityInPath> wholePath;
        private int startingCityId;

        public Path CopyPath()
        {
            var newPath = new Dictionary<int,CityInPath>();
            foreach(var city in this.GetWholePath())
            {
                newPath.Add(city.Key, new CityInPath(city.Value));
            }


            return new Path
            {
                citiesDictionary = this.citiesDictionary,
                wholePath = newPath,
                startingCityId = this.startingCityId
            };
        }

        public void GeneratePath(int startingCityId, Dictionary<int, City> _citiesDictionary)
        {
            this.citiesDictionary = _citiesDictionary;
            this.startingCityId = startingCityId;

            wholePath = new Dictionary<int, CityInPath>();
            var startingCity = new CityInPath (startingCityId);
            wholePath.Add(startingCityId, startingCity);

            var numberOfCitiesOutsidePath = GetCityIdsOutsidePath().Count();
            var random = new Random();
            var lastElementId = startingCityId;

            while (numberOfCitiesOutsidePath != 0)
            {
                var closestNeighboursIds = GetClosestNeighboursIdsOfLastElement(lastElementId, 5);
                var randomCityIndex = closestNeighboursIds.ElementAt(random.Next(closestNeighboursIds.Count));            //taking one random city from best results

                AddCityToPath(lastElementId, randomCityIndex);
                numberOfCitiesOutsidePath--;
                lastElementId = randomCityIndex;
            }
        }

        public void GeneratePathSecond(int startingCityId, Dictionary<int, City> _citiesDictionary)
        {
            //todo


            //this.citiesDictionary = _citiesDictionary;
            //this.startingCityId = startingCityId;

            //wholePath = new Dictionary<int, CityInPath>();
            //var startingCity = new CityInPath(startingCityId);
            //wholePath.Add(startingCityId, startingCity);

            //var numberOfCitiesOutsidePath = GetCityIdsOutsidePath().Count();
            //var random = new Random();
            //var lastElementId = startingCityId;

            //while (numberOfCitiesOutsidePath != 0)
            //{
            //    var closestNeighboursIds = GetClosestNeighboursIdsOfLastElement(lastElementId, 5);
            //    var randomCityIndex = closestNeighboursIds.ElementAt(random.Next(closestNeighboursIds.Count));            //taking one random city from best results

            //    AddCityToPath(lastElementId, randomCityIndex);
            //    numberOfCitiesOutsidePath--;
            //    lastElementId = randomCityIndex;
            //}
        }


        private void AddCityToPath(int lastElementId, int newCityId)
        {
            var lastElement = wholePath[lastElementId];
            lastElement.SecondConnectionId = newCityId;

            var cityToAdd = new CityInPath { CityId = newCityId, FirstConnectionId = lastElementId };
            wholePath.Add(newCityId, new CityInPath(cityToAdd));
        }

        public int GetTotalLengthOfPath()
        {
            if(wholePath.Count == 0)
            {
                return int.MaxValue;
            }


            var currentCityId = startingCityId;
            var currentCity = wholePath[currentCityId];

            var nextCityId = currentCity.FirstConnectionId == 0 ? currentCity.SecondConnectionId : currentCity.FirstConnectionId;
            var totalDistance = citiesDictionary[currentCityId].Connections[nextCityId];

            var previousCityId = startingCityId;
            currentCityId = nextCityId;

            var lastCityId = GetLastElementOfPath().CityId;
            while (currentCityId != lastCityId)
            {
                currentCity = wholePath[currentCityId];
                nextCityId = currentCity.FirstConnectionId == previousCityId ? currentCity.SecondConnectionId : currentCity.FirstConnectionId;
                totalDistance += citiesDictionary[currentCityId].Connections[nextCityId];

                previousCityId = currentCityId;
                currentCityId = nextCityId;
            }

            return totalDistance;
        }

        private CityInPath GetLastElementOfPath()
        {
            return wholePath.Values.First(c => (c.FirstConnectionId == 0 || c.SecondConnectionId == 0) && c.CityId != this.startingCityId);
        }

        private List<int> GetCityIdsOutsidePath()
        {
            var cityIds = citiesDictionary.Keys.Where(cd => !wholePath.Select(wp => wp.Key).Contains(cd)).ToList();

            return cityIds;
        }

        public List<int> GetClosestNeighboursIdsOfLastElement(int lastElementId, int numberOfReturnedCities)
        {
            var lastElement = citiesDictionary[lastElementId];
            var cityIdsOutsidePath = GetCityIdsOutsidePath();

            var closestNeighboursIds = lastElement.Connections
                .Where(c => cityIdsOutsidePath.Contains(c.Key))                             //only cities that have not been added already
                .OrderBy(c => c.Value)
                .Select(c => c.Key)
                .Take(numberOfReturnedCities)                                                   // taking only few of the cities
                .ToList();

            return closestNeighboursIds;
        }

        //public void InsertAt(CityInPath city, int index)
        //{
        //    var previousCity = this.wholePath.ElementAt(index - 1);
        //    previousCity.DistanceToNextCity = previousCity.Connections[city.CityId];  //update distance

        //    city.DistanceToNextCity = city.Connections[this.wholePath.ElementAt(index + 1).CityId];

        //    this.wholePath.Insert(index, city);
        //}

        //public CityInPath RemoveAt(int index)  //cant be first or last
        //{
        //    var previousCity = this.wholePath.ElementAt(index - 1);
        //    previousCity.DistanceToNextCity = previousCity.Connections[this.wholePath.ElementAt(index + 1).CityId];  //update distance

        //    var cityToDelete = wholePath.ElementAt(index);
        //    wholePath.RemoveAt(index);

        //    return cityToDelete;
        //}

        public Dictionary<int, CityInPath> GetWholePath()
        {
            return this.wholePath;
        }

        public List<Edge> GetAllEdges()
        {
            var edgeList = new List<Edge>();

            var currentCityId = this.startingCityId;
            var currentCity = this.wholePath[currentCityId];
            var lastCityId = GetLastElementOfPath().CityId;
            var previousCityId = 0;

            while (currentCityId != lastCityId)
            {
                var nextCityId = currentCity.FirstConnectionId == previousCityId ? currentCity.SecondConnectionId : currentCity.FirstConnectionId;

                edgeList.Add(new Edge
                {
                    CityId1 = currentCityId,
                    CityId2 = nextCityId
                });

                previousCityId = currentCityId;
                currentCityId = nextCityId;
            }

            return edgeList;
        }
    }
}
