using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeKata_Drivers.Models
{
    public class Trip
    {
        public string driverName { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public double tripTime { get; set; }
        public double milesDriven { get; set; }
    }
}
