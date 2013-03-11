using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public class Rectangle : Shape
    {
        // Constructors
        public Rectangle()
        {
            this.width = 0;
            this.height = 0;
        }

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        // Methods
        public override double CalculateSurface()
        {
            return this.width * this.height;
        }
    }
}
