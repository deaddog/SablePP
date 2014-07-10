using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Nodes.Identifiers
{
    public class TokenIdentifier : TIdentifier
    {
        private AToken token;

        public static TokenIdentifier Replace(TIdentifier identifier, AToken token)
        {
            TokenIdentifier t = new TokenIdentifier(identifier.Text, identifier.Line, identifier.Position, token);
            identifier.ReplaceBy(t);
            return t;
        }

        private TokenIdentifier(string text, int line, int pos, AToken token)
            :base(text, line, pos)
        {
            this.token = token;
        }

        public AToken Declaration
        {
            get { return token; }
        }
    }
}
