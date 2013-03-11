using System;

class MissCat
{
    static void Main()
    {
        int jury = int.Parse(Console.ReadLine());
        int[] cats = new int[10];

        int[] votes = new int[jury];
        for (int i = 0; i < jury; i++)
        {
            votes[i] = int.Parse(Console.ReadLine());
            cats[votes[i] - 1]++;
        }

        int maxVote = 0;
        for (int i = 0; i < 1; i++)
        {
            int maxIndex = i;
            for (int j = i + 1; j < 10; j++)
            {
                if (cats[j] > cats[maxIndex])
                {
                    maxIndex = j;
                }
            }
            maxVote = cats[maxIndex];
        }

        for (int i = 0; i < 10; i++)
        {
            if (cats[i] == maxVote)
            {
                Console.WriteLine(i + 1);
                break;
            }
        }
    }
}