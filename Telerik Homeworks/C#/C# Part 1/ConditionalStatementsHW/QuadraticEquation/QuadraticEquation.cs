using System;

namespace QuadraticEquation
{
    class QuadraticEquation
    {
        static void Main()
        {
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            string A;
            string B;
            string C;

            if (a != 0)
            {
                if (a > 0)
                {
                    A = "+" + a + "*x^2";
                }
                else
                {
                    A = a + "*x^2";
                }
            }
            else
            {
                A = "";
            }

            if (b != 0)
            {
                if (b > 0)
                {
                    B = "+" + b + "*x";
                }
                else
                {
                    B = b + "*x";
                }
            }
            else
            {
                B = "";
            }

            if (c != 0)
            {
                if (c > 0)
                {
                    C = "+" + c;
                }
                else
                {
                    C = Convert.ToString(c);
                }
            }
            else
            {
                C = "";
            }

            Console.WriteLine(A + B + C + "=0");

            if (a != 0)
            {
                double D = b * b - 4 * a * c;

                if (D > 0)
                {
                    double x1 = ((-b) + Math.Sqrt(D)) / (2 * a);
                    double x2 = ((-b) - Math.Sqrt(D)) / (2 * a);

                    Console.WriteLine("x1 = " + x1);
                    Console.WriteLine("x2 = " + x2);
                }
                else if (D == 0)
                {
                    double x1 = (-b) / (2 * a);

                    Console.WriteLine("x1 = x2 = " + x1);
                }
                else if (D < 0)
                {
                    Console.WriteLine("No real roots exist!");
                }
            }

            else if (a == 0)
            {
                if (b != 0)
                {
                    double x = (-c) / b;
                    Console.WriteLine(x);
                }
                else if (b == 0 && c != 0)
                {
                    Console.WriteLine("No real roots exist!");
                }
            }

            if (a == 0 && b == 0 && c == 0)
            {
                Console.WriteLine("every single \"x\" is a root");
            }
        }
    }
}
