using SablePP.Compiler.Nodes;
using SablePP.Generate;
using SablePP.Generate.RegularExpressions;
using SablePP.Tools.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Compiler
{
    public class GrammarBuilder
    {
        private Dictionary<PHelper, Helper> helpers;
        private GrammarBuilder()
        {
            this.helpers = new Dictionary<PHelper, Helper>();
        }

        public static Grammar BuildSableCCGrammar(Start<PGrammar> grammar)
        {
            GrammarBuilder builder = new GrammarBuilder();
            return builder.Visit(grammar.Root as AGrammar);
        }

        public Grammar Visit(AGrammar node)
        {
            var package = node.PackageName;
            var helpers = Visit(node.Helpers).ToArray();
            throw new NotImplementedException();
        }

        public IEnumerable<Helper> Visit(PHelpers node)
        {
            return from h in node.Helpers select Visit(h);
        }

        public Helper Visit(PHelper node)
        {
            var helper = new Helper(Visit(node.Regex));
            helpers.Add(node, helper);
            return helper;
        }

        public RegExp Visit(PRegex node)
        {
            throw new NotImplementedException();
        }
    }
}
