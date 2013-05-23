using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredLoop
{
    public class RefactoredLoop
    {
        public static void Main(string[] args)
        {
            int[] array = new int[100];
            int expectedValue = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(array[i]);

                    if (array[i] == expectedValue)
                    {
                        Console.WriteLine("Value found");
                        break;
                    }
                }
            }

            // More code here
        }
    }
}
