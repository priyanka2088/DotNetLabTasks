using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Identity.Client;
using Microsoft.Graph.Authentication; // Include this for ClientCredentialProvider

namespace O365Apps
{
    internal class Program
    {
        private const string clientId = "DotNetId"; // Your Azure app client ID
        private const string tenantId = "34sftyu8"; // Your Azure tenant ID
        private const string clientSecret = "secret1234"; // Your Azure app client secret

        static async Task Main(string[] args)
        {
            Console.Write("SharePoint Site URL: ");
            string siteUrl = Console.ReadLine();

            Console.Write("List Name: ");
            string listName = Console.ReadLine();

            Console.Write("Item ID: ");
            string itemId = Console.ReadLine();

            Console.Write("Updated Title: ");
            string updatedTitle = Console.ReadLine();

            try
            {
                // Authenticate and create Graph client
                var graphClient = GetGraphServiceClient();

                // Get the site ID from the URL
                var siteId = await GetSiteId(graphClient, siteUrl);

                // Update the list item
                await UpdateListItem(graphClient, siteId, listName, itemId, updatedTitle);

                Console.WriteLine($"Item updated successfully: Task ID {itemId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static GraphServiceClient GetGraphServiceClient()
        {
            IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithTenantId(tenantId)
                .WithClientSecret(clientSecret)
                .Build();

            ClientCredentialProvider authProvider = new ClientCredentialProvider(app);
            return new GraphServiceClient(authProvider);
        }

        private static async Task<string> GetSiteId(GraphServiceClient graphClient, string siteUrl)
        {
            var uriParts = new Uri(siteUrl).AbsolutePath.Trim('/').Split('/');
            string siteName = uriParts.Length > 0 ? uriParts[0] : "";

            var site = await graphClient.Sites
                .GetByPath(siteName, "yourtenant.sharepoint.com") // Adjust if necessary
                .GetAsync();

            return site.Id;
        }

        private static async Task UpdateListItem(GraphServiceClient graphClient, string siteId, string listName, string itemId, string updatedTitle)
        {
            var listItem = new Microsoft.Graph.Models.ListItem
            {
                Fields = new Microsoft.Graph.Models.FieldValueSet
                {
                    AdditionalData = new Dictionary<string, object>
                    {
                        { "Title", updatedTitle }
                    }
                }
            };

            await graphClient.Sites[siteId].Lists[listName].Items[itemId]
                .ToGetRequestInformation()
                .UpdateAsync(listItem);
        }
    }
}
