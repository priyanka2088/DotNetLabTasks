using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace ZomatoApp
{
    public class BoxIntegration
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task UploadFileAsync(string filePath)
        {
            var fileContent = new MultipartFormDataContent();
            var stream = new ByteArrayContent(File.ReadAllBytes(filePath));
            fileContent.Add(stream, "file", Path.GetFileName(filePath));

            try
            {
                var response = await client.PostAsync("https://api.box.com/2.0/files/content", fileContent);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"File uploaded successfully: {Path.GetFileName(filePath)}");
                }
                else
                {
                    Console.WriteLine($"File upload failed: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading file: {ex.Message}");
            }
        }
    }
}