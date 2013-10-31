using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sable.Compiler.Nodes;

namespace Sable.Compiler.SymbolLinking
{
    public class HelperVisitor : DeclarationVisitor
    {
        private Dictionary<string, DHelper> helpers = new Dictionary<string, DHelper>();
        private bool firstRun = true;

        public Dictionary<string, DHelper> GetHelpers()
        {
            Dictionary<string, DHelper> helperDict = new Dictionary<string, DHelper>();
            foreach (var h in helpers)
                helperDict.Add(h.Key, h.Value);
            return helperDict;
        }

        public override void CaseAHelper(AHelper node)
        {
            if (firstRun)
            {
                string text = node.GetIdentifier().Text;
                DHelper helper = new DHelper(node);
                if (helpers.ContainsKey(text))
                    RegisterError(node.GetIdentifier(), "Helper {0} has already been defined (line {1}).", node.GetIdentifier(), helpers[text].DeclarationToken.Line);
                else
                    helpers.Add(text, helper);
            }
            else
            {
                base.CaseAHelper(node);
            }
        }
        public override void OutAHelpers(AHelpers node)
        {
            if (firstRun)
            {
                firstRun = false;
                node.Apply(this);
            }
        }

        public override void CaseTIdentifier(TIdentifier node)
        {
            DHelper helper = null;
            if (helpers.TryGetValue(node.Text, out helper))
                node.SetDeclaration(helper);
            else
                RegisterError(node, "The helper {0} has not been defined.", node);
        }
    }
}
