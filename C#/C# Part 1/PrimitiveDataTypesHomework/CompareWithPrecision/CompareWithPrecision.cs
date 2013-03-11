using System;

class CompareWithPrecision
{
    static void Main()
    {
        // precision = 0.000001
        double number1 = double.Parse(Console.ReadLine());
        double number2 = double.Parse(Console.ReadLine());

        if (Math.Abs(number1 - number2) < 0.000001)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}
