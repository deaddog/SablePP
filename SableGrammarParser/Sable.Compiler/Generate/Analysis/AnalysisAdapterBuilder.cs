using System;

using Sable.Compiler.Nodes;
using Sable.Tools.Generate.CSharp;

namespace Sable.Compiler.Generate.Analysis
{
    public class AnalysisAdapterBuilder : GenerateVisitor
    {
        private ClassElement adapterClass;

        public AnalysisAdapterBuilder(NameSpaceElement namespaceElement)
        {
            namespaceElement.CreateClass("AnalysisAdapter", AccessModifiers.@public, "AnalysisAdapter<object>");
            adapterClass = namespaceElement.CreateClass("AnalysisAdapter", AccessModifiers.@public, "Adapter<TValue, object>");
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

        public override void CaseAToken(AToken node)
        {
            var visitMethod = adapterClass.CreateMethod(AccessModifiers.@public, "Visit", "void");
            visitMethod.Parameters.Add("node", node.ClassName);

            visitMethod.EmitIdentifier("Case" + node.ClassName);
            using (var par = visitMethod.EmitParenthesis())
                par.EmitIdentifier("node");
            visitMethod.EmitSemicolon(true);

            var caseMethod = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "Case" + node.ClassName, "void");
            caseMethod.Parameters.Add("node", node.ClassName);

            caseMethod.EmitIdentifier("DefaultCase");
            using (var par = caseMethod.EmitParenthesis())
                par.EmitIdentifier("node");
            caseMethod.EmitSemicolon(true);
        }

        public override void CaseAAlternative(AAlternative node)
        {
            var visitMethod = adapterClass.CreateMethod(AccessModifiers.@public, "Visit", "void");
            visitMethod.Parameters.Add("node", node.ClassName);

            visitMethod.EmitIdentifier("Case" + node.ClassName);
            using (var par = visitMethod.EmitParenthesis())
                par.EmitIdentifier("node");
            visitMethod.EmitSemicolon(true);

            var caseMethod = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "Case" + node.ClassName, "void");
            caseMethod.Parameters.Add("node", node.ClassName);

            caseMethod.EmitIdentifier("DefaultCase");
            using (var par = caseMethod.EmitParenthesis())
                par.EmitIdentifier("node");
            caseMethod.EmitSemicolon(true);
        }
    }
}
