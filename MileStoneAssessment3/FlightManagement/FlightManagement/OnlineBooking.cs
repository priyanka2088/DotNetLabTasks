using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement
{
    public class OnlineBooking : IBooking
    {
        private static int bookingCounter = 0; // Static counter for booking IDs
        private Dictionary<int, (Flight flight, Passenger passenger)> bookings = new Dictionary<int, (Flight, Passenger)>();

        public void BookTicket(Flight flight, Passenger passenger)
        {
            bookingCounter++;
            bookings[bookingCounter] = (flight, passenger); // Store the flight and passenger details with the booking ID

            Console.WriteLine($"Booking confirmed for flight {flight.FlightNumber} with ID: {bookingCounter}");
        }

        public int GetBookingId()
        {
            // Return the last generated booking ID
            return bookingCounter;
        }

        public void CancelBooking(int bookingId)
        {
            if (bookings.Remove(bookingId))
            {
                Console.WriteLine($"Cancelled booking {bookingId}.");
            }
            else
            {
                Console.WriteLine($"Booking ID {bookingId} not found.");
            }
        }

        public string GetBookingDetails(int bookingId)
        {
            if (bookings.TryGetValue(bookingId, out var booking))
            {
                var flight = booking.flight;
                var passenger = booking.passenger;
                return $"Booking ID: {bookingId}, Flight: {flight.FlightNumber}, Passenger: {passenger.Name}, Email: {passenger.Email}, Phone: {passenger.Phone}";
            }
            return $"Booking ID {bookingId} not found.";
        }
    }

}
