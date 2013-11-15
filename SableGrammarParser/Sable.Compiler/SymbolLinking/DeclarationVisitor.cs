using System;
using System.Collections.Generic;

using Sable.Compiler.Nodes;

using Sable.Tools.Error;

namespace Sable.Compiler.SymbolLinking
{
    public class DeclarationVisitor : Error.ErrorVisitor
    {
        public DeclarationVisitor(ErrorManager errorManager)
            : base(errorManager)
        {
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            Dictionary<string, DHelper> helpers = new Dictionary<string, DHelper>();
            if (node.HasHelpers)
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
    }
}
