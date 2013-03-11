using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidRangeException
{
    class Demo
    {
        static void Main(string[] args)
        {
            // InvalidRangeException<int> test
            try
            {
                Console.Write("Input an integer in the range [1, 100]: ");
                int number = int.Parse(Console.ReadLine());

                if (number < 1 || number > 100)
                {
                    throw new InvalidRangeException<int>(1, 100);
                }

                Console.WriteLine("The integer was in the corrent range");
            }

            catch (InvalidRangeException<int> invalidRangeException)
            {
                Console.WriteLine(invalidRangeException.Message);
            }

            // InvalidRangeException<DateTime> test
            Console.WriteLine();

            try
            {
                DateTime startDate = new DateTime(1980, 1, 1);
                DateTime endDate = new DateTime(2013, 12, 31);

                Console.Write("Input a date in the range [1.1.1980, 31.12.2013]: ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                if (date < startDate || date > endDate)
                {
                    throw new InvalidRangeException<DateTime>(startDate, endDate);
                }

                Console.WriteLine("The date was in the correct range");
            }

            catch (InvalidRangeException<DateTime> invalidRangeException)
            {
                Console.WriteLine(invalidRangeException.Message);
            }
        }
    }
}
