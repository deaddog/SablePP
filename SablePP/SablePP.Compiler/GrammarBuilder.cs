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

        #region Regular Exrpressions

        public RegExp Visit(PRegex node)
        {
            return Visit((dynamic)node);
        }

        public RegExp Visit(ACharRegex node)
        {
            return new LiteralRegExp(node.Character.Text[0]);
        }
        public RegExp Visit(ADecRegex node)
        {
            return new LiteralRegExp((char)int.Parse(node.DecChar.Text));
        }
        public RegExp Visit(AHexRegex node)
        {
            var i = Convert.ToInt32(node.HexChar.Text.Substring(2), 16);
            return new LiteralRegExp((char)i);
        }
        public RegExp Visit(AConcatenatedRegex node)
        {
            if (node.Regexs.Count == 1)
                return Visit(node.Regexs[0]);
            else
                return new ConcatenatedRegExp(from r in node.Regexs select Visit(r));
        }
        public RegExp Visit(AUnaryRegex node)
        {
            if (node.Modifier is AQuestionModifier)
                return new ModifiedRegExp(Visit(node.Regex), Modifiers.Optional);
            else if (node.Modifier is AStarModifier)
                return new ModifiedRegExp(Visit(node.Regex), Modifiers.ZeroOrMany);
            else if (node.Modifier is APlusModifier)
                return new ModifiedRegExp(Visit(node.Regex), Modifiers.OneOrMany);
            else
                throw new ArgumentException("Unknown modifier: " + node.Modifier);
        }
        public RegExp Visit(ABinaryplusRegex node)
        {
            return new SetRegExp(Visit(node.Left), Visit(node.Right), SetRegExp.SetTypes.Union);
        }
        public RegExp Visit(ABinaryminusRegex node)
        {
            return new SetRegExp(Visit(node.Left), Visit(node.Right), SetRegExp.SetTypes.Complement);
        }
        public RegExp Visit(AIntervalRegex node)
        {
            return new SetRegExp(Visit(node.Left), Visit(node.Right), SetRegExp.SetTypes.Range);
        }
        public RegExp Visit(AStringRegex node)
        {
            return new LiteralRegExp(node.String.Text);
        }
        public RegExp Visit(AIdentifierRegex node)
        {
            var h = helpers[node.Identifier.AsPHelper];
            return new ReferenceRegExp(h);
        }
        public RegExp Visit(AParenthesisRegex node)
        {
            return Visit(node.Regex);
        }
        public RegExp Visit(AOrRegex node)
        {
            if (node.Regexs.Count == 1)
                return Visit(node.Regexs[0]);
            else
                return new OrRegExp(from r in node.Regexs select Visit(r));
        }

        #endregion
    }
}
