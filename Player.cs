namespace SnakesAndLadders
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Player
    {
        public int currentPosition;
        public string name;

        public Player(string name)
        {
            this.name = name;
            this.currentPosition = 0;
        }

        public void Move(int diceValue, Board board)
        {
            int oldPosition = currentPosition;
            int newExpectedPosition = currentPosition + diceValue;
            if (IsValidMove(newExpectedPosition))
            {
                currentPosition = newExpectedPosition;

                if (board.IsLadder(currentPosition))
                {
                    currentPosition = board.GetNewPositionAfterClimibingLadder(currentPosition);
                }
                else if (board.IsSnake(currentPosition))
                {
                    currentPosition = board.GetNewPositionAfterFallingBySnake(currentPosition);
                }
            }

            PrintMovement(oldPosition, currentPosition, diceValue);
        }

        public void PrintMovement(int oldPosition, int newPosition, int diceValue)
        {
            if (oldPosition != newPosition)
            {
                Console.WriteLine("{0} rolled a {1} and moved from {2} to {3}", this.name, diceValue, oldPosition, newPosition);
            }
        }

        public bool IsWinningMove()
        {
            if (currentPosition == 100)
                return true;
            return false;
        }

        private bool IsValidMove(int position)
        {
            return position > 100 ? false : true;
        }
    }
}
