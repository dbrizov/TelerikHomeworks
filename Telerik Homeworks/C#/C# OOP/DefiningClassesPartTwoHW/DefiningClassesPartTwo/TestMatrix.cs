using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    static class TestMatrix
    {
        public static void TestMethod()
        {
            // Test operator + and operator -
            // Make instances
            Console.WriteLine("--Test (+) and (-) operators--");
            Matrix<int> matrix1 = new Matrix<int>(3, 3);
            Matrix<int> matrix2 = new Matrix<int>(3, 3);

            // Fill up the matrices
            for (int i = 0; i < matrix1.RowsCount; i++)
            {
                for (int j = 0; j < matrix1.ColsCount; j++)
                {
                    matrix1[i, j] = i + j;
                    matrix2[i, j] = 1;
                }
            }

            // Print them on the console
            Console.WriteLine(matrix1);
            Console.WriteLine(matrix2);
            Console.WriteLine(new string('-', 20));
            // Print the added ad subtracted matrices
            Console.WriteLine(matrix1 + matrix2);
            Console.WriteLine(matrix1 - matrix2);

            // Test operator *
            Console.WriteLine("--Test (*) operator--");
            Matrix<int> matrix3 = new Matrix<int>(3, 2);
            Matrix<int> matrix4 = new Matrix<int>(2, 3);

            // Fill up the matrices
            int counter = 1;
            for (int i = 0; i < matrix3.RowsCount; i++)
            {
                for (int j = 0; j < matrix3.ColsCount; j++)
                {
                    matrix3[i, j] = counter;
                    counter++;
                }
            }

            counter = 1;
            for (int i = 0; i < matrix4.RowsCount; i++)
            {
                for (int j = 0; j < matrix4.ColsCount; j++)
                {
                    matrix4[i, j] = counter;
                    counter++;
                }
            }

            // Print the two matrices
            Console.WriteLine(matrix3);
            Console.WriteLine(matrix4);
            Console.WriteLine(new string('-', 20));
            // Print the multiplication of matrix3 and matrix4
            // http://www.bluebit.gr/matrix-calculator/matrix_multiplication.aspx
            Console.WriteLine(matrix3 * matrix4);

            // Test operator true
            Console.WriteLine("--Test operator true--");
            if (matrix3)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }

            matrix3[0, 0] = 0;
            if (matrix3)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
