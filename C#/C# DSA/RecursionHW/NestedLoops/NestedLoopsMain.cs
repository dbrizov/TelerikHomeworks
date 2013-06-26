using System;

namespace NestedLoops
{
    public class NestedLoopsMain
    {
        public static void Main(string[] args)
        {
            Console.Write("Number of nested loops = ");
            int nestedLoopsCount = int.Parse(Console.ReadLine());

            int[] arr = new int[nestedLoopsCount];
            SimulateNestedLoops(arr, 0);
        }

        public static void SimulateNestedLoops(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                // The most inner loop ended - we are printing the result
                PrintArray(arr);
                return;
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[index] = i + 1;
                    SimulateNestedLoops(arr, index + 1);
                }
            }
        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
