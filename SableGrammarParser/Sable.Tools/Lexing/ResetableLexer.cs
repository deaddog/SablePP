using System;
using System.Collections.Generic;
using Sable.Tools.Nodes;

namespace Sable.Tools.Lexing
{
    public class ResetableLexer : ILexer
    {
        private ILexer lexer;
        private LinkedList<Token> tokens;

        private LinkedListNode<Token> current;

        public ResetableLexer(ILexer lexer)
        {
            this.lexer = lexer;
            this.tokens = new LinkedList<Token>();
            this.current = null;
        }

        public Nodes.Token Peek()
        {
            if (current.Next != null)
                return current.Next.Value;
            else
                return lexer.Peek();
        }

        public Nodes.Token Next()
        {
            if (current.Next == null)
            {
                Token t = lexer.Next();
                if (t == null)
                    return null;
                current.List.AddAfter(current, t);
            }

            current = current.Next;
            return current.Value;
        }

        public void Reset()
        {
            if (current != null)
                current = current.List.First;
        }
    }
}
