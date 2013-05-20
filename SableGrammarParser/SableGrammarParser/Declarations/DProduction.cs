using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser
{
    /// <summary>
    /// Represents the declaration of a production identifier.
    /// </summary>
    public class DProduction : Declaration
    {
        private bool concrete;

        /// <summary>
        /// Initializes a new instance of the <see cref="DProduction"/> class.
        /// </summary>
        /// <param name="node">The production node from which this <see cref="DProduction"/> should be constructed.</param>
        public DProduction(AProduction production, bool concrete)
            : base(production.GetIdentifier())
        {
            this.concrete = concrete;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="DProduction"/> is a concrete rule (or an ast rule).
        /// </summary>
        /// <value>
        ///   <c>true</c> if concrete; otherwise, <c>false</c>.
        /// </value>
        public bool Concrete
        {
            get { return concrete; }
        }

        public override string ToString()
        {
            return "P:" + base.ToString();
        }
    }
}
