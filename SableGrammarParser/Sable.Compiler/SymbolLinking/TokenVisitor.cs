using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sable.Compiler.Nodes;

namespace Sable.Compiler.SymbolLinking
{
    public class TokenVisitor : DeclarationVisitor
    {
        private Dictionary<string, DHelper> helpers;
        private Dictionary<string, DState> states;
        private Dictionary<string, DToken> tokens;

        public Dictionary<string, DToken> GetTokens()
        {
            Dictionary<string, DToken> tokenDict = new Dictionary<string, DToken>();
            foreach (var s in tokens)
                tokenDict.Add(s.Key, s.Value);
            return tokenDict;
        }

        public TokenVisitor(IEnumerable<KeyValuePair<string, DHelper>> helpers, IEnumerable<KeyValuePair<string, DState>> states)
        {
            this.helpers = new Dictionary<string, DHelper>();
            foreach (var v in helpers)
                this.helpers.Add(v.Key, v.Value);

            this.states = new Dictionary<string, DState>();
            foreach (var v in states)
                this.states.Add(v.Key, v.Value);

            this.tokens = new Dictionary<string, DToken>();
        }

        public override void CaseAToken(AToken node)
        {
            if (node.HasStatelist)
                Visit(node.Statelist);

            string text = node.Identifier.Text;

            DToken token = new DToken(node);
            if (tokens.ContainsKey(text))
                RegisterError(node.Identifier, "Token {0} has already been defined (line {1}).", node.Identifier, tokens[text].DeclarationToken.Line);
            else
                tokens.Add(text, token);
            node.Identifier.SetDeclaration(tokens[text]);

            Visit(node.Regex);
            if (node.HasTokenlookahead)
                Visit(node.Tokenlookahead);
        }

        public override void CaseATokenstateListitem(ATokenstateListitem node)
        {
            DState state = null;
            if (states.TryGetValue(node.Identifier.Text, out state))
                node.Identifier.SetDeclaration(state);
            else
                RegisterError(node.Identifier, "The state {0} has not been defined.", node.Identifier);
        }
        public override void CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node)
        {
            {
                DState state = null;
                if (states.TryGetValue(node.From.Text, out state))
                    node.From.SetDeclaration(state);
                else
                    RegisterError(node.From, "The state {0} has not been defined.", node.From);
            }
            {
                DState state = null;
                if (states.TryGetValue(node.To.Text, out state))
                    node.To.SetDeclaration(state);
                else
                    RegisterError(node.To, "The state {0} has not been defined.", node.To);
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
