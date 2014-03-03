using System;
using System.Collections.Generic;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Error;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class IgnoredTokenVisitor : ErrorVisitor
    {
        private DeclarationTables.DeclarationTable<DToken> tokens;

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
            if (!tokens.Link(node))
                RegisterError(node, "The token {0} has not been defined.", node);
        }
    }
}
