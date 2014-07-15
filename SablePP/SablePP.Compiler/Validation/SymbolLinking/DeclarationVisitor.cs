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

        private DeclarationTables.ProductionsTable productions;
        private DeclarationTables.ProductionsTable astProd;
        private DeclarationTables.ProductionsTable nonastProd;
        private DeclarationTables.AlternativesTable alternatives;
        private DeclarationTables.ElementsTable elements;

        public DeclarationVisitor(ErrorManager errorManager)
            : base(errorManager)
        {
            this.helpers = new DeclarationTables.HelpersTable();
            this.states = new DeclarationTables.StatesTable();
            this.tokens = new DeclarationTables.TokensTable();

            this.productions = null;
            this.astProd = new DeclarationTables.ProductionsTable();
            this.nonastProd = new DeclarationTables.ProductionsTable();
            this.alternatives = new DeclarationTables.AlternativesTable();
            this.elements = new DeclarationTables.ElementsTable();
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
                Visit(node.Productions);

            if (node.HasAstproductions)
                Visit(node.Astproductions);

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
            foreach (AIdentifierListitem item in node.List.Listitem)
            {
                if (!tokens.Link(item.Identifier))
                    RegisterError(item.Identifier, "The token {0} has not been defined.", item.Identifier);
                else
                    tokens[item.Identifier.Text].IsIgnored = true;
            }
        }

        public override void CaseAAstproductions(AAstproductions node)
        {
            productions = astProd;

            foreach (var prod in node.Productions)
                if (!productions.Declare(prod))
                    RegisterError(prod.Identifier, "AST production {0} has already been defined (line {1}).", prod.Identifier, productions[prod.Identifier.Text].Identifier.Line);

            base.CaseAAstproductions(node);

            productions = null;
        }
        public override void CaseAProductions(AProductions node)
        {
            productions = nonastProd;

            foreach (var prod in node.Productions)
                if (!productions.Declare(prod))
                    RegisterError(prod.Identifier, "Production {0} has already been defined (line {1}).", prod.Identifier, productions[prod.Identifier.Text].Identifier.Line);

            base.CaseAProductions(node);

            productions = null;
        }
        public override void CaseAProduction(AProduction node)
        {
            alternatives.Clear();
            base.CaseAProduction(node);
        }
        public override void CaseAAlternative(AAlternative node)
        {
            elements.Clear();
            base.CaseAAlternative(node);
        }

        public override void CaseAAlternativename(AAlternativename node)
        {
            if (!alternatives.Declare(node.GetFirstParent<AAlternative>()))
                RegisterError(node.Name, "Production alternative {0} is already in use (line {1}).", node.Name, alternatives[node.Name.Text].Alternativename.Name.Line);
            base.CaseAAlternativename(node);
        }
        public override void CaseAElementname(AElementname node)
        {
            if (!elements.Declare(node.GetFirstParent<PElement>()))
                RegisterError(node.Name, "Element name {0} is already in use in this production.", node.Name);
            base.CaseAElementname(node);
        }

        public override void CaseACleanElementid(ACleanElementid node)
        {
            TIdentifier ident = node.Identifier;
            string text = ident.Text;

            if (tokens.Contains(text) && productions.Contains(text))
                RegisterError(ident, "Unable to determine if {0} refers to a token or a production. Use T.{1} or P.{1} to specify.", ident, text);
            else if (tokens.Link(ident))
            {
                if (tokens[text].IsIgnored)
                    RegisterError(node, "The ignored token {0} cannot be used in a production.", ident);
            }
            else if (!productions.Link(ident))
                RegisterError(ident, "The token or production {0} has not been defined.", ident);

            base.CaseACleanElementid(node);
        }
        public override void CaseATokenElementid(ATokenElementid node)
        {
            if (tokens.Link(node.Identifier))
            {
                if (tokens[node.Identifier.Text].IsIgnored)
                    RegisterError(node, "The ignored token {0} cannot be used in a production.", node.Identifier);
            }
            else
                RegisterError(node.Identifier, "The token {0} has not been defined.", node.Identifier);

            base.CaseATokenElementid(node);
        }
        public override void CaseAProductionElementid(AProductionElementid node)
        {
            if (!productions.Link(node.Identifier))
                RegisterError(node.Identifier, "The production {0} has not been defined.", node.Identifier);
            
            base.CaseAProductionElementid(node);
        }
    }
}
