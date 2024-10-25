using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Identity.Client;


namespace SharePointListRetriever
{
    internal class Program
    {
        private const string clientId = "DotNetId"; // Client ID
        private const string clientSecret = "secret1234"; //  Client Secret
        private const string tenantId = "34sftyu8"; // Tenant ID
        private const string sharePointSiteUrl = "https://yourtenant.sharepoint.com/sites/dotnetsite"; //  site URL
        private const string listName = "List1"; //  list name

        static async Task Main(string[] args)
        {
            try
            {
                var client = await GetAuthenticatedGraphClient();
                var items = await GetSharePointListItems(client, sharePointSiteUrl, listName);

                Console.WriteLine($"{listName} List:");
                foreach (var item in items)
                {
                    Console.WriteLine($"- {item.Fields.AdditionalData["Title"]}: {item.Fields.AdditionalData["Description"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred.");
                Console.WriteLine(ex.Message);
            }
        }

        private static async Task<GraphServiceClient> GetAuthenticatedGraphClient()
        {
            var app = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority($"https://login.microsoftonline.com/{tenantId}")
                .Build();

            var scopes = new[] { "https://graph.microsoft.com/.default" };
            var authResult = await app.AcquireTokenForClient(scopes).ExecuteAsync();

            var graphClient = new GraphServiceClient(new DelegateAuthenticationProvider (
                requestMessage =>
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                    return Task.CompletedTask;
                }));

            return graphClient;
        }

        private static async Task<IEnumerable<ListItem>> GetSharePointListItems(GraphServiceClient client, string siteUrl, string listName)
        {
            // Get the hostname and the site-relative path
            var siteRelativePath = siteUrl.Replace("https://yourtenant.sharepoint.com", "").Trim('/');

            // Get the site using the hostname and site-relative path
            var site = await client.Sites["dotnettenant.sharepoint.com"].Sites[siteRelativePath].Request().GetAsync();

            // Get the list by its name
            var list = await client.Sites[site.Id].Lists[listName].Request().GetAsync();

            // Get the items from the list
            var listItems = await client.Sites[site.Id].Lists[list.Id].Items.Request().GetAsync();
            return listItems.CurrentPage;
        }
    }
}