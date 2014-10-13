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
        private ScopedDictionary<string, object> elements;
        private Dictionary<object, string> names;
        private SafeNameDictionary<object> safename;

        private Builder()
        {
            this.root = new PatchElement();

            this.elements = new ScopedDictionary<string, object>();
            this.names = new Dictionary<object, string>();
            this.safename = new SafeNameDictionary<object>(elements);
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
                    string name = safename.Add("helper", grammar.Helpers[i]);
                    names.Add(grammar.Helpers[i], name);

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
                    string name = safename.Add("state", grammar.States[i]);
                    names.Add(grammar.States[i], name);

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
                    string name = safename.Add("token", grammar.Tokens[i]);
                    names.Add(grammar.Tokens[i], name);

                    Emit(grammar.Tokens[i]);
                }
                root.DecreaseIndentation();
                root.EmitLine();
            }

            var ignored = GetIgnoredTokens(grammar);
            if (ignored.Length > 0)
            {
                root.Emit("Ignored Tokens  ");
                EmitEach(ignored, t => Emit(names[t]), ", ");
                root.EmitLine(";");
                root.EmitLine();
            }

            for (int i = 0; i < grammar.AbstractProductions.Length; i++)
                names.Add(grammar.AbstractProductions[i], safename.Add("abstract", grammar.AbstractProductions[i]));
            for (int i = 0; i < grammar.Productions.Length; i++)
                names.Add(grammar.Productions[i], safename.Add("prod", grammar.Productions[i]));

            var temp = root;
            var abs = root = new PatchElement();
            if (grammar.AbstractProductions.Length > 0)
            {
                root.EmitLine("Abstract Syntax Tree");
                root.IncreaseIndentation();
                for (int i = 0; i < grammar.AbstractProductions.Length; i++)
                    Emit(grammar.AbstractProductions[i]);
                root.DecreaseIndentation();
                root.EmitLine();
            }

            var prod = root = new PatchElement();
            if (grammar.Productions.Length > 0)
            {
                root.EmitLine("Productions");
                root.IncreaseIndentation();
                for (int i = 0; i < grammar.Productions.Length; i++)
                    Emit(grammar.Productions[i]);
                root.DecreaseIndentation();
                root.EmitLine();
            }

            temp.InsertElement(prod);
            temp.InsertElement(abs);
            root = temp;
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
            Emit("{0} = ", names[helper]);
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

            Emit("{0} = ", names[token]);
            Emit(token.Expression);
            root.EmitLine(";");
        }

        private void Emit(Token.TokenState state)
        {
            if (state.Translates)
                Emit("{0} -> {1}", names[state.From], names[state.To]);
            else
                Emit("{0}", names[state.From]);
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
            root.Emit(names[expression.ReferencedHelper]);
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
            elements.OpenScope();
            for (int i = 0; i < production.Alternatives.Count; i++)
                names.Add(production.Alternatives[i], safename.Add("alt", production.Alternatives[i]));

            Emit("{0} ", names[production]);
            Emit(production.Translation);
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
            elements.CloseScope();
        }
        private void Emit(Production.ProductionTranslation translation)
        {
            Emit("{ -> ");

            if (translation.HasToken)
                Emit(names[translation.Token]);
            else
                Emit(names[translation.Production]);

            switch (translation.Modifier)
            {
                case Modifiers.Optional: Emit("?"); break;
                case Modifiers.ZeroOrMany: Emit("*"); break;
                case Modifiers.OneOrMany: Emit("+"); break;
            }

            Emit(" }");
        }
        private void Emit(Alternative alternative)
        {
            elements.OpenScope();
            Emit("{{{0}}} ", names[alternative]);
            EmitEach(alternative.Elements, e => Emit(e), " ");
            elements.CloseScope();
        }
        private void Emit(Alternative.Element element)
        {
            names.Add(element, safename.Add("e", element));
            Emit((dynamic)element);
        }
        private void Emit(Alternative.TokenElement element)
        {
            Emit("[{0}]:{1}", names[element], names[element.Token]);

            switch (element.Modifier)
            {
                case Modifiers.Optional: Emit("?"); break;
                case Modifiers.ZeroOrMany: Emit("*"); break;
                case Modifiers.OneOrMany: Emit("+"); break;
            }
        }
        private void Emit(Alternative.ProductionElement element)
        {
            Emit("[{0}]:{1}", names[element], names[element.Production]);

            switch (element.Modifier)
            {
                case Modifiers.Optional: Emit("?"); break;
                case Modifiers.ZeroOrMany: Emit("*"); break;
                case Modifiers.OneOrMany: Emit("+"); break;
            }
        }

        private void Emit(AbstractProduction production)
        {
            elements.OpenScope();
            for (int i = 0; i < production.Alternatives.Count; i++)
                names.Add(production.Alternatives[i], safename.Add("abstractalt", production.Alternatives[i]));

            root.EmitLine(" {0}", names[production]);
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
            elements.CloseScope();
        }
        private void Emit(AbstractAlternative alternative)
        {
            elements.OpenScope();
            Emit("{{{0}}} ", names[alternative]);
            EmitEach(alternative.Elements, e => Emit(e), " ");
            elements.CloseScope();
        }
        private void Emit(AbstractAlternative.Element element)
        {
            names.Add(element, safename.Add("e", element));
            Emit((dynamic)element);
        }
        private void Emit(AbstractAlternative.TokenElement element)
        {
            Emit("[{0}]:{1}", names[element], names[element.Token]);

            switch (element.Modifier)
            {
                case Modifiers.Optional: Emit("?"); break;
                case Modifiers.ZeroOrMany: Emit("*"); break;
                case Modifiers.OneOrMany: Emit("+"); break;
            }
        }
        private void Emit(AbstractAlternative.ProductionElement element)
        {
            Emit("[{0}]:{1}", names[element], names[element.Production]);

            switch (element.Modifier)
            {
                case Modifiers.Optional: Emit("?"); break;
                case Modifiers.ZeroOrMany: Emit("*"); break;
                case Modifiers.OneOrMany: Emit("+"); break;
            }
        }
    }
}
