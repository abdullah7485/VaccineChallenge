using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineChallenge
{
    public class Person
    {
        public string Name;
        public int Age;
        public string Latitude;
        public string Longitude;
        public string NearestCenter;
        public string Contact;

        public double Longt
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