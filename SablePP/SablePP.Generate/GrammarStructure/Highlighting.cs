using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SablePP.Generate
{
    public class Highlighting : GrammarPart
    {
        private Token[] tokens;
        private Color? foreground, background;
        private bool italic, bold;

        public Highlighting(IEnumerable<Token> tokens, bool italic, bool bold, Color? foreground, Color? background)
        {
            this.tokens = tokens.ToArray();
            this.italic = italic;
            this.bold = bold;
            this.foreground = foreground;
            this.background = background;
        }

        internal override bool canBeParent(GrammarPart part)
        {
            return part is Grammar;
        }
        public Grammar Parent
        {
            get { return base.parent as Grammar; }
        }

        public Token[] Tokens
        {
            get { return tokens; }
        }

        public Color? Foreground
        {
            get { return foreground; }
        }
        public Color? Background
        {
            get { return background; }
        }

        public bool Italic
        {
            get { return italic; }
        }
        public bool Bold
        {
            get { return bold; }
        }
    }
}
