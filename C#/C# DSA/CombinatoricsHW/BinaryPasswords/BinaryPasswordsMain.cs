using System;

namespace BinaryPasswords
{
    public class BinaryPasswordsMain
    {
        public static long Pow(long x, long y)
        {
            long result = 1;
            for (int i = 0; i < y; i++)
            {
                result *= x;
            }

            return result;
        }

        public static void Main(string[] args)
        {
            string pattern = Console.ReadLine();

            // Count the asterices
            long astericsCount = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == '*')
                {
                    astericsCount++;
                }
            }

            // The number of passwords is 2^astericsCount
            Console.WriteLine(Pow(2, astericsCount));
        }
    }
}
