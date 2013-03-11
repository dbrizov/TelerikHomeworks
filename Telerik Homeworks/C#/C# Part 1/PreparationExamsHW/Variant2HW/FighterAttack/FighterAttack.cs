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

class FighterAttack
{
    static void Main()
    {
        int totalDamage = 0;

        // read the input
        Point p1 = new Point(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        Point p2 = new Point(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        Point f = new Point(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        int d = int.Parse(Console.ReadLine());

        // calculating the missiles (projectiles) coordinates;
        Point left = new Point(f.x + d, f.y + 1);
        Point right = new Point(f.x + d, f.y - 1);
        Point front = new Point(f.x + d + 1, f.y);
        Point middle = new Point(f.x + d, f.y);

        // calculating the Rectangles sides coordinates
        int minX = Math.Min(p1.x, p2.x);
        int maxX = Math.Max(p1.x, p2.x);
        int minY = Math.Min(p1.y, p2.y);
        int maxY = Math.Max(p1.y, p2.y);

        // calculating the totalDamage
        if (left.x <= maxX && left.x >= minX && left.y <= maxY && left.y >= minY)
        {
            totalDamage += 50;
        }
        if (right.x <= maxX && right.x >= minX && right.y <= maxY && right.y >= minY)
        {
            totalDamage += 50;
        }
        if (front.x <= maxX && front.x >= minX && front.y <= maxY && front.y >= minY)
        {
            totalDamage += 75;
        }
        if (middle.x <= maxX && middle.x >= minX && middle.y <= maxY && middle.y >= minY)
        {
            totalDamage += 100;
        }

        Console.WriteLine(totalDamage + "%");
    }
}