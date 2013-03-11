using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstNameBeforeLastName;

namespace SortStudents
{
    class SortStudents
    {
        static void Main(string[] args)
        {
            // With lambda expressions
            List<Student> students = new List<Student>
            {
                new Student("Pesho", "Petkov", 19),
                new Student("Ivan", "Dortulov", 21),
                new Student("Georgi", "Georgiev", 25),
                new Student("Aleksandur", "Zlatkov", 17),
                new Student("Ivan", "Ivanov", 29)
            };

            var orderedStudentsWithLambdaExpressions = 
                students.OrderByDescending((x) => x.FirstName).ThenByDescending((x) => x.LastName);

            foreach (var student in orderedStudentsWithLambdaExpressions)
            {
                Console.WriteLine(student);
            }

            // With LINQ queries
            var orderedStudentsWithLINQQueries =
                from student in students
                orderby student.FirstName + student.LastName descending
                select student;

            Console.WriteLine();
            foreach (var student in orderedStudentsWithLINQQueries)
            {
                Console.WriteLine(student);
            }
        }
    }
}
