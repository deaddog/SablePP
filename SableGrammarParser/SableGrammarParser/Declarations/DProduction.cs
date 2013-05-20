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
    public class DProduction : DBaseProduction<DAlternative>
    {
        private DAProduction astProduction;

        /// <summary>
        /// Initializes a new instance of the <see cref="DProduction"/> class.
        /// </summary>
        /// <param name="node">The production node from which this <see cref="DProduction"/> should be constructed.</param>
        public DProduction(AProduction production)
            : base(production.GetIdentifier(), true)
        {
        }

        public DAProduction TranslatesTo
        {
            get { return astProduction; }
            set
            {
                if (astProduction != null)
                    astProduction = value;
                else 
                    throw new InvalidOperationException("Attempted to set TranslatesTo twice.");
            }
        }

        public override string ToString()
        {
            return "P:" + base.ToString();
        }
    }
}
