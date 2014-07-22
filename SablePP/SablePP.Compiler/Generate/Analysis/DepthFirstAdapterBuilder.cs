using System;

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

            Visit(node.Elements);

            method.Body.EmitNewLine();
            method.Body.EmitLine("Out{0}(node);", node.ClassName);
            method.Body.EmitLine("Out{0}(node);", node.Production.ClassName);
        }

        public override void CaseAElements(AElements node)
        {
            if (!reversed)
                base.CaseAElements(node);
            else
            {
                InPElements(node);
                InAElements(node);


                {
                    PElement[] temp = new PElement[node.Element.Count];
                    node.Element.CopyTo(temp, 0);
                    for (int i = temp.Length - 1; i >= 0; i--)
                        Visit((dynamic)temp[i]);
                }

                OutAElements(node);
                OutPElements(node);
            }
        }

        private void EmitInOut(string name)
        {
            MethodElement method;
            adapterClass.Add(method = new MethodElement("public virtual void In{0}({0} node)", true, name));
            method.Body.EmitLine("Default{0}In(node);", name[0]);

            adapterClass.Add(method = new MethodElement("public virtual void Out{0}({0} node)", true, name));
            method.Body.EmitLine("Default{0}Out(node);", name[0]);
        }

        public override void CaseASimpleElement(ASimpleElement node)
        {
            method.Body.EmitLine("Visit({0}node.{1});", node.Elementid.Identifier.IsPProduction ? "(dynamic)" : "", ToCamelCase(node.LowerName));
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            method.Body.EmitLine("if (node.Has{0})", ToCamelCase(node.LowerName));
            method.Body.IncreaseIndentation();
            method.Body.EmitLine("Visit({0}node.{1});", node.Elementid.Identifier.IsPProduction ? "(dynamic)" : "", ToCamelCase(node.LowerName));
            method.Body.DecreaseIndentation();
        }
        public override void CaseAPlusElement(APlusElement node)
        {
            TIdentifier typeId = node.Elementid.Identifier;
            string type = (typeId.IsPToken ? typeId.AsPToken.ClassName : typeId.AsPProduction.Declaration.ClassName);
            string name = ToCamelCase(node.LowerName);

            EmitListWalking(type, name, node);
        }
        public override void CaseAStarElement(AStarElement node)
        {
            TIdentifier typeId = node.Elementid.Identifier;
            string type = (typeId.IsPToken ? typeId.AsPToken.ClassName : typeId.AsPProduction.Declaration.ClassName);
            string name = ToCamelCase(node.LowerName);

            EmitListWalking(type, name, node);
        }

        private void EmitListWalking(string type, string name, PElement node)
        {
            method.Body.EmitLine("{");
            method.Body.IncreaseIndentation();

            method.Body.EmitLine("{0}[] temp = new {0}[node.{1}.Count];", type, name);
            method.Body.EmitLine("node.{0}.CopyTo(temp, 0);", name);

            if (!reversed)
                method.Body.EmitLine("for (int i = 0; i < temp.Length; i++)");
            else
                method.Body.EmitLine("for (int i = temp.Length - 1; i >= 0; i--)");
            method.Body.IncreaseIndentation();

            method.Body.EmitLine("Visit({0}temp[i]);", node.Elementid.Identifier.IsPProduction ? "(dynamic)" : "");
            method.Body.DecreaseIndentation();

            method.Body.DecreaseIndentation();
            method.Body.EmitLine("}");
        }

    }
}
