using DoctorManagementSystem;
namespace DoctorManagementSystem
    {
        internal class Program
        {
            static void Main(string[] args)
            {
            DoctorManagementsystem.DoctorManagement system = new DoctorManagementsystem.DoctorManagement();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nDoctor Management System");
                        Console.WriteLine("1. Add Doctor");
                        Console.WriteLine("2. Search Doctor by Registration No");
                        Console.WriteLine("3. Exit");
                        Console.Write("Enter your choice: ");

                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                // Call the method to add a new doctor
                                system.AddDoctor();
                                break;
                            case "2":
                                // Call the method to search for a doctor by Registration No
                                system.SearchDoctor();
                                break;
                            case "3":
                                // Exit the application
                                Console.WriteLine("Exiting system.");
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    }
                }
            }
        }
    }