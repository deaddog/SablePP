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

        private BAnalysis()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Collections.Generic");
            fileElement.Using.Add(SablePP.Generate.Namespaces.Analysis);
            fileElement.Using.Add(SablePP.Generate.Namespaces.Nodes);
        }

        public static FileElement BuildCode(Grammar astRoot)
        {
            BAnalysis n = new BAnalysis();
            n.Visit(astRoot);
            return n.fileElement;
        }

        private void Visit(Grammar node)
        {
            fileElement.Add(nameElement = new NameSpaceElement(node.Namespace + ".Analysis"));
            fileElement.Using.Add(node.Namespace + ".Nodes");

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
