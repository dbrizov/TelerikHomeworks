using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ExtractTextFromXMLFile
{
    static void Main(string[] args)
    {
		List<string> text = new List<string>();

        StreamReader reader = new StreamReader("file.xml");
        using (reader)
        {
            int code = reader.Read();

            while (true)
            {
                StringBuilder str = new StringBuilder();
                if (code == (int)'>')
                {
                    code = reader.Read();
                    if (code == -1) // The end of the file is reached
                    {
                        break;
                    }

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