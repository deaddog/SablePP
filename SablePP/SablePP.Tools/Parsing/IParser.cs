using SablePP.Tools.Nodes;

namespace SablePP.Tools.Parsing
{
    /// <summary>
    /// Defines a method for performing a parse.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parses some valid data.
        /// </summary>
        /// <returns>The rootnode of an AST.</returns>
        Node Parse();
    }
}
