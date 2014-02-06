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
    /// Defines methods for implementing execution of a compiler via three of its fases; lexing, parsing and validation of AST.
    /// </summary>
    public interface ICompilerExecuter
    {
        /// <summary>
        /// Gets a lexer that can be used to perform lexical analyses on a given input.
        /// </summary>
        /// <param name="reader">The <see cref="TextReader"/> from which input is read.</param>
        /// <returns>An <see cref="ILexer"/> capable of performing lexical analysis.</returns>
        ILexer GetLexer(TextReader reader);
        /// <summary>
        /// Gets a parser that can be used to generate an AST from the tokenstream supplied by the <see cref="ILexer"/>.
        /// </summary>
        /// <param name="lexer">The lexer that supplies the stream of tokens for the parser.</param>
        /// <returns>An <see cref="IParser"/> capable of generating an AST.</returns>
        IParser GetParser(ILexer lexer);
        /// <summary>
        /// Validates an AST given its root and a set of <see cref="CompilationOptions"/>.
        /// </summary>
        /// <param name="astRoot">The root of the AST.</param>
        /// <param name="compilationOptions">Compilation options for the validation. This includes an <see cref="ErrorManager"/> for registering errors.</param>
        void Validate(Node astRoot, CompilationOptions compilationOptions);
        /// <summary>
        /// Determines which <see cref="Style"/> should be applied to a <see cref="Token"/> in the lexical analysis.
        /// </summary>
        /// <param name="token">The token to style.</param>
        /// <returns>The style that should be applied to the token, or <c>null</c> if no style applies.</returns>
        Style GetSimpleStyle(Token token);
    }
}
