using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce
{
    internal class ShippingProcessor : IOrderProcessor
    {
        public void CancelOrder()
        {
            Console.WriteLine("Cancel order for shipment");
        }

        public void ProcessOrder()
        {
            Console.WriteLine("process order for shipment");
        }
    }
}
