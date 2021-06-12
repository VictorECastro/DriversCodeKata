using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeKata_Drivers.Models
{
    public class Driver
    {
        public string driverName { get; set; }
        public double TotalMiles { get; set; }
        public double avgSpeed { get; set; }
        public List<Trip> trips { get; set; }
    }
}
