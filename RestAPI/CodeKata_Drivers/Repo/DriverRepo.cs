using CodeKata_Drivers.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeKata_Drivers.Repo
{
    public class DriverRepo
    {
        public Driver AddDriver(string driverName, List<Driver> drivers)
        {
            Driver dr = new Driver();
            if (drivers.Count == 0)
            {
                dr = SetDriver(driverName);
            }
            else
            {
                bool x = drivers.Any(drv => drv.driverName == driverName);
                if (!x)
                {
                    dr = SetDriver(driverName);
                }
            }


            return dr;
        }

        public string GetDriverReport(Driver d)
        {
           
            string report = "";
            double totalMiles = 0;
            double totHours = 0;
            double avgSpeed = 0;
            foreach (Trip t in d.trips)
            {
                totalMiles += t.milesDriven;
                totHours += t.tripTime;
            }
            avgSpeed = totalMiles / totHours;

            if (totalMiles == 0)
                report = string.Format("{0}: 0 miles", d.driverName);
            else
                report = String.Format("{0}: {1} miles @ {2} mph", d.driverName, Math.Round(totalMiles), Math.Round(avgSpeed));

            return report;
        }

        private Driver SetDriver(string driverName)
        {
            Driver driver = new Driver()
            {
                driverName = driverName,
                TotalMiles = 0,
                avgSpeed = 0,
                trips = new List<Trip>()
            };
            return driver;
        }
    }
}
