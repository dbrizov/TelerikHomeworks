using System;

namespace ExchangeValues
{
    class ExchangeValues
    {
        static void Main()
        {
            int first = 10;
            int second = 5;

            if (first > second)
            {
                int x = first;
                first = second;
                second = x;
            }

            Console.WriteLine(first);
            Console.WriteLine(second);
        }
    }
}
