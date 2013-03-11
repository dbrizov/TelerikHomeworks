using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    static class TestTeacher
    {
        static public void TestMethod()
        {
            Discipline math = new Discipline("Math", 1, 1);
            Discipline programming = new Discipline("Programming", 2, 2);

            List<Discipline> disciplines = new List<Discipline>();
            disciplines.Add(math);
            disciplines.Add(programming);

            Teacher teacher = new Teacher("Ivan", disciplines);
            Console.WriteLine(teacher);

            teacher.AddDiscipline(new Discipline());
            Console.WriteLine(teacher);

            teacher.RemoveDiscipline(math);
            Console.WriteLine(teacher);

            teacher.Disciplines = new List<Discipline>();
            Console.WriteLine(teacher);

            teacher.Live();
        }
    }
}
