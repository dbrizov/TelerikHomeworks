using System;
using System.Collections.Generic;

class ReverseDigits
{
    public static void Reverse(ref int number)
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

    static void Main(string[] args)
    {
        // User Input
        Console.Write("Number = ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine(number);

        Reverse(ref number);

        Console.WriteLine(number);
    }
}