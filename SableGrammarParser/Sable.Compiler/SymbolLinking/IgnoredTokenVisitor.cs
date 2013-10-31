using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sable.Compiler.Nodes;

namespace Sable.Compiler.SymbolLinking
{
    public class IgnoredTokenVisitor : Error.ErrorVisitor
    {
        private Dictionary<string, DToken> tokens;

        public IgnoredTokenVisitor(IEnumerable<KeyValuePair<string, DToken>> tokens)
        {
            this.tokens = new Dictionary<string, DToken>();
            foreach (var v in tokens)
                this.tokens.Add(v.Key, v.Value);
        }

        public override void CaseTIdentifier(TIdentifier node)
        {
            DToken token = null;
            if (tokens.TryGetValue(node.Text, out token))
            {
                node.SetDeclaration(token);
                token.Ignored = true;
            }
            else
                RegisterError(node, "The token {0} has not been defined.", node);
        }
    }
}
