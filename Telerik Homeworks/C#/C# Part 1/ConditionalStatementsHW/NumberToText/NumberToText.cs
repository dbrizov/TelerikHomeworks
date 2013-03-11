using System;

class NumberToText
{
    static void Main()
    {
        string[] str1 = {"zero", "one", "two", "three", "four", 
                            "five", "six", "seven", "eight", "nine"};

        string[] str2 = {"eleven", "twelve", "thirteen", "fourteen", "fifteen",
                            "sixteen", "seventeen", "eighteen", "nineteen"};

        string[] str3 = {"ten", "twenty", "thirty", "fourty", "fifty", "sixty",
                            "seventy", "eighty", "ninety"};

        Console.Write("Input number [0, 999]: ");
        int number = int.Parse(Console.ReadLine());
        int copyOfNumber = number;

        if (number == 0)
        {
            Console.WriteLine(str1[0]);
        }

        int[] digits = new int[3];
        int digitsCounter = 0;

        while (copyOfNumber != 0)
        {
            digits[digitsCounter] = copyOfNumber % 10;
            copyOfNumber = copyOfNumber / 10;
            digitsCounter++;
        }

        if (digitsCounter == 1)
        {
            Console.WriteLine(str1[number]);
        }
        else if (digitsCounter == 2 && number >= 11 && number <= 19)
        {
            Console.WriteLine(str2[number - 11]);
        }
        else if (digitsCounter == 2 && (number == 10 || number > 19))
        {
            if (digits[0] == 0)
            {
                Console.WriteLine(str3[digits[1] - 1]);
            }
            else
            {
                Console.WriteLine(str3[digits[1] - 1] + " " + str1[digits[0]]);
            }
        }
        else if (digitsCounter == 3)
        {
            if (digits[0] == 0 && digits[1] == 0)
            {
                Console.WriteLine(str1[digits[2]] + " hundred");
            }
            else
            {
                if (digits[1] == 0)
                {
                    Console.WriteLine(str1[digits[2]] + " hundred and " + str1[digits[0]]);
                }
                else if (digits[1] == 1 && digits[0] != 0)
                {
                    Console.WriteLine(str1[digits[2]] + " hundred and " + str2[digits[0] - 1]);
                }
                else if (digits[1] > 1 && digits[0] == 0)
                {
                    Console.WriteLine(str1[digits[2]] + " hundred and " + str3[digits[1] - 1]);
                }
                else if (digits[1] > 1 && digits[0] != 0)
                {
                    Console.WriteLine(str1[digits[2]] + " hundred and " + str3[digits[1] - 1] + " " + str1[digits[0]]);
                }
            }
        }
    }
}
