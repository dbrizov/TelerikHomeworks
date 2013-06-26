using System;
using System.Diagnostics;

namespace PriorityQueueWithBinaryHeap
{
    public class ProgramMain
    {
        public static void Main(string[] args)
        {
            // Demo
            Random randomNumberGenerator = new Random();
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            int itemsCount = 5;
            for (int i = 0; i < itemsCount; i++)
            {
                priorityQueue.Enqueue(randomNumberGenerator.Next(100));
            }

            Console.WriteLine("Count: {0}", priorityQueue.Count);

            for (int i = 0; i < itemsCount; i++)
            {
                Console.WriteLine(priorityQueue.Dequeue());
            }

            Console.WriteLine("Count: {0}", priorityQueue.Count);

            // Performance Test - Worst Case
            Console.WriteLine("---PERFORMANCE TESTS---\n");
            int elementsCount = 1000000;
            Console.WriteLine("---Enqueueing {0} elements---", elementsCount);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < elementsCount; i++)
            {
                priorityQueue.Enqueue(i);
            }

            stopwatch.Stop();
            Console.WriteLine("Enqueue time: {0}\n", stopwatch.Elapsed);
            Console.WriteLine("---Dequeueing {0} elements---", elementsCount);
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < elementsCount; i++)
            {
                priorityQueue.Dequeue();
            }

            stopwatch.Stop();
            Console.WriteLine("Dequeue time: {0}\n", stopwatch.Elapsed);
        }
    }
}
