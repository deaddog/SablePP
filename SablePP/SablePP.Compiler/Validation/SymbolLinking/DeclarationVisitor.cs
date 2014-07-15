using System;
using System.Collections.Generic;

using SablePP.Compiler.Nodes;

using SablePP.Tools.Error;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class DeclarationVisitor : ErrorVisitor
    {
        private DeclarationTables.HelpersTable helpers;
        private DeclarationTables.StatesTable states;

        public DeclarationVisitor(ErrorManager errorManager)
            : base(errorManager)
        {
            this.helpers = new DeclarationTables.HelpersTable();
            this.states = new DeclarationTables.StatesTable();
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            DeclarationTables declarations = new DeclarationTables();

            if (node.HasHelpers)
                Visit(node.Helpers);

            if (node.HasStates)
                Visit(node.States);

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
                RegisterWarning(h.Identifier, "The helper '{0}' is never used in a helper or token definition.", h.Identifier.Text);

            foreach (var s in states.NonLinked)
                RegisterWarning(s, "The state '{0}' is never used.", s.Text);

            foreach (var t in declarations.Tokens.NonLinked)
                RegisterWarning(t.DeclarationToken, "The token '{0}' is never used in a production.", t.DeclarationToken.Text);

            foreach (var p in declarations.Productions.NonLinked)
                if (!p.First)
                    RegisterWarning(p.DeclarationToken, "The production '{0}' is never used in another production.", p.DeclarationToken.Text);

            foreach (var p in declarations.AstProductions.NonLinked)
                if (!p.First)
                    RegisterWarning(p.DeclarationToken, "The AST production '{0}' is never used in another production.", p.DeclarationToken.Text);
        }

        public override void CaseAHelpers(AHelpers node)
        {
            foreach (var h in node.Helpers)
                if (!helpers.Declare(h))
                {
                    RegisterError(h.Identifier, "Helper {0} has already been defined (line {1}).",
                        h.Identifier,
                        helpers[h.Identifier.Text].Identifier.Line);
                }

            base.CaseAHelpers(node);
        }
        public override void CaseAIdentifierRegexpart(AIdentifierRegexpart node)
        {
            if (!helpers.Link(node.Identifier))
                RegisterError(node.Identifier, "The helper {0} has not been defined.", node.Identifier);
        }

        public override void CaseAStates(AStates node)
        {
            foreach (AIdentifierListitem s in node.List.Listitem)
                states.Declare(s.Identifier);
        }
    }
}
