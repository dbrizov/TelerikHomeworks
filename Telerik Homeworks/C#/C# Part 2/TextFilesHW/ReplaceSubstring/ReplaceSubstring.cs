using System;
using System.IO;

class ReplaceSubstring
{
    static void Main(string[] args)
    {
        string oldText;
        string newText;

        StreamReader fileReader = new StreamReader("file.txt");
        using (fileReader)
        {
            oldText = fileReader.ReadToEnd();
            newText =  oldText.Replace("start", "finish");
        }

        StreamWriter fileWriter = new StreamWriter("file.txt");
        using (fileWriter)
        {
            fileWriter.WriteLine(newText);
        }
    }
}