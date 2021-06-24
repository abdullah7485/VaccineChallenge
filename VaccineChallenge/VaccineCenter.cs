using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineChallenge
{
    public class VaccineCenter
    {
        public string Name;
        public string Latitude;
        public string Longitude;

        public double Long
        {
            get
            {
                double longitude = 0;
                double.TryParse(Longitude, out longitude);
                return longitude;
            }
        }

        public double Lat
        {
            get
            {
                double lat = 0;
                double.TryParse(Latitude, out lat);
                return lat;
            }
        }
    }
}

