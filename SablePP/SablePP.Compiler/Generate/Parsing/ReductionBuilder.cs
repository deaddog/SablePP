using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate;
using SablePP.Tools.Nodes;
using System.Collections.Generic;

namespace SablePP.Compiler.Generate.Parsing
{
    public abstract class ReductionBuilder : DepthFirstAdapter
    {
        #region Variable Names

        private List<string> namesInUse;
        private Dictionary<object, string> names;

        protected string GetVariable(SablePP.Compiler.Generate.Productions.ProductionElement node)
        {
            string name;
            if (!names.TryGetValue(node, out name))
            {
                var type = node.ProductionOrTokenClass;
                name = GetVariable(type.ToLower());

                names.Add(node, name);
            }
            return name;
        }
        protected string GetVariable(AAlternative node)
        {
            string name;
            if (!names.TryGetValue(node, out name))
            {
                var type = node.ClassName;
                name = GetVariable(type.ToLower());

                names.Add(node, name);
            }
            return name;
        }
        protected string GetVariable(PElement node)
        {
            string name;
            if (!names.TryGetValue(node, out name))
            {
                var type = node.GeneratedTypeName;
                name = GetVariable(type.ToLower());

                names.Add(node, name);
            }
            return name;
        }
        private string GetVariable(string name)
        {
            int i = 1;

            string variable;

            do variable = name + (i++); while (namesInUse.Contains(variable));
            namesInUse.Add(variable);

            return variable;
        }

        #endregion

        public ReductionBuilder()
            : base()
        {
            this.namesInUse = new List<string>();
            this.names = new Dictionary<object, string>();

            this.elements = new List<PatchElement>();
        }

        public override void InAAlternative(AAlternative node)
        {
            reset();
        }

        public PatchElement[] GetElements(AAlternative node)
        {
            reset();
            elements.Clear();
            _code = null;

            Visit(node);

            return elements.ToArray();
        }

        private void reset()
        {
            namesInUse.Clear();
            names.Clear();
        }

        private List<PatchElement> elements;
        private PatchElement _code;
        protected PatchElement code
        {
            get { return _code; }
        }

        protected void CreateNewCase()
        {
            _code = new PatchElement();
            elements.Add(_code);
        }
    }
}
