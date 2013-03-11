using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    static class TestPointsDistance
    {
        public static void TestMethod()
        {
            Point3D point1 = new Point3D(0, 0, 1);
            Point3D point2 = Point3D.ZeroPoint;

            Console.WriteLine(PointsDistance.CalculateDistance(point1, point2));

            Point3D point3 = new Point3D(1, 1, 1);
            Point3D point4 = Point3D.ZeroPoint;

            Console.WriteLine(PointsDistance.CalculateDistance(point3, point4));
        }
    }
}
