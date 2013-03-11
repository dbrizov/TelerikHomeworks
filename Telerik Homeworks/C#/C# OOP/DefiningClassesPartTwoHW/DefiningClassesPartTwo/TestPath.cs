using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    static class TestPath
    {
        public static void TestMethod()
        {
            // Make an instance
            Path path = new Path();

            // Add some points
            for (int i = 0; i < 5; i++)
            {
                path.AddPoint3D(new Point3D(i, i, i));
            }

            path.RemovePoint3D(new Point3D(2, 2, 2)); // Removes the (2, 2, 2) point

            // Prints the path on the console
            for (int i = 0; i < path.SequenceOfPoints.Count; i++)
            {
                Console.WriteLine(path.SequenceOfPoints[i]);
            }
        }
    }
}
