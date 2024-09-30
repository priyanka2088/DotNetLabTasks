using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce
{
    //Method Overriding
    internal class DiscountedOrder : Order
    {
        public decimal Discount { get; set; }

        public override decimal CalculateTotal()
        {

            return Total - Discount;
        }
    }
}