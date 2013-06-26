using System;

namespace StudentsAndTheirCourses
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Student objAsStudent = obj as Student;
            if (objAsStudent == null)
            {
                // The obj can't be cast to Student
                return false;
            }

            return (this.FirstName == objAsStudent.FirstName &&
                    this.LastName == objAsStudent.LastName);
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode();
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}