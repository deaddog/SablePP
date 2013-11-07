using System;
using System.Threading;

using Sable.Tools.Nodes;

namespace Sable.Tools.Analysis
{
    public abstract class TreeWalker
    {
        public abstract void Visit(Token token);
        public abstract void Visit(Production production);
        public void Visit(Node node)
        {
            if (node is Token)
                Visit(node as Token);
            else if (node is Production)
                Visit(node as Production);
        }

        public static void VisitInParallel(Node node, params TreeWalker[] walkers)
        {
            Thread[] threads = new Thread[walkers.Length];
            for (int i = 0; i < walkers.Length; i++)
            {
                TreeWalker walker = walkers[i];
                Thread t = new Thread(() => walker.Visit(node));
                t.Start();
            }
            for (int i = 0; i < threads.Length; i++)
                threads[i].Join();
        }
    }
}
