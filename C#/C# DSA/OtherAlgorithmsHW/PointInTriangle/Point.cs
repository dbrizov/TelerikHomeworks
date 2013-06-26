using System;

namespace PointInTriangle
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }
    }
}
