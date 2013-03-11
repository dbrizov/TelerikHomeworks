using System;

class HelloName
{
    public static void Hello(string name)
    {
        Console.WriteLine("Hello, {0}", name);
    }

    static void Main(string[] args)
    {
        Hello("Denis");
    }
}