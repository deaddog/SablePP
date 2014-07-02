using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Nodes;

namespace SablePP.Compiler.Generate
{
    public class LexerModifier
    {
        private Start<PGrammar> astRoot;

        private LexerModifier(Start<PGrammar> astRoot)
        {
            if (astRoot == null)
                throw new ArgumentNullException("astRoot");
            else
                this.astRoot = astRoot;
        }

        #region Regular expressions

        private static Regex lexerThrow = new Regex(@"throw new LexerException[^;]*;");
        private static Regex lexerClass = new Regex(@"}[^p{}]*public class LexerException[^}]*}[^}]*");

        #endregion

        private static string ToCamelCase(string text)
        {
            return SablePP.Compiler.CommonMethods.ToCamelCase(text);
        }

        private string ReplaceIn(string parserCode)
        {
            string code = parserCode;
            
            string package = astRoot.Root.PackageName;

            if (astRoot.Root.HasPackage)
            {
                code = code.Replace("using " + package + ".node;", "using " + ToolsNamespace.Nodes + ";\nusing " + package + ".Nodes;\nusing " + ToolsNamespace.Error + ";");
                code = code.Replace("namespace " + package + ".lexer", "namespace " + package + ".Lexing");
            }
            else
            {
                code = code.Replace("using .node;", "using " + ToolsNamespace.Nodes + ";\nusing " + package + ".Nodes;\nusing " + ToolsNamespace.Error + ";");
                code = code.Replace("namespace .lexer", "namespace " + package + ".Lexing");
            }

            code = Regex.Replace(code, ".Pos[^a-z]", m => { return ".Position" + m.Value.Substring(4); });
            code = lexerThrow.Replace(code, "throw new LexerException(start_line + 1, start_pos + 1, \"Unknown token: \" + text);");
            code = lexerClass.Replace(code, "");

            code = code.Replace("public class Lexer", "public class Lexer : " + ToolsNamespace.Lexing + ".ILexer");

            code = code.Replace("\r\n", "\n").Replace('\r', '\n').Replace("\n", "\r\n");

            return code;
        }
        public static string ReplaceInCode(string parserCode, Start<PGrammar> astRoot)
        {
            LexerModifier modifier = new LexerModifier(astRoot);
            return modifier.ReplaceIn(parserCode);
        }
        public static void ApplyToFile(string filepath, Start<PGrammar> astRoot)
        {
            string code;

            using (StreamReader reader = new StreamReader(filepath))
                code = reader.ReadToEnd();

            code = ReplaceInCode(code, astRoot);

            using (StreamWriter writer = new StreamWriter(filepath))
                writer.Write(code);
        }
    }
}
