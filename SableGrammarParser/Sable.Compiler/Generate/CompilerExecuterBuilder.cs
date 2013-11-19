using System;
using System.Text;

using Sable.Compiler.Nodes;

using Sable.Tools.Generate.CSharp;
using Sable.Tools.Nodes;

namespace Sable.Compiler.Generate
{
    public static class CompilerExecuterBuilder
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

            classElement.EmitNewLine();
            CreateSimpleSyntaxMethod(classElement);

            return fileElement;
        }

        private static ClassElement CreateClass(FileElement fileElement, string packageName)
        {
            NameSpaceElement name = fileElement.CreateNamespace(packageName);
            return name.CreateClass("CompilerExecuter", AccessModifiers.@public | AccessModifiers.partial, "ICompilerExecuter");
        }

        private static void CreateLexerMethods(ClassElement classElement)
        {
            var exMethod = classElement.CreateMethod(AccessModifiers.None, "Sable.Tools.ICompilerExecuter.GetLexer", "ILexer");
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
            var exMethod = classElement.CreateMethod(AccessModifiers.None, "Sable.Tools.ICompilerExecuter.GetParser", "IParser");
            exMethod.Parameters.Add("lexer", "ILexer");

            string resetName = typeof(Sable.Tools.Lexing.ResetableLexer).Name;
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

            var exMethod = classElement.CreateMethod(AccessModifiers.None, "Sable.Tools.ICompilerExecuter.Validate", "void");
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
        private static void CreateSimpleSyntaxMethod(ClassElement classElement)
        {
            var method = classElement.CreateMethod(AccessModifiers.@public, "GetSimpleStyle", "Style");
            method.Parameters.Add("token", "Token");
            method.EmitReturn();
            method.EmitNull();
            method.EmitSemicolon(true);
        }
    }
}
