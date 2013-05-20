using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser
{
    public class DBaseProduction<T> : Declaration
        where T: DBaseAlternative
    {
        private bool concrete;
        private AlternativeCollection alternatives;

        /// <summary>
        /// Initializes a new instance of the <see cref="DBaseProduction"/> class.
        /// </summary>
        /// <param name="declarationToken">The declaration token.</param>
        /// <param name="concrete">A boolean value indicating if this production is concrete or abstract.</param>
        protected DBaseProduction(TIdentifier declarationToken, bool concrete)
            : base(declarationToken)
        {
            this.concrete = concrete;
            this.alternatives = new AlternativeCollection(this);
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="DBaseProduction"/> is a concrete rule or an ast rule.
        /// </summary>
        /// <value>
        ///   <c>true</c> if concrete; otherwise, <c>false</c>.
        /// </value>
        public bool Concrete
        {
            get { return concrete; }
        }

        public AlternativeCollection Alternatives
        {
            get { return alternatives; }
        }

        public class AlternativeCollection
        {
            private DBaseProduction<T> parent;
            private List<T> list;

            public AlternativeCollection(DBaseProduction<T> parent)
            {
                this.parent = parent;
                this.list = new List<T>();
            }

            public void Add(T alternative)
            {
                this.list.Add(alternative);
            }

            public int Count
            {
                get { return list.Count; }
            }
        }
    }
}
