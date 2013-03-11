using System;

class DancingBits
{
    static void Main()
    {
        string bits = "";
        int dancingBits = 0;

        // read the input
        short k = short.Parse(Console.ReadLine());
        short n = short.Parse(Console.ReadLine());

        // input the numbers and converting them to bit strings and comcating them
        uint[] numbers = new uint[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = uint.Parse(Console.ReadLine());
            bits += Convert.ToString(numbers[i], 2);
        }

        int length = bits.Length;
        int trailingBits = 0;
        char previousBit = '5';
        
        // counting the dancing bits
        for (int i = 0; i < length; i++)
        {
            if (bits[i] == previousBit)
            {
                trailingBits++;
            }
            else
            {
                if (trailingBits == k)
                {
                    dancingBits++;
                }
                trailingBits = 1;
            }
            previousBit = bits[i];
        }

        if (trailingBits == k)
        {
            dancingBits++;
        }

        Console.WriteLine(dancingBits);
    }
}