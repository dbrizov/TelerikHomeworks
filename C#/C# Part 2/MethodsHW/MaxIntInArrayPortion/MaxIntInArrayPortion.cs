using System;

class MaxIntInArrayPortion
{
    public static int MaxIntInPortion(int[] array, int startIndex)
    {
        int maxInt = int.MinValue;

        for (int i = startIndex; i < array.Length; i++)
        {
            if (maxInt < array[i])
            {
                maxInt = array[i];
            }
        }

        return maxInt;
    }

    public static void AscendingSort(int[] array)
    {
        int[] copyArray = (int[])array.Clone();

        for (int i = 0; i < array.Length; i++)
        {
            int max = MaxIntInPortion(copyArray, 0);
            array[array.Length - 1 - i] = max;

            int maxIndex = 0;
            for (int j = 0; j < copyArray.Length; j++)
            {
                if (copyArray[j] == max)
                {
                    maxIndex = j;
                }
            }

            int[] tempArray = new int[copyArray.Length - 1];
            int tempArrayIndex = 0;

            for (int j = 0; j < copyArray.Length; j++)
            {
                if (j != maxIndex)
                {
                    tempArray[tempArrayIndex] = copyArray[j];
                    tempArrayIndex++;
                }
            }

            copyArray = (int[])tempArray.Clone();
        }
    }

    public static void DescendingSort(int[] array)
    {
        int[] copyArray = (int[])array.Clone();

        for (int i = 0; i < array.Length; i++)
        {
            int max = MaxIntInPortion(copyArray, 0);
            array[i] = max;

            int maxIndex = 0;
            for (int j = 0; j < copyArray.Length; j++)
            {
                if (copyArray[j] == max)
                {
                    maxIndex = j;
                }
            }

            int[] tempArray = new int[copyArray.Length - 1];
            int tempArrayIndex = 0;

            for (int j = 0; j < copyArray.Length; j++)
            {
                if (j != maxIndex)
                {
                    tempArray[tempArrayIndex] = copyArray[j];
                    tempArrayIndex++;
                }
            }

            copyArray = (int[])tempArray.Clone();
        }
    }

    public static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        int[] array = new int[] { 5, 1, 4, 3, 2 };

        PrintArray(array);

        AscendingSort(array);

        PrintArray(array);

        DescendingSort(array);

        PrintArray(array);
    }
}