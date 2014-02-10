using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Tools.Error
{
    /// <summary>
    /// Represents a point-in-code by its line number and character position.
    /// </summary>
    public struct Position : IComparable<Position>, IEquatable<Position>
    {
        private int line;
        private int position;

        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> struct with the specified location.
        /// </summary>
        /// <param name="line">The line number (one-based).</param>
        /// <param name="position">The character position (one-based) in the line.</param>
        public Position(int line, int position)
        {
            if (line < 0)
                line = 0;
            if (position < 0)
                position = 0;

            this.line = line;
            this.position = position;
        }

        /// <summary>
        /// Gets the line number (one-based) associated with this <see cref="Position"/>.
        /// </summary>
        public int Line
        {
            get { return line; }
        }
        /// <summary>
        /// Gets the character position (one-based) in the line.
        /// </summary>
        public int Character
        {
            get { return position; }
        }

        /// <summary>
        /// Compares two <see cref="Position"/>s for equality.
        /// </summary>
        /// <param name="p1">The first <see cref="Position"/> argument.</param>
        /// <param name="p2">The second <see cref="Position"/> argument.</param>
        /// <returns><c>true</c>, if <paramref name="p1"/> and <paramref name="p2"/> refer to equal <see cref="Position"/>s; otherwise, false.</returns>
        public static bool operator ==(Position p1, Position p2)
        {
            return p1.Equals(p2);
        }
        /// <summary>
        /// Compares two <see cref="Position"/>s for inequality.
        /// </summary>
        /// <param name="p1">The first <see cref="Position"/> argument.</param>
        /// <param name="p2">The second <see cref="Position"/> argument.</param>
        /// <returns><c>true</c>, if <paramref name="p1"/> and <paramref name="p2"/> do not refer to equal <see cref="Position"/>s; otherwise, false.</returns>
        public static bool operator !=(Position p1, Position p2)
        {
            return !p1.Equals(p2);
        }

        /// <summary>
        /// Compares the current <see cref="Position"/> with another <see cref="Position"/> instance to determine which is first/last.
        /// </summary>
        /// <param name="other">A <see cref="Position"/> to compare with this <see cref="Position"/>.</param>
        /// <returns>
        /// A value that indicates the relative order of <see cref="Position"/> instances. The return value has the following meanings:
        /// Less than zero; This <see cref="Position"/> is located before the <paramref name="other"/> parameter.
        /// Zero; This <see cref="Position"/> is equal to <paramref name="other"/>.
        /// Greater than zero; This <see cref="Position"/> is located later than the <paramref name="other"/>.
        /// </returns>
        public int CompareTo(Position other)
        {
            return other.line != this.line ? this.line.CompareTo(other.line) : this.position.CompareTo(other.position);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/>, is equal to this <see cref="Position"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this <see cref="Position"/>.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this <see cref="Position"/>; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Position))
                return false;
            return this.Equals((Position)obj);
        }
        /// <summary>
        /// Indicates whether this <see cref="Position"/> is equal to another <see cref="Position"/>.
        /// </summary>
        /// <param name="other">A <see cref="Position"/> instance to compare with this <see cref="Position"/>.</param>
        /// <returns>
        /// <c>true</c>, if this <see cref="Position"/> is equal to the <paramref name="other" /> parameter; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Position other)
        {
            return this.line == other.line && this.position == other.position;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return line ^ position;
        }
    }
}
