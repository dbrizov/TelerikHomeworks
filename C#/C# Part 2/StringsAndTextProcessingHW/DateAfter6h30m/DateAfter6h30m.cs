using System;
using System.Globalization;
using System.Threading;

class DateAfter6h30m
{
    static void Main(string[] args)
    {
        CultureInfo culture = new CultureInfo("bg-BG");

        string str = "22.03.2013 10:00:00";
        DateTime date = DateTime.ParseExact(str, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        Console.WriteLine(date);

        date = date.AddHours(6.5);

        Console.WriteLine("{0} {1}", date.ToString("dddd", culture), date);

    }
}