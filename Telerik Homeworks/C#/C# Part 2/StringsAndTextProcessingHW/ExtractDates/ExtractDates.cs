using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

class ExtractDates
{
    static void Main(string[] args)
    {
        string text;
        StreamReader reader = new StreamReader("file.txt");
        using (reader)
        {
            text = reader.ReadToEnd();
        }

        MatchCollection dates = Regex.Matches(text, @"[0-3][0-9].[0-1][0-9].[\d]{4}");

        foreach (var date in dates)
        {
            DateTime currentDate = DateTime.Parse(date.ToString());
            Console.WriteLine(currentDate.ToString(new CultureInfo("en-CA")));
        }
    }
}