namespace SnakesAndLadders
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static int RollDice()
        {
            Random randomValue = new Random();
            return randomValue.Next(1, 7);
        }

        public static void Main(string[] args)
        {
            string inputReadFromInputStream;
            Board board = new Board();

            // Take Inputs for snake
            inputReadFromInputStream = Console.ReadLine();
            int numberOfSnakes = Convert.ToInt32(inputReadFromInputStream);

            for(int iterator = 0; iterator < numberOfSnakes; iterator++)
            {
                inputReadFromInputStream = Console.ReadLine();
                string[] tokens = inputReadFromInputStream.Split(' ');
                int head = Convert.ToInt32(tokens[0]);
                int tail = Convert.ToInt32(tokens[1]);
                board.AddSnake(head, tail);
            }

            // Ladder
            inputReadFromInputStream = Console.ReadLine();
            int numberOfLadders = Convert.ToInt32(inputReadFromInputStream);

            for (int iterator = 0; iterator < numberOfLadders; iterator++)
            {
                inputReadFromInputStream = Console.ReadLine();
                string[] tokens = inputReadFromInputStream.Split(' ');
                int tail = Convert.ToInt32(tokens[0]);
                int head = Convert.ToInt32(tokens[1]);
                board.AddLadder(tail, head);
            }

            // Player Input
            inputReadFromInputStream = Console.ReadLine();
            int numberOfPlayers = Convert.ToInt32(inputReadFromInputStream);
            List<Player> players = new List<Player>();

            for (int iterator = 0; iterator < numberOfPlayers; iterator++)
            {
                string playerName = Console.ReadLine();
                Player player = new Player(playerName);
                players.Add(player);
            }

            bool isGameOver = false;

            while (!isGameOver)
            {
                for (int iterator = 0; iterator < numberOfPlayers; iterator++)
                {
                    int diceValue = Program.RollDice();
                    players[iterator].Move(diceValue, board);
                    if (players[iterator].IsWinningMove())
                    {
                        Console.WriteLine("{0} wins the game", players[iterator].name);
                        isGameOver = true;
                        break;
                    }
                }
            }
        }
    }
}
