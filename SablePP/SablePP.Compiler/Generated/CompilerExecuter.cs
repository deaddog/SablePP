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
            return null;
        }
    }
}
