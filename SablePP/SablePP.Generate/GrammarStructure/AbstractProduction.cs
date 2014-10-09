using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SablePP.Generate
{
    public class AbstractProduction : GrammarPart
    {
        private string name;
        private AddOnlyList<AbstractAlternative> alternatives;

        public AbstractProduction(string name)
            : this(name, null)
        {
        }
        public AbstractProduction(string name, IEnumerable<AbstractAlternative> alternatives)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            this.name = name;

            this.alternatives = new AddOnlyList<AbstractAlternative>(this);
            this.alternatives.ItemAdded += (s, e) => e.Item.Production = this;

            if (alternatives != null)
                this.alternatives.AddRange(alternatives);
        }

        internal override bool canBeParent(GrammarPart part)
        {
            return part is Grammar;
        }
        public Grammar Parent
        {
            get { return base.parent as Grammar; }
        }

        public string Name
        {
            get { return name; }
        }
        public AddOnlyList<AbstractAlternative> Alternatives
        {
            get { return alternatives; }
        }
    }
}
