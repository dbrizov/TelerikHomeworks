using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class ReverseWordsInSentence
{
    static void Main(string[] args)
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";
        List<char> letters = new List<char>();

        for (int i = 'a'; i <= 'z'; i++)
        {
            letters.Add((char)i);
        }

        for (int i = 'A'; i <= 'Z'; i++)
        {
            letters.Add((char)i);
        }

        for (int i = 0; i <= 9; i++)
        {
            letters.Add((char)i);
        }

        letters.Add('#');
        letters.Add('+');
        letters.Add('-');
        letters.Add('/');
        letters.Add('*');

        string[] words = sentence.Split(new char[] { '.', ',', '!', '?', ':', ';', '"', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] spacesBetweenWords = sentence.Split(letters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        Array.Reverse(words);
        StringBuilder reversedSentence = new StringBuilder();

        for (int i = 0; i < spacesBetweenWords.Length; i++)
        {
            reversedSentence.Append(words[i]);
            reversedSentence.Append(spacesBetweenWords[i]);
        }

        Console.WriteLine(reversedSentence.ToString());
    }
}