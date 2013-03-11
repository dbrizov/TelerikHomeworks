using System;
using System.IO;

class PrintOddLines
{
    // The counting starts from 0
    public static void PrintOdd(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line = reader.ReadLine();
            int counter = 0;

            while (line != null)
            {
                if (counter % 2 != 0)
                {
                    Console.WriteLine(line);
                }

                line = reader.ReadLine();
                counter++;
            }
        }
    }

    static void Main(string[] args)
    {
        string path = "file.txt";

        PrintOdd(path);
    }
}