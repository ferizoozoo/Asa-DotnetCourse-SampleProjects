using System;
using System.Collections.Generic;
using System.Text;

namespace LadderAndSnake
{
    public struct MoveResult
    {
        public MoveResult(string name, ColorEnum color, int oldPosition, int newPosition, int diceValue)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Color = color;
            OldPosition = oldPosition;
            NewPosition = newPosition;
            DiceValue = diceValue;
            IsWinner = false;
        }
        public bool IsWinner{ get; set; }
        public string Name { get; private  set; }
        public ColorEnum Color { get; private set; }
        public int OldPosition { get; private set; }
        public int NewPosition { get; private set; }
        public int DiceValue { get; }
    }
}
