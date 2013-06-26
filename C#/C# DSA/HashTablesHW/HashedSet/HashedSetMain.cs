using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HashedSet
{
    public class HashedSetMain
    {
        public static void PrintHashedSet<T>(MyHashSet<T> set)
        {
            foreach (var item in set)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            // Simple demo
            MyHashSet<int> set = new MyHashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);

            PrintHashedSet(set);

            Console.WriteLine("Contains 1: {0}", set.Contains(1));
            Console.WriteLine("Contains 5: {0}", set.Contains(5));
            Console.WriteLine("Contains 6: {0}", set.Contains(6));
            Console.WriteLine("Contains -1: {0}", set.Contains(-1));
            Console.WriteLine("Count: {0}", set.Count);

            Console.WriteLine("(Remove 1)");
            set.Remove(1);

            Console.WriteLine("Contains 1: {0}", set.Contains(1));
            Console.WriteLine("Count: {0}", set.Count);

            PrintHashedSet(set);

            MyHashSet<int> set2 = new MyHashSet<int>();
            set2.Add(4);
            set2.Add(5);
            set2.Add(6);
            set2.Add(7);

            Console.Write("[2, 3, 4, 5] UnionWith [4, 5, 6, 7] = ");
            set.UnionWith(set2);
            PrintHashedSet(set);

            Console.Write("[2, 3, 4, 5, 6, 7] IntersectWith [1, 2, 3, 8] = ");
            set2.Clear();
            set2.Add(1);
            set2.Add(2);
            set2.Add(3);
            set2.Add(8);
            set.IntersectWith(set2);
            PrintHashedSet(set);
        }
    }
}
