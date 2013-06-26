using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HashTable
{
    public class HashTableMain
    {
        public static void Main(string[] args)
        {
            // Performance test
            int operations = 1000000;
            int elements = 50000;
            Random random = new Random();

            MyHashTable<string, int> hashTable = new MyHashTable<string, int>();
            for (int i = 0; i < elements; i++)
            {
                hashTable.Add(random.Next().ToString() + "asd", i);
            }

            var hashSet = new HashSet<string>();
            for (int i = 0; i < elements; i++)
            {
                hashSet.Add(random.Next().ToString() + "asd");
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < operations; i++)
            {
                hashTable.ContainsKey("asd");
            }

            stopwatch.Stop();
            Console.WriteLine("MyHashTable: " + stopwatch.Elapsed);

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < operations; i++)
            {
                hashSet.Contains("asd");
            }

            stopwatch.Stop();
            Console.WriteLine("HashSet: " + stopwatch.Elapsed);
        }
    }
}
