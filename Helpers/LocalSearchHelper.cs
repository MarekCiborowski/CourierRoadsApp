using Helpers.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public static class LocalSearchHelper
    {
        public static Dictionary<int, City> citiesDictionary;
        public static List<Edge> allEdges;
        public static int edgesCount;

        public static void LocalSearch(Path path, Dictionary<int, City> _citiesDictionary)
        {
            citiesDictionary = _citiesDictionary;
            allEdges = path.GetAllEdges();
            edgesCount = allEdges.Count;

            var improvement = true;
            while (improvement)
            {
                improvement = _2OPT(path);
            }

        }

        public static bool _2OPT(Path path)
        {
            // take first edge that has possibility to be swapped
            for(int firstEdgeIndex = 0; firstEdgeIndex < edgesCount - 3; ++firstEdgeIndex)
            {
                // take first non-neighbour edge corresponding to firstEdgeIndex
                for(int secondEdgeIndex = firstEdgeIndex + 2; secondEdgeIndex < edgesCount - 1; ++secondEdgeIndex)
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

                        allEdges.Remove(firstEdge);
                        allEdges.Remove(secondEdge);

                        allEdges.Insert(firstEdgeIndex, newFirstEdge);
                        allEdges.Insert(secondEdgeIndex, newSecondEdge);

                        // take all edges between the new ones
                        var edgesToReverse = allEdges.GetRange(firstEdgeIndex + 1, secondEdgeIndex - firstEdgeIndex - 1);

                        // reverse edges taken above 
                        var reversedEdges = new List<Edge>();
                        foreach(var edge in edgesToReverse)
                        {
                            reversedEdges.Add(new Edge { FromCityId = edge.ToCityId, ToCityId = edge.FromCityId });
                        }
                        reversedEdges.Reverse();

                        allEdges.RemoveRange(firstEdgeIndex + 1, secondEdgeIndex - firstEdgeIndex - 1);
                        
                        allEdges.InsertRange(firstEdgeIndex + 1, reversedEdges);

                        return true;
                    }
                }
            }
            return false;
        }
    }
}
