using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal partial class BAnalysis
    {
        private void emitAnalysisAdapter(Grammar node)
        {
            ClassElement adapterClass;

            nameElement.Add(new ClassElement("public class AnalysisAdapter : AnalysisAdapter<object>"));
            nameElement.Add(adapterClass = new ClassElement("public class AnalysisAdapter<{1}> : Adapter<{1}, {0}>", node.AbstractProductions.First().Name, typeParameter));

            // Dynamic Visit(node) method
            MethodElement method;
            adapterClass.Add(method = new MethodElement("public override void Visit(Node node)"));
            method.Body.EmitLine("Visit((dynamic)node);");

            adapterClass.EmitNewline();

            foreach (var p in node.AbstractProductions)
                foreach (var a in p.Alternatives)
                    emitAnalysisAdapterAlternative(adapterClass, a);
            foreach (var t in node.Tokens)
                emitAnalysisAdapterToken(adapterClass, t);
        }

        private void emitAnalysisAdapterToken(ClassElement adapterClass, Token node)
        {
            MethodElement method;
            adapterClass.Add(method = new MethodElement("public void Visit({0} node)", true, node.Name));
            method.Body.EmitLine("Handle{0}(node);", node.Name);

            adapterClass.Add(method = new MethodElement("protected virtual void Handle{0}({0} node)", true, node.Name));
            method.Body.EmitLine("HandleDefault(node);");
        }
        private void emitAnalysisAdapterAlternative(ClassElement adapterClass, AbstractAlternative node)
        {
            MethodElement method;
            adapterClass.Add(method = new MethodElement("public void Visit({0} node)", true, node.Name));
            method.Body.EmitLine("Handle{0}(node);", node.Name);

            adapterClass.Add(method = new MethodElement("protected virtual void Handle{0}({0} node)", true, node.Name));
            method.Body.EmitLine("HandleDefault(node);");
        }
    }
}
