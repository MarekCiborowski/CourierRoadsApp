using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.Structures
{
    public class CityInPath 
    {
        public int CityId { get; set; }

        public int FirstConnectionId { get; set; } = 0;

        public int SecondConnectionId { get; set; } = 0;

        public CityInPath(CityInPath cityInPath)
        {
            this.CityId = cityInPath.CityId;
            this.FirstConnectionId = cityInPath.FirstConnectionId;
            this.SecondConnectionId = cityInPath.SecondConnectionId;
        }

        public CityInPath(int cityId)
        {
            this.CityId = cityId;
        }

        public CityInPath()
        {
        }
    }
}
