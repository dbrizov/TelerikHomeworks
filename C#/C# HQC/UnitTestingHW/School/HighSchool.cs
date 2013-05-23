using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class HighSchool
    {
        private List<int> uniqueStudentNumbers = new List<int>();
        private List<Student> students;
        private List<Course> courses;

        public HighSchool()
        {
            this.students = new List<Student>();
            this.courses = new List<Course>();
        }

        public List<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public List<Course> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.uniqueStudentNumbers.Contains(student.UniqueNumber))
            {
                throw new ArgumentException("This student already exists in this school");
            }

            this.students.Add(new Student(student.Name, student.UniqueNumber));
            this.uniqueStudentNumbers.Add(student.UniqueNumber);
        }

        public void RemoveStudent(Student student)
        {
            this.students.Remove(student);
        }

        public void AddCourse(Course course)
        {
            this.courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            this.courses.Remove(course);
        }
    }
}
