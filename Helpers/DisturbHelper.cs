using Helpers.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers
{
    public static class DisturbHelper
    {
        public static void Disturb(Path path, int k = 2)
        {
            var edgesForSwapping = FindEdgesForSwapping(path, k * 2);

            RemoveOldEdges(edgesForSwapping, path);

            var newEdges = SwapEdges(edgesForSwapping);

            AddNewEdges(newEdges, path);
        }

        private static List<Edge> FindEdgesForSwapping(Path path, int howMany)
        {
            var edgesForSwapping = new List<Edge>();
            Random random = new Random();

            var cityIds = path.GetWholePath().Select(p => p.Key).ToList();
            var pathsEdges = path.GetAllEdges();

            for (int i = 0; i < howMany; ++i)
            {
                var randomCityId = cityIds[random.Next(cityIds.Count)];
                var randomCityEdges = FindEdgesForGivenCity(randomCityId, pathsEdges);

                Edge possibleEdgeToSwap = null;
                foreach (var edge in randomCityEdges)
                {
                    if (cityIds.Any(c => c == edge.FromCityId)
                        && cityIds.Any(c => c == edge.ToCityId))
                    {
                        possibleEdgeToSwap = edge;
                        break;
                    }
                }

                // If no edge found, try again, reduce iteration if needed
                if (possibleEdgeToSwap == null)
                {
                    i = i == 0 ? 0 : --i;
                    cityIds.Remove(randomCityId);
                    continue;
                }

                edgesForSwapping.Add(possibleEdgeToSwap);
                cityIds.Remove(possibleEdgeToSwap.FromCityId);
                cityIds.Remove(possibleEdgeToSwap.ToCityId);
            }
            return edgesForSwapping;
        }

        private static List<Edge> FindEdgesForGivenCity(int cityId, List<Edge> allEdges)
        {
            return allEdges.FindAll(e => e.FromCityId == cityId || e.ToCityId == cityId);
        }

        private static List<Edge> SwapEdges(List<Edge> edgesToSwap)
        {
            var swappedEdges = new List<Edge>();
            var random = new Random();

            var howManyPairs = edgesToSwap.Count / 2;
            for (int i = 0; i < howManyPairs; ++i)
            {
                var randomPairFirst = edgesToSwap[random.Next(edgesToSwap.Count)];
                edgesToSwap.Remove(randomPairFirst);

                var randomPairSecond = edgesToSwap[random.Next(edgesToSwap.Count)];
                edgesToSwap.Remove(randomPairSecond);

                swappedEdges.Add(new Edge()
                {
                    FromCityId = randomPairFirst.FromCityId,
                    ToCityId = randomPairSecond.FromCityId
                });
                swappedEdges.Add(new Edge()
                {
                    FromCityId = randomPairFirst.ToCityId,
                    ToCityId = randomPairSecond.ToCityId
                });
            }

            return swappedEdges;
        }

        private static void RemoveOldEdges(List<Edge> edgesToRemove, Path currentPath)
        {
            var wholePath = currentPath.GetWholePath();

            foreach (var edge in edgesToRemove)
            {
                var firstCity = wholePath[edge.FromCityId];

                if (firstCity.FirstConnectionId == edge.ToCityId)
                {
                    firstCity.FirstConnectionId = 0;
                }
                else
                {
                    firstCity.SecondConnectionId = 0;
                }

                var secondCity = wholePath[edge.ToCityId];

                if (secondCity.FirstConnectionId == edge.FromCityId)
                {
                    secondCity.FirstConnectionId = 0;
                }
                else
                {
                    secondCity.SecondConnectionId = 0;
                }
            }
        }

        private static void AddNewEdges(List<Edge> edgesToAdd, Path currentPath)
        {
            var wholePath = currentPath.GetWholePath();

            foreach (var edge in edgesToAdd)
            {
                var firstCity = wholePath[edge.FromCityId];

                if (firstCity.FirstConnectionId == 0) 
                {
                    firstCity.FirstConnectionId = edge.ToCityId;
                }
                else
                {
                    firstCity.SecondConnectionId = edge.ToCityId;
                }

                var secondCity = wholePath[edge.ToCityId];

                if (secondCity.FirstConnectionId == 0)
                {
                    secondCity.FirstConnectionId = edge.FromCityId;
                }
                else
                {
                    secondCity.SecondConnectionId = edge.FromCityId;
                }
            }
        }
    }
}
