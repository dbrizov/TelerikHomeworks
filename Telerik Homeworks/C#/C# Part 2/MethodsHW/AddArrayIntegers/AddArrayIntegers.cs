using System;
using System.Numerics;

class AddArrayIntegers
{
    public static void PrintInteger(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[array.Length - i - 1]);
        }
        Console.WriteLine();
    }

    public static BigInteger AddIntegers(int[] num1, int[] num2)
    {
        BigInteger number1 = 0;
        BigInteger number2 = 0;
        BigInteger multiplier = 1;

        for (int i = 0; i < num1.Length; i++)
        {
            number1 += num1[i] * multiplier;
            multiplier *= 10;
        }

        multiplier = 1;

        for (int i = 0; i < num2.Length; i++)
        {
            number2 += num2[i] * multiplier;
            multiplier *= 10;
        }

        return (number1 + number2);
    }

    static void Main(string[] args)
    {
        // User input
        Console.Write("Number1 Length = ");
        int num1Length = int.Parse(Console.ReadLine());

        Console.Write("Number2 Length = ");
        int num2Length = int.Parse(Console.ReadLine());

        int[] num1 = new int[num1Length];
        int[] num2 = new int[num2Length];

        // num1 digits input
        for (int i = 0; i < num1.Length; i++)
        {
            Console.Write("Number1-digit{0} = ", i + 1);
            num1[num1.Length - i - 1] = int.Parse(Console.ReadLine());
        }

        // num2 digits input
        for (int i = 0; i < num2.Length; i++)
        {
            Console.Write("Number-digit{0} = ", i + 1);
            num2[num2.Length - i - 1] = int.Parse(Console.ReadLine());
        }

        PrintInteger(num1);
        PrintInteger(num2);

        BigInteger result = AddIntegers(num1, num2);
        Console.WriteLine(result);
    }
}