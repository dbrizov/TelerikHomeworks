using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchy
{
    static class TestStudent
    {
        public static void TestMethod()
        {
            Student student = new Student();
            Console.WriteLine(student); // - grade: 0

            student = new Student("Georgi", "Ivanov", 5.49);
            Console.WriteLine(student); // Georgi Ivanov - grade: 5.49

            Student student2 = new Student(student);
            student2.FirstName = "Ivan";
            student2.Grade = 6.00;
            Console.WriteLine(student2); // Ivan Ivanov - grade: 6
        }
    }
}
