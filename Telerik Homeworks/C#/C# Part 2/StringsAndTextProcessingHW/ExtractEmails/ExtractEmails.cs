using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main(string[] args)
    {
        string text;

        StreamReader reader = new StreamReader("file.txt");
        using (reader)
        {
            text = reader.ReadToEnd();
        }

        MatchCollection emails = Regex.Matches(text, @"[\w\d._]{2,20}[\w\d]{2,20}@[\w\d.]{2,20}[.]{1}[\w\d]{2,20}");

        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
    }
}