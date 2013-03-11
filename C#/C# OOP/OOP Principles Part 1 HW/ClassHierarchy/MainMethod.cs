using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchy
{
    class MainMethod
    {
        static void Main(string[] args)
        {
            //TestStudent.TestMethod();
            //TestWorker.TestMethod();

            Console.WriteLine(new string('-', 30));

            // Define a list of 10 students
            List<Student> students = new List<Student>
            {
                new Student("A", "B", 2.00),
                new Student("C", "D", 5.89),
                new Student("E", "F", 5.49),
                new Student("G", "H", 6.00),
                new Student("I", "J", 4.50),
                new Student("K", "L", 4.00),
                new Student("M", "N", 3.50),
                new Student("O", "P", 2.00),
                new Student("Q", "R", 2.50),
                new Student("S", "T", 3.00)
            };

            // Sort the students in ascending order by grade
            var sortedStudents = students.OrderBy((x) => x.Grade);

            // Print the sorted students
            Console.WriteLine("\nPRINT SORTED STUDENTS");
            foreach (Student student in sortedStudents)
            {
                student.Print();
            }

            // Define 10 a list of 10 workers
            List<Worker> workers = new List<Worker>
            {
                new Worker("A", "B", 50, 8),
                new Worker("C", "D", 150, 8),
                new Worker("E", "F", 100, 8),
                new Worker("G", "H", 250, 8),
                new Worker("I", "J", 200, 8),
                new Worker("K", "L", 350, 8),
                new Worker("M", "N", 300, 8),
                new Worker("O", "P", 600, 8),
                new Worker("Q", "R", 500, 8),
                new Worker("S", "T", 400, 8)
            };

            // Sort the workers in descending order by money per hour
            var sortedWorkers = workers.OrderByDescending((x) => x.MoneyPerHour());

            // Print the sorted workers
            Console.WriteLine("\nPRINT SORTED WORKER");
            foreach (Worker worker in sortedWorkers)
            {
                worker.Print();
            }

            // Merge the lists and sort them by first name and last name
            List<Human> humans = new List<Human>();

            for (int i = 0; i < students.Count; i++)
            {
                humans.Add(students[i]);
                humans.Add(workers[i]);
            }

            var sortedHumans =
                from human in humans
                orderby human.FirstName + human.LastName ascending
                select human;

            // Print the sorted humans
            Console.WriteLine("\nPRINT SORTED HUMANS");
            foreach (Human human in sortedHumans)
            {
                human.Print();
            }
        }
    }
}
