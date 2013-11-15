using System;
using System.IO;

using Sable.Tools;
using Sable.Tools.Error;
using Sable.Tools.Lexing;
using Sable.Tools.Nodes;
using Sable.Tools.Parsing;

using Sable.Compiler.Lexing;
using Sable.Compiler.Nodes;
using Sable.Compiler.Parsing;
using System.Diagnostics;

namespace Sable.Compiler
{
    public partial class CompilerExecuter : ICompilerExecuter
    {
        ILexer Sable.Tools.ICompilerExecuter.GetLexer(TextReader reader)
        {
            return this.GetLexer(reader);
        }
        public Lexer GetLexer(TextReader reader)
        {
            return new Lexer(reader);
        }

        IParser Sable.Tools.ICompilerExecuter.GetParser(ILexer lexer)
        {
            if (!(lexer is Lexer))
                throw new ArgumentException("Lexer must be of type " + typeof(Lexer).FullName, "lexer");

            return this.GetParser(lexer as Lexer);
        }
        public Parser GetParser(Lexer lexer)
        {
            return new Parser(lexer);
        }

        void Sable.Tools.ICompilerExecuter.Validate(Node astRoot, ErrorManager errorManager)
        {
            if (!(astRoot is Start<PGrammar>))
                throw new ArgumentException("Root must be of type " + typeof(Start<PGrammar>).FullName, "astRoot");

            this.Validate(astRoot as Start<PGrammar>, errorManager);
        }
        partial void PerformValidation(Start<PGrammar> root, ErrorManager errorManager);
        public void Validate(Start<PGrammar> root, ErrorManager errorManager)
        {
            PerformValidation(root, errorManager);
        }
    }
}
