using System;

class PolinomialsExtended
{
    public static int[] SubtractPolinomials(int[] poli1, int[] poli2)
    {
        int maxLength = Math.Max(poli1.Length, poli2.Length);
        int[] result = new int[maxLength];

        if (maxLength == poli1.Length)
        {
            result = (int[])poli1.Clone();

            for (int i = 0; i < poli2.Length; i++)
            {
                result[i] -= poli2[i];
            }
        }
        else
        {
            result = (int[])poli2.Clone();

            for (int i = 0; i < result.Length; i++)
            {
                result[i] *= -1;
            }

            for (int i = 0; i < poli1.Length; i++)
            {
                result[i] += poli1[i];
            }
        }

        return result;
    }

    public static int[] MultiplyPolinomials(int[] poli1, int[] poli2)
    {
        int[] result = new int[poli1.Length + poli2.Length - 1];

        for (int i = 0; i < poli1.Length; i++)
        {
            for (int j = 0; j < poli2.Length; j++)
            {
                result[i + j] += (poli1[i] * poli2[j]);
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
        int[] poli2 = { 9, 2, -1, 2, 4 };

        PrintPoli(poli1);
        PrintPoli(poli2);
        Console.WriteLine(new string('-', 79));

        Console.Write("Subtraction = ");
        PrintPoli(SubtractPolinomials(poli1, poli2));

        Console.Write("Multiplication = ");
        PrintPoli(MultiplyPolinomials(poli1, poli2));
    }
}