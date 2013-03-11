using System;
using System.Collections.Generic;

class ExtractSentencesByWord
{
    static string[] ExtractSentencesWithGivenWord(string text, string word)
    {
        List<string> result = new List<string>();
        char[] separators = { '.', '!', '?' };
        string[] sentences = text.Split(separators);

        for (int i = 0; i < sentences.Length; i++)
        {
            string[] words = sentences[i].Split(' ');

            for (int j = 0; j < words.Length; j++)
            {
                if (words[j].ToLower() == word.ToLower())
                {
                    result.Add(sentences[i]);
                    break;
                }
            }
        }

        return result.ToArray();
    }

    static void Main(string[] args)
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        Console.WriteLine(text);
        Console.WriteLine();

        Console.Write("Input word: ");
        string word = Console.ReadLine();

        string[] sentences = ExtractSentencesWithGivenWord(text, word);
        Console.WriteLine();
        Console.WriteLine("Extracted senteces:");

        for (int i = 0; i < sentences.Length; i++)
        {
            Console.WriteLine(sentences[i].Trim());
        }
    }
}