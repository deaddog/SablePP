using System;
using System.Collections.Generic;

namespace SablePP.Compiler.Execution
{
    public abstract class CompilerBase
    {
        private ArgumentCollection arguments;
        public ArgumentCollection Arguments
        {
            get { return arguments; }
        }

        public void Main(string[] args)
        {
            this.arguments = new ArgumentCollection(args);
            Main();
        }

        protected abstract void Main();

        public class ArgumentCollection
        {
            private Dictionary<string, string[]> dict;
            private static readonly string[] emptyArray = new string[0];

            public ArgumentCollection(string[] args)
            {
                Dictionary<string, List<string>> builder = new Dictionary<string, List<string>>();
                builder.Add(string.Empty, new List<string>());

                string currentarg = string.Empty;

                for (int i = 0; i < args.Length; i++)
                {
                    string arg = args[i];
                    if (arg.StartsWith("-"))
                    {
                        currentarg = arg.Substring(1);
                        if (!builder.ContainsKey(currentarg))
                            builder.Add(currentarg, new List<string>());
                    }
                    else
                    {
                        builder[currentarg].Add(arg);
                    }
                }

                dict = new Dictionary<string, string[]>();
                foreach (string s in builder.Keys)
                    dict.Add(s, builder[s].ToArray());
            }

            public string[] this[string argument]
            {
                get
                {
                    if (argument == null)
                        return NoArgument;
                    else if (dict.ContainsKey(argument))
                        return dict[argument];
                    else
                        return emptyArray;
                }
            }

            public string[] NoArgument
            {
                get { return dict[string.Empty]; }
            }
        }
    }
}
