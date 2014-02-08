using FastColoredTextBoxNS;
using SablePP.Tools.Nodes;

namespace SablePP.Tools
{
    /// <summary>
    /// Defines a method for determining which <see cref="Style"/> relates to a specific <see cref="Token"/>.
    /// An implementation of <see cref="IHighlighter"/> can be used to apply syntax highlighting to code.
    /// </summary>
    public interface IHighlighter
    {
        /// <summary>
        /// Gets the style from a token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>The style that should be applied to the token, or <c>null</c> if no style applies.</returns>
        Style GetStyle(Token token);
    }
}
