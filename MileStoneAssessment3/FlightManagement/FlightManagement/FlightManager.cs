using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement
{
    public class FlightManager
    {
        private Flight[] flightArray = new Flight[10];
        private List<Flight> flightList = new List<Flight>();

        public void LoadFlights(List<Flight> flights)
        {
            flightList.AddRange(flights);
            foreach (var flight in flights)
            {
                AddFlightToArray(flight); // Add to array as well
            }
        }

        public void AddFlight(Flight flight)
        {
            AddFlightToArray(flight); // Add to array
            flightList.Add(flight);   // Add to list
        }

        private void AddFlightToArray(Flight flight)
        {
            for (int i = 0; i < flightArray.Length; i++)
            {
                if (flightArray[i] == null)
                {
                    flightArray[i] = flight;
                    break;
                }
            }
        }

        public bool RemoveFlight(string flightNumber)
        {
            bool removedFromArray = false;
            for (int i = 0; i < flightArray.Length; i++)
            {
                if (flightArray[i]?.FlightNumber == flightNumber)
                {
                    flightArray[i] = null; // Remove from array
                    removedFromArray = true;
                    break;
                }
            }
            // Remove from the list as well
            bool removedFromList = flightList.RemoveAll(f => f.FlightNumber == flightNumber) > 0;

            return removedFromArray || removedFromList; // Return true if removed from either
        }

        public Flight SearchFlight(string flightNumber)
        {
            Flight flight = SearchFlightInArray(flightNumber);
            return flight ?? flightList.Find(f => f.FlightNumber == flightNumber); // Return from list if not found in array
        }

        private Flight SearchFlightInArray(string flightNumber)
        {
            foreach (var flight in flightArray)
            {
                if (flight?.FlightNumber == flightNumber)
                {
                    return flight;
                }
            }
            return null; // Not found in array
        }

        public List<Flight> GetAllFlights()
        {
            return flightList;
        }

        // Querying methods
        public List<Flight> FilterFlightsByDestination(string destination)
        {
            return flightList.Where(f => f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Flight> SortFlightsByFare()
        {
            return flightList.OrderBy(f => f.CalculateFare()).ToList();
        }

        public IGrouping<string, Flight>[] GroupFlightsByType()
        {
            return flightList.GroupBy(f => f is DomesticFlight ? "Domestic" : "International").ToArray();
        }
    }
}
