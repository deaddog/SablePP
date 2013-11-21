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

            var visitType = returnAnalysisAdapter.CreateMethod(AccessModifiers.@public, "Visit", returnAnalysisAdapter.TypeParameters[0]);
            visitType.Parameters.Add("node", name);
            visitType.Parameters.Add("arg", returnAnalysisAdapter.TypeParameters[0]);
            visitType.EmitReturn();
            visitType.EmitIdentifier(caseName);
            using (var par = visitType.EmitParenthesis())
            {
                par.EmitIdentifier("node");
                par.EmitComma();
                par.EmitIdentifier("arg");
            }
            visitType.EmitSemicolon(true);

            var typeMethod = returnAnalysisAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, caseName, returnAnalysisAdapter.TypeParameters[0]);
            typeMethod.Parameters.Add("node", name);
            typeMethod.Parameters.Add("arg", returnAnalysisAdapter.TypeParameters[0]);

            typeMethod.EmitReturn();
            typeMethod.EmitIdentifier("DefaultCase");
            using (var par = typeMethod.EmitParenthesis())
            {
                par.EmitIdentifier("node");
                par.EmitComma();
                par.EmitIdentifier("arg");
            }
            typeMethod.EmitSemicolon(true);
        }
    }
}
