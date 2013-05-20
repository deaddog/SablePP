using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
{
    public class ProductionVisitor : Error.ErrorVisitor
    {
        private Dictionary<string, DToken> tokens;
        private Dictionary<string, DProduction> productions;
        private bool firstRun = true;

        private Dictionary<string, DAlternativeName> alternatives;

        public Dictionary<string, DProduction> GetProductions()
        {
            Dictionary<string, DProduction> productionDict = new Dictionary<string, DProduction>();
            foreach (var p in productions)
                productionDict.Add(p.Key, p.Value);
            return productionDict;
        }

        public ProductionVisitor(IEnumerable<KeyValuePair<string, DToken>> tokens)
        {
            this.tokens = new Dictionary<string, DToken>();
            foreach (var v in tokens)
                this.tokens.Add(v.Key, v.Value);

            this.productions = new Dictionary<string, DProduction>();
            this.alternatives = new Dictionary<string, DAlternativeName>();
        }

        public override void CaseAProduction(AProduction node)
        {
            if (firstRun)
            {
                string text = node.GetIdentifier().Text;
                DProduction production = new DProduction(node, true);
                if (productions.ContainsKey(text))
                    RegisterError(node.GetIdentifier(), "Production {0} has already been defined (line {1}).", node.GetIdentifier(), productions[text].DeclarationToken.Line);
                else
                    productions.Add(text, production);
            }
            else
            {
                alternatives.Clear();

                if (node.GetIdentifier() != null)
                {
                    TIdentifier ident = node.GetIdentifier();
                    DProduction production = null;
                    if (productions.TryGetValue(ident.Text, out production))
                        ident.SetDeclaration(production);
                    else
                        RegisterError(ident, "The production {0} has not been defined.", ident);
                }

                if (node.GetProdtranslation() != null)
                    throw new NotImplementedException();

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
            base.InAAlternative(node);
        }
        public override void CaseAAlternativename(AAlternativename node)
        {
            string text = node.GetName().Text;
            DAlternativeName alternative = new DAlternativeName(node);
            if (alternatives.ContainsKey(text))
                RegisterError(node.GetName(), "Production {0} has already been defined (line {1}).", node.GetName(), alternatives[text].DeclarationToken.Line);
            else
                alternatives.Add(text, alternative);
        }
        public override void CaseAAlternative(AAlternative node)
        {
            base.CaseAAlternative(node);
        }
    }
}
