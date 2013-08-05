using System;
using System.Collections.Generic;
using System.Linq;

namespace University.Models
{
    public class Student
    {
        private ICollection<Course> courses;

        public Student()
        {
            this.courses = new HashSet<Course>();
        }

        public int StudentId { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public int? HomeworkId { get; set; }

        public virtual Homework Homework { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
