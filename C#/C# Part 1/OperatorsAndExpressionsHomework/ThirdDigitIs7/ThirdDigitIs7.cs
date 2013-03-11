using System;

class ThirdDigitIs7
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        if (number / 100 > 0)
        {
            if (number / 100 % 10 == 7)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
        else
        {
            Console.WriteLine("Invalid number!");
        }
   }
}
