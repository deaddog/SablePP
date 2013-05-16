using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
{
    public class DeclarationVisitor : Error.ErrorVisitor
    {
        public static DeclarationVisitor StartNewVisitor(Start startNode)
        {
            DeclarationVisitor visitor = new DeclarationVisitor();
            visitor.StartVisitor(visitor, startNode);
            return visitor;
        }

        public override void CaseAGrammar(AGrammar node)
        {
            //if (node.GetPackage() != null)
            //    node.GetPackage().Apply(this);

            Dictionary<string, DHelper> helpers = new Dictionary<string, DHelper>();
            if (node.GetHelpers() != null)
                helpers = StartVisitor(new HelperVisitor(), node.GetHelpers()).GetHelpers();

            Dictionary<string, DState> states = new Dictionary<string, DState>();
            if (node.GetStates() != null)
                states = StartVisitor(new StateVisitor(), node.GetStates()).GetStates();

            Dictionary<string, DToken> tokens = new Dictionary<string, DToken>();
            if (node.GetTokens() != null)
                tokens = StartVisitor(new TokenVisitor(helpers, states), node.GetTokens()).GetTokens();

            //if (node.GetIgnoredtokens() != null)
            //    node.GetIgnoredtokens().Apply(this);

            //if (node.GetProductions() != null)
            //    node.GetProductions().Apply(this);

            //if (node.GetAstproductions() != null)
            //    node.GetAstproductions().Apply(this);
        }
    }
}
