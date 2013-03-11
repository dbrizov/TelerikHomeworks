using System;

class HexadecimalToBinary
{
    public static string HexToBin(string hexNumber)
    {
        string binNumber = string.Empty;

        for (int i = 0; i < hexNumber.Length; i++)
        {
            int number; // The number that represents the first 4 bits

            if (hexNumber[i] >= '0' && hexNumber[i] <= '9')
            {
                number = (int)(hexNumber[i] - '0');
            }
            else if (hexNumber[i] >= 'a' && hexNumber[i] <= 'f')
            {
                number = (int)(hexNumber[i] - 87);
            }
            else
            {
                number = (int)(hexNumber[i] - 55);
            }

            string bin = Convert.ToString(number, 2).PadLeft(4, '0');

            binNumber += bin;
        }

        return binNumber;
    }

    static void Main(string[] args)
    {
        Console.Write("Input hex number: ");
        string hex = Console.ReadLine();

        Console.WriteLine("{0} = {1}", hex, HexToBin(hex));
    }
}