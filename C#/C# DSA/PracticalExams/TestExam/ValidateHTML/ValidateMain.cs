using System;
using System.Collections.Generic;
using System.Text;

namespace ValidateHTML
{
    class ValidateMain
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder(50);
            for (int i = 0; i < n; i++)
            {
                string html = Console.ReadLine();
                result.Append(CheckHTML(html));
            }

            Console.WriteLine(result.ToString());
        }

        static string CheckHTML(string html)
        {
            string[] matches = html.Split(new char[] { '<', '>' }, StringSplitOptions.RemoveEmptyEntries);

            Stack<string> tags = new Stack<string>();
            int count = 0;
            for (int i = 0; i < matches.Length; i++)
            {
                string tag = matches[i];
                tags.Push(tag);

                if (tag[0] != '/')
                {
                    count++;
                }
                else
                {
                    count--;

                    if (count < 0)
                    {
                        return "INVALID\n";
                    }
                    else
                    {
                        string closedTag = tags.Pop();
                        string openedTag = tags.Pop();
                        if (openedTag[0] != closedTag[1])
                        {
                            return "INVALID\n";
                        }
                    }
                }
            }

            if (count == 0)
            {
                return "VALID\n";
            }
            else
            {
                return "INVALID\n";
            }
        }
    }
}
