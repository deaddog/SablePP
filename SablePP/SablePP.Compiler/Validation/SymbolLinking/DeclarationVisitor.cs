using System;
using System.Collections.Generic;

using SablePP.Compiler.Nodes;

using SablePP.Tools.Error;
using SablePP.Compiler.Nodes.Identifiers;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class DeclarationVisitor : ErrorVisitor
    {
        private DeclarationTables.HelpersTable helpers;
        private DeclarationTables.StatesTable states;
        private DeclarationTables.TokensTable tokens;

        public DeclarationVisitor(ErrorManager errorManager)
            : base(errorManager)
        {
            this.helpers = new DeclarationTables.HelpersTable();
            this.states = new DeclarationTables.StatesTable();
            this.tokens = new DeclarationTables.TokensTable();
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
                Visit(node.Tokens);

            if (node.HasIgnoredtokens)
                Visit(node.Ignoredtokens);

            if (node.HasProductions)
                ProductionVisitor.LoadProductionDeclarations(node.Productions, declarations, this.ErrorManager);

            if (node.HasAstproductions)
                ProductionVisitor.LoadProductionDeclarations(node.Astproductions, declarations, this.ErrorManager);

            if (node.HasProductions)
                TranslationVisitor.SetIdentifiersInTranslations(node.Productions, declarations, this.ErrorManager);

            if (node.HasHighlightrules)
                TokenHighlightVisitor.LoadTokenDeclarations(node.Highlightrules, declarations, this.ErrorManager);

            foreach (var h in helpers.NonLinked)
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

        public override void CaseAToken(AToken node)
        {
            if (node.HasStatelist)
                Visit(node.Statelist);

            if (!tokens.Declare(node))
                RegisterError(node.Identifier, "Token {0} has already been defined (line {1}).", node.Identifier, tokens[node.Identifier.Text].Identifier.Line);

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

        public override void CaseAIgnoredtokens(AIgnoredtokens node)
        {
            foreach(AIdentifierListitem item in node.List.Listitem)
            {
                if (!tokens.Link(item.Identifier))
                    RegisterError(item.Identifier, "The token {0} has not been defined.", item.Identifier);
                else
                    tokens[item.Identifier.Text].IsIgnored = true;
            }
        }
    }
}
