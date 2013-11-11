using System;

using Sable.Compiler.Nodes;
using Sable.Tools.Generate.CSharp;

namespace Sable.Compiler.Generate.Analysis
{
    public class ReturnAnalysisAdapterBuilder : GenerateVisitor
    {
        private ClassElement returnAnalysisAdapter;

        public ReturnAnalysisAdapterBuilder(NameSpaceElement nameElement, PGrammar grammar)
        {
            nameElement.CreateClass("ReturnAnalysisAdapter", AccessModifiers.@public, "ReturnAnalysisAdapter<object>");

            returnAnalysisAdapter = nameElement.CreateClass("ReturnAnalysisAdapter", AccessModifiers.@public, "ReturnAdapter<TValue, " + grammar.RootProduction + ">");
            returnAnalysisAdapter.TypeParameters.Add("TValue");
        }
    }
}
