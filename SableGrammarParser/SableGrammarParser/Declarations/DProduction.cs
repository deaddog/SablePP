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
        private AProduction production;

        /// <summary>
        /// Initializes a new instance of the <see cref="DProduction"/> class.
        /// </summary>
        /// <param name="node">The production node from which this <see cref="DProduction"/> should be constructed.</param>
        public DProduction(AProduction production)
            : base(production.GetIdentifier())
        {
            this.production = production;
        }

        /// <summary>
        /// Gets the production declared by this <see cref="DProduction"/>.
        /// </summary>
        /// <value>
        /// The production declared by this <see cref="DProduction"/>.
        /// </value>
        public AProduction Production
        {
            get { return production; }
        }

        public override string ToString()
        {
            return "P:" + base.ToString();
        }
    }
}
