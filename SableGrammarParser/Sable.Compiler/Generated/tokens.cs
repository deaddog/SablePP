using System;
using System.Collections.Generic;
using Sable.Tools.Nodes;
using Sable.Compiler.Analysis;

namespace Sable.Compiler.Nodes
{
    public partial class TPackagename : Token<TPackagename>
    {
        public TPackagename(string text)
            : base(text)
        {
        }
        public TPackagename(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TPackagename Clone()
        {
            return new TPackagename(Text, Line, Position);
        }
    }
    
    public partial class TPackagetoken : Token<TPackagetoken>
    {
        public TPackagetoken(string text)
            : base(text)
        {
        }
        public TPackagetoken(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TPackagetoken Clone()
        {
            return new TPackagetoken(Text, Line, Position);
        }
    }
    
    public partial class TStatestoken : Token<TStatestoken>
    {
        public TStatestoken(string text)
            : base(text)
        {
        }
        public TStatestoken(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TStatestoken Clone()
        {
            return new TStatestoken(Text, Line, Position);
        }
    }
    
    public partial class THelperstoken : Token<THelperstoken>
    {
        public THelperstoken(string text)
            : base(text)
        {
        }
        public THelperstoken(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override THelperstoken Clone()
        {
            return new THelperstoken(Text, Line, Position);
        }
    }
    
    public partial class TTokenstoken : Token<TTokenstoken>
    {
        public TTokenstoken(string text)
            : base(text)
        {
        }
        public TTokenstoken(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TTokenstoken Clone()
        {
            return new TTokenstoken(Text, Line, Position);
        }
    }
    
    public partial class TIgnoredtoken : Token<TIgnoredtoken>
    {
        public TIgnoredtoken(string text)
            : base(text)
        {
        }
        public TIgnoredtoken(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TIgnoredtoken Clone()
        {
            return new TIgnoredtoken(Text, Line, Position);
        }
    }
    
    public partial class TProductionstoken : Token<TProductionstoken>
    {
        public TProductionstoken(string text)
            : base(text)
        {
        }
        public TProductionstoken(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TProductionstoken Clone()
        {
            return new TProductionstoken(Text, Line, Position);
        }
    }
    
    public partial class TAsttoken : Token<TAsttoken>
    {
        public TAsttoken(string text)
            : base(text)
        {
        }
        public TAsttoken(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TAsttoken Clone()
        {
            return new TAsttoken(Text, Line, Position);
        }
    }
    
    public partial class TNew : Token<TNew>
    {
        public TNew(string text)
            : base(text)
        {
        }
        public TNew(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TNew Clone()
        {
            return new TNew(Text, Line, Position);
        }
    }
    
    public partial class TNull : Token<TNull>
    {
        public TNull(string text)
            : base(text)
        {
        }
        public TNull(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TNull Clone()
        {
            return new TNull(Text, Line, Position);
        }
    }
    
    public partial class TTokenSpecifier : Token<TTokenSpecifier>
    {
        public TTokenSpecifier(string text)
            : base(text)
        {
        }
        public TTokenSpecifier(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TTokenSpecifier Clone()
        {
            return new TTokenSpecifier(Text, Line, Position);
        }
    }
    
    public partial class TProductionSpecifier : Token<TProductionSpecifier>
    {
        public TProductionSpecifier(string text)
            : base(text)
        {
        }
        public TProductionSpecifier(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TProductionSpecifier Clone()
        {
            return new TProductionSpecifier(Text, Line, Position);
        }
    }
    
    public partial class TDot : Token<TDot>
    {
        public TDot(string text)
            : base(text)
        {
        }
        public TDot(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TDot Clone()
        {
            return new TDot(Text, Line, Position);
        }
    }
    
    public partial class TDDot : Token<TDDot>
    {
        public TDDot(string text)
            : base(text)
        {
        }
        public TDDot(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TDDot Clone()
        {
            return new TDDot(Text, Line, Position);
        }
    }
    
    public partial class TSemicolon : Token<TSemicolon>
    {
        public TSemicolon(string text)
            : base(text)
        {
        }
        public TSemicolon(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TSemicolon Clone()
        {
            return new TSemicolon(Text, Line, Position);
        }
    }
    
    public partial class TEqual : Token<TEqual>
    {
        public TEqual(string text)
            : base(text)
        {
        }
        public TEqual(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TEqual Clone()
        {
            return new TEqual(Text, Line, Position);
        }
    }
    
    public partial class TLBkt : Token<TLBkt>
    {
        public TLBkt(string text)
            : base(text)
        {
        }
        public TLBkt(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TLBkt Clone()
        {
            return new TLBkt(Text, Line, Position);
        }
    }
    
    public partial class TRBkt : Token<TRBkt>
    {
        public TRBkt(string text)
            : base(text)
        {
        }
        public TRBkt(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TRBkt Clone()
        {
            return new TRBkt(Text, Line, Position);
        }
    }
    
    public partial class TLPar : Token<TLPar>
    {
        public TLPar(string text)
            : base(text)
        {
        }
        public TLPar(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TLPar Clone()
        {
            return new TLPar(Text, Line, Position);
        }
    }
    
    public partial class TRPar : Token<TRPar>
    {
        public TRPar(string text)
            : base(text)
        {
        }
        public TRPar(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TRPar Clone()
        {
            return new TRPar(Text, Line, Position);
        }
    }
    
    public partial class TLBrace : Token<TLBrace>
    {
        public TLBrace(string text)
            : base(text)
        {
        }
        public TLBrace(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TLBrace Clone()
        {
            return new TLBrace(Text, Line, Position);
        }
    }
    
    public partial class TRBrace : Token<TRBrace>
    {
        public TRBrace(string text)
            : base(text)
        {
        }
        public TRBrace(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TRBrace Clone()
        {
            return new TRBrace(Text, Line, Position);
        }
    }
    
    public partial class TPlus : Token<TPlus>
    {
        public TPlus(string text)
            : base(text)
        {
        }
        public TPlus(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TPlus Clone()
        {
            return new TPlus(Text, Line, Position);
        }
    }
    
    public partial class TMinus : Token<TMinus>
    {
        public TMinus(string text)
            : base(text)
        {
        }
        public TMinus(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TMinus Clone()
        {
            return new TMinus(Text, Line, Position);
        }
    }
    
    public partial class TQMark : Token<TQMark>
    {
        public TQMark(string text)
            : base(text)
        {
        }
        public TQMark(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TQMark Clone()
        {
            return new TQMark(Text, Line, Position);
        }
    }
    
    public partial class TStar : Token<TStar>
    {
        public TStar(string text)
            : base(text)
        {
        }
        public TStar(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TStar Clone()
        {
            return new TStar(Text, Line, Position);
        }
    }
    
    public partial class TPipe : Token<TPipe>
    {
        public TPipe(string text)
            : base(text)
        {
        }
        public TPipe(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TPipe Clone()
        {
            return new TPipe(Text, Line, Position);
        }
    }
    
    public partial class TComma : Token<TComma>
    {
        public TComma(string text)
            : base(text)
        {
        }
        public TComma(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TComma Clone()
        {
            return new TComma(Text, Line, Position);
        }
    }
    
    public partial class TSlash : Token<TSlash>
    {
        public TSlash(string text)
            : base(text)
        {
        }
        public TSlash(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TSlash Clone()
        {
            return new TSlash(Text, Line, Position);
        }
    }
    
    public partial class TArrow : Token<TArrow>
    {
        public TArrow(string text)
            : base(text)
        {
        }
        public TArrow(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TArrow Clone()
        {
            return new TArrow(Text, Line, Position);
        }
    }
    
    public partial class TColon : Token<TColon>
    {
        public TColon(string text)
            : base(text)
        {
        }
        public TColon(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TColon Clone()
        {
            return new TColon(Text, Line, Position);
        }
    }
    
    public partial class TIdentifier : Token<TIdentifier>
    {
        public TIdentifier(string text)
            : base(text)
        {
        }
        public TIdentifier(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TIdentifier Clone()
        {
            return new TIdentifier(Text, Line, Position);
        }
    }
    
    public partial class TCharacter : Token<TCharacter>
    {
        public TCharacter(string text)
            : base(text)
        {
        }
        public TCharacter(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TCharacter Clone()
        {
            return new TCharacter(Text, Line, Position);
        }
    }
    
    public partial class TDecChar : Token<TDecChar>
    {
        public TDecChar(string text)
            : base(text)
        {
        }
        public TDecChar(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TDecChar Clone()
        {
            return new TDecChar(Text, Line, Position);
        }
    }
    
    public partial class THexChar : Token<THexChar>
    {
        public THexChar(string text)
            : base(text)
        {
        }
        public THexChar(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override THexChar Clone()
        {
            return new THexChar(Text, Line, Position);
        }
    }
    
    public partial class TString : Token<TString>
    {
        public TString(string text)
            : base(text)
        {
        }
        public TString(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TString Clone()
        {
            return new TString(Text, Line, Position);
        }
    }
    
    public partial class TBlank : Token<TBlank>
    {
        public TBlank(string text)
            : base(text)
        {
        }
        public TBlank(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TBlank Clone()
        {
            return new TBlank(Text, Line, Position);
        }
    }
    
    public partial class TComment : Token<TComment>
    {
        public TComment(string text)
            : base(text)
        {
        }
        public TComment(string text, int line, int pos)
            : base(text, line, pos)
        {
        }
        
        public override TComment Clone()
        {
            return new TComment(Text, Line, Position);
        }
    }
}
