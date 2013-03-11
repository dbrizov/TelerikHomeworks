using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    static class TestGenericList
    {

        public static void TestMethod()
        {
            // Make an instance - test constructors
            GenericList<int> list = new GenericList<int>();

            // Print capacity and count - test properties
            Console.WriteLine("capacity = {0}", list.Capacity); // capacity = 4
            Console.WriteLine("count = {0}", list.Count); // count = 0

            // Add items - test Add(T elem) method
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            // Print the list and list.Count - test ToString() method and count functionality
            Console.WriteLine(list); // 0 1 2 3 4 5 6 7 8 9
            Console.WriteLine("count = {0}", list.Count); // 10

            // Remove element by index - test RemoveAt(int index) method and reverse count functionality
            list.RemoveAt(3); // 0 1 2 3 4 5 6 7 8 9 -> 0 1 2 4 5 6 7 8 9
            Console.WriteLine(list); // 0 1 2 4 5 6 7 8 9
            Console.WriteLine("count = {0}", list.Count); // count = 9
            Console.WriteLine("capacity = {0}", list.Capacity); // capacity = 16 - test the auto-grow functionality

            // Insert element at given index - test Insert(int index, T element) method
            list.Insert(3, -5); // 0 1 2 4 5 6 7 8 9 -> 0 1 2 -5 4 5 6 7 8 9
            Console.WriteLine(list); // 0 1 2 -5 4 5 6 7 8 9
            Console.WriteLine("count = {0}", list.Count); // cout = 10

            // Print the list with ElementAt(int index) method - test ElementAt(int index) method
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write("{0} ", list.ElementAt(i)); // 0 1 2 -5 4 5 6 7 8 9
            }

            Console.WriteLine();

            // Test FindByValue(T value) method
            Console.WriteLine(list.FindByValue(8)); // 8 - value 8 is at the 8th index
            Console.WriteLine(list.FindByValue(10)); // -1 - 10 is not in the list

            // Test Min() and Max() methods
            Console.WriteLine("min = {0}", list.Min()); // min = -5
            Console.WriteLine("max = {0}", list.Max()); // max = 9

            // Test Clear() method
            Console.WriteLine(list); // 0 1 2 -5 4 5 6 7 8 9
            list.Clear();
            Console.WriteLine(list + "(nothing)"); // (nothing)
        }
    }
}
