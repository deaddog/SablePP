using System;
using System.Collections.Generic;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Error;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class TokenVisitor : DeclarationVisitor
    {
        private DeclarationTables.DeclarationTable<DHelper> helpers;
        private DeclarationTables.DeclarationTable<DState> states;
        private DeclarationTables.DeclarationTable<DToken> tokens;

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

            if (!tokens.Declare(node.Identifier))
                RegisterError(node.Identifier, "Token {0} has already been defined (line {1}).", node.Identifier, tokens[node.Identifier].DeclarationToken.Line);

            Visit(node.Regex);
            if (node.HasTokenlookahead)
                Visit(node.Tokenlookahead);
        }

        public override void CaseATokenstateListitem(ATokenstateListitem node)
        {
            if (!states.Link(node.Identifier))
                RegisterError(node.Identifier, "The state {0} has not been defined.", node.Identifier);
        }
        public override void CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node)
        {
            if (!states.Link(node.From))
                RegisterError(node.From, "The state {0} has not been defined.", node.From);
            if (!states.Link(node.To))
                RegisterError(node.To, "The state {0} has not been defined.", node.To);
        }

        public override void CaseTIdentifier(TIdentifier node)
        {
            if (!helpers.Link(node))
                RegisterError(node, "The helper {0} has not been defined.", node);
        }
    }
}
