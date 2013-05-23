using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactorChef
{
    public class Potato : Vegetable
    {
        public Potato()
        {
            this.Kilograms = 0;
            this.PricePerKilogram = 0;
        }

        public Potato(double kilograms, double pricePerKilogram)
        {
            this.Kilograms = kilograms;
            this.PricePerKilogram = pricePerKilogram;
        }
    }
}
