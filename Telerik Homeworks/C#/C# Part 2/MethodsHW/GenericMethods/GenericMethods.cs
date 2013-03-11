using System;

class GenericMethods
{
    // NOTE: There is not precision check for double and float
    public static T GetMax<T>(params T[] array)
    {
        Array.Sort(array);

        return array[array.Length - 1];
    }

    // NOTE: There is not precision check for double and float
    public static T GetMin<T>(params T[] array)
    {
        Array.Sort(array);

        return array[0];
    }

    public static decimal GetAverage<T>(params T[] array)
    {
        dynamic sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return (decimal)sum / array.Length;
    }

    public static T GetSum<T>(params T[] array)
    {
        dynamic sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return sum;
    }

    public static T GetProduct<T>(params T[] array)
    {
        dynamic product = 1;

        for (int i = 0; i < array.Length; i++)
        {
            product *= array[i];
        }

        return product;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(GetMax(1, 2, 3, 4, 5));

        Console.WriteLine(GetMin(1.0f, 2.0f, 3.0f, 4.0f, 5.0f));

        Console.WriteLine(GetAverage(5, 5, 5, 6, 6));

        Console.WriteLine(GetSum(1.0m, 3.0m, 4.0m, 2.0m, 5.0m));

        Console.WriteLine(GetProduct(5.0m, 5.0m, 5.0m, 5.0m));

        Console.WriteLine(GetProduct(0L, 1L, 2L, 3L, 4L));
    }
}