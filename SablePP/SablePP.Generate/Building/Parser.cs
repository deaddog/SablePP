﻿using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    public class Parser
    {
        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private ClassElement classElement;

        private Parser()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Collections.Generic");
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

        private static IEnumerable<object> getListTypes(Production[] productions)
        {
            List<object> declarations = new List<object>();

            foreach (var p in productions)
                foreach (var a in p.Alternatives)
                    foreach (var e in a.Elements)
                    {
                        if (e.Modifier == Modifiers.OneOrMany || e.Modifier == Modifiers.ZeroOrMany)
                        {
                            object decl = e is Alternative.TokenElement ?
                                (object)(e as Alternative.TokenElement).Token :
                                (object)(e as Alternative.ProductionElement).Production;

                            if (!declarations.Contains(decl))
                            {
                                declarations.Add(decl);
                                yield return decl;
                            }
                        }
                    }
        }

        private void Visit(Production[] node)
        {
            int productionCase = 0;
            for (; productionCase < node.Length; productionCase++)
            {

            }

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

        private int reduceCase = 0;
        private MethodElement reduceMethod;

        private SimpleReductionBuilder simple = new SimpleReductionBuilder();
        private TranslationReductionBuilder translation = new TranslationReductionBuilder();

        public void CaseAAlternative(AAlternative node)
        {
            ReductionBuilder builder = node.HasTranslation ? (ReductionBuilder)translation : (ReductionBuilder)simple;

            foreach (var e in builder.GetElements(node, productionCase))
            {
                reduceMethod.Body.EmitLine("case {0}:", reduceCase);
                reduceMethod.Body.IncreaseIndentation();
                reduceMethod.Body.EmitLine("{");
                reduceMethod.Body.IncreaseIndentation();

                reduceMethod.Body.InsertElement(e);

                reduceMethod.Body.DecreaseIndentation();
                reduceMethod.Body.EmitLine("}");
                reduceMethod.Body.EmitLine("break;");
                reduceMethod.Body.DecreaseIndentation();

                reduceCase++;
            }
        }
    }
}
