using System;

using Sable.Compiler.Nodes;
using Sable.Tools.Generate.CSharp;

namespace Sable.Compiler.Generate.Analysis
{
    public class DepthFirstReturnAdapterBuilder : GenerateVisitor
    {
        private ClassElement adapterClass;
        private AGrammar grammar;

        private bool reversed;
        private MethodElement method;

        public DepthFirstReturnAdapterBuilder(NameSpaceElement namespaceElement, bool reversed)
        {
            this.reversed = reversed;

            string className = (reversed ? "Reverse" : "") + "DepthFirstReturnAdapter";

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
    }
}
