using System;

class CircleAreaPerimeter
{
    static void Main()
    {
        Console.Write("r = ");
        int r = int.Parse(Console.ReadLine());

        Console.WriteLine("Perimeter = " + (2 * Math.PI * r));
        Console.WriteLine("Area = " + (Math.PI * r * r));
    }
}
