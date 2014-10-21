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
            this.alternatives.ItemAdded += (s, e) =>
            {
                e.Item.Production = this;
                sharedElements = null;
                foreach (var a in this.alternatives)
                    a.ClearSharedElements();
            };

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

        private AbstractAlternative.Element[] sharedElements = null;

        public AbstractAlternative.Element[] SharedElements
        {
            get
            {
                if (sharedElements == null)
                {
                    var shared = alternatives[0].Elements.ToList();

                    for (int i = 1; i < alternatives.Count; i++)
                    {
                        var elements = alternatives[i].Elements;

                        for (int s = 0; s < shared.Count; s++)
                        {
                            var t = elements.FirstOrDefault(x => x.Name == shared[s].Name);
                            if (t == null || t.Modifier != shared[s].Modifier)
                                shared.RemoveAt(s--);
                        }
                    }

                    sharedElements = shared.ToArray();
                }

                return sharedElements;
            }
        }
    }
}
