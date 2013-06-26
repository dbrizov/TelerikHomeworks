using System;

namespace MyStack
{
    public class MyStackMain
    {
        public static void Main(string[] args)
        {
            // Simple demo
            StaticStack<int> stack = new StaticStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            Console.WriteLine(stack); // outputs 4321
            Console.WriteLine(stack.Count); // outputs 4
            Console.WriteLine();

            Console.WriteLine(stack.Pop()); // outputs 4
            Console.WriteLine(stack); // outputs 321
            Console.WriteLine(stack.Count); // outputs 3
            Console.WriteLine();

            // I've also made unit tests
        }
    }
}
