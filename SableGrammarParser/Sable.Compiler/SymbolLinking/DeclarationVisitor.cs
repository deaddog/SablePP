using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sable.Compiler.Nodes;
using Sable.Tools.Nodes;

namespace Sable.Compiler.SymbolLinking
{
    public class DeclarationVisitor : Error.ErrorVisitor
    {
        public override void OutStart(Start<PGrammar> node)
        {
            base.OutStart(node);
            var unlinked = StartVisitor(new LINKTEST(), node).Unlinked;

            for (int i = 0; i < unlinked.Length; i++)
                RegisterError(unlinked[i], "Identifier \"" + unlinked[i].Text + "\" could not be linked to a declaration.");
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            Dictionary<string, DHelper> helpers = new Dictionary<string, DHelper>();
            if(node.HasHelpers)
                helpers = StartVisitor(new HelperVisitor(), node.Helpers).GetHelpers();

            Dictionary<string, DState> states = new Dictionary<string, DState>();
            if (node.HasStates)
                states = StartVisitor(new StateVisitor(), node.States).GetStates();

            Dictionary<string, DToken> tokens = new Dictionary<string, DToken>();
            if (node.HasTokens)
                tokens = StartVisitor(new TokenVisitor(helpers, states), node.Tokens).GetTokens();

            if (node.HasIgnoredtokens)
                StartVisitor(new IgnoredTokenVisitor(tokens), node.Ignoredtokens);

            if (node.HasProductions)
                StartVisitor(new ProductionVisitor(tokens), node.Productions);

            Dictionary<string, DProduction> astProductions = new Dictionary<string, DProduction>();
            if (node.HasAstproductions)
                astProductions = StartVisitor(new ProductionVisitor(tokens), node.Astproductions).GetProductions();

            if (node.HasProductions)
                StartVisitor(new TranslationVisitor(astProductions), node.Productions);
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
