using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Exercise 8 - Implement the UnpassableBlock
    public class UnpassableBlock : IndestructibleBlock
    {
        // Constructor
        public UnpassableBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { '$' } };
        }
    }
}
