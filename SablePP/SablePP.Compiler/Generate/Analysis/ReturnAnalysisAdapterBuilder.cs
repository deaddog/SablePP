﻿using System;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Generate.CSharp;

namespace SablePP.Compiler.Generate.Analysis
{
    public class ReturnAnalysisAdapterBuilder : GenerateVisitor
    {
        private static readonly string typeParameter = "Result";
        private ClassElement returnAnalysisAdapter;
        private int argumentCount;

        public ReturnAnalysisAdapterBuilder(NameSpaceElement nameElement, byte arguments, PGrammar grammar)
        {
            this.argumentCount = arguments;

            string baseClass = "";
            for (int i = 1; i <= argumentCount; i++)
                baseClass += "T" + i + ", ";
            baseClass += typeParameter + ", " + grammar.RootProduction;

            nameElement.Add(returnAnalysisAdapter = new ClassElement("public class ReturnAnalysisAdapter : ReturnAdapter<{0}>", baseClass));
            for (int i = 1; i <= argumentCount; i++)
                returnAnalysisAdapter.TypeParameters.Add("T" + i);
            returnAnalysisAdapter.TypeParameters.Add(typeParameter);
        }

        public override void CaseAGrammar(AGrammar node)
        {
            MethodElement method;
            returnAnalysisAdapter.Add(method = new MethodElement("public override {0} Visit(Node node)", true, returnAnalysisAdapter.TypeParameters[argumentCount]));
            for (int i = 1; i <= argumentCount; i++)
                method.Parameters.Add("{0} arg{1}", returnAnalysisAdapter.TypeParameters[i - 1], i);
            method.Body.Emit("return Visit((dynamic)node");
            for (int i = 1; i <= argumentCount; i++)
                method.Body.Emit(", arg{0}", i);
            method.Body.EmitLine(");");

            returnAnalysisAdapter.EmitNewline();

            if (node.HasAstproductions)
                Visit(node.Astproductions);
            else if (node.HasProductions)
                Visit(node.Productions);

            if (node.HasTokens)
                Visit(node.Tokens);
        }

        public override void CaseAToken(AToken node)
        {
            EmitCase(node.ClassName);
        }

        public override void CaseAAlternative(AAlternative node)
        {
            EmitCase(node.ClassName);
        }
        private void EmitCase(string name)
        {
            string caseName = "Case" + name;

            MethodElement method;
            returnAnalysisAdapter.Add(method = new MethodElement("public {0} Visit({1} node)", true, returnAnalysisAdapter.TypeParameters[argumentCount], name));
            for (int i = 1; i <= argumentCount; i++)
                method.Parameters.Add("{0} arg{1}", returnAnalysisAdapter.TypeParameters[i - 1], i);

            method.Body.Emit("return {0}(node", caseName);
            for (int i = 1; i <= argumentCount; i++)
                method.Body.Emit(", arg{0}", i);
            method.Body.EmitLine(");");

            returnAnalysisAdapter.Add(method = new MethodElement("public virtual {2} {0}({1} node)", true, caseName, name, returnAnalysisAdapter.TypeParameters[argumentCount]));
            for (int i = 1; i <= argumentCount; i++)
                method.Parameters.Add("{0} arg{1}", returnAnalysisAdapter.TypeParameters[i - 1], i);

            method.Body.Emit("return DefaultCase(node");
            for (int i = 1; i <= argumentCount; i++)
                method.Body.Emit(", arg{0}", i);
            method.Body.EmitLine(");");
        }
    }
}
