using System;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate.CSharp;

namespace SablePP.Compiler.Generate.Analysis
{
    public class AnalysisAdapterBuilder : GenerateVisitor
    {
        private ClassElement adapterClass;

        public AnalysisAdapterBuilder(NameSpaceElement namespaceElement, PGrammar grammar)
        {
            namespaceElement.Add(new ClassElement("public class AnalysisAdapter : AnalysisAdapter<object>"));
            namespaceElement.Add(adapterClass = new ClassElement("public class AnalysisAdapter<TValue> : Adapter<TValue, " + grammar.RootProduction + ">"));
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
            MethodElement method;
            adapterClass.Add(method = new MethodElement("public void Visit({0} node)", true, node.ClassName));
            method.Body.EmitLine("Case{0}(node);", node.ClassName);

            adapterClass.Add(method = new MethodElement("public virtual void Case{0}({0} node)", true, node.ClassName));
            method.Body.EmitLine("DefaultCase(node);");
        }

        public override void CaseAAlternative(AAlternative node)
        {
            MethodElement method;
            adapterClass.Add(method = new MethodElement("public void Visit({0} node)", true, node.ClassName));
            method.Body.EmitLine("Case{0}(node);", node.ClassName);

            adapterClass.Add(method = new MethodElement("public virtual void Case{0}({0} node)", true, node.ClassName));
            method.Body.EmitLine("DefaultCase(node);");
        }
    }
}
