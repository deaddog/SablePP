using System;
using System.Collections.Generic;

using SablePP.Compiler.Nodes;
using SablePP.Tools.Error;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class StateVisitor : DeclarationVisitor
    {
        private DeclarationTables.DeclarationTable<DState> states;

        private StateVisitor(DeclarationTables declarations, ErrorManager errorManager)
            : base(errorManager)
        {
            this.states = declarations.States;
        }

        public static void LoadStateDeclarations(PStates node, DeclarationTables declarations, ErrorManager errorManager)
        {
            new StateVisitor(declarations, errorManager).Visit(node);
        }

        public override void CaseTIdentifier(TIdentifier node)
        {
            if (!states.Declare(node))
                RegisterError(node, "State {0} has already been defined.", node);
        }
    }
}
