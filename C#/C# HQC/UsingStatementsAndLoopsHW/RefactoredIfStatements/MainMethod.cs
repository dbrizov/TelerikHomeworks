using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredIfStatements
{
    public class MainMethod
    {
        // This is need for the first if statement
        public static void Cook(Potato potato)
        {
            // Do Something...
        }

        // This is needed to the second if statement
        public static void VisitCell()
        {
            // Do Something...
        }

        public static void Main(string[] args)
        {
            // The first if statement
            Potato potato = new Potato();

            if (potato != null)
            {
                if (potato.HasBeenPeeled && potato.IsRotten == false)
                {
                    Cook(potato);
                }
            }

            // The second if statemen
            int x = 0;
            int minX = int.MinValue;
            int maxX = int.MaxValue;

            int y = 0;
            int minY = int.MinValue;
            int maxY = int.MaxValue;

            bool shouldVisitCell = true;

            if ((minX <= x && x <= maxX) && 
                (minY <= y && y <= maxY) && 
                shouldVisitCell)
            {
                VisitCell();
            }
        }
    }
}
