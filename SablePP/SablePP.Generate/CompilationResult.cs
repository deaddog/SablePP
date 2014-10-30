using SablePP.Tools.Generate;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SablePP.Generate
{
    public class CompilationResult
    {
        private CompilationError error;

        private PatchElement lexerGoto, lexerAccept, parserAction, parserGoto, parserMessage, parserError;

        internal CompilationResult()
            : this(null)
        {
        }
        internal CompilationResult(CompilationError error)
        {
            this.error = error;
        }

        public CompilationError Error
        {
            get { return error; }
        }

        internal void SetLexerTables(string lexerCode)
        {
            lexerGoto = getTable(lexerCode, @"int\[\]\[\]\[\]\[\] gotoTable[^{]+(?<table>{[^;]*);");
            lexerAccept = getTable(lexerCode, @"int\[\]\[\] accept[^{]+(?<table>{[^;]*);");
        }
        internal void SetParserTables(string parserCode)
        {
            parserAction = getTable(parserCode, @"int\[\]\[\]\[\] actionTable[^{]+(?<table>{[^;]*);");
            parserGoto = getTable(parserCode, @"int\[\]\[\]\[\] gotoTable[^{]+(?<table>{[^;]*);");
            parserMessage = getTable(parserCode, "String\\[\\] errorMessages[^{]*(?<table>([^\"}]*\"[^\"]*\")+[^}]*\\});");
            parserError = getTable(parserCode, @"int\[\] errors[^{]+(?<table>{[^;]*);");
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

        internal PatchElement LexerGotoTable
        {
            get { return lexerGoto; }
        }
        internal PatchElement LexerAcceptTable
        {
            get { return lexerAccept; }
        }

        internal PatchElement ParserActionTable
        {
            get { return parserAction; }
        }
        internal PatchElement ParserGotoTable
        {
            get { return parserGoto; }
        }
        internal PatchElement ParserErrorMessagesTable
        {
            get { return parserMessage; }
        }
        internal PatchElement ParserErrorTable
        {
            get { return parserError; }
        }
    }
}
