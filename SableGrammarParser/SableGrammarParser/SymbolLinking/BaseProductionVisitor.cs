using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
{
    public abstract class BaseProductionVisitor<ProdType, AltType> : Error.ErrorVisitor
        where AltType : DBaseAlternative
        where ProdType : DBaseProduction<AltType>
    {
        private Dictionary<string, DToken> tokens;
        private Dictionary<string, ProdType> productions;
        private bool firstRun = true;
        private bool concrete;

        private Dictionary<string, AltType> alternatives;
        private Dictionary<string, DElementName> elements;

        private DictType tryGet<DictType>(Dictionary<string, DictType> dictionary, string text) where DictType : Declaration
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            if (text == null || text.Length == 0)
                throw new ArgumentNullException("text");

            DictType declaration;
            if (dictionary.TryGetValue(text, out declaration))
                return declaration;
            else
                return null;
        }
        protected DToken GetToken(string text)
        {
            return tryGet(tokens, text);
        }
        protected ProdType GetProduction(string text)
        {
            return tryGet(productions, text);
        }
        protected AltType GetAlternativeName(string text)
        {
            return tryGet(alternatives, text);
        }
        protected DElementName GetElementName(string text)
        {
            return tryGet(elements, text);
        }

        protected abstract ProdType Construct(AProduction node);
        protected abstract AltType Construct(AAlternativename node);

        public Dictionary<string, ProdType> GetProductions()
        {
            Dictionary<string, ProdType> productionDict = new Dictionary<string, ProdType>();
            foreach (var p in productions)
                productionDict.Add(p.Key, p.Value);
            return productionDict;
        }

        protected BaseProductionVisitor(IEnumerable<KeyValuePair<string, DToken>> tokens, bool concrete)
        {
            this.concrete = concrete;

            this.tokens = new Dictionary<string, DToken>();
            foreach (var v in tokens)
                this.tokens.Add(v.Key, v.Value);

            this.productions = new Dictionary<string, ProdType>();
            this.alternatives = new Dictionary<string, AltType>();
            this.elements = new Dictionary<string, DElementName>();
        }

        public override void CaseAProduction(AProduction node)
        {
            if (firstRun)
            {
                string text = node.GetIdentifier().Text;
                ProdType production = Construct(node);
                if (productions.ContainsKey(text))
                    RegisterError(node.GetIdentifier(), "The {2}production {0} has already been defined (line {1}).", node.GetIdentifier(), productions[text].DeclarationToken.Line, concrete ? "" : "AST ");
                else
                    productions.Add(text, production);
            }
            else
            {
                alternatives.Clear();

                if (node.GetIdentifier() != null)
                {
                    TIdentifier ident = node.GetIdentifier();
                    ProdType production = null;
                    if (productions.TryGetValue(ident.Text, out production))
                        ident.SetDeclaration(production);
                    else
                        RegisterError(ident, "The {1}production {0} has not been defined.", ident, concrete ? "" : "AST ");
                }

                if (node.GetProdtranslation() != null)
                    node.GetProdtranslation().Apply(this);

                if (node.GetEqual() != null)
                    node.GetEqual().Apply(this);

                if (node.GetProductionrule() != null)
                    node.GetProductionrule().Apply(this);

                if (node.GetSemicolon() != null)
                    node.GetSemicolon().Apply(this);
            }
        }
        public override void OutAProductions(AProductions node)
        {
            if (firstRun)
            {
                firstRun = false;
                node.Apply(this);
            }
        }

        public override void InAAlternative(AAlternative node)
        {
            elements.Clear();
        }
        public override void CaseAAlternativename(AAlternativename node)
        {
            string text = node.GetName().Text;
            AltType alternative = Construct(node);
            if (alternatives.ContainsKey(text))
                RegisterError(node.GetName(), "Alternative {0} has already been defined (line {1}).", node.GetName(), alternatives[text].DeclarationToken.Line);
            else
            {
                alternatives.Add(text, alternative);
                node.GetName().SetDeclaration(alternative);
            }
        }

        public override void CaseAElementname(AElementname node)
        {
            string text = node.GetName().Text;
            DElementName element = new DElementName(node);
            if (elements.ContainsKey(text))
                RegisterError(node.GetName(), "Element name {0} has already been defined.", node.GetName());
            else
            {
                elements.Add(text, element);
                node.GetName().SetDeclaration(element);
            }
        }
        public override void CaseACleanElementid(ACleanElementid node)
        {
            TIdentifier ident = node.GetIdentifier();

            if (tokens.ContainsKey(ident.Text) && productions.ContainsKey(ident.Text))
                RegisterError(node, "{0} is defined a token (line {2}) and a production (line {3}) - use T.{1} or P.{1} to specify which was meant.", ident, ident.Text, tokens[ident.Text].DeclarationToken.Line, productions[ident.Text].DeclarationToken.Line);
            else if (tokens.ContainsKey(ident.Text))
                ident.SetDeclaration(tokens[ident.Text]);
            else if (productions.ContainsKey(ident.Text))
                ident.SetDeclaration(productions[ident.Text]);
            else
                RegisterError(node, "{0} has not been defined as neither a production, nor a token.", ident);
        }
        public override void CaseATokenElementid(ATokenElementid node)
        {
            DToken token = null;
            if (tokens.TryGetValue(node.GetIdentifier().Text, out token))
                node.GetIdentifier().SetDeclaration(token);
            else
                RegisterError(node, "The token {0} has not been defined.", node.GetIdentifier());
        }
        public override void CaseAProductionElementid(AProductionElementid node)
        {
            ProdType production = null;
            if (productions.TryGetValue(node.GetIdentifier().Text, out production))
                node.GetIdentifier().SetDeclaration(production);
            else
                RegisterError(node, "The production {0} has not been defined.", node.GetIdentifier());
        }
    }
}
