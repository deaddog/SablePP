﻿using System;
using System.Collections.Generic;

using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate.CSharp;
using SablePP.Tools.Nodes;

namespace SablePP.Compiler.Generate.Analysis
{
    public class AnalysisBuilder : GenerateVisitor
    {
        private const byte TYPEARGSCOUNT_RETURN = 3;

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

            nameElement.EmitRegionStart("Analysis adapters", false);
            nameElement.EmitNewLine();

            adapters.Add(new AnalysisAdapterBuilder(nameElement, node));
            nameElement.EmitNewLine();
            adapters.Add(new DepthFirstAdapterBuilder(nameElement, false));
            nameElement.EmitNewLine();
            adapters.Add(new DepthFirstAdapterBuilder(nameElement, true));

            nameElement.EmitRegionEnd();
            nameElement.EmitRegionStart("Return analysis adapters", false);
            nameElement.EmitNewLine();

            for (byte i = 0; i <= TYPEARGSCOUNT_RETURN; i++)
                adapters.Add(new ReturnAnalysisAdapterBuilder(nameElement, i, node));

            nameElement.EmitNewLine();
            nameElement.EmitRegionEnd(false);

            VisitInParallel(node, adapters.ToArray());
        }
    }
}
