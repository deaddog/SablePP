using System;
using System.Collections.Generic;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Error;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class HelperVisitor : DeclarationVisitor
    {
        private DeclarationTables.DeclarationTable<DHelper> helpers;
        private bool firstRun = true;

        private HelperVisitor(DeclarationTables declarations, ErrorManager errorManager)
            : base(errorManager)
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
                if (!helpers.Declare(node.Identifier))
                    RegisterError(node.Identifier, "Helper {0} has already been defined (line {1}).", node.Identifier, helpers[node.Identifier].DeclarationToken.Line);
            }
            else
                Visit(node.Regex);
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
            if (!helpers.Link(node))
                RegisterError(node, "The helper {0} has not been defined.", node);
        }
    }
}
