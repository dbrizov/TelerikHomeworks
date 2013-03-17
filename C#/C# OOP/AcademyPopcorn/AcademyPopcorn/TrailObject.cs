using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Exrecise 5 - Implement a TrailObject class
    public class TrailObject : GameObject
    {
        // Fields
        private int lifeTime;

        // Constructor
        public TrailObject(MatrixCoords topLeft, int lifeTime)
            : base(topLeft, new char[,] { { '.' } })
        {
            this.lifeTime = lifeTime;
        }

        // Methods
        public override void Update()
        {
            this.lifeTime--;

            if (lifeTime == 0)
            {
                this.IsDestroyed = true;
            }
        }

        public override char[,] GetImage()
        {
            return (char[,])this.body.Clone();
        }
    }
}
