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

    }
}
