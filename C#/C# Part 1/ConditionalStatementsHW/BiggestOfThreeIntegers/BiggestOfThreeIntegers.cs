using System;

namespace BiggestOfThreeIntegers
{
    class BiggestOfThreeIntegers
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int max = 0;

            if (a > b)
            {
                if (a > c)
                {
                    max = a;
                }
                else
                {
                    max = c;
                }
            }

            if (a > c)
            {
                if (a > b)
                {
                    max = b;
                }
                else
                {
                    max = c;
                }
            }

            if (b > a)
            {
                if (b > c)
                {
                    max = b;
                }
                else
                {
                    max = c;
                }
            }

            if (b > c)
            {
                if (b > a)
                {
                    max = b;
                }
                else
                {
                    max = a;
                }
            }

            if (c > a)
            {
                if (c > b)
                {
                    max = c;
                }
                else
                {
                    max = b;
                }
            }

            if (c > b)
            {
                if (c > a)
                {
                    max = c;
                }
                else
                {
                    max = a;
                }
            }

            Console.WriteLine("max= " + max);
        }
    }
}
