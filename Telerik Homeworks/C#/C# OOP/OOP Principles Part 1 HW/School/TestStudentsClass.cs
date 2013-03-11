using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    static class TestStudentsClass
    {
        public static void TestMethod()
        {
            StudentsClass studentsClass = new StudentsClass();
            studentsClass.AddStudent(new Student("Georgi", 8));
            studentsClass.AddTeacher(new Teacher("Pesho", new List<Discipline>()));

            Console.WriteLine(studentsClass);

            studentsClass.RemoveStudent(new Student("Georgi", 8));
            Console.WriteLine(studentsClass);

            studentsClass.RemoveTeacher(new Teacher("Pesho", new List<Discipline>()));
            Console.WriteLine(studentsClass);
        }
    }
}
