using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser
{
    public class DeclarationVisitor : Error.ErrorVisitor
    {
        private Dictionary<string, Helper> helpers = new Dictionary<string, Helper>();

        public DeclarationVisitor()
        {
        }

        public static DeclarationVisitor StartNewVisitor(Start startNode)
        {
            DeclarationVisitor visitor = new DeclarationVisitor();
            visitor.StartVisitor(visitor, startNode);
            return visitor;
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.GetPackage() != null)
                node.GetPackage().Apply(this);

            //if (node.GetHelpers() != null)
            //    node.GetHelpers().Apply(this);

            //if (node.GetStates() != null)
            //    node.GetStates().Apply(this);

            //if (node.GetTokens() != null)
            //    node.GetTokens().Apply(this);

            //if (node.GetIgnoredtokens() != null)
            //    node.GetIgnoredtokens().Apply(this);

            //if (node.GetProductions() != null)
            //    node.GetProductions().Apply(this);

            //if (node.GetAstproductions() != null)
            //    node.GetAstproductions().Apply(this);
        }
    }
}
