using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECommerce
{
    internal class Admin : Person
    {
        public string AdminID { get; set; }

        public Admin(string name, string email, string adminId) : base(name, email)
        {
            AdminID = adminId;
        }

        public void ManageSystem()
        {
            Console.WriteLine($"{Name} is managing the system.");
        }
    }
}