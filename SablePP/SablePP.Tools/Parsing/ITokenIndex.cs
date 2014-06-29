using SablePP.Tools.Nodes;

namespace SablePP.Tools.Parsing
{
    /// <summary>
    /// Defines a method that gets the index of a given <see cref="Token"/>.
    /// </summary>
    public interface ITokenIndex
    {
        /// <summary>
        /// Gets the index of a <see cref="Token"/>.
        /// </summary>
        /// <param name="token">The <see cref="Token"/> of which to retrieve the index..</param>
        /// <returns>The index of <paramref name="token"/>.</returns>
        int GetIndex(Token token);
    }
}
