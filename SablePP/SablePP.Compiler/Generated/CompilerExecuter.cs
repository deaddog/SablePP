using System.Drawing;
using System.IO;

using SablePP.Tools.Nodes;

using SablePP.Compiler.Lexing;
using SablePP.Compiler.Nodes;
using SablePP.Compiler.Parsing;

using FastColoredTextBoxNS;

namespace SablePP.Compiler
{
    public partial class CompilerExecuter : SablePP.Tools.CompilerExecuter<PGrammar, Lexer, Parser>
    {
        public override Lexer GetLexer(TextReader reader)
        {
            return new Lexer(reader);
        }
        
        public override Parser GetParser(SablePP.Tools.Lexing.ILexer lexer)
        {
            return new Parser(lexer);
        }
        
        public override Style GetSimpleStyle(Token token)
        {
            if (token is TComment)
                return style1;
            if (token is TCharacter || token is TString)
                return style2;
            if (token is TNamespace || token is TNamespacetoken || token is THelperstoken || token is TTokenstoken || token is TIgnoredtoken || token is TStatestoken || token is TProductionstoken || token is TAsttoken || token is THighlighttoken)
                return style3;
            if (token is TBold)
                return style4;
            if (token is TItalic)
                return style5;
            return null;
        }
        private TextStyle style1 = new TextStyle(new SolidBrush(Color.FromArgb(0, 128, 0)), null, FontStyle.Regular);
        private TextStyle style2 = new TextStyle(new SolidBrush(Color.FromArgb(163, 21, 21)), null, FontStyle.Regular);
        private TextStyle style3 = new TextStyle(new SolidBrush(Color.FromArgb(76, 76, 76)), null, FontStyle.Bold);
        private TextStyle style4 = new TextStyle(null, null, FontStyle.Bold);
        private TextStyle style5 = new TextStyle(null, null, FontStyle.Italic);
    }
}
