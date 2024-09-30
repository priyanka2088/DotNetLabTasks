using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FlightManagement
{
    public class FileHandler
    {
        public void ReadFlightsFromFile(string filePath, List<Flight> flights)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 3) // Domestic Flight
                {
                    if (double.TryParse(parts[2], out double baseFare))
                    {
                        flights.Add(new DomesticFlight
                        {
                            FlightNumber = parts[0],
                            Destination = parts[1],
                            BaseFare = baseFare
                        });
                    }
                }
                else if (parts.Length == 4) // International Flight
                {
                    if (double.TryParse(parts[2], out double baseFare) && double.TryParse(parts[3], out double tax))
                    {
                        flights.Add(new InternationalFlight
                        {
                            FlightNumber = parts[0],
                            Destination = parts[1],
                            BaseFare = baseFare,
                            Tax = tax
                        });
                    }
                }
            }
        }

        public void WriteFlightsToFile(string filePath, List<Flight> flights)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var flight in flights)
                {
                    if (flight is DomesticFlight domesticFlight)
                    {
                        writer.WriteLine($"{domesticFlight.FlightNumber},{domesticFlight.Destination},{domesticFlight.BaseFare}");
                    }
                    else if (flight is InternationalFlight internationalFlight)
                    {
                        writer.WriteLine($"{internationalFlight.FlightNumber},{internationalFlight.Destination},{internationalFlight.BaseFare},{internationalFlight.Tax}");
                    }
                }
            }
        }
    }


}