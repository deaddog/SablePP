using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal partial class BAnalysis
    {
        private static readonly string typeParameter = "Value";
        private static readonly string returnTypeParameter = "Result";

        private const byte TYPEARGSCOUNT_RETURN = 3;

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

            nameElement.EmitRegionStart("Analysis adapters", false);
            nameElement.EmitNewLine();

            emitAnalysisAdapter(node);
            nameElement.EmitNewLine();
            emitDepthFirstAdapter(node, false);
            nameElement.EmitNewLine();
            emitDepthFirstAdapter(node, true);

            nameElement.EmitRegionEnd();
            nameElement.EmitRegionStart("Return analysis adapters", false);
            nameElement.EmitNewLine();

            for (byte i = 0; i <= TYPEARGSCOUNT_RETURN; i++)
                emitReturnAnalysisAdapter(node, i);

            nameElement.EmitNewLine();
            nameElement.EmitRegionEnd(false);
        }
    }
}
