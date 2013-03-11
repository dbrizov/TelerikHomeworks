using System;

class FromToBitExchange
{
    static void Main()
    {
        Console.Write("Number= ");
        int number = Convert.ToInt32(Console.ReadLine());
        Console.Write("From: "); // from which bit...
        int from1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("To: "); // ...to which bit
        int to = Convert.ToInt32(Console.ReadLine());
        Console.Write("Select a starting #bit for exchange: "); // the exchange will start from this bit and will continue till (from1 - to + 1) exchanges are done
        int from2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        int copyOfNumber = number;

        int counter = 0;

        // counts how many bits are needed to write the number in binary
        do
        {
            copyOfNumber = copyOfNumber / 2;
            counter++;
        }
        while (copyOfNumber != 0);

        copyOfNumber = number;

        int indexHelper = 0; // helper for the next for ( ; ; )

        // writes the number in binary into an array bit by bit
        int[] bits = new int[32];
        for (int i = 0; i < 32; i++)
        {
            if (i < 32 - counter)
            {
                bits[i] = 0;
            }
            else
            {
                if (copyOfNumber % 2 != 0)
                {
                    bits[31 - indexHelper] = 1;
                }
                else
                {
                    bits[31 - indexHelper] = 0;
                }
                copyOfNumber = copyOfNumber / 2;
                indexHelper++;
            }
        }

        // prints "number" in binary
        for (int i = 0; i < 32; i++)
        {
            Console.Write(bits[i]);
        }
        Console.WriteLine(" -> " + number);

        // the exchanging of the bits
        for (int i = 0; i < to - from1 + 1; i++)
        {
            int x = bits[31 - from1 - i];
            bits[31 - from1 - i] = bits[31 - from2 - i];
            bits[31 - from2 - i] = x;
        }

        // converts the "binary number" back to decimal
        number = 0;
        for (int i = 0; i < 32; i++)
        {
            if (bits[32 - 1 - i] == 1)
            {
                number = number + (int)(Math.Pow(2.0, (double)i));
            }
        }

        // prints the NEW number in binary
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0') + " -> " + number);

        //second algorith with bitwise operators

        //Console.Write("Number= ");
        //int number = Convert.ToInt32(Console.ReadLine());
        //Console.Write("From: ");
        //int from1 = Convert.ToInt32(Console.ReadLine());
        //Console.Write("To: ");
        //int to = Convert.ToInt32(Console.ReadLine());
        //Console.Write("Select a starting #bit for exchange: ");
        //int from2 = Convert.ToInt32(Console.ReadLine());

        //int counter = 0;

        //int copyOfNumber = number;

        //for (int i = from1; i <= to; i++)
        //{
        //    if (((1 << i) & number) != 0 && ((1 << (from2 + counter)) & number) == 0)
        //    {
        //        number = number & ~(1 << i);
        //        number = number | (1 << (from2 + counter));
        //    }
        //    else if (((1 << i) & number) == 0 && ((1 << (from2 + counter)) & number) != 0)
        //    {
        //        number = number | (1 << i);
        //        number = number & ~(1 << (from2 + counter));
        //    }
        //    counter++;
        //}

        //Console.WriteLine(Convert.ToString(copyOfNumber, 2));
        //Console.WriteLine(Convert.ToString(number, 2));
    }
}
