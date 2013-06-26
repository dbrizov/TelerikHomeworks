using System;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int p = int.Parse(input[2]);
            int q = int.Parse(input[3]);

            int count = 0;
            while (a % p != q)
            {
                a++;
            }

            for (int i = a; i <= b; i += p)
            {
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
