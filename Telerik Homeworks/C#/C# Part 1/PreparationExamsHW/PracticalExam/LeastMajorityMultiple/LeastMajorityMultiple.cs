using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        byte[] arr = new byte[5];

        for (int i = 0; i < 5; i++)
        {
            arr[i] = byte.Parse(Console.ReadLine());
        }

        Array.Sort(arr);

        for (int i = arr[2]; i < int.MaxValue; i++)
        {
            int counter = 0;

            for (int j = 0; j < 5; j++)
            {
                if (i % arr[j] == 0)
                {
                    counter++;
                }
            }

            if (counter >= 3)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}