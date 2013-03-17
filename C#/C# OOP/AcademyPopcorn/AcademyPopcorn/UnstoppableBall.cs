using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Exercise 8 - Implement UnstoppableBall class
    public class UnstoppableBall : Ball
    {
        public new const string CollisionGroupString = "unstoppable ball";

        // Constructors
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = new char[,] { { 'O' } };
        }

        // Methods
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "indestructible block" || otherCollisionGroupString == "racket" ||
                otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings.Contains("indestructible block") ||
                collisionData.hitObjectsCollisionGroupStrings.Contains("racket"))
            {
                base.RespondToCollision(collisionData);
            }
        }
    }
}
