using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser
{
    /// <summary>
    /// Represents the declaration of a token identifier.
    /// </summary>
    public class DToken : Declaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DToken"/> class.
        /// </summary>
        /// <param name="node">The token node from which this <see cref="DToken"/> should be constructed.</param>
        public DToken(AToken node)
            : base(node.GetIdentifier())
        {
        }

        public override string ToString()
        {
            return "T:" + base.ToString();
        }
    }
}
