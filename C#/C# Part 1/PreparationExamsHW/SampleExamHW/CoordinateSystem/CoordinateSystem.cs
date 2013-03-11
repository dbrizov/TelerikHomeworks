using System;

class CoordinateSystem
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());

        byte result = 0;

        if (x > 0 && y > 0)
        {
            result = 1;
        }
        else if (x < 0 && y > 0)
        {
            result = 2;
        }
        else if (x < 0 && y < 0)
        {
            result = 3;
        }
        else if (x > 0 && y < 0)
        {
            result = 4;
        }
        else if (x == 0 && y != 0)
        {
            result = 5;
        }
        else if (x != 0 && y == 0)
        {
            result = 6;
        }

        Console.WriteLine(result);
    }
}