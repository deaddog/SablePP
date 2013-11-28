using System;
using System.Collections.Generic;

using SablePP.Tools.Error;

namespace SablePP.Compiler.Validation
{
    public class SyntaxHighlightValidator : Error.ErrorVisitor
    {
        public SyntaxHighlightValidator(ErrorManager manager)
            : base(manager)
        {
        }

        public override void CaseAGrammar(Nodes.AGrammar node)
        {
            if (node.HasHighlightrules)
                Visit((dynamic)node.Highlightrules);
        }

        public override void CaseAHighlightrule(Nodes.AHighlightrule node)
        {
            base.CaseAHighlightrule(node);
        }
    }
}
