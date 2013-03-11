using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ExtractOnlyTextFromHtml
{
    static void Main(string[] args)
    {
        List<string> text = new List<string>();

        StreamReader reader = new StreamReader("file.txt");
        using (reader)
        {
            int code = reader.Read();

            while (reader.EndOfStream == false)
            {
                StringBuilder str = new StringBuilder();

                if (code == (int)'>')
                {
                    code = reader.Read();

                    while (code != (int)'<')
                    {
                        str.Append((char)code);
                        code = reader.Read();
                    }

                    string trimed = (str.ToString()).Trim();
                    if (trimed != string.Empty)
                    {
                        text.Add(trimed);
                    }
                }

                code = reader.Read();
            }
        }

        for (int i = 0; i < text.Count; i++)
        {
            Console.WriteLine(text[i]);
        }
    }
}