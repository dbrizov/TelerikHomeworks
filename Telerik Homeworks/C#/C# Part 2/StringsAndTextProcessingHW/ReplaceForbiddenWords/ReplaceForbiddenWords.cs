using System;

class ReplaceForbiddenWords
{
    static void Main(string[] args)
    {
        string text = @"Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string[] forbiddenWords = { "PHP", "CLR", "Microsoft" };

        Console.WriteLine(text);
        Console.WriteLine();

        for (int i = 0; i < forbiddenWords.Length; i++)
        {
            text = text.Replace(forbiddenWords[i], new string('*', forbiddenWords[i].Length));
        }

        Console.WriteLine(text);
    }
}