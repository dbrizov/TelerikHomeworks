using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        // Constructors
        public Person() : this(null, null) { }

        public Person(string name, int? age)
        {
            this.name = name;
            this.age = age;
        }

        // Fields
        private string name;
        private int? age;

        // Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        // Methods
        public override string ToString()
        {
            return string.Format("Name: {0}\nAge: {1}", this.name, (this.age == null ? "unspecified" : this.age.ToString()));
        } 
    }
}
