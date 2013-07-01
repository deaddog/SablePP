using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sable.Compiler.analysis;
using Sable.Compiler.node;
using Sable.Tools.Generate.CSharp;

namespace Sable.Compiler.Generate.Tokens
{
    public class TokenNodes : TokenVisitor
    {
        private FileElement fileElement;
        private NameSpaceElement nameElement;

        private string packageName = null;

        private TokenNodes()
        {
            fileElement = new FileElement();
            fileElement.Using.Add("System");
            fileElement.Using.Add("System.Collections.Generic");
        }

        public static FileElement BuildCode(Start astRoot)
        {
            TokenNodes n = new TokenNodes();
            astRoot.Apply(n);
            return n.fileElement;
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.GetPackage() != null)
                node.GetPackage().Apply(this);

            if (packageName == null)
                packageName = "SableCCPP";
            nameElement = fileElement.CreateNamespace(packageName + ".Nodes");
            fileElement.Using.Add(packageName + ".Analysis");

            if (node.GetTokens() != null)
                node.GetTokens().Apply(this);
        }

        public override void CaseTPackagename(TPackagename node)
        {
            this.packageName = node.Text;
        }
    }
}
