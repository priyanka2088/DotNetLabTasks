using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemOnClass
{
    class Person
    {
        public string Name;
        public Person(string name)
        {
            this.Name = name;
        }
        ~Person() 
        {
            this.Name=string.Empty;
        }
        public override string ToString()
        {
            return "Hello My Name is " + Name;
        }
    }
}
