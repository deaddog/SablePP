using SablePP.Tools.Generate;
using SablePP.Tools.Generate.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Generate.Building
{
    public class Lexer
    {
        private Grammar grammar;
        private CompilationResult tables;

        private FileElement fileElement;
        private NameSpaceElement nameElement;
        private ClassElement classElement;

        private Dictionary<string, int> states;
        private int tokenIndex = 0;

        private PatchElement getTokenMethod, getNextStateMethod;

        private Lexer(Grammar grammar, CompilationResult tables)
        {
            this.grammar = grammar;
            this.tables = tables;
        }
    }
}
