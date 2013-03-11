using System;

class GetMax
{
    public static int Max(int x, int y)
    {
        if (x > y)
        {
            return x;
        }
        else
        {
            return y;
        }
    }

    static void Main(string[] args)
    {
        Console.Write("First = ");
        int first = int.Parse(Console.ReadLine());

        Console.Write("Second = ");
        int second = int.Parse(Console.ReadLine());

        Console.Write("Third = ");
        int third = int.Parse(Console.ReadLine());

        Console.WriteLine("Max = {0}", Max(Max(first, second), third));
    }
}