using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SablePP.Tools.Nodes;
using SablePP.Tools.Error;

namespace SablePP.Tools.Lexing
{
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

        protected Token token;
        protected int currentState;

        private PushbackReader input;
        private int line;
        private int pos;
        private bool cr;
        private bool eof;
        private StringBuilder text;

        private int[][][][] gotoTable;
        private int[][] acceptTable;

        public Lexer(TextReader input, int initialState, int[][][][] gotoTable, int[][] acceptTable)
        {
            this.text = new StringBuilder();
            this.input = new PushbackReader(input);

            this.currentState = initialState;
            this.gotoTable = gotoTable;
            this.acceptTable = acceptTable;
        }

        protected virtual Token GetToken()
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
                int c = GetChar();

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

                        Token token = getToken(tokenIndex, GetText(accept_length), start_line + 1, start_pos + 1);
                        PushBack(accept_length);
                        pos = accept_pos;
                        line = accept_line;

                        int newState = changeState(tokenIndex, currentState);
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

        protected abstract Token getToken(int tokenIndex, string text, int line, int position);
        protected virtual int changeState(int tokenIndex, int currentState)
        {
            return -1;
        }

        private int GetChar()
        {
            if (eof)
                return -1;

            int result = input.Read();

            if (result == -1)
                eof = true;

            return result;
        }
        private void PushBack(int acceptLength)
        {
            int length = text.Length;
            for (int i = length - 1; i >= acceptLength; i--)
            {
                eof = false;
                input.Unread(text[i]);
            }
        }
        protected virtual void Unread(Token token)
        {
            String text = token.Text;
            int length = text.Length;

            for (int i = length - 1; i >= 0; i--)
            {
                eof = false;
                input.Unread(text[i]);
            }

            pos = token.Position - 1;
            line = token.Line - 1;
        }
        private string GetText(int acceptLength)
        {
            StringBuilder s = new StringBuilder(acceptLength);
            for (int i = 0; i < acceptLength; i++)
                s.Append(text[i]);

            return s.ToString();
        }

        public Token Peek()
        {
            while (token == null)
                token = GetToken();

            return token;
        }

        public Token Next()
        {
            Token result = Peek();
            token = null;
            return result;
        }
    }
}
