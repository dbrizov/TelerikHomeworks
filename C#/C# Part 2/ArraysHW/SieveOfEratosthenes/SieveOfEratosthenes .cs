using System;

class SieveOfEratosthenes 
{
    static void Main(string[] args)
    {
        // User input
        Console.Write("[2, n];    n = ");
        int n = int.Parse(Console.ReadLine());

        /*
         * Find the prime numbers int [2, input]
         */
        bool[] map = new bool[n + 1];
        int[] numbers = new int[n + 1];

        // Generate the two arrays
        for (int i = 0; i < map.Length; i++)
        {
            numbers[i] = i; // 0 on 0-th index, 1 on 1-th index, 2 on 2-th index, ...
        }

        // All that are not prime are set to true
        // The indexes 0 and 1 are missed because we don't have to check if
        // the numbers 0 and 1 are prime.
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            for (int j = i * i; j < map.Length; j += i)
            {
                map[j] = true;
            }
        }

        // Print the prime numbers
        for (int i = 2; i < map.Length; i++)
        {
            if (map[i] == false)
            {
                Console.Write("{0} ", numbers[i]);
            }
        }

        Console.WriteLine();
    }
}