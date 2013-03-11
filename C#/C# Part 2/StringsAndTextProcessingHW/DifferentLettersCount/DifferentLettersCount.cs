using System;
using System.Collections.Generic;

class DifferentLettersCount
{
    static void Main(string[] args)
    {
        Console.Write("Input string: ");
        string str = Console.ReadLine();

        int[] letters = new int[(int)Math.Pow(2, 16)];

        for (int i = 0; i < str.Length; i++)
        {
            letters[(int)str[i]]++;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] != 0)
            {
                Console.WriteLine("{0} -> {1}", (char)i, letters[i]);
            }
        }
    }
}