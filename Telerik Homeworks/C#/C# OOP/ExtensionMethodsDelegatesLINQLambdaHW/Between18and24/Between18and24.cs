using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstNameBeforeLastName;

namespace Between18and24
{
    class Between18and24
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
                where (student.Age >= 18 && student.Age <= 24)
                select student;

            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}
