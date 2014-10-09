using SablePP.Generate.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SablePP.Generate
{
    public class Token : GrammarPart
    {
        private string name;
        private bool ignored;
        private TokenState[] states;
        private RegExp expression;

        public Token(string name, bool ignored, RegExp expression)
            : this(name, ignored, expression, null)
        {
        }
        public Token(string name, bool ignored, RegExp expression, IEnumerable<TokenState> states)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (expression == null)
                throw new ArgumentNullException("expression");

            this.name = name;
            this.ignored = ignored;
            this.expression = expression;
            if (states == null)
                this.states = new TokenState[0];
            else
                this.states = states.ToArray();

            foreach (var s in this.states)
                s.parent = this;
        }

        internal override bool canBeParent(GrammarPart part)
        {
            return part is Grammar;
        }
        public Grammar Parent
        {
            get { return base.parent as Grammar; }
        }

        public bool Ignored
        {
            get { return ignored; }
        }

        public string Name
        {
            get { return name; }
        }

        public TokenState[] States
        {
            get { return states; }
        }

        public RegExp Expression
        {
            get { return expression; }
        }

        public class TokenState : GrammarPart
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

            internal override bool canBeParent(GrammarPart part)
            {
                return part is Token;
            }
            public Token Parent
            {
                get { return base.parent as Token; }
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
