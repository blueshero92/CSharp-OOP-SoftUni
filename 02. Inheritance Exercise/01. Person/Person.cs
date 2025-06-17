using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private string name;
        private uint age;

        public Person(string name, uint age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get { return this.name; } 
            set { this.name = value; }
        }

        public virtual uint Age
        {
            get { return this.age; } 
            set { this.age = value; }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
