using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sable.Compiler.Nodes;

namespace Sable.Compiler.Declarations
{
    public class ProductionElement
    {
        private bool star = false, plus = false, question = false;
        private string name;
        private Declaration declaration;

        private ProductionElement(PElement node, PElementname name, PElementid id)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            AElementname aName = name as AElementname;
            if (aName != null)
                this.name = aName.GetName().Text;
            else
                this.name = null;

            if (id is ACleanElementid)
                this.declaration = (id as ACleanElementid).GetIdentifier().Declaration;
            else if (id is ATokenElementid)
                this.declaration = (id as ATokenElementid).GetIdentifier().Declaration;
            else if (id is AProductionElementid)
                this.declaration = (id as AProductionElementid).GetIdentifier().Declaration;
            else throw new InvalidOperationException("Unknown element id type.");
        }

        public ProductionElement(ASimpleElement node)
            : this(node as PElement, node.GetElementname(), node.GetElementid())
        {
        }
        public ProductionElement(AStarElement node)
            : this(node as PElement, node.GetElementname(), node.GetElementid())
        {
            star = true;
        }
        public ProductionElement(APlusElement node)
            : this(node as PElement, node.GetElementname(), node.GetElementid())
        {
            plus = true;
        }
        public ProductionElement(AQuestionElement node)
            : this(node as PElement, node.GetElementname(), node.GetElementid())
        {
            question = true;
        }

        public bool Many
        {
            get { return star || plus; }
        }
        public bool ZeroOrMany
        {
            get { return star; }
        }
        public bool OneOrMany
        {
            get { return plus; }
        }
        public bool Optional
        {
            get { return star || question; }
        }
        public bool ZeroOrOne
        {
            get { return question; }
        }
        public bool One
        {
            get { return !star && !plus && !question; }
        }
    }
}
