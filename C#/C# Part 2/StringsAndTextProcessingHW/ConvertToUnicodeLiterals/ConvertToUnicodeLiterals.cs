using System;
using System.Text;

class ConvertToUnicodeLiterals
{
    public static string DecimalToHexadecimal(int number)
    {
        string helper = Convert.ToString(number, 16);
        int len = helper.Length;
        char[] hexNumber = new char[len];

        for (int i = 0; i < len; i++)
        {
            int remainder = number % 16;
            number /= 16;

            if (remainder >= 0 && remainder <= 9)
            {
                hexNumber[len - i - 1] = (char)(remainder + 48);
            }
            else if (remainder >= 10 && remainder <= 15)
            {
                hexNumber[len - i - 1] = (char)(remainder + 55);
            }
        }

        string result = new string(hexNumber);
        return result;
    }

    static void Main(string[] args)
    {
        Console.Write("Input string: ");
        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            Console.Write("\\u" + DecimalToHexadecimal((int)input[i]).PadLeft(4, '0'));
        }

        Console.WriteLine();
    }
}