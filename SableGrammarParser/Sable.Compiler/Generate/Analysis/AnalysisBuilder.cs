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

        private InterfaceElement iAnalysis;
        private InterfaceElement iReturnAnalysis;

        private ClassElement analysisAdapter;
        private ClassElement returnAnalysisAdapter;

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

        private void CreateIAnalysis()
        {
            iAnalysis = nameElement.CreateInterface("IAnalysis", AccessModifiers.@public);
            iAnalysis.TypeParameters.Add("TValue");

            iAnalysis.EmitGetProperty("Input", "Table<TValue>");
            iAnalysis.EmitGetProperty("Output", "Table<TValue>");
            iAnalysis.EmitNewLine();
        }
        private void CreateIReturnAnalysis()
        {
            iReturnAnalysis = nameElement.CreateInterface("IReturnAnalysis", AccessModifiers.@public);
            iReturnAnalysis.TypeParameters.Add("T");
        }
        private void CreateAnalysisAdapter()
        {
            nameElement.CreateClass("AnalysisAdapter", AccessModifiers.@public, "AnalysisAdapter<object>");

            analysisAdapter = nameElement.CreateClass("AnalysisAdapter", AccessModifiers.@public, "IAnalysis<TValue>");
            analysisAdapter.TypeParameters.Add("TValue");

            analysisAdapter.EmitField("input", "Table<TValue>", AccessModifiers.@private);
            analysisAdapter.EmitField("output", "Table<TValue>", AccessModifiers.@private);
            analysisAdapter.EmitNewLine();

            var constructor = analysisAdapter.CreateConstructor(AccessModifiers.@public);
            constructor.EmitThis();
            constructor.EmitPeriod();
            constructor.EmitIdentifier("input");
            constructor.EmitAssignment();
            constructor.EmitNew();
            constructor.EmitIdentifier("Table");
            using (var types = constructor.EmitParenthesis(ParenthesisElement.Types.Angled))
                types.EmitIdentifier("TValue");
            constructor.EmitParenthesis();
            constructor.EmitSemicolon(true);

            constructor.EmitThis();
            constructor.EmitPeriod();
            constructor.EmitIdentifier("output");
            constructor.EmitAssignment();
            constructor.EmitNew();
            constructor.EmitIdentifier("Table");
            using (var types = constructor.EmitParenthesis(ParenthesisElement.Types.Angled))
                types.EmitIdentifier("TValue");
            constructor.EmitParenthesis();
            constructor.EmitSemicolon(true);
            analysisAdapter.EmitNewLine();

            var input = analysisAdapter.CreateGetProperty(AccessModifiers.@public, "Input", "Table<TValue>");
            input.Get.EmitReturn();
            input.Get.EmitIdentifier("input");
            input.Get.EmitSemicolon(false);

            var output = analysisAdapter.CreateGetProperty(AccessModifiers.@public, "Output", "Table<TValue>");
            output.Get.EmitReturn();
            output.Get.EmitIdentifier("output");
            output.Get.EmitSemicolon(false);
            analysisAdapter.EmitNewLine();

            MethodElement voidmethod = analysisAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultCase", "void");
            voidmethod.Parameters.Add("node", "Node");
            analysisAdapter.EmitNewLine();
        }
        private void CreateReturnAnalysisAdapter()
        {
            nameElement.CreateClass("ReturnAnalysisAdapter", AccessModifiers.@public, "ReturnAnalysisAdapter<object>");

            returnAnalysisAdapter = nameElement.CreateClass("ReturnAnalysisAdapter", AccessModifiers.@public, "IReturnAnalysis<T>");
            returnAnalysisAdapter.TypeParameters.Add("T");

            MethodElement typemethod = returnAnalysisAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultCase", "T");
            typemethod.Parameters.Add("node", "Node");
            typemethod.Parameters.Add("arg", "T");
            typemethod.EmitReturn();
            typemethod.EmitIdentifier("arg");
            typemethod.EmitSemicolon(true);
            returnAnalysisAdapter.EmitNewLine();
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.GetPackage() != null)
                node.GetPackage().Apply(this);

            string packageName = node.PackageName;

            nameElement = fileElement.CreateNamespace(packageName + ".Analysis");
            fileElement.Using.Add(packageName + ".Nodes");

            CreateIAnalysis();
            CreateIReturnAnalysis();

            CreateAnalysisAdapter();
            CreateReturnAnalysisAdapter();

            if (node.GetAstproductions() != null)
                node.GetAstproductions().Apply(this);
            else if (node.GetProductions() != null)
                node.GetProductions().Apply(this);
            EmitCase("Start");

            if (node.GetTokens() != null)
            {
                iAnalysis.EmitNewLine();
                iReturnAnalysis.EmitNewLine();
                analysisAdapter.EmitNewLine();
                returnAnalysisAdapter.EmitNewLine();
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
            var voidMethod = iAnalysis.CreateMethod("Case" + name, "void");
            voidMethod.Parameters.Add("node", name);

            var typeMethod = iReturnAnalysis.CreateMethod("Case" + name, iReturnAnalysis.TypeParameters[0]);
            typeMethod.Parameters.Add("node", name);
            typeMethod.Parameters.Add("arg", iReturnAnalysis.TypeParameters[0]);
        }

        private void EmitAdapterCase(string name)
        {
            var voidMethod = analysisAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "Case" + name, "void");
            voidMethod.Parameters.Add("node", name);

            voidMethod.EmitIdentifier("DefaultCase");
            using (var par = voidMethod.EmitParenthesis())
                par.EmitIdentifier("node");
            voidMethod.EmitSemicolon(true);

            var typeMethod = returnAnalysisAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "Case" + name, returnAnalysisAdapter.TypeParameters[0]);
            typeMethod.Parameters.Add("node", name);
            typeMethod.Parameters.Add("arg", iReturnAnalysis.TypeParameters[0]);

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
