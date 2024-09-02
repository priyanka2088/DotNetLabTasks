using DoctorManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagementsystem
{
    internal class DoctorManagement
    {
            // Dictionary to store doctor information with Registration No as the key
            private readonly Dictionary<string, Doctor> doctors = new Dictionary<string, Doctor>();

            public void AddDoctor()
            {
                try
                {
                    string regNo;
                    // Loop until a valid and unique Registration No is entered
                    do
                    {
                        Console.Write("Enter Registration No (7 digits): ");
                        regNo = Console.ReadLine();

                        // Check if Registration No is valid
                        if (!Validator.ValidateRegistrationNo(regNo))
                        {
                            Console.WriteLine("Invalid Registration No. It should be 7 digits.");
                            continue;
                        }

                        // Check if the Registration No already exists
                        if (doctors.ContainsKey(regNo))
                        {
                            Console.WriteLine("Registration No already exists. Please enter a unique Registration No.");
                            regNo = null; // Reset regNo to prompt the user again
                        }
                    } while (string.IsNullOrEmpty(regNo));

                    string name;
                    // Loop until a valid Doctor Name is entered
                    do
                    {
                        Console.Write("Enter Doctor Name: ");
                        name = Console.ReadLine();
                        if (!Validator.ValidateName(name))
                        {
                            Console.WriteLine("Invalid Doctor Name. It should contain only alphabets.");
                        }
                    } while (!Validator.ValidateName(name));

                    string city;
                    // Loop until a valid City is entered (assuming no specific validation is required for City)
                    do
                    {
                        Console.Write("Enter City: ");
                        city = Console.ReadLine();
                        // Assuming there is no specific validation for City
                        break;
                    } while (true);

                    string specialization;
                    // Loop until a valid Area of Specialization is entered
                    do
                    {
                        Console.Write("Enter Area of Specialization: ");
                        specialization = Console.ReadLine();
                        if (!Validator.ValidateName(specialization))
                        {
                            Console.WriteLine("Invalid Area of Specialization. It should contain only alphabets.");
                        }
                    } while (!Validator.ValidateName(specialization));

                    string address;

                    Console.Write("Enter Clinic Address: ");
                    address = Console.ReadLine();


                    string timings;
                    // Loop until valid Clinic Timings are entered
                    do
                    {
                        Console.Write("Enter Clinic Timings: ");
                        timings = Console.ReadLine();
                        if (!Validator.ValidateClinicTimings(timings))
                        {
                            Console.WriteLine("Invalid Clinic Timings. It should not be empty.");
                        }
                    } while (!Validator.ValidateClinicTimings(timings));

                    string contactNo;
                    // Loop until a valid Contact No is entered
                    do
                    {
                        Console.Write("Enter Contact No (10 digits): ");
                        contactNo = Console.ReadLine();
                        if (!Validator.ValidateContactNo(contactNo))
                        {
                            Console.WriteLine("Invalid Contact No. It should be 10 digits.");
                        }
                    } while (!Validator.ValidateContactNo(contactNo));

                    // Create a new Doctor object and add it to the dictionary
                    Doctor doctor = new Doctor(regNo, name, city, specialization, address, timings, contactNo);
                    doctors[regNo] = doctor;
                    Console.WriteLine("Doctor added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while adding the doctor: {ex.Message}");
                }
            }

            public void SearchDoctor()
            {
                try
                {
                    Console.Write("Enter Registration No to search: ");
                    string regNo = Console.ReadLine();

                    if (doctors.TryGetValue(regNo, out Doctor doctor))
                    {
                        Console.WriteLine($"Registration No: {doctor.RegistrationNo}");
                        Console.WriteLine($"Name: {doctor.Name}");
                        Console.WriteLine($"City: {doctor.City}");
                        Console.WriteLine($"Specialization: {doctor.Specialization}");
                        Console.WriteLine($"Address: {doctor.Address}");
                        Console.WriteLine($"Timings: {doctor.Timings}");
                        Console.WriteLine($"Contact No: {doctor.ContactNo}");
                    }
                    else
                    {
                        Console.WriteLine("Doctor not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while searching for the doctor: {ex.Message}");
                }
            }
        }
    }
