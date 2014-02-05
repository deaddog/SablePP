using System;
using System.Drawing;
using System.IO;

using SablePP.Tools;
using SablePP.Tools.Error;
using SablePP.Tools.Lexing;
using SablePP.Tools.Nodes;
using SablePP.Tools.Parsing;

using SablePP.Compiler.Lexing;
using SablePP.Compiler.Nodes;
using SablePP.Compiler.Parsing;

using FastColoredTextBoxNS;

namespace SablePP.Compiler
{
    public partial class CompilerExecuter : CompilerExecuter<PGrammar, Lexer, Parser>
    {
        public override Lexer GetLexer(TextReader reader)
        {
            return new Lexer(reader);
        }
        
        public override Parser GetParser(ILexer lexer)
        {
            return new Parser(lexer);
        }
        
        public override Style GetSimpleStyle(Token token)
        {
            if (token is TComment)
                return commentStyle;
            if (token is TCharacter || token is TString)
                return stringStyle;
            if (token is TPackagename || token is TPackagetoken || token is THelperstoken || token is TTokenstoken || token is TIgnoredtoken || token is TStatestoken || token is TProductionstoken || token is TAsttoken || token is THighlighttoken)
                return headingStyle;
            if (token is TBold)
                return boldStyle;
            if (token is TItalic)
                return italicStyle;
            return null;
        }
        private TextStyle commentStyle = new TextStyle(new SolidBrush(Color.FromArgb(0, 128, 0)), null, FontStyle.Regular);
        private TextStyle stringStyle = new TextStyle(new SolidBrush(Color.FromArgb(163, 21, 21)), null, FontStyle.Regular);
        private TextStyle headingStyle = new TextStyle(new SolidBrush(Color.FromArgb(76, 76, 76)), null, FontStyle.Bold);
        private TextStyle boldStyle = new TextStyle(null, null, FontStyle.Bold);
        private TextStyle italicStyle = new TextStyle(null, null, FontStyle.Italic);
    }
}
