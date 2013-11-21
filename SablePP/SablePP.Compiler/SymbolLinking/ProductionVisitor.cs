using System;
using System.Collections.Generic;

using Sable.Compiler.Nodes;
using Sable.Tools.Error;

namespace Sable.Compiler.SymbolLinking
{
    public class ProductionVisitor : DeclarationVisitor
    {
        private Dictionary<string, DToken> tokens;
        private Dictionary<string, DProduction> productions;
        private Dictionary<string, DAlternativeName> alternatives;
        private Dictionary<string, DElementName> elements;

        private AAlternative currentAlternative;

        private ProductionVisitor(DeclarationTables declarations, ErrorManager errorManager, bool ast)
            : base(errorManager)
        {
            this.tokens = declarations.Tokens;
            this.productions = ast ? declarations.AstProductions : declarations.Productions;

            this.alternatives = new Dictionary<string, DAlternativeName>();
            this.elements = new Dictionary<string, DElementName>();
        }

        public static void LoadProductionDeclarations(PProductions node, DeclarationTables declarations, ErrorManager errorManager)
        {
            new ProductionVisitor(declarations, errorManager, false).Visit(node);
        }
        public static void LoadProductionDeclarations(PAstproductions node, DeclarationTables declarations, ErrorManager errorManager)
        {
            new ProductionVisitor(declarations, errorManager, true).Visit(node);
        }

        public override void InAProductions(AProductions node)
        {
            DeclarationLinker linker = new DeclarationLinker(this.ErrorManager);
            linker.Visit(node);
            foreach (var p in linker.Productions)
                this.productions.Add(p.Key, p.Value);
            base.InAProductions(node);
        }
        public override void InAAstproductions(AAstproductions node)
        {
            DeclarationLinker linker = new DeclarationLinker(this.ErrorManager);
            linker.Visit(node);
            foreach (var p in linker.Productions)
                this.productions.Add(p.Key, p.Value);
            base.InAAstproductions(node);
        }
        public override void InAProduction(AProduction node)
        {
            alternatives.Clear();
            base.InAProduction(node);
        }
        public override void InAAlternative(AAlternative node)
        {
            elements.Clear();
            this.currentAlternative = node;

            base.InAAlternative(node);
        }
        public override void InAAlternativename(AAlternativename node)
        {
            string text = node.Name.Text;
            DAlternativeName alternative = new DAlternativeName(node);
            if (alternatives.ContainsKey(text))
                RegisterError(node.Name, "Production alternative {0} is already in use (line {1}).", node.Name, alternatives[text].DeclarationToken.Line);
            else
            {
                alternatives.Add(text, alternative);
                node.Name.SetDeclaration(alternative);
            }

            base.InAAlternativename(node);
        }

        public override void InAElementname(AElementname node)
        {
            string text = node.Name.Text;
            DElementName element = new DElementName(node);
            if (elements.ContainsKey(text))
                RegisterError(node.Name, "Element name {0} is already in use in this production.", node.Name);
            else
            {
                elements.Add(text, element);
                node.Name.SetDeclaration(element);
            }

            base.InAElementname(node);
        }
        public override void InACleanElementid(ACleanElementid node)
        {
            TIdentifier ident = node.Identifier;
            string text = ident.Text;

            if (tokens.ContainsKey(text) && productions.ContainsKey(text))
                RegisterError(ident, "Unable to determine if {0} refers to a token or a production. Use T.{1} or P.{1} to specify.", ident, text);
            else if (tokens.ContainsKey(text))
                ident.SetDeclaration(tokens[text]);
            else if (productions.ContainsKey(text))
                ident.SetDeclaration(productions[text]);
            else
                RegisterError(ident, "The token or production {0} has not been defined.", ident);

            base.InACleanElementid(node);
        }
        public override void InATokenElementid(ATokenElementid node)
        {
            TIdentifier identifier = node.Identifier;

            DToken token = null;
            if (tokens.TryGetValue(identifier.Text, out token))
                identifier.SetDeclaration(token);
            else
                RegisterError(identifier, "The token {0} has not been defined.", identifier);

            base.InATokenElementid(node);
        }
        public override void InAProductionElementid(AProductionElementid node)
        {
            TIdentifier identifier = node.Identifier;

            DProduction production = null;
            if (productions.TryGetValue(identifier.Text, out production))
                identifier.SetDeclaration(production);
            else
                RegisterError(identifier, "The production {0} has not been defined.", identifier);

            base.InAProductionElementid(node);
        }

        private class DeclarationLinker : DeclarationVisitor
        {
            private Dictionary<string, DProduction> productions = new Dictionary<string, DProduction>();
            public Dictionary<string, DProduction> Productions
            {
                get
                {
                    Dictionary<string, DProduction> productionDict = new Dictionary<string, DProduction>();
                    foreach (var p in productions)
                        productionDict.Add(p.Key, p.Value);
                    return productionDict;
                }
            }

            public DeclarationLinker(ErrorManager errorManager)
                : base(errorManager)
            {
            }

            public override void CaseAProduction(AProduction node)
            {
                string text = node.Identifier.Text;
                DProduction production = new DProduction(node);
                if (productions.ContainsKey(text))
                    RegisterError(node.Identifier, "Production {0} has already been defined (line {1}).", node.Identifier, productions[text].DeclarationToken.Line);
                else
                {
                    productions.Add(text, production);
                    node.Identifier.SetDeclaration(production);
                }
            }
        }
    }
}
