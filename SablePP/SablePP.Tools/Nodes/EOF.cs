using System;

namespace SablePP.Tools.Nodes
{
    /// <summary>
    /// Represents an end-of-file token. The string contained by an <see cref="EOF"/> is always <see cref="String.Empty"/>.
    /// </summary>
    public class EOF : Token<EOF>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EOF"/> class.
        /// </summary>
        public EOF()
            : base("")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EOF"/> class located at a specific line and position.
        /// </summary>
        /// <param name="line">The line (one-based) where the token is located in the source.</param>
        /// <param name="pos">The position (one-based) where the token is located in the source line.</param>
        public EOF(int line, int pos)
            : base("", line, pos)
        {
        }

        /// <summary>
        /// Clones this <see cref="EOF"/> instace and returns the new element.
        /// </summary>
        /// <returns>A new <see cref="EOF"/> token element that is a copy of this instance.</returns>
        public override EOF Clone()
        {
            return new EOF(Line, Position);
        }
    }
}
