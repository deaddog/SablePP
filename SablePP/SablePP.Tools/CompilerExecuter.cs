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
        where TRoot : Production
        where TLexer : class, ILexer
        where TParser : class, IParser
    {
        public CompilerExecuter()
        {
        }

        public abstract TLexer GetLexer(TextReader reader);
        public abstract TParser GetParser(ILexer lexer);
        public virtual void Validate(Start<TRoot> root, CompilationOptions compilationOptions)
        {
        }
        public abstract Style GetSimpleStyle(Token token);

        private void handleErrorArgument(object sender, ErrorArgumentEventArgs e)
        {
            HandleErrorArgument(e);
        }
        /// <summary>
        /// When overridden in a derived class, handles the proper translation of arguments into strings.
        /// </summary>
        /// <param name="e">The <see cref="ErrorArgumentEventArgs"/> instance containing the event data.</param>
        public virtual void HandleErrorArgument(ErrorArgumentEventArgs e)
        {
        }

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
        void ICompilerExecuter.Validate(Node astRoot, CompilationOptions compilationOptions)
        {
            if (!(astRoot is Start<TRoot>))
                throw new ArgumentException("Root must be of type " + typeof(Start<TRoot>).FullName, "astRoot");

            compilationOptions.ErrorManager.TranslateArgument += handleErrorArgument;
            this.Validate(astRoot as Start<TRoot>, compilationOptions);
            compilationOptions.ErrorManager.TranslateArgument -= handleErrorArgument;
        }
        Style ICompilerExecuter.GetSimpleStyle(Token token)
        {
            return this.GetSimpleStyle(token);
        }
    }
}
