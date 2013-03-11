using System;

class ReadNumbers
{
    public static int ReadNumber(int start, int end)
    {
        Console.Write("Input number: ");
        int number;

        try
        {
            number = int.Parse(Console.ReadLine());

            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException(
                    String.Format("The number has to be in the interval [{0}, {1}]", start, end));
            }
        }
        catch (FormatException fe)
        {
            throw new FormatException("The input is not a number!");
        }

        return number;
    }

    static void Main(string[] args)
    {
        for (int i = 1; i <= 10; i++)
        {
            ReadNumber(i, 10);
        }
    }
}