using System;
using System.Text;

namespace MyLinkedList
{
    public class MyLinkedListMain
    {
        public static void PrintList(CustomLinkedList<int> list)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in list)
            {
                result.AppendFormat("{0} ", item);
            }

            Console.WriteLine(result.ToString());
        }

        public static void Main(string[] args)
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            list.Add(1);
            list.Add(2); // list = 1, 2
            PrintList(list); // outputs 1 2
            Console.WriteLine(list.Count); // outputs 2
            Console.WriteLine("---------------------------------");

            list.Clear(); // list = null(empty)
            PrintList(list); // outputs empty line
            Console.WriteLine(list.Count); // outputs 0
            Console.WriteLine("---------------------------------");

            list.AddLast(3);
            list.AddLast(4);
            list.AddFirst(5);
            list.AddFirst(1);
            list.AddFirst(2); // list = 2, 1, 5, 3, 4
            PrintList(list); // outputs 2 1 5 3 4
            Console.WriteLine(list.Count); // outputs 5
            Console.WriteLine("---------------------------------");

            list.RemoveFirst();
            list.RemoveLast();
            list.RemoveAt(1);
            list.Remove(1); // list = 3
            PrintList(list); // outputs 3
            Console.WriteLine(list.Count); // outputs 1
            Console.WriteLine("---------------------------------");

            list.Insert(0, 1); // list = 1, 3
            PrintList(list); // outputs 1 3
            Console.WriteLine(list.Count); // outputs 2
            Console.WriteLine("---------------------------------");

            // I also have unit tests
        }
    }
}
