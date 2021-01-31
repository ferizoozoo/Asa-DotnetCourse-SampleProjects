using System;
using System.Collections.Generic;
using System.Text;

namespace LadderAndSnake
{
    public struct ShortCut
    {
        public int Start { get; }
        public int End { get; }

        public ShortCut(int start, int end)
        {
            Start = start;
            End = end;
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
