using System;
using System.Collections.Generic;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Error;

namespace SablePP.Compiler.SymbolLinking
{
    public class TokenHighlightVisitor : Error.ErrorVisitor
    {
        private TokenHighlightVisitor(DeclarationTables declarations, ErrorManager errorManager)
            : base(errorManager)
        {
        }

        public static void LoadTokenDeclarations(PHighlightrules node, DeclarationTables declarations, ErrorManager errorManager)
        {
            new TokenHighlightVisitor(declarations, errorManager).Visit(node);
        }
    }
}
