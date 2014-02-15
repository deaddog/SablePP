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
        private int line;
        private int position;

        public SableGrammarEmitter(Stream stream)
        {
            this.stream = stream;
            this.encoding = new System.Text.UTF8Encoding(false);
            this.line = 1;
            this.position = 1;
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
            this.position += text.Length;
        }

        public override void DefaultCase(Node node)
        {
            if (node is Token)
            {
                Token token = node as Token;

                while (token.Line > line)
                {
                    write("\r\n");
                    this.position = 1;
                    this.line++;
                }
                if (token.Position > position)
                    write("".PadLeft(token.Position - position));

                write(token.Text);
            }
            else
            {
                string s = node.ToString();
                base.DefaultCase(node);
            }
        }
    }
}
