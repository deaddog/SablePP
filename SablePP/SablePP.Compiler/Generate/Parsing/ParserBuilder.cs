﻿using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate;
using SablePP.Tools.Generate.CSharp;
using SablePP.Tools.Nodes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SablePP.Compiler.Generate.Parsing
{
    public class ParserBuilder : GenerateVisitor
    {
        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private ClassElement classElement;

        private ParserBuilder()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
        }

        public static FileElement BuildCode(string originalFile, Start<PGrammar> astRoot)
        {
            string code;
            using (StreamReader reader = new StreamReader(originalFile))
                code = reader.ReadToEnd();

            ParserBuilder n = new ParserBuilder();
            n.Visit(astRoot);

            n.classElement.EmitNewline();
            n.classElement.EmitField("private static int[][][] actionTable", getActionTable(code));
            n.classElement.EmitField("private static int[][][] gotoTable", getGotoTable(code));
            n.classElement.EmitField("private static string[] errorMessages", getErrorMessages(code));
            n.classElement.EmitField("private static int[] errors", getErrors(code));

            return n.fileElement;
        }

        #region Table Extraction

        private static PatchElement getActionTable(string parserCode)
        {
            return getTable(parserCode, @"int\[\]\[\]\[\] actionTable[^{]+(?<table>{[^;]*);");
        }

        private static PatchElement getGotoTable(string parserCode)
        {
            return getTable(parserCode, @"int\[\]\[\]\[\] gotoTable[^{]+(?<table>{[^;]*);");
        }

        private static PatchElement getErrorMessages(string parserCode)
        {
            return getTable(parserCode, "String\\[\\] errorMessages[^{]*(?<table>([^\"}]*\"[^\"]*\")+[^}]*\\});");
        }

        private static PatchElement getErrors(string parserCode)
        {
            return getTable(parserCode, @"int\[\] errors[^{]+(?<table>{[^;]*);");
        }

        private static PatchElement getTable(string code, string regex)
        {
            return getTable(Regex.Match(code, regex).Groups["table"].Value);
        }
        private static PatchElement getTable(string code)
        {
            PatchElement element = new PatchElement();

            string[] strings = getNonEmpty(code.Split(new char[] { '\r', '\n' })).ToArray();

            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].StartsWith("}"))
                    element.DecreaseIndentation();

                element.Emit(strings[i]);
                if (i < strings.Length - 1)
                    element.EmitNewLine();

                if (strings[i].EndsWith("{"))
                    element.IncreaseIndentation();
            }

            return element;
        }

        private static IEnumerable<string> getNonEmpty(IEnumerable<string> collection)
        {
            foreach (var s in collection)
            {
                var t = s.Trim();
                if (t.Length > 0)
                    yield return t;
            }
        }

        #endregion

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            string packageName = node.PackageName;

            fileElement.Add(nameElement = new NameSpaceElement(packageName + ".Parsing"));
            fileElement.Using.Add(packageName + ".Nodes");
            fileElement.Using.Add(ToolsNamespace.Nodes);

            nameElement.Add(classElement = new ClassElement("public class Parser : {0}.Parser<{1}>", ToolsNamespace.Parsing, node.RootProduction));

            TokenIndexBuilder indexer = new TokenIndexBuilder(classElement);
            indexer.Visit(node.Tokens);

            classElement.Add(new MethodElement(
                "public Parser(SablePP.Tools.Lexing.ILexer lexer)",
                "base(lexer, actionTable, gotoTable, errorMessages, errors)", true));

            classElement.Add(reduceMethod = new MethodElement("protected override void reduce(int index)"));
            reduceMethod.Body.EmitLine("switch (index)");
            reduceMethod.Body.EmitLine("{");
            reduceMethod.Body.IncreaseIndentation();

            Visit(node.Productions);

            reduceMethod.Body.DecreaseIndentation();
            reduceMethod.Body.EmitLine("}");
        }

        private int reduceCase = 0;
        private int productionCase = 0;
        private MethodElement reduceMethod;

        private SimpleReductionBuilder simple = new SimpleReductionBuilder();
        private TranslationReductionBuilder translation = new TranslationReductionBuilder();

        public override void OutAProduction(AProduction node)
        {
            productionCase++;
        }

        public override void CaseAAlternative(AAlternative node)
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
