using System;

struct Point
{
    public int x;
    public int y;
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

class ShipDamage
{
    static void Main()
    {
        Point s1 = new Point(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        Point s2 = new Point(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        int h = int.Parse(Console.ReadLine());
        Point c1 = new Point(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        Point c2 = new Point(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        Point c3 = new Point(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

        // Find the projectiles coordinates
        c1.y += 2 * (h - c1.y);
        c2.y += 2 * (h - c2.y);
        c3.y += 2 * (h - c3.y);

        int minX = Math.Min(s1.x, s2.x);
        int maxX = Math.Max(s1.x, s2.x);
        int minY = Math.Min(s1.y, s2.y);
        int maxY = Math.Max(s1.y, s2.y);

        int shipLife = 0;

        // corners damage
        if ((c1.x == minX || c1.x == maxX) && (c1.y == minY || c1.y == maxY))
        {
            shipLife -= 25;
        }
        if ((c2.x == minX || c2.x == maxX) && (c2.y == minY || c2.y == maxY))
        {
            shipLife -= 25;
        }
        if ((c3.x == minX || c3.x == maxX) && (c3.y == minY || c3.y == maxY))
        {
            shipLife -= 25;
        }

        // sides damage
        if (((c1.x == minX || c1.x == maxX) && (c1.y > minY && c1.y < maxY)) ||
            ((c1.y == minY || c1.y == maxY) && (c1.x > minX && c1.x < maxX)))
        {
            shipLife -= 50;
        }
        if (((c2.x == minX || c2.x == maxX) && (c2.y > minY && c2.y < maxY)) ||
            ((c2.y == minY || c2.y == maxY) && (c2.x > minX && c2.x < maxX)))
        {
            shipLife -= 50;
        }
        if (((c3.x == minX || c3.x == maxX) && (c3.y > minY && c3.y < maxY)) ||
            ((c3.y == minY || c3.y == maxY) && (c3.x > minX && c3.x < maxX)))
        {
            shipLife -= 50;
        }

        // inner damage
        if ((c1.x > minX) && (c1.x < maxX) && (c1.y > minY) && (c1.y < maxY))
        {
            shipLife -= 100;
        }
        if ((c2.x > minX) && (c2.x < maxX) && (c2.y > minY) && (c2.y < maxY))
        {
            shipLife -= 100;
        }
        if ((c3.x > minX) && (c3.x < maxX) && (c3.y > minY) && (c3.y < maxY))
        {
            shipLife -= 100;
        }

        Console.WriteLine(-shipLife + "%");
    }
}