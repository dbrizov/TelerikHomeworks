using System;

namespace GreatestOfFiveVars
{
    class GreatestOfFiveVars
    {
        static void Main()
        {
            int a = 2;
            int b = 3;
            int c = 5;
            int d = 4;
            int e = 1;

            int[] arr = new int[5] { a, b, c, d, e, };

            for (int i = 0; i < 4; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < 5; j++)
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

            Console.WriteLine(arr[4]);
        }
    }
}
