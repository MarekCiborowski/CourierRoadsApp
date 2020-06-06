using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Structures
{
    public class CityInPath : City
    {
        public int DistanceToNextCity { get; set; } = 0;

        public CityInPath(City city)
        {
            this.CityId = city.CityId;
            this.Connections = city.Connections;
            this.CoordinateX = city.CoordinateX;
            this.CoordinateY = city.CoordinateY;
            this.PackageWeigth = city.PackageWeigth;
        }
    }
}
