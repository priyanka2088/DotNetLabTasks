using static System.Net.Mime.MediaTypeNames;
using Microsoft.Office.Interop.Outlook;
using System;

namespace MSOutlookInterOp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Initialize Outlook application
                Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
                NameSpace outlookNamespace = outlookApp.GetNamespace("MAPI");

                // Get the default calendar folder
                MAPIFolder calendarFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);

                // Define the time range for upcoming events
                DateTime startTime = DateTime.Now;
                DateTime endTime = startTime.AddDays(30); // Next 30 days

                // Filter calendar items
                Items calendarItems = calendarFolder.Items;
                calendarItems.IncludeRecurrences = true;
                calendarItems.Sort("[Start]");

                // Restrict to upcoming events
                string filter = $"[Start] >= '{startTime.ToString("g")}' AND [Start] <= '{endTime.ToString("g")}'";
                Items filteredItems = calendarItems.Restrict(filter);

                // Output upcoming events
                Console.WriteLine("Upcoming Events:");
                foreach (AppointmentItem item in filteredItems)
                {
                    Console.WriteLine($"- {item.Subject}: {item.Start.ToString("g")}");
                }
            }
            catch (System.Runtime.InteropServices.COMException comEx)
            {
                Console.WriteLine("Error accessing Outlook. Please ensure Outlook is installed and you have permission.");
                Console.WriteLine($"COM Exception: {comEx.Message}");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("An error occurred.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
