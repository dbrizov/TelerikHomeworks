using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstNameBeforeLastName
{
    // The class Student is implemented in this project.
    // I will use it the next to projects too.
    class FirstNameBeforeLastName
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Pesho", "Petkov", 19),
                new Student("Ivan", "Dortulov", 21),
                new Student("Georgi", "Georgiev", 25),
                new Student("Aleksandur", "Zlatkov", 17),
                new Student("Ivan", "Ivanov", 29)
            };

            var filteredStudents =
                from student in students
                where string.Compare(student.FirstName, student.LastName) < 0
                select student;

            // Only Ivan Dortulov will not be displayed because the first name is not
            // before the last name in alphabetical order
            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student);
            }
        }
    }

    public class Student
    {
        // Fields
        private string firstName;
        private string lastName;
        private int age;

        // Constructor
        public Student(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        // Properties
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        // Methods
        public override string ToString()
        {
            return string.Format("First name: {0}\nLast name: {1}\nAge: {2}",
                this.firstName, this.lastName, this.age);
        }
    }
}
