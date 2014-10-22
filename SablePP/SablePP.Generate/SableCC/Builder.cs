using SablePP.Generate.RegularExpressions;
using SablePP.Generate.Translations;
using SablePP.Tools;
using SablePP.Tools.Generate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.SableCC
{
    internal class Builder
    {
        private PatchElement root;
        private SafeNameDictionary variables;

        private Builder()
        {
            this.root = new PatchElement();

            this.variables = new SafeNameDictionary();
        }

        public static void BuildToFile(Grammar grammar, string filepath)
        {
            Builder builder = new Builder();
            builder.Start(grammar);
            builder.root.ToFile(filepath, Encoding.UTF8, "  ");
        }

        private void Start(Grammar grammar)
        {
            root.EmitLine("Package {0};", grammar.Namespace);
            root.EmitLine();

            if (grammar.Helpers.Length > 0)
            {
                root.EmitLine("Helpers");
                root.IncreaseIndentation();
                for (int i = 0; i < grammar.Helpers.Length; i++)
                {
                    variables.Add("helper", grammar.Helpers[i]);

                    Emit(grammar.Helpers[i]);
                }
                root.DecreaseIndentation();
                root.EmitLine();
            }

            if (grammar.States.Length > 0)
            {
                root.Emit("States ");
                for (int i = 0; i < grammar.States.Length; i++)
                {
                    string name = variables.Add("state", grammar.States[i]);

                    if (i > 0) Emit(", ");
                    Emit(name);
                }
                root.EmitLine(";");
                root.EmitLine();
            }

            if (grammar.Tokens.Length > 0)
            {
                root.EmitLine("Tokens");
                root.IncreaseIndentation();
                for (int i = 0; i < grammar.Tokens.Length; i++)
                {
                    variables.Add("token", grammar.Tokens[i]);

                    Emit(grammar.Tokens[i]);
                }
                root.DecreaseIndentation();
                root.EmitLine();
            }

            var ignored = GetIgnoredTokens(grammar);
            if (ignored.Length > 0)
            {
                root.Emit("Ignored Tokens  ");
                EmitEach(ignored, t => Emit(variables[t]), ", ");
                root.EmitLine(";");
                root.EmitLine();
            }

            for (int i = 0; i < grammar.Productions.Length; i++)
                variables.Add("prod", grammar.Productions[i]);

            if (grammar.Productions.Length > 0)
            {
                root.EmitLine("Productions");
                root.IncreaseIndentation();
                for (int i = 0; i < grammar.Productions.Length; i++)
                    Emit(grammar.Productions[i]);
                root.DecreaseIndentation();
                root.EmitLine();
            }
        }

        private Token[] GetIgnoredTokens(Grammar grammar)
        {
            return grammar.Tokens.Where(t => t.Ignored).ToArray();
        }

        private void Emit(string text, params object[] args)
        {
            root.Emit(text, args);
        }

        private void EmitEach<T>(T[] array, Action<T> emit, string separator)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0) Emit(separator);
                emit(array[i]);
            }
        }

        private void Emit(Helper helper)
        {
            Emit("{0} = ", variables[helper]);
            Emit(helper.Expression);
            root.EmitLine(";");
        }

        private void Emit(Token token)
        {
            if (token.States.Length > 0)
            {
                Emit("{ ");
                EmitEach(token.States, Emit, ", ");
                Emit(" } ");
            }

            Emit("{0} = ", variables[token]);
            if (token.Expression is LiteralRegExp)
            {
                LiteralRegExp lit = token.Expression as LiteralRegExp;
                string text = lit.IsChar ? lit.Char.ToString() : lit.Content;
                Emit(new OrRegExp(new RegExp[] { new LiteralRegExp(text), new LiteralRegExp(text) }));
            }
            else
                Emit(token.Expression);
            root.EmitLine(";");
        }

        private void Emit(Token.TokenState state)
        {
            if (state.Translates)
                Emit("{0} -> {1}", variables[state.From], variables[state.To]);
            else
                Emit("{0}", variables[state.From]);
        }

        #region Regular expressions

        private void Emit(RegExp expression)
        {
            Emit((dynamic)expression);
        }
        private void Emit(ConcatenatedRegExp expression)
        {
            Emit(" (");
            for (int i = 0; i < expression.Expressions.Length; i++)
            {
                if (i > 0) Emit(" ");
                Emit(expression.Expressions[i]);
            }
            Emit(") ");
        }
        private void Emit(LiteralRegExp expression)
        {
            if (expression.IsChar)
                Emit(@"{0}", (int)expression.Char.Value);
            else
                Emit("\'{0}\'", expression.Content);
        }
        private void Emit(ModifiedRegExp expression)
        {
            Emit(" (");
            Emit(expression.Expression);
            Emit(") ");
            switch (expression.Modifier)
            {
                case Modifiers.Optional: root.Emit("?"); break;
                case Modifiers.ZeroOrMany: root.Emit("*"); break;
                case Modifiers.OneOrMany: root.Emit("+"); break;
            }
        }
        private void Emit(OrRegExp expression)
        {
            Emit(" (");
            for (int i = 0; i < expression.Expressions.Length; i++)
            {
                if (i > 0) root.Emit(" | ");
                Emit(expression.Expressions[i]);
            }
            Emit(") ");
        }
        private void Emit(ReferenceRegExp expression)
        {
            root.Emit(variables[expression.ReferencedHelper]);
        }
        private void Emit(SetRegExp expression)
        {
            root.Emit("[");
            Emit(expression.From);
            switch (expression.SetType)
            {
                case SetRegExp.SetTypes.Union:
                    root.Emit(" + ");
                    break;
                case SetRegExp.SetTypes.Complement:
                    root.Emit(" - ");
                    break;
                case SetRegExp.SetTypes.Range:
                    root.Emit(" .. ");
                    break;
                default:
                    break;
            }
            Emit(expression.To);
            root.Emit("]");
        }

        #endregion

        private void Emit(Production production)
        {
            variables.OpenScope();
            for (int i = 0; i < production.Alternatives.Count; i++)
                variables.Add("alt", production.Alternatives[i]);

            Emit("{0} ", variables[production]);
            root.EmitLine();
            root.IncreaseIndentation();
            root.Emit("= ");
            Emit(production.Alternatives[0]);
            root.EmitLine();
            for (int i = 1; i < production.Alternatives.Count; i++)
            {
                Emit("| ");
                Emit(production.Alternatives[i]);
                root.EmitLine();
            }
            root.EmitLine(";");
            root.DecreaseIndentation();
            variables.CloseScope();
        }
        private void Emit(Alternative alternative)
        {
            variables.OpenScope();
            Emit("{{{0}}} ", variables[alternative]);
            EmitEach(alternative.Elements, e => Emit(e), " ");
            variables.CloseScope();
        }
        private void Emit(Alternative.Element element)
        {
            variables.Add("e", element);
            Emit((dynamic)element);
        }
        private void Emit(Alternative.TokenElement element)
        {
            Emit("[{0}]:{1}", variables[element], variables[element.Token]);

            switch (element.Modifier)
            {
                case Modifiers.Optional: Emit("?"); break;
                case Modifiers.ZeroOrMany: Emit("*"); break;
                case Modifiers.OneOrMany: Emit("+"); break;
            }
        }
        private void Emit(Alternative.ProductionElement element)
        {
            Emit("[{0}]:{1}", variables[element], variables[element.Production]);

            switch (element.Modifier)
            {
                case Modifiers.Optional: Emit("?"); break;
                case Modifiers.ZeroOrMany: Emit("*"); break;
                case Modifiers.OneOrMany: Emit("+"); break;
            }
        }
    }
}
