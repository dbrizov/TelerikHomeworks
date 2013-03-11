using System;

class LastDigitWord
{
    public static string LastDigitAsWord(int number)
    {
        int lastDigit = number % 10;
        switch (lastDigit)
        {
            case 0:
                return "Zero";
            case 1:
                return "One";
            case 2:
                return "Two";
            case 3:
                return "Three";
            case 4:
                return "Four";
            case 5:
                return "Five";
            case 6:
                return "Six";
            case 7:
                return "Seven";
            case 8:
                return "Eight";
            case 9:
                return "Nine";
            default:
                return "No suck digit";
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Integer = ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine(LastDigitAsWord(number));
    }
}