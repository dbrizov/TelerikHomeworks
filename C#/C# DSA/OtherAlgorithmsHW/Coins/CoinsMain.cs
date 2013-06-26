using System;

namespace Coins
{
    public class CoinsMain
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] coins = new int[3] { 5, 2, 1 };
            int[] coinsCount = new int[3];

            for (int i = 0; i < coins.Length; i++)
            {
                coinsCount[i] = number / coins[i];
                number %= coins[i];
            }

            Console.WriteLine("{0}coin(s) x 5 + {1}coin(s) x 2 + {2}coin(s) x 1",
                coinsCount[0], coinsCount[1], coinsCount[2]);
        }
    }
}
