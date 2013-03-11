using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    class Test
    {
        static void Main(string[] args)
        {
            // Make the array
            Shape[] figures = new Shape[]
            {
                new Rectangle(2, 3),
                new Triangle(2, 3),
                new Circle(10)
            };

            // Test the polymorphism
            for (int i = 0; i < figures.Length; i++)
            {
                Console.WriteLine(figures[i].CalculateSurface());
            }
        }
    }
}
