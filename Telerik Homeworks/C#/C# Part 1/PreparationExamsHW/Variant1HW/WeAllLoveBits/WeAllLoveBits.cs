using System;

class WeAllLoveBits
{
    static double Pow(double x, double y)
    {
        double result = 1;
        for (int i = 0; i < y; i++)
        {
            result *= x;
        }
        return result;
    }

    static void Main()
    {
        // read the input
        int N = int.Parse(Console.ReadLine());
        uint[] numbers = new uint[N];

        for (int i = 0; i < N; i++)
        {
            numbers[i] = uint.Parse(Console.ReadLine());
        }

        // making the magic
        for (int i = 0; i < N; i++)
        {
            // making the inverted P
            uint q = numbers[i];
            int counter = 0;
            while (q != 0)
            {
                q = q / 2;
                counter++;
            }

            int counter2 = counter;
            for (int j = 0; j < counter; j++)
            {
                counter2--;
                q += (uint)Pow(2.0, (double)counter2);
            }

            uint invertedP = ~numbers[i] & q; // The inverted P

            // making the reversed P
            q = numbers[i];
            uint[] bits = new uint[counter];

            for (int j = 0; j < counter; j++)
            {
                bits[j] = q % 2;
                q = q / 2;
            }

            counter2 = counter;
            for (int j = 0; j < counter; j++)
            {
                counter2--;
                if (bits[j] == 1)
                {
                    q += (uint)Pow(2.0, (double)counter2);
                }
            }

            uint reversedP = q; // The reversed P

            // making the new P
            uint newP = (numbers[i] ^ invertedP) & reversedP;
            Console.WriteLine(newP);
        }
    }
}