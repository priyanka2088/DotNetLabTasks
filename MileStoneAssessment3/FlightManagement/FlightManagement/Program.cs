using System;
using System.Collections.Generic;

namespace FlightManagement
    {
        class Program
        {
            static void Main()
            {
                var flightManager = new FlightManager();
                var fileHandler = new FileHandler();
                var validation = new Validation();
                var flights = new List<Flight>();
                IBooking booking = new OnlineBooking();

                // Load initial data from file
                fileHandler.ReadFlightsFromFile("flights.csv", flights);
                flightManager.LoadFlights(flights);

                // Main menu loop
                while (true)
                {
                    Console.WriteLine("\nFlight Booking System");
                    Console.WriteLine("1. Add Flight");
                    Console.WriteLine("2. Book Ticket");
                    Console.WriteLine("3. Cancel Booking");
                    Console.WriteLine("4. Search Flight");
                    Console.WriteLine("5. Display All Flights");
                    Console.WriteLine("6. Filter Flights");
                    Console.WriteLine("7. Sort Flights");
                    Console.WriteLine("8. Group Flights");
                    Console.WriteLine("9. Remove Flight");
                    Console.WriteLine("10. Exit");

                    var choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            AddFlight(flightManager, validation);
                            break;
                        case "2":
                            BookTicket(flightManager, validation, booking);
                            break;
                        case "3":
                            CancelBooking(booking);
                            break;
                        case "4":
                            SearchFlight(flightManager);
                            break;
                        case "5":
                            DisplayAllFlights(flightManager);
                            break;
                        case "6":
                            FilterFlights(flightManager);
                            break;
                        case "7":
                            SortFlights(flightManager);
                            break;
                        case "8":
                            GroupFlights(flightManager);
                            break;
                        case "9":
                            RemoveFlight(flightManager); // Call the new method
                            break;
                        case "10":
                            return; // Exit
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }

            static void AddFlight(FlightManager flightManager, Validation validation)
            {
                Console.WriteLine("Enter Flight Type (Domestic/International): ");
                var flightType = Console.ReadLine();

                Console.WriteLine("Enter Flight Number (Format: FL1234): ");
                var flightNumber = Console.ReadLine();

                // Validate the flight number format
                if (!validation.ValidateFlightNumber(flightNumber))
                {
                    Console.WriteLine("Invalid flight number format. Please use format FL1234.");
                    return;
                }

                Console.WriteLine("Enter Destination: ");
                var destination = Console.ReadLine();

                Console.WriteLine("Enter Base Fare: ");
                var baseFare = double.Parse(Console.ReadLine());

                if (flightType.Equals("Domestic", StringComparison.OrdinalIgnoreCase))
                {
                    flightManager.AddFlight(new DomesticFlight { FlightNumber = flightNumber, Destination = destination, BaseFare = baseFare });
                }
                else if (flightType.Equals("International", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter Tax: ");
                    var tax = double.Parse(Console.ReadLine());
                    flightManager.AddFlight(new InternationalFlight { FlightNumber = flightNumber, Destination = destination, BaseFare = baseFare, Tax = tax });
                }
                else
                {
                    Console.WriteLine("Invalid flight type.");
                }
            }

            static void BookTicket(FlightManager flightManager, Validation validation, IBooking booking)
            {
                Console.WriteLine("Enter Flight Number to book: ");
                var flightNumber = Console.ReadLine();

                // Validate flight number
                if (!validation.ValidateFlightNumber(flightNumber))
                {
                    Console.WriteLine("Invalid flight number format. Please use format FL1234.");
                    return;
                }

                var flight = flightManager.SearchFlight(flightNumber);

                if (flight != null)
                {
                    Console.WriteLine("Enter Passenger Name: ");
                    var passengerName = Console.ReadLine();

                    Console.WriteLine("Enter Passenger Email: ");
                    var email = Console.ReadLine();
                    if (!validation.ValidateEmail(email))
                    {
                        Console.WriteLine("Invalid email format.");
                        return;
                    }

                    Console.WriteLine("Enter Passenger Phone: ");
                    var phone = Console.ReadLine();
                    if (!validation.ValidatePhone(phone))
                    {
                        Console.WriteLine("Invalid phone format.");
                        return;
                    }

                    var passenger = new Passenger { Name = passengerName, Email = email, Phone = phone };
                    booking.BookTicket(flight, passenger);

                    // Display the booking ID
                    Console.WriteLine($"Your booking ID is: {booking.GetBookingId()}");
                }
                else
                {
                    Console.WriteLine("Flight not found.");
                }
            }



            static void CancelBooking(IBooking booking)
            {
                Console.WriteLine("Enter Booking ID to cancel: ");
                if (int.TryParse(Console.ReadLine(), out int bookingId))
                {
                    // Display booking details before cancellation
                    string details = booking.GetBookingDetails(bookingId);
                    Console.WriteLine(details);

                    // Confirm cancellation
                    Console.WriteLine("Are you sure you want to cancel this booking? (yes/no)");
                    var confirmation = Console.ReadLine();

                    if (confirmation?.ToLower() == "yes")
                    {
                        booking.CancelBooking(bookingId);
                    }
                    else
                    {
                        Console.WriteLine("Cancellation aborted.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid booking ID.");
                }
            }


            static void SearchFlight(FlightManager flightManager)
            {
                Console.WriteLine("Enter Flight Number to search: ");
                var flightNumber = Console.ReadLine();
                var flight = flightManager.SearchFlight(flightNumber);  // Search for the flight in the FlightManager

                if (flight != null)
                {
                    flight.DisplayDetails();
                }
                else
                {
                    Console.WriteLine("Flight not found.");
                }
            }

            static void DisplayAllFlights(FlightManager flightManager)
            {
                var allFlights = flightManager.GetAllFlights(); // Retrieve all flights from the FlightManager
                foreach (var flight in allFlights)
                {
                    flight.DisplayDetails();
                }
            }

            static void FilterFlights(FlightManager flightManager)
            {
                Console.WriteLine("Enter destination to filter:");
                var destination = Console.ReadLine();
                // Get the filtered list of flights based on the provided destination
                var filteredFlights = flightManager.FilterFlightsByDestination(destination);
                // Check if any flights were found
                if (filteredFlights.Count == 0)
                {
                    Console.WriteLine("No flights available for the specified destination.");
                }
                else
                {
                    // Display the details of each filtered flight
                    foreach (var flight in filteredFlights)
                    {
                        flight.DisplayDetails();
                    }
                }
            }

            static void SortFlights(FlightManager flightManager)
            {
                var sortedFlights = flightManager.SortFlightsByFare(); // Retrieve a sorted list of flights based on fare
                foreach (var flight in sortedFlights)
                {
                    flight.DisplayDetails();
                }
            }

            static void GroupFlights(FlightManager flightManager)
            {
                // Get grouped flights based on their type (Domestic/International)
                var groupedFlights = flightManager.GroupFlightsByType();
                foreach (var group in groupedFlights)
                {
                    Console.WriteLine(group.Key);
                    foreach (var flight in group)
                    {
                        flight.DisplayDetails();
                    }
                }
            }

            static void RemoveFlight(FlightManager flightManager)
            {
                Console.WriteLine("Enter Flight Number to remove: ");
                var flightNumber = Console.ReadLine();

                if (flightManager.RemoveFlight(flightNumber))
                {
                    Console.WriteLine($"Flight {flightNumber} has been removed.");
                }
                else
                {
                    Console.WriteLine("Flight not found.");
                }
            }
        }

    }