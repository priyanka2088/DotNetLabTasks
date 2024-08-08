using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProblem
{
     interface IVehiculo
    {
        public void Drive();
        public bool Refuel(int amount);
    }
}
