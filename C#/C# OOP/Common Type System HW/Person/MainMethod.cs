using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class MainMethod
    {
        static void Main(string[] args)
        {
            // Test
            Person person = new Person();
            person.Name = "asd";

            Console.WriteLine(person);

            person.Age = 20;

            Console.WriteLine("\n" + person);
        }
    }
}
