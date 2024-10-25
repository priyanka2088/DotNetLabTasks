using Microsoft.SharePoint.Client;

namespace SharePointInteraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string siteUrl = GetInput("SharePoint Site URL: ");
            string libraryName = GetInput("Library Name: ");
            string filePath = GetInput("File Path: ");

            // Initialize SharePoint ClientContext
            using (ClientContext context = new ClientContext(siteUrl))
            {
                try
                {
                    // Assuming credentials are already set (e.g., using SharePointOnlineCredentials)

                    // Get the library by name
                    List documentsLibrary = context.Web.Lists.GetByTitle(libraryName);

                    // Prepare to upload a file
                    string fileName = Path.GetFileName(filePath);
                    string fileRelativeUrl = "/" + libraryName + "/" + fileName;

                    // Read the file from disk
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        // Use FileCreationInformation to set properties of the new file
                        FileCreationInformation fileInfo = new FileCreationInformation
                        {
                            ContentStream = fs,
                            Url = fileRelativeUrl,
                            Overwrite = true
                        };

                        // Upload the file to SharePoint
                        Microsoft.SharePoint.Client.File uploadFile = documentsLibrary.RootFolder.Files.Add(fileInfo);
                        context.Load(uploadFile);
                        context.ExecuteQuery();

                        Console.WriteLine($"File uploaded successfully: {fileName}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error uploading file: {ex.Message}");
                }
            }
        }

        // Helper method to get input from user
        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
