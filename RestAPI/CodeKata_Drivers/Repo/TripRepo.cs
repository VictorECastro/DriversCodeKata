using CodeKata_Drivers.Models;
using System;
using System.Collections.Generic;

namespace CodeKata_Drivers.Repo
{
    public class TripRepo
    {
        public List<Driver> GetTripToAdd(string driverName, string startTime, string endtime, string milesDriven, List<Driver> drivers)
        {
            Trip trip = new Trip()
            {
                driverName = driverName,
                startTime = getTime(startTime),
                endTime = getTime(endtime),
                tripTime = getTripTime(getTime(startTime), getTime(endtime)),
                milesDriven = Convert.ToDouble(milesDriven)
            };

            if (isValid(trip))
            {
                int index = drivers.FindIndex(dv => dv.driverName == driverName);
                if (index >= 0)
                {
                    drivers[index].trips.Add(trip);
                }
                return drivers;

            }
            else
                return null;
        }

        public DateTime getTime(string val)
        {
            DateTime dt = Convert.ToDateTime(val);
            return dt;
        }
        public double getTripTime(DateTime startTime, DateTime endTime)
        {
            TimeSpan ts = endTime - startTime;
            return ts.TotalHours;

        }
        private double getHours(DateTime time)
        {
            double hour = time.Hour;
            double minute = time.Minute;

            return hour + minute;
        }
        public bool isValid(Trip trip)
        {
            double miles = (double)Math.Round(trip.milesDriven);
            double mph = miles / trip.tripTime;
            bool valid = true;

            if (mph < 5 || mph > 100)
                valid = false;

            return valid;
        }
    }
}
