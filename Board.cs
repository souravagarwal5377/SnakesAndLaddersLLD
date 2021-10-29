namespace SnakesAndLadders
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Board
    {
        List<int> snakeHeads;
        List<int> snakeTails;
        List<int> ladderHeads;
        List<int> ladderTails;

        public Board()
        {
            snakeHeads = new List<int>();
            snakeTails = new List<int>();
            ladderHeads = new List<int>();
            ladderTails = new List<int>();
        }

        public void AddSnake(int head, int tail)
        {
            snakeHeads.Add(head);
            snakeTails.Add(tail);
        }

        public void AddLadder(int tail, int head)
        {
            ladderHeads.Add(head);
            ladderTails.Add(tail);
        }

        public bool IsLadder(int position)
        {
            if (ladderTails.Contains(position))
            {
                return true;
            }

            return false;
        }

        public bool IsSnake(int position)
        {
            if (snakeHeads.Contains(position))
            {
                return true;
            }

            return false;
        }

        public int GetNewPositionAfterClimibingLadder(int playerPosition)
        {
            int indexOfPositionInLadderArray = ladderTails.IndexOf(playerPosition);
            return ladderHeads[indexOfPositionInLadderArray];
        }

        public int GetNewPositionAfterFallingBySnake(int playerPosition)
        {
            int indexOfPositionInSnakeArray = snakeHeads.IndexOf(playerPosition);
            return snakeTails[indexOfPositionInSnakeArray];
        }
    }
}
