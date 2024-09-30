using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce
{
    internal class PaymentProcessor : IOrderProcessor
    {
        public void CancelOrder()
        {
            Console.WriteLine("payment for the order has been cancelled");
        }

        public void ProcessOrder()
        {
            Console.WriteLine("Processing order");
        }
    }
}
