using System;
using System.Collections.Generic;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Error;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class TokenHighlightVisitor : ErrorVisitor
    {
        private Dictionary<string, DToken> tokens;
        private Dictionary<string, DHighlightRule> highlight;

        private Dictionary<string, DHighlightRule> styledTokens;

        private DHighlightRule currentRule = null;

        private TokenHighlightVisitor(DeclarationTables declarations, ErrorManager errorManager)
            : base(errorManager)
        {
            this.tokens = declarations.Tokens;
            this.highlight = declarations.HighlightRules;

            this.styledTokens = new Dictionary<string,DHighlightRule>();
        }

        public static void LoadTokenDeclarations(PHighlightrules node, DeclarationTables declarations, ErrorManager errorManager)
        {
            new TokenHighlightVisitor(declarations, errorManager).Visit(node);
        }

        public override void CaseAHighlightrule(AHighlightrule node)
        {
            string text = node.Name.Text;

            DHighlightRule rule = new DHighlightRule(node);
            if (highlight.ContainsKey(text))
                RegisterError(node.Name, "Syntax highlight style {0} has already been defined (line {1}).", node.Name, highlight[text].DeclarationToken.Line);
            else
                highlight.Add(text, rule);
            node.Name.SetDeclaration(highlight[text]);

            currentRule = rule;

            Visit((dynamic)node.Tokens);
        }
        public override void CaseTIdentifier(TIdentifier node)
        {
            if (!tokens.ContainsKey(node.Text))
                RegisterError(node, "The token {0} has not been defined.", node);
            else if (styledTokens.ContainsKey(node.Text))
                RegisterError(node, "The style of {0} has already been defined as {1} (line {2}).", node, styledTokens[node.Text], styledTokens[node.Text].DeclarationToken.Line);
            else
            {
                node.SetDeclaration(tokens[node.Text]);
                styledTokens.Add(node.Text, currentRule);
            }
        }
    }
}
