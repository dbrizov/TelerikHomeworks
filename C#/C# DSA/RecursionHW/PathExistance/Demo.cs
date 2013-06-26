using System;

namespace PathExistance
{
    public class Demo
    {
        public static void Main(string[] args)
        {
            // Demo
            char[,] labyrinth = 
            {
                {'-', '-', '-', '*', '-', '-', '-'},
                {'*', '*', '*', '*', '-', '*', '-'},
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

            bool pathExists = lab.ExistsPathBetweenTheStartAndEndCells();
            Console.WriteLine("A path exists between these two cells: {0}", pathExists);
        }
    }
}
