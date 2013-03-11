using System;

class AstrologicalDigits
{
    static void Main()
    {
        int digitsSum = 0;
        string number = Console.ReadLine();
        int numberLength = number.Length;

        for (int i = 0; i < numberLength; i++)
        {
            switch (number[i])
            {
                case '1':
                    digitsSum += 1;
                    break;
                case '2':
                    digitsSum += 2;
                    break;
                case '3':
                    digitsSum += 3;
                    break;
                case '4':
                    digitsSum += 4;
                    break;
                case '5':
                    digitsSum += 5;
                    break;
                case '6':
                    digitsSum += 6;
                    break;
                case '7':
                    digitsSum += 7;
                    break;
                case '8':
                    digitsSum += 8;
                    break;
                case '9':
                    digitsSum += 9;
                    break;
                default:
                    digitsSum += 0;
                    break;
            }
        }

        while (digitsSum > 9)
        {
            int nextDigitsSum = 0;
            while (digitsSum != 0)
            {
                nextDigitsSum += digitsSum % 10;
                digitsSum /= 10;
            }
            digitsSum = nextDigitsSum;
        }

        Console.WriteLine(digitsSum);
    }
}