using System;

namespace UsersChoiceInput
{
    class UsersChoiceInput
    {
        static void Main()
        {
            Console.Write("1 - int, 2 - double, 3 - string: ");
            byte choice = byte.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("i= ");
                    int i = int.Parse(Console.ReadLine());
                    i++;
                    Console.WriteLine(i);
                    break;
                case 2:
                    Console.Write("d= ");
                    double d = double.Parse(Console.ReadLine());
                    d++;
                    Console.WriteLine(d);
                    break;
                case 3:
                    Console.Write("s= ");
                    string s = Console.ReadLine();
                    s += "*";
                    Console.WriteLine(s);
                    break;
                default:
                    Console.WriteLine("Wrong input!");
                    break;
            }
        }
    }
}
