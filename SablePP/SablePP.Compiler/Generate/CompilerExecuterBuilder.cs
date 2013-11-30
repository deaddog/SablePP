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

            ClassElement classElement = CreateClass(fileElement, packageName);
            CreateLexerMethods(classElement);

            classElement.EmitNewLine();
            CreateParserMethods(classElement);

            classElement.EmitNewLine();
            CreateValidateMethods(classElement, rootProduction);

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

        private static ClassElement CreateClass(FileElement fileElement, string packageName)
        {
            NameSpaceElement name = fileElement.CreateNamespace(packageName);
            return name.CreateClass("CompilerExecuter", AccessModifiers.@public | AccessModifiers.partial, "ICompilerExecuter");
        }

        private static void CreateLexerMethods(ClassElement classElement)
        {
            var exMethod = classElement.CreateMethod(AccessModifiers.None, "SablePP.Tools.ICompilerExecuter.GetLexer", "ILexer");
            exMethod.Parameters.Add("reader", "TextReader");

            exMethod.EmitReturn();
            exMethod.EmitThis();
            exMethod.EmitPeriod();
            exMethod.EmitIdentifier("GetLexer");
            using (var par = exMethod.EmitParenthesis())
                par.EmitIdentifier("reader");
            exMethod.EmitSemicolon(true);


            var imMethod = classElement.CreateMethod(AccessModifiers.@public, "GetLexer", "Lexer");
            imMethod.Parameters.Add("reader", "TextReader");

            imMethod.EmitReturn();
            imMethod.EmitNew();
            imMethod.EmitIdentifier("Lexer");
            using (var par = imMethod.EmitParenthesis())
                par.EmitIdentifier("reader");
            imMethod.EmitSemicolon(true);
        }
        private static void CreateParserMethods(ClassElement classElement)
        {
            var exMethod = classElement.CreateMethod(AccessModifiers.None, "SablePP.Tools.ICompilerExecuter.GetParser", "IParser");
            exMethod.Parameters.Add("lexer", "ILexer");

            string resetName = typeof(SablePP.Tools.Lexing.ResetableLexer).Name;
            using (var iff = exMethod.EmitIf())
            {
                iff.EmitLogicNot();
                using (var par = iff.EmitParenthesis())
                {
                    par.EmitIdentifier("lexer");
                    par.EmitIs();
                    par.EmitIdentifier("Lexer");
                    par.EmitLogicOr();
                    using (var reset = par.EmitParenthesis())
                    {
                        reset.EmitIdentifier("lexer");
                        reset.EmitIs();
                        reset.EmitIdentifier(resetName);
                        reset.EmitLogicAnd();
                        using (var par2 = reset.EmitParenthesis())
                        {
                            par2.EmitIdentifier("lexer");
                            par2.EmitAs();
                            par2.EmitIdentifier(resetName);
                        }
                        reset.EmitPeriod();
                        reset.EmitIdentifier("InnerLexer");
                        reset.EmitIs();
                        reset.EmitIdentifier("Lexer");
                    }
                }
            }
            exMethod.EmitNewLine();

            exMethod.IncreaseIndentation();

            exMethod.EmitThrow();
            exMethod.EmitNew();
            exMethod.EmitIdentifier("ArgumentException");
            using (var par = exMethod.EmitParenthesis())
            {
                par.EmitStringValue("Lexer must be of type ");
                par.EmitPlus();
                using (var tpar = par.EmitTypeOf())
                    tpar.EmitIdentifier("Lexer");
                par.EmitPeriod();
                par.EmitIdentifier("FullName");
                par.EmitComma();
                par.EmitStringValue("lexer");
            }
            exMethod.EmitSemicolon(true);

            exMethod.DecreaseIndentation();

            exMethod.EmitNewLine();
            exMethod.EmitReturn();
            exMethod.EmitThis();
            exMethod.EmitPeriod();
            exMethod.EmitIdentifier("GetParser");
            using (var par = exMethod.EmitParenthesis())
            {
                par.EmitIdentifier("lexer");
            }
            exMethod.EmitSemicolon(true);

            var imMethod = classElement.CreateMethod(AccessModifiers.@public, "GetParser", "Parser");
            imMethod.Parameters.Add("lexer", "ILexer");

            imMethod.EmitReturn();
            imMethod.EmitNew();
            imMethod.EmitIdentifier("Parser");
            using (var par = imMethod.EmitParenthesis())
                par.EmitIdentifier("lexer");
            imMethod.EmitSemicolon(true);
        }
        private static void CreateValidateMethods(ClassElement classElement, string rootProduction)
        {
            #region Explicit method

            var exMethod = classElement.CreateMethod(AccessModifiers.None, "SablePP.Tools.ICompilerExecuter.Validate", "void");
            exMethod.Parameters.Add("astRoot", "Node");
            exMethod.Parameters.Add("errorManager", "ErrorManager");

            using (var iff = exMethod.EmitIf())
            {
                iff.EmitLogicNot();
                using (var par = iff.EmitParenthesis())
                {
                    par.EmitIdentifier("astRoot");
                    par.EmitIs();
                    par.EmitIdentifier("Start");
                    using (var typePar = par.EmitParenthesis(ParenthesisElement.Types.Angled))
                        typePar.EmitIdentifier(rootProduction);
                }
            }
            exMethod.EmitNewLine();

            exMethod.IncreaseIndentation();

            exMethod.EmitThrow();
            exMethod.EmitNew();
            exMethod.EmitIdentifier("ArgumentException");
            using (var par = exMethod.EmitParenthesis())
            {
                par.EmitStringValue("Root must be of type ");
                par.EmitPlus();
                using (var tpar = par.EmitTypeOf())
                {
                    tpar.EmitIdentifier("Start");
                    using (var typePar = tpar.EmitParenthesis(ParenthesisElement.Types.Angled))
                        typePar.EmitIdentifier(rootProduction);
                }
                par.EmitPeriod();
                par.EmitIdentifier("FullName");
                par.EmitComma();
                par.EmitStringValue("astRoot");
            }
            exMethod.EmitSemicolon(true);

            exMethod.DecreaseIndentation();

            exMethod.EmitNewLine();
            exMethod.EmitThis();
            exMethod.EmitPeriod();
            exMethod.EmitIdentifier("Validate");
            using (var par = exMethod.EmitParenthesis())
            {
                par.EmitIdentifier("astRoot");
                par.EmitAs();
                par.EmitIdentifier("Start");
                using (var typePar = par.EmitParenthesis(ParenthesisElement.Types.Angled))
                    typePar.EmitIdentifier(rootProduction);
                par.EmitComma();
                par.EmitIdentifier("errorManager");
            }
            exMethod.EmitSemicolon(true);

            #endregion

            #region Partial method

            var parMethod = classElement.CreatePartialMethod("PerformValidation", "void");
            parMethod.Parameters.Add("root", "Start<" + rootProduction + ">");
            parMethod.Parameters.Add("errorManager", "ErrorManager");

            #endregion

            #region Implicit method

            var imMethod = classElement.CreateMethod(AccessModifiers.@public, "Validate", "void");
            imMethod.Parameters.Add("root", "Start<" + rootProduction + ">");
            imMethod.Parameters.Add("errorManager", "ErrorManager");

            imMethod.EmitIdentifier("PerformValidation");
            using (var par = imMethod.EmitParenthesis())
            {
                par.EmitIdentifier("root");
                par.EmitComma();
                par.EmitIdentifier("errorManager");
            }
            imMethod.EmitSemicolon(true);

            #endregion
        }
        private static void CreateSimpleSyntaxMethod(ClassElement classElement, out InlineElement rulesElement)
        {
            var method = classElement.CreateMethod(AccessModifiers.@public, "GetSimpleStyle", "Style");
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
            int red = int.Parse(node.Red.Text);
            int green = int.Parse(node.Green.Text);
            int blue = int.Parse(node.Blue.Text);

            return Color.FromArgb(red, green, blue);
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

            int hue = int.Parse(node.Hue.Text);
            int saturation = int.Parse(node.Saturation.Text);
            int brightness = int.Parse(node.Brightness.Text);

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
