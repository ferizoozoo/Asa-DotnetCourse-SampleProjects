using System;
using System.Collections.Generic;
using System.Text;

namespace LadderAndSnake
{
    class Board
    {
        public int Heigth { get; }
        public int Width { get; }
        public int ExitPint => Heigth * Width;

        int _ladderCount;
        int _SnakeCount;
        List<ShortCut> _shortCuts;// this data structure is not performant in term of time and space complexity
        public Board(int heigth, int width, int ladderCount, int snakeCount)
        {
            Heigth = heigth;
            Width = width;
            _ladderCount = ladderCount;
            _SnakeCount = snakeCount;
            if (Heigth * width < (_ladderCount + snakeCount) / 2)
            {
                throw new ArgumentOutOfRangeException("The size of the board and number of the ladders and snakes are not compatible.");
            }
            _shortCuts = new List<ShortCut>();
            Initial();
        }

        private void Initial()
        {
            AddSnake();
            AddLAdder();
        }

        private void AddSnake()
        {
            for (int i = 0; i < _SnakeCount; i++)
            {
                //Implement
            }
        }

        private void AddLAdder()
        {
            for (int i = 0; i < _SnakeCount; i++)
            {
                //Implement
            }
        }

        internal int CalculateNextPostion(int position, int diceValue)
        {
            throw new NotImplementedException();
        }

        internal BoardDataDto GetData()
        {
            throw new NotImplementedException();
        }
    }
}
