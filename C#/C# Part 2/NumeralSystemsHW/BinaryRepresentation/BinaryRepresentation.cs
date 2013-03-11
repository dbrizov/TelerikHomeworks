using System;

class BinaryRepresentation
{
    public static string GetBinaryRepresentation(short number)
    {
        string binNumber = string.Empty;

        for (int i = 0; i < 16; i++)
        {
            binNumber = ((number >> i) & 1) + binNumber;
        }

        return binNumber;
    }

    static void Main(string[] args)
    {
        Console.Write("Input 16bit integer: ");
        short number = short.Parse(Console.ReadLine());

        Console.WriteLine("{0} = {1}", number, GetBinaryRepresentation(number));
    }
}