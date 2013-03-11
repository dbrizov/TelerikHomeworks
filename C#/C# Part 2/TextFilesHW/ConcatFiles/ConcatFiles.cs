using System;
using System.IO;

class ConcatFiles
{
    public static void AppendFiles(string filePath1, string filePath2)
    {
        StreamWriter writer = new StreamWriter("appended.txt");
        using (writer)
        {
            StreamReader reader1 = new StreamReader(filePath1);
            using (reader1)
            {
                string firstFile = reader1.ReadToEnd();
                writer.Write(firstFile);
            }

            StreamReader reader2 = new StreamReader(filePath2);
            using (reader2)
            {
                string secondFile = reader2.ReadToEnd();
                writer.Write(secondFile);
            }
        }
    }

    static void Main(string[] args)
    {
        string firstFilePath = "file1.txt";
        string secondFilePath = "file2.txt";

        AppendFiles(firstFilePath, secondFilePath);
    }
}