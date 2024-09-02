using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoctorManagementSystem
{
    // Class to handle validations
    public static class Validator
    {
        public static bool ValidateRegistrationNo(string regNo)
        {
            // Validate Registration Number.The Registration Number must be exactly 7 digits long
            return Regex.IsMatch(regNo, @"^\d{7}$");
        }

        public static bool ValidateName(string name)
        {
            // The Name must contain only alphabets and spaces
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }

        public static bool ValidateContactNo(string contactNo)
        {
            // The Contact Number must be exactly 10 digits long
            return Regex.IsMatch(contactNo, @"^\d{10}$");
        }

        // Validate Clinic Timings: should not be empty
        public static bool ValidateClinicTimings(string timings)
        {
            return !string.IsNullOrWhiteSpace(timings);
        }
    }
}