using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    static class TestPoint3D
    {
        public static void TestMethod()
        {
            Point3D point = new Point3D(1, 1, 1);
            Console.WriteLine(point);
            Console.WriteLine(Point3D.ZeroPoint);
        }
    }
}
