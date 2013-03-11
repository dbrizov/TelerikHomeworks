using System;

class FactorialSequences
{
    static void Main()
    {
        Console.WriteLine("Input N and K (K > N > 1):");
        // n!
        decimal nFact = 1;
        Console.Write("N= ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            nFact = nFact * i;
        }

        // k!
        decimal kFact = 1;
        Console.Write("K= ");
        int k = int.Parse(Console.ReadLine());

        for (int i = 1; i <= k; i++)
        {
            kFact = kFact * i;
        }

        // (k - n)!
        decimal KminusNFact = 1;
        int KminusN = k - n;

        for (int i = 1; i <= KminusN; i++)
        {
            KminusNFact = KminusNFact * i;
        }

        Console.WriteLine("N! * K! / (K-N)! = " + nFact * kFact / KminusNFact);
    }
}