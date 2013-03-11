using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    class MainMethod
    {
        static void Main(string[] args)
        {
            TestPoint3D.TestMethod();
            //TestPointsDistance.TestMethod();
            //TestPath.TestMethod();
            //TestPathStorage.TestMethod();
            //TestGenericList.TestMethod();
            //TestMatrix.TestMethod();

            /* Test Version attribute */
            //Type type = typeof(Point);

            //object[] allAttributes = type.GetCustomAttributes(false);

            //foreach (VersionAttribute attribute in allAttributes)
            //{
            //    Console.WriteLine(attribute);
            //}
        }

        [VersionAttribute(1, 1)]
        struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
