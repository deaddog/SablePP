using System;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate.CSharp;

namespace SablePP.Compiler.Generate.Analysis
{
    public class ReturnAnalysisAdapterBuilder : GenerateVisitor
    {
        private ClassElement returnAnalysisAdapter;
        private int argumentCount;

        public ReturnAnalysisAdapterBuilder(NameSpaceElement nameElement, byte arguments, PGrammar grammar)
        {
            this.argumentCount = arguments;

            string baseClass = "ReturnAdapter<";
            for (int i = 1; i <= argumentCount; i++)
                baseClass += "T" + i + ", ";

            baseClass += "TResult, " + grammar.RootProduction + ">";
            returnAnalysisAdapter = nameElement.CreateClass("ReturnAnalysisAdapter", AccessModifiers.@public, baseClass);
            for (int i = 1; i <= argumentCount; i++)
                returnAnalysisAdapter.TypeParameters.Add("T" + i);
            returnAnalysisAdapter.TypeParameters.Add("TResult");
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

        public override void CaseAToken(AToken node)
        {
            EmitCase("T" + node.Identifier.Text.ToCamelCase());
        }

        public override void CaseAAlternative(AAlternative node)
        {
            EmitCase(node.ClassName);
        }
        private void EmitCase(string name)
        {
            string caseName = "Case" + name;

            var visitType = returnAnalysisAdapter.CreateMethod(AccessModifiers.@public, "Visit", returnAnalysisAdapter.TypeParameters[argumentCount]);
            visitType.Parameters.Add("node", name);
            for (int i = 1; i <= argumentCount; i++)
                visitType.Parameters.Add("arg" + i, returnAnalysisAdapter.TypeParameters[i - 1]);
            visitType.EmitReturn();
            visitType.EmitIdentifier(caseName);
            using (var par = visitType.EmitParenthesis())
            {
                par.EmitIdentifier("node");
                for (int i = 1; i <= argumentCount; i++)
                {
                    par.EmitComma();
                    par.EmitIdentifier("arg" + i);
                }
            }
            visitType.EmitSemicolon(true);

            var typeMethod = returnAnalysisAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, caseName, returnAnalysisAdapter.TypeParameters[argumentCount]);
            typeMethod.Parameters.Add("node", name);
            for (int i = 1; i <= argumentCount; i++)
                typeMethod.Parameters.Add("arg" + i, returnAnalysisAdapter.TypeParameters[i - 1]);

            typeMethod.EmitReturn();
            typeMethod.EmitIdentifier("DefaultCase");
            using (var par = typeMethod.EmitParenthesis())
            {
                par.EmitIdentifier("node");
                for (int i = 1; i <= argumentCount; i++)
                {
                    par.EmitComma();
                    par.EmitIdentifier("arg" + i);
                }
            }
            typeMethod.EmitSemicolon(true);
        }
    }
}
