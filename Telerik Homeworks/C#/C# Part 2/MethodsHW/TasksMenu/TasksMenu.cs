using System;
using System.Collections.Generic;

class TasksMenu
{
    public static void ReverseDigits(ref int number)
    {
        List<int> reversedDigits = new List<int>();

        // Counts the digits and writes them in reversedDigits
        while (number != 0)
        {
            reversedDigits.Add(number % 10);
            number = number / 10;
        }

        // Pregenerates the number
        int multiplier = 1;
        for (int i = 0; i < reversedDigits.Count; i++)
        {
            number += reversedDigits[reversedDigits.Count - i - 1] * multiplier;
            multiplier *= 10;
        }
    }

    public static double GetAverage(int[] array)
    {
        int sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return (double)sum / array.Length;
    }

    public static double SolveLinearEquation(double a, double b)
    {
        return (-b) / a;
    }

    /*
     * Main Method
     */
    static void Main(string[] args)
    {
        int task = 0;

        do
        {
            Console.WriteLine("Select Task:");
            Console.WriteLine("1 - Reverse digits of a number");
            Console.WriteLine("2 - Calculate the average of sequence of integers");
            Console.WriteLine("3 - Solve linear equation (ax + b = 0)");

            task = int.Parse(Console.ReadLine());
        }
        while (task < 1 || task > 3);

        if (task == 1)
        {
            int number;

            // Input the number
            do
            {
                Console.Write("Input number: ");
                number = int.Parse(Console.ReadLine());
            }
            while (number < 0);

            ReverseDigits(ref number);

            Console.WriteLine("Reversed = {0}", number);
        }
        else if (task == 2)
        {
            int sequenceLength;
            int[] sequence;

            // Input the length of the sequence
            do
            {
                Console.Write("Input sequence length: ");
                sequenceLength = int.Parse(Console.ReadLine());
            }
            while (sequenceLength <= 0);

            sequence = new int[sequenceLength];

            // Input the numbers of the sequence
            for (int i = 0; i < sequence.Length; i++)
            {
                Console.Write("Number{0} = ", i + 1);
                sequence[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Average = {0}", GetAverage(sequence));
        }
        else
        {
            double a;
            double b;

            // Input a
            do
            {
                Console.Write("a = ");
                a = double.Parse(Console.ReadLine());
            }
            while (a == 0);

            // Input b
            Console.Write("b = ");
            b = double.Parse(Console.ReadLine());

            Console.WriteLine("x = {0}", SolveLinearEquation(a, b));
        }
    }
}