﻿using System;
using System.Collections.Generic;

using Sable.Compiler.Analysis;
using Sable.Compiler.Nodes;
using Sable.Tools.Generate.CSharp;
using Sable.Tools.Nodes;

namespace Sable.Compiler.Generate.Analysis
{
    public class AnalysisBuilder : GenerateVisitor
    {
        private FileElement fileElement;
        private NameSpaceElement nameElement;

        private AnalysisBuilder()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Collections.Generic");
            fileElement.Using.Add(ToolsNamespace.Analysis);
            fileElement.Using.Add(ToolsNamespace.Nodes);
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

            nameElement = fileElement.CreateNamespace(packageName + ".Analysis");
            fileElement.Using.Add(packageName + ".Nodes");

            List<DepthFirstAdapter> adapters = new List<DepthFirstAdapter>();

            nameElement.EmitRegionStart("Analysis adapters");
            nameElement.EmitNewLine();

            adapters.Add(new AnalysisAdapterBuilder(nameElement, node));
            nameElement.EmitNewLine();

            adapters.Add(new DepthFirstAdapterBuilder(nameElement));

            nameElement.EmitNewLine();
            nameElement.EmitRegionEnd();
            nameElement.EmitNewLine();
            nameElement.EmitRegionStart("Return analysis adapters");
            nameElement.EmitNewLine();

            adapters.Add(new ReturnAnalysisAdapterBuilder(nameElement, node));

            nameElement.EmitNewLine();
            nameElement.EmitRegionEnd();

            VisitInParallel(node, adapters.ToArray());
        }
    }
}
