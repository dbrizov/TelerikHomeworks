using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    // Exercise 3 - define class that calculates the distance between 2 3D points
    static class PointsDistance
    {
        public static double CalculateDistance(Point3D p1, Point3D p2)
        {
            return Math.Sqrt(Math.Pow(p2.x - p1.x, 2) +
                             Math.Pow(p2.y - p1.y, 2) +
                             Math.Pow(p2.z - p1.z, 2));
        }
    }
}
