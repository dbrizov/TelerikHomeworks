using System;

class IsoscelesTriangle
{
    static void Main()
    {
        string str =        @" 
                               {0,3}
                             {0,3} {0,3}
                           {0,3}     {0,3}
                         {0,3}         {0,3}
                       {0,3}             {0,3}
                     {0,3}                 {0,3}
                   {0,3}                     {0,3}
                 {0,3}{0,3}{0,3}{0,3}{0,3} {0,3}{0,3}{0,3}{0,3}{0,3}";
        Console.WriteLine(str, (char)0x00A9);
    }
}
