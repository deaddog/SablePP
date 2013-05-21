using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sable.Compiler.node;

namespace Sable.Compiler.SymbolLinking
{
    public class DeclarationVisitor : Error.ErrorVisitor
    {
        public override void OutStart(Start node)
        {
            base.OutStart(node);
            var unlinked = StartVisitor(new LINKTEST(), node).Unlinked;
            if (unlinked.Length > 0)
            {
                Console.WriteLine("Unlinked identifiers:");
                for (int i = 0; i < unlinked.Length; i++)
                    Console.WriteLine("{0} (line {1})", unlinked[i], unlinked[i].Line);
                Console.ReadKey(true);
            }
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.GetPackage() != null)
                node.GetPackage().Apply(this);

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

            if (node.GetProductions() != null)
                StartVisitor(new ProductionVisitor(tokens), node.GetProductions());

            Dictionary<string, DProduction> astProductions = new Dictionary<string, DProduction>();
            if (node.GetAstproductions() != null)
                astProductions = StartVisitor(new ProductionVisitor(tokens), node.GetAstproductions()).GetProductions();

            if (node.GetProductions() != null)
                StartVisitor(new TranslationVisitor(astProductions), node.GetProductions());
        }

        private class LINKTEST : Error.ErrorVisitor
        {
            private List<TIdentifier> unlinked;
            public TIdentifier[] Unlinked
            {
                get { return unlinked.ToArray(); }
            }

            public LINKTEST()
            {
                this.unlinked = new List<TIdentifier>();
            }

            public override void CaseTIdentifier(TIdentifier node)
            {
                if (!node.HasDeclaration)
                    unlinked.Add(node);
            }
        }
    }
}
