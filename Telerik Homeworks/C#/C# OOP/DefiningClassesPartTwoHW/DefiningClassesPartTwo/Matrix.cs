using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    // Exercise 8 - define class Matrix<T>
    public class Matrix<T>
    {
        // Fields
        private T[,] twoDimentionalArray;
        private int rowsCount;
        private int colsCount;

        // Constructors
        public Matrix(int rowsCount, int colsCount)
        {
            twoDimentionalArray = new T[rowsCount, colsCount];
            this.rowsCount = rowsCount;
            this.colsCount = colsCount;
        }

        // Properties
        public T[,] TwoDimentionalArray
        {
            get
            {
                return this.twoDimentionalArray;
            }
        }

        public int RowsCount
        {
            get
            {
                return this.rowsCount;
            }
        }

        public int ColsCount
        {
            get
            {
                return this.colsCount;
            }
        }

        // Exercise 9 - this[int row, int col] indexer implementation
        public T this[int row, int col]
        {
            get
            {
                return this.twoDimentionalArray[row, col];
            }
            set
            {
                this.twoDimentionalArray[row, col] = value;
            }
        }

        // Exercise 10 - operator +, -, * overloadings
        // Operator +
        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.rowsCount == matrix2.rowsCount &&
                matrix1.colsCount == matrix2.colsCount)
            {
                Matrix<T> result = new Matrix<T>(matrix1.rowsCount, matrix1.colsCount);

                for (int row = 0; row < matrix1.rowsCount; row++)
                {
                    for (int col = 0; col < matrix1.colsCount; col++)
                    {
                        result.twoDimentionalArray[row, col] =
                            (dynamic)matrix1[row, col] + (dynamic)matrix2[row, col];
                    }
                }

                return result;
            }
            else
            {
                throw new FormatException("Operator + can't be applied to matrices that have different dimentions");
            }
        }

        // Operator -
        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.rowsCount == matrix2.rowsCount &&
                matrix1.colsCount == matrix2.colsCount)
            {
                Matrix<T> result = new Matrix<T>(matrix1.rowsCount, matrix1.colsCount);

                for (int row = 0; row < matrix1.rowsCount; row++)
                {
                    for (int col = 0; col < matrix1.colsCount; col++)
                    {
                        result.twoDimentionalArray[row, col] =
                            (dynamic)matrix1[row, col] - (dynamic)matrix2[row, col];
                    }
                }

                return result;
            }
            else
            {
                throw new FormatException("Operator + can't be applied to matrices that have different dimentions");
            }
        }

        // Operator *
        public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1.colsCount == matrix2.rowsCount)
            {
                Matrix<T> result = new Matrix<T>(matrix1.rowsCount, matrix2.colsCount);

                for (int row = 0; row < result.rowsCount; row++)
                {
                    for (int col = 0; col < result.colsCount; col++)
                    {
                        for (int i = 0; i < matrix1.colsCount; i++)
                        {
                            result[row, col] += (dynamic)matrix1[row, i] * (dynamic)matrix2[i, col];
                        }
                    }
                }

                return result;
            }
            else
            {
                throw new FormatException("Can't multiply matrices with incorect dimentions");
            }
        }

        // Exercise 11 - operator true
        public static bool operator true(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.RowsCount; i++)
            {
                for (int j = 0; j < matrix.ColsCount; j++)
                {
                    if ((dynamic)matrix[i, j] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.RowsCount; i++)
            {
                for (int j = 0; j < matrix.ColsCount; j++)
                {
                    if ((dynamic)matrix[i, j] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // Methods
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.rowsCount; row++)
            {
                for (int col = 0; col < this.colsCount; col++)
                {
                    result.Append(string.Format("{0, -5}", twoDimentionalArray[row, col]));
                }

                result.Append("\n");
            }

            return result.ToString();
        }
    }
}
