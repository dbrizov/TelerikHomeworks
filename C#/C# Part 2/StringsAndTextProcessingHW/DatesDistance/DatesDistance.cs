using System;
using System.Globalization;
using System.Threading;

class DatesDistance
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        Console.Write("1th date: ");
        DateTime firstDate = DateTime.Parse(Console.ReadLine());

        Console.Write("2nd date: ");
        DateTime secondDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Distance: {0}", (secondDate - firstDate).Days);
    }
}