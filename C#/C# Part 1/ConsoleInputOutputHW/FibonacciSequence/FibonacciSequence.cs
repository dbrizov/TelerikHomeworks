using System;

class FibonacciSequence
{
    static void Main()
    {
        decimal first = 0;
        decimal second = 1;
        decimal helper;

        for (int i = 0; i < 100; i++)
        {
            helper = first;
            first = second;
            second = helper + second;

            Console.WriteLine(helper);
        }
    }
}
