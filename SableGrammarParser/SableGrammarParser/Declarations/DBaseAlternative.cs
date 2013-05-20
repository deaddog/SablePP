using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser
{
    public class DBaseAlternative : Declaration
    {
        private bool concrete;

        /// <summary>
        /// Initializes a new instance of the <see cref="DBaseAlternative"/> class.
        /// </summary>
        /// <param name="node">The alternative name node from which this <see cref="DBaseAlternative"/> should be constructed.</param>
        protected DBaseAlternative(AAlternativename name, bool concrete)
            : base(name.GetName())
        {
            this.concrete = concrete;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="DBaseAlternative"/> is an alternative in a concrete rule or an ast rule.
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
            return "ALT:" + base.ToString();
        }
    }
}
