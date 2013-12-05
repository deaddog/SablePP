using System;
using System.Drawing;
using System.Text;

using SablePP.Compiler.Nodes;

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
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Drawing");
            fileElement.Using.Add("System.IO");

            fileElement.Using.EmitNewline();

            fileElement.Using.Add(ToolsNamespace.Root);
            fileElement.Using.Add(ToolsNamespace.Error);
            fileElement.Using.Add(ToolsNamespace.Lexing);
            fileElement.Using.Add(ToolsNamespace.Nodes);
            fileElement.Using.Add(ToolsNamespace.Parsing);

            fileElement.Using.EmitNewline();

            fileElement.Using.Add(packageName + ".Lexing");
            fileElement.Using.Add(packageName + ".Nodes");
            fileElement.Using.Add(packageName + ".Parsing");

            fileElement.Using.EmitNewline();

            fileElement.Using.Add("FastColoredTextBoxNS");

            ClassElement classElement = CreateClass(fileElement, packageName, rootProduction);
            CreateLexerMethod(classElement);

            classElement.EmitNewLine();
            CreateParserMethod(classElement);

            InlineElement styleRules;

            classElement.EmitNewLine();
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
            NameSpaceElement name = fileElement.CreateNamespace(packageName);
            return name.CreateClass("CompilerExecuter", AccessModifiers.@public | AccessModifiers.partial, "CompilerExecuter<" + rootProduction + ", Lexer, Parser>");
        }

        private static void CreateLexerMethod(ClassElement classElement)
        {
            var imMethod = classElement.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "GetLexer", "Lexer");
            imMethod.Parameters.Add("reader", "TextReader");

            imMethod.EmitReturn();
            imMethod.EmitNew();
            imMethod.EmitIdentifier("Lexer");
            using (var par = imMethod.EmitParenthesis())
                par.EmitIdentifier("reader");
            imMethod.EmitSemicolon(true);
        }
        private static void CreateParserMethod(ClassElement classElement)
        {
            var imMethod = classElement.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "GetParser", "Parser");
            imMethod.Parameters.Add("lexer", "ILexer");

            imMethod.EmitReturn();
            imMethod.EmitNew();
            imMethod.EmitIdentifier("Parser");
            using (var par = imMethod.EmitParenthesis())
                par.EmitIdentifier("lexer");
            imMethod.EmitSemicolon(true);
        }
        private static void CreateSimpleSyntaxMethod(ClassElement classElement, out InlineElement rulesElement)
        {
            var method = classElement.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "GetSimpleStyle", "Style");
            method.Parameters.Add("token", "Token");
            rulesElement = new InlineElement();
            method.InsertInline(rulesElement);
            method.EmitReturn();
            method.EmitNull();
            method.EmitSemicolon(true);
        }

        #endregion

        private ClassElement builderClass;
        private ExecutableElement styleRulesElement;
        private ExecutableElement styleField;

        private Color? textColor;
        private Color? backgroundColor;
        private FontStyle fontStyle;

        private string currentStyle;

        private CompilerExecuterBuilder(ClassElement builderClass, InlineElement styleRulesElement)
        {
            this.builderClass = builderClass;
            this.styleRulesElement = styleRulesElement;
        }

        public override void CaseAHighlightrule(AHighlightrule node)
        {
            currentStyle = node.Name.Text + "Style";

            InlineElement field;
            builderClass.EmitField(currentStyle, "TextStyle", AccessModifiers.@private, out field);

            field.EmitNew();
            field.EmitIdentifier("TextStyle");
            styleField = field.EmitParenthesis();

            textColor = null;
            backgroundColor = null;
            fontStyle = FontStyle.Regular;

            InlineElement temp = styleRulesElement as InlineElement;
            styleRulesElement = temp.EmitIf();
            Visit((dynamic)node.Tokens);
            temp.EmitNewLine();
            temp.IncreaseIndentation();
            temp.EmitReturn();
            temp.EmitIdentifier(currentStyle);
            temp.EmitSemicolon(true);
            temp.DecreaseIndentation();
            styleRulesElement = temp;

            Visit((dynamic)node.List);

            EmitNewBrush(textColor);
            styleField.EmitComma();
            EmitNewBrush(backgroundColor);
            styleField.EmitComma();

            if (fontStyle == FontStyle.Regular)
            {
                styleField.EmitIdentifier("FontStyle");
                styleField.EmitPeriod();
                styleField.EmitIdentifier("Regular");
            }
            else
            {
                bool first = true;
                foreach (FontStyle s in Enum.GetValues(typeof(FontStyle)))
                    if (fontStyle.HasFlag(s) && s != FontStyle.Regular)
                    {
                        if (!first) styleField.EmitBinaryOr();
                        styleField.EmitIdentifier("FontStyle");
                        styleField.EmitPeriod();
                        styleField.EmitIdentifier(s.ToString());

                        first = false;
                    }
            }
        }

        public override void CaseAIdentifierList(AIdentifierList node)
        {
            PListitem[] temp = new PListitem[node.Listitem.Count];
            node.Listitem.CopyTo(temp, 0);
            for (int i = 0; i < temp.Length; i++)
            {
                if (i > 0)
                    styleRulesElement.EmitLogicOr();
                Visit((dynamic)temp[i]);
            }
        }

        public override void CaseTIdentifier(TIdentifier node)
        {
            styleRulesElement.EmitIdentifier("token");
            styleRulesElement.EmitIs();
            styleRulesElement.EmitIdentifier(node.AsToken.GeneratedName);
        }

        private void EmitNewBrush(Color? color)
        {
            if (color.HasValue)
            {
                styleField.EmitNew();
                styleField.EmitIdentifier("SolidBrush");
                using (var brushPar = styleField.EmitParenthesis())
                {
                    brushPar.EmitIdentifier("Color");
                    brushPar.EmitPeriod();
                    brushPar.EmitIdentifier("FromArgb");
                    using (var par = brushPar.EmitParenthesis())
                    {
                        par.EmitIntValue(color.Value.R);
                        par.EmitComma();
                        par.EmitIntValue(color.Value.G);
                        par.EmitComma();
                        par.EmitIntValue(color.Value.B);
                    }
                }
            }
            else
                styleField.EmitNull();
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
