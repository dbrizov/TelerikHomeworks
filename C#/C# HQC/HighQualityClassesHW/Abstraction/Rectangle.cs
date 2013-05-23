using System;

namespace Abstraction
{
    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            if (width <= 0)
            {
                throw new ArgumentException("The width must be > 0");
            }

            if (height <= 0)
            {
                throw new ArgumentException("The height must be > 0");
            }

            this.width = width;
            this.height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The width must be a positive number");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The width must be a positive number");
                }

                this.height = value;
            }
        }

        public override double GetPerimeter()
        {
            double perimeter = 2 * (this.width + this.height);
            return perimeter;
        }

        public override double GetSurface()
        {
            double surface = this.width * this.height;
            return surface;
        }
    }
}
