using System;

class FallDown
{
    static void Main()
    {
        byte[] bytes = new byte[8];
        string[] byteStrings = new string[8];

        // input the Bytes and converting them to byte-strings
        for (int i = 0; i < 8; i++)
        {
            bytes[i] = byte.Parse(Console.ReadLine());
            byteStrings[i] = Convert.ToString(bytes[i], 2).PadLeft(8, '0');
        }

        // generating a matrix of chars (bitMap) with the exact bit possitions
        char[,] bitMap = new char[8, 8];
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                bitMap[i, j] = (byteStrings[i])[j];
            }
        }

        // sortation of the bitMap columns
        char[] column = new char[8];
        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                column[i] = bitMap[i, j];
            }
            Array.Sort(column);
            for (int i = 0; i < 8; i++)
            {
                bitMap[i, j] = column[i];
            }
        }

        // generating the new Bytes from the sorted bitMap
        for (int i = 0; i < 8; i++)
        {
            byte number = 0;
            for (int j = 0; j < 8; j++)
            {
                if (bitMap[i, j] == '1')
                {
                    number += (byte)Math.Pow(2.0, (double)(7 - j));
                }
            }
            Console.WriteLine(number);
        }
    }
}