using System;

class CalculateSumFromString
{
    public static int GetSum(string str)
    {
        string[] strArray = str.Split(' ');

        int sum = 0;

        for (int i = 0; i < strArray.Length; i++)
        {
            int number = int.Parse(strArray[i]);
            sum += number;
        }

        return sum;
    }

    static void Main(string[] args)
    {
        Console.Write("Input: ");
        string input = Console.ReadLine();

        Console.WriteLine("Sum = {0}", GetSum(input));
    }
}