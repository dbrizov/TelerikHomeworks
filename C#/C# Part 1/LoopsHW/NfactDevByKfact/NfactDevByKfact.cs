using System;

class NfactDevByKfact
{
    static void Main()
    {
        Console.WriteLine("Input N and K (K > N > 1):");
        decimal nFact = 1;
        Console.Write("N= ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            nFact = nFact * i;
        }

        decimal kFact = 1;
        Console.Write("K= ");
        int k = int.Parse(Console.ReadLine());

        for (int i = 1; i <= k; i++)
        {
            kFact = kFact * i;
        }

        Console.WriteLine("N!= " + nFact);
        Console.WriteLine("K!= " + kFact);
        Console.WriteLine("N! / K! = " + nFact / kFact);
    }
}