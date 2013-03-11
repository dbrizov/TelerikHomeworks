using System;
using System.IO;

class CompareFiles
{
    static void Main(string[] args)
    {
        int same = 0;
        int different = 0;

        StreamReader fileReader1 = new StreamReader("file1.txt");
        using (fileReader1)
        {
            StreamReader fileReader2 = new StreamReader("file2.txt");
            using (fileReader2)
            {
                string line1 = fileReader1.ReadLine();
                string line2 = fileReader2.ReadLine();

                while (line1 != null && line2 != null)
                {
                    if (String.Compare(line1, line2) == 0)
                    {
                        same++;
                    }
                    else
                    {
                        different++;
                    }

                    line1 = fileReader1.ReadLine();
                    line2 = fileReader2.ReadLine();
                }
            }
        }

        Console.WriteLine("Same lines: {0}", same);
        Console.WriteLine("Different lines: {0}", different);
    }
}