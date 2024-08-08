using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProblem
{
    internal class Car:IVehiculo
    {
        public int gasolineAmount;
        public Car(int startingGasolineAmount)
        {
            this.gasolineAmount = startingGasolineAmount;
        }
        public void Drive()
        {
            if(gasolineAmount > 0)
            {
                Console.WriteLine("Driving");
            }
        }
        public bool Refuel(int amount)
        {
            gasolineAmount += amount;
            return true;
        }
    }
}
