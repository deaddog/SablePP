using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
{
    public class ProductionVisitor : BaseProductionVisitor
    {
        public ProductionVisitor(IEnumerable<KeyValuePair<string, DToken>> tokens)
            : base(tokens, true)
        {
        }
    }
}
