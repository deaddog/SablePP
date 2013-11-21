using System;
using System.Collections.Generic;

using Sable.Compiler.Nodes;
using Sable.Tools.Error;

namespace Sable.Compiler.SymbolLinking
{
    public class IgnoredTokenVisitor : Error.ErrorVisitor
    {
        private Dictionary<string, DToken> tokens;

        private IgnoredTokenVisitor(DeclarationTables declarations, ErrorManager errorManager)
            : base(errorManager)
        {
            this.tokens = declarations.Tokens;
        }

        public static void SetIgnoredTokens(PIgnoredtokens node, DeclarationTables declarations, ErrorManager errorManager)
        {
            new IgnoredTokenVisitor(declarations, errorManager).Visit(node);
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
