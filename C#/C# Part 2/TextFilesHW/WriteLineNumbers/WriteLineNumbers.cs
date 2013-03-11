using System;
using System.IO;

class WriteLineNumbers
{
    static void Main(string[] args)
    {
        StreamReader reader = new StreamReader("withoutNumbers.txt");

        using (reader)
        {
            StreamWriter writer = new StreamWriter("withNumbers.txt");

            using (writer)
            {
                int counter = 1;
                string line = reader.ReadLine();

                while (line != null)
                {
                    writer.Write("{0}. ", counter);
                    writer.WriteLine(line);

                    line = reader.ReadLine();
                    counter++;
                }
            }
        }
    }
}