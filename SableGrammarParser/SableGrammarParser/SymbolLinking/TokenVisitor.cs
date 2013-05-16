using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SableGrammarParser.node;

namespace SableGrammarParser.SymbolLinking
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
            if (node.GetStatelist() != null)
                node.GetStatelist().Apply(this);

            if (node.GetIdentifier() != null)
            {
                string text = node.GetIdentifier().Text;

                DToken token = new DToken(node);
                if (tokens.ContainsKey(text))
                    RegisterError(node.GetIdentifier(), "Token {0} has already been defined (line {1}).", node.GetIdentifier(), tokens[text].DeclarationToken.Line);
                else
                    tokens.Add(text, token);
                node.GetIdentifier().SetDeclaration(tokens[text]);
            }

            if (node.GetRegex() != null)
                node.GetRegex().Apply(this);

            if (node.GetTokenlookahead() != null)
                node.GetTokenlookahead().Apply(this);
        }

        public override void CaseATokenstateListitem(ATokenstateListitem node)
        {
            DState state = null;
            if (states.TryGetValue(node.GetIdentifier().Text, out state))
                node.GetIdentifier().SetDeclaration(state);
            else
                RegisterError(node.GetIdentifier(), "The state {0} has not been defined.", node.GetIdentifier());
        }
        public override void CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node)
        {
            {
                DState state = null;
                if (states.TryGetValue(node.GetFrom().Text, out state))
                    node.GetFrom().SetDeclaration(state);
                else
                    RegisterError(node.GetFrom(), "The state {0} has not been defined.", node.GetFrom());
            }
            {
                DState state = null;
                if (states.TryGetValue(node.GetTo().Text, out state))
                    node.GetTo().SetDeclaration(state);
                else
                    RegisterError(node.GetTo(), "The state {0} has not been defined.", node.GetTo());
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
