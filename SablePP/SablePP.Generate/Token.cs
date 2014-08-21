using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate
{
    public class Token
    {
        private string name;
        private TokenState[] states;
        private RegularExpression expression;

        public Token(string name, RegularExpression expression)
            : this(name, expression, null)
        {
        }
        public Token(string name, RegularExpression expression, IEnumerable<TokenState> states)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (expression == null)
                throw new ArgumentNullException("expression");

            this.name = name;
            this.expression = expression;
            if (states == null)
                this.states = new TokenState[0];
            else
                this.states = states.ToArray();
        }

        public string Name
        {
            get { return name; }
        }

        public TokenState[] States
        {
            get { return states; }
        }

        public RegularExpression Expression
        {
            get { return expression; }
        }

        public class TokenState
        {
            private State from, to;

            public TokenState(State state)
            {
                if (state == null)
                    throw new ArgumentNullException("state");

                this.from = state;
                this.to = null;
            }
            public TokenState(State from, State to)
            {
                if (from == null)
                    throw new ArgumentNullException("from");

                if (to == null)
                    throw new ArgumentNullException("to");

                this.from = from;
                this.to = to;
            }

            public bool Translates
            {
                get { return to != null; }
            }

            public State From
            {
                get { return from; }
            }
            public State To
            {
                get { return to; }
            }
        }
    }
}
