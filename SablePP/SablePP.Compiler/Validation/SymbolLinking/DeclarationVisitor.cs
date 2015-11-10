using SablePP.Compiler.Nodes;
using SablePP.Generate;
using SablePP.Tools;
using SablePP.Tools.Error;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class DeclarationVisitor : ErrorVisitor
    {
        private bool hasASTsection;

        private DeclarationTable<PHelper> helpers;
        private DeclarationTable<PState> states;
        private DeclarationTable<PToken> tokens;

        private DeclarationTable<PProduction> productions;
        private DeclarationTable<PProduction> astProd;
        private DeclarationTable<PProduction> nonastProd;

        private DeclarationTable<PAlternative> alternatives;
        private Dictionary<PProduction, DeclarationTable<PAlternative>> allAlternatives;
        private DeclarationTable<PElement> elements;
        private Dictionary<PAlternative, DeclarationTable<PElement>> allElements;

        public DeclarationVisitor(ErrorManager errorManager)
            : base(errorManager)
        {
            this.helpers = new DeclarationTable<PHelper>();
            this.states = new DeclarationTable<PState>();
            this.tokens = new DeclarationTable<PToken>();

            this.productions = null;
            this.astProd = new DeclarationTable<PProduction>();
            this.nonastProd = new DeclarationTable<PProduction>();

            this.alternatives = null;
            this.allAlternatives = new Dictionary<PProduction, DeclarationTable<PAlternative>>();
            this.elements = null;
            this.allElements = new Dictionary<PAlternative, DeclarationTable<PElement>>();
        }

        private string getSuggestion(TIdentifier identifier, params IDeclarationTable[] tables)
        {
            if (tables.Length == 0)
                return null;

            var keys = from t in tables
                       from kvp in t.Declarations
                       select kvp.Key;

            var suggestion = keys.GetDistance(identifier.Text).Where(x => x.Distance < 0.75).Cast<EditDistance<string>?>().FirstOrDefault()?.Target;

            if (suggestion == null)
                return null;
            else
                return $" Did you mean '{suggestion}'?";
        }

        private bool TryDeclare<T>(T declaration, DeclarationTable<T> table)
            where T : SablePP.Tools.Nodes.Production, IDeclaration
        {
            return TryDeclare(declaration, getName(false, table), table);
        }
        private bool TryDeclare<T>(T declaration, string typename, DeclarationTable<T> table)
            where T : SablePP.Tools.Nodes.Production, IDeclaration
        {
            if (!table.Declare(declaration))
            {
                var identifier = declaration.GetIdentifier();
                var line = table[identifier.Text].GetIdentifier().Line;
                RegisterError(identifier, $"The {typename} {identifier} has already been defined (line {line}).");
                return false;
            }
            else
                return true;
        }
        private bool TryLink(TIdentifier identifier, params IDeclarationTable[] tables)
        {
            return TryLink(identifier, getNames(false, tables), tables);
        }
        private bool TryLink(TIdentifier identifier, string typename, params IDeclarationTable[] tables)
        {
            if (!tables.Any(t => t.Link(identifier)))
            {
                RegisterError(identifier, $"The {typename} {identifier.Text} has not been defined." + getSuggestion(identifier, tables));
                return false;
            }
            else
                return true;
        }

        private string getNames(bool plural, params IDeclarationTable[] tables)
        {
            if (tables.Length == 0)
                throw new ArgumentException("No tables were specified.");

            string r = getName(plural, tables[0]);

            for (int i = 1; i < tables.Length - 1; i++)
                r += ", " + getName(plural, tables[i]);

            if (tables.Length > 1)
                r += " or " + getName(plural, tables[tables.Length - 1]);

            return r;
        }
        private string getName(bool plural, IDeclarationTable table)
        {
            var name = getName(table);
            if (plural)
                name += "s";
            return name;
        }
        private string getName(IDeclarationTable table)
        {
            if (table == helpers)
                return "helper";
            else if (table == states)
                return "state";
            else if (table == tokens)
                return "token";
            else if (table == nonastProd)
                return "production";
            else if (table == astProd)
                return "AST production";
            else if (table == alternatives)
                return "production alternative";
            else
                throw new ArgumentOutOfRangeException("Unknown table type.");
        }

        public override void CaseAGrammar(AGrammar node)
        {
            hasASTsection = node.HasAstproductions;

            VisitNamespaces(node.Namespaces);
            VisitHelpers(node.Helpers);
            VisitStates(node.States);
            VisitTokens(node.Tokens);
            VisitIgnoredTokens(node.IgnoredTokens);
            VisitAstProductions(node.AstProductions);
            VisitProductions(node.Productions);

            if (ErrorManager.Errors.Count > 0)
                return;

            if (node.HasProductions && node.HasAstproductions)
                new TranslationTargetVisitor(this.ErrorManager).VisitProductions(node.Productions);

            VisitHighlightRules(node.HighlightRules);

            foreach (var h in helpers.UnLinked)
                RegisterWarning(h.Identifier, "The helper {0} is never used in a helper or token definition.", h.Identifier);

            foreach (var s in states.UnLinked)
                RegisterWarning(s, "The state {0} is never used.", s);

            foreach (var t in tokens.UnLinked)
                RegisterWarning(t.Identifier, "The token {0} is never used in a production.", t.Identifier);

            foreach (var p in nonastProd.UnLinked)
                if (!p.Identifier.AsPProduction.IsFirst)
                    RegisterWarning(p.Identifier, "The production {0} is never used in another production.", p.Identifier);

            foreach (var p in astProd.UnLinked)
                if (!p.Identifier.AsPProduction.IsFirst)
                    RegisterWarning(p.Identifier, "The AST production {0} is never used in another production.", p.Identifier);
        }

        protected override void CaseHelpers(PHelper[] nodes)
        {
            foreach (var h in nodes)
                if (!helpers.Declare(h))
                    RegisterError(h.Identifier, "Helper {0} has already been defined (line {1}).", h.Identifier, helpers[h.Identifier.Text].Identifier.Line);

            base.CaseHelpers(nodes);
        }
        public override void CaseAIdentifierRegex(AIdentifierRegex node)
        {
            if (!helpers.Link(node.Identifier))
                RegisterError(node.Identifier, "The helper {0} has not been defined.", node.Identifier);
        }

        protected override void CaseStates(PState[] nodes)
        {
            foreach (var s in nodes)
                if (!states.Declare(s))
                    RegisterError(s.Identifier, "State {0} has already been defined (line {1}).", s.Identifier, states[s.Identifier.Text].Identifier.Line);
        }

        public override void CaseAToken(AToken node)
        {
            if (node.Statelist.Count > 0)
                Visit(node.Statelist);

            if (!tokens.Declare(node))
                RegisterError(node.Identifier, "Token {0} has already been defined (line {1}).", node.Identifier, tokens[node.Identifier.Text].Identifier.Line);

            Visit(node.Regex);
            if (node.HasTokenlookahead)
                Visit(node.Tokenlookahead);
        }

        public override void CaseATokenState(ATokenState node)
        {
            if (!states.Link(node.Identifier))
                RegisterError(node.Identifier, "The state {0} has not been defined.", node.Identifier);
        }
        public override void CaseATransitionTokenState(ATransitionTokenState node)
        {
            if (!states.Link(node.From))
                RegisterError(node.From, "The state {0} has not been defined.", node.From);
            if (!states.Link(node.To))
                RegisterError(node.To, "The state {0} has not been defined.", node.To);
        }

        protected override void CaseIgnoredTokens(TIdentifier[] nodes)
        {
            foreach (var item in nodes)
            {
                if (!tokens.Link(item))
                    RegisterError(item, "The token {0} has not been defined.", item);
                else
                    tokens[item.Text].IsIgnored = true;
            }
        }

        protected override void CaseAstProductions(PProduction[] nodes)
        {
            productions = astProd;

            foreach (var prod in nodes)
                if (!productions.Declare(prod))
                    RegisterError(prod.Identifier, "AST production {0} has already been defined (line {1}).", prod.Identifier, productions[prod.Identifier.Text].Identifier.Line);

            base.CaseAstProductions(nodes);

            productions = null;
        }
        protected override void CaseProductions(PProduction[] nodes)
        {
            productions = nonastProd;

            foreach (var prod in nodes)
                if (!productions.Declare(prod))
                    RegisterError(prod.Identifier, "Production {0} has already been defined (line {1}).", prod.Identifier, productions[prod.Identifier.Text].Identifier.Line);

            base.CaseProductions(nodes);

            productions = null;
        }
        public override void CaseAProduction(AProduction node)
        {
            alternatives = new DeclarationTable<PAlternative>();

            Visit(node.Identifier);

            if (node.HasProdtranslation)
            {
                Visit(node.Prodtranslation);

                var id = node.Prodtranslation.Identifier;
                var mod = node.Prodtranslation.Modifier.GetModifier();

                if (id.IsPProduction)
                    node.AstTarget = new TranslationTarget(id.AsPProduction, mod);
                else if (id.IsPToken)
                    node.AstTarget = new TranslationTarget(id.AsPToken, mod);
            }
            else if (hasASTsection)
            {
                PProduction abs;
                if (astProd.TryGetValue(node.Identifier.Text, out abs))
                    node.AstTarget = new TranslationTarget(abs, Modifiers.Single);
                else
                    RegisterError(node.Identifier,
                        "Resulting AST node could not be inferred from production. No \"{0}\" ast-production was found.", node.Identifier.Text);
            }

            Visit(node.Alternatives);
            if (node.Alternatives.Where(a => !a.HasAlternativename).Count() > 1)
                RegisterError(node.Identifier, "A production can only have 1 unnamed alternative.");

            allAlternatives[node] = alternatives;
        }
        public override void CaseAAlternative(AAlternative node)
        {
            elements = new DeclarationTable<PElement>();
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
            if (astProd.Contains(node.Identifier.Text) && tokens.Contains(node.Identifier.Text))
                RegisterError(node.Identifier, "Unable to determine if {0} refers to an AST production or a token.", node.Identifier.Text);
            if (!astProd.Link(node.Identifier) && !tokens.Link(node.Identifier))
                RegisterError(node.Identifier, "The production translation target {0} has not been defined as neither an AST production or a token.", node.Identifier);
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
            for (int i = 0; i < node.Tokens.Count; i++)
            {
                var item = node.Tokens[i];
                if (!tokens.Link(item))
                    RegisterError(node, "The token {0} has not been defined.", item);
                else
                {
                    var token = tokens[item.Text];
                    if (token.HasHighlighting)
                        RegisterError(item, "The style of {0} has already been defined in line {1}.", item, token.Highlighting.Lpar.Line);
                    else
                        token.Highlighting = node;
                }
            }
        }
    }
}
