using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Error
{
    public struct Position : IComparable<Position>, IEquatable<Position>
    {
        private int line;
        private int position;

        public Position(int line, int position)
        {
            if (line < 0)
                line = 0;
            if (position < 0)
                position = 0;

            this.line = line;
            this.position = position;
        }

        public int Line
        {
            get { return line; }
        }
        public int Character
        {
            get { return position; }
        }

        public static bool operator ==(Position p1, Position p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator !=(Position p1, Position p2)
        {
            return !p1.Equals(p2);
        }

        public int CompareTo(Position other)
        {
            return other.line != this.line ? this.line.CompareTo(other.line) : this.position.CompareTo(other.position);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Position))
                return false;
            return this.Equals((Position)obj);
        }
        public bool Equals(Position other)
        {
            return this.line == other.line && this.position == other.position;
        }

        public override int GetHashCode()
        {
            return line ^ position;
        }
    }
}
