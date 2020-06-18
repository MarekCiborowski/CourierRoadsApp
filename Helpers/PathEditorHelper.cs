using Helpers.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public static class PathEditorHelper
    {
        public static void RemoveOldEdges(List<Edge> edgesToRemove, Path currentPath)
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

        public static void AddNewEdges(List<Edge> edgesToAdd, Path currentPath)
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
