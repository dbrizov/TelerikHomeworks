using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Company : Customer
    {
        // Constructors
        public Company() : base() { }
        public Company(string companyName) : base(companyName) { }
    }
}
