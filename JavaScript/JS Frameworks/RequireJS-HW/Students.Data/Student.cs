using System;
using System.Collections.Generic;
using System.Linq;

namespace Students.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public ICollection<Mark> Marks { get; set; }

        public Student()
        {
            this.Marks = new HashSet<Mark>();
        }
    }
}
