using System.Linq;
using SablePP.Tools.Nodes;
using System.Collections.Generic;

namespace SablePP.Tools.Analysis
{
    /// <summary>
    /// Represents a <see cref="TreeWalker"/> that performs reverse-ordered depth first traversal of an AST.
    /// </summary>
    public class DepthFirstReversedTreeWalker : TreeWalker
    {
        /// <summary>
        /// When overridden in a derived class, performs tasks related to a single <see cref="Token" /> by 'visiting' it.
        /// </summary>
        /// <param name="token">The <see cref="Token" /> to visit.</param>
        public override void Visit(Token token)
        {
        }
        /// <summary>
        /// Visits, in reverse order, the children of a <see cref="Production"/> node. This call is made recursively.
        /// </summary>
        /// <param name="production">The <see cref="Production" /> whose children to visit.</param>
        public override void Visit(Production production)
        {
            foreach (Node node in production.GetChildren().Reverse())
                Visit(node);
        }

        /// <summary>
        /// Enumerates all tokens in a node depth-first, in reverse order.
        /// </summary>
        /// <param name="node">The node which tokens are visited.</param>
        /// <returns>A collection of the tokens in <paramref name="node"/>.</returns>
        public static IEnumerable<Token> GetTokens(Node node)
        {
            if (node is Token)
                yield return node as Token;
            else
                foreach (var token in getTokensFromProduction(node as Production))
                    yield return token;
        }
        private static IEnumerable<Token> getTokensFromProduction(Production production)
        {
            foreach (Node node in production.GetChildren().Reverse())
                foreach (var token in GetTokens(node))
                    yield return token;
        }
    }
}
