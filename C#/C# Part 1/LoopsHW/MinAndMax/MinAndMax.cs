using System;

class MinAndMax
{
    static void Main()
    {
        Console.Write("#numbers = ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("number-{0}: ", i + 1);
            arr[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            int x = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = x;
        }

        Console.WriteLine("Min= " + arr[0]);
        Console.WriteLine("Max= " + arr[n-1]);
    }
}
