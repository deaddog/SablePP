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
        private bool eofFound;
        private Sable.Tools.Error.LexerException exception;

        public ResetableLexer(ILexer lexer)
        {
            this.lexer = lexer;
            this.tokens = new LinkedList<Token>();
            this.current = tokens.AddFirst((Token)null);
            this.eofFound = false;
            this.exception = null;
        }

        public ILexer InnerLexer
        {
            get { return lexer; }
        }

        private LinkedListNode<Token> addNext()
        {
            if (exception != null)
                throw exception;

            Token next;
            
            try { next = lexer.Next(); }
            catch (Sable.Tools.Error.LexerException ex)
            {
                next = null;
                exception = ex;
                throw ex;
            }
            
            LinkedListNode<Token> node = tokens.AddAfter(current, next);
            if (next is EOF)
                eofFound = true;
            return node;
        }

        public Nodes.Token Peek()
        {
            if (current.Next != null)
                return current.Next.Value;
            else
            {
                if (eofFound)
                    return tokens.Last.Value;
                else
                {
                    addNext();
                    return current.Next.Value;
                }
            }
        }

        public Nodes.Token Next()
        {
            if (current.Next == null)
            {
                if (eofFound)
                    return null;
                else
                {
                    addNext();
                    return Next();
                }
            }
            else
            {
                current = current.Next;
                return current.Value;
            }
        }

        public void Reset()
        {
            if (current.Value != null)
                current = current.List.First;
        }
    }
}
