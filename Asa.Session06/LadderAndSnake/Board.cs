using System;
using System.Collections.Generic;
using System.Text;

namespace LadderAndSnake
{
    public class Board
    {
        public int Height { get; }
        public int Width { get; }
        public int ExitPoint => Height * Width;

        int _ladderCount;
        int _snakeCount;

        Dictionary<int, ShortCut> _shortCuts;
        HashSet<int> _cellsUsedForShortCuts;

        Random _random;

        public Board(int height, int width, int ladderCount, int snakeCount)
        {
            if (height * width < (ladderCount + snakeCount) / 2)
                throw new ArgumentOutOfRangeException("The size of the board and number of the ladders and snakes are not compatible.");

            Height = height;
            Width = width;
            _ladderCount = ladderCount;
            _snakeCount = snakeCount;
            _shortCuts = new Dictionary<int, ShortCut>();
            _cellsUsedForShortCuts = new HashSet<int>();
            _random = new Random();

            Initial();
        }

        private void Initial()
        {
            AddShortCut(_snakeCount, IsSnake);
            AddShortCut(_ladderCount, IsLadder);
        }

        private ShortCut GenerateShortCut()
        {
            int start = 1 + _random.Next(100);
            int end = 1 + _random.Next(100);
            return new ShortCut(start, end);
        }

        private delegate bool ShortCutSnakeOrLadder(ShortCut shortCut);

        private bool IsSnake(ShortCut shortCut) => shortCut.Start > shortCut.End;

        private bool IsLadder(ShortCut shortCut) => shortCut.Start < shortCut.End;

        private void AddShortCut(int count, ShortCutSnakeOrLadder snakeOrLadder)
        {
            int shortCutsAdded = 0;
            while (shortCutsAdded <= count)
            {
                var shortCut = GenerateShortCut();
                if (snakeOrLadder(shortCut) && IsShortCutValid(shortCut))
                {
                    // Add the cells used for shortcuts
                    _cellsUsedForShortCuts.Add(shortCut.Start);
                    _cellsUsedForShortCuts.Add(shortCut.End);

                    // Add the shortcut to the shortcuts
                    _shortCuts.Add(shortCut.Start, shortCut);
                    shortCutsAdded++;
                }  
            }
        }

        private bool IsShortCutValid(ShortCut shortCut)
        {
            if (_cellsUsedForShortCuts.Contains(shortCut.Start) || _cellsUsedForShortCuts.Contains(shortCut.End))
                return false;
            return true;
        }

        public int CalculateNextPosition(int position, int diceValue)
        {
            int newPosition = position + diceValue;

            if (_shortCuts.ContainsKey(newPosition))
                newPosition = _shortCuts[newPosition].End;

            if (newPosition > 100)
                newPosition = 0;

            if (newPosition < 0)
                throw new ArgumentOutOfRangeException("New position cannot be below zero.");

            return newPosition;
        }

        internal BoardDataDto GetData()
        {
            var boardData = new BoardDataDto
            {
                Height = this.Height,
                Width = this.Width
            };

            return boardData;
        }
    }
}
