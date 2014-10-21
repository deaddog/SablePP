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
    public class GrammarBuilder
    {
        private Dictionary<PHelper, Helper> helpers;
        private Dictionary<PState, State> states;
        private Dictionary<PToken, Token> tokens;

        private Dictionary<PProduction, Production> productions;
        private Dictionary<PElement, Alternative.Element> elements;

        private Dictionary<PProduction, AbstractProduction> abstractProductions;
        private Dictionary<PAlternative, AbstractAlternative> abstractAlternatives;

        private GrammarBuilder()
        {
            this.helpers = new Dictionary<PHelper, Helper>();
            this.states = new Dictionary<PState, State>();
            this.tokens = new Dictionary<PToken, Token>();

            this.productions = new Dictionary<PProduction, Production>();
            this.elements = new Dictionary<PElement, Alternative.Element>();

            this.abstractProductions = new Dictionary<PProduction, AbstractProduction>();
            this.abstractAlternatives = new Dictionary<PAlternative, AbstractAlternative>();
        }

        public static Grammar BuildSableCCGrammar(SablePP.Tools.Nodes.Start<PGrammar> grammar)
        {
            GrammarBuilder builder = new GrammarBuilder();
            return builder.Visit(grammar.Root as AGrammar);
        }

        public Grammar Visit(AGrammar node)
        {
            var _package = node.PackageName;
            var _helpers = node.HasHelpers ? Visit(node.Helpers).ToArray() : new Helper[0];
            var _states = node.HasStates ? Visit(node.States).ToArray() : new State[0];
            var _tokens = node.HasTokens ? Visit(node.Tokens).ToArray() : new Token[0]; ;

            foreach (var p in node.Astproductions.Productions)
            {
                string name = "P" + p.Identifier.Text.ToCamelCase();
                AbstractProduction prod = new AbstractProduction(name);
                abstractProductions.Add(p, prod);
            }

            var _absProds = node.HasAstproductions ? VisitAbstract(node.Astproductions).ToArray() : new AbstractProduction[0];

            foreach (var p in node.Productions.Productions)
            {
                Production prod;
                if (p.HasProdtranslation)
                    prod = new Production(Visit(p.Prodtranslation));
                else
                {
                    var target = p.AstTarget;
                    if (target.IsToken)
                        prod = new Production(new Production.ProductionTranslation(tokens[target.Token], target.Modifier));
                    else if (target.IsProduction)
                        prod = new Production(new Production.ProductionTranslation(abstractProductions[target.Production], target.Modifier));
                    else
                        throw new InvalidOperationException("Invalid production target.");
                }
                productions.Add(p, prod);
            }

            var _productions = node.HasProductions ? Visit(node.Productions).ToArray() : new Production[0];
            var _styles = node.HasHighlightrules ? Visit(node.Highlightrules).ToArray() : new Highlighting[0];

            return new Grammar(_package, _helpers, _states, _tokens, _productions, _absProds, _styles);
        }

        public Production.ProductionTranslation Visit(PProdtranslation node)
        {
            Modifiers mod = node.Modifier.GetModifier();

            if (node.Identifier.IsPProduction)
                return new Production.ProductionTranslation(abstractProductions[node.Identifier.AsPProduction], mod);
            else if (node.Identifier.IsPToken)
                return new Production.ProductionTranslation(tokens[node.Identifier.AsPToken], mod);
            else
                throw new ArgumentException("Production translation must be to either an ast node or a token.");
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

        public IEnumerable<State> Visit(PStates node)
        {
            return from s in node.States select Visit(s);
        }
        public State Visit(PState node)
        {
            var state = new State();
            states.Add(node, state);
            return state;
        }

        public IEnumerable<Token> Visit(PTokens node)
        {
            return from t in node.Tokens select Visit(t);
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

        public IEnumerable<AbstractProduction> VisitAbstract(PAstproductions node)
        {
            return from p in node.Productions select VisitAbstract(p);
        }
        public AbstractProduction VisitAbstract(PProduction node)
        {
            var prod = abstractProductions[node];

            prod.Alternatives.AddRange(from a in node.Alternatives select VisitAbstract(a));

            return prod;
        }

        public AbstractAlternative VisitAbstract(PAlternative node)
        {
            string name = node.Production.Identifier.Text.ToCamelCase();
            if (node.HasAlternativename)
                name = node.Alternativename.Name.Text.ToCamelCase() + name;
            name = "A" + name;

            AbstractAlternative alt = new AbstractAlternative(name, from e in node.Elements select VisitAbstract(e));
            abstractAlternatives.Add(node, alt);
            return alt;
        }
        public AbstractAlternative.Element VisitAbstract(PElement node)
        {
            string name = node.Elementid.Identifier.Text.ToCamelCase();

            if (node.HasElementname)
                name = node.Elementname.Name.Text;
            else if (node.IsList)
                name += "s";

            var mod = node.Modifier.GetModifier();
            var id = node.Elementid.Identifier;

            if (id.IsPProduction)
                return new AbstractAlternative.ProductionElement(name.ToCamelCase(), abstractProductions[id.AsPProduction], mod);
            else if (id.IsPToken)
                return new AbstractAlternative.TokenElement(name.ToCamelCase(), tokens[id.AsPToken], mod);
            else
                throw new ArgumentException("Element must must refer to either an ast node or a token.");
        }

        public IEnumerable<Production> Visit(PProductions node)
        {
            return from p in node.Productions select Visit(p);
        }
        public Production Visit(PProduction node)
        {
            var prod = productions[node];

            prod.Alternatives.AddRange(from a in node.Alternatives select Visit(a));

            return prod;
        }

        public Alternative Visit(PAlternative node)
        {
            var elements = new Alternative.Element[node.Elements.Count];

            for (int i = 0; i < elements.Length; i++)
            {
                var e = node.Elements[i];
                elements[i] = Visit(e);
                this.elements.Add(e, elements[i]);
            }

            if (node.HasTranslation)
                return new Alternative(elements, Visit(node.Translation));
            else
            {
                var translations = new Translation[elements.Length];

                for (int i = 0; i < translations.Length; i++)
                {
                    translations[i] = new ElementTranslation(elements[i]);
                    if (elements[i].Modifier == Modifiers.OneOrMany || elements[i].Modifier == Modifiers.ZeroOrMany)
                        translations[i] = new ListTranslation(new Translation[] { translations[i] });
                }

                var newTranslation = new NewTranslation(abstractAlternatives[node.AstTarget.Alternative], translations);

                return new Alternative(elements, newTranslation);
            }
        }
        public Alternative.Element Visit(PElement node)
        {
            var mod = node.Modifier.GetModifier();

            if (node.Elementid.Identifier.IsPToken)
            {
                var token = tokens[node.Elementid.Identifier.AsPToken];
                return new Alternative.TokenElement(token, mod);
            }
            else if (node.Elementid.Identifier.IsPProduction)
            {
                var prod = productions[node.Elementid.Identifier.AsPProduction];
                return new Alternative.ProductionElement(prod, mod);
            }
            else
                throw new InvalidOperationException("Unknown element target.");
        }

        #region Translations

        public Translation Visit(PTranslation node)
        {
            return Visit((dynamic)node);
        }

        public Translation Visit(AFullTranslation node)
        {
            return Visit(node.Translation);
        }
        public Translation Visit(ANewTranslation node)
        {
            return new NewTranslation(abstractAlternatives[node.Target.Alternative], from t in node.Arguments select Visit(t));
        }
        public Translation Visit(ANewalternativeTranslation node)
        {
            return new NewTranslation(abstractAlternatives[node.Target.Alternative], from t in node.Arguments select Visit(t));
        }
        public Translation Visit(AListTranslation node)
        {
            return new ListTranslation(from t in node.Elements select Visit(t));
        }
        public Translation Visit(ANullTranslation node)
        {
            return new NullTranslation();
        }
        public Translation Visit(AIdTranslation node)
        {
            return new ElementTranslation(elements[node.Identifier.AsPElement]);
        }
        public Translation Visit(AIddotidTranslation node)
        {
            return new ElementTranslation(elements[node.Identifier.AsPElement]);
        }

        #endregion

        public IEnumerable<Highlighting> Visit(PHighlightrules node)
        {
            return from h in node.Highlightrules select Visit(h);
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
    }
}
