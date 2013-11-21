using System;
using System.Collections.Generic;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Error;

namespace SablePP.Compiler.SymbolLinking
{
    public class TokenVisitor : DeclarationVisitor
    {
        private Dictionary<string, DHelper> helpers;
        private Dictionary<string, DState> states;
        private Dictionary<string, DToken> tokens;
        
        private TokenVisitor(DeclarationTables declarations, ErrorManager errorManager)
            : base(errorManager)
        {
            this.helpers = declarations.Helpers;
            this.states = declarations.States;
            this.tokens = declarations.Tokens;
        }

        public static void LoadTokenDeclarations(PTokens node, DeclarationTables declarations, ErrorManager errorManager)
        {
            new TokenVisitor(declarations, errorManager).Visit(node);
        }

        public override void CaseAToken(AToken node)
        {
            if (node.HasStatelist)
                Visit(node.Statelist);

            string text = node.Identifier.Text;

            DToken token = new DToken(node);
            if (tokens.ContainsKey(text))
                RegisterError(node.Identifier, "Token {0} has already been defined (line {1}).", node.Identifier, tokens[text].DeclarationToken.Line);
            else
                tokens.Add(text, token);
            node.Identifier.SetDeclaration(tokens[text]);

            Visit(node.Regex);
            if (node.HasTokenlookahead)
                Visit(node.Tokenlookahead);
        }

        public override void CaseATokenstateListitem(ATokenstateListitem node)
        {
            DState state = null;
            if (states.TryGetValue(node.Identifier.Text, out state))
                node.Identifier.SetDeclaration(state);
            else
                RegisterError(node.Identifier, "The state {0} has not been defined.", node.Identifier);
        }
        public override void CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node)
        {
            {
                DState state = null;
                if (states.TryGetValue(node.From.Text, out state))
                    node.From.SetDeclaration(state);
                else
                    RegisterError(node.From, "The state {0} has not been defined.", node.From);
            }
            {
                DState state = null;
                if (states.TryGetValue(node.To.Text, out state))
                    node.To.SetDeclaration(state);
                else
                    RegisterError(node.To, "The state {0} has not been defined.", node.To);
            }
        }

        public override void CaseTIdentifier(TIdentifier node)
        {
            DHelper helper = null;
            if (helpers.TryGetValue(node.Text, out helper))
                node.SetDeclaration(helper);
            else
                RegisterError(node, "The helper {0} has not been defined.", node);
        }
    }
}
