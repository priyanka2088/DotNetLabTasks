using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce
{
    internal class Product
    {
        //encapsulation

        private string name;
        private decimal price;
        private string category;
        // Properties
        public string Name { get { return name; } set { name = value; } }
        public decimal Price { get { return price; } set { price = value; } }
        public string Category { get { return category; } set { category = value; } }

        // Constructor
        public Product(string name, decimal price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
        //update price
        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
        }
        // Method to display product information
        public void DisplayProduct()
        {
            Console.WriteLine($"Product: {Name}, Price: {Price}, Category: {Category}");
        }

    }
}
