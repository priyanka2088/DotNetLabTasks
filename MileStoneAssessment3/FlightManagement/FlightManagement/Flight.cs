using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement
{
    public abstract class Flight
    {
        public string FlightNumber { get; set; }
        public string Destination { get; set; }
        public double BaseFare { get; set; }

        public abstract double CalculateFare();
        public abstract void DisplayDetails();
    }
}
