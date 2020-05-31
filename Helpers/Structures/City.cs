using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Structures
{
    public class City
    {
        public int CityId { get; set; }

        public float CoordinateX { get; set; }

        public float CoordinateY { get; set; }

        public int PackageWeigth { get; set; }

        public Dictionary<int, int> Connections { get; set; } = new Dictionary<int, int>();// CityId/Distance between them
    }
}
