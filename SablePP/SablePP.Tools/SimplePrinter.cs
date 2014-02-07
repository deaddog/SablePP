using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SablePP.Tools.Analysis;
using SablePP.Tools.Nodes;

namespace SablePP.Tools
{
    /// <summary>
    /// Provides a method for printing an AST to <see cref="Console"/>.
    /// </summary>
    public class SimplePrinter : DepthFirstTreeWalker
    {
        private int indent;
        private List<string> dotLines = new List<string>();
        private bool showTokens;

        private Node root;

        private ConsoleColor astnodescolor, tokencolor, textcolor, treecolor;

        private SimplePrinter(bool showTokens, ConsoleColor astnodes, ConsoleColor tokens, ConsoleColor text, ConsoleColor tree)
        {
            this.showTokens = showTokens;
            this.astnodescolor = astnodes;
            this.tokencolor = tokens;
            this.textcolor = text;
            this.treecolor = tree;
        }

        /// <summary>
        /// Prints the tree specified by node.
        /// </summary>
        /// <param name="node">The node that is the root in the printed tree.</param>
        /// <param name="showTokens">if set to <c>true</c> tokens are printed, otherwise they are skipped.</param>
        /// <param name="astnodes">The <see cref="ConsoleColor"/> used to draw production names.</param>
        /// <param name="tokens">The <see cref="ConsoleColor"/> used to draw token names.</param>
        /// <param name="text">The <see cref="ConsoleColor"/> used to draw node text values.</param>
        /// <param name="tree">The <see cref="ConsoleColor"/> used to draw the tree structure itself.</param>
        public static void Print(Node node, bool showTokens, ConsoleColor astnodes, ConsoleColor tokens, ConsoleColor text, ConsoleColor tree)
        {
            SimplePrinter printer = new SimplePrinter(showTokens, astnodes, tokens, text, tree);
            printer.print(node);
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

        public void done()
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

        private void print(Node node)
        {
            this.root = node;
            Visit(node);
            done();
        }

        public override void Visit(Production production)
        {
            printNode(production);

            indent++;
            base.Visit(production);
            indent--;
        }
        public override void Visit(Token token)
        {
            if (showTokens)
                printNode(token);
        }
    }
}