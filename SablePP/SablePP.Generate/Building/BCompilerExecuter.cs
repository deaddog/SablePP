﻿using SablePP.Tools.Generate;
using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal class BCompilerExecuter
    {
        public static FileElement BuildCode(Grammar node)
        {
            FileElement fileElement = new FileElement();
            fileElement.Using.Add("System.Drawing");
            fileElement.Using.Add("System.IO");

            fileElement.Using.EmitNewline();

            fileElement.Using.Add(SablePP.Generate.Namespaces.Nodes);

            fileElement.Using.EmitNewline();

            fileElement.Using.Add(node.Namespace + ".Lexing");
            fileElement.Using.Add(node.Namespace + ".Nodes");
            fileElement.Using.Add(node.Namespace + ".Parsing");

            fileElement.Using.EmitNewline();

            fileElement.Using.Add("FastColoredTextBoxNS");

            ClassElement classElement = CreateClass(fileElement, node.Namespace, node.AbstractProductions.First().Name);
            CreateLexerMethod(classElement);

            classElement.EmitNewline();
            CreateParserMethod(classElement);

            PatchElement styleRules;

            classElement.EmitNewline();
            CreateSimpleSyntaxMethod(classElement, out styleRules);

            BCompilerExecuter builder = new BCompilerExecuter(classElement, styleRules);
            foreach (var rule in node.HighlightingRules)
                builder.Visit(rule);

            return fileElement;
        }

        #region Class setup

        private static ClassElement CreateClass(FileElement fileElement, string @namespace, string rootProduction)
        {
            NameSpaceElement name = new NameSpaceElement(@namespace);
            fileElement.Add(name);

            ClassElement executerClass = new ClassElement("public partial class CompilerExecuter : {1}.CompilerExecuter<{0}, Lexer, Parser>", rootProduction, SablePP.Generate.Namespaces.Root);
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
            MethodElement imMethod = new MethodElement("public override Parser GetParser(" + SablePP.Generate.Namespaces.Lexing + ".ILexer lexer)");
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

        private BCompilerExecuter(ClassElement builderClass, PatchElement styleRulesElement)
        {
            this.builderClass = builderClass;
            this.styleRulesElement = styleRulesElement;
        }

        private SablePP.Tools.SafeNameDictionary names = new Tools.SafeNameDictionary();

        private void Visit(Highlighting node)
        {
            string currentStyle = names.Add("style");

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

            for (int i = 0; i < node.Tokens.Length; i++)
            {
                if (i > 0)
                    styleRulesElement.Emit(" || ");

                styleRulesElement.Emit("token is {0}", node.Tokens[i].Name);
            }

            temp.EmitLine(")");
            temp.IncreaseIndentation();
            temp.EmitLine("return {0};", currentStyle);
            temp.DecreaseIndentation();
            styleRulesElement = temp;

            EmitNewBrush(node.Foreground);
            styleField.Emit(", ");
            EmitNewBrush(node.Background);
            styleField.Emit(", ");

            if (node.Italic && node.Bold)
                styleField.Emit("FontStyle.Regular");
            else if (node.Italic && !node.Bold)
                styleField.Emit("FontStyle.Italic");
            else if (!node.Italic && node.Bold)
                styleField.Emit("FontStyle.Bold");
            else
                styleField.Emit("FontStyle.Regular");
        }

        private void EmitNewBrush(Color? color)
        {
            if (color.HasValue)
                styleField.Emit("new SolidBrush(Color.FromArgb({0}, {1}, {2}))", color.Value.R, color.Value.G, color.Value.B);
            else
                styleField.Emit("null");
        }
    }
}
