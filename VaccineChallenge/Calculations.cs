using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineChallenge
{
    public class Calculations
    {
        /// <summary>
        /// calculate distance from the person to every branch and select the minimum distance
        /// </summary>
        /// <param name="lat">Person's location latitude value</param>
        /// <param name="longt">Person's location longitude value</param>
        /// /// <param name="centersList">Vaccination Centers list</param>
        /// <returns>return the branch</returns>
        public static string GetNearestCenter(double lat, double longt, List<VaccineCenter> centersList)
        {
            string branch = "";
            double MinDistance = double.MaxValue;
            foreach (var center in centersList)
            {
                double distance = Calculations.CalcDistance(lat, longt, center.Lat, center.Long);
                if (Math.Abs(distance) < MinDistance)
                {
                    MinDistance = Math.Abs(distance);
                    branch = center.Name;
                }
            }
            return branch;
        }

        /// <summary>
        /// calculates the distance between two points (given the latitude/longitude of those points).
        /// </summary>
        /// <param name="lat1"> Latitude of point 1 (in decimal degrees)</param>
        /// <param name="lon1"> Longitude of point 1 (in decimal degrees)</param>
        /// <param name="lat2">Latitude of point 2 (in decimal degrees)</param>
        /// <param name="lon2">Longitude of point 2 (in decimal degrees)</param>
        /// <returns>distance by KiloMeter</returns>
        public static double CalcDistance(double lat1, double lon1, double lat2, double lon2)
        {
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return 0;
            }
            else
            {
                double theta = Math.Abs(lon1) - Math.Abs(lon2);
                //double theta = lon1 - lon2;

                double CentralAngelRadians = Math.Acos( Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta)) );
                double Raidus = 6371.009;
                double distance = CentralAngelRadians * Raidus;

                return (distance);
                
            }
        }

        
        //to convert decimal degrees to radians
        private static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //to convert radians to decimal degrees
        private static double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}