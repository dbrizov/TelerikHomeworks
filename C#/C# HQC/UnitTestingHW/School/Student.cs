using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student
    {
        private string name;
        private int uniqueNumber;

        public Student(string name, int uniqueNumber)
        {
            if (name == null)
            {
                throw new ArgumentNullException("The student's name is null");
            }

            if (name == string.Empty)
            {
                throw new ArgumentException("The student's name empty string");
            }

            if (uniqueNumber < 10000 || uniqueNumber > 99999)
            {
                throw new ArgumentException("The student's unique number is not in range [10000, 99999]");
            }

            this.name = name;
            this.uniqueNumber = uniqueNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Student))
            {
                return false;
            }

            Student objAsStudent = obj as Student;

            if (this.Name == objAsStudent.Name &&
                this.UniqueNumber == objAsStudent.UniqueNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.uniqueNumber.GetHashCode();
        }
    }
}
