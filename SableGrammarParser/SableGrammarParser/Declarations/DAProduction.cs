using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser
{
    /// <summary>
    /// Represents the declaration of an ast production identifier.
    /// </summary>
    public class DAProduction : DBaseProduction<DAAlternative>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DAProduction"/> class.
        /// </summary>
        /// <param name="node">The production node from which this <see cref="DAProduction"/> should be constructed.</param>
        public DAProduction(AProduction production)
            : base(production.GetIdentifier(), false)
        {
        }
        
        public override string ToString()
        {
            return "A:" + base.ToString();
        }
    }
}
