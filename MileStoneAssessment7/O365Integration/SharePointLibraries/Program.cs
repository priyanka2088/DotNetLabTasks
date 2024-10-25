using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using Microsoft.SharePoint.Client;


namespace SharePointLibraries
{
    internal class Program
        {
            static void Main(string[] args)
            {
                // Input from user (you can change these to be passed as arguments)
                string siteUrl = "https://yourtenant.sharepoint.com/sites/dotnetsite";
                string libraryName = "Documents";

                try
                {
                    // Prompt user for credentials
                    Console.WriteLine("Enter your SharePoint username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter your SharePoint password:");
                    SecureString password = GetPassword();

                    // Connect to SharePoint site
                    ClientContext context = new ClientContext(siteUrl)
                    {
                    
                        Credentials = new SharePointOnlineCredentials(username, password)
                    };

                    // Get the SharePoint document library
                    Web web = context.Web;
                    List documentLibrary = web.Lists.GetByTitle(libraryName);
                    CamlQuery query = CamlQuery.CreateAllItemsQuery(100); // Adjust query for pagination
                    ListItemCollection items = documentLibrary.GetItems(query);

                    context.Load(items);
                    context.ExecuteQuery();

                    // Output list of documents
                    Console.WriteLine("\nDocument List:");
                    foreach (ListItem item in items)
                    {
                        Console.WriteLine($"- {item["FileLeafRef"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            // Helper function to securely input password
            private static SecureString GetPassword()
            {
                SecureString password = new SecureString();
                while (true)
                {
                    var key = Console.ReadKey(intercept: true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    password.AppendChar(key.KeyChar);
                }
                return password;
            }
        }
    class SharePointOnlineCredentials:ICredentials
    {
        public SharePointOnlineCredentials(string username, SecureString password)
        {
            string str_username = username;
            SecureString str_password = password;
        }
        public NetworkCredential? GetCredential(Uri uri, string authType)
        {
            throw new NotImplementedException();
        }
    }
    }