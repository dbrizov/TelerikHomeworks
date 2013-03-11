using System;

class DecimalToBinary
{
    public static int[] DecToBin(int number)
    {
        string helper = Convert.ToString(number, 2);
        int len = helper.Length;

        int[] binNumber = new int[len];

        for (int i = 0; i < len; i++)
        {
            binNumber[len - i - 1] = number % 2;
            number /= 2;
        }

        return binNumber;
    }

    static void Main(string[] args)
    {
        Console.Write("Input number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("{0} = ", number);

        int[] binNumber = DecToBin(number);

        for (int i = 0; i < binNumber.Length; i++)
        {
            Console.Write(binNumber[i]);
        }

        Console.WriteLine();
    }
}