using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate;
using System.Collections.Generic;

namespace SablePP.Compiler.Generate.Parsing
{
    public class TranslationReductionBuilder : ReductionBuilder
    {
        private readonly Dictionary<PTranslation, string> variableNames;

        public TranslationReductionBuilder()
        {
            this.variableNames = new Dictionary<PTranslation, string>();
        }

        public override void CaseAAlternative(Nodes.AAlternative node)
        {
            CreateNewCase();
            base.CaseAAlternative(node);
        }
    }
}
