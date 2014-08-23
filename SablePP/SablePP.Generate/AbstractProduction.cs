using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SablePP.Generate
{
    public class AbstractProduction
    {
        private string name;
        private AbstractAlternative[] alternatives;

        public AbstractProduction(string name, IEnumerable<AbstractAlternative> alternatives)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (alternatives == null)
                throw new ArgumentNullException("alternatives");

            this.name = name;
            this.alternatives = alternatives.ToArray();

            if (this.alternatives.Length == 0)
                throw new ArgumentOutOfRangeException("alternatives", "A production must contain at least one alternative.");
        }

        public string Name
        {
            get { return name; }
        }
        public AbstractAlternative[] Alternatives
        {
            get { return alternatives; }
        }
    }
}
