using System;
using System.Collections.Generic;
using System.Linq;

namespace University.Models
{
    public class Course
    {
        private ICollection<Student> students;

        public Course()
        {
            this.students = new HashSet<Student>();
        }

        public int CourseId { get; set; }

        public string Description { get; set; }

        public string Materials { get; set; }

        public int? HomeworkId { get; set; }

        public virtual Homework Homework { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
