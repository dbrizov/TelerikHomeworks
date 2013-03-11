using System;

class LeapYear
{
    static void Main(string[] args)
    {
        Console.Write("Year: ");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine(DateTime.IsLeapYear(year));
    }
}