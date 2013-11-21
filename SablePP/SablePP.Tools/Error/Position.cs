using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Error
{
    public struct Position : IComparable<Position>, IEquatable<Position>
    {
        private int lineNumber;
        private int linePosition;

        public Position(int lineNumber, int linePosition)
        {
            this.lineNumber = lineNumber;
            this.linePosition = linePosition;
        }

        public int LineNumber
        {
            get { return lineNumber; }
        }
        public int LinePosition
        {
            get { return linePosition; }
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
            return other.lineNumber != this.lineNumber ? this.lineNumber.CompareTo(other.lineNumber) : this.linePosition.CompareTo(other.linePosition);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Position))
                return false;
            return this.Equals((Position)obj);
        }
        public bool Equals(Position other)
        {
            return this.lineNumber == other.lineNumber && this.linePosition == other.linePosition;
        }

        public override int GetHashCode()
        {
            return lineNumber ^ linePosition;
        }
    }
}
