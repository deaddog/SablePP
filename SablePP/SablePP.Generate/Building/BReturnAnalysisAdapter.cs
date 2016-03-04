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
            nameElement.Add(returnAnalysisAdapter = new ClassElement($"public partial class ReturnAnalysisAdapter : ReturnAdapter<{baseClass}>"));

            var types = returnAnalysisAdapter.TypeParameters;

            for (int i = 1; i <= arguments; i++)
                types.Add("T" + i);
            types.Add(returnTypeParameter);

            bool first = true;

            foreach (var p in node.AbstractProductions)
            {
                if (!first)
                    returnAnalysisAdapter.EmitNewline();

                emitReturnAnalysisAdapterProduction(returnAnalysisAdapter, p);
                foreach (var a in p.Alternatives)
                    emitReturnAnalysisAdapterAlternative(returnAnalysisAdapter, a);

                first = false;
            }

            returnAnalysisAdapter.EmitNewline();

            foreach (var t in node.Tokens)
                emitReturnAnalysisAdapterToken(returnAnalysisAdapter, t);
        }

        private void emitReturnAnalysisAdapterToken(ClassElement adapterClass, Token node)
        {
            var types = adapterClass.TypeParameters;

            MethodElement method;
            method = createReturnMethod(adapterClass, $"public {types[types.Count - 1]} Visit({node.Name} node)");
            emitReturnStatement(method, $"Handle{node.Name}(node");

            method = createReturnMethod(adapterClass, $"protected virtual {types[types.Count - 1]} Handle{node.Name}({node.Name} node)");
            emitReturnStatement(method, $"HandleDefault(node");
        }
        private void emitReturnAnalysisAdapterAlternative(ClassElement adapterClass, AbstractAlternative node)
        {
            var types = adapterClass.TypeParameters;

            MethodElement method;
            method = createReturnMethod(adapterClass, $"private {types[types.Count - 1]} dispatch({node.Name} node)");
            emitReturnStatement(method, $"Handle{node.Name}(node");

            method = createReturnMethod(adapterClass, $"protected virtual {types[types.Count - 1]} Handle{node.Name}({node.Name} node)");
            emitReturnStatement(method, $"HandleDefault(node");
        }
        private void emitReturnAnalysisAdapterProduction(ClassElement adapterClass, AbstractProduction node)
        {
            var types = adapterClass.TypeParameters;

            MethodElement method;
            method = createReturnMethod(adapterClass, $"public {types[types.Count - 1]} Visit({node.Name} node)");
            emitReturnStatement(method, $"Handle{node.Name}(node");

            method = createReturnMethod(adapterClass, $"protected virtual {types[types.Count - 1]} Handle{node.Name}({node.Name} node)");
            emitReturnStatement(method, "dispatch((dynamic)node");
        }

        private MethodElement createReturnMethod(ClassElement adapterClass, string methodsignature, bool hasBody = true)
        {
            var types = adapterClass.TypeParameters;

            var method = new MethodElement(methodsignature, hasBody);
            adapterClass.Add(method);

            for (int i = 0; i < types.Count - 1; i++)
                method.Parameters.Add($"{types[i]} arg{i + 1}");

            return method;
        }
        private void emitReturnStatement(MethodElement method, string calledMethod)
        {
            method.Body.Emit("return " + calledMethod);
            for (int i = 1; i < method.Parameters.Count; i++)
                method.Body.Emit($", arg{i}");
            method.Body.EmitLine(");");
        }
    }
}
