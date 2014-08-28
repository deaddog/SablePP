﻿using SablePP.Compiler.Nodes;
using SablePP.Generate;
using SablePP.Generate.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Compiler
{
    public class GrammarBuilder
    {
        private Dictionary<PHelper, Helper> helpers;
        private Dictionary<PState, State> states;
        private Dictionary<PToken, Token> tokens;
        private Dictionary<PProduction, Production> productions;
        private Dictionary<PProduction, AbstractProduction> abstractProductions;
        private GrammarBuilder()
        {
            this.helpers = new Dictionary<PHelper, Helper>();
            this.states = new Dictionary<PState, State>();
            this.tokens = new Dictionary<PToken, Token>();
            this.productions = new Dictionary<PProduction, Production>();
            this.abstractProductions = new Dictionary<PProduction, AbstractProduction>();
        }

        public static Grammar BuildSableCCGrammar(SablePP.Tools.Nodes.Start<PGrammar> grammar)
        {
            GrammarBuilder builder = new GrammarBuilder();
            return builder.Visit(grammar.Root as AGrammar);
        }

        public Grammar Visit(AGrammar node)
        {
            var package = node.PackageName;
            var helpers = Visit(node.Helpers).ToArray();
            var states = Visit(node.States).ToArray();
            var tokens = Visit(node.Tokens).ToArray();

            foreach (var p in node.Astproductions.Productions)
            {
                string name = "P" + p.Identifier.Text.ToCamelCase();
                AbstractProduction prod = new AbstractProduction(name);
                abstractProductions.Add(p, prod);
            }

            var absProds = VisitAbstract(node.Astproductions).ToArray();

            foreach (var p in node.Productions.Productions)
            {
                Production prod;
                if (p.HasProdtranslation)
                    prod = new Production(Visit(p.Prodtranslation));
                else
                {
                    AbstractProduction absProd = abstractProductions.FirstOrDefault(a => a.Key.Identifier.Text == p.Identifier.Text).Value;
                    prod = new Production(new Production.ProductionTranslation(absProd, Modifiers.Single));
                }
                productions.Add(p, prod);
            }

            var prods = Visit(node.Productions).ToArray();
            throw new NotImplementedException();
        }

        public Production.ProductionTranslation Visit(PProdtranslation node)
        {
            Modifiers mod = Modifiers.Single;

            if (node.HasModifier)
                mod = Visit(node.Modifier);

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
                token = new Token(name, Visit(node.Regex));
            else
                token = new Token(name, Visit(node.Regex), from s in node.Statelist select Visit(s));

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
            return new ModifiedRegExp(Visit(node.Regex), Visit(node.Modifier));
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

        public Modifiers Visit(PModifier node)
        {
            if (node is AQuestionModifier)
                return Modifiers.Optional;
            else if (node is AStarModifier)
                return Modifiers.ZeroOrMany;
            else if (node is APlusModifier)
                return Modifiers.OneOrMany;
            else
                throw new ArgumentException("Unknown modifier: " + node);
        }

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

            return new AbstractAlternative(name, from e in node.Elements select VisitAbstract(e));
        }

        public AbstractAlternative.Element VisitAbstract(PElement node)
        {
            string name = node.Elementid.Identifier.Text.ToCamelCase();

            if (node.HasElementname)
                name = node.Elementname.Name.Text;
            else if (node.IsList)
                name += "s";

            var mod = node.HasModifier ? Visit(node.Modifier) : Modifiers.Single;
            var id = node.Elementid.Identifier;

            if (id.IsPProduction)
                return new AbstractAlternative.ProductionElement(name, abstractProductions[id.AsPProduction], mod);
            else if (id.IsPToken)
                return new AbstractAlternative.TokenElement(name, tokens[id.AsPToken], mod);
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
            throw new NotImplementedException();
        }
    }
}
