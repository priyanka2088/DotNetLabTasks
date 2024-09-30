
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement
{
    using System.Text.RegularExpressions;

    public class Validation
    {
        public bool ValidateFlightNumber(string flightNumber)
        {
            return Regex.IsMatch(flightNumber, @"^FL\d{4}$");
        }

        public bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public bool ValidatePhone(string phone)
        {
            return Regex.IsMatch(phone, @"^\+?\d{10,15}$");
        }
    }

}
