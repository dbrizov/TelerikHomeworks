using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Individual : Customer
    {
        // Constructors
        public Individual() : base() { }
        public Individual(string individualName) : base(individualName) { }
    }
}
