using System;
using System.Drawing;
using System.IO;

using SablePP.Tools;
using SablePP.Tools.Error;
using SablePP.Tools.Lexing;
using SablePP.Tools.Nodes;
using SablePP.Tools.Parsing;

using SablePP.Compiler.Lexing;
using SablePP.Compiler.Nodes;
using SablePP.Compiler.Parsing;

using FastColoredTextBoxNS;

namespace SablePP.Compiler
{
    public partial class CompilerExecuter : ICompilerExecuter
    {
        ILexer SablePP.Tools.ICompilerExecuter.GetLexer(TextReader reader)
        {
            return this.GetLexer(reader);
        }
        public Lexer GetLexer(TextReader reader)
        {
            return new Lexer(reader);
        }
        
        IParser SablePP.Tools.ICompilerExecuter.GetParser(ILexer lexer)
        {
            if (!(lexer is Lexer || (lexer is ResetableLexer && (lexer as ResetableLexer).InnerLexer is Lexer)))
                throw new ArgumentException("Lexer must be of type " + typeof(Lexer).FullName, "lexer");
            
            return this.GetParser(lexer);
        }
        public Parser GetParser(ILexer lexer)
        {
            return new Parser(lexer);
        }
        
        void SablePP.Tools.ICompilerExecuter.Validate(Node astRoot, ErrorManager errorManager)
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
        
        public Style GetSimpleStyle(Token token)
        {
            return null;
        }
    }
}
