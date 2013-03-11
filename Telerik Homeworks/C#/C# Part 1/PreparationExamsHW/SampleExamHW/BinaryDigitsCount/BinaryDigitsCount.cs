using System;

class BinaryDigitsCount
{
    static void Main()
    {
        byte digit = byte.Parse(Console.ReadLine());
        short numbersCount = short.Parse(Console.ReadLine());
        uint[] numbers = new uint[numbersCount];

        char charDigit = '0';
        if (digit == 1)
        {
            charDigit = '1';
        }

        for (int i = 0; i < numbersCount; i++)
        {
            numbers[i] = uint.Parse(Console.ReadLine());
        }

        string binNumber;
        for (int i = 0; i < numbersCount; i++)
        {
            int counter = 0;
            binNumber = Convert.ToString(numbers[i], 2);

            for (int j = 0; j < binNumber.Length; j++)
            {
                if (binNumber[j] == charDigit)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}