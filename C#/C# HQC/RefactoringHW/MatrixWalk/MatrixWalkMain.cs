using System;

namespace MatrixWalk
{
    public class MatrixWalkMain
    {
        public static void Main(string[] args)
        {
            int n = ReadInput();
            int rows = n;
            int cols = n;
            WalkedMatrix matrix = new WalkedMatrix(rows, cols);

            Console.WriteLine(matrix.ToString());
        }

        private static int ReadInput()
        {
            int num = 0;
            while (num == 0 || num < 0 || num > 100)
            {
                Console.Write("Enter a positive number in range [1, 100]: ");
                int.TryParse(Console.ReadLine(), out num);
            }

            Console.WriteLine("You haven't entered a correct positive number");
            return num;
        }
    }
}
