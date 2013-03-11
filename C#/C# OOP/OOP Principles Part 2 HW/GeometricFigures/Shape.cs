using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public abstract class Shape
    {
        // Fields
        protected double width;
        protected double height;

        // Methods
        public abstract double CalculateSurface();
    }
}
