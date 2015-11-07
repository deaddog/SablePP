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

            adapterClass.Add(new MethodElement($"public virtual void InStart(Start<{rootProduction}> node)"));
            adapterClass.Add(new MethodElement($"public virtual void OutStart(Start<{rootProduction}> node)"));

            #region StartCase

            adapterClass.Add(method = new MethodElement($"protected override void HandleStart(Start<{rootProduction}> node)"));

            method.Body.EmitLine("InStart(node);");
            method.Body.EmitNewLine();

            if (!reversed)
            {
                method.Body.EmitLine("Visit((dynamic)node.Root);");
                method.Body.EmitLine("Visit(node.EOF);");
            }
            else
            {
                method.Body.EmitLine("Visit(node.EOF);");
                method.Body.EmitLine("Visit((dynamic)node.Root);");
            }

            method.Body.EmitNewLine();
            method.Body.EmitLine("OutStart(node);");
            adapterClass.EmitNewline();

            #endregion

            adapterClass.Add(new MethodElement("public virtual void DefaultPIn(Node node)"));
            adapterClass.Add(new MethodElement("public virtual void DefaultPOut(Node node)"));

            adapterClass.Add(new MethodElement("public virtual void DefaultAIn(Node node)"));
            adapterClass.Add(new MethodElement("public virtual void DefaultAOut(Node node)"));

            foreach (var p in grammar.AbstractProductions)
            {
                emitDepthFirstAdapterProduction(adapterClass, p);
                foreach (var a in p.Alternatives)
                    emitDepthFirstAdapterAlternative(adapterClass, a, reversed);
            }
        }

        private void emitDepthFirstAdapterProduction(ClassElement adapterClass, AbstractProduction node)
        {
            adapterClass.EmitNewline();
            emitDepthFirstAdapterInOut(adapterClass, node.Name);
        }

        private void emitDepthFirstAdapterAlternative(ClassElement adapterClass, AbstractAlternative node, bool reversed)
        {
            emitDepthFirstAdapterInOut(adapterClass, node.Name);

            MethodElement method;
            adapterClass.Add(method = new MethodElement($"protected override void Handle{node.Name}({node.Name} node)"));
            method.Body.EmitLine($"In{node.Production.Name}(node);");
            method.Body.EmitLine($"In{node.Name}(node);");
            method.Body.EmitNewLine();

            var elements = reversed ? node.Elements.Reverse() : node.Elements;
            foreach (var e in elements)
                emitDepthFirstAdapterElement(e, method);

            method.Body.EmitNewLine();
            method.Body.EmitLine($"Out{node.Name}(node);");
            method.Body.EmitLine($"Out{node.Production.Name}(node);");
        }

        private void emitDepthFirstAdapterInOut(ClassElement adapterClass, string name)
        {
            MethodElement method;
            adapterClass.Add(method = new MethodElement($"public virtual void In{name}({name} node)"));
            method.Body.EmitLine($"Default{name[0]}In(node);");

            adapterClass.Add(method = new MethodElement($"public virtual void Out{name}({name} node)"));
            method.Body.EmitLine($"Default{name[0]}Out(node);");
        }

        private void emitDepthFirstAdapterElement(AbstractAlternative.Element node, MethodElement method)
        {
            string dynamic = node is AbstractAlternative.ProductionElement ? "(dynamic)" : "";
            string name = node.Name;

            switch (node.Modifier)
            {
                case Modifiers.Single:
                    method.Body.EmitLine($"Visit({dynamic}node.{name});");
                    break;

                case Modifiers.Optional:
                    method.Body.EmitLine($"if (node.Has{name})");
                    method.Body.IncreaseIndentation();
                    method.Body.EmitLine($"Visit({dynamic}node.{name});");
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
