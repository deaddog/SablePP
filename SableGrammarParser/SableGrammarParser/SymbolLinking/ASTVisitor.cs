using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
{
    public class ASTVisitor : Error.ErrorVisitor
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

        public ASTVisitor(IEnumerable<KeyValuePair<string, DToken>> tokens)
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
                DProduction production = new DProduction(node, false);
                if (productions.ContainsKey(text))
                    RegisterError(node.GetIdentifier(), "AST production {0} has already been defined (line {1}).", node.GetIdentifier(), productions[text].DeclarationToken.Line);
                else
                    productions.Add(text, production);
            }
            else
                base.CaseAProduction(node);
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
