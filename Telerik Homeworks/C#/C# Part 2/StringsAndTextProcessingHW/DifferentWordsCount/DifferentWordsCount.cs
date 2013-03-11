using System;
using System.Collections.Generic;

class DifferentWordsCount
{
    static void Main(string[] args)
    {
        string str = Console.ReadLine();
        char[] separators = new char[] { ' ', '.', '?', '!', ',', '(', ')', ':', ';', '\n', '\t', '\r' };
        string[] words = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> pairs = new Dictionary<string, int>();

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i].ToLower(); // It's not case sensitive
            if (pairs.ContainsKey(word))
            {
                pairs[word]++;
            }
            else
            {
                pairs.Add(word, 1);
            }
        }

        foreach (var pair in pairs)
        {
            Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
        }
    }
}