using System;
using System.Linq;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate.CSharp;

namespace SablePP.Compiler.Generate.Analysis
{
    public class DepthFirstAdapterBuilder : GenerateVisitor
    {
        private static readonly string typeParameter = "Value";
        private ClassElement adapterClass;
        private AGrammar grammar;

        private bool reversed;
        private MethodElement method;

        public DepthFirstAdapterBuilder(NameSpaceElement namespaceElement, bool reversed)
        {
            this.reversed = reversed;

            string className = (reversed ? "Reverse" : "") + "DepthFirstAdapter";

            namespaceElement.Add(new ClassElement("public class {0} : {0}<object>", className));
            namespaceElement.Add(adapterClass = new ClassElement("public class {0}<{1}> : AnalysisAdapter<{1}>", className, typeParameter));
        }

        public override void CaseAGrammar(AGrammar node)
        {
            this.grammar = node;

            CreateGenericListMethod();
            adapterClass.EmitNewline();

            CreateStartInOutMethods();
            CreateStartCaseMethod();
            adapterClass.EmitNewline();

            CreateDefaultProductionMethods();
            CreateDefaultAlternativeMethods();

            if (node.HasAstproductions)
                Visit(node.Astproductions);
            else if (node.HasProductions)
                Visit(node.Productions);

            if (node.HasTokens)
                Visit(node.Tokens);
        }

        #region Default methods

        public void CreateGenericListMethod()
        {
            MethodElement method;
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
        }

        public void CreateStartInOutMethods()
        {
            adapterClass.Add(new MethodElement("public virtual void InStart(Start<{0}> node)", true, grammar.RootProduction));
            adapterClass.Add(new MethodElement("public virtual void OutStart(Start<{0}> node)", true, grammar.RootProduction));
        }
        public void CreateStartCaseMethod()
        {
            MethodElement method;
            adapterClass.Add(method = new MethodElement("public override void CaseStart(Start<{0}> node)", true, grammar.RootProduction));

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
        }

        public void CreateDefaultProductionMethods()
        {
            adapterClass.Add(new MethodElement("public virtual void DefaultPIn(Node node)"));
            adapterClass.Add(new MethodElement("public virtual void DefaultPOut(Node node)"));
        }
        public void CreateDefaultAlternativeMethods()
        {
            adapterClass.Add(new MethodElement("public virtual void DefaultAIn(Node node)"));
            adapterClass.Add(new MethodElement("public virtual void DefaultAOut(Node node)"));
        }

        #endregion

        public override void InAProduction(AProduction node)
        {
            adapterClass.EmitNewline();
            EmitInOut("P" + node.Identifier.Text.ToCamelCase());
        }

        public override void CaseAAlternative(AAlternative node)
        {
            EmitInOut(node.ClassName);

            adapterClass.Add(method = new MethodElement("public override void Case{0}({0} node)", true, node.ClassName));
            method.Body.EmitLine("In{0}(node);", node.Production.ClassName);
            method.Body.EmitLine("In{0}(node);", node.ClassName);
            method.Body.EmitNewLine();

            var elements = reversed ? node.Elements.Reverse() : node.Elements;
            foreach (var e in elements)
                Visit(e);

            method.Body.EmitNewLine();
            method.Body.EmitLine("Out{0}(node);", node.ClassName);
            method.Body.EmitLine("Out{0}(node);", node.Production.ClassName);
        }

        private void EmitInOut(string name)
        {
            MethodElement method;
            adapterClass.Add(method = new MethodElement("public virtual void In{0}({0} node)", true, name));
            method.Body.EmitLine("Default{0}In(node);", name[0]);

            adapterClass.Add(method = new MethodElement("public virtual void Out{0}({0} node)", true, name));
            method.Body.EmitLine("Default{0}Out(node);", name[0]);
        }

        public override void CaseAElement(AElement node)
        {
            string dynamic = node.Elementid.Identifier.IsPProduction ? "(dynamic)" : "";
            string name = ToCamelCase(node.LowerName);

            switch (node.ElementType)
            {
                case ElementTypes.Simple:
                    method.Body.EmitLine("Visit({0}node.{1});", dynamic, name);
                    break;

                case ElementTypes.Question:
                    method.Body.EmitLine("if (node.Has{0})", name);
                    method.Body.IncreaseIndentation();
                    method.Body.EmitLine("Visit({0}node.{1});", dynamic, name);
                    method.Body.DecreaseIndentation();
                    break;

                case ElementTypes.Plus:
                case ElementTypes.Star:
                    method.Body.EmitLine("Visit(node.{0});", name);
                    break;
            }
        }
    }
}
