using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountEachElement
{
    class CountEachElementMain
    {
        static Dictionary<double, int> CountEachElement(double[] arr)
        {
            var elementsCounts = new Dictionary<double, int>();

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

        static void Main(string[] args)
        {
            double[] arr = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            Console.WriteLine(string.Join(", ", arr));

            var elementsCounts = CountEachElement(arr);
            foreach (var pair in elementsCounts)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
