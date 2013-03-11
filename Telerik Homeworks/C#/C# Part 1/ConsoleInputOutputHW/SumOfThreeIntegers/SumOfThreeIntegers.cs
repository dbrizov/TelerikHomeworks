using System;

class SumOfThreeIntegers
{
    static void Main()
    {
        Console.Write("n1=");
        int number1 = int.Parse(Console.ReadLine());
        Console.Write("n2=");
        int number2 = int.Parse(Console.ReadLine());
        Console.Write("n3=");
        int number3 = int.Parse(Console.ReadLine());

        Console.WriteLine("sum=" + (number1 + number2 + number3));
    }
}
