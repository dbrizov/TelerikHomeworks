using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactorChef
{
    public class Carrot : Vegetable
    {
        public Carrot()
        {
            this.Kilograms = 0;
            this.PricePerKilogram = 0;
        }

        public Carrot(double kilograms, double pricePerKilogram)
        {
            this.Kilograms = kilograms;
            this.PricePerKilogram = pricePerKilogram;
        }
    }
}
