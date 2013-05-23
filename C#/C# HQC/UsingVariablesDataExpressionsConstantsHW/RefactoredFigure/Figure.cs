using System;

namespace RefactoredFigure
{
    public class Figure
    {
        private double width;
        private double height;

        public Figure(double width, double height)
        {
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
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("The width of the figure cannot be <= 0");
                }
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
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("The height of the figure cannot be <= 0");
                }
            }
        }
    }
}
