using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    static class TestDiscipline
    {
        public static void testMethod()
        {
            Discipline discipline = new Discipline();
            Console.WriteLine(discipline);

            discipline = new Discipline("Math", 3, 2);
            Console.WriteLine(discipline);

            Console.WriteLine(discipline.Name = "Biology");
            Console.WriteLine(discipline);
        }
    }
}
