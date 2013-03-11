using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    // Exercise 1 - define Point3D structure and override ToString();
    // Exercise 2 - define static readonly field which holds the zero point (0, 0, 0)
    // and a static property for that field
    struct Point3D
    {
        public double x;
        public double y;
        public double z;
        static readonly Point3D zeroPoint = new Point3D(0, 0, 0);

        // Constructor
        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // ZeroPoint property
        public static Point3D ZeroPoint
        {
            get
            {
                return zeroPoint;
            }
        }

        // ToString() override
        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", x, y, z);
        }
    }
}
