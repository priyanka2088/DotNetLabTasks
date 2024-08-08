using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemOnMultiLevel
{
    class Person
    {
        public int age;
        public void Greet()
        {
            Console.WriteLine("Hello ");
        }
        public void SetAge(int age)
        {
            this.age = age;
        }
    }
}
