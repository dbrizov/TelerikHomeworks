using System;

class SubstringCount
{
    static void Main(string[] args)
    {
        string text = @"We are living in an yellow submarine. 
We don't have anything else. Inside the submarine is very tight. 
So we are drinking all the day. We will move out of it in 5 days.";
        text = text.ToLower();

        Console.WriteLine(text);

        Console.Write("Input substring: ");
        string substring = Console.ReadLine();
        substring = substring.ToLower();

        int counter = 0;
        int index = text.IndexOf(substring);

        while (index != -1)
        {
            counter++;
            index = text.IndexOf(substring, index + 1);
        }

        Console.WriteLine("\"{0}\" is contained {1} times", substring, counter);
    }
}