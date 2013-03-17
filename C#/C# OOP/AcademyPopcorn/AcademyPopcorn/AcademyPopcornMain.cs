using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;
        const int GameSleepTime = 100;
        const int TrailLifeTime = 3;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            // Exercise 1 - add side walls and ceiling wall
            for (int col = 0; col < WorldCols; col++)
            {
                Block indestructibleBlock = new IndestructibleBlock(new MatrixCoords(0, col));

                engine.AddObject(indestructibleBlock);
            }

            // Exercise 5 - TrailObject test
            //TrailObject trailObject = new TrailObject(new MatrixCoords(10, 15), LifeTime);
            //engine.AddObject(trailObject);

            // Exercise 7 - Replace the normal ball with a meteorite ball
            //Ball meteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1), TrailLifeTime);

            //engine.AddObject(meteoriteBall);

            // Exercise 9 - Test the UnstoppableBall and the UnpassableBlock
            //for (int i = startCol; i < endCol / 2; i++)
            //{
            //    Block currBlock = new UnpassableBlock(new MatrixCoords(startRow + 1, i));

            //    engine.AddObject(currBlock);
            //}

            //Ball ustoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            //engine.AddObject(ustoppableBall);

            // Exercise 10 - Test the Explosion and the ExplosionBlock
            //Block explosionBlock = new ExplosionBlock(new MatrixCoords(startRow + 1, 7));
            //engine.AddObject(explosionBlock);

            //for (int i = endCol / 2; i < endCol; i++)
            //{
            //    Block expBlock = new ExplosionBlock(new MatrixCoords(startRow + 1, i));
            //    engine.AddObject(expBlock);
            //}

            // Exercise 12 - Test the GiftBlock and the Gift
            //for (int i = startCol; i < endCol; i++)
            //{
            //    Block giftBlock = new GiftBlock(new MatrixCoords(startRow + 1, i));

            //    engine.AddObject(giftBlock);
            //}

            // Exercise 13 - Shooting racket test
            for (int i = startCol; i < endCol; i++)
            {
                Block giftBlock = new GiftBlock(new MatrixCoords(startRow + 1, i));

                engine.AddObject(giftBlock);
            }

            Racket theRacket = new ShootingRacket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            for (int row = 0; row < WorldRows; row++)
            {
                Block indestructibleBlock = new IndestructibleBlock(new MatrixCoords(row, 0));

                engine.AddObject(indestructibleBlock);

                indestructibleBlock = new IndestructibleBlock(new MatrixCoords(row, WorldCols - 1));

                engine.AddObject(indestructibleBlock);
            }
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            // Exercise 13 - using the new Engine
            Engine gameEngine = new EngineSecondVersion(renderer, keyboard, GameSleepTime);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            // Exercise 13 - Implemetation of the OnActionPressed
            keyboard.OnActionPressed += (sender, evenInfo) =>
            {
                if (gameEngine is EngineSecondVersion)
                {
                    ((EngineSecondVersion)gameEngine).ShootPlayerRacket();
                }
            };

            Initialize(gameEngine);

            gameEngine.Run();
        }
    }
}
