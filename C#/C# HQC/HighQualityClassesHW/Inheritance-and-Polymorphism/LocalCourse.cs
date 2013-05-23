using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        public LocalCourse()
            : this(null, null, new List<string>(), null)
        {
        }

        public LocalCourse(string name)
            : this(name, null, new List<string>(), null)
        {
        }

        public LocalCourse(string name, string teacherName)
            : this(name, teacherName, new List<string>(), null)
        {
        }

        public LocalCourse(string name, string teacherName, List<string> students)
            : this(name, teacherName, students, null)
        {
        }

        public LocalCourse(string name, string teacherName, List<string> students, string lab)
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab { get; set; }

        public override string ToString()
        {
            string result = base.ToString();

            result = "Local" + result;

            if (this.Lab != null)
            {
                result += "\nLab: " + this.Lab;
            }

            return result + "\n";
        }
    }
}
