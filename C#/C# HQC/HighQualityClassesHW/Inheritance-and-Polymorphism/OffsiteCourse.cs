using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        public OffsiteCourse()
            : this(null, null, new List<string>(), null)
        {
        }

        public OffsiteCourse(string name)
            : this(name, null, new List<string>(), null)
        {
        }

        public OffsiteCourse(string name, string teacherName)
            : this(name, teacherName, new List<string>(), null)
        {
        }

        public OffsiteCourse(string name, string teacherName, List<string> students)
            : this(name, teacherName, students, null)
        {
        }

        public OffsiteCourse(string name, string teacherName, List<string> students, string town)
            : base(name, teacherName, students)
        {
            this.Town = town;
        }

        public string Town { get; set; }

        public override string ToString()
        {
            string result = base.ToString();

            result = "Offsite" + result;

            if (this.Town != null)
            {
                result += "\nTown: " + this.Town;
            }

            return result + "\n";
        }
    }
}
