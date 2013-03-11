using System;

class BinaryToDecimal
{
    public static int BinToDec(int[] bin)
    {
        int decNum = 0;

        for (int i = 0; i < bin.Length; i++)
        {
            decNum += bin[i] * (int)Math.Pow(2, bin.Length - i - 1);
        }

        return decNum;
    }

    static void Main(string[] args)
    {
        int[] bin1 = { 1, 0, 0 };
        int[] bin2 = { 1, 1, 1, 1, 1, 1 };
        int[] bin3 = { 1, 0, 0, 0, 0, 0, 0 };

        Console.WriteLine(BinToDec(bin1));
        Console.WriteLine(BinToDec(bin2));
        Console.WriteLine(BinToDec(bin3));
    }
}