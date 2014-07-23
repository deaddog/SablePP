using System;
using System.Collections.Generic;

using SablePP.Compiler.Nodes;

using SablePP.Tools.Error;
using SablePP.Compiler.Nodes.Identifiers;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class DeclarationVisitor : ErrorVisitor
    {
        private HelpersTable helpers;
        private StatesTable states;
        private TokensTable tokens;

        private ProductionsTable productions;
        private ProductionsTable astProd;
        private ProductionsTable nonastProd;

        private AlternativesTable alternatives;
        private Dictionary<PProduction, AlternativesTable> allAlternatives;
        private ElementsTable elements;
        private Dictionary<PAlternative, ElementsTable> allElements;

        private HighlightrulesTable highlightrules;

        public DeclarationVisitor(ErrorManager errorManager)
            : base(errorManager)
        {
            this.helpers = new HelpersTable();
            this.states = new StatesTable();
            this.tokens = new TokensTable();

            this.productions = null;
            this.astProd = new ProductionsTable();
            this.nonastProd = new ProductionsTable();

            this.alternatives = null;
            this.allAlternatives = new Dictionary<PProduction, AlternativesTable>();
            this.elements = null;
            this.allElements = new Dictionary<PAlternative, ElementsTable>();

            this.highlightrules = new HighlightrulesTable();
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            if (node.HasHelpers)
                Visit(node.Helpers);

            if (node.HasStates)
                Visit(node.States);

            if (node.HasTokens)
                Visit(node.Tokens);

            if (node.HasIgnoredtokens)
                Visit(node.Ignoredtokens);

            if (node.HasAstproductions)
                Visit(node.Astproductions);

            if (node.HasProductions)
                Visit(node.Productions);

            if (node.HasHighlightrules)
                Visit(node.Highlightrules);

            foreach (var h in helpers.NonLinked)
                RegisterWarning(h.Identifier, "The helper {0} is never used in a helper or token definition.", h.Identifier);

            foreach (var s in states.NonLinked)
                RegisterWarning(s, "The state {0} is never used.", s);

            foreach (var t in tokens.NonLinked)
                RegisterWarning(t.Identifier, "The token {0} is never used in a production.", t.Identifier);

            foreach (var p in nonastProd.NonLinked)
                if (!p.Identifier.AsPProduction.IsFirst)
                    RegisterWarning(p.Identifier, "The production {0} is never used in another production.", p.Identifier);

            foreach (var p in astProd.NonLinked)
                if (!p.Identifier.AsPProduction.IsFirst)
                    RegisterWarning(p.Identifier, "The AST production {0} is never used in another production.", p.Identifier);
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
            foreach (var s in node.States)
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
        public override void CaseATransitionTokenstateListitem(ATransitionTokenstateListitem node)
        {
            if (!states.Link(node.From))
                RegisterError(node.From, "The state {0} has not been defined.", node.From);
            if (!states.Link(node.To))
                RegisterError(node.To, "The state {0} has not been defined.", node.To);
        }

        public override void CaseAIgnoredtokens(AIgnoredtokens node)
        {
            foreach (var item in node.Tokens)
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
            alternatives = new AlternativesTable();
            base.CaseAProduction(node);
            allAlternatives[node] = alternatives;
        }
        public override void CaseAAlternative(AAlternative node)
        {
            elements = new ElementsTable();
            base.CaseAAlternative(node);
            allElements[node] = elements;
        }

        public override void CaseAAlternativename(AAlternativename node)
        {
            if (!alternatives.Declare(node.GetFirstParent<AAlternative>()))
                RegisterError(node.Name, "Production alternative {0} is already in use (line {1}).", node.Name, alternatives[node.Name.Text].Alternativename.Name.Line);
            base.CaseAAlternativename(node);
        }
        public override void InPElement(PElement node)
        {
            if (!elements.Declare(node))
            {
                if (node.HasElementname)
                    RegisterError(node.Elementname.Name, "Element name {0} is already in use in this production.", node.Elementname.Name);
                else
                    RegisterError(node.Elementid.Identifier, "A {0} element (or an element named {0}) is already in use in this production.", node.Elementid.Identifier);
            }
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

        public override void InPProdtranslation(PProdtranslation node)
        {
            if (!astProd.Link(node.Identifier))
                RegisterError(node.Identifier, "The AST production {0} has not been defined.", node.Identifier);
        }

        public override void CaseANewTranslation(ANewTranslation node)
        {
            if (!astProd.Link(node.Production))
                RegisterError(node.Production, "The AST production {0} has not been defined.", node.Production);

            base.CaseANewTranslation(node);
        }
        public override void CaseANewalternativeTranslation(ANewalternativeTranslation node)
        {
            if (astProd.Link(node.Production))
            {
                PProduction dp = astProd[node.Production.Text];
                var alternatives = allAlternatives[dp];

                if (!alternatives.Link(node.Alternative))
                    RegisterError(node.Alternative, "The AST alternative {0} has not been defined.", node.Alternative);
            }
            else
                RegisterError(node.Production, "The AST production {0} has not been defined.", node.Production);

            base.CaseANewalternativeTranslation(node);
        }
        public override void CaseAIdTranslation(AIdTranslation node)
        {
            if (!elements.Link(node.Identifier))
                RegisterError(node.Identifier, "The production element {0} has not been defined. Check for possible renames.", node.Identifier);
        }
        public override void CaseAIddotidTranslation(AIddotidTranslation node)
        {
            if (!elements.Link(node.Identifier))
                RegisterError(node.Identifier, "The production element {0} has not been defined. Check for possible renames.", node.Identifier);

            if (!astProd.Link(node.Production))
                RegisterError(node.Production, "The AST production {0} has not been defined.", node.Production);
        }

        public override void CaseAHighlightrule(AHighlightrule node)
        {
            if (!highlightrules.Declare(node))
                RegisterError(node.Name, "Syntax highlight style {0} has already been defined (line {1}).", node.Name, highlightrules[node.Name.Text].Name.Line);

            foreach (var item in node.Tokens)
            {
                if (!tokens.Link(item.Identifier))
                    RegisterError(node, "The token {0} has not been defined.", node);
                else
                {
                    var token = tokens[item.Identifier.Text];
                    if (token.HasHighlighting)
                        RegisterError(item.Identifier, "The style of {0} has already been defined as {1} (line {2}).", item.Identifier, token.Highlighting.Name, token.Highlighting.Name.Line);
                    else
                        token.Highlighting = node;
                }
            }
        }
    }
}
