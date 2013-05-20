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
                    //node.GetProdtranslation().Apply(this);

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
    }
}
