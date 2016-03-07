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

        protected override void HandleAGrammar(AGrammar node)
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

        protected override void HandleHelpers(PHelper[] nodes)
        {
            foreach (var h in nodes)
                TryDeclare(h, helpers);

            base.HandleHelpers(nodes);
        }
        protected override void HandleAIdentifierRegex(AIdentifierRegex node)
        {
            TryLink(node.Identifier, helpers);
        }

        protected override void HandleStates(PState[] nodes)
        {
            foreach (var s in nodes)
                TryDeclare(s, states);
        }

        protected override void HandleAToken(AToken node)
        {
            if (node.Statelist.Count > 0)
                Visit(node.Statelist);

            TryDeclare(node, tokens);

            Visit(node.Regex);
            if (node.HasTokenlookahead)
                Visit(node.Tokenlookahead);
        }

        protected override void HandleATokenState(ATokenState node)
        {
            TryLink(node.Identifier, states);
        }
        protected override void HandleATransitionTokenState(ATransitionTokenState node)
        {
            TryLink(node.From, states);
            TryLink(node.To, states);
        }

        protected override void HandleIgnoredTokens(TIdentifier[] nodes)
        {
            foreach (var item in nodes)
                if (TryLink(item, tokens))
                    tokens[item.Text].IsIgnored = true;
        }

        protected override void HandleAstProductions(PProduction[] nodes)
        {
            productions = astProd;

            foreach (var prod in nodes)
                TryDeclare(prod, productions);

            base.HandleAstProductions(nodes);

            productions = null;
        }
        protected override void HandleProductions(PProduction[] nodes)
        {
            productions = nonastProd;

            foreach (var prod in nodes)
                TryDeclare(prod, productions);

            base.HandleProductions(nodes);

            productions = null;
        }
        protected override void HandleAProduction(AProduction node)
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
        protected override void HandleAAlternative(AAlternative node)
        {
            elements = new DeclarationTable<PElement>();
            base.HandleAAlternative(node);
            allElements[node] = elements;
        }

        protected override void HandleAAlternativename(AAlternativename node)
        {
            TryDeclare(node.GetFirstParent<AAlternative>(), alternatives);

            base.HandleAAlternativename(node);
        }
        protected override void HandlePElement(PElement node)
        {
            if (!elements.Declare(node))
            {
                if (node.HasElementname)
                    RegisterError(node.Elementname.Name, "Element name {0} is already in use in this production.", node.Elementname.Name);
                else
                    RegisterError(node.Elementid.Identifier, "A {0} element (or an element named {0}) is already in use in this production.", node.Elementid.Identifier);
            }

            base.HandlePElement(node);
        }

        protected override void HandleACleanElementid(ACleanElementid node)
        {
            TIdentifier ident = node.Identifier;
            string text = ident.Text;

            if (tokens.Contains(text) && productions.Contains(text))
                RegisterError(ident, "Unable to determine if {0} refers to a token or a production. Use T.{1} or P.{1} to specify.", ident, text);
            else if (TryLink(ident, tokens, productions) && tokens.Contains(text))
            {
                if (tokens[text].IsIgnored)
                    RegisterError(node, "The ignored token {0} cannot be used in a production.", ident);
            }

            base.HandleACleanElementid(node);
        }
        protected override void HandleATokenElementid(ATokenElementid node)
        {
            if (TryLink(node.Identifier, tokens))
            {
                if (tokens[node.Identifier.Text].IsIgnored)
                    RegisterError(node, "The ignored token {0} cannot be used in a production.", node.Identifier);
            }

            base.HandleATokenElementid(node);
        }
        protected override void HandleAProductionElementid(AProductionElementid node)
        {
            TryLink(node.Identifier, productions);

            base.HandleAProductionElementid(node);
        }

        protected override void HandlePProdtranslation(PProdtranslation node)
        {
            if (astProd.Contains(node.Identifier.Text) && tokens.Contains(node.Identifier.Text))
                RegisterError(node.Identifier, "Unable to determine if {0} refers to an AST production or a token.", node.Identifier.Text);
            if (!astProd.Link(node.Identifier) && !tokens.Link(node.Identifier))
                RegisterError(node.Identifier, "The production translation target {0} has not been defined as neither an AST production or a token.", node.Identifier);

            base.HandlePProdtranslation(node);
        }

        protected override void HandleANewTranslation(ANewTranslation node)
        {
            if (TryLink(node.Production, astProd) && node.Production.AsPProduction.UnnamedAlternative == null)
                RegisterError(node.Production, "The AST production {0} does not have an unnamed alternative.");

            base.HandleANewTranslation(node);
        }
        protected override void HandleANewalternativeTranslation(ANewalternativeTranslation node)
        {
            if (TryLink(node.Production, astProd))
            {
                PProduction dp = astProd[node.Production.Text];
                var alternatives = allAlternatives[dp];

                TryLink(node.Alternative, "AST alternative", alternatives);
            }

            base.HandleANewalternativeTranslation(node);
        }
        protected override void HandleAIdTranslation(AIdTranslation node)
        {
            TryLink(node.Identifier, "production element", elements);
        }
        protected override void HandleAIddotidTranslation(AIddotidTranslation node)
        {
            TryLink(node.Identifier, "production element", elements);
            TryLink(node.Production, astProd);
        }

        protected override void HandleAHighlightrule(AHighlightrule node)
        {
            for (int i = 0; i < node.Tokens.Count; i++)
            {
                var item = node.Tokens[i];
                if (TryLink(item, tokens))
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
