using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
    public static T[] ExtractSubsequence<T>(T[] arr, uint startIndex, uint count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("The input array is null");
        }

        if (startIndex >= arr.Length)
        {
            throw new ArgumentOutOfRangeException("the startIndex must be in range [0, arr.Length - 1]");
        }

        if (startIndex + count > arr.Length)
        {
            throw new ArgumentException(
                "The count is too big. There are not so many elements in the array. The index will go out of range");
        }

        List<T> result = new List<T>();
        for (int i = (int)startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Gets the ending string with length = count.
    /// If the count > str.length then the whole string is returned
    /// </summary>
    /// <param name="str">The string from which a new string will be extracted</param>
    /// <param name="count">The length of extracted string</param>
    /// <returns>
    /// The whole string if count > str.Length.
    /// The ending substring with length == count if str.Length > count
    /// </returns>
    public static string ExtractEnding(string str, uint count)
    {
        if (str == null)
        {
            throw new ArgumentNullException("The input string is null");
        }

        if (count > str.Length)
        {
            return str;
        }

        StringBuilder result = new StringBuilder();
        for (int i = (int)(str.Length - count); i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(uint number)
    {
        bool isPrime = true;
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                isPrime = false;
                break;
            }
        }

        return isPrime;
    }

    public static void Main()
    {
        var substr = ExtractSubsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = ExtractSubsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = ExtractSubsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        var emptyarr = ExtractSubsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(string.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 100)); // returns the whole string

        if (CheckPrime(23))
        {
            Console.WriteLine("23 is prime");
        }

        if (CheckPrime(33))
        {
            Console.WriteLine("33 is prime");
        }

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };

        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
