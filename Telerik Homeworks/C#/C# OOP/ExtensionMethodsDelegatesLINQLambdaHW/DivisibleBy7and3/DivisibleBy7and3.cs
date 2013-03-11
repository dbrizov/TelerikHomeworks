using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleBy7and3
{
    class DivisibleBy7and3
    {
        static void Main(string[] args)
        {
            List<int> array = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 21, 42 };

            // With Lambda expressions
            List<int> filteredArray1 = array.FindAll((x) => x % 21 == 0);
            for (int i = 0; i < filteredArray1.Count; i++)
            {
                Console.WriteLine(filteredArray1[i]);
            }

            Console.WriteLine();

            // With LINQ Queries
            var filteredArray2 =
                from number in array
                where number % 21 == 0
                select number;

            foreach (var number in filteredArray2)
            {
                Console.WriteLine(number);
            }
        }
    }
}
