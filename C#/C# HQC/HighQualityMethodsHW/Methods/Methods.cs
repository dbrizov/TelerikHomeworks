using System;

namespace Methods
{
    public class Methods
    {
        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            bool sidesCanFormATriagle =
                (sideA + sideB > sideC) &&
                (sideB + sideC > sideA) &&
                (sideA + sideC > sideB);

            if (!sidesCanFormATriagle)
            {
                throw new ArgumentException("The given sides cannot form a triangle");
            }

            double semiperimeter = (sideA + sideB + sideC) / 2;
            double area = 
                Math.Sqrt(semiperimeter * (semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC)); // Heron's theorem

            return area;
        }

        public static string GetDigitEnglishWord(int digit)
        {
            string result = string.Empty;

            switch (digit)
            {
                case 0:
                    result = "zero";
                    break;
                case 1:
                    result = "one";
                    break;
                case 2:
                    result = "two";
                    break;
                case 3:
                    result = "three";
                    break;
                case 4:
                    result = "four";
                    break;
                case 5:
                    result = "five";
                    break;
                case 6:
                    result = "six";
                    break;
                case 7:
                    result = "seven";
                    break;
                case 8:
                    result = "eight";
                    break;
                case 9:
                    result = "nine";
                    break;
                default:
                    throw new ArgumentException("The input must be a digit from 0 to 9");
            }

            return result;
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("The input array of elements is null");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("The input array is empty");
            }

            int maxElement = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (maxElement < elements[i])
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static void PrintFormatNumber(object number, string format)
        {
            if (number == null)
            {
                throw new ArgumentNullException("the given number is null");
            }

            if (format == null)
            {
                throw new ArgumentNullException("The given format string is null");
            }

            if (number is IFormattable == false)
            {
                throw new ArgumentException("The given number is not a number");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p}", number);
            }
            else
            {
                throw new ArgumentException("The given format string is not correct format string");
            }
        }

        public static double CalculatePointsDistance(
            double x1, double y1, double x2, double y2)
        {
            double deltaX = x2 - x1;
            double deltaY = y2 - y1;

            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
            return distance;
        }

        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(GetDigitEnglishWord(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintFormatNumber(1.3, "f");
            PrintFormatNumber(0.75, "%");

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName, 
                stella.FirstName, 
                peter.IsOlderThan(stella));
        }
    }
}
