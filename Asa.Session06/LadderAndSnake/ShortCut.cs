using System;
using System.Collections.Generic;
using System.Text;

namespace LadderAndSnake
{
    public class ShortCut
    {
        public int Start { get; }
        public int End { get; }
        public bool IsSnake => Start > End;
        public bool IsLadder => Start < End;
        public bool IsSpecial { get; }

        public ShortCut(int start, int end, bool isSpecial)
        {
            Start = start;
            End = end;
            IsSpecial = isSpecial;

            if (IsLadder && IsSpecial)
                End = 100;
        }

        public override bool Equals(object obj)
        {
            return obj is ShortCut cut &&
                   Start == cut.Start &&
                   End == cut.End;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }
    }
}
