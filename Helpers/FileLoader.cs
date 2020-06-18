using Helpers.Structures;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Helpers
{
    public class FileLoader
    {
        public static Dictionary<int,City> LoadCitiesFromTestFile(string filePath)
        {
            var citiesList = new Dictionary<int,City>();
            var isFirstLineRead = false;
            int cityCount;
            int cityIndex = 1;

            foreach (var readLine in File.ReadLines(filePath))
            {
                if (!isFirstLineRead)
                {
                    var inputValues = readLine.Split(' ');
                    cityCount = int.Parse(inputValues[0]);

                    isFirstLineRead = true;
                    continue;
                }

                else
                {
                    var inputValues = readLine.Split(' ');
                    var newCity = new City
                    {
                        CityId = cityIndex,
                        CoordinateX = float.Parse(inputValues[0], NumberStyles.Float, CultureInfo.InvariantCulture),
                        CoordinateY = float.Parse(inputValues[1], NumberStyles.Float, CultureInfo.InvariantCulture),
                        PackageWeigth = int.Parse(inputValues[2])
                    };

                    citiesList.Add(cityIndex, newCity);
                    cityIndex++;
                }
            }

            return citiesList;
        }

        public static Dictionary<int, City> LoadCitiesFromCityFiles(string cityFilePath, string connectionFilePath)
        {
            var citiesList = new Dictionary<int, City>();
            var isFirstLineRead = false;
            int cityCount;
            int cityIndex = 1;

            foreach (var readLine in File.ReadLines(cityFilePath))
            {
                if (!isFirstLineRead)
                {
                    var inputValues = readLine.Split(' ');
                    cityCount = int.Parse(inputValues[0]);

                    isFirstLineRead = true;
                    continue;
                }

                else
                {
                    var inputValues = readLine.Split(' ');
                    var newCity = new City
                    {
                        CityId = cityIndex,
                        CoordinateX = float.Parse(inputValues[0], NumberStyles.Float, CultureInfo.InvariantCulture),
                        CoordinateY = float.Parse(inputValues[1], NumberStyles.Float, CultureInfo.InvariantCulture),
                        PackageWeigth = int.Parse(inputValues[2])
                    };

                    citiesList.Add(cityIndex, newCity);
                    cityIndex++;
                }
            }

            return citiesList;
        }




    }
}
