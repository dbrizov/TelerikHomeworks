using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderExtensions
{
    static class StringBuilderExtensions
    {
        // Extension method
        public static StringBuilder Substring(this StringBuilder strBuilder, int index, int length)
        {
            string str = strBuilder.ToString();
            return new StringBuilder(str.Substring(index, length));
        }

        // test
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder("Extension methods simple test");

            StringBuilder substring1 = str.Substring(1, 10); // Extension m
            StringBuilder substring2 = str.Substring(10, 3); // met

            Console.WriteLine(substring1);
            Console.WriteLine(substring2);
        }
    }
}
