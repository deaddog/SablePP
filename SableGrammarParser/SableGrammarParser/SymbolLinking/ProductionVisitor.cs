using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
{
    public class ProductionVisitor : BaseProductionVisitor
    {
        private Dictionary<string, DProduction> astProductions;

        public ProductionVisitor(IEnumerable<KeyValuePair<string, DToken>> tokens,
                                 IEnumerable<KeyValuePair<string,DProduction>> astProductions)
            : base(tokens, true)
        {
            this.astProductions = new Dictionary<string, DProduction>();
            foreach (var a in astProductions)
                this.astProductions.Add(a.Key, a.Value);
        }
    }
}
