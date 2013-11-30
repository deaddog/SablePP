using System;
using System.Collections.Generic;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Error;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class HelperVisitor : DeclarationVisitor
    {
        private Dictionary<string, DHelper> helpers;
        private bool firstRun = true;

        private HelperVisitor(DeclarationTables declarations, ErrorManager errorManager)
            :base(errorManager)
        {
            this.helpers = declarations.Helpers;
        }

        public static void LoadHelperDeclarations(PHelpers node, DeclarationTables declarations, ErrorManager errorManager)
        {
            new HelperVisitor(declarations, errorManager).Visit(node);
        }

        public override void CaseAHelper(AHelper node)
        {
            if (firstRun)
            {
                string text = node.Identifier.Text;
                DHelper helper = new DHelper(node);
                if (helpers.ContainsKey(text))
                    RegisterError(node.Identifier, "Helper {0} has already been defined (line {1}).", node.Identifier, helpers[text].DeclarationToken.Line);
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
                Visit(node);
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
