using System;

using Sable.Compiler.analysis;
using Sable.Compiler.node;
using Sable.Tools.Generate.CSharp;

namespace Sable.Compiler.Generate.Analysis
{
    public class AnalysisBuilder : GenerateVisitor
    {
        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private string productionName;

        private InterfaceElement voidAnalysis;
        private InterfaceElement typeAnalysis;

        private ClassElement voidAnalysisAdapter;
        private ClassElement typeAnalysisAdapter;

        private AnalysisBuilder()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Collections.Generic");
        }

        public static FileElement BuildCode(Start astRoot)
        {
            AnalysisBuilder n = new AnalysisBuilder();
            astRoot.Apply(n);
            return n.fileElement;
        }

        private string GetTokenName(PToken element)
        {
            if (element is AToken)
                return "T" + ToCamelCase((element as AToken).GetIdentifier().Text);
            else
                throw new NotImplementedException("Unknown token type.");
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.GetPackage() != null)
                node.GetPackage().Apply(this);

            string packageName = node.PackageName;

            nameElement = fileElement.CreateNamespace(packageName + ".Analysis");
            fileElement.Using.Add(packageName + ".Nodes");

            this.voidAnalysis = nameElement.CreateInterface("IAnalysis", AccessModifiers.@public);
            this.voidAnalysis.TypeParameters.Add("TValue");
            this.typeAnalysis = nameElement.CreateInterface("IReturnAnalysis", AccessModifiers.@public);
            this.typeAnalysis.TypeParameters.Add("T");

            this.voidAnalysis.EmitGetProperty("Input", "Table<TValue>");
            this.voidAnalysis.EmitGetProperty("Output", "Table<TValue>");

            this.voidAnalysisAdapter = nameElement.CreateClass("AnalysisAdapter", AccessModifiers.@public, "IAnalysis<TValue>");
            this.voidAnalysisAdapter.TypeParameters.Add("TValue");
            this.typeAnalysisAdapter = nameElement.CreateClass("ReturnAnalysisAdapter", AccessModifiers.@public, "IReturnAnalysis<T>");
            this.typeAnalysisAdapter.TypeParameters.Add("T");

            MethodElement voidmethod = this.voidAnalysisAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultCase", "void");
            voidmethod.Parameters.Add("node", "Node");
            voidAnalysisAdapter.EmitNewLine();

            MethodElement typemethod = this.typeAnalysisAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultCase", "T");
            typemethod.Parameters.Add("node", "Node");
            typemethod.Parameters.Add("arg", "T");
            typemethod.EmitReturn();
            typemethod.EmitIdentifier("arg");
            typemethod.EmitSemicolon(true);
            typeAnalysisAdapter.EmitNewLine();

            if (node.GetAstproductions() != null)
                node.GetAstproductions().Apply(this);
            else if (node.GetProductions() != null)
                node.GetProductions().Apply(this);
            EmitCase("Start");

            if (node.GetTokens() != null)
            {
                voidAnalysis.EmitNewLine();
                typeAnalysis.EmitNewLine();
                voidAnalysisAdapter.EmitNewLine();
                typeAnalysisAdapter.EmitNewLine();
                node.GetTokens().Apply(this);
                EmitCase("EOF");
            }
        }

        public override void CaseAToken(AToken node)
        {
            string name = GetTokenName(node);

            EmitCase(name);
        }

        public override void CaseAProduction(AProduction node)
        {
            this.productionName = ToCamelCase(node.GetIdentifier().Text);
            string name = "P" + productionName;

            base.CaseAProduction(node);
        }

        public override void CaseAAlternative(AAlternative node)
        {
            string name = "A" + productionName;
            if (node.GetAlternativename() != null)
                name = "A" + ToCamelCase((node.GetAlternativename() as AAlternativename).GetName().Text) + productionName;

            EmitCase(name);
        }

        private void EmitCase(string name)
        {
            EmitInterfaceCase(name);
            EmitAdapterCase(name);
        }

        private void EmitInterfaceCase(string name)
        {
            var voidMethod = voidAnalysis.CreateMethod("Case" + name, "void");
            voidMethod.Parameters.Add("node", name);

            var typeMethod = typeAnalysis.CreateMethod("Case" + name, typeAnalysis.TypeParameters[0]);
            typeMethod.Parameters.Add("node", name);
            typeMethod.Parameters.Add("arg", typeAnalysis.TypeParameters[0]);
        }

        private void EmitAdapterCase(string name)
        {
            var voidMethod = voidAnalysisAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "Case" + name, "void");
            voidMethod.Parameters.Add("node", name);

            voidMethod.EmitIdentifier("DefaultCase");
            using (var par = voidMethod.EmitParenthesis())
                par.EmitIdentifier("node");
            voidMethod.EmitSemicolon(true);

            var typeMethod = typeAnalysisAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "Case" + name, typeAnalysisAdapter.TypeParameters[0]);
            typeMethod.Parameters.Add("node", name);
            typeMethod.Parameters.Add("arg", typeAnalysis.TypeParameters[0]);

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
