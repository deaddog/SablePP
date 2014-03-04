using System;
using System.Collections.Generic;

using SablePP.Compiler.Nodes;

using SablePP.Tools.Error;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class DeclarationVisitor : ErrorVisitor
    {
        public DeclarationVisitor(ErrorManager errorManager)
            : base(errorManager)
        {
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            DeclarationTables declarations = new DeclarationTables();

            if (node.HasHelpers)
                HelperVisitor.LoadHelperDeclarations(node.Helpers, declarations, this.ErrorManager);

            if (node.HasStates)
                StateVisitor.LoadStateDeclarations(node.States, declarations, this.ErrorManager);

            if (node.HasTokens)
                TokenVisitor.LoadTokenDeclarations(node.Tokens, declarations, this.ErrorManager);

            if (node.HasIgnoredtokens)
                IgnoredTokenVisitor.SetIgnoredTokens(node.Ignoredtokens, declarations, this.ErrorManager);

            if (node.HasProductions)
                ProductionVisitor.LoadProductionDeclarations(node.Productions, declarations, this.ErrorManager);

            if (node.HasAstproductions)
                ProductionVisitor.LoadProductionDeclarations(node.Astproductions, declarations, this.ErrorManager);

            if (node.HasProductions)
                TranslationVisitor.SetIdentifiersInTranslations(node.Productions, declarations, this.ErrorManager);

            if (node.HasHighlightrules)
                TokenHighlightVisitor.LoadTokenDeclarations(node.Highlightrules, declarations, this.ErrorManager);

            foreach (var h in declarations.Helpers.NonLinked)
                RegisterWarning(h.DeclarationToken, "The helper '{0}' is never used in a helper or token definition.", h.DeclarationToken.Text);

            foreach (var s in declarations.States.NonLinked)
                RegisterWarning(s.DeclarationToken, "The state '{0}' is never used.", s.DeclarationToken.Text);

            foreach (var t in declarations.Tokens.NonLinked)
                RegisterWarning(t.DeclarationToken, "The token '{0}' is never used in a production.", t.DeclarationToken.Text);

            foreach (var p in declarations.Productions.NonLinked)
                if (!p.First)
                    RegisterWarning(p.DeclarationToken, "The production '{0}' is never used in another production.", p.DeclarationToken.Text);

            foreach (var p in declarations.AstProductions.NonLinked)
                if (!p.First)
                    RegisterWarning(p.DeclarationToken, "The AST production '{0}' is never used in another production.", p.DeclarationToken.Text);
        }
    }
}
