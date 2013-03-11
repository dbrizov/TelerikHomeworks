using System;
using System.Text;

class EncodeAndDecode
{
    static string EncodeDecode(string str, string cipher)
    {
        StringBuilder result = new StringBuilder(str);
        int index = 0;

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = (char)(result[i] ^ cipher[index]);

            if (index != cipher.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

        return result.ToString();
    }

    static void Main(string[] args)
    {
        string str = "Denis Borislavov Rizov";

        Console.Write("Enter a cipher(a string): ");
        string cipher = Console.ReadLine();

        str = EncodeDecode(str, cipher);
        Console.WriteLine(str);

        str = EncodeDecode(str, cipher);
        Console.WriteLine(str);
    }
}