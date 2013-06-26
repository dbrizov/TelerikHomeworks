using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PathExistance.Tests
{
    [TestClass]
    public class LabyrinthTests
    {
        [TestMethod]
        public void TestPathExist()
        {
            char[,] matrix = new char[100, 100];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = '-';
                }
            }

            Labyrinth lab = new Labyrinth(matrix);
            lab.SetStartCell(0, 0);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    lab.SetEndCell(i, j);
                    Assert.IsTrue(lab.ExistsPathBetweenTheStartAndEndCells());
                }
            }
        }
    }
}
