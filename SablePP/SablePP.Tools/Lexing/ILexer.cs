using SablePP.Tools.Nodes;

namespace SablePP.Tools.Lexing
{
    /// <summary>
    /// Defines methods for performing lexical analysis.
    /// </summary>
    public interface ILexer
    {
        /// <summary>
        /// Gets the next <see cref="Token"/> in the token stream, but does not remove it from the stream.
        /// </summary>
        /// <returns>The next <see cref="Token"/> in the token stream.</returns>
        Token Peek();
        /// <summary>
        /// Gets the next <see cref="Token"/> in the token stream, and removes it from the stream.
        /// </summary>
        /// <returns>The next <see cref="Token"/> in the token stream.</returns>
        Token Next();
    }
}
