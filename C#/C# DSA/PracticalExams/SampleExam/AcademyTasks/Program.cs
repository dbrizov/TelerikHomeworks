using System;

namespace AcademyTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            int[] tasks = new int[input.Length];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = int.Parse(input[i]);
            }

            int variety = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMinSteps(tasks, variety));
        }

        static int GetMinSteps(int[] tasks, int variety)
        {
            int minSteps = tasks.Length;
            for (int i = 0; i < tasks.Length - 1; i++)
            {
                for (int j = i + 1; j < tasks.Length; j++)
                {
                    if (Math.Abs(tasks[i] - tasks[j]) >= variety)
                    {
                        int steps = 0;
                        steps += (i + 1) / 2; // from 0 to i, 0 inclusive
                        steps += (j - i + 1) / 2 + 1; // from i to j, both inclusive
                        minSteps = Math.Min(minSteps, steps);
                    }
                }
            }

            return minSteps;
        }
    }
}
