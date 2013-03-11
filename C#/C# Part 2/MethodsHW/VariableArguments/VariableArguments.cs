using System;

class VariableArguments
{
    public static int GetMax(params int[] array)
    {
        int max = int.MinValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (max < array[i])
            {
                max = array[i];
            }
        }

        return max;
    }

    public static int GetMin(params int[] array)
    {
        int min = int.MaxValue;

        for (int i = 0; i < array.Length; i++)
        {
            if (min > array[i])
            {
                min = array[i];
            }
        }

        return min;
    }

    public static double GetAverage(params int[] array)
    {
        int sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return (double)sum / array.Length;
    }

    public static int GetSum(params int[] array)
    {
        int sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return sum;
    }

    public static int GetProduct(params int[] array)
    {
        int product = 1;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == 0)
            {
                return 0;
            }

            product *= array[i];
        }

        return product;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(GetMax(1, 2, 3, 4, 5));

        Console.WriteLine(GetMin(1, 2, 3, 4, 5));

        Console.WriteLine(GetAverage(5, 5, 5, 6, 6));

        Console.WriteLine(GetSum(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));

        Console.WriteLine(GetProduct(5, 5, 5, 5));

        Console.WriteLine(GetProduct(0, 1, 2, 3, 4));
    }
}