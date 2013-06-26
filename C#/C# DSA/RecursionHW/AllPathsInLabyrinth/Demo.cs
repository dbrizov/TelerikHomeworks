using System;
using System.Collections.Generic;

namespace AllPathsInLabyrinth
{
    public class Demo
    {
        public static void Main(string[] args)
        {
            // Demo
            char[,] labyrinth = 
            {
                {'-', '-', '-', '*', '-', '-', '-'},
                {'*', '*', '-', '*', '-', '*', '-'},
                {'-', '-', '-', '-', '-', '-', '-'},
                {'-', '*', '*', '*', '*', '*', '-'},
                {'-', '-', '-', '-', '-', '-', '-'},
            };

            Labyrinth lab = new Labyrinth(labyrinth);
            Console.WriteLine(lab);

            Console.Write("start cell row = ");
            int startCellRow = int.Parse(Console.ReadLine());
            Console.Write("start cell col = ");
            int startCellCol = int.Parse(Console.ReadLine());
            lab.SetStartCell(startCellRow, startCellCol);

            Console.Write("end cell row = ");
            int endCellRow = int.Parse(Console.ReadLine());
            Console.Write("end cell col = ");
            int endCellCol = int.Parse(Console.ReadLine());
            lab.SetEndCell(endCellRow, endCellCol);

            Console.WriteLine("\n" + lab);

            var allPaths = lab.FindAllPathBetweenTheStartAndEndCell();
            foreach (var path in allPaths)
            {
                PrintMatrix(path);
            }
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 3}", matrix[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
