using System;

class OddOrEven
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine((number % 2 == 0) ? "Even" : "Odd");
    }
}
