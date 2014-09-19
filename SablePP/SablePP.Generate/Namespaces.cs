using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate
{
    public static class Namespaces
    {
        public static string Root
        {
            get { return "SablePP.Tools"; }
        }

        public static string Analysis
        {
            get { return Root + ".Analysis"; }
        }
        public static string Nodes
        {
            get { return Root + ".Nodes"; }
        }
        public static string Error
        {
            get { return Root + ".Error"; }
        }

        public static string Parsing
        {
            get { return Root + ".Parsing"; }
        }
        public static string Lexing
        {
            get { return Root + ".Lexing"; }
        }
    }
}
