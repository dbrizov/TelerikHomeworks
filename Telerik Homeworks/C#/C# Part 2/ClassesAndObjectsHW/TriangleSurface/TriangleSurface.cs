using System;

class TriangleSurface
{
    public static double GetSurfaceWithAltitude(double a, double ha)
    {
        return (a * ha) / 2;
    }

    public static double GetSurfaceWithHeron(double a, double b, double c)
    {
        double p = (a + b + c) / 2; // half-perimeter

        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    // Angle has a degree measure. 30 = 30 degrees, 90 = 90 degrees, ...
    public static double GetSurfaceWithAngle(double a, double b, double angleBetweenThem)
    {
        double angle = (angleBetweenThem * Math.PI) / 180;

        return (a * b * Math.Sin(angle)) / 2;
    }

    static void Main(string[] args)
    {
        double a = 3;
        double b = 4;
        double c = 5;

        Console.WriteLine(GetSurfaceWithAltitude(a, b));
        Console.WriteLine(GetSurfaceWithHeron(a, b, c));
        Console.WriteLine(GetSurfaceWithAngle(a, b, 90));
    }
}