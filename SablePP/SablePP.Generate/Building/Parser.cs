using SablePP.Tools.Generate.CSharp;
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

        public override void Visit(Token[] node)
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
                if(!t.Ignored)
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
        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            string packageName = node.PackageName;

            fileElement.Add(nameElement = new NameSpaceElement(packageName + ".Parsing"));
            fileElement.Using.Add(packageName + ".Nodes");
            fileElement.Using.Add(SablePP.Generate.Namespaces.Nodes);

            nameElement.Add(classElement = new ClassElement("public class Parser : {0}.Parser<{1}>", SablePP.Generate.Namespaces.Parsing, node.RootProduction));

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

            reduceMethod.Body.DecreaseIndentation();
            reduceMethod.Body.EmitLine("}");
        }

        private static string[] getListTypes(AGrammar grammar)
        {
            List<string> types = new List<string>();
            List<IDeclaration> declarations = new List<IDeclaration>();

            foreach (var p in grammar.Productions.Productions)
                foreach (var a in p.Alternatives)
                    foreach (var e in a.Elements)
                    {
                        var t = e.ElementType;
                        if (t == ElementTypes.Plus || t == ElementTypes.Star)
                        {
                            var decl = (e.Elementid.Identifier as DeclarationIdentifier).Declaration;
                            if (!declarations.Contains(decl))
                            {
                                types.Add(e.ClassName);
                                declarations.Add(decl);
                            }
                        }
                    }

            return types.ToArray();
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
