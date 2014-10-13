using SablePP.Generate.Translations;
using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate.Building
{
    internal class Parser
    {
        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private ClassElement classElement;

        private Parser()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Collections.Generic");

            this.variables = new NameTable<object>(nameCounted);
        }

        private static IEnumerable<string> nameCounted(string x)
        {
            yield return x;
            int i = 2;
            while (true) yield return x + i++;
        }

        public static FileElement BuildCode(Grammar grammar, CompilationResult tables)
        {
            Parser parser = new Parser();
            parser.Visit(grammar);

            parser.classElement.EmitNewline();
            parser.classElement.EmitField("private static int[][][] actionTable", tables.ParserActionTable);
            parser.classElement.EmitField("private static int[][][] gotoTable", tables.ParserGotoTable);
            parser.classElement.EmitField("private static string[] errorMessages", tables.ParserErrorMessagesTable);
            parser.classElement.EmitField("private static int[] errors", tables.ParserErrorTable);

            return parser.fileElement;
        }

        public void Visit(Token[] node)
        {
            this.classElement.EmitRegionStart("Token Index", false);
            this.classElement.EmitNewline();

            MethodElement dyn;
            classElement.Add(dyn = new MethodElement("protected override int getTokenIndex(Token token)"));
            dyn.Body.EmitLine("return getIndex((dynamic)token);");

            classElement.EmitNewline();

            MethodElement none;
            classElement.Add(none = new MethodElement("private int getIndex(Token node)"));
            none.Body.EmitLine("return -1;");

            classElement.EmitNewline();

            int index = 0;
            foreach (var t in node)
                if (!t.Ignored)
                {
                    MethodElement m;
                    classElement.Add(m = new MethodElement("private int getIndex({0} node)", true, t.Name));
                    m.Body.EmitLine("return {0};", index++);
                }

            classElement.EmitNewline();

            classElement.Add(none = new MethodElement("private int getIndex(EOF node)"));
            none.Body.EmitLine("return {0};", index);

            this.classElement.EmitRegionEnd();
        }
        public void Visit(Grammar node)
        {
            fileElement.Add(nameElement = new NameSpaceElement(node.Namespace + ".Parsing"));
            fileElement.Using.Add(node.Namespace + ".Nodes");
            fileElement.Using.Add(SablePP.Generate.Namespaces.Nodes);

            nameElement.Add(classElement = new ClassElement("public class Parser : {0}.Parser<{1}>", SablePP.Generate.Namespaces.Parsing, node.AbstractProductions[0].Name));

            Visit(node.Tokens);

            classElement.Add(new MethodElement(
                "public Parser({0}.ILexer lexer)",
                "base(lexer, actionTable, gotoTable, errorMessages, errors)", true, SablePP.Generate.Namespaces.Lexing));

            classElement.Add(reduceMethod = new MethodElement("protected override void reduce(int index)"));
            reduceMethod.Body.EmitLine("switch (index)");
            reduceMethod.Body.EmitLine("{");
            reduceMethod.Body.IncreaseIndentation();

            Visit(node.Productions);

            reduceMethod.Body.DecreaseIndentation();
            reduceMethod.Body.EmitLine("}");
        }

        private static IEnumerable<string> getListTypes(Production[] productions)
        {
            List<object> declarations = new List<object>();

            foreach (var p in productions)
                foreach (var a in p.Alternatives)
                    foreach (var e in a.Elements)
                    {
                        if (e.Modifier == Modifiers.OneOrMany || e.Modifier == Modifiers.ZeroOrMany)
                        {
                            object decl;
                            string name;

                            if (e is Alternative.TokenElement)
                            {
                                decl = (e as Alternative.TokenElement).Token;
                                name = (e as Alternative.TokenElement).Token.Name;
                            }
                            else
                            {
                                decl = (e as Alternative.ProductionElement).Production;
                                var t = (e as Alternative.ProductionElement).Production.Translation;
                                if (t.HasToken)
                                    name = t.Token.Name;
                                else
                                    name = t.Production.Name;
                            }

                            if (!declarations.Contains(decl))
                            {
                                declarations.Add(decl);
                                yield return name;
                            }
                        }
                    }
        }

        private void Visit(Production[] node)
        {
            int productionCase = 0;
            for (; productionCase < node.Length; productionCase++)
                foreach (var alt in node[productionCase].Alternatives)
                {
                    variables.Clear();
                    var optionalElements = alt.Elements.Where(e => e.Modifier == Modifiers.Optional || e.Modifier == Modifiers.ZeroOrMany).ToList();
                    int baseCase = reduceCase;

                    for (int i = 0; i < 1 << optionalElements.Count; i++)
                        reduceMethod.Body.EmitLine("case {0}:", reduceCase++);

                    reduceMethod.Body.IncreaseIndentation();
                    reduceMethod.Body.EmitLine("{");
                    reduceMethod.Body.IncreaseIndentation();

                    for (int i = alt.Elements.Length - 1; i >= 0; i--)
                    {
                        var e = alt.Elements[i];
                        EmitPop(e, optionalElements.IndexOf(e), baseCase);
                    }

                    Visit(alt.Translation);
                    reduceMethod.Body.EmitLine("Push({0}, {1});", productionCase, variables[alt.Translation]);

                    reduceMethod.Body.DecreaseIndentation();
                    reduceMethod.Body.EmitLine("}");
                    reduceMethod.Body.EmitLine("break;");
                    reduceMethod.Body.DecreaseIndentation();
                }

            // Generate cases for handling list-building
            foreach (var type in getListTypes(node))
            {
                reduceMethod.Body.EmitLine("case {0}:", reduceCase++);
                reduceMethod.Body.IncreaseIndentation();
                reduceMethod.Body.EmitLine("Push({1}, new List<{0}>() {{ Pop<{0}>() }});", type, productionCase);
                reduceMethod.Body.EmitLine("break;");
                reduceMethod.Body.DecreaseIndentation();

                reduceMethod.Body.EmitLine("case {0}:", reduceCase++);
                reduceMethod.Body.IncreaseIndentation();
                reduceMethod.Body.EmitLine("{");
                reduceMethod.Body.IncreaseIndentation();
                reduceMethod.Body.EmitLine("{0} item = Pop<{0}>();", type);
                reduceMethod.Body.EmitLine("List<{0}> list = Pop<List<{0}>>();", type);
                reduceMethod.Body.EmitLine("list.Add(item);");
                reduceMethod.Body.EmitLine("Push({0}, list);", productionCase);
                reduceMethod.Body.DecreaseIndentation();
                reduceMethod.Body.EmitLine("}");
                reduceMethod.Body.EmitLine("break;");
                reduceMethod.Body.DecreaseIndentation();

                productionCase++;
            }
        }

        private void EmitPop(Alternative.Element element, int optionalIndex, int baseReduceCase)
        {
            string type = element.GetGeneratedName();
            bool list = element.GeneratesList();
            string name = variables.Add(type.ToLower() + (list ? "list" : ""), element);

            if (optionalIndex < 0)
                if (!list)
                    reduceMethod.Body.EmitLine("{0} {1} = Pop<{0}>();", type, name);
                else
                    reduceMethod.Body.EmitLine("List<{0}> {1} = Pop<List<{0}>>();", type, name);
            else
                if (!list)
                    reduceMethod.Body.EmitLine("{0} {1} = isOn({2}, index - {3}) ? Pop<{0}>() : null;", type, name, 1 << optionalIndex, baseReduceCase);
                else
                    reduceMethod.Body.EmitLine("List<{0}> {1} = isOn({2}, index - {3}) ? Pop<List<{0}>>() : new List<{0}>();", type, name, 1 << optionalIndex, baseReduceCase);
        }

        private int reduceCase = 0;
        private MethodElement reduceMethod;

        private NameTable<object> variables;

        private void Visit(Translation translation)
        {
            Visit((dynamic)translation);
        }

        private void Visit(ElementTranslation translation)
        {
            variables[translation] = variables[translation.Element];
        }
        private void Visit(ListTranslation translation)
        {
            string type = translation.GetListElementType();
            if (type == null)
                throw new InvalidOperationException("Unable to determine type of elements in list.");

            for (int i = 0; i < translation.Elements.Length; i++)
                Visit(translation.Elements[i]);

            string name = variables.Add(type.ToLower() + "list", translation);
            reduceMethod.Body.EmitLine("List<{0}> {1} = new List<{0}>();", type, name);

            for (int i = 0; i < translation.Elements.Length; i++)
            {
                if (translation.Elements[i].GeneratesList())
                    reduceMethod.Body.EmitLine("{0}.AddRange({1});", name, variables[translation.Elements[i]]);
                else if (translation.Elements[i] is ElementTranslation && (translation.Elements[i] as ElementTranslation).Element.Modifier == Modifiers.Optional)
                    reduceMethod.Body.EmitLine("if ({1} != null) {0}.Add({1});", name, variables[translation.Elements[i]]);
                else
                    reduceMethod.Body.EmitLine("{0}.Add({1});", name, variables[translation.Elements[i]]);
            }
        }
        private void Visit(NewTranslation translation)
        {
            string name = variables.Add(translation.Alternative.Name.ToLower(), translation);

            foreach (var arg in translation.Arguments) Visit(arg);

            reduceMethod.Body.EmitLine("{0} {1} = new {0}(", translation.Alternative.Name, name);
            reduceMethod.Body.IncreaseIndentation();

            for (int i = 0; i < translation.Arguments.Length; i++)
            {
                reduceMethod.Body.EmitLine("{0}{1}",
                    variables[translation.Arguments[i]],
                    i < translation.Arguments.Length - 1 ? "," : "");
            }

            reduceMethod.Body.DecreaseIndentation();
            reduceMethod.Body.EmitLine(");");
        }
        private void Visit(NullTranslation translation)
        {
            variables[translation] = "null";
        }
    }
}
