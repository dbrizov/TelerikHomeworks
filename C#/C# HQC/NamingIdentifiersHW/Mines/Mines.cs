using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mines
{
    public class Mines
    {
        public static void Main(string[] args)
        {
            const int MAX_EMPTY_CELLS_COUNT = 35;

            string command = string.Empty;
            char[,] playField = CreatePlayField();
            char[,] bombs = PlaceBombs();
            int pointsCount = 0;
            bool gameOver = false;
            List<Player> topPlayers = new List<Player>(6);
            int row = 0;
            int column = 0;
            bool newGameHasStarted = true;
            bool foundAllCells = false;

            do
            {
                if (newGameHasStarted)
                {
                    Console.WriteLine("Lets play \"Mines\". Try your luck to find the cells without mines." +
                    " The command 'top' shows the ranking, 'restart' begind a new game, 'exit' exits the game!");
                    DisplayPlayField(playField);
                    newGameHasStarted = false;
                }

                Console.Write("Give a row and a column : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= playField.GetLength(0) && column <= playField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowRankingTable(topPlayers);
                        break;
                    case "restart":
                        playField = CreatePlayField();
                        bombs = PlaceBombs();
                        DisplayPlayField(playField);
                        gameOver = false;
                        newGameHasStarted = false;
                        break;
                    case "exit":
                        Console.WriteLine("bye, bye...");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                InputNextTurn(playField, bombs, row, column);
                                pointsCount++;
                            }

                            if (MAX_EMPTY_CELLS_COUNT == pointsCount)
                            {
                                foundAllCells = true;
                            }
                            else
                            {
                                DisplayPlayField(playField);
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command\n");
                        break;
                }

                if (gameOver)
                {
                    DisplayPlayField(bombs);
                    Console.Write(
                        "\nHrrrrrr! You died heroicly with {0} points. " +
                        "Give a Nickname: ",
                        pointsCount);
                    string nickname = Console.ReadLine();
                    Player t = new Player(nickname, pointsCount);
                    if (topPlayers.Count < 5)
                    {
                        topPlayers.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            if (topPlayers[i].Points < t.Points)
                            {
                                topPlayers.Insert(i, t);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    topPlayers.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    topPlayers.Sort((Player firstPlayer, Player secondPlayer) => secondPlayer.Points.CompareTo(firstPlayer.Points));
                    ShowRankingTable(topPlayers);

                    playField = CreatePlayField();
                    bombs = PlaceBombs();
                    pointsCount = 0;
                    gameOver = false;
                    newGameHasStarted = true;
                }

                if (foundAllCells)
                {
                    Console.WriteLine("\nBRAVOOOS! You found 35 cells without a blood drop.");
                    DisplayPlayField(bombs);
                    Console.WriteLine("Give me your nickname, dude: ");
                    string nickname = Console.ReadLine();
                    Player player = new Player(nickname, pointsCount);
                    topPlayers.Add(player);
                    ShowRankingTable(topPlayers);

                    playField = CreatePlayField();
                    bombs = PlaceBombs();
                    pointsCount = 0;
                    foundAllCells = false;
                    newGameHasStarted = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void ShowRankingTable(List<Player> players)
        {
            Console.WriteLine("\nScore:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} cells",
                        i + 1, 
                        players[i].Name,
                        players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty!\n");
            }
        }

        private static void InputNextTurn(char[,] field, char[,] bombs, int row, int column)
        {
            char bombsCount = GetTotalBombsCount(bombs, row, column);
            bombs[row, column] = bombsCount;
            field[row, column] = bombsCount;
        }

        private static void DisplayPlayField(char[,] board)
        {
            int boardRows = board.GetLength(0);
            int boardColumns = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardRows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < boardColumns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.WriteLine("|");
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] playField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    playField[i, j] = '-';
                }
            }

            List<int> bombMap = new List<int>();
            while (bombMap.Count < 15)
            {
                Random random = new Random();
                int randomLocation = random.Next(50);
                if (!bombMap.Contains(randomLocation))
                {
                    bombMap.Add(randomLocation);
                }
            }

            foreach (int bombLocation in bombMap)
            {
                int column = bombLocation / columns;
                int row = bombLocation % columns;
                if (row == 0 && bombLocation != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                playField[column, row - 1] = '*';
            }

            return playField;
        }

        private static void GetNearbyBombsCount(char[,] field)
        {
            int column = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char bombsCount = GetTotalBombsCount(field, i, j);
                        field[i, j] = bombsCount;
                    }
                }
            }
        }

        private static char GetTotalBombsCount(char[,] field, int rows, int columns)
        {
            int totalBombsCount = 0;
            int rowsCount = field.GetLength(0);
            int colsCount = field.GetLength(1);

            if (rows - 1 >= 0)
            {
                if (field[rows - 1, columns] == '*')
                {
                    totalBombsCount++;
                }
            }

            if (rows + 1 < rowsCount)
            {
                if (field[rows + 1, columns] == '*')
                {
                    totalBombsCount++;
                }
            }

            if (columns - 1 >= 0)
            {
                if (field[rows, columns - 1] == '*')
                {
                    totalBombsCount++;
                }
            }

            if (columns + 1 < colsCount)
            {
                if (field[rows, columns + 1] == '*')
                {
                    totalBombsCount++;
                }
            }

            if ((rows - 1 >= 0) && (columns - 1 >= 0))
            {
                if (field[rows - 1, columns - 1] == '*')
                {
                    totalBombsCount++;
                }
            }

            if ((rows - 1 >= 0) && (columns + 1 < colsCount))
            {
                if (field[rows - 1, columns + 1] == '*')
                {
                    totalBombsCount++;
                }
            }

            if ((rows + 1 < rowsCount) && (columns - 1 >= 0))
            {
                if (field[rows + 1, columns - 1] == '*')
                {
                    totalBombsCount++;
                }
            }

            if ((rows + 1 < rowsCount) && (columns + 1 < colsCount))
            {
                if (field[rows + 1, columns + 1] == '*')
                {
                    totalBombsCount++;
                }
            }

            return char.Parse(totalBombsCount.ToString());
        }

        public class Player
        {
            private string name;
            private int points;

            public Player()
            {
            }

            public Player(string name, int points)
            {
                this.name = name;
                this.points = points;
            }

            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            public int Points
            {
                get
                {
                    return this.points;
                }

                set
                {
                    this.points = value;
                }
            }
        }
    }
}