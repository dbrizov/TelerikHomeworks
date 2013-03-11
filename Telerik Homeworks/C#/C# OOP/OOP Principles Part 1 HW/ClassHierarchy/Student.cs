using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchy
{
    public class Student : Human
    {
        // Fields
        private double grade;

        // Constructors
        public Student()
            : base()
        {
            this.grade = 0;
        }

        public Student(string firstName, string lastName, double grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
        }

        public Student(Student student)
            : base((Human)student)
        {
            this.grade = student.grade;
        }

        // Properties
        public double Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                this.grade = value;
            }
        }

        // Methods
        public override string ToString()
        {
            return string.Format("Student: {0} {1} - grade: {2}",
                this.FirstName, this.LastName, this.grade);
        }

        public override void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
