using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal partial class BAnalysis
    {
        private FileElement fileElement;
        private NameSpaceElement nameElement;

        private AnalysisBuilder()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Collections.Generic");
            fileElement.Using.Add(SablePP.Generate.Namespaces.Analysis);
            fileElement.Using.Add(SablePP.Generate.Namespaces.Nodes);
        }

        public static FileElement BuildCode(Start<PGrammar> astRoot)
        {
            AnalysisBuilder n = new AnalysisBuilder();
            n.Visit(astRoot);
            return n.fileElement;
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            string packageName = node.PackageName;
            fileElement.Add(nameElement = new NameSpaceElement(packageName + ".Analysis"));
            fileElement.Using.Add(packageName + ".Nodes");

            List<DepthFirstAdapter> adapters = new List<DepthFirstAdapter>();

            adapters.Add(new AnalysisAdapterBuilder(nameElement, node));
            nameElement.EmitNewLine();
            adapters.Add(new DepthFirstAdapterBuilder(nameElement, false));
            nameElement.EmitNewLine();
            adapters.Add(new DepthFirstAdapterBuilder(nameElement, true));

            VisitInParallel(node, adapters.ToArray());
        }
    }
}
