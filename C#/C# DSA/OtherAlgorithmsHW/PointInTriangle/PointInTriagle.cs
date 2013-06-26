using System;

namespace PointInTriangle
{
    public class PointInTriagle
    {
        public static void Main(string[] args)
        {
            Console.Write("A.x = ");
            double ax = double.Parse(Console.ReadLine());
            Console.Write("A.y = ");
            double ay = double.Parse(Console.ReadLine());

            Console.Write("B.x = ");
            double bx = double.Parse(Console.ReadLine());
            Console.Write("B.y = ");
            double by = double.Parse(Console.ReadLine());

            Console.Write("C.x = ");
            double cx = double.Parse(Console.ReadLine());
            Console.Write("C.y = ");
            double cy = double.Parse(Console.ReadLine());

            Console.Write("P.x = ");
            double px = double.Parse(Console.ReadLine());
            Console.Write("P.y = ");
            double py = double.Parse(Console.ReadLine());

            Point a = new Point(ax, ay);
            Point b = new Point(bx, by);
            Point c = new Point(cx, cy);
            Point p = new Point(px, py);

            Console.WriteLine("Point 'p' is inside the tringle ABC: " + IsInside(p, a, b, c));
        }

        public static double GetDeterminant(Point p1, Point p2, Point p3)
        {
            return
                p1.X * (p2.Y - p3.Y) + 
                p2.X * (p3.Y - p1.Y) + 
                p3.X * (p1.Y - p2.Y);
        }

        public static bool IsInside(Point p, Point a, Point b, Point c)
        {
            return
                GetDeterminant(p, a, b) >= 0 &&
                GetDeterminant(p, b, c) >= 0 &&
                GetDeterminant(p, c, a) >= 0;
        }
    }
}
