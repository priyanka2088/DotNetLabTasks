using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement
{
    public interface IBooking
    {
        void BookTicket(Flight flight, Passenger passenger);
        int GetBookingId(); // Method to get booking ID
        void CancelBooking(int bookingId);
        string GetBookingDetails(int bookingId);
    }
}
