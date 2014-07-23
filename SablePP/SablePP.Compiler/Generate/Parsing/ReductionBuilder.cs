using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Compiler.Generate.Parsing
{
    public abstract class ReductionBuilder : DepthFirstAdapter
    {
        #region Variable Names

        private List<string> namesInUse;
        protected string GetVariable(string name)
        {
            string variable = (from n in getVariations(name.ToLower())
                               where !namesInUse.Contains(n)
                               select n).First();

            namesInUse.Add(variable);
            return variable;
        }

        private IEnumerable<string> getVariations(string name)
        {
            yield return name;
            for (int i = 2; ; i++)
                yield return name + i;
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
            reset();
        }
    }
}
