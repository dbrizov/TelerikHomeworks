using System;

class EqualArrays
{
    static void Main(string[] args)
    {
        bool equal = true;

        // Input the array lengths
        Console.Write("array1 Length = ");
        int array1Length = int.Parse(Console.ReadLine());
        Console.Write("array2 Length = ");
        int array2Length = int.Parse(Console.ReadLine());

        if (array1Length == array2Length)
        {
            int[] array1 = new int[array1Length];
            int[] array2 = new int[array2Length];

            // Input array1 elements
            for (int i = 0; i < array1.Length; i++)
            {
                Console.Write("array1[{0}] = ", i);
                array1[i] = int.Parse(Console.ReadLine());
            }

            // Input array2 elements
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write("array2[{0}] = ", i);
                array2[i] = int.Parse(Console.ReadLine());
            }

            // Compare the two arrays
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    equal = false;
                    break;
                }
            }
        }
        else
        {
            equal = false;
        }

        // Print the result
        Console.WriteLine(equal);
    }
}