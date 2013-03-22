using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_1_2_3
{
    class MainMethod
    {
        static void Main(string[] args)
        {
            // Test CompareTo(T)
            Console.WriteLine("TEST CompareTo(T)");
            Student s1 = new Student("baa", "", "", "12345");
            Student s2 = new Student("bac", "", "", "12345");

            Console.WriteLine(s1.CompareTo(s2)); // -1
            Console.WriteLine(s1.CompareTo(s1)); // 0
            Console.WriteLine(s2.CompareTo(s1)); // 1;

            // Test Equals(T)
            Console.WriteLine("\nTEST Equals(T)");
            s1 = new Student("asd");
            s2 = new Student("asd");

            // They have different references but are equal.
            // Operator == uses Equals
            Console.WriteLine(s1 == s2); // True
            Console.WriteLine(s1 != s2); // False

            // Test Clone()
            Console.WriteLine("\nTEST Clone()");
            s1 = new Student("hahahaha");
            s2 = s1.Clone();

            Console.WriteLine(s1 == s2); // True

            // Test ToString()
            Console.WriteLine("\nTEST ToString()");
            Console.WriteLine(s2);
        }
    }
}
