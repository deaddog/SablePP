using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Nodes;

using SablePP.Tools.Generate;
using SablePP.Tools.Generate.CSharp;

namespace SablePP.Compiler.Generate
{
    public class ParserModifier
    {
        private Start<PGrammar> astRoot;
        private ArgumentCollection arguments;
        private ParentTable parentTable;

        private ParserModifier(Start<PGrammar> astRoot)
        {
            if (astRoot == null)
                throw new ArgumentNullException("astRoot");
            else
                this.astRoot = astRoot;

            this.arguments = new ArgumentCollection(this);
            this.parentTable = new ParentTable(this);
        }

        #region Regular expressions

        private static Regex newList = new Regex(@"TypedList (?<name>listNode[0-9]+) = new TypedList\(\);");
        private static Regex castList = new Regex(@"TypedList (?<name>listNode[0-9]+) = \(TypedList\)(?<assign>nodeArrayList[0-9]+\[[0-9]+\]);");
        private static Regex addAll = new Regex(@"(?<list>listNode[0-9]+)\.AddRange\((?<arg>listNode[0-9]+)\);");
        private static Regex add = new Regex(@"(?<list>listNode[0-9]+)\.Add\((?<arg>[^0-9]+[0-9]+)\);");
        private static Regex castNode = new Regex(@"(?<type>[TAP][A-Z][a-zA-Z]*) (?<name>[^ ]*) = \(\1\)nodeArrayList[0-9]+\[[0-9]+\];");
        private static Regex newNodes = new Regex(@"(?<type>[TAP][A-Z][a-zA-Z]*) (?<name>[^ ]+) = new \k<type>[^(]\([ \r\n]*(?<arg>[^,) \r\n]*)(,[ \r\n]*(?<arg>[^,) \r\n]*))*");
        private static Regex indexMethod = new Regex(@"private int Index\(Switchable token\)[^}]*}");
        private static Regex parseMethod = new Regex(@"public Start Parse\(\)");
        private static Regex acceptCase = new Regex(@"case ACCEPT[^{]*{[^}]*}");
        private static Regex parserThrow = new Regex("throw new ParserException\\(.*\\\"\\] \\\" \\+[ \\n]*", RegexOptions.Singleline);
        private static Regex parserClass = new Regex(@"{[^p{}]*public class ParserException[^}]*}[^}]*}[^}]*}[^}]*}");

        #endregion

        private string ReplaceIn(string parserCode)
        {
            string code = parserCode;

            string package = astRoot.Root.PackageName;

            string[] namespaces = new string[]
            {
                "System",
                "System.Collections",
                "System.Collections.Generic",
                "System.Text",
                "System.IO",
                
                ToolsNamespace.Lexing,
                ToolsNamespace.Error,
                ToolsNamespace.Nodes,

                package + ".Analysis",
                package + ".Lexing",
                package + ".Nodes"
            };
            string usingstring = "\r\nnamespace " + package + ".Parsing";
            for (int i = namespaces.Length - 1; i >= 0; i--)
                usingstring = "using " + namespaces[i] + ";\r\n" + usingstring;

            code = Regex.Replace(code, "using .*namespace " + package + ".parser", usingstring, RegexOptions.Singleline);
            code = code.Replace("private Lexer lexer;", "private ILexer lexer;");
            code = code.Replace("public Parser(Lexer lexer)", "public Parser(ILexer lexer)");

            code = code.Replace(" Analysis ", " IAnalysis ");
            code = code.Replace("IList ign = null;", "List<Token> ign = null;");
            code = code.Replace("ign = new TypedList(NodeCast.Instance);", "ign = new List<Token>();");
            code = code.Replace("private IAnalysis ignoredTokens = new AnalysisAdapter();", "private AnalysisAdapter<List<Token>> ignoredTokens = new AnalysisAdapter<List<Token>>();");
            code = code.Replace("public IAnalysis IgnoredTokens", "public AnalysisAdapter<List<Token>> IgnoredTokens");
            code = code.Replace("ignoredTokens.SetIn(lexer.Peek(), ign);", "ignoredTokens.Input[lexer.Peek()] = ign;");

            code = parserThrow.Replace(code, "throw new ParserException(last_token, last_line, last_pos, ");
            code = parserClass.Replace(code, "{");

            MethodElement parseMethodElement = new MethodElement(AccessModifiers.None, ToolsNamespace.Parsing + ".IParser.Parse", "Node");
            parseMethodElement.EmitReturn();
            parseMethodElement.EmitThis();
            parseMethodElement.EmitPeriod();
            parseMethodElement.EmitIdentifier("Parse");
            parseMethodElement.EmitParenthesis();
            parseMethodElement.EmitSemicolon(true);
            string methodCode = parseMethodElement.ToString(4);

            code = indexMethod.Replace(code, ReplaceInIndexMethod);
            code = parseMethod.Replace(code, methodCode + "public Start<" + astRoot.Root.RootProduction + "> Parse()");
            code = code.Replace("public class Parser", "public class Parser : " + ToolsNamespace.Parsing + ".IParser");
            code = acceptCase.Replace(code, ReplaceInAcceptCase);

            code = Regex.Replace(code, ".Pos[^a-z]", m => { return ".Position" + m.Value.Substring(4); });
            code = Regex.Replace(code, @"(?<section>ArrayList New0\(\).*?)private static int\[]\[]\[]", replaceSection, RegexOptions.Singleline);

            code = code.Replace("\r\n", "\n").Replace('\r', '\n').Replace("\n", "\r\n");

            return code;
        }
        public static string ReplaceInCode(string parserCode, Start<PGrammar> astRoot)
        {
            ParserModifier modifier = new ParserModifier(astRoot);
            return modifier.ReplaceIn(parserCode);
        }
        public static void ApplyToFile(string filepath, Start<PGrammar> astRoot)
        {
            string code;

            using (StreamReader reader = new StreamReader(filepath))
                code = reader.ReadToEnd();

            code = ReplaceInCode(code, astRoot);

            using (StreamWriter writer = new StreamWriter(filepath))
                writer.Write(code);
        }

        private string ReplaceInIndexMethod(Match match)
        {
            string value = match.Value;
            value = value.Replace("private int Index(Switchable token)", "private int Index(Token token)");
            value = value.Replace("token.Apply(converter);", "converter.Visit((dynamic)token);");
            return value;
        }
        private string ReplaceInAcceptCase(Match match)
        {
            string value = match.Value;
            value = value.Replace("Start", "Start<" + astRoot.Root.RootProduction + ">");
            return value;
        }

        private string replaceSection(Match method)
        {
            return Regex.Replace(method.Groups["section"].Value, @"ArrayList New[0-9]+\(\)[^{]+{([^}{]+{[^}{]+})*[^}{]+}",
                match => new MethodWorker(match.Value, arguments, parentTable).Fix()) + "private static int[][][]";
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
            private ParentTable parentTable;

            public MethodWorker(string input, ArgumentCollection arguments, ParentTable parentTable)
            {
                this.input = input;
                this.arguments = arguments;
                this.parentTable = parentTable;
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

                    types[name] = parentTable[type];
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
                {
                    Console.WriteLine("Unable to resolve types in {0}:", Regex.Match(text, @"New[0-9]+").Value);
                    for (int i = 0; i < untyped.Count; i++)
                        Console.WriteLine(" - {0}", untyped[i]);
                    Console.WriteLine();
                    //throw new InvalidOperationException("The type of a TypedList could not be determined.");
                }
                else
                {
                    text = newList.Replace(text, m => replaceNewTypedList(m, types));
                    text = castList.Replace(text, m => replaceCastTypedList(m, types));
                }

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
                        visitor.Visit(owner.astRoot);
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
                    if (node.HasAstproductions)
                        Visit(node.Astproductions);
                    else if (node.HasProductions)
                        Visit(node.Productions);
                }

                private DProduction currentProduction;
                private DAlternativeName currentAlternative;

                private string currentPname;
                private string currentAname;

                public override void InAProduction(AProduction node)
                {
                    currentPname = node.Identifier.Text;
                    currentPname = "P" + currentPname.ToCamelCase();
                    currentProduction = node.Identifier.AsProduction;
                }

                public override void InAAlternative(AAlternative node)
                {
                    index = 0;

                    if (!node.HasAlternativename)
                    {
                        currentAlternative = null;
                        currentAname = 'A' + currentPname.Substring(1);
                    }
                }
                public override void InAAlternativename(AAlternativename node)
                {
                    currentAname = node.Name.Text;
                    currentAname = "A" + currentAname.ToCamelCase() + currentPname.Substring(1);
                    currentAlternative = node.Name.AsAlternativeName;
                }
                public override void InAElements(AElements node)
                {
                    arguments[currentAname] = new string[node.Element.Count];
                }
                public override void InACleanElementid(ACleanElementid node)
                {
                    if (node.Identifier.IsToken)
                        arguments[currentAname][index] = "T" + node.Identifier.Text.ToCamelCase();
                    else if (node.Identifier.IsProduction)
                        arguments[currentAname][index] = "P" + node.Identifier.Text.ToCamelCase();
                    index++;
                }
                public override void InATokenElementid(ATokenElementid node)
                {
                    arguments[currentAname][index] = "T" + node.Identifier.Text.ToCamelCase();
                    index++;
                }
                public override void InAProductionElementid(AProductionElementid node)
                {
                    arguments[currentAname][index] = "P" + node.Identifier.Text.ToCamelCase();
                    index++;
                }
            }

            #endregion
        }

        private class ParentTable
        {
            private Dictionary<string, string> parents;

            public ParentTable(ParserModifier owner)
            {
                ParentVisitor par = new ParentVisitor();
                par.Visit(owner.astRoot);
                this.parents = par.List;
            }

            public string this[string name]
            {
                get
                {
                    if (parents.ContainsKey(name))
                        return parents[name];
                    else
                        return name;
                }
            }

            private class ParentVisitor : DepthFirstAdapter
            {
                public Dictionary<string, string> List = new Dictionary<string, string>();
                private string parent = null;

                public override void CaseAGrammar(AGrammar node)
                {
                    if (node.HasAstproductions)
                        Visit(node.Astproductions);
                }

                public override void CaseAProduction(AProduction node)
                {
                    string name = node.Identifier.Text;
                    this.parent = "P" + name.ToCamelCase();

                    Visit(node.Productionrule);
                }

                public override void CaseAAlternative(AAlternative node)
                {
                    if (node.HasAlternativename)
                        Visit(node.Alternativename);
                    else
                    {
                        string name = "A" + parent.Substring(1);
                        List.Add(name, parent);
                    }
                }

                public override void CaseAAlternativename(AAlternativename node)
                {
                    string name = "A" + node.Name.Text.ToCamelCase() + parent.Substring(1);
                    List.Add(name, parent);
                }
            }
        }
    }
}
