using Helpers;
using Helpers.Structures;
using System;
using System.Collections.Generic;

namespace ConsoleChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            var filepath = "Test.txt";
            var cityPath = "miasta.txt";
            var connectionsPath = "polaczenia.txt";

            var loadedData = FileLoader.LoadCitiesFromCityFiles(cityPath, connectionsPath);

            Console.WriteLine(MaxPossiblePathsHelper.GetMaxPossiblePathsAmount(116, 118, loadedData));

        }
    }
}
