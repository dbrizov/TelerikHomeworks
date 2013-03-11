using System;
using System.Text;

class ReverseString
{
    static void Main(string[] args)
    {
        string str = Console.ReadLine();
        StringBuilder reversed = new StringBuilder();

        for (int i = 0; i < str.Length; i++)
        {
            reversed.Append(str[str.Length - i - 1]);
        }

        Console.WriteLine(reversed.ToString());
    }
}