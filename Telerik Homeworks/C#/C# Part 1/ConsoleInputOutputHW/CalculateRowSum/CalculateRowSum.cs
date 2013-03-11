using System;

class CalculateRowSum
{
    static void Main()
    {
        decimal sum = 1m;
        decimal copyOfSum;

        int denom = 2;

        do
        {
            copyOfSum = sum;

            if (denom % 2 == 0)
            {
                sum = sum + 1m / denom;
            }
            else
            {
                sum = sum - 1m / denom;
            }

            denom++;
        }
        while (Math.Abs(copyOfSum - sum) >= 0.001m);

        Console.WriteLine("{0:f3}", copyOfSum);
        Console.WriteLine("{0:f3}", sum);
    }
}
