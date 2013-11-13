using System;
using System.IO;
using System.Text;

using Sable.Compiler.Analysis;

namespace Sable.Compiler
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
    }
}
