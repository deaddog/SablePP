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

        private ClassElement depthFirstAdapter;
        private ClassElement depthFirstReturnAdapter;

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
        private void CreateDepthFirstAdapter()
        {
            depthFirstAdapter = nameElement.CreateClass("DepthFirstAdapter", AccessModifiers.@public, "AnalysisAdapter<TValue>");
            depthFirstAdapter.TypeParameters.Add("TValue");

            var pIn = depthFirstAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultPIn", "void");
            pIn.Parameters.Add("node", "Node");
            var pOut = depthFirstAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultPOut", "void");
            pOut.Parameters.Add("node", "Node");
            var aIn = depthFirstAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultAIn", "void");
            aIn.Parameters.Add("node", "Node");
            var aOut = depthFirstAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "DefaultAOut", "void");
            aOut.Parameters.Add("node", "Node");
        }
        private void CreateDepthFirstReturnAdapter()
        {
            depthFirstReturnAdapter = nameElement.CreateClass("DepthFirstReturnAdapter", AccessModifiers.@public, "ReturnAnalysisAdapter<T>");
            depthFirstReturnAdapter.TypeParameters.Add("T");
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

            CreateDepthFirstAdapter();
            CreateDepthFirstReturnAdapter();

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

            depthFirstAdapter.EmitNewLine();
            EmitInOut(name);

            base.CaseAProduction(node);
        }

        MethodElement voidMethod;
        public override void CaseAAlternative(AAlternative node)
        {
            string name = "A" + productionName;
            if (node.GetAlternativename() != null)
                name = "A" + ToCamelCase((node.GetAlternativename() as AAlternativename).GetName().Text) + productionName;

            EmitInOut(name);

            EmitCase(name);

            voidMethod = depthFirstAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "Case" + name, "void");
            voidMethod.Parameters.Add("node", name);

            voidMethod.EmitIdentifier("InP" + productionName);
            using (var par = voidMethod.EmitParenthesis())
                par.EmitIdentifier("node");
            voidMethod.EmitSemicolon(true);

            voidMethod.EmitIdentifier("In" + name);
            using (var par = voidMethod.EmitParenthesis())
                par.EmitIdentifier("node");
            voidMethod.EmitSemicolon(true);
            voidMethod.EmitNewLine();

            node.GetElements().Apply(this);

            voidMethod.EmitNewLine();
            voidMethod.EmitIdentifier("Out" + name);
            using (var par = voidMethod.EmitParenthesis())
                par.EmitIdentifier("node");
            voidMethod.EmitSemicolon(true);

            voidMethod.EmitIdentifier("OutP" + productionName);
            using (var par = voidMethod.EmitParenthesis())
                par.EmitIdentifier("node");
            voidMethod.EmitSemicolon(true);
        }

        public override void CaseASimpleElement(ASimpleElement node)
        {
            voidMethod.EmitIdentifier("node");
            voidMethod.EmitPeriod();
            voidMethod.EmitIdentifier(ToCamelCase(node.LowerName));
            voidMethod.EmitPeriod();
            voidMethod.EmitIdentifier("Apply");
            using (var par = voidMethod.EmitParenthesis())
                par.EmitIdentifier("this");
            voidMethod.EmitSemicolon(true);
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            using(var iff = voidMethod.EmitIf())
            {
                iff.EmitIdentifier("node");
                iff.EmitPeriod();
                iff.EmitIdentifier("Has" + ToCamelCase(node.LowerName));
            }
            voidMethod.EmitNewLine();
            voidMethod.IncreaseIndentation();
            voidMethod.EmitIdentifier("node");
            voidMethod.EmitPeriod();
            voidMethod.EmitIdentifier(ToCamelCase(node.LowerName));
            voidMethod.EmitPeriod();
            voidMethod.EmitIdentifier("Apply");
            using (var par = voidMethod.EmitParenthesis())
                par.EmitIdentifier("this");
            voidMethod.EmitSemicolon(true);
            voidMethod.DecreaseIndentation();
        }
        public override void CaseAStarElement(AStarElement node)
        {
            TIdentifier typeId = node.GetElementid().Identifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = ToCamelCase(node.LowerName);

            EmitListWalking(type, name);
        }
        public override void CaseAPlusElement(APlusElement node)
        {
            TIdentifier typeId = node.GetElementid().Identifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = ToCamelCase(node.LowerName);

            EmitListWalking(type, name);
        }

        private void EmitListWalking(string type, string name)
        {
            //PAssignment[] temp = new PAssignment[node.Assignment.Count];
            voidMethod.EmitIdentifier(type);
            voidMethod.EmitParenthesis(ParenthesisElement.Types.Square);
            voidMethod.EmitIdentifier("temp");
            voidMethod.EmitAssignment();
            voidMethod.EmitNew();
            voidMethod.EmitIdentifier(type);
            using (var par = voidMethod.EmitParenthesis(ParenthesisElement.Types.Square))
            {
                par.EmitIdentifier("node");
                par.EmitPeriod();
                par.EmitIdentifier(name);
                par.EmitPeriod();
                par.EmitIdentifier("Count");
            }
            voidMethod.EmitSemicolon(true);

            //node.Assignment.CopyTo(temp, 0);
            voidMethod.EmitIdentifier("node");
            voidMethod.EmitPeriod();
            voidMethod.EmitIdentifier(name);
            voidMethod.EmitPeriod();
            voidMethod.EmitIdentifier("CopyTo");
            using (var par = voidMethod.EmitParenthesis())
            {
                par.EmitIdentifier("temp");
                par.EmitComma();
                par.EmitIntValue(0);
            }
            voidMethod.EmitSemicolon(true);

            //for (int i = 0; i < temp.Length; i++)
            using (var par = voidMethod.EmitFor())
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
            voidMethod.EmitNewLine();

            //    temp[i].Apply(this);
            voidMethod.IncreaseIndentation();
            voidMethod.EmitIdentifier("temp");
            using (var par = voidMethod.EmitParenthesis(ParenthesisElement.Types.Square))
                par.EmitIdentifier("i");
            voidMethod.EmitPeriod();
            voidMethod.EmitIdentifier("Apply");
            using (var par = voidMethod.EmitParenthesis())
                par.EmitIdentifier("this");
            voidMethod.EmitSemicolon(true);
            voidMethod.DecreaseIndentation();
        }

        private void EmitInOut(string name)
        {
            var methodIn = depthFirstAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "In" + name, "void");
            methodIn.Parameters.Add("node", name);
            methodIn.EmitIdentifier("Default" + name[0] + "In");
            using (var par = methodIn.EmitParenthesis())
                par.EmitIdentifier("node");
            methodIn.EmitSemicolon(true);

            var methodOut = depthFirstAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "Out" + name, "void");
            methodOut.Parameters.Add("node", name);
            methodOut.EmitIdentifier("Default" + name[0] + "Out");
            using (var par = methodOut.EmitParenthesis())
                par.EmitIdentifier("node");
            methodOut.EmitSemicolon(true);
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
