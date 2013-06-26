using System;
using System.Collections.Generic;

class Program
{
    static int[] digits = new int[]
    {
        Convert.ToInt32("1111110", 2), // 0
        Convert.ToInt32("0110000", 2), // 1
        Convert.ToInt32("1101101", 2), // 2
        Convert.ToInt32("1111001", 2), // 3
        Convert.ToInt32("0110011", 2), // 4
        Convert.ToInt32("1011011", 2), // 5
        Convert.ToInt32("1011111", 2), // 6
        Convert.ToInt32("1110000", 2), // 7
        Convert.ToInt32("1111111", 2), // 8
        Convert.ToInt32("1111011", 2)  // 9
    };

    static int N;
    static int[] displayedDigits;

    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        displayedDigits = new int[N];
        currentCombination = new char[N];

        for (int i = 0; i < displayedDigits.Length; i++)
        {
            displayedDigits[i] = Convert.ToInt32(Console.ReadLine(), 2);
        }

        SolveWithRecursion(0);

        Console.WriteLine(combinations.Count);
        for (int i = 0; i < combinations.Count; i++)
        {
            Console.WriteLine(combinations[i]);
        }
    }

    static List<string> combinations = new List<string>();
    static char[] currentCombination;

    static void SolveWithRecursion(int currentDigit)
    {
        if (currentDigit == N)
        {
            combinations.Add(new string(currentCombination));
            return;
        }
        for (int i = 0; i < digits.Length; i++)
        {
            if ((digits[i] & displayedDigits[currentDigit]) == displayedDigits[currentDigit])
            {
                currentCombination[currentDigit] = (char)('0' + i);
                SolveWithRecursion(currentDigit + 1);
            }
        }
    }
}