using System;

class FormatNumber
{
    static void Main(string[] args)
    {
        Console.Write("Input number: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("{0,15}", number);
        Console.WriteLine("{0,15:x}", number);
        Console.WriteLine("{0,15:p}", number);
        Console.WriteLine("{0,15:e}", number);
    }
}