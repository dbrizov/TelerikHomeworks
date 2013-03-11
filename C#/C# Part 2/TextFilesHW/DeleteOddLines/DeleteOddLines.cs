using System;
using System.Collections.Generic;
using System.IO;

class DeleteOddLines
{
    static void Main(string[] args)
    {
        List<string> evenLines = new List<string>();

        StreamReader fileReader = new StreamReader("file.txt");
        using (fileReader)
        {
            int lineCounter = 1;
            string line = fileReader.ReadLine();

            while (line != null)
            {
                if (lineCounter % 2 == 0)
                {
                    evenLines.Add(line);
                }

                lineCounter++;
                line = fileReader.ReadLine();
            }
        }

        StreamWriter fileWriter = new StreamWriter("file.txt");
        using (fileWriter)
        {
            for (int i = 0; i < evenLines.Count; i++)
            {
                fileWriter.WriteLine(evenLines[i]);
            }
        }
    }
}