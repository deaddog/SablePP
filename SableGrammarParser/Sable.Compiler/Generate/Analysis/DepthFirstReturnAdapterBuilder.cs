using System;

using Sable.Compiler.Nodes;
using Sable.Tools.Generate.CSharp;

namespace Sable.Compiler.Generate.Analysis
{
    public class DepthFirstReturnAdapterBuilder : GenerateVisitor
    {
        private const string VALUE_TYPE = "TValue";

        private ClassElement adapterClass;
        private AGrammar grammar;

        private bool reversed;
        private MethodElement method;

        public DepthFirstReturnAdapterBuilder(NameSpaceElement namespaceElement, bool reversed)
        {
            this.reversed = reversed;

            string className = (reversed ? "Reverse" : "") + "DepthFirstReturnAdapter";

            namespaceElement.CreateClass(className, AccessModifiers.@public, className + "<object>");
            adapterClass = namespaceElement.CreateClass(className, AccessModifiers.@public, "ReturnAnalysisAdapter<" + VALUE_TYPE + ">");
            adapterClass.TypeParameters.Add(VALUE_TYPE);
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

        private void EmitArgAssign()
        {
            method.EmitIdentifier("arg");
            method.EmitAssignment();
        }
        private void EmitReturnArg()
        {
            method.EmitReturn();
            method.EmitIdentifier("arg");
            method.EmitSemicolon(true);
        }

        #region Default methods

        public void CreateVisitNodeMethod()
        {
            var method = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "Visit", VALUE_TYPE);
            method.Parameters.Add("node", "Node");
            method.Parameters.Add("arg", VALUE_TYPE);
            method.EmitReturn();
            method.EmitIdentifier("Visit");
            using (var par = method.EmitParenthesis())
            {
                par.EmitDynamic(true);
                par.EmitIdentifier("node");
                par.EmitComma();
                par.EmitIdentifier("arg");
            }
            method.EmitSemicolon(true);
        }

        public void CreateStartInOutMethods()
        {
            method = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "InStart", VALUE_TYPE);
            method.Parameters.Add("node", "Start<" + grammar.RootProduction + ">");
            method.Parameters.Add("arg", VALUE_TYPE);
            EmitReturnArg();

            method = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "OutStart", VALUE_TYPE);
            method.Parameters.Add("node", "Start<" + grammar.RootProduction + ">");
            method.Parameters.Add("arg", VALUE_TYPE);
            EmitReturnArg();
        }
        public void CreateStartCaseMethod()
        {
            method = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "CaseStart", VALUE_TYPE);
            method.Parameters.Add("node", "Start<" + grammar.RootProduction + ">");
            method.Parameters.Add("arg", VALUE_TYPE);

            EmitArgAssign();
            method.EmitIdentifier("InStart");
            using (var par = method.EmitParenthesis())
            {
                par.EmitIdentifier("node");
                par.EmitComma();
                par.EmitIdentifier("arg");
            }
            method.EmitSemicolon(true);
            method.EmitNewLine();

            if (!reversed)
            {
                EmitVisitStartMethodCall();
                EmitVisitEOFMethodCall();
            }
            else
            {
                EmitVisitEOFMethodCall();
                EmitVisitStartMethodCall();
            }
            method.EmitNewLine();

            EmitArgAssign();
            method.EmitIdentifier("OutStart");
            using (var par = method.EmitParenthesis())
            {
                par.EmitIdentifier("node");
                par.EmitComma();
                par.EmitIdentifier("arg");
            }
            method.EmitSemicolon(true);
            method.EmitNewLine();

            EmitReturnArg();
        }
        public void EmitVisitStartMethodCall()
        {
            EmitArgAssign();
            method.EmitIdentifier("Visit");
            using (var par = method.EmitParenthesis())
            {
                using (var par2 = par.EmitParenthesis())
                    par2.EmitIdentifier("dynamic");
                par.EmitIdentifier("node");
                par.EmitPeriod();
                par.EmitIdentifier("Root");
                par.EmitComma();
                par.EmitIdentifier("arg");
            }
            method.EmitSemicolon(true);
        }
        public void EmitVisitEOFMethodCall()
        {
            EmitArgAssign();
            method.EmitIdentifier("Visit");
            using (var par = method.EmitParenthesis())
            {
                par.EmitIdentifier("node");
                par.EmitPeriod();
                par.EmitIdentifier("EOF");
                par.EmitComma();
                par.EmitIdentifier("arg");
            }
            method.EmitSemicolon(true);
        }

        public void CreateDefaultProductionMethods()
        {
            method = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultPIn", VALUE_TYPE);
            method.Parameters.Add("node", "Node");
            method.Parameters.Add("arg", VALUE_TYPE);
            EmitReturnArg();

            method = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultPOut", VALUE_TYPE);
            method.Parameters.Add("node", "Node");
            method.Parameters.Add("arg", VALUE_TYPE);
            EmitReturnArg();
        }
        public void CreateDefaultAlternativeMethods()
        {
            method = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultAIn", VALUE_TYPE);
            method.Parameters.Add("node", "Node");
            method.Parameters.Add("arg", VALUE_TYPE);
            EmitReturnArg();

            method = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultAOut", VALUE_TYPE);
            method.Parameters.Add("node", "Node");
            method.Parameters.Add("arg", VALUE_TYPE);
            EmitReturnArg();
        }

        #endregion

        public override void InAProduction(AProduction node)
        {
            adapterClass.EmitNewLine();
            EmitInOut("P" + node.Identifier.Text.ToCamelCase());
        }

        private void EmitInOut(string name)
        {
            method = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "In" + name, VALUE_TYPE);
            method.Parameters.Add("node", name);
            method.Parameters.Add("arg", VALUE_TYPE);

            method.EmitReturn();
            method.EmitIdentifier("Default" + name[0] + "In");
            using (var par = method.EmitParenthesis())
            {
                par.EmitIdentifier("node");
                par.EmitComma();
                par.EmitIdentifier("arg");
            }
            method.EmitSemicolon(true);

            method = adapterClass.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "Out" + name, VALUE_TYPE);
            method.Parameters.Add("node", name);
            method.Parameters.Add("arg", VALUE_TYPE);

            method.EmitReturn();
            method.EmitIdentifier("Default" + name[0] + "Out");
            using (var par = method.EmitParenthesis())
            {
                par.EmitIdentifier("node");
                par.EmitComma();
                par.EmitIdentifier("arg");
            }
            method.EmitSemicolon(true);
        }
    }
}
