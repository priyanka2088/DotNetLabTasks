using System;
using System.Collections.Generic;
using System.IO;

namespace ZomatoApp
{
    public static class CsvHandler
    {
        public static void ParseCsv(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("CSV file does not exist.");
                return;
            }

            var menuItems = new List<MenuItem>();

            using (var reader = new StreamReader(filePath))
            {
                string headerLine = reader.ReadLine(); // Read the header
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    var menuItem = new MenuItem
                    {
                        ItemName = values[0],
                        Price = decimal.Parse(values[1])
                    };
                    menuItems.Add(menuItem);
                }
            }

            // Display parsed items
            foreach (var item in menuItems)
            {
                Console.WriteLine($"Item: {item.ItemName}, Price: {item.Price}");
            }
        }
    }

    public class MenuItem
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}