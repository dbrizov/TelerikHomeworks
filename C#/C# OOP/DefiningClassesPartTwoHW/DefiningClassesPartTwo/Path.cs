using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    // Exercise 4 - define class Path that holds sequence of 3D points
    class Path
    {
        // Field
        private List<Point3D> sequenceOfPoints;

        // Constructor
        public Path()
        {
            sequenceOfPoints = new List<Point3D>();
        }

        // Add and Remove methods
        public void AddPoint3D(Point3D point)
        {
            this.sequenceOfPoints.Add(point);
        }

        public void RemovePoint3D(Point3D point)
        {
            this.sequenceOfPoints.Remove(point);
        }

        // Property
        public List<Point3D> SequenceOfPoints
        {
            get
            {
                return this.sequenceOfPoints;
            }
            set
            {
                this.sequenceOfPoints = value;
            }
        }
    }
}
