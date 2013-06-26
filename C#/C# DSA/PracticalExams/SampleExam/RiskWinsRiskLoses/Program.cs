using System;
using System.Collections.Generic;
using System.Text;

namespace RiskWinsRiskLoses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string startCombination = Console.ReadLine();
            string endCombination = Console.ReadLine();
            int forbiddenCombinationsCount = int.Parse(Console.ReadLine());

            List<string> forbiddenCombinations = new List<string>();
            for (int i = 0; i < forbiddenCombinationsCount; i++)
            {
                string forbiddenCombination = Console.ReadLine();
                forbiddenCombinations.Add(forbiddenCombination);
            }

            int pressedButtonsCount = 0;
            for (int i = 0; i < startCombination.Length; i++)
            {
                int startDigit = startCombination[i] - '0';
                int endDigit = endCombination[i] - '0';

                pressedButtonsCount += Math.Min(
                    Math.Abs(startDigit - endDigit),
                    10 - Math.Abs(startDigit - endDigit));
            }

            Console.WriteLine(pressedButtonsCount);
        }
    }
}
