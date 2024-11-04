using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZomatoApp.Models;

namespace ZomatoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private static List<Restaurant> restaurants = new List<Restaurant>
        {
            new Restaurant { Name = "Pizza Place", Address = "123 Main St", Rating = 4.5 },
            new Restaurant { Name = "Pasta House", Address = "456 Elm St", Rating = 4.2 }
        };

        private const string ExcelPath = @"C:\Users\Administrator\Desktop\CSharp\Tasks\Assignments\ZomatoApp\Data\restaurants.xlsx";
        private const string XmlPath = @"C:\Users\Administrator\Desktop\CSharp\Tasks\Assignments\ZomatoApp\Data\restaurants.xml";
        private const string CsvPath = @"C:\Users\Administrator\Desktop\CSharp\Tasks\Assignments\ZomatoApp\Data\menu.csv";
        private const string JsonPath = @"C:\Users\Administrator\Desktop\CSharp\Tasks\Assignments\ZomatoApp\Data\reviews.json";
        private const string filePath = @"C:\Users\Administrator\Desktop\CSharp\Tasks\Assignments\ZomatoApp\Data\menu.pdf";



        // XML handling
        [HttpGet("parse-xml")]
        public IActionResult ParseXml()
        {
            XmlHandler.ParseXml(XmlPath);
            return Ok("XML parsed successfully.");
        }

        // CSV handling
        [HttpGet("parse-csv")]
        public IActionResult ParseCsv()
        {
            CsvHandler.ParseCsv(CsvPath);
            return Ok("CSV parsed successfully.");
        }

        // Read Excel file
        [HttpGet("read-excel")]
        public IActionResult ReadExcel()
        {
            ExcelHandler.ReadExcel(ExcelPath);
            return Ok("Excel file read successfully.");
        }

        // JSON handling
        [HttpGet("parse-json")]
        public IActionResult ParseJson()
        {
            string jsonContent = System.IO.File.ReadAllText(JsonPath);
            JsonHandler.ParseJson(jsonContent);
            return Ok("JSON parsed successfully.");
        }

        // GET: api/restaurants
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetRestaurants()
        {
            return Ok(restaurants);
        }

        // GET: api/restaurants/{name}
        [HttpGet("{name}")]
        public ActionResult<Restaurant> GetRestaurant(string name)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        // POST: api/restaurants
        [HttpPost]
        public ActionResult<Restaurant> CreateRestaurant([FromBody] Restaurant restaurant)
        {
            if (restaurant == null)
            {
                return BadRequest("Restaurant data is null.");
            }
            restaurants.Add(restaurant);
            return CreatedAtAction(nameof(GetRestaurant), new { name = restaurant.Name }, restaurant);
        }

        // PUT: api/restaurants/{name}
        [HttpPut("{name}")]
        public IActionResult UpdateRestaurant(string name, [FromBody] Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            if (restaurant == null)
            {
                return NotFound();
            }
            restaurant.Address = updatedRestaurant.Address;
            restaurant.Rating = updatedRestaurant.Rating;
            return NoContent();
        }

        // DELETE: api/restaurants/{name}
        [HttpDelete("{name}")]
        public IActionResult DeleteRestaurant(string name)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
            if (restaurant == null)
            {
                return NotFound();
            }
            restaurants.Remove(restaurant);
            return NoContent();
        }

        [HttpGet("fetch-incidents")]                               //Servicenow Integration
        public async Task<IActionResult> FetchIncidents()
        {
            var incidents = await ServiceNowIntegration.GetIncidentsAsync();


            var response = new List<string>();
            foreach (var incident in incidents)
            {
                response.Add($"Incident ID: {incident.SysId}, Short Description: {incident.ShortDescription}");
            }

            return Ok(response); // Return the list as the response
        }


        [HttpPost("upload-file")]                                 // BoxApi
        public async Task<IActionResult> UploadFile([FromBody] string filePath)
        {
            await BoxIntegration.UploadFileAsync(filePath);
            return Ok("File uploaded successfully.");
        }
    }
}