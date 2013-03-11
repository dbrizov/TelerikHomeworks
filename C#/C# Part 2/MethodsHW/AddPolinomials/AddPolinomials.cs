using System;

class AddPolinomials
{
    public static int[] AddPolis(int[] poli1, int[] poli2)
    {
        int maxLength = Math.Max(poli1.Length, poli2.Length);
        int[] result = new int[maxLength];

        if (maxLength == poli1.Length)
        {
            result = (int[])poli1.Clone();

            for (int i = 0; i < poli2.Length; i++)
            {
                result[i] += poli2[i];
            }
        }
        else
        {
            result = (int[])poli2.Clone();

            for (int i = 0; i < poli1.Length; i++)
            {
                result[i] += poli1[i];
            }
        }

        return result;
    }

    public static void PrintPoli(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[arr.Length - i - 1] >= 0)
            {
                Console.Write(" +{0}x^{1}", arr[arr.Length - i - 1], arr.Length - i - 1);
            }
            else
            {
                Console.Write(" {0}x^{1}", arr[arr.Length - i - 1], arr.Length - i - 1);
            }
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        int[] poli1 = { -5, 0, 1 };
        int[] poli2 = { 9, 2, -1, 2, 4};

        PrintPoli(poli1);
        PrintPoli(poli2);
        Console.WriteLine(new string('-', 79));

        PrintPoli(AddPolis(poli1, poli2));
    }
}