using SablePP.Tools.Nodes;

namespace SablePP.Tools.Analysis
{
    /// <summary>
    /// Represents a <see cref="TreeWalker"/> that performs in-order depth first traversal of an AST.
    /// </summary>
    public class DepthFirstTreeWalker : TreeWalker
    {
        /// <summary>
        /// When overridden in a derived class, performs tasks related to a single <see cref="Token" /> by 'visiting' it.
        /// </summary>
        /// <param name="token">The <see cref="Token" /> to visit.</param>
        public override void Visit(Token token)
        {
        }
        /// <summary>
        /// Visits, in order, the children of a <see cref="Production"/> node. This call is made recursively.
        /// </summary>
        /// <param name="production">The <see cref="Production" /> whose children to visit.</param>
        public override void Visit(Production production)
        {
            foreach (Node node in production.GetChildren())
                Visit(node);
        }
    }
}
