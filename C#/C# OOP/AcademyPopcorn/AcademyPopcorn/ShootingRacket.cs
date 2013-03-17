using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Exercise 13 - Implementation of the ShootingRacket class
    public class ShootingRacket : Racket
    {
        // Fields
        private bool isShootable = false;
        private bool justShooted = false;

        // Properties
        public bool JustShooted
        {
            set
            {
                this.justShooted = value;
            }
        }

        // Constructors
        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
            this.body = new char[1, width + 2];

            this.body[0, 0] = '<';
            this.body[0, width + 1] = '>';

            for (int i = 1; i < width + 1; i++)
            {
                this.body[0, i] = '=';
            }
        }

        // Methods
        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.isShootable && this.justShooted)
            {
                List<GameObject> bullets = new List<GameObject>();

                isShootable = false;
                bullets.Add(new Bullet(this.topLeft));
                bullets.Add(new Bullet(new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col + 1 + this.Width)));

                this.isShootable = false;
                this.justShooted = false;

                return bullets;
            }

            return new List<GameObject>();
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.Contains("gift"))
            {
                this.isShootable = true;
                this.justShooted = false;
            }
        }
    }
}
