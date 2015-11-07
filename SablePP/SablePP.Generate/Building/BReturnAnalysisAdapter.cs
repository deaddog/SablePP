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
            nameElement.Add(returnAnalysisAdapter = new ClassElement($"public class ReturnAnalysisAdapter : ReturnAdapter<{baseClass}>"));

            var types = returnAnalysisAdapter.TypeParameters;

            for (int i = 1; i <= arguments; i++)
                types.Add("T" + i);
            types.Add(returnTypeParameter);

            MethodElement method;
            returnAnalysisAdapter.Add(method = new MethodElement($"public override {returnTypeParameter} Visit(Node node)"));
            for (int i = 1; i <= arguments; i++)
                method.Parameters.Add($"{types[i - 1]} arg{i}");
            method.Body.Emit("return Visit((dynamic)node");
            for (int i = 1; i <= arguments; i++)
                method.Body.Emit($", arg{i}");
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
            var types = returnAnalysisAdapter.TypeParameters;

            MethodElement method;
            returnAnalysisAdapter.Add(method = new MethodElement($"public {types[arguments]} Visit({name} node)"));
            for (int i = 1; i <= arguments; i++)
                method.Parameters.Add("{0} arg{1}", returnAnalysisAdapter.TypeParameters[i - 1], i);

            method.Body.Emit($"return Handle{name}(node");
            for (int i = 1; i <= arguments; i++)
                method.Body.Emit(", arg{0}", i);
            method.Body.EmitLine(");");

            returnAnalysisAdapter.Add(method = new MethodElement($"public virtual {types[arguments]} Handle{name}({name} node)"));
            for (int i = 1; i <= arguments; i++)
                method.Parameters.Add($"{types[i - 1]} arg{i}");

            method.Body.Emit("return HandleDefault(node");
            for (int i = 1; i <= arguments; i++)
                method.Body.Emit($", arg{i}");
            method.Body.EmitLine(");");
        }
    }
}
