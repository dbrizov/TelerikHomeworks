using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public abstract class Course
    {
        protected Course()
            : this(null, null, new List<string>())
        {
        }

        protected Course(string name)
            : this(name, null, new List<string>())
        {
        }

        protected Course(string name, string teacherName)
            : this(name, teacherName, new List<string>())
        {
        }

        protected Course(string name, string teacherName, List<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = new List<string>(students);
        }

        public string Name { get; set; }
        public string TeacherName { get; set; }
        public IList<string> Students { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Course: \nName = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("\nTeacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("\nStudents = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            string result;

            if (this.Students == null || this.Students.Count == 0)
            {
                result = "{ }";
            }
            else
            {
                result = "{ " + string.Join(", ", this.Students) + " }";
            }

            return result;
        }
    }
}
