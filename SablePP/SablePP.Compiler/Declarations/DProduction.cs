using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler
{
    /// <summary>
    /// Represents the declaration of a production identifier.
    /// </summary>
    public class DProduction : Declaration
    {
        private AProduction production;
        private bool first;

        /// <summary>
        /// Initializes a new instance of the <see cref="DProduction"/> class.
        /// </summary>
        /// <param name="identifier">The production node from which this <see cref="DProduction"/> should be constructed.</param>
        /// <param name="first">Denotes if this <see cref="DProduction"/> is the first listed production</param>
        public DProduction(TIdentifier identifier, bool first)
            : base(identifier)
        {
            if (!(identifier.GetParent() is AProduction))
                throw new ArgumentException("The identifier used for constructing DProduction must be the direct child of AProduction.");

            this.production = identifier.GetParent() as AProduction;
            this.first = first;
        }

        /// <summary>
        /// Gets the production to which this <see cref="DProduction"/> refers.
        /// </summary>
        public AProduction Production
        {
            get { return production; }
        }

        public bool First
        {
            get { return first; }
        }

        public override string ToString()
        {
            return "P:" + base.ToString();
        }
    }
}
