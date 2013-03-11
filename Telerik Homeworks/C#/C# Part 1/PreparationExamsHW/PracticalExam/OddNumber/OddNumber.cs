using System;

class OddNumber
{
    static void Main()
    {
        // Видях решението от демотата, защото моето решение е бавно, но работи.
        // До сега не съм използвал XOR. Разписах го на лист.
        // Наистина много елегантно решение

        int N = int.Parse(Console.ReadLine());
        long result = 0;
        for (int i = 0; i < N; i++)
        {
            long number = long.Parse(Console.ReadLine());
            result = result ^ number;
        }
        Console.WriteLine(result);

        //// input the count (N) of the numbers
        //int n = int.Parse(Console.ReadLine());

        //long[] numbers = new long[n];

        //// input the numbers
        //for (int i = 0; i < n; i++)
        //{
        //    numbers[i] = long.Parse(Console.ReadLine());
        //}

        //int[] bitMap = new int[n];

        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = 0; j < n; j++)
        //    {
        //        if (numbers[i] == numbers[j])
        //        {
        //            bitMap[i]++;
        //        }
        //    }
        //}

        //int oddIndex = 0;
        //for (int i = 0; i < n; i++)
        //{
        //    if (bitMap[i] % 2 != 0)
        //    {
        //        oddIndex = i;
        //    }
        //}

        //Console.WriteLine(numbers[oddIndex]);
    }
}