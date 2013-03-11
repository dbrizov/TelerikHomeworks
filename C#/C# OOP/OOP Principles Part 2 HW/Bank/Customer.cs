using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Customer
    {
        // Fields
        private string name;

        // Constructors
        public Customer()
        {
            this.name = string.Empty;
        }

        public Customer(string name)
        {
            this.name = name;
        }

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
    }
}
