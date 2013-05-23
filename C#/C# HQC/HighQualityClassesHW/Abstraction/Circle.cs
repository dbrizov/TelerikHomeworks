using System;

namespace Abstraction
{
    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("The radius must be > 0");
            }

            this.radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The radius must be a positive number");
                }

                this.radius = value;
            }
        }

        public override double GetPerimeter()
        {
            double perimeter = 2 * Math.PI * this.radius;
            return perimeter;
        }

        public override double GetSurface()
        {
            double surface = Math.PI * this.radius * this.radius;
            return surface;
        }
    }
}
