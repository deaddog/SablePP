using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Sable.Compiler.analysis;
using Sable.Compiler.node;

namespace Sable.Compiler
{
    public class ParserModifier
    {
        private Start astRoot;
        private ArgumentCollection arguments;

        private ParserModifier(Start astRoot)
        {
            if (astRoot == null)
                throw new ArgumentNullException("astRoot");
            else
                this.astRoot = astRoot;

            this.arguments = new ArgumentCollection(this);
        }

        #region Regular expressions

        private static Regex newList = new Regex(@"TypedList (?<name>listNode[0-9]+) = new TypedList\(\);");
        private static Regex castList = new Regex(@"TypedList (?<name>listNode[0-9]+) = \(TypedList\)(?<assign>nodeArrayList[0-9]+\[[0-9]+\]);");
        private static Regex addAll = new Regex(@"(?<list>listNode[0-9]+)\.AddRange\((?<arg>listNode[0-9]+)\);");
        private static Regex add = new Regex(@"(?<list>listNode[0-9]+)\.Add\((?<arg>[^0-9]+[0-9]+)\);");
        private static Regex castNode = new Regex(@"(?<type>[TAP][A-Z][a-zA-Z]*) (?<name>[^ ]*) = \(\1\)nodeArrayList[0-9]+\[[0-9]+\];");
        private static Regex newNodes = new Regex(@"(?<type>[TAP][A-Z][a-zA-Z]*) (?<name>[^ ]+) = new \k<type>[^(]\([ \r\n]*(?<arg>[^,) \r\n]*)(,[ \r\n]*(?<arg>[^,) \r\n]*))*");

        #endregion

        private static string ToCamelCase(string text)
        {
            return string.Join(" ", from s in text.Split(' ') select char.ToUpper(s[0]) + s.Substring(1));
        }

        private string ReplaceIn(string parserCode)
        {
            string code = parserCode;

            string package = astRoot.GetPGrammar().PackageName;

            code = code.Replace("using System.Collections;", "using System.Collections;\r\nusing System.Collections.Generic;");
            code = code.Replace("using " + package + ".node;", "using " + package + ".Nodes;");
            code = code.Replace("using " + package + ".analysis;", "using " + package + ".Analysis;");
            code = code.Replace("using " + package + ".lexer;", "using " + package + ".Lexing;");
            code = code.Replace("namespace " + package + ".parser", "namespace " + package + ".Parsing");

            code = code.Replace(" Analysis ", " IAnalysis ");
            code = code.Replace("IList ign = null;", "List<Token> ign = null;");
            code = code.Replace("ign = new TypedList(NodeCast.Instance);", "ign = new List<Token>();");
            code = code.Replace("private IAnalysis ignoredTokens = new AnalysisAdapter();", "private AnalysisAdapter<List<Token>> ignoredTokens = new AnalysisAdapter<List<Token>>();");
            code = code.Replace("public IAnalysis IgnoredTokens", "public IAnalysis<List<Token>> IgnoredTokens");
            code = code.Replace("ignoredTokens.SetIn(lexer.Peek(), ign);", "ignoredTokens.Input[lexer.Peek()] = ign;");

            code = Regex.Replace(code, ".Pos[^a-z]", m => { return ".Position" + m.Value.Substring(4); });
            code = Regex.Replace(code, @"(?<section>ArrayList New0\(\).*?)private static int\[]\[]\[]", replaceSection, RegexOptions.Singleline);

            return code;
        }
        public static string ReplaceInCode(string parserCode, Start astRoot)
        {
            ParserModifier modifier = new ParserModifier(astRoot);
            return modifier.ReplaceIn(parserCode);
        }
        public static void ApplyToFile(string filepath, Start astRoot)
        {
            string code;

            using (StreamReader reader = new StreamReader(filepath))
                code = reader.ReadToEnd();

            code = ReplaceInCode(code, astRoot);

            using (StreamWriter writer = new StreamWriter(filepath))
                writer.Write(code);
        }

        private string replaceSection(Match method)
        {
            return Regex.Replace(method.Groups["section"].Value, @"ArrayList New[0-9]+\(\)[^{]+{([^}{]+{[^}{]+})*[^}{]+}",
                match => new MethodWorker(match.Value, arguments).Fix()) + "private static int[][][]";
        }

        private class MethodWorker
        {
            /// <summary>
            /// Represents type-relations between two identifiers.
            /// </summary>
            private List<Relation> relations = new List<Relation>();
            /// <summary>
            /// Maps identifiers to types when relations is known.
            /// </summary>
            private Dictionary<string, string> types = new Dictionary<string, string>();
            /// <summary>
            /// Lists all identifiers for which the type is not known
            /// </summary>
            private List<string> untyped = new List<string>();

            private string input;
            private ArgumentCollection arguments;

            public MethodWorker(string input, ArgumentCollection arguments)
            {
                this.input = input;
                this.arguments = arguments;
            }

            private class Relation
            {
                public readonly string Name1, Name2;

                public Relation(string name1, string name2)
                {
                    this.Name1 = name1;
                    this.Name2 = name2;
                }
            }

            public string Fix()
            {
                string text = input;

                text = replaceAddAll(text);

                foreach (Match match in newList.Matches(text))
                {
                    string name = match.Groups["name"].Value;
                    untyped.Add(name);
                }

                foreach (Match match in castList.Matches(text))
                {
                    string name = match.Groups["name"].Value;
                    untyped.Add(name);
                }

                foreach (Match match in castNode.Matches(text))
                {
                    string name = match.Groups["name"].Value;
                    string type = match.Groups["type"].Value;
                    types[name] = type;
                    Clean();
                }

                foreach (Match match in add.Matches(text))
                {
                    string list = match.Groups["list"].Value;
                    string arg = match.Groups["arg"].Value;
                    relations.Add(new Relation(list, arg));
                    Clean();
                }

                foreach (Match match in addAll.Matches(text))
                {
                    string list = match.Groups["list"].Value;
                    string arg = match.Groups["arg"].Value;
                    relations.Add(new Relation(list, arg));
                    Clean();
                }

                foreach (Match m in newNodes.Matches(text))
                {
                    if (untyped.Count == 0)
                        break;

                    string type = m.Groups["type"].Value;
                    string name = m.Groups["name"].Value;
                    types[name] = type;
                    Clean();

                    string[] args = arguments[type];
                    int index = 0;
                    foreach (Capture c in m.Groups["arg"].Captures)
                    {
                        if (c.Value != "null")
                            types[c.Value] = args[index];
                        Clean();
                        index++;
                    }
                }

                if (untyped.Count > 0)
                    throw new InvalidOperationException("The type of a TypedList could not be determined.");

                text = newList.Replace(text, m => replaceNewTypedList(m, types));
                text = castList.Replace(text, m => replaceCastTypedList(m, types));

                return text;
            }

            private static string replaceAddAll(string input)
            {
                return Regex.Replace(input, @"(?<list>listNode[0-9]+\.)AddAll(?<arg>\(listNode[0-9]+\);)",
                    m => string.Format("{0}AddRange{1}", m.Groups["list"], m.Groups["arg"]));
            }
            private static string replaceNewTypedList(Match match, Dictionary<string, string> types)
            {
                string name = match.Groups["name"].Value;
                return string.Format("List<{0}> {1} = new List<{0}>();", types[name], name);
            }
            private static string replaceCastTypedList(Match match, Dictionary<string, string> types)
            {
                string name = match.Groups["name"].Value;
                string assign = match.Groups["assign"].Value;

                string type = types.ContainsKey(name) ? types[name] : "Node";
                if (!types.ContainsKey(name))
                {
                }

                return string.Format("List<{0}> {1} = (List<{0}>){2};", type, name, assign);
            }

            private void Clean()
            {
                if (relations.Count >= 1)
                {
                    int c = 0;
                    do
                    {
                        var rep_exp = from r in relations
                                      from t in types
                                      where r.Name1 == t.Key || r.Name2 == t.Key
                                      select new { Relation = r, t.Value };

                        var rep_arr = rep_exp.ToArray();
                        c = rep_arr.Length;

                        foreach (var i in rep_arr)
                        {
                            relations.Remove(i.Relation);
                            types[i.Relation.Name1] = i.Value;
                            types[i.Relation.Name2] = i.Value;
                        }
                    } while (c > 0);
                }

                foreach (var name in types.Keys)
                    untyped.Remove(name);
            }
        }

        private class ArgumentCollection
        {
            private Dictionary<string, string[]> arguments;
            private ParserModifier owner;

            public ArgumentCollection(ParserModifier owner)
            {
                this.owner = owner;
            }

            public string[] this[string type]
            {
                get
                {
                    if (arguments == null)
                    {
                        ArgumentVisitor visitor = new ArgumentVisitor();
                        owner.astRoot.Apply(visitor);
                        this.arguments = visitor.arguments;
                    }
                    return arguments[type];
                }
            }

            #region Visitor that retrieves the arguments for construction of all nodes in the ast

            private class ArgumentVisitor : DepthFirstAdapter
            {
                public Dictionary<string, string[]> arguments;
                private int index;

                public override void CaseAGrammar(AGrammar node)
                {
                    arguments = new Dictionary<string, string[]>();
                    if (node.GetAstproductions() != null)
                        node.GetAstproductions().Apply(this);
                    else if (node.GetProductions() != null)
                        node.GetProductions().Apply(this);
                }

                private DProduction currentProduction;
                private DAlternativeName currentAlternative;

                private string currentPname;
                private string currentAname;

                public override void InAProduction(AProduction node)
                {
                    currentPname = node.GetIdentifier().Text;
                    currentPname = "P" + ToCamelCase(currentPname);
                    currentProduction = node.GetIdentifier().AsProduction;
                }

                public override void InAAlternative(AAlternative node)
                {
                    index = 0;

                    if (node.GetAlternativename() == null)
                    {
                        currentAlternative = null;
                        currentAname = 'A' + currentPname.Substring(1);
                    }
                }
                public override void InAAlternativename(AAlternativename node)
                {
                    currentAname = node.GetName().Text;
                    currentAname = "A" + ToCamelCase(currentAname) + currentPname.Substring(1);
                    currentAlternative = node.GetName().AsAlternativeName;
                }
                public override void InAElements(AElements node)
                {
                    arguments[currentAname] = new string[node.GetElement().Count];
                }
                public override void InACleanElementid(ACleanElementid node)
                {
                    if (node.GetIdentifier().IsToken)
                        arguments[currentAname][index] = "T" + ToCamelCase(node.GetIdentifier().Text);
                    else if (node.GetIdentifier().IsProduction)
                        arguments[currentAname][index] = "P" + ToCamelCase(node.GetIdentifier().Text);
                    index++;
                }
                public override void InATokenElementid(ATokenElementid node)
                {
                    arguments[currentAname][index] = "T" + ToCamelCase(node.GetIdentifier().Text);
                    index++;
                }
                public override void InAProductionElementid(AProductionElementid node)
                {
                    arguments[currentAname][index] = "P" + ToCamelCase(node.GetIdentifier().Text);
                    index++;
                }
            }

            #endregion
        }
    }
}
