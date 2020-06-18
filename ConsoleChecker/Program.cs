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
            var filepath = "Test2.txt";
            var mainHelper = new MainHelper();

            mainHelper.Initiate(filepath);
            mainHelper.GeneratePath(1);
        }
    }
}
