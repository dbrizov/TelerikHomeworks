using System;

namespace MyQueue
{
    public class MyQueueMain
    {
        public static void Main(string[] args)
        {
            // Simple Demo
            LinkedQueue<int> queue = new LinkedQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine(queue.ToString()); // outputs 1234
            Console.WriteLine();

            int dequeued = queue.Dequeue();
            Console.WriteLine(dequeued); // outputs 1
            Console.WriteLine(queue.ToString()); // outputs 234
            Console.WriteLine();

            queue.Enqueue(5);
            Console.WriteLine(queue.ToString()); // outputs 2345
            Console.WriteLine();

            // I've also made unit tests that test everything in the queue.
        }
    }
}
