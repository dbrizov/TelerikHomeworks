using System;

class LexicographicOrdinance
{
    static void Main(string[] args)
    {
        // Input the arrays lengths
        Console.Write("array1 length = ");
        int arr1Length = int.Parse(Console.ReadLine());
        Console.Write("array2 length = ");
        int arr2Length = int.Parse(Console.ReadLine());

        char[] arr1 = new char[arr1Length];
        char[] arr2 = new char[arr2Length];

        // Input char array1
        for (int i = 0; i < arr1.Length; i++)
        {
            Console.Write("array1[{0}] = ", i);
            arr1[i] = char.Parse(Console.ReadLine());
        }

        // Input char array2
        for (int i = 0; i < arr2.Length; i++)
        {
            Console.Write("array2[{0}] = ", i);
            arr2[i] = char.Parse(Console.ReadLine());
        }

        int minLength = Math.Min(arr1.Length, arr2.Length); // The length of the smaller array
        bool equalToMinLength = false; // Checks if the two arrays are equal from index 0 to index (minLength - 1)

        // Complares from index 0 to index (minLength - 1)
        for (int i = 0; i < minLength; i++)
        {
            if (arr1[i] < arr2[i])
            {
                Console.WriteLine("array1 is earlier in lexicographic ordinance");
                equalToMinLength = true;
                break;
            }
            if (arr1[i] > arr2[i])
            {
                Console.WriteLine("array2 is earlier in lexicographic ordinance");
                equalToMinLength = true;
                break;
            }
        }

        // If they are equal in [0, minIndex - 1], then the lengths are compared
        if (equalToMinLength == false)
        {
            if (arr1.Length < arr2.Length)
            {
                Console.WriteLine("array1 is earlier in lexicographic ordinance");
            }
            else if (arr1.Length > arr2.Length)
            {
                Console.WriteLine("array2 is earlier in lexicographic ordinance");
            }
            else
            {
                Console.WriteLine("The arrays are equal");
            }
        }
    }
}