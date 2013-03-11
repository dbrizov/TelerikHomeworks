using System;

class ExchangeValues
{
    static void Main()
    {
        int number1 = 5;
        int number2 = 10;
        int x = number1;
        number1 = number2;
        number2 = x;

        Console.WriteLine(number1);
        Console.WriteLine(number2);
    }
}
