using System;
using System.IO;

using SablePP.Tools.Error;
using SablePP.Tools.Lexing;
using SablePP.Tools.Nodes;
using SablePP.Tools.Parsing;

using FastColoredTextBoxNS;

namespace SablePP.Tools
{
    public interface ICompilerExecuter
    {
        ILexer GetLexer(TextReader reader);
        IParser GetParser(ILexer lexer);
        void Validate(Node astRoot, CompilationOptions compilationOptions);
        Style GetSimpleStyle(Token token);
    }
}
