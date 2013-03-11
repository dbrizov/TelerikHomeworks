using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableExtensionMethods
{
    public static class IEnumerableExtensions
    {
        // Sum extension
        public static T Sum<T>(this IEnumerable<T> enumeration) where T : struct, IConvertible, IComparable
        {
            dynamic sum = enumeration.ElementAt<T>(0);
            foreach (var item in enumeration)
            {
                sum += item;
            }

            return sum - enumeration.ElementAt<T>(0);
        }

        // Product extension
        public static T Product<T>(this IEnumerable<T> enumeration) where T : struct, IConvertible, IComparable
        {
            dynamic product = enumeration.ElementAt<T>(0);
            foreach (var item in enumeration)
            {
                product *= item;
            }

            return product / enumeration.ElementAt<T>(0);
        }

        // Min extension
        public static T Min<T>(this IEnumerable<T> enumeration) where T : struct, IConvertible, IComparable
        {
            dynamic min = enumeration.ElementAt<T>(0);
            foreach (var item in enumeration)
            {
                if (min > item)
                {
                    min = item;
                }
            }

            return min;
        }

        // Max extension
        public static T Max<T>(this IEnumerable<T> enumeration) where T : struct, IConvertible, IComparable
        {
            dynamic max = enumeration.ElementAt<T>(0);
            foreach (var item in enumeration)
            {
                if (max < item)
                {
                    max = item;
                }
            }

            return max;
        }

        // Average extension
        public static T Average<T>(this IEnumerable<T> enumeration) where T : struct, IConvertible, IComparable
        {
            T sum = enumeration.Sum<T>();
            int count = 0;
            foreach (var item in enumeration)
            {
                count++;
            }

            return (dynamic)sum / count;
        }

        // Extensions tests
        static void Main(string[] args)
        {
            List<double> list = new List<double> { 1, 2, 3, 4.5, 3.14, 2.71 };

            Console.WriteLine("Sum = " + list.Sum<double>());
            Console.WriteLine("Average = " + list.Average<double>());
            Console.WriteLine("Min = " + list.Min<double>());
            Console.WriteLine("Max = " + list.Max<double>());
            Console.WriteLine("Product = " + list.Product<double>());
        }
    }
}
