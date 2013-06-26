using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractStringsWithOddCount
{
    class OddStringsCountMain
    {
        static Dictionary<string, int> CountEachElement(string[] arr)
        {
            var elementsCounts = new Dictionary<string, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (elementsCounts.ContainsKey(arr[i]))
                {
                    elementsCounts[arr[i]]++;
                }
                else
                {
                    elementsCounts.Add(arr[i], 1);
                }
            }

            return elementsCounts;
        }

        static string[] ExtractStringsWithOddCount(string[] arr)
        {
            var elementsCounts = CountEachElement(arr);
            List<string> elementsWithOddCount = new List<string>();

            foreach (var pair in elementsCounts)
            {
                if (pair.Value % 2 != 0)
                {
                    elementsWithOddCount.Add(pair.Key);
                }
            }

            return elementsWithOddCount.ToArray();
        }

        static void Main(string[] args)
        {
            string[] arr = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            Console.WriteLine(string.Join(", ", arr));

            string[] stringsWithOddCount = ExtractStringsWithOddCount(arr);

            Console.WriteLine(string.Join(", ", stringsWithOddCount));
        }
    }
}
