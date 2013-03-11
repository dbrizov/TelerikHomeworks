using System;

class ConvertNumericalSystems
{
    // (0 -> '0')  (10 -> 'A')  (15 -> 'F') ...
    public static char GetSymbol(int number)
    {
        if (number >= 10)
        {
            return (char)(number + 'A' - 10);
        }
        else
        {
            return (char)(number + '0');
        }
    }

    // ('A' -> 10) ('C' -> 12)  ('Z' -> 36)
    public static int GetNumber(char symbol)
    {
        if (symbol >= 'A')
        {
            return (int)(symbol - 'A' + 10);
        }
        else
        {
            return (int)(symbol - '0');
        }
    }

    // Convert from base 10 to base X
    public static string ConvertFrom10ToX(long number, int x)
    {
        string result = string.Empty;

        while (number != 0)
        {
            int remainder = (int)(number % x);
            result = GetSymbol(remainder) + result;
            number /= x;
        }

        return result;
    }

    // Convert from base X to base 10
    public static long ConvertFromXTo10(string number, int x)
    {
        long result = 0;

        for (int i = 0; i < number.Length; i++)
        {
            result += GetNumber(number[i]) * (long)Math.Pow(x, number.Length - i - 1);
        }

        return result;
    }

    // Convert from bas X to base Y
    public static string ConvertFromXToY(string number, int x, int y)
    {
        long decNumber = ConvertFromXTo10(number, x);
        string yNumber = ConvertFrom10ToX(decNumber, y);

        return yNumber;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(ConvertFromXToY("826", 10, 36));
        Console.WriteLine(ConvertFromXToY("1086854", 10, 36));
        Console.WriteLine(ConvertFromXToY("676", 10, 36));
        Console.WriteLine(ConvertFromXToY("22518676", 10, 36));
        Console.WriteLine(ConvertFromXToY("46235695", 10, 36));

        Console.WriteLine();

        Console.WriteLine(ConvertFromXToY("FF", 16, 10));
        Console.WriteLine(ConvertFromXToY("FF", 16, 2));
        Console.WriteLine(ConvertFromXToY("FF", 16, 8));
        Console.WriteLine(ConvertFromXToY("FF", 16, 20));
    }
}