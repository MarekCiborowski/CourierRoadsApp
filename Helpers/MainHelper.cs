﻿using Helpers.Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Helpers
{
    public class MainHelper
    {
        private Dictionary<int, City> citiesDictionary;

        public MainHelper(Dictionary<int, City> citiesDictionary)
        {
            this.citiesDictionary = citiesDictionary;
        }
        public void InitiateMap(string filepathCity, string filepathConnections)
        {
            citiesDictionary = FileLoader.LoadCitiesFromCityFiles(filepathCity, filepathConnections);
            citiesDictionary = ShortestPathHelper.FillRealDistances(citiesDictionary);
        }
        public Path GenerateRandomPath(int startingCityId)
        {
            //var bestPath = new Path();
            //bestPath.GeneratePath(startingCityId, citiesDictionary);

            //for(var numberOfRetries = 0; numberOfRetries < 1; numberOfRetries++)
            //{
            //    var newPath = new Path();
            //    newPath.GeneratePath(startingCityId, citiesDictionary);

            //    if(newPath.GetTotalLengthOfPath() < bestPath.GetTotalLengthOfPath())
            //    {
            //        bestPath = newPath;
            //    }

            //}

            //return bestPath;

            var firstPath = new Path();
            //var secondPath = new Path();

            firstPath.GenerateRandomPath(startingCityId, citiesDictionary);
            //secondPath.GenerateRandomPath(startingCityId, citiesDictionary);

            //return firstPath.GetTotalLengthOfPath() < secondPath.GetTotalLengthOfPath() ? firstPath : secondPath;
            return firstPath;
        }

        public Path GenerateGreedyPath(int startingCityId)
        {
            var path = new Path();
            path.GeneratePath(startingCityId, citiesDictionary);

            return path;
        }

        public Path ILS(int startingCityId)
        {
            Path bestPath = new Path();
            var bestPathLength = int.MaxValue;

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 2; i++)
            {
                //var pathLocal = GenerateGreedyPath(startingCityId);
                var pathLocal = GenerateRandomPath(startingCityId);
                LocalSearchHelper.LocalSearch(pathLocal, citiesDictionary);
                var pathLocalLength = pathLocal.GetTotalLengthOfPath();
                
                for(int j = 0; j < 15; j++)
                {
                    if (stopwatch.Elapsed.Seconds > 19)
                    {
                        StopAndSaveTime(stopwatch);
                        return bestPath;
                    }

                    var path = pathLocal.CopyPath();
                    DisturbHelper.Disturb(path);
                    LocalSearchHelper.LocalSearch(path, citiesDictionary);
                    var pathLength = path.GetTotalLengthOfPath();
                    
                    if(pathLength < bestPathLength)
                    {
                        bestPath = path;
                        pathLocal = path;

                        bestPathLength = pathLength;
                        pathLocalLength = pathLength;
                    }
                    else if(pathLength < pathLocalLength)
                    {
                        pathLocal = path;
                        pathLocalLength = pathLength;
                    }
                }
            }

            StopAndSaveTime(stopwatch);
            return bestPath;

        }

        public Path Basic_VNS(int startingCityId)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            //var bestPath = GenerateRandomPath(startingCityId);
            var bestPath = GenerateGreedyPath(startingCityId);
            var bestPathLength = bestPath.GetTotalLengthOfPath();

            while(true)
            {
                var k = 1;
                while (k < 4)
                {
                    if (stopwatch.Elapsed.Seconds > 18)
                    {
                        StopAndSaveTime(stopwatch);
                        return bestPath;
                    }

                    var path = bestPath.CopyPath();
                    DisturbHelper.Disturb(path, k);
                    LocalSearchHelper.LocalSearch(path, citiesDictionary);

                    var pathLength = path.GetTotalLengthOfPath();

                    if(pathLength < bestPathLength)
                    {
                        bestPath = path;
                        bestPathLength = pathLength;
                        k = 1;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
        }

        private void StopAndSaveTime(Stopwatch stopwatch)
        {
            stopwatch.Stop();
            Statistics.LastExecutionTimeMiliSeconds = stopwatch.ElapsedMilliseconds;
        }
    }
}
