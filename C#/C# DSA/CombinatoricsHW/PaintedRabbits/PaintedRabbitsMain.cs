using System;
using System.Collections.Generic;

namespace PaintedRabbits
{
    public class PaintedRabbitsMain
    {
        public static void Main(string[] args)
        {
            int askedRabbits = int.Parse(Console.ReadLine());

            // Counts the same answers
            // If the input is 4 1 1 2 2 then in the dictionary we have
            // 1 -> 2
            // 2 -> 2
            Dictionary<int, int> answers = new Dictionary<int, int>();
            for (int i = 0; i < askedRabbits; i++)
            {
                int answer = int.Parse(Console.ReadLine());
                if (answers.ContainsKey(answer))
                {
                    answers[answer]++;
                }
                else
                {
                    answers[answer] = 1;
                }
            }

            long numberOfRabbits = 0;
            foreach (var pair in answers)
            {
                if (pair.Key + 1 >= pair.Value)
                {
                    numberOfRabbits += pair.Key + 1;
                }
                else
                {
                    // I have figured out these strange formula.
                    // Unfortunately it's hard to explain.
                    numberOfRabbits +=
                        (pair.Value / (pair.Key + 1)) * (pair.Key + 1) +
                        (pair.Value % (pair.Key + 1)) * (pair.Key + 1);
                }
            }

            Console.WriteLine(numberOfRabbits);
        }
    }
}
