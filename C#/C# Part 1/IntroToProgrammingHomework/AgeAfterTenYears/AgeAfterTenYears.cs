using System;

class AgeAfterTenYears
{
    static void Main()
    {
        Console.Write("Your age: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("After 10 years you will be " + (age + 10) + " years old");
    }
}
