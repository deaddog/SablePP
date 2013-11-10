using System;
using System.IO;

using Sable.Tools.Error;
using Sable.Tools.Lexing;
using Sable.Tools.Nodes;
using Sable.Tools.Parsing;

namespace Sable.Tools
{
    public abstract class CompilerExecuter
    {
        protected internal abstract ILexer GetLexer(TextReader reader);
        protected internal abstract IParser GetParser(ILexer lexer);
        protected internal abstract void ValidateAST(Node astRoot, ErrorManager errorManager);
    }
}
