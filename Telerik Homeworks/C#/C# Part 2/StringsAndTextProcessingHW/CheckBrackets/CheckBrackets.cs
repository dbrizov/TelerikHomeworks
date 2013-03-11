using System;
using System.Collections.Generic;

class CheckBrackets
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Stack<char> stack = new Stack<char>();

        if (input[0] == ')')
        {
            Console.WriteLine("Not correct!");
            return;
        }
        else
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(input[i]);
                }
                else if (input[i] == ')')
                {
                    if (stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Not correct!");
            }
        }
    }
}