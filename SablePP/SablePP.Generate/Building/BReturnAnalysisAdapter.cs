using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal partial class BAnalysis
    {
        private void emitReturnAnalysisAdapter(Grammar node, int arguments)
        {
            string baseClass = "";
            for (int i = 1; i <= arguments; i++)
                baseClass += "T" + i + ", ";
            baseClass += returnTypeParameter + ", " + node.AbstractProductions.First().Name;

            ClassElement returnAnalysisAdapter;
            nameElement.Add(returnAnalysisAdapter = new ClassElement("public class ReturnAnalysisAdapter : ReturnAdapter<{0}>", baseClass));
            for (int i = 1; i <= arguments; i++)
                returnAnalysisAdapter.TypeParameters.Add("T" + i);
            returnAnalysisAdapter.TypeParameters.Add(returnTypeParameter);

            MethodElement method;
            returnAnalysisAdapter.Add(method = new MethodElement("public override {0} Visit(Node node)", true, returnAnalysisAdapter.TypeParameters[arguments]));
            for (int i = 1; i <= arguments; i++)
                method.Parameters.Add("{0} arg{1}", returnAnalysisAdapter.TypeParameters[i - 1], i);
            method.Body.Emit("return Visit((dynamic)node");
            for (int i = 1; i <= arguments; i++)
                method.Body.Emit(", arg{0}", i);
            method.Body.EmitLine(");");

            returnAnalysisAdapter.EmitNewline();

            foreach (var p in node.AbstractProductions)
                foreach (var a in p.Alternatives)
                    emitReturnAnalysisAdapterCase(returnAnalysisAdapter, a.Name, arguments);

            foreach (var t in node.Tokens)
                emitReturnAnalysisAdapterCase(returnAnalysisAdapter, t.Name, arguments);
        }

        private void emitReturnAnalysisAdapterCase(ClassElement returnAnalysisAdapter, string name, int arguments)
        {
            string caseName = "Case" + name;

            MethodElement method;
            returnAnalysisAdapter.Add(method = new MethodElement("public {0} Visit({1} node)", true, returnAnalysisAdapter.TypeParameters[arguments], name));
            for (int i = 1; i <= arguments; i++)
                method.Parameters.Add("{0} arg{1}", returnAnalysisAdapter.TypeParameters[i - 1], i);

            method.Body.Emit("return {0}(node", caseName);
            for (int i = 1; i <= arguments; i++)
                method.Body.Emit(", arg{0}", i);
            method.Body.EmitLine(");");

            returnAnalysisAdapter.Add(method = new MethodElement("public virtual {2} {0}({1} node)", true, caseName, name, returnAnalysisAdapter.TypeParameters[arguments]));
            for (int i = 1; i <= arguments; i++)
                method.Parameters.Add("{0} arg{1}", returnAnalysisAdapter.TypeParameters[i - 1], i);

            method.Body.Emit("return HandleDefault(node");
            for (int i = 1; i <= arguments; i++)
                method.Body.Emit(", arg{0}", i);
            method.Body.EmitLine(");");
        }
    }
}
