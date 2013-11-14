using System;
using System.IO;

using Sable.Tools.Error;
using Sable.Tools.Lexing;
using Sable.Tools.Nodes;
using Sable.Tools.Parsing;

namespace Sable.Tools
{
    public interface ICompilerExecuter
    {
        ILexer GetLexer(TextReader reader);
        IParser GetParser(ILexer lexer);
        void Validate(Node astRoot, ErrorManager errorManager);
    }
}
