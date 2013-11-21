using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Declarations
{
    public class ProductionElement
    {
        private bool star = false, plus = false, question = false;
        private string name;
        private Declaration declaration;

        public ProductionElement(PElement node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            AElementname aName = node.PElementname as AElementname;
            this.name = aName == null ? null : aName.Name.Text;
            this.declaration = node.PElementid.TIdentifier.Declaration;

            if (node is AStarElement)
                star = true;
            else if (node is APlusElement)
                plus = true;
            else if (node is AQuestionElement)
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
