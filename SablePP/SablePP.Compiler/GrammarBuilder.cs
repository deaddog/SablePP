using SablePP.Compiler.Nodes;
using SablePP.Generate;
using SablePP.Generate.RegularExpressions;
using SablePP.Generate.Translations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SablePP.Compiler
{
    public abstract class GrammarBuilder
    {
        protected Dictionary<PHelper, Helper> helpers;
        protected Dictionary<PState, State> states;
        protected Dictionary<PToken, Token> tokens;

        internal GrammarBuilder()
        {
            this.helpers = new Dictionary<PHelper, Helper>();
            this.states = new Dictionary<PState, State>();
            this.tokens = new Dictionary<PToken, Token>();
        }

        public static Grammar BuildSableCCGrammar(SablePP.Tools.Nodes.Start<PGrammar> grammar)
        {
            GrammarBuilder builder;

            if (grammar.Root.HasAstproductions)
                builder = new AstGrammarBuilder();
            else
                builder = new NoAstGrammarBuilder();

            return builder.Visit(grammar.Root as AGrammar);
        }

        public abstract Grammar Visit(AGrammar node);

        public IEnumerable<Helper> Visit(IEnumerable<PHelper> nodes)
        {
            return from h in nodes select Visit(h);
        }
        public Helper Visit(PHelper node)
        {
            var helper = new Helper(Visit(node.Regex));
            helpers.Add(node, helper);
            return helper;
        }

        public IEnumerable<State> Visit(IEnumerable<PState> nodes)
        {
            return from s in nodes select Visit(s);
        }
        public State Visit(PState node)
        {
            var state = new State();
            states.Add(node, state);
            return state;
        }

        #region Tokens

        public IEnumerable<Token> Visit(IEnumerable<PToken> nodes)
        {
            return from t in nodes select Visit(t);
        }
        public Token Visit(PToken node)
        {
            Token token;

            string name = "T" + node.Identifier.Text.ToCamelCase();

            if (node.Statelist.Count == 0)
                token = new Token(name.ToCamelCase(), node.IsIgnored, Visit(node.Regex));
            else
                token = new Token(name.ToCamelCase(), node.IsIgnored, Visit(node.Regex), from s in node.Statelist select Visit(s));

            tokens.Add(node, token);
            return token;
        }
        public Token.TokenState Visit(PTokenState node)
        {
            return Visit((dynamic)node);
        }
        public Token.TokenState Visit(ATokenState node)
        {
            return new Token.TokenState(states[node.Identifier.AsState]);
        }
        public Token.TokenState Visit(ATransitionTokenState node)
        {
            return new Token.TokenState(states[node.From.AsState], states[node.To.AsState]);
        }

        #endregion

        #region Regular Expressions

        public RegExp Visit(PRegex node)
        {
            return Visit((dynamic)node);
        }

        public RegExp Visit(ACharRegex node)
        {
            return new LiteralRegExp(node.Character.Text[1]);
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
            return new ModifiedRegExp(Visit(node.Regex), node.Modifier.GetModifier());
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
            return new LiteralRegExp(node.String.Text.Substring(1, node.String.Text.Length - 2));
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

        #region Highlighting

        public IEnumerable<Highlighting> Visit(IEnumerable<PHighlightrule> nodes)
        {
            return from h in nodes select Visit(h);
        }

        public Highlighting Visit(PHighlightrule node)
        {
            bool bold = node.Styles.OfType<ABoldHighlightStyle>().Any();
            bool italic = node.Styles.OfType<AItalicHighlightStyle>().Any();

            var foreground = node.Styles.OfType<ATextHighlightStyle>().FirstOrDefault();
            var background = node.Styles.OfType<ABackgroundHighlightStyle>().FirstOrDefault();

            Color? foreColor = null;
            if (foreground != null)
                foreColor = Visit(foreground.Color);

            Color? backColor = null;
            if (background != null)
                backColor = Visit(background.Color);

            return new Highlighting(from t in node.Tokens select tokens[t.AsPToken], italic, bold, foreColor, backColor);
        }

        public Color Visit(PColor node)
        {
            return Visit((dynamic)node);
        }

        public Color Visit(AHexColor node)
        {
            //Remove the # from the start of the color token
            string color = node.Color.Text.Substring(1);

            int red, green, blue;

            if (color.Length == 3)
            {
                red = int.Parse("" + color[0] + color[0], System.Globalization.NumberStyles.HexNumber);
                green = int.Parse("" + color[1] + color[1], System.Globalization.NumberStyles.HexNumber);
                blue = int.Parse("" + color[2] + color[2], System.Globalization.NumberStyles.HexNumber);
            }
            else if (color.Length == 6)
            {
                red = int.Parse("" + color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                green = int.Parse("" + color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                blue = int.Parse("" + color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            }
            else
                throw new ApplicationException("Invalid length of hex-color token: " + color.Length + ".");

            return Color.FromArgb(red, green, blue);
        }
        public Color Visit(AHsvColor node)
        {
            Func<float, byte> calcValue = ff =>
            {
                ff *= 255;
                if (ff > 255) ff = 255;
                if (ff < 0) ff = 0;
                return (byte)ff;
            };

            int hue = node.Hue.Value;
            float saturation = node.Saturation.Value / 100f;
            float brightness = node.Brightness.Value / 100f;

            int h = (int)(hue / 60f);
            float f = (hue / 60f) - h; h %= 6;
            byte v = calcValue(brightness);
            byte p = calcValue(brightness * (1 - saturation));
            byte q = calcValue(brightness * (1 - f * saturation));
            byte t = calcValue(brightness * (1 - (1 - f) * saturation));

            switch (h)
            {
                case 0: return Color.FromArgb(v, t, p);
                case 1: return Color.FromArgb(q, v, p);
                case 2: return Color.FromArgb(p, v, t);
                case 3: return Color.FromArgb(p, q, v);
                case 4: return Color.FromArgb(t, p, v);
                case 5: return Color.FromArgb(v, p, q);
                default: throw new ApplicationException("Unknown hue value: " + hue);
            }
        }
        public Color Visit(ARgbColor node)
        {
            return Color.FromArgb(node.Red.Value, node.Green.Value, node.Blue.Value);
        }

        #endregion
    }
}
