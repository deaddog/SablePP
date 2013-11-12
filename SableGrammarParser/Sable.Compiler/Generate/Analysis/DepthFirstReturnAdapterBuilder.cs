using System;

using Sable.Compiler.Nodes;
using Sable.Tools.Generate.CSharp;

namespace Sable.Compiler.Generate.Analysis
{
    public class DepthFirstReturnAdapterBuilder : GenerateVisitor
    {
        private ClassElement returnAnalysisAdapter;

        public DepthFirstReturnAdapterBuilder(NameSpaceElement nameElement, bool reverse)
        {
            nameElement.CreateClass("DepthFirstReturnAnalysisAdapter", AccessModifiers.@public, "DepthFirstReturnAnalysisAdapter<object>");

            returnAnalysisAdapter = nameElement.CreateClass("DepthFirstReturnAnalysisAdapter", AccessModifiers.@public, "ReturnAnalysisAdapter<TValue>");
            returnAnalysisAdapter.TypeParameters.Add("TValue");
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
