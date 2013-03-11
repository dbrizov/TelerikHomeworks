using System;

class PrimeInteger
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool flag = true;

        if (number % 2 == 0 && number != 2)
        {
            flag = false;
        }
        else
        {
            for (int i = 3; i <= Math.Sqrt(number); i = i + 2)
            {
                if (number % i == 0)
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
        }

        Console.WriteLine(flag);
    }
}
