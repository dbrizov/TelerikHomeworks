using System;

class UpperCaseTag
{
    static void Main(string[] args)
    {
        string text = @"We are living in a <upcase>yellow submarine</upcase>. 
We don't have <upcase>anything</upcase> else.";

        int index1 = text.IndexOf(">"); // The first index of '>'
        int index2 = 0;
        if (index1 != -1)
        {
            index2 = text.IndexOf("<", index1); // The second index of '<'
        }

        while (index1 != -1 && index2 != -1)
        {
            string substring = text.Substring(index1 + 1, index2 - index1 - 1);
            string newSubstring = substring.ToUpper();

            text = text.Replace(substring, newSubstring);

            index1 = text.IndexOf(">", index1 + 1);
            index1 = text.IndexOf(">", index1 + 1);
            if (index1 != -1)
            {
                index2 = text.IndexOf("<", index1);
            }
        }

        text = text.Replace("<upcase>", "");
        text = text.Replace("</upcase>", "");

        Console.WriteLine(text);
    }
}