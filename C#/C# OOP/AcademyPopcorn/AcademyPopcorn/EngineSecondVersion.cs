using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Exercise 4 - Inherit the Engine class
    public class EngineSecondVersion : Engine
    {
        public EngineSecondVersion(IRenderer renderer, IUserInterface userInterface, int gameSleepTime)
            : base(renderer, userInterface, gameSleepTime)
        {
        }

        // Exercise 13 - Implementation of the ShootPlayerRacket method
        public virtual void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).JustShooted = true;
            }
        }
    }
}
