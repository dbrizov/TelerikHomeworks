using System;
using System.Collections.Generic;
using System.IO;

class SortListOfStrings
{
    static void Main(string[] args)
    {
        StreamReader listReader = new StreamReader("list-of-strings.txt");
        using (listReader)
        {
            List<string> list = new List<string>();
            string line = listReader.ReadLine();

            while (line != null)
            {
                list.Add(line);
                line = listReader.ReadLine();
            }

            list.Sort();

            StreamWriter listWriter = new StreamWriter("sorted-list.txt");
            using (listWriter)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    listWriter.WriteLine(list[i]);
                }
            }
        }
    }
}