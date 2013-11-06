using System;

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

        private ClassElement analysisAdapter;
        private ClassElement returnAnalysisAdapter;

        private ClassElement depthFirstAdapter;
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

        private void CreateAnalysisAdapter()
        {
            nameElement.CreateClass("AnalysisAdapter", AccessModifiers.@public, "AnalysisAdapter<object>");

            analysisAdapter = nameElement.CreateClass("AnalysisAdapter", AccessModifiers.@public, "Adapter<TValue, " + grammar.RootProduction + ">");
            analysisAdapter.TypeParameters.Add("TValue");
        }
        private void CreateReturnAnalysisAdapter()
        {
            nameElement.CreateClass("ReturnAnalysisAdapter", AccessModifiers.@public, "ReturnAnalysisAdapter<object>");

            returnAnalysisAdapter = nameElement.CreateClass("ReturnAnalysisAdapter", AccessModifiers.@public, "ReturnAdapter<TValue, " + grammar.RootProduction + ">");
            returnAnalysisAdapter.TypeParameters.Add("TValue");
        }
        private void CreateDepthFirstAdapter()
        {
            nameElement.CreateClass("DepthFirstAdapter", AccessModifiers.@public, "DepthFirstAdapter<object>");

            depthFirstAdapter = nameElement.CreateClass("DepthFirstAdapter", AccessModifiers.@public, "AnalysisAdapter<TValue>");
            depthFirstAdapter.TypeParameters.Add("TValue");

            var visit = depthFirstAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "Visit", "void");
            visit.Parameters.Add("node", "Node");
            visit.EmitIdentifier("Visit");
            using(var par = visit.EmitParenthesis())
            {
                EmitDynamic(par);
                par.EmitIdentifier("node");
            }
            visit.EmitSemicolon(true);

            depthFirstAdapter.EmitNewLine();

            var sIn = depthFirstAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "InStart", "void");
            sIn.Parameters.Add("node", "Start<" + grammar.RootProduction + ">");
            var sOut = depthFirstAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, "OutStart", "void");
            sOut.Parameters.Add("node", "Start<" + grammar.RootProduction + ">");

            var sCase = depthFirstAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@override, "CaseStart", "void");
            sCase.Parameters.Add("node", "Start<" + grammar.RootProduction + ">");
            sCase.EmitIdentifier("InStart");
            using (var par = sCase.EmitParenthesis())
                par.EmitIdentifier("node");
            sCase.EmitSemicolon(true);
            sCase.EmitNewLine();
            sCase.EmitIdentifier("Visit");
            using (var par = sCase.EmitParenthesis())
            {
                using (var par2 = par.EmitParenthesis())
                    par2.EmitIdentifier("dynamic");
                par.EmitIdentifier("node");
                par.EmitPeriod();
                par.EmitIdentifier("Root");
            }
            sCase.EmitSemicolon(true);
            sCase.EmitIdentifier("Visit");
            using (var par = sCase.EmitParenthesis())
            {
                par.EmitIdentifier("node");
                par.EmitPeriod();
                par.EmitIdentifier("EOF");
            }
            sCase.EmitSemicolon(true);
            sCase.EmitNewLine();
            sCase.EmitIdentifier("OutStart");
            using (var par = sCase.EmitParenthesis())
                par.EmitIdentifier("node");
            sCase.EmitSemicolon(true);

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

            CreateAnalysisAdapter();
            CreateReturnAnalysisAdapter();

            CreateDepthFirstAdapter();
            CreateDepthFirstReturnAdapter();

            if (node.HasAstproductions)
                Visit(node.Astproductions);
            else if (node.HasProductions)
                Visit(node.Productions);

            if (node.HasTokens)
            {
                analysisAdapter.EmitNewLine();
                returnAnalysisAdapter.EmitNewLine();
                Visit(node.Tokens);
            }
        }

        public override void CaseAToken(AToken node)
        {
            string name = GetTokenName(node);

            EmitCase(name);
        }

        public override void CaseAProduction(AProduction node)
        {
            this.productionName = ToCamelCase(node.Identifier.Text);
            string name = "P" + productionName;

            depthFirstAdapter.EmitNewLine();
            EmitInOut(name);

            base.CaseAProduction(node);
        }

        MethodElement voidMethod;
        public override void CaseAAlternative(AAlternative node)
        {
            string name = "A" + productionName;
            if(node.HasAlternativename)
                name = "A" + ToCamelCase((node.Alternativename as AAlternativename).Name.Text) + productionName;

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

            Visit(node.Elements);

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
            voidMethod.EmitIdentifier("Visit");
            using (var par = voidMethod.EmitParenthesis())
            {
                if (node.Elementid.TIdentifier.IsProduction)
                    EmitDynamic(par);
                par.EmitIdentifier("node");
                par.EmitPeriod();
                par.EmitIdentifier(ToCamelCase(node.LowerName));
            }
            voidMethod.EmitSemicolon(true);
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            using (var iff = voidMethod.EmitIf())
            {
                iff.EmitIdentifier("node");
                iff.EmitPeriod();
                iff.EmitIdentifier("Has" + ToCamelCase(node.LowerName));
            }
            voidMethod.EmitNewLine();
            voidMethod.IncreaseIndentation();
            voidMethod.EmitIdentifier("Visit");
            using (var par = voidMethod.EmitParenthesis())
            {
                if (node.Elementid.TIdentifier.IsProduction)
                    EmitDynamic(par);
                par.EmitIdentifier("node");
                par.EmitPeriod();
                par.EmitIdentifier(ToCamelCase(node.LowerName));
            }
            voidMethod.EmitSemicolon(true);
            voidMethod.DecreaseIndentation();
        }
        public override void CaseAStarElement(AStarElement node)
        {
            TIdentifier typeId = node.Elementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = ToCamelCase(node.LowerName);

            EmitListWalking(type, name, node);
        }
        public override void CaseAPlusElement(APlusElement node)
        {
            TIdentifier typeId = node.Elementid.TIdentifier;
            string type = (typeId.IsToken ? "T" + ToCamelCase(typeId.AsToken.Name) : "P" + ToCamelCase(typeId.AsProduction.Name));
            string name = ToCamelCase(node.LowerName);

            EmitListWalking(type, name, node);
        }

        private void EmitDynamic(ExecutableElement element)
        {
            using (var par = element.EmitParenthesis())
                par.EmitIdentifier("dynamic");
        }

        private void EmitListWalking(string type, string name, PElement node)
        {
            voidMethod.EmitBlockStart();

            //PAssignment[] temp = new PAssignment[node.Assignment.Count];
            voidMethod.EmitIdentifier(type + "[]");
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

            //    Visit(temp[i]);
            voidMethod.IncreaseIndentation();
            voidMethod.EmitIdentifier("Visit");
            using (var par = voidMethod.EmitParenthesis())
            {
                if (node.PElementid.TIdentifier.IsProduction)
                    EmitDynamic(par);
                par.EmitIdentifier("temp");
                using (var square = par.EmitParenthesis(ParenthesisElement.Types.Square))
                    square.EmitIdentifier("i");
            }
            voidMethod.EmitSemicolon(true);
            voidMethod.DecreaseIndentation();

            voidMethod.EmitBlockEnd();
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
            string caseName = "Case" + name;

            var visitVoid = analysisAdapter.CreateMethod(AccessModifiers.@public, "Visit", "void");
            visitVoid.Parameters.Add("node", name);
            visitVoid.EmitIdentifier(caseName);
            using (var par = visitVoid.EmitParenthesis())
                par.EmitIdentifier("node");
            visitVoid.EmitSemicolon(true);

            var voidMethod = analysisAdapter.CreateMethod(AccessModifiers.@public | AccessModifiers.@virtual, caseName, "void");
            voidMethod.Parameters.Add("node", name);

            voidMethod.EmitIdentifier("DefaultCase");
            using (var par = voidMethod.EmitParenthesis())
                par.EmitIdentifier("node");
            voidMethod.EmitSemicolon(true);

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
