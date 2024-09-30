using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement
{
    public class InternationalFlight : Flight
    {
        public double Tax { get; set; }

        public override double CalculateFare()
        {
            return BaseFare + Tax;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"International Flight {FlightNumber} to {Destination}, Fare: {CalculateFare()}");
        }
    }
}
