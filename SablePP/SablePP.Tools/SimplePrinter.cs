﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SablePP.Tools.Analysis;
using SablePP.Tools.Nodes;

namespace SablePP.Tools
{
    public class SimplePrinter<TRoot> : DepthFirstTreeWalker where TRoot : Production
    {
        private int indent;
        private List<string> dotLines = new List<string>();
        private bool showTokens;

        private ConsoleColor astnodescolor, tokencolor, textcolor, treecolor;

        public SimplePrinter(bool showTokens, ConsoleColor astnodes, ConsoleColor tokens, ConsoleColor text, ConsoleColor tree)
        {
            this.showTokens = showTokens;
            this.astnodescolor = astnodes;
            this.tokencolor = tokens;
            this.textcolor = text;
            this.treecolor = tree;
        }

        private void printIndent()
        {
            StringBuilder builder = new StringBuilder();
            while (builder.Length < indent * 2)
                builder.Append(builder.Length % 2 == 0 ? '|' : ' ');
            if (builder.Length > 0)
            {
                builder[builder.Length - 2] = '+';
                builder[builder.Length - 1] = '-';
            }
            Console.Write("".PadRight(builder.Length, ' '));
            dotLines.Add(builder.ToString());
        }

        private void printNode(Node node)
        {
            printIndent();

            Console.ForegroundColor = node is Token ? tokencolor : astnodescolor;
            Console.Write(node.GetType().Name);

            if (!showTokens || node is Token)
            {
                Console.ForegroundColor = textcolor;
                int a = Console.WindowWidth - Console.CursorLeft - 1;
                string text = node.ToString().Replace("\r", "\\r").Replace("\n", "\\n");
                if (text.Length >= a)
                {
                    Console.Write(" " + text.Substring(0, a));
                }
                else
                {
                    Console.Write(" " + text);
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine();
        }
        private void dotReplace(int y, int x, char c)
        {
            dotLines[y] = dotLines[y].Substring(0, x) + c + dotLines[y].Substring(x + 1);
        }

        public void Done()
        {
            dotLines[dotLines.Count - 1] = dotLines[dotLines.Count - 1].Replace('|', ' ');
            for (int i = dotLines.Count - 2; i >= 0; i--)
                for (int j = 0; j < dotLines[i].Length; j++)
                    if (dotLines[i][j] == '|')
                    {
                        if (j >= dotLines[i + 1].Length || dotLines[i + 1][j] == ' ')
                            dotReplace(i, j, ' ');
                    }

            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = treecolor;

            if (Console.CursorTop - dotLines.Count < 0)
                return;
            Console.CursorTop -= dotLines.Count;
            for (int i = 0; i < dotLines.Count; i++)
            {
                Console.Write(dotLines[i]);
                Console.CursorTop++;
                Console.CursorLeft = 0;
            }

            Console.ForegroundColor = color;
        }

        public void Print(Start<TRoot> node)
        {
            Visit(node);
        }

        public override void Visit(Production production)
        {
            printNode(production);

            indent++;
            base.Visit(production);
            indent--;

            if (production is Start<TRoot>)
                Done();
        }
        public override void Visit(Token token)
        {
            if (showTokens)
                printNode(token);
        }
    }
}