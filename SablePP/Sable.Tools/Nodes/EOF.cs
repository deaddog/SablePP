using System;

namespace Sable.Tools.Nodes
{
    public class EOF : Token<EOF>
    {
        public EOF()
            : base("")
        {
        }

        public EOF(int line, int pos)
            : base("", line, pos)
        {
        }

        public override EOF Clone()
        {
            return new EOF(Line, Position);
        }
    }
}
