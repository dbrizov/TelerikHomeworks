using System;
using System.IO;
using System.Text.RegularExpressions;

class DeleteTestPrefixWords
{
    static void Main(string[] args)
    {
        string oldText;
        string newText;

        StreamReader fileReader = new StreamReader("file.txt");
        using (fileReader)
        {
            oldText = fileReader.ReadToEnd();
        }

        newText = Regex.Replace(oldText, @"(\b)test((\w|\d|_)*)(\b)", string.Empty);
        // (\b) - starts a word boundary
        // the prefix is exactly test
        // ((\w|\d|_)*) - the next characters can be chars, numbers or _
        // * means that they can be repeated many times
        // the last (\b) sets the end of the word boundary

        StreamWriter fileWriter = new StreamWriter("file.txt");
        using (fileWriter)
        {
            fileWriter.WriteLine(newText);
        }
    }
}