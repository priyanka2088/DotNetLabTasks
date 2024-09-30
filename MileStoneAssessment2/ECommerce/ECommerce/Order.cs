using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce
{
    internal class Order
    {
        // Properties
        public List<Product> Products { get; set; }
        public decimal Total { get; set; }

        // Constructor
        public Order()
        {
            Products = new List<Product>();
            Total = 0;
        }

        public virtual decimal CalculateTotal()
        {
            return Total;
        }

        // Method to add a product to the order
        public void AddProduct(Product product)
        {
            Products.Add(product);
            Total += product.Price;
        }
        public void AddProduct(string name, decimal price, string category)
        {
            Products.Add(new Product(name, price, category));
            Total += price;
        }

        // Method to display the order details
        public void DisplayOrder()
        {
            Console.WriteLine("Order Details:");
            foreach (var product in Products)
            {
                product.DisplayProduct();
            }
            Console.WriteLine($"Total: {Total}");
        }
    }
}
