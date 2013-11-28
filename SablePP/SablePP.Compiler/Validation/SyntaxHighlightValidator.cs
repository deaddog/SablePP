using System;
using System.Collections.Generic;

using SablePP.Tools.Error;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Validation
{
    public class SyntaxHighlightValidator : Error.ErrorVisitor
    {
        public SyntaxHighlightValidator(ErrorManager manager)
            : base(manager)
        {
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasHighlightrules)
                Visit((dynamic)node.Highlightrules);
        }

        public override void CaseAHighlightrule(AHighlightrule node)
        {
            bold = null;
            italic = null;
            text = null;
            background = null;

            base.CaseAHighlightrule(node);
        }

        private ABoldHighlightStyle bold = null;
        private AItalicHighlightStyle italic = null;
        private ATextHighlightStyle text = null;
        private ABackgroundHighlightStyle background = null;

        public override void CaseABoldHighlightStyle(ABoldHighlightStyle node)
        {
            bold = node;
            base.CaseABoldHighlightStyle(node);
        }
        public override void CaseAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            italic = node;
            base.CaseAItalicHighlightStyle(node);
        }
        public override void CaseATextHighlightStyle(ATextHighlightStyle node)
        {
            text = node;
            base.CaseATextHighlightStyle(node);
        }
        public override void CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            background = node;
            base.CaseABackgroundHighlightStyle(node);
        }
    }
}
