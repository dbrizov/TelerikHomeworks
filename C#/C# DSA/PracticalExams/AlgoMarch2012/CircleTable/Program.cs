using System;

namespace CircleTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int evenKnightsCount = int.Parse(input[0]);
            int oddKnightsCount = int.Parse(input[1]);
            int knightsCount = evenKnightsCount + oddKnightsCount;
            int sitsCount = int.Parse(input[2]);
            int knightsDistance = int.Parse(input[3]);

            int result = 1;
            for (int i = 0; i < knightsCount; i++)
            {
                result *= sitsCount;
                sitsCount -= (knightsDistance + 1);
            }

            Console.WriteLine(result);
        }
    }
}
