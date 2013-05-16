using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
{
    public class StateVisitor : DeclarationVisitor
    {
        private Dictionary<string, DState> states = new Dictionary<string,DState>();

        public Dictionary<string, DState> GetStates()
        {
            Dictionary<string, DState> stateDict = new Dictionary<string, DState>();
            foreach (var s in states)
                stateDict.Add(s.Key, s.Value);
            return stateDict;
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
