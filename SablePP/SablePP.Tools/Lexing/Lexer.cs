using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SablePP.Tools.Nodes;
using SablePP.Tools.Error;

namespace SablePP.Tools.Lexing
{
    /// <summary>
    /// Performs lexical analysis when provided with a goto-table and and accept-table.
    /// </summary>
    public abstract class Lexer : ILexer
    {
        private class PushbackReader
        {
            private TextReader reader;
            private Stack<int> stack;

            public PushbackReader(TextReader reader)
            {
                this.reader = reader;
                this.stack = new Stack<int>();
            }

            public int Peek()
            {
                if (stack.Count > 0)
                    return stack.Peek();
                return reader.Peek();
            }

            public int Read()
            {
                if (stack.Count > 0)
                    return stack.Pop();
                return reader.Read();
            }

            public void Unread(int v)
            {
                stack.Push(v);
            }
        }

        private Token token;
        private int currentState;

        private PushbackReader input;
        private int line;
        private int pos;
        private bool cr;
        private bool eof;
        private StringBuilder text;

        private int[][][][] gotoTable;
        private int[][] acceptTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lexer"/> class.
        /// </summary>
        /// <param name="input">The <see cref="TextReader"/> from which the lexer will read its input.</param>
        /// <param name="initialState">The initial state of the lexer.</param>
        /// <param name="gotoTable">The goto table.</param>
        /// <param name="acceptTable">The accept table.</param>
        public Lexer(TextReader input, int initialState, int[][][][] gotoTable, int[][] acceptTable)
        {
            this.text = new StringBuilder();
            this.input = new PushbackReader(input);

            this.currentState = initialState;
            this.gotoTable = gotoTable;
            this.acceptTable = acceptTable;
        }

        private Token getToken()
        {
            int dfa_state = 0;

            int start_pos = pos;
            int start_line = line;

            int accept_state = -1;
            int accept_token = -1;
            int accept_length = -1;
            int accept_pos = -1;
            int accept_line = -1;

            int[][][] gotoTable = this.gotoTable[currentState];
            int[] accept = this.acceptTable[currentState];
            text.Length = 0;

            while (true)
            {
                int c = getChar();

                if (c != -1)
                {
                    switch (c)
                    {
                        case 10:
                            if (cr)
                            {
                                cr = false;
                            }
                            else
                            {
                                line++;
                                pos = 0;
                            }
                            break;
                        case 13:
                            line++;
                            pos = 0;
                            cr = true;
                            break;
                        default:
                            pos++;
                            cr = false;
                            break;
                    };

                    text.Append((char)c);
                    do
                    {
                        int oldState = (dfa_state < -1) ? (-2 - dfa_state) : dfa_state;

                        dfa_state = -1;

                        int[][] tmp1 = gotoTable[oldState];
                        int low = 0;
                        int high = tmp1.Length - 1;

                        while (low <= high)
                        {
                            int middle = (low + high) / 2;
                            int[] tmp2 = tmp1[middle];

                            if (c < tmp2[0])
                            {
                                high = middle - 1;
                            }
                            else if (c > tmp2[1])
                            {
                                low = middle + 1;
                            }
                            else
                            {
                                dfa_state = tmp2[2];
                                break;
                            }
                        }
                    } while (dfa_state < -1);
                }
                else
                {
                    dfa_state = -1;
                }

                if (dfa_state >= 0)
                {
                    if (accept[dfa_state] != -1)
                    {
                        accept_state = dfa_state;
                        accept_token = accept[dfa_state];
                        accept_length = text.Length;
                        accept_pos = pos;
                        accept_line = line;
                    }
                }
                else
                {
                    if (accept_state != -1)
                    {
                        int tokenIndex = accept_token;

                        Token token = getToken(tokenIndex, getText(accept_length), start_line + 1, start_pos + 1);
                        pushBack(accept_length);
                        pos = accept_pos;
                        line = accept_line;

                        int newState = getNextState(tokenIndex, currentState);
                        if (newState != -1)
                            currentState = newState;

                        return token;
                    }
                    else
                    {
                        if (text.Length > 0)
                        {
                            throw new LexerException(start_line + 1, start_pos + 1, "Unknown token: " + text);
                        }
                        else
                        {
                            EOF token = new EOF(
                                start_line + 1,
                                start_pos + 1);
                            return token;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// When overridden in a deriving class; constructs a new instance of the <see cref="Token"/> corresponding to <paramref name="tokenIndex"/>.
        /// </summary>
        /// <param name="tokenIndex">The index of the token that should be constructed.</param>
        /// <param name="text">The text associated with the token.</param>
        /// <param name="line">The line (one-based) where the token is located in the source.</param>
        /// <param name="position">The position (one-based) where the token is located in the source line.</param>
        /// <returns>A new <see cref="Token"/> that corresponds to <paramref name="tokenIndex"/>.</returns>
        protected abstract Token getToken(int tokenIndex, string text, int line, int position);
        /// <summary>
        /// Gets the next state of the lexer, if any.
        /// </summary>
        /// <param name="tokenIndex">The index of the current token.</param>
        /// <param name="currentState">The current state of the lexer.</param>
        /// <returns>The next state of the lexer after the current token; or -1 if the state should not change.</returns>
        protected virtual int getNextState(int tokenIndex, int currentState)
        {
            return -1;
        }

        private int getChar()
        {
            if (eof)
                return -1;

            int result = input.Read();

            if (result == -1)
                eof = true;

            return result;
        }
        private void pushBack(int acceptLength)
        {
            int length = text.Length;
            for (int i = length - 1; i >= acceptLength; i--)
            {
                eof = false;
                input.Unread(text[i]);
            }
        }
        private string getText(int acceptLength)
        {
            StringBuilder s = new StringBuilder(acceptLength);
            for (int i = 0; i < acceptLength; i++)
                s.Append(text[i]);

            return s.ToString();
        }

        /// <summary>
        /// Gets the next <see cref="Token" /> in the token stream, but does not remove it from the stream.
        /// </summary>
        /// <returns>
        /// The next <see cref="Token" /> in the token stream.
        /// </returns>
        public Token Peek()
        {
            while (token == null)
                token = getToken();

            return token;
        }

        /// <summary>
        /// Gets the next <see cref="Token" /> in the token stream, and removes it from the stream.
        /// </summary>
        /// <returns>
        /// The next <see cref="Token" /> in the token stream.
        /// </returns>
        public Token Next()
        {
            Token result = Peek();
            token = null;
            return result;
        }
    }
}
