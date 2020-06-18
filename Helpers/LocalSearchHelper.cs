using Helpers.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public static class LocalSearchHelper
    {
        public static Dictionary<int, City> citiesDictionary;

        public static void LocalSearch(Path path, Dictionary<int, City> _citiesDictionary)
        {
            citiesDictionary = _citiesDictionary;
            var improvement = true;
            int i = 0;
            while (improvement)
            {
                improvement = _2OPT(path);
                i++;
            }

        }

        public static bool _2OPT(Path path)
        {
            var allEdges = path.GetAllEdges();
            var count = allEdges.Count;

            for(int firstEdgeIndex = 0; firstEdgeIndex < count - 3; ++firstEdgeIndex)
            {
                for(int secondEdgeIndex = firstEdgeIndex + 2; secondEdgeIndex < count - 1; ++secondEdgeIndex)
                {
                    var firstEdge = allEdges[firstEdgeIndex];
                    var secondEdge = allEdges[secondEdgeIndex];

                    var firstEdgeLength = citiesDictionary[firstEdge.FromCityId].Connections[firstEdge.ToCityId];
                    var secondEdgeLength = citiesDictionary[secondEdge.FromCityId].Connections[secondEdge.ToCityId];

                    var oldLength = firstEdgeLength + secondEdgeLength;

                    var newFirstEdgeLength = citiesDictionary[firstEdge.FromCityId].Connections[secondEdge.FromCityId];
                    var newSecondEdgeLength = citiesDictionary[firstEdge.ToCityId].Connections[secondEdge.ToCityId];

                    var newLength = newFirstEdgeLength + newSecondEdgeLength;

                    if(newLength < oldLength)
                    {
                        var newFirstEdge = new Edge { FromCityId = firstEdge.FromCityId, ToCityId = secondEdge.FromCityId };
                        var newSecondEdge = new Edge { FromCityId = firstEdge.ToCityId, ToCityId = secondEdge.ToCityId };

                        PathEditorHelper.RemoveOldEdges(new List<Edge> { firstEdge, secondEdge }, path);
                        PathEditorHelper.AddNewEdges(new List<Edge> { newFirstEdge, newSecondEdge }, path);

                        return true;
                    }
                }
            }

            return false;
        }

        

    }
}
