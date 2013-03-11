using System;

class BinaryToHexadecimal
{
    public static string BinToHex(string binNumber)
    {
        string hexNumber = string.Empty;

        while (binNumber.Length % 4 != 0)
        {
            binNumber = "0" + binNumber;
        }

        string bitStr = string.Empty; // The string that represents the first 4 bits;
        int bitNum = 0; // The number that represents the first 4 bits;

        for (int i = 0; i < binNumber.Length; i++)
        {
            bitStr += binNumber[i];

            if (bitStr.Length == 4)
            {
                for (int j = 0; j < bitStr.Length; j++)
                {
                    if (bitStr[j] == '1')
                    {
                        bitNum += (int)Math.Pow(2, bitStr.Length - j - 1);
                    }
                }

                if (bitNum >= 0 && bitNum <= 9)
                {
                    hexNumber += (char)(bitNum + 48);
                }
                else if (bitNum >= 10 && bitNum <= 15)
                {
                    hexNumber += (char)(bitNum + 87);
                }

                bitStr = string.Empty;
                bitNum = 0;
            }
        }

        return hexNumber;
    }

    static void Main(string[] args)
    {
        Console.Write("Input binaty number: ");
        string bin = Console.ReadLine();

        Console.WriteLine("{0} = {1}", bin, BinToHex(bin));
    }
}