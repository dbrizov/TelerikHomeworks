using System;

class HexadecimalToDecimal
{
    public static int HexToDec(string str)
    {
        int decimalNumber = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] >= '0' && str[i] <= '9')
            {
                decimalNumber += (str[i] - '0') * (int)Math.Pow(16.0, str.Length - i - 1);
            }
            else if (str[i] >= 'a' && str[i] <= 'f')
            {
                decimalNumber += (str[i] - 87) * (int)Math.Pow(16.0, str.Length - i - 1);
            }
            else if (str[i] >= 'A' && str[i] <= 'F')
            {
                decimalNumber += (str[i] - 55) * (int)Math.Pow(16.0, str.Length - i - 1);
            }
        }

        return decimalNumber;
    }

    static void Main(string[] args)
    {
        Console.Write("Input hexadecimal number: ");
        string hexNum = Console.ReadLine();

        Console.WriteLine("{0} = {1}", hexNum, HexToDec(hexNum));
    }
}