using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate;
using System.Collections.Generic;

namespace SablePP.Compiler.Generate.Parsing
{
    public abstract class ReductionBuilder : DepthFirstAdapter
    {
        #region Variable Names

        private List<string> namesInUse;
        protected string GetVariable(string name)
        {
            int i = 1;

            string variable;

            do variable = name + (i++); while (namesInUse.Contains(variable));
            namesInUse.Add(variable);

            return variable;
        }

        #endregion

        private int gotoNumber;
        protected int GoTo
        {
            get { return gotoNumber; }
        }

        public ReductionBuilder()
            : base()
        {
            this.namesInUse = new List<string>();

            this.elements = new List<PatchElement>();
        }

        public PatchElement[] GetElements(AAlternative node, int gotoNumber)
        {
            this.gotoNumber = gotoNumber;
            reset();
            elements.Clear();
            _code = null;

            Visit(node);

            return elements.ToArray();
        }

        private void reset()
        {
            namesInUse.Clear();
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
