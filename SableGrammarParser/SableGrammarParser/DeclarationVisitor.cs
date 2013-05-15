using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser
{
    public class DeclarationVisitor : Error.ErrorVisitor
    {
        private Dictionary<string, Declaration> declarations;

        public static DeclarationVisitor StartNewVisitor(Start startNode)
        {
            DeclarationVisitor visitor = new DeclarationVisitor();
            visitor.StartVisitor(visitor, startNode);
            return visitor;
        }

        protected DeclarationVisitor StartVisitor(DeclarationVisitor visitor, Node node)
        {
            if (this.declarations == null)
                this.declarations = new Dictionary<string, Declaration>();

            visitor.declarations = this.declarations;
            base.StartVisitor(visitor, node);
            return visitor;
        }

        public override void CaseAGrammar(AGrammar node)
        {
            //if (node.GetPackage() != null)
            //    node.GetPackage().Apply(this);

            StartVisitor(new HelperVisitor(), node.GetHelpers());
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

        protected void EnterSymbol(string name, Declaration declaration)
        {
            declarations.Add(name, declaration);
        }

        private class HelperVisitor : DeclarationVisitor
        {
            private Dictionary<string, DHelper> helpers = new Dictionary<string, DHelper>();
            private bool firstRun = true;

            public override void CaseAHelper(AHelper node)
            {
                if (firstRun)
                {
                    DHelper helper = new DHelper(node);
                    helpers.Add(node.GetIdentifier().Text, helper);
                    EnterSymbol(node.GetIdentifier().Text, helper);
                }
                else
                {
                    base.CaseAHelper(node);
                }
            }
            public override void OutAHelpers(AHelpers node)
            {
                if (firstRun)
                {
                    firstRun = false;
                    node.Apply(this);
                }
            }

            public override void CaseTIdentifier(TIdentifier node)
            {
                node.SetDeclaration(helpers[node.Text]);
            }
        }

        private class TokenVisitor : Error.ErrorVisitor
        {
        }
    }
}
