using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagementSystem
{
    public class Doctor
    {
        public string RegistrationNo { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Specialization { get; set; }
        public string Address { get; set; }
        public string Timings { get; set; }
        public string ContactNo { get; set; }

        public Doctor(string registrationNo, string name, string city, string specialization, string address, string timings, string contactNo)
        {
            RegistrationNo = registrationNo;
            Name = name;
            City = city;
            Specialization = specialization;
            Address = address;
            Timings = timings;
            ContactNo = contactNo;
        }
    }
}