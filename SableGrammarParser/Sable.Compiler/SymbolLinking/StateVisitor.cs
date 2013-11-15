using System;
using System.Collections.Generic;

using Sable.Compiler.Nodes;
using Sable.Tools.Error;

namespace Sable.Compiler.SymbolLinking
{
    public class StateVisitor : DeclarationVisitor
    {
        private Dictionary<string, DState> states;

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
            string text = node.Text;
            DState state = new DState(node);
            if (states.ContainsKey(text))
                RegisterError(node, "State {0} has already been defined.", node);
            else
                states.Add(text, state);

            node.SetDeclaration(states[text]);
        }
    }
}
