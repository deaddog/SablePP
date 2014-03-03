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

        /// <summary>
        /// Initializes a new instance of the <see cref="DProduction"/> class.
        /// </summary>
        /// <param name="node">The production node from which this <see cref="DProduction"/> should be constructed.</param>
        public DProduction(TIdentifier identifier)
            : base(identifier)
        {
            if (!(identifier.GetParent() is AProduction))
                throw new ArgumentException("The identifier used for constructing DProduction must be the direct child of AProduction.");

            this.production = identifier.GetParent() as AProduction;
        }

        /// <summary>
        /// Gets the production to which this <see cref="DProduction"/> refers.
        /// </summary>
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
