using System;
using System.IO;

using SablePP.Tools.Error;
using SablePP.Tools.Lexing;
using SablePP.Tools.Nodes;
using SablePP.Tools.Parsing;

using FastColoredTextBoxNS;

namespace SablePP.Tools
{
    public abstract class CompilerExecuter<TRoot, TLexer, TParser> : ICompilerExecuter
        where TRoot : Node
        where TLexer : class, ILexer
        where TParser : class, IParser
    {
        public CompilerExecuter()
        {
        }

        public abstract TLexer GetLexer(TextReader reader);
        public abstract TParser GetParser(ILexer lexer);
        public virtual void Validate(Start<TRoot> root, ErrorManager errorManager)
        {
        }
        public abstract Style GetSimpleStyle(Token token);

        ILexer ICompilerExecuter.GetLexer(TextReader reader)
        {
            return this.GetLexer(reader);
        }
        IParser ICompilerExecuter.GetParser(ILexer lexer)
        {
            if (!(lexer is TLexer || (lexer is ResetableLexer && (lexer as ResetableLexer).InnerLexer is TLexer)))
                throw new ArgumentException("Lexer must be of type " + typeof(TLexer).FullName, "lexer");

            return this.GetParser(lexer);
        }
        void ICompilerExecuter.Validate(Node astRoot, ErrorManager errorManager)
        {
            if (!(astRoot is Start<TRoot>))
                throw new ArgumentException("Root must be of type " + typeof(Start<TRoot>).FullName, "astRoot");

            this.Validate(astRoot as Start<TRoot>, errorManager);
        }
        Style ICompilerExecuter.GetSimpleStyle(Token token)
        {
            return this.GetSimpleStyle(token);
        }
    }
}
