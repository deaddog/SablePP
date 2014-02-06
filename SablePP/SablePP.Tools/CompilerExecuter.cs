using System;
using System.IO;

using SablePP.Tools.Error;
using SablePP.Tools.Lexing;
using SablePP.Tools.Nodes;
using SablePP.Tools.Parsing;

using FastColoredTextBoxNS;

namespace SablePP.Tools
{
    /// <summary>
    /// Provides a welltyped implementation of <see cref="ICompilerExecuter"/> by casting elements internally.
    /// </summary>
    /// <typeparam name="TRoot">The type of the AST root.</typeparam>
    /// <typeparam name="TLexer">The type of the lexer.</typeparam>
    /// <typeparam name="TParser">The type of the parser.</typeparam>
    public abstract class CompilerExecuter<TRoot, TLexer, TParser> : ICompilerExecuter
        where TRoot : Node
        where TLexer : class, ILexer
        where TParser : class, IParser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompilerExecuter{TRoot, TLexer, TParser}"/> class.
        /// </summary>
        public CompilerExecuter()
        {
        }

        /// <summary>
        /// Gets a <see cref="TLexer"/> that can be used to perform lexical analyses on a given input.
        /// </summary>
        /// <param name="reader">The <see cref="TextReader" /> from which input is read.</param>
        /// <returns>
        /// A <see cref="TLexer"/> capable of performing lexical analysis.
        /// </returns>
        public abstract TLexer GetLexer(TextReader reader);
        /// <summary>
        /// Gets a <see cref="TParser"/> that can be used to generate an AST from the tokenstream supplied by the <see cref="TLexer" />.
        /// </summary>
        /// <param name="lexer">The lexer that supplies the stream of tokens for the parser.</param>
        /// <returns>
        /// A <see cref="TParser"/> capable of generating an AST.
        /// </returns>
        public abstract TParser GetParser(ILexer lexer);
        /// <summary>
        /// Validates an AST given its root and a set of <see cref="CompilationOptions" />.
        /// </summary>
        /// <param name="astRoot">The <see cref="Start{TRoot}"/> element which is the root of an AST with first child of type <see cref="TRoot"/>.</param>
        /// <param name="compilationOptions">Compilation options for the validation. This includes an <see cref="ErrorManager" /> for registering errors.</param>
        public virtual void Validate(Start<TRoot> root, CompilationOptions compilationOptions)
        {
        }
        /// <summary>
        /// Determines which <see cref="Style" /> should be applied to a <see cref="Token" /> in the lexical analysis.
        /// </summary>
        /// <param name="token">The token to style.</param>
        /// <returns>
        /// The style that should be applied to the token, or <c>null</c> if no style applies.
        /// </returns>
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
        void ICompilerExecuter.Validate(Node astRoot, CompilationOptions compilationOptions)
        {
            if (!(astRoot is Start<TRoot>))
                throw new ArgumentException("Root must be of type " + typeof(Start<TRoot>).FullName, "astRoot");

            this.Validate(astRoot as Start<TRoot>, compilationOptions);
        }
        Style ICompilerExecuter.GetSimpleStyle(Token token)
        {
            return this.GetSimpleStyle(token);
        }
    }
}
