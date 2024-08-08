using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemOnMultiLevel
{
    class Teacher:Person
    {
        public void Explain()
        {
            Console.WriteLine("I'm explaining on the screen");
        }
        public void ShowAge(int x)
        {
            Console.WriteLine("My Age is " + x + "old in the screen");
        }
    }
}
