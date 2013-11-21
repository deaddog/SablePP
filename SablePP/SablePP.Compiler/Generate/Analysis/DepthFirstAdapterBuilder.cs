using System;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate.CSharp;

namespace SablePP.Compiler.Generate.Analysis
{
    public class DepthFirstAdapterBuilder : GenerateVisitor
    {
        private ClassElement adapterClass;
        private AGrammar grammar;

        private bool reversed;
        private MethodElement method;

        public DepthFirstAdapterBuilder(NameSpaceElement namespaceElement, bool reversed)
        {
            this.reversed = reversed;

            string className = (reversed ? "Reverse" : "") + "DepthFirstAdapter";

            namespaceElement.CreateClass(className, AccessModifiers.@public, className + "<object>");
            adapterClass = namespaceElement.CreateClass(className, AccessModifiers.@public, "AnalysisAdapter<TValue>");
            adapterClass.TypeParameters.Add("TValue");
        }

        public override void CaseAGrammar(AGrammar node)
        {
            this.grammar = node;

            CreateVisitNodeMethod();
            adapterClass.EmitNewLine();

            CreateStartInOutMethods();
            CreateStartCaseMethod();
            adapterClass.EmitNewLine();

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

        public void CreateVisitNodeMethod()
        {
            var method = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "Visit", "void");
            method.Parameters.Add("node", "Node");
            method.EmitIdentifier("Visit");
            using (var par = method.EmitParenthesis())
            {
                par.EmitDynamic(true);
                par.EmitIdentifier("node");
            }
            method.EmitSemicolon(true);
        }

        public void CreateStartInOutMethods()
        {
            var inMethod = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "InStart", "void");
            inMethod.Parameters.Add("node", "Start<" + grammar.RootProduction + ">");

            var outMethod = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "OutStart", "void");
            outMethod.Parameters.Add("node", "Start<" + grammar.RootProduction + ">");
        }
        public void CreateStartCaseMethod()
        {
            var method = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "CaseStart", "void");
            method.Parameters.Add("node", "Start<" + grammar.RootProduction + ">");

            method.EmitIdentifier("InStart");
            using (var par = method.EmitParenthesis())
                par.EmitIdentifier("node");
            method.EmitSemicolon(true);
            method.EmitNewLine();

            if (!reversed)
            {
                EmitVisitStartMethodCall(method);
                EmitVisitEOFMethodCall(method);
            }
            else
            {
                EmitVisitEOFMethodCall(method);
                EmitVisitStartMethodCall(method);
            }
            method.EmitNewLine();

            method.EmitIdentifier("OutStart");
            using (var par = method.EmitParenthesis())
                par.EmitIdentifier("node");
            method.EmitSemicolon(true);
        }
        public void EmitVisitStartMethodCall(MethodElement method)
        {
            method.EmitIdentifier("Visit");
            using (var par = method.EmitParenthesis())
            {
                using (var par2 = par.EmitParenthesis())
                    par2.EmitIdentifier("dynamic");
                par.EmitIdentifier("node");
                par.EmitPeriod();
                par.EmitIdentifier("Root");
            }
            method.EmitSemicolon(true);
        }
        public void EmitVisitEOFMethodCall(MethodElement method)
        {
            method.EmitIdentifier("Visit");
            using (var par = method.EmitParenthesis())
            {
                par.EmitIdentifier("node");
                par.EmitPeriod();
                par.EmitIdentifier("EOF");
            }
            method.EmitSemicolon(true);
        }

        public void CreateDefaultProductionMethods()
        {
            var inMethod = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultPIn", "void");
            inMethod.Parameters.Add("node", "Node");
            var outMethod = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultPOut", "void");
            outMethod.Parameters.Add("node", "Node");
        }
        public void CreateDefaultAlternativeMethods()
        {
            var inMethod = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultAIn", "void");
            inMethod.Parameters.Add("node", "Node");
            var outMethod = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultAOut", "void");
            outMethod.Parameters.Add("node", "Node");
        }

        #endregion

        public override void InAProduction(AProduction node)
        {
            adapterClass.EmitNewLine();
            EmitInOut("P" + node.Identifier.Text.ToCamelCase());
        }

        public override void CaseAAlternative(AAlternative node)
        {
            EmitInOut(node.ClassName);

            method = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "Case" + node.ClassName, "void");
            method.Parameters.Add("node", node.ClassName);

            method.EmitIdentifier("In" + node.ProductionName);
            using (var par = method.EmitParenthesis())
                par.EmitIdentifier("node");
            method.EmitSemicolon(true);

            method.EmitIdentifier("In" + node.ClassName);
            using (var par = method.EmitParenthesis())
                par.EmitIdentifier("node");
            method.EmitSemicolon(true);
            method.EmitNewLine();

            Visit(node.Elements);

            method.EmitNewLine();
            method.EmitIdentifier("Out" + node.ClassName);
            using (var par = method.EmitParenthesis())
                par.EmitIdentifier("node");
            method.EmitSemicolon(true);

            method.EmitIdentifier("Out" + node.ProductionName);
            using (var par = method.EmitParenthesis())
                par.EmitIdentifier("node");
            method.EmitSemicolon(true);
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
            var methodIn = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "In" + name, "void");
            methodIn.Parameters.Add("node", name);
            methodIn.EmitIdentifier("Default" + name[0] + "In");
            using (var par = methodIn.EmitParenthesis())
                par.EmitIdentifier("node");
            methodIn.EmitSemicolon(true);

            var methodOut = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "Out" + name, "void");
            methodOut.Parameters.Add("node", name);
            methodOut.EmitIdentifier("Default" + name[0] + "Out");
            using (var par = methodOut.EmitParenthesis())
                par.EmitIdentifier("node");
            methodOut.EmitSemicolon(true);
        }

        public override void CaseASimpleElement(ASimpleElement node)
        {
            method.EmitIdentifier("Visit");
            using (var par = method.EmitParenthesis())
            {
                if (node.Elementid.TIdentifier.IsProduction)
                    par.EmitDynamic(true);
                par.EmitIdentifier("node");
                par.EmitPeriod();
                par.EmitIdentifier(ToCamelCase(node.LowerName));
            }
            method.EmitSemicolon(true);
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            using (var @if = method.EmitIf())
            {
                @if.EmitIdentifier("node");
                @if.EmitPeriod();
                @if.EmitIdentifier("Has" + ToCamelCase(node.LowerName));
            }
            method.EmitNewLine();
            method.IncreaseIndentation();
            method.EmitIdentifier("Visit");
            using (var par = method.EmitParenthesis())
            {
                if (node.Elementid.TIdentifier.IsProduction)
                    par.EmitDynamic(true);
                par.EmitIdentifier("node");
                par.EmitPeriod();
                par.EmitIdentifier(ToCamelCase(node.LowerName));
            }
            method.EmitSemicolon(true);
            method.DecreaseIndentation();
        }
        public override void CaseAPlusElement(APlusElement node)
        {
            TIdentifier typeId = node.Elementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = ToCamelCase(node.LowerName);

            EmitListWalking(type, name, node);
        }
        public override void CaseAStarElement(AStarElement node)
        {
            TIdentifier typeId = node.Elementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = ToCamelCase(node.LowerName);

            EmitListWalking(type, name, node);
        }

        private void EmitListWalking(string type, string name, PElement node)
        {
            method.EmitBlockStart();

            //PAssignment[] temp = new PAssignment[node.Assignment.Count];
            method.EmitIdentifier(type + "[]");
            method.EmitIdentifier("temp");
            method.EmitAssignment();
            method.EmitNew();
            method.EmitIdentifier(type);
            using (var par = method.EmitParenthesis(ParenthesisElement.Types.Square))
            {
                par.EmitIdentifier("node");
                par.EmitPeriod();
                par.EmitIdentifier(name);
                par.EmitPeriod();
                par.EmitIdentifier("Count");
            }
            method.EmitSemicolon(true);

            //node.Assignment.CopyTo(temp, 0);
            method.EmitIdentifier("node");
            method.EmitPeriod();
            method.EmitIdentifier(name);
            method.EmitPeriod();
            method.EmitIdentifier("CopyTo");
            using (var par = method.EmitParenthesis())
            {
                par.EmitIdentifier("temp");
                par.EmitComma();
                par.EmitIntValue(0);
            }
            method.EmitSemicolon(true);

            if (!reversed)
                //for (int i = 0; i < temp.Length; i++)
                using (var par = method.EmitFor())
                {
                    par.EmitInt();
                    par.EmitIdentifier("i");
                    par.EmitAssignment();
                    par.EmitIntValue(0);
                    par.EmitSemicolon(false);
                    par.EmitIdentifier("i");
                    par.EmitLessThan();
                    par.EmitIdentifier("temp");
                    par.EmitPeriod();
                    par.EmitIdentifier("Length");
                    par.EmitSemicolon(false);
                    par.EmitIdentifier("i");
                    par.EmitPlusPlus();
                }
            else
                //for (int i = temp.Length - 1; i >= 0; i--)
                using (var par = method.EmitFor())
                {
                    par.EmitInt();
                    par.EmitIdentifier("i");
                    par.EmitAssignment();
                    par.EmitIdentifier("temp");
                    par.EmitPeriod();
                    par.EmitIdentifier("Length");
                    par.EmitMinus();
                    par.EmitIntValue(1);
                    par.EmitSemicolon(false);
                    par.EmitIdentifier("i");
                    par.EmitGreaterThanOrEqual();
                    par.EmitIntValue(0);
                    par.EmitSemicolon(false);
                    par.EmitIdentifier("i");
                    par.EmitMinusMinus();
                }
            method.EmitNewLine();

            //    Visit(temp[i]);
            method.IncreaseIndentation();
            method.EmitIdentifier("Visit");
            using (var par = method.EmitParenthesis())
            {
                if (node.PElementid.TIdentifier.IsProduction)
                    par.EmitDynamic(true);
                par.EmitIdentifier("temp");
                using (var square = par.EmitParenthesis(ParenthesisElement.Types.Square))
                    square.EmitIdentifier("i");
            }
            method.EmitSemicolon(true);
            method.DecreaseIndentation();

            method.EmitBlockEnd();
        }

    }
}
