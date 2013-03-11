using System;

class GetWorkingDays
{
    public static int CountWorkingDaysFromTodayToSomeDate(DateTime date)
    {
        int counter = 0;

        DateTime[] holidays = { new DateTime(2013, 12, 25), new DateTime(2013, 12, 31) };

        DateTime now = DateTime.Now;
        int period = (date - now).Days + 1;

        for (int i = 1; i <= period; i++)
        {
            if (now.AddDays(i).DayOfWeek != DayOfWeek.Saturday &&
                now.AddDays(i).DayOfWeek != DayOfWeek.Sunday)
            {
                bool isHoliday = false;

                for (int j = 0; j < holidays.Length; j++)
                {
                    if (now.AddDays(i).Year == holidays[j].Year &&
                        now.AddDays(i).Month == holidays[j].Month &&
                        now.AddDays(i).Day == holidays[j].Day)
                    {
                        isHoliday = true;
                        break;
                    }
                }

                if (isHoliday == false)
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    static void Main(string[] args)
    {
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.WriteLine(CountWorkingDaysFromTodayToSomeDate(date));
    }
}