using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchy
{
    public class Human
    {
        // Fields
        private string firstName;
        private string lastName;

        // Constructors
        public Human()
        {
            this.firstName = string.Empty;
            this.lastName = string.Empty;
        }

        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Human(Human human)
        {
            this.firstName = human.firstName;
            this.lastName = human.lastName;
        }

        // Properties
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        // Methods
        public virtual void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
