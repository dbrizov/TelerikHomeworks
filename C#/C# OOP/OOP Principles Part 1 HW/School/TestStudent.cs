using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    static class TestStudent
    {
        public static void TestMethod()
        {
            Student student = new Student();
            Console.WriteLine(student);

            Student student2 = new Student("Ivan Georgiev", 17);
            Console.WriteLine(student2);

            Student student3 = new Student(student2);
            Console.WriteLine(student3);

            Console.WriteLine(student2.Name);
            Console.WriteLine(student2.NumberInClass);

            student2.Live();
        }
    }
}
