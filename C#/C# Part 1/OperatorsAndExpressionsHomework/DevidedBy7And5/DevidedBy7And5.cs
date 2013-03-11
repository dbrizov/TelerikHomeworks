using System;

class DevidedBy7And5
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        if (number % 35 == 0)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}
