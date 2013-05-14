using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser
{
    /// <summary>
    /// Represents the declaration of a helper identifier.
    /// </summary>
    public class Helper : Declaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Helper"/> class.
        /// </summary>
        /// <param name="node">The helper node from which this <see cref="Helper"/> should be constructed.</param>
        public Helper(AHelper node)
            : base(node.GetIdentifier())
        {
        }
    }
}
