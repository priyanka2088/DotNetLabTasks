using static System.Net.Mime.MediaTypeNames;
using System;
using Microsoft.Office.Interop.Outlook;

namespace OutlookEmailSender
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sample input data
            string recipient = "recipient@example.com";
            string subject = "Monthly Report";
            string body = "Please find the attached report.";
            string attachmentPath = @"C:\path\to\report.pdf"; // Change to your file path

            try
            {
                // Initialize Outlook application
                Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();

                // Create a new mail item
                MailItem mailItem = (MailItem)outlookApp.CreateItem(OlItemType.olMailItem);
                mailItem.To = recipient;
                mailItem.Subject = subject;
                mailItem.Body = body;

                // Add attachment
                if (!string.IsNullOrEmpty(attachmentPath))
                {
                    mailItem.Attachments.Add(attachmentPath);
                }

                // Send the email
                mailItem.Send();
                Console.WriteLine($"Email sent successfully to {recipient}");
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
