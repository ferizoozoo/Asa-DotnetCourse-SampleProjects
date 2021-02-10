﻿using System;
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
        int _specialLadderCount;
        int _specialSnakeCount;

        Dictionary<int, ShortCut> _shortCuts;
        HashSet<int> _cellsUsedForShortCuts;

        Random _random;

        public Board(int height, int width, int ladderCount, int specialLadderCount, int snakeCount, int specialSnakeCount)
        {
            if (height * width < (ladderCount + snakeCount) / 2)
                throw new ArgumentOutOfRangeException("The size of the board and number of the ladders and snakes are not compatible.");

            if (specialLadderCount > ladderCount)
                throw new ArgumentOutOfRangeException("Special ladder cannot be more than total ladders.");

            if (specialSnakeCount > snakeCount)
                throw new ArgumentOutOfRangeException("Special snakes cannot be more than total snakes.");

            Height = height;
            Width = width;
            _ladderCount = ladderCount;
            _specialLadderCount = specialLadderCount;
            _snakeCount = snakeCount;
            _specialSnakeCount = specialSnakeCount;
            _shortCuts = new Dictionary<int, ShortCut>();
            _cellsUsedForShortCuts = new HashSet<int>();
            _random = new Random();

            Initial();
        }

        private void Initial()
        {
            AddShortCut(_snakeCount - _specialSnakeCount, false, IsSnake);
            AddShortCut(_specialSnakeCount, true, IsSnake);
            AddShortCut(_ladderCount - _specialLadderCount, false, IsLadder);
            AddShortCut(_specialLadderCount, true, IsLadder);
        }

        private ShortCut GenerateShortCut(bool isSpecial)
        {
            int start = 1 + _random.Next(100);
            int end = 1 + _random.Next(100);
            return new ShortCut(start, end, isSpecial);
        }

        private delegate bool ShortCutSnakeOrLadder(ShortCut shortCut);
        private bool IsSnake(ShortCut shortCut) => shortCut.Start > shortCut.End;
        private bool IsLadder(ShortCut shortCut) => shortCut.Start < shortCut.End;

        private bool IsLadder(ShortCut shortCut) => shortCut.Start < shortCut.End;

        private void AddShortCut(int count, bool isSpecial, ShortCutSnakeOrLadder snakeOrLadder)
        {
            int shortCutsAdded = 0;
            while (shortCutsAdded < count)
            {
                var shortCut = GenerateShortCut(isSpecial);
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

        public bool CheckSpecialSnake(int position)
        {
            var shortCut = _shortCuts[position];
            if (shortCut.IsSpecial && shortCut.IsSnake)
                return true;
            return false;
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
