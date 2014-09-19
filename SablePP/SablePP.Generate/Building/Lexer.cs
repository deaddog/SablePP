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

        public Lexer(Grammar grammar, CompilationResult tables)
        {
            this.grammar = grammar;
            this.tables = tables;
        }
    }
}
