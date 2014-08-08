using System;
using System.Drawing;
using System.Text;

using SablePP.Compiler.Nodes;

using SablePP.Tools.Generate;
using SablePP.Tools.Generate.CSharp;
using SablePP.Tools.Nodes;

namespace SablePP.Compiler.Generate
{
    public class CompilerExecuterBuilder : GenerateVisitor
    {
        public static FileElement Build(Start<PGrammar> root)
        {
            string packageName = root.Root.PackageName;
            string rootProduction = root.Root.RootProduction;

            FileElement fileElement = new FileElement();
            fileElement.Using.Add("System.Drawing");
            fileElement.Using.Add("System.IO");

            fileElement.Using.EmitNewline();

            fileElement.Using.Add(ToolsNamespace.Nodes);

            fileElement.Using.EmitNewline();

            fileElement.Using.Add(packageName + ".Lexing");
            fileElement.Using.Add(packageName + ".Nodes");
            fileElement.Using.Add(packageName + ".Parsing");

            fileElement.Using.EmitNewline();

            fileElement.Using.Add("FastColoredTextBoxNS");

            ClassElement classElement = CreateClass(fileElement, packageName, rootProduction);
            CreateLexerMethod(classElement);

            classElement.EmitNewline();
            CreateParserMethod(classElement);

            PatchElement styleRules;

            classElement.EmitNewline();
            CreateSimpleSyntaxMethod(classElement, out styleRules);

            if (root.Root is AGrammar && (root.Root as AGrammar).HasHighlightrules)
            {
                CompilerExecuterBuilder builder = new CompilerExecuterBuilder(classElement, styleRules);
                builder.Visit((root.Root as AGrammar).Highlightrules);
            }

            return fileElement;
        }

        #region Class setup

        private static ClassElement CreateClass(FileElement fileElement, string packageName, string rootProduction)
        {
            NameSpaceElement name = new NameSpaceElement(packageName);
            fileElement.Add(name);

            ClassElement executerClass = new ClassElement("public partial class CompilerExecuter : {1}.CompilerExecuter<{0}, Lexer, Parser>", rootProduction, ToolsNamespace.Root);
            name.Add(executerClass);

            return executerClass;
        }

        private static void CreateLexerMethod(ClassElement classElement)
        {
            MethodElement imMethod = new MethodElement("public override Lexer GetLexer(TextReader reader)");
            imMethod.Body.EmitLine("return new Lexer(reader);");

            classElement.Add(imMethod);
        }
        private static void CreateParserMethod(ClassElement classElement)
        {
            MethodElement imMethod = new MethodElement("public override Parser GetParser(" + ToolsNamespace.Lexing + ".ILexer lexer)");
            imMethod.Body.EmitLine("return new Parser(lexer);");

            classElement.Add(imMethod);
        }
        private static void CreateSimpleSyntaxMethod(ClassElement classElement, out PatchElement rulesElement)
        {
            MethodElement method = new MethodElement("public override Style GetSimpleStyle(Token token)");

            rulesElement = new PatchElement();
            method.Body.InsertElement(rulesElement);
            method.Body.EmitLine("return null;");

            classElement.Add(method);
        }

        #endregion

        private ClassElement builderClass;
        private PatchElement styleRulesElement;
        private PatchElement styleField;

        private Color? textColor;
        private Color? backgroundColor;
        private FontStyle fontStyle;

        private string currentStyle;

        private CompilerExecuterBuilder(ClassElement builderClass, PatchElement styleRulesElement)
        {
            this.builderClass = builderClass;
            this.styleRulesElement = styleRulesElement;
        }

        public override void CaseAHighlightrule(AHighlightrule node)
        {
            currentStyle = node.Name.Text + "Style";

            PatchElement field;
            builderClass.EmitField("private TextStyle " + currentStyle, out field);

            styleField = new PatchElement();
            field.Emit("new TextStyle(");
            field.InsertElement(styleField);
            field.Emit(")");

            textColor = null;
            backgroundColor = null;
            fontStyle = FontStyle.Regular;

            PatchElement temp = styleRulesElement;
            styleRulesElement = new PatchElement();

            temp.Emit("if (");
            temp.InsertElement(styleRulesElement);

            for (int i = 0; i < node.Tokens.Count; i++)
            {
                if (i > 0)
                    styleRulesElement.Emit(" || ");

                styleRulesElement.Emit("token is {0}", node.Tokens[i].AsPToken.ClassName);
            }

            temp.EmitLine(")");
            temp.IncreaseIndentation();
            temp.EmitLine("return {0};", currentStyle);
            temp.DecreaseIndentation();
            styleRulesElement = temp;

            Visit(node.Styles);

            EmitNewBrush(textColor);
            styleField.Emit(", ");
            EmitNewBrush(backgroundColor);
            styleField.Emit(", ");

            if (fontStyle == FontStyle.Regular)
                styleField.Emit("FontStyle.Regular");
            else
            {
                bool first = true;
                foreach (FontStyle s in Enum.GetValues(typeof(FontStyle)))
                    if (fontStyle.HasFlag(s) && s != FontStyle.Regular)
                    {
                        if (!first) styleField.Emit(" | ");
                        styleField.Emit("FontStyle.{0}", s);

                        first = false;
                    }
            }
        }

        private void EmitNewBrush(Color? color)
        {
            if (color.HasValue)
                styleField.Emit("new SolidBrush(Color.FromArgb({0}, {1}, {2}))", color.Value.R, color.Value.G, color.Value.B);
            else
                styleField.Emit("null");
        }

        private Color GetColor(ARgbColor node)
        {
            return Color.FromArgb(node.Red.Value, node.Green.Value, node.Blue.Value);
        }
        private Color GetColor(AHsvColor node)
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
        private Color GetColor(AHexColor node)
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

        public override void CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            backgroundColor = GetColor((dynamic)node.Color);
        }
        public override void CaseATextHighlightStyle(ATextHighlightStyle node)
        {
            textColor = GetColor((dynamic)node.Color);
        }

        public override void CaseAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            fontStyle |= FontStyle.Italic;
        }
        public override void CaseABoldHighlightStyle(ABoldHighlightStyle node)
        {
            fontStyle |= FontStyle.Bold;
        }
    }
}
