using System;

class LettersIndexes
{
    static void Main(string[] args)
    {
        for (int i = 0; i <= 25; i++)
        {
            Console.Write("{0, -3}", i);
        }

        Console.WriteLine();

        for (int i = 97; i <= 122; i++)
        {
            Console.Write("{0, -3}", (char)i);
        }

        Console.WriteLine();

        Console.Write("Input word: ");
        string word = Console.ReadLine();

        for (int i = 0; i < word.Length; i++)
        {
            Console.WriteLine(word[i] - 'a');
        }
    }
}