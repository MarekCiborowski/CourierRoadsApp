using Helpers.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public static class MaxPossiblePathsHelper
    {
        public static int GetMaxPossiblePathsAmount(int fromCityId, int toCityId, Dictionary<int,City> citiesDictionary)
        {
            var citiesDictionaryCopy = new Dictionary<int, City>();
            foreach (var city in citiesDictionary)
            {
                citiesDictionaryCopy.Add(city.Key, new City
                {
                    CityId = city.Value.CityId,
                    CoordinateX = city.Value.CoordinateX,
                    CoordinateY = city.Value.CoordinateY,
                    Name = city.Value.Name,
                    PackageWeigth = city.Value.PackageWeigth,
                });

                foreach (var connection in city.Value.Connections)
                {
                    citiesDictionaryCopy[city.Key].Connections.Add(connection.Key, connection.Value);
                }
            }

            int numberOfPaths = 0;
            List<int> p;
            while((p = BFS(fromCityId,toCityId,citiesDictionaryCopy)) != null)
            {
                for(int i = 1; i < p.Count; i++)
                {
                    var currentCityId = p[i];
                    var previousCityId = p[i - 1];

                    citiesDictionaryCopy[previousCityId].Connections.Remove(currentCityId);
                    citiesDictionaryCopy[currentCityId].Connections.Remove(previousCityId);
                }

                numberOfPaths++;
            }

            return numberOfPaths;

        }

        public static List<int> BFS(int fromCityId, int toCityId, Dictionary <int,City> citiesDictionaryCopy)
        {
            var cityCount = citiesDictionaryCopy.Count;
            var predecessors = new Dictionary<int, int>();
            var visited = new Dictionary<int, bool>();

            for(int i = 1; i <= cityCount; i++)
            {
                predecessors.Add(i, 0);
                visited.Add(i, false);
            }

            visited[fromCityId] = true;
            var queue = new Queue<int>();

            queue.Enqueue(fromCityId);

            while(queue.Count != 0)
            {
                var currentCityId = queue.Dequeue();
                foreach(var neighbourCityId in citiesDictionaryCopy[currentCityId].Connections.Keys)
                {
                    if (!visited[neighbourCityId])
                    {
                        queue.Enqueue(neighbourCityId);
                        visited[neighbourCityId] = true;
                        predecessors[neighbourCityId] = currentCityId;
                    }
                }
                if (visited[toCityId])
                {
                    var path = new List<int>();
                    var cityId = toCityId;
                    path.Add(cityId);

                    while (cityId != fromCityId)
                    {
                        cityId = predecessors[cityId];
                        path.Add(cityId);
                    }

                    return path;
                }
            }

            return null;


        }
    }
}
