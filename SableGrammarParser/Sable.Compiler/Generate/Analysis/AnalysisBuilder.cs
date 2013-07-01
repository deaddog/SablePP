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

        private string packageName = null;

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

            if (packageName == null)
                packageName = "SableCCPP";
            nameElement = fileElement.CreateNamespace(packageName + ".Analysis");
            fileElement.Using.Add(packageName + ".Nodes");

            this.voidAnalysis = nameElement.CreateInterface("Analysis", AccessModifiers.@public);
            this.typeAnalysis = nameElement.CreateInterface("ReturnAnalysis", AccessModifiers.@public);
            this.typeAnalysis.TypeParameters.Add("T");

            if (node.GetAstproductions() != null)
                node.GetAstproductions().Apply(this);
            else if (node.GetProductions() != null)
                node.GetProductions().Apply(this);
            EmitCase("Start");

            if (node.GetTokens() != null)
            {
                voidAnalysis.EmitNewLine();
                typeAnalysis.EmitNewLine();
                node.GetTokens().Apply(this);
                EmitCase("EOF");
            }
        }

        public override void CaseAToken(AToken node)
        {
            string name = GetTokenName(node);

            EmitCase(name);
        }

        public override void CaseTPackagename(TPackagename node)
        {
            this.packageName = node.Text;
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
            var voidMethod = voidAnalysis.CreateMethod(AccessModifiers.None, "Case" + name, "void");
            voidMethod.Parameters.Add("node", name);

            var typeMethod = typeAnalysis.CreateMethod(AccessModifiers.None, "Case" + name, typeAnalysis.TypeParameters[0]);
            typeMethod.Parameters.Add("node", name);
            typeMethod.Parameters.Add("arg", typeAnalysis.TypeParameters[0]);
        }
    }
}
