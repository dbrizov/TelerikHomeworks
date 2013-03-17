using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Exercise 10 - Implement the ExplosionBlock
    public class ExplosionBlock : Block
    {
        // Constructor
        public ExplosionBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { 'E' } };
        }

        // Methods
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();

            if (this.IsDestroyed)
            {
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { '*' } }, new MatrixCoords(-1, 0)));
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { '*' } }, new MatrixCoords(1, 0)));
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { '*' } }, new MatrixCoords(0, 1)));
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { '*' } }, new MatrixCoords(0, -1)));
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { '*' } }, new MatrixCoords(1, 1)));
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { '*' } }, new MatrixCoords(1, -1)));
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { '*' } }, new MatrixCoords(-1, 1)));
                produceObjects.Add(new Explosion(this.topLeft, new char[,] { { '*' } }, new MatrixCoords(-1, -1)));
            }

            return produceObjects;
        }
    }
}
