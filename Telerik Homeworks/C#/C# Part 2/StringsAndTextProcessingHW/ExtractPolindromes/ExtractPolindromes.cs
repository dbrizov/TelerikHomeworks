using System;
using System.IO;

class ExtractPolindromes
{
    static bool IsPolindrome(string str)
    {
        for (int i = 0; i < str.Length / 2; i++)
        {
            if (str[i] != str[str.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }

    static void Main(string[] args)
    {
        string text;
        StreamReader reader = new StreamReader("file.txt");
        using (reader)
        {
            text = reader.ReadToEnd();
        }

        char[] separators = new char[] { ' ', '.', '!', '?', ',', ':', ';', '(', ')', '\t', '\r', '\n' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            if (IsPolindrome(words[i].ToLower()))
            {
                Console.WriteLine(words[i].ToLower());
            }
        }
    }
}