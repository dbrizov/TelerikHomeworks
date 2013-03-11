using System;

class CircleRectangleExpression
{
    static void Main()
    {
        Console.Write("x= ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("y= ");
        double y = double.Parse(Console.ReadLine());

        bool outOfRectangle = (x < -1 || x > 5) || (y < -1 || y > 1);
        bool inCircle = (x - 1) * (x - 1) + (y - 1) * (y - 1) < 9;

        Console.WriteLine((outOfRectangle && inCircle) ? true : false);
    }
}
