using System;

using Sable.Compiler.Nodes;
using Sable.Tools.Generate.CSharp;

namespace Sable.Compiler.Generate.Analysis
{
    public class DepthFirstReturnAdapterBuilder : GenerateVisitor
    {
        private ClassElement adapterClass;
        private AGrammar grammar;

        private bool reversed;
        private MethodElement method;

        public DepthFirstReturnAdapterBuilder(NameSpaceElement namespaceElement, bool reversed)
        {
            this.reversed = reversed;

            string className = (reversed ? "Reverse" : "") + "DepthFirstReturnAdapter";

            namespaceElement.CreateClass(className, AccessModifiers.@public, className + "<object>");
            adapterClass = namespaceElement.CreateClass(className, AccessModifiers.@public, "AnalysisAdapter<TValue>");
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
