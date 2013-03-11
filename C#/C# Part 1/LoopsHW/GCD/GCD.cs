using System;

class GCD
{
    static void Main()
    {
        Console.Write("number-1 = ");
        int number1 = int.Parse(Console.ReadLine());

        Console.Write("number-2 = ");
        int number2 = int.Parse(Console.ReadLine());

        while (number1 != number2)
        {
            if (number1 > number2)
            {
                number1 -= number2;
            }
            else
            {
                number2 -= number1;
            }
        }

        Console.WriteLine(number1);
    }
}