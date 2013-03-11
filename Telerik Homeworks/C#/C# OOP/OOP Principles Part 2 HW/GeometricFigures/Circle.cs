using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public class Circle : Shape
    {
        // Constructors
        public Circle()
        {
            // width = height = radius
            this.width = 0;
            this.height = 0;
        }

        public Circle(double radius)
        {
            this.width = radius;
            this.height = radius;
        }

        // Methods
        public override double CalculateSurface()
        {
            return Math.PI * width * height; // PI * r * r
        }
    }
}
