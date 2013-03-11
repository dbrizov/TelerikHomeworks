using System;

class SortInAlphabeticalOrder
{
    static void Main(string[] args)
    {
        char[] separators = new char[] { ' ' };
        string[] words = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

        Array.Sort(words);

        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }

        // The strange thing is that the word "are" is before the word "Are"
        // The ASCII code of 'A' is 65 and of 'a' is 97
    }
}