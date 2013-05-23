using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        private List<Student> students;

        public Course()
        {
            this.students = new List<Student>();
        }

        public Course(List<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException("The given students list is null");
            }

            if (students.Count > 30)
            {
                throw new ArgumentException("students.Count > 30. The max course count is 30");
            }

            this.students = new List<Student>(students);
        }

        public List<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student is null");
            }

            if (this.students.Count >= 30)
            {
                throw new Exception("The course is full");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student is null");
            }

            if (this.students.Count == 0)
            {
                throw new Exception("The course is empty");
            }

            if (this.students.Contains(student) == false)
            {
                throw new Exception("There is no such student in the course");
            }

            this.students.Remove(student);
        }
    }
}
