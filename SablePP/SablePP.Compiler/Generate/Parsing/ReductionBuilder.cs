using SablePP.Compiler.Analysis;
using System.Collections.Generic;

namespace SablePP.Compiler.Generate.Parsing
{
    public abstract class ReductionBuilder : ReverseDepthFirstAdapter
    {
        private List<string> namesInUse;

        public ReductionBuilder()
            : base()
        {
            this.namesInUse = new List<string>();
        }

        protected string GetVariable(string name)
        {
            int i = 1;

            string variable;

            do variable = name + (i++); while (namesInUse.Contains(variable));
            namesInUse.Add(variable);

            return variable;
        }

        protected void Reset()
        {
            namesInUse.Clear();
        }
    }
}
