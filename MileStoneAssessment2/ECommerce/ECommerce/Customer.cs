using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerce
{
    internal class Customer : Person
    {
        public string CustomerID { get; set; }

        public Customer(string name, string email, string customerId) : base(name, email)
        {
            CustomerID = customerId;
        }

        public void PlaceOrder()
        {
            Console.WriteLine($"{Name} has placed an order.");
        }
    }
}