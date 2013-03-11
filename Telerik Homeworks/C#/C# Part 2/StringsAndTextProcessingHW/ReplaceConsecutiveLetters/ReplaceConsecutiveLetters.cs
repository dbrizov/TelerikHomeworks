using System;
using System.Text;

class ReplaceConsecutiveLetters
{
    static void Main(string[] args)
    {
        Console.Write("Input string:");
        string str = Console.ReadLine();

        StringBuilder resultStr = new StringBuilder();

        char previous = str[0];
        resultStr.Append(previous);

        for (int i = 1; i < str.Length; i++)
        {
            if (str[i] != previous)
            {
                resultStr.Append(str[i]);
                previous = str[i];
            }
        }

        Console.WriteLine(resultStr.ToString());
    }
}