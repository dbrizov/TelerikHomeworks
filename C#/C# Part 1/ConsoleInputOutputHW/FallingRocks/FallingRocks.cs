using System;
using System.Linq;
using System.Threading;

class Coordinate
{
    public int x;
    public int y;
    public Coordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

class FallingRocks
{
    static int sleepTime = 100; // variable for the Thread.Sleep(int)
    static Coordinate right = new Coordinate(1, 0); // right direction
    static Coordinate left = new Coordinate(-1, 0); // left direction
    static Coordinate down = new Coordinate(0, 1); // down direction
    static Coordinate nextPosition = new Coordinate(0, 0); // next position
    static bool positionWasChanged = false; // variable for the dwarfs position change
    static Coordinate[] dwarf = new Coordinate[3]; // implementation of the dwarf
    static char[] rocks = new char[17] { '!', '@', '#', '$', '%', '^', '&', '*', '-', '+', ';', '.', '♠', '♣', '♥', '♦', '=' }; // array of rocks
    static Coordinate[] rockLine1; // implementation of the rock line 1
    static Coordinate[] rockLine2; // implementation of the rock line 2
    static Coordinate[] rockLine3; // implementation of the rock line 3
    static Coordinate[] rockLine4; // implementation of the rock line 4
    static long rockLineCounter1; // these variables help for the different lines displaying
    static long rockLineCounter2; // these variables help for the different lines displaying
    static long rockLineCounter3; // these variables help for the different lines displaying
    static int rocksNumber = 5; // number of rocks which every line has
    static int points = 0; // user points counter
    static int life = 9; // user life points
    static int levelCounter = 0; // counter that helps for the level delay
    static int level = 1; // current level
    static Random randomNumber = new Random(); // random number

    // displays the current life
    static void DisplayLife()
    {
        Console.SetCursorPosition(21, 0);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("♥:" + life);
    }

    // displays the current level
    static void DisplayLevel()
    {
        Console.SetCursorPosition(35, 0);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Level:" + level);
    }

    // displays the user points
    static void DisplayPoints()
    {
        Console.SetCursorPosition(1, 0);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Points:" + points);
    }

    // displays the blue field
    static void DisplayBlueField()
    {
        Console.SetCursorPosition(20, Console.WindowHeight - 1);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("(C) 2012 Denis Rizov All Rights Reserved");

        for (int i = 1; i < Console.WindowWidth - 1; i++)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(i, 1);
            Console.Write("o");
            Console.SetCursorPosition(i, Console.WindowHeight - 2);
            Console.Write("o");
        }
        for (int i = 1; i < Console.WindowHeight - 1; i++)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(1, i);
            Console.Write("o");
            Console.SetCursorPosition(Console.WindowWidth - 2, i);
            Console.Write("o");
        }
    }

    // displays the dwarf
    static void DisplayDwarf()
    {

        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(dwarf[i].x, dwarf[i].y);
            Console.ForegroundColor = ConsoleColor.White;
            if (i == 0)
            {
                Console.Write("(");
            }
            if (i == 1)
            {
                Console.Write("O");
            }
            if (i == 2)
            {
                Console.Write(")");
            }
        }
    }

    // this function doesn't allow the dwarf to go out of the blue field
    static void CheckDwarfPosition()
    {
        if (dwarf[0].x < 2)
        {
            dwarf[0].x = 2;
            dwarf[1].x = 3;
            dwarf[2].x = 4;
        }
        if (dwarf[2].x > Console.WindowWidth - 3)
        {
            dwarf[2].x = Console.WindowWidth - 3;
            dwarf[1].x = Console.WindowWidth - 4;
            dwarf[0].x = Console.WindowWidth - 5;
        }
    }

    // generates random rock lines with specified number of rocks
    static void GenerateRockLines(int numberOfRocks)
    {
        // rockLine1 starting coordinates
        rockLineCounter1 = 0;
        rockLineCounter2 = 0;
        rockLineCounter3 = 0;
        rockLine1 = new Coordinate[numberOfRocks];
        rockLine2 = new Coordinate[numberOfRocks];
        rockLine3 = new Coordinate[numberOfRocks];
        rockLine4 = new Coordinate[numberOfRocks];
        for (int i = 0; i < numberOfRocks; i++)
        {
            rockLine1[i] = new Coordinate(randomNumber.Next(2, Console.WindowWidth - 2), 2); // rockLine1 starting coordinates
            rockLine2[i] = new Coordinate(randomNumber.Next(2, Console.WindowWidth - 2), 2); // rockLine2 starting coordinates
            rockLine3[i] = new Coordinate(randomNumber.Next(2, Console.WindowWidth - 2), 2); // rockLine3 starting coordinates
            rockLine4[i] = new Coordinate(randomNumber.Next(2, Console.WindowWidth - 2), 2); // rockLine4 starting coordinates
        }
    }

    // displays rockLine1
    static void DisplayRockLine1()
    {
        for (int i = 0; i < rocksNumber; i++)
        {
            Console.SetCursorPosition(rockLine1[i].x, rockLine1[i].y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(rocks[i]);
        }
    }

    // displays rockLine2
    static void DisplayRockLine2()
    {
        for (int i = 0; i < rocksNumber; i++)
        {
            Console.SetCursorPosition(rockLine2[i].x, rockLine2[i].y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(rocks[i]);
        }
    }

    // displays rockLine3
    static void DisplayRockLine3()
    {
        for (int i = 0; i < rocksNumber; i++)
        {
            Console.SetCursorPosition(rockLine3[i].x, rockLine3[i].y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(rocks[i]);
        }
    }

    // displays rockLine4
    static void DisplayRockLine4()
    {
        for (int i = 0; i < rocksNumber; i++)
        {
            Console.SetCursorPosition(rockLine4[i].x, rockLine4[i].y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(rocks[i]);
        }
    }

    // teleports each rock line back to the top if the bottom is reached and counts the user points
    static void CheckRocksPosition()
    {
        if (rockLine1[0].y > Console.WindowHeight - 3)
        {
            for (int i = 0; i < rocksNumber; i++)
            {
                rockLine1[i] = new Coordinate(randomNumber.Next(2, Console.WindowWidth - 2), 2);
                rockLine1[i].y = 2;
            }
            points += level * 10;
        }
        if (rockLine2[0].y > Console.WindowHeight - 3)
        {
            for (int i = 0; i < rocksNumber; i++)
            {
                rockLine2[i] = new Coordinate(randomNumber.Next(2, Console.WindowWidth - 2), 2);
                rockLine2[i].y = 2;
            }
            points += level * 10;
        }
        if (rockLine3[0].y > Console.WindowHeight - 3)
        {
            for (int i = 0; i < rocksNumber; i++)
            {
                rockLine3[i] = new Coordinate(randomNumber.Next(2, Console.WindowWidth - 2), 2);
                rockLine3[i].y = 2;
            }
            points += level * 10;
        }
        if (rockLine4[0].y > Console.WindowHeight - 3)
        {
            for (int i = 0; i < rocksNumber; i++)
            {
                rockLine4[i] = new Coordinate(randomNumber.Next(2, Console.WindowWidth - 2), 2);
                rockLine4[i].y = 2;
            }
            points += level * 10;
        }
    }
    
    // checks if the GAME IS OVER and paints the dwarfs parts in red on impact
    static bool GameOver()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < rocksNumber; j++)
            {
                if ((dwarf[i].y == rockLine1[j].y && dwarf[i].x == rockLine1[j].x) ||
                    (dwarf[i].y == rockLine2[j].y && dwarf[i].x == rockLine2[j].x) ||
                    (dwarf[i].y == rockLine3[j].y && dwarf[i].x == rockLine3[j].x) ||
                    (dwarf[i].y == rockLine4[j].y && dwarf[i].x == rockLine4[j].x))
                {
                    life--;
                    Console.SetCursorPosition(dwarf[i].x, dwarf[i].y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (i == 0)
                    {
                        Console.Write("(");
                    }
                    if (i == 1)
                    {
                        Console.Write("O");
                    }
                    if (i == 2)
                    {
                        Console.Write(")");
                    }
                    if (life == 0)
                    {
                        DisplayLife();
                        return (true);
                    }
                }
            }
        }
        DisplayLife();
        return (false);
    }
    
    // checks if the game ended
    static bool EndOfGame()
    {
        if (level == 13)
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }
    
    static void Main()
    {
        DisplayBlueField();

        // dwarfs starting coordinates
        for (int i = 0; i < 3; i++)
        {
            dwarf[i] = new Coordinate(i + 37, Console.WindowHeight - 3);
        }

        GenerateRockLines(rocksNumber);

        while (true)
        {
            DisplayLevel();

            DisplayPoints();

            CheckDwarfPosition();

            DisplayDwarf();

            DisplayRockLine1();

            // changes the dwarfs position
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInput = Console.ReadKey(true);
                if (keyInput.Key == ConsoleKey.RightArrow)
                {
                    nextPosition = right;
                    positionWasChanged = true;
                }
                if (keyInput.Key == ConsoleKey.LeftArrow)
                {
                    nextPosition = left;
                    positionWasChanged = true;
                }
            }

            // cleans the key buffer
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            // moves the dwarf to the next position if the position was changed by the player
            if (positionWasChanged == true)
            {
                if (nextPosition.x == right.x && nextPosition.y == right.y)
                {
                    Console.SetCursorPosition(dwarf[0].x, dwarf[0].y);
                    Console.Write(" ");
                    for (int i = 0; i < 3; i++)
                    {
                        dwarf[i].x += right.x;
                        dwarf[i].y += right.y;
                    }

                    CheckDwarfPosition();

                    DisplayDwarf();
                }
                if (nextPosition.x == left.x && nextPosition.y == left.y)
                {
                    Console.SetCursorPosition(dwarf[2].x, dwarf[2].y);
                    Console.Write(" ");
                    for (int i = 0; i < 3; i++)
                    {
                        dwarf[i].x += left.x;
                        dwarf[i].y += left.y;
                    }

                    CheckDwarfPosition();

                    DisplayDwarf();
                }
                positionWasChanged = false;
            }

            // moves rockLine1 by 1 step down
            for (int i = 0; i < rocksNumber; i++)
            {
                Console.SetCursorPosition(rockLine1[i].x, rockLine1[i].y);
                Console.Write(" ");
                rockLine1[i].y += down.y;
            }

            CheckRocksPosition();
            DisplayRockLine1();
            rockLineCounter1++; // rockLine1 was displayed(moved) 1, 2, ... times

            // starts the displaying(moving) of rockLine2 if rockLine1 was moved 6 times (we have 5 empty rows between the lines
            if (rockLineCounter1 == 6)
            {
                for (int i = 0; i < rocksNumber; i++)
                {
                    Console.SetCursorPosition(rockLine2[i].x, rockLine2[i].y);
                    Console.Write(" ");
                    rockLine2[i].y += down.y;
                }

                CheckRocksPosition();
                DisplayRockLine2();
                rockLineCounter1 = 5; // the displaying of rockLine1 will make rockLineCounter1 == 6 and 
                                      // rockLine2 will continue to be displayed and moved because rockLineCounter1 == 5 again
                rockLineCounter2++; // rockLine2 was displayed(moved) once
            }

            if (rockLineCounter2 == 6)
            {
                for (int i = 0; i < rocksNumber; i++)
                {
                    Console.SetCursorPosition(rockLine3[i].x, rockLine3[i].y);
                    Console.Write(" ");
                    rockLine3[i].y += down.y;
                }

                CheckRocksPosition();
                DisplayRockLine3();
                rockLineCounter2 = 5;
                rockLineCounter3++;
            }

            if (rockLineCounter3 == 6)
            {
                for (int i = 0; i < rocksNumber; i++)
                {
                    Console.SetCursorPosition(rockLine4[i].x, rockLine4[i].y);
                    Console.Write(" ");
                    rockLine4[i].y += down.y;
                }

                CheckRocksPosition();
                DisplayRockLine4();
                rockLineCounter3 = 5;
            }

            // levelCounter is increased by 1 every 100 millisecnds, by 10 every second, by 300 for every 30 seconds
            // NOTE* - the time between levels becomes shorter when the game speed rises
            levelCounter++;
            if (levelCounter % 300 == 0)
            {
                rocksNumber++; // plus 1 rock
                GenerateRockLines(rocksNumber); // generates the new lines with the new number of rocks
                sleepTime -= 5; // game speed increases
                level++; // next level

                Console.Clear(); // clears the old rocks and everything
                DisplayBlueField(); // displays the blue field again, because it was cleared just a millisecond ago
            }

            // displays "GAME OVER!" if the game is over
            if (GameOver() == true)
            {
                Console.SetCursorPosition(35, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("GAME OVER!");
                Thread.Sleep(2000);
                Console.SetCursorPosition(28, 11);
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
                return;
            }

            // displays "YOU WIN" if you are the winner
            if (EndOfGame() == true)
            {
                Console.SetCursorPosition(35, 10);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("CONGRATULATIONS");
                Console.SetCursorPosition(39, 10);
                Console.Write("YOU WIN!");
                Thread.Sleep(2000);
                Console.SetCursorPosition(28, 11);
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
                return;
            }

            Thread.Sleep(sleepTime); // sets the game speed
        }
    }
}
