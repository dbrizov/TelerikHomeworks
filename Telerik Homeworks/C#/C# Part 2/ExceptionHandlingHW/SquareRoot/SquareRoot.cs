using System;

class SquareRoot
{
    static void Main(string[] args)
    {
        Console.Write("Input number: ");

        try
        {
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid number. Can't calculate the square root of a negavite number");
            }

            double square = Math.Sqrt(number);
            Console.WriteLine("Square = {0}", square);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number. You have to enter a number");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ivalid number. The number is too big");
        }
        finally
        {
            Console.WriteLine("Goodbye!");
        }
    }
}