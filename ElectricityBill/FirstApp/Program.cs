using System.Runtime.InteropServices;

namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int unit;
            double billamount,additional,cost;
            Console.WriteLine("Enter the Unit ");
            unit=Convert.ToInt32(Console.ReadLine());
            if (unit<=50)
            {
                billamount = unit * 0.50;
               

;            }
            else if(unit<=150)
            {
                billamount = 50 * 0.50 + (unit - 50) * 0.75;
            }
            else if(unit<=250)
            {
                billamount = 50 * 0.50 + 100 * 0.75 +(unit-150) * 1.20;
            }
            else
            {
                billamount = 50 * 0.50 + 100 * 0.75 + 100 * 1.20 + (unit - 250) * 1.50;

            }

            additional = (billamount / 100) * 20;
            cost = billamount + additional;
            Console.WriteLine("Electricity Bill = " + cost+"rupees");

        }
    }
}