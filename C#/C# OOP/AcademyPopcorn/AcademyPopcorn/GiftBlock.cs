using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Exercise 12 - Implementation of the GiftBlock class
    public class GiftBlock : Block
    {
        // Constructor
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { 'G' } };
        }

        // Methods
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<Gift> gift = new List<Gift>();

            if (this.IsDestroyed)
            {
                gift.Add(new Gift(this.topLeft, new char[,] { { '♥' } }));
            }

            return gift;
        }
    }
}
