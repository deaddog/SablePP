using System;
using System.IO;
using System.Text;

using SablePP.Compiler.Analysis;
using SablePP.Tools.Nodes;

namespace SablePP.Compiler
{
    public class SableGrammarEmitter : DepthFirstAdapter
    {
        private Stream stream;
        private Encoding encoding;

        public SableGrammarEmitter(Stream stream)
        {
            this.stream = stream;
            this.encoding = new System.Text.UTF8Encoding(false);
        }

        public override void CaseAGrammar(Nodes.AGrammar node)
        {
            if (node.HasPackage)
                Visit((dynamic)node.Package);
            if (node.HasHelpers)
                Visit((dynamic)node.Helpers);
            if (node.HasStates)
                Visit((dynamic)node.States);
            if (node.HasTokens)
                Visit((dynamic)node.Tokens);
            if (node.HasIgnoredtokens)
                Visit((dynamic)node.Ignoredtokens);
            if (node.HasProductions)
                Visit((dynamic)node.Productions);
            if (node.HasAstproductions)
                Visit((dynamic)node.Astproductions);
        }
        private void write(string text)
        {
            byte[] buffer = encoding.GetBytes(text);
            stream.Write(buffer, 0, buffer.Length);
        }
        private void writeNewline()
        {
            write("\r\n");
        }

        public override void CaseTPackagetoken(Nodes.TPackagetoken node)
        {
            DefaultCase(new Nodes.TPackagetoken("Package", node.Line, node.Position));
        }

        public override void DefaultCase(Node node)
        {
            if (node is Token)
                write((node as Token).Text  +  " ");
            else
                base.DefaultCase(node);
        }

        // Newline rules

        public override void CaseAPackage(Nodes.APackage node)
        {
            base.CaseAPackage(node);
            writeNewline();
        }

        public override void CaseTHelperstoken(Nodes.THelperstoken node)
        {
            base.CaseTHelperstoken(node);
            writeNewline();
        }
        public override void CaseAHelper(Nodes.AHelper node)
        {
            base.CaseAHelper(node);
            writeNewline();
        }

        public override void CaseAStates(Nodes.AStates node)
        {
            base.CaseAStates(node);
            writeNewline();
        }

        public override void CaseTTokenstoken(Nodes.TTokenstoken node)
        {
            base.CaseTTokenstoken(node);
            writeNewline();
        }
        public override void CaseAToken(Nodes.AToken node)
        {
            base.CaseAToken(node);
            writeNewline();
        }

        public override void CaseAIgnoredtokens(Nodes.AIgnoredtokens node)
        {
            base.CaseAIgnoredtokens(node);
            writeNewline();
        }

        public override void CaseTProductionstoken(Nodes.TProductionstoken node)
        {
            base.CaseTProductionstoken(node);
            writeNewline();
        }
        public override void CaseTAsttoken(Nodes.TAsttoken node)
        {
            base.CaseTAsttoken(node);
            writeNewline();
        }
        public override void CaseAProduction(Nodes.AProduction node)
        {
            base.CaseAProduction(node);
            writeNewline();
        }
    }
}
