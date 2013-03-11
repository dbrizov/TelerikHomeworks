using System;

class DecimalToHexadecimal
{
    public static char[] DecToHex(int number)
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

        return hexNumber;
    }

    static void Main(string[] args)
    {
        Console.Write("Input decimal number: ");
        int number = int.Parse(Console.ReadLine());

        char[] hexNumber = DecToHex(number);

        Console.Write("{0} = ", number);

        for (int i = 0; i < hexNumber.Length; i++)
        {
            Console.Write(hexNumber[i]);
        }

        Console.WriteLine();
    }
}