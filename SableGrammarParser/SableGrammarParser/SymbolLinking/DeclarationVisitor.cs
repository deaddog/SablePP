using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
{
    public class DeclarationVisitor : Error.ErrorVisitor
    {
        private bool testing;
        private bool alllinked;

        public bool AllLinked
        {
            get { return alllinked; }
        }

        protected DeclarationVisitor()
        {
            this.testing = false;
            this.alllinked = true;
        }

        public static DeclarationVisitor StartNewVisitor(Start startNode)
        {
            DeclarationVisitor visitor = new DeclarationVisitor();
            visitor.StartVisitor(visitor, startNode);
            return visitor;
        }

        public override void OutStart(Start node)
        {
            base.OutStart(node);
            if (!testing)
            {
                testing = true;
                node.Apply(this);
            }
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (testing)
            {
                base.CaseAGrammar(node);
                return;
            }

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

            if (node.GetIgnoredtokens() != null)
                StartVisitor(new IgnoredTokenVisitor(tokens), node.GetIgnoredtokens());

            Dictionary<string, DProduction> astProductions = new Dictionary<string, DProduction>();
            if (node.GetAstproductions() != null)
                StartVisitor(new ASTVisitor(tokens), node.GetAstproductions());

            Dictionary<string, DProduction> productions = new Dictionary<string, DProduction>();
            if (node.GetProductions() != null)
                productions = StartVisitor(new ProductionVisitor(tokens), node.GetProductions()).GetProductions();
        }

        public override void CaseTIdentifier(TIdentifier node)
        {
            if (testing && !node.HasDeclaration)
                alllinked = false;
        }
    }
}
