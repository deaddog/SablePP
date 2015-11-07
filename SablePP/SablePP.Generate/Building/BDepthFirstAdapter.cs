using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    internal partial class BAnalysis
    {
        public void emitDepthFirstAdapter(Grammar grammar, bool reversed)
        {
            string className = (reversed ? "Reverse" : "") + "DepthFirstAdapter";

            ClassElement adapterClass;
            MethodElement method;

            string rootProduction = grammar.AbstractProductions.First().Name;

            nameElement.Add(new ClassElement($"public class {className} : {className}<object>"));
            nameElement.Add(adapterClass = new ClassElement($"public class {className}<{typeParameter}> : AnalysisAdapter<{typeParameter}>"));

            #region Visit(List)

            adapterClass.Add(method = new MethodElement("public void Visit<Element>(Production.NodeList<Element> elements) where Element : Node"));
            method.Body.EmitLine("Element[] temp = new Element[elements.Count];");
            method.Body.EmitLine("elements.CopyTo(temp, 0);");

            if (!reversed)
                method.Body.EmitLine("for (int i = 0; i < temp.Length; i++)");
            else
                method.Body.EmitLine("for (int i = temp.Length - 1; i >= 0; i--)");

            method.Body.IncreaseIndentation();
            method.Body.EmitLine("Visit((dynamic)temp[i]);");
            method.Body.DecreaseIndentation();
            adapterClass.EmitNewline();

            #endregion

            #region StartCase

            adapterClass.Add(method = new MethodElement($"protected override void HandleStart(Start<{rootProduction}> node)"));

            if (!reversed)
            {
                method.Body.EmitLine("Visit(node.Root);");
                method.Body.EmitLine("Visit(node.EOF);");
            }
            else
            {
                method.Body.EmitLine("Visit(node.EOF);");
                method.Body.EmitLine("Visit(node.Root);");
            }

            adapterClass.EmitNewline();

            #endregion

            foreach (var p in grammar.AbstractProductions)
                foreach (var a in p.Alternatives)
                    emitDepthFirstAdapterAlternative(adapterClass, a, reversed);
        }

        private void emitDepthFirstAdapterAlternative(ClassElement adapterClass, AbstractAlternative node, bool reversed)
        {
            MethodElement method;
            adapterClass.Add(method = new MethodElement($"protected override void Handle{node.Name}({node.Name} node)"));

            var elements = reversed ? node.Elements.Reverse() : node.Elements;
            foreach (var e in elements)
                emitDepthFirstAdapterElement(e, method);
        }

        private void emitDepthFirstAdapterElement(AbstractAlternative.Element node, MethodElement method)
        {
            string name = node.Name;

            switch (node.Modifier)
            {
                case Modifiers.Single:
                    method.Body.EmitLine($"Visit(node.{name});");
                    break;

                case Modifiers.Optional:
                    method.Body.EmitLine($"if (node.Has{name})");
                    method.Body.IncreaseIndentation();
                    method.Body.EmitLine($"Visit(node.{name});");
                    method.Body.DecreaseIndentation();
                    break;

                case Modifiers.OneOrMany:
                case Modifiers.ZeroOrMany:
                    method.Body.EmitLine($"Visit(node.{name});", name);
                    break;
            }
        }
    }
}
