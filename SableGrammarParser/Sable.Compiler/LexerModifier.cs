using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Sable.Compiler.Analysis;
using Sable.Compiler.Nodes;

namespace Sable.Compiler
{
    public class LexerModifier
    {
        private Start astRoot;

        private LexerModifier(Start astRoot)
        {
            if (astRoot == null)
                throw new ArgumentNullException("astRoot");
            else
                this.astRoot = astRoot;
        }

        #region Regular expressions

        private static Regex newList = new Regex(@"TypedList (?<name>listNode[0-9]+) = new TypedList\(\);");
        private static Regex castList = new Regex(@"TypedList (?<name>listNode[0-9]+) = \(TypedList\)(?<assign>nodeArrayList[0-9]+\[[0-9]+\]);");
        private static Regex addAll = new Regex(@"(?<list>listNode[0-9]+)\.AddRange\((?<arg>listNode[0-9]+)\);");
        private static Regex add = new Regex(@"(?<list>listNode[0-9]+)\.Add\((?<arg>[^0-9]+[0-9]+)\);");
        private static Regex castNode = new Regex(@"(?<type>[TAP][A-Z][a-zA-Z]*) (?<name>[^ ]*) = \(\1\)nodeArrayList[0-9]+\[[0-9]+\];");
        private static Regex newNodes = new Regex(@"(?<type>[TAP][A-Z][a-zA-Z]*) (?<name>[^ ]+) = new \k<type>[^(]\([ \r\n]*(?<arg>[^,) \r\n]*)(,[ \r\n]*(?<arg>[^,) \r\n]*))*");

        #endregion

        private static string ToCamelCase(string text)
        {
            return Sable.Compiler.CommonMethods.ToCamelCase(text);
        }

        private string ReplaceIn(string parserCode)
        {
            string code = parserCode;

            string package = astRoot.GetPGrammar().PackageName;

            code = code.Replace("using " + package + ".node;", "using " + ToolsNamespace.Nodes + ";\nusing " + package + ".Nodes;");
            code = code.Replace("namespace " + package + ".lexer", "namespace " + package + ".Lexing");

            code = Regex.Replace(code, ".Pos[^a-z]", m => { return ".Position" + m.Value.Substring(4); });

            return code;
        }
        public static string ReplaceInCode(string parserCode, Start astRoot)
        {
            LexerModifier modifier = new LexerModifier(astRoot);
            return modifier.ReplaceIn(parserCode);
        }
        public static void ApplyToFile(string filepath, Start astRoot)
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
