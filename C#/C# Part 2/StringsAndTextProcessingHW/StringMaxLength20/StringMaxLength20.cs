using System;
using System.Text;

class StringMaxLength20
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        if (input.Length > 20)
        {
            throw new ArgumentOutOfRangeException("The string.Length must be <= 20");
        }

        StringBuilder str = new StringBuilder(input);

        for (int i = str.Length; i < 20; i++)
        {
            str.Append("*");
        }

        Console.WriteLine(str.ToString());
    }
}