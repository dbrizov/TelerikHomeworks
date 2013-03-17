using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // Exercise 6 - Implement the meteorite ball
    public class MeteoriteBall : Ball
    {
        // Field
        int trailLifeTime;

        // Constructor
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed, int trailLifeTime)
            : base(topLeft, speed)
        {
            this.trailLifeTime = trailLifeTime;
        }

        public override void Update()
        {
            this.TopLeft += this.Speed;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrailObject> trail = new List<TrailObject>();
            trail.Add(new TrailObject(this.TopLeft, this.trailLifeTime));

            return trail;
        }
    }
}
