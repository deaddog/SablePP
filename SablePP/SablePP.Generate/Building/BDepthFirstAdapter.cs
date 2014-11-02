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

            nameElement.Add(new ClassElement("public class {0} : {0}<object>", className));
            nameElement.Add(adapterClass = new ClassElement("public class {0}<{1}> : AnalysisAdapter<{1}>", className, typeParameter));

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

            adapterClass.Add(new MethodElement("public virtual void InStart(Start<{0}> node)", true, rootProduction));
            adapterClass.Add(new MethodElement("public virtual void OutStart(Start<{0}> node)", true, rootProduction));

            #region StartCase

            adapterClass.Add(method = new MethodElement("public override void CaseStart(Start<{0}> node)", true, rootProduction));

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
            adapterClass.Add(method = new MethodElement("public override void Case{0}({0} node)", true, node.Name));
            method.Body.EmitLine("In{0}(node);", node.Production.Name);
            method.Body.EmitLine("In{0}(node);", node.Name);
            method.Body.EmitNewLine();

            var elements = reversed ? node.Elements.Reverse() : node.Elements;
            foreach (var e in elements)
                emitDepthFirstAdapterElement(e, method);

            method.Body.EmitNewLine();
            method.Body.EmitLine("Out{0}(node);", node.Name);
            method.Body.EmitLine("Out{0}(node);", node.Production.Name);
        }

        private void emitDepthFirstAdapterInOut(ClassElement adapterClass, string name)
        {
            MethodElement method;
            adapterClass.Add(method = new MethodElement("public virtual void In{0}({0} node)", true, name));
            method.Body.EmitLine("Default{0}In(node);", name[0]);

            adapterClass.Add(method = new MethodElement("public virtual void Out{0}({0} node)", true, name));
            method.Body.EmitLine("Default{0}Out(node);", name[0]);
        }

        private void emitDepthFirstAdapterElement(AbstractAlternative.Element node, MethodElement method)
        {
            string dynamic = node is AbstractAlternative.ProductionElement ? "(dynamic)" : "";
            string name = node.Name;

            switch (node.Modifier)
            {
                case Modifiers.Single:
                    method.Body.EmitLine("Visit({0}node.{1});", dynamic, name);
                    break;

                case Modifiers.Optional:
                    method.Body.EmitLine("if (node.Has{0})", name);
                    method.Body.IncreaseIndentation();
                    method.Body.EmitLine("Visit({0}node.{1});", dynamic, name);
                    method.Body.DecreaseIndentation();
                    break;

                case Modifiers.OneOrMany:
                case Modifiers.ZeroOrMany:
                    method.Body.EmitLine("Visit(node.{0});", name);
                    break;
            }
        }
    }
}
