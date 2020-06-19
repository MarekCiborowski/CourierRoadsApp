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
            var mainHelper = new MainHelper();

            mainHelper.Initiate(filepath);

            var path = mainHelper.ILS(1);
            var x = path.GetTotalLengthOfPath();
            Console.WriteLine(x);
        }
    }
}
