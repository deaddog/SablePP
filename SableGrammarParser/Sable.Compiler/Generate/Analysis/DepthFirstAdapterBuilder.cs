using System;

using Sable.Compiler.Nodes;
using Sable.Tools.Generate.CSharp;

namespace Sable.Compiler.Generate.Analysis
{
    public class DepthFirstAdapterBuilder : GenerateVisitor
    {
        private ClassElement adapterClass;

        public DepthFirstAdapterBuilder(NameSpaceElement namespaceElement)
        {
            namespaceElement.CreateClass("DepthFirstAnalysisAdapter", AccessModifiers.@public, "DepthFirstAnalysisAdapter<object>");
            adapterClass = namespaceElement.CreateClass("DepthFirstAnalysisAdapter", AccessModifiers.@public, "DepthFirstAnalysisAdapter<TValue, object>");
            adapterClass.TypeParameters.Add("TValue");
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasAstproductions)
                Visit(node.Astproductions);
            else if (node.HasProductions)
                Visit(node.Productions);

            if (node.HasTokens)
                Visit(node.Tokens);
        }
    }
}
