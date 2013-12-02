using System;
using System.IO;

using SablePP.Tools.Error;
using SablePP.Tools.Lexing;
using SablePP.Tools.Nodes;
using SablePP.Tools.Parsing;

using FastColoredTextBoxNS;

namespace SablePP.Tools
{
    public abstract class CompilerExecuter
    {
        internal CompilerExecuter()
        {
        }

        internal protected abstract ILexer getLexer(TextReader reader);
        internal protected abstract IParser getParser(ILexer lexer);
        internal protected abstract void validate(Node astRoot, ErrorManager errorManager);
        internal protected abstract Style getSimpleStyle(Token token);
    }

    public abstract class CompilerExecuter<TRoot, TLexer, TParser> : CompilerExecuter
        where TRoot : Node
        where TLexer : class, ILexer
        where TParser : class, IParser
    {
        public CompilerExecuter()
            : base()
        {
        }

        protected sealed internal override ILexer getLexer(TextReader reader)
        {
            return GetLexer(reader);
        }
        protected sealed internal override IParser getParser(ILexer lexer)
        {
            if (!(lexer is TLexer || (lexer is ResetableLexer && (lexer as ResetableLexer).InnerLexer is TLexer)))
                throw new ArgumentException("Lexer must be of type " + typeof(TLexer).FullName, "lexer");

            return this.GetParser(lexer as TLexer);
        }
        protected sealed internal override void validate(Node astRoot, ErrorManager errorManager)
        {
            if (!(astRoot is Start<TRoot>))
                throw new ArgumentException("Root must be of type " + typeof(Start<TRoot>).FullName, "astRoot");

            this.Validate(astRoot as Start<TRoot>, errorManager);
        }
        protected sealed internal override Style getSimpleStyle(Token token)
        {
            return GetSimpleStyle(token);
        }

        public abstract TLexer GetLexer(TextReader reader);
        public abstract TParser GetParser(TLexer lexer);
        public virtual void Validate(Start<TRoot> root, ErrorManager errorManager)
        {
        }
        public abstract Style GetSimpleStyle(Token token);
    }
}
