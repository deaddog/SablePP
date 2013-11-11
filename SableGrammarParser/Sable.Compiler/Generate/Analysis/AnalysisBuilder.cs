using System;
using System.Collections.Generic;

using Sable.Compiler.Analysis;
using Sable.Compiler.Nodes;
using Sable.Tools.Generate.CSharp;
using Sable.Tools.Nodes;

namespace Sable.Compiler.Generate.Analysis
{
    public class AnalysisBuilder : GenerateVisitor
    {
        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private string productionName;

        private PGrammar grammar;

        private ClassElement returnAnalysisAdapter;

        private ClassElement depthFirstReturnAdapter;

        private AnalysisBuilder(PGrammar grammar)
        {
            this.grammar = grammar;

            fileElement = new FileElement();
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Collections.Generic");
            fileElement.Using.Add(ToolsNamespace.Analysis);
            fileElement.Using.Add(ToolsNamespace.Nodes);
        }

        public static FileElement BuildCode(Start<PGrammar> astRoot)
        {
            AnalysisBuilder n = new AnalysisBuilder(astRoot.Root);
            n.Visit(astRoot);
            return n.fileElement;
        }

        private string GetTokenName(PToken element)
        {
            if (element is AToken)
                return "T" + ToCamelCase((element as AToken).Identifier.Text);
            else
                throw new NotImplementedException("Unknown token type.");
        }

        private void CreateReturnAnalysisAdapter()
        {
            nameElement.CreateClass("ReturnAnalysisAdapter", AccessModifiers.@public, "ReturnAnalysisAdapter<object>");

            returnAnalysisAdapter = nameElement.CreateClass("ReturnAnalysisAdapter", AccessModifiers.@public, "ReturnAdapter<TValue, " + grammar.RootProduction + ">");
            returnAnalysisAdapter.TypeParameters.Add("TValue");
        }
        private void CreateDepthFirstReturnAdapter()
        {
            nameElement.CreateClass("DepthFirstReturnAdapter", AccessModifiers.@public, "DepthFirstReturnAdapter<object>");

            depthFirstReturnAdapter = nameElement.CreateClass("DepthFirstReturnAdapter", AccessModifiers.@public, "ReturnAnalysisAdapter<T>");
            depthFirstReturnAdapter.TypeParameters.Add("T");
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasPackage)
                Visit(node.Package);

            string packageName = node.PackageName;

            nameElement = fileElement.CreateNamespace(packageName + ".Analysis");
            fileElement.Using.Add(packageName + ".Nodes");

            List<DepthFirstAdapter> adapters = new List<DepthFirstAdapter>();
            adapters.Add(new AnalysisAdapterBuilder(nameElement));
            adapters.Add(new DepthFirstAdapterBuilder(nameElement));
            VisitInParallel(node, adapters.ToArray());
            CreateReturnAnalysisAdapter();

            CreateDepthFirstReturnAdapter();

            if (node.HasAstproductions)
                Visit(node.Astproductions);
            else if (node.HasProductions)
                Visit(node.Productions);

            if (node.HasTokens)
            {
                returnAnalysisAdapter.EmitNewLine();
                Visit(node.Tokens);
            }
        }

        public override void CaseAToken(AToken node)
        {
            string name = GetTokenName(node);

            EmitCase(name);
        }

        public override void CaseAAlternative(AAlternative node)
        {
            string name = "A" + productionName;
            if(node.HasAlternativename)
                name = "A" + ToCamelCase((node.Alternativename as AAlternativename).Name.Text) + productionName;

            EmitCase(name);
        }

        private void EmitCase(string name)
        {
            string caseName = "Case" + name;

            var visitType = returnAnalysisAdapter.CreateMethod(AccessModifiers.@public, "Visit", returnAnalysisAdapter.TypeParameters[0]);
            visitType.Parameters.Add("node", name);
            visitType.Parameters.Add("arg", returnAnalysisAdapter.TypeParameters[0]);
            visitType.EmitReturn();
            visitType.EmitIdentifier(caseName);
            using (var par = visitType.EmitParenthesis())
            {
                par.EmitIdentifier("node");
                par.EmitComma();
                par.EmitIdentifier("arg");
            }
            visitType.EmitSemicolon(true);

            var typeMethod = returnAnalysisAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, caseName, returnAnalysisAdapter.TypeParameters[0]);
            typeMethod.Parameters.Add("node", name);
            typeMethod.Parameters.Add("arg", returnAnalysisAdapter.TypeParameters[0]);

            typeMethod.EmitReturn();
            typeMethod.EmitIdentifier("DefaultCase");
            using (var par = typeMethod.EmitParenthesis())
            {
                par.EmitIdentifier("node");
                par.EmitComma();
                par.EmitIdentifier("arg");
            }
            typeMethod.EmitSemicolon(true);
        }
    }
}
