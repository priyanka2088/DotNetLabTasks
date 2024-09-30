
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement
{
    public class DomesticFlight : Flight
    {
        public override double CalculateFare()
        {
            return BaseFare;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Domestic Flight {FlightNumber} to {Destination}, Fare: {CalculateFare()}");
        }
    }
}
