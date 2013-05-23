using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorChef
{
    public abstract class Vegetable : IFood
    {
        public double Kilograms { get; set; }

        public double PricePerKilogram { get; set; }

        public double GetPrice()
        {
            return this.Kilograms * this.PricePerKilogram;
        }
    }
}
