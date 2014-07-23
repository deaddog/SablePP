using System;
using System.Collections.Generic;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Nodes;

namespace SablePP.Compiler.Parsing
{
    public class Parser : SablePP.Tools.Parsing.Parser<PGrammar>
    {
        #region Token Index
        
        protected override int getTokenIndex(Token token)
        {
            return getIndex((dynamic)token);
        }
        
        private int getIndex(Token node)
        {
            return -1;
        }
        
        private int getIndex(TPackagename node)
        {
            return 0;
        }
        private int getIndex(TPackagetoken node)
        {
            return 1;
        }
        private int getIndex(TStatestoken node)
        {
            return 2;
        }
        private int getIndex(THelperstoken node)
        {
            return 3;
        }
        private int getIndex(TTokenstoken node)
        {
            return 4;
        }
        private int getIndex(TIgnoredtoken node)
        {
            return 5;
        }
        private int getIndex(TProductionstoken node)
        {
            return 6;
        }
        private int getIndex(TAsttoken node)
        {
            return 7;
        }
        private int getIndex(THighlighttoken node)
        {
            return 8;
        }
        private int getIndex(TNew node)
        {
            return 9;
        }
        private int getIndex(TNull node)
        {
            return 10;
        }
        private int getIndex(TTokenSpecifier node)
        {
            return 11;
        }
        private int getIndex(TProductionSpecifier node)
        {
            return 12;
        }
        private int getIndex(TDot node)
        {
            return 13;
        }
        private int getIndex(TDDot node)
        {
            return 14;
        }
        private int getIndex(TSemicolon node)
        {
            return 15;
        }
        private int getIndex(TEqual node)
        {
            return 16;
        }
        private int getIndex(TLBkt node)
        {
            return 17;
        }
        private int getIndex(TRBkt node)
        {
            return 18;
        }
        private int getIndex(TLPar node)
        {
            return 19;
        }
        private int getIndex(TRPar node)
        {
            return 20;
        }
        private int getIndex(TLBrace node)
        {
            return 21;
        }
        private int getIndex(TRBrace node)
        {
            return 22;
        }
        private int getIndex(TPlus node)
        {
            return 23;
        }
        private int getIndex(TMinus node)
        {
            return 24;
        }
        private int getIndex(TQMark node)
        {
            return 25;
        }
        private int getIndex(TStar node)
        {
            return 26;
        }
        private int getIndex(TPipe node)
        {
            return 27;
        }
        private int getIndex(TComma node)
        {
            return 28;
        }
        private int getIndex(TSlash node)
        {
            return 29;
        }
        private int getIndex(TArrow node)
        {
            return 30;
        }
        private int getIndex(TColon node)
        {
            return 31;
        }
        private int getIndex(TIdentifier node)
        {
            return 32;
        }
        private int getIndex(TCharacter node)
        {
            return 33;
        }
        private int getIndex(TDecChar node)
        {
            return 34;
        }
        private int getIndex(THexChar node)
        {
            return 35;
        }
        private int getIndex(TString node)
        {
            return 36;
        }
        private int getIndex(TItalic node)
        {
            return 37;
        }
        private int getIndex(TBold node)
        {
            return 38;
        }
        private int getIndex(TText node)
        {
            return 39;
        }
        private int getIndex(TBackground node)
        {
            return 40;
        }
        private int getIndex(TRgb node)
        {
            return 41;
        }
        private int getIndex(THsv node)
        {
            return 42;
        }
        private int getIndex(THexColor node)
        {
            return 43;
        }
        
        private int getIndex(EOF node)
        {
            return 44;
        }
        
        #endregion
        
        public Parser(SablePP.Tools.Lexing.ILexer lexer)
            : base(lexer, actionTable, gotoTable, errorMessages, errors)
        {
        }
        protected override void reduce(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 1:
                    {
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 2:
                    {
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 3:
                    {
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 4:
                    {
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 5:
                    {
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 6:
                    {
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 7:
                    {
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 8:
                    {
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 9:
                    {
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 10:
                    {
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 11:
                    {
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 12:
                    {
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 13:
                    {
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 14:
                    {
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 15:
                    {
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 16:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 17:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 18:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 19:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 20:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 21:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 22:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 23:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 24:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 25:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 26:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 27:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 28:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 29:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 30:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 31:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 32:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 33:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 34:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 35:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 36:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 37:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 38:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 39:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 40:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 41:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 42:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 43:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 44:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 45:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 46:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 47:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 48:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 49:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 50:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 51:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 52:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 53:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 54:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 55:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 56:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 57:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 58:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 59:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 60:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 61:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 62:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 63:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 64:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 65:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 66:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 67:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 68:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 69:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 70:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 71:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 72:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 73:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 74:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 75:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 76:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 77:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 78:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 79:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 80:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 81:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 82:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 83:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 84:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 85:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 86:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 87:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 88:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 89:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 90:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 91:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 92:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 93:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 94:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 95:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 96:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 97:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 98:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 99:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 100:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 101:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 102:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 103:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 104:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 105:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 106:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 107:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 108:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 109:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 110:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 111:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 112:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 113:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 114:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 115:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 116:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 117:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 118:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 119:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 120:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 121:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 122:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 123:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 124:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 125:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 126:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 127:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            null
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 128:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 129:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 130:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 131:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 132:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 133:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 134:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 135:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 136:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 137:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 138:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 139:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 140:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 141:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 142:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 143:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 144:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 145:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 146:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 147:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 148:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 149:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 150:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 151:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 152:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 153:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 154:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 155:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 156:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 157:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 158:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 159:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 160:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 161:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 162:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 163:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 164:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 165:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 166:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 167:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 168:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 169:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 170:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 171:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 172:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 173:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 174:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 175:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 176:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 177:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 178:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 179:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 180:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 181:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 182:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 183:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 184:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 185:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 186:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 187:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 188:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 189:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 190:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 191:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            null,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 192:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 193:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 194:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 195:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 196:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 197:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 198:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 199:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 200:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 201:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 202:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 203:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 204:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 205:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 206:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 207:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 208:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 209:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 210:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 211:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 212:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 213:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 214:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 215:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 216:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 217:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 218:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 219:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 220:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 221:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 222:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 223:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            null,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 224:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 225:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 226:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 227:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 228:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 229:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 230:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 231:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 232:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 233:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 234:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 235:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 236:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 237:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 238:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 239:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            null,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 240:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 241:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 242:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 243:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 244:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 245:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 246:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 247:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            null,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 248:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 249:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 250:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 251:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            null,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 252:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 253:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            null,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 254:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        AGrammar agrammar = new AGrammar(
                            null,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 255:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        PProductions pproductions = Pop<PProductions>();
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        PTokens ptokens = Pop<PTokens>();
                        PStates pstates = Pop<PStates>();
                        PHelpers phelpers = Pop<PHelpers>();
                        PPackage ppackage = Pop<PPackage>();
                        AGrammar agrammar = new AGrammar(
                            ppackage,
                            phelpers,
                            pstates,
                            ptokens,
                            pignoredtokens,
                            pproductions,
                            pastproductions,
                            phighlightrules
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 256:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        TPackagename tpackagename = Pop<TPackagename>();
                        TPackagetoken tpackagetoken = Pop<TPackagetoken>();
                        APackage apackage = new APackage(
                            tpackagetoken,
                            tpackagename,
                            tsemicolon
                        );
                        Push(1, apackage);
                    }
                    break;
                case 257:
                    {
                        List<PHelper> phelperlist = Pop<List<PHelper>>();
                        THelperstoken thelperstoken = Pop<THelperstoken>();
                        List<PHelper> phelperlist2 = new List<PHelper>();
                        phelperlist2.AddRange(phelperlist);
                        AHelpers ahelpers = new AHelpers(
                            thelperstoken,
                            phelperlist2
                        );
                        Push(2, ahelpers);
                    }
                    break;
                case 258:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        PRegex pregex = Pop<PRegex>();
                        TEqual tequal = Pop<TEqual>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AHelper ahelper = new AHelper(
                            tidentifier,
                            tequal,
                            pregex,
                            tsemicolon
                        );
                        Push(3, ahelper);
                    }
                    break;
                case 259:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        List<PIdentifierListitem> pidentifierlistitemlist = Pop<List<PIdentifierListitem>>();
                        TStatestoken tstatestoken = Pop<TStatestoken>();
                        List<PIdentifierListitem> pidentifierlistitemlist2 = new List<PIdentifierListitem>();
                        pidentifierlistitemlist2.AddRange(pidentifierlistitemlist);
                        AStates astates = new AStates(
                            tstatestoken,
                            pidentifierlistitemlist2,
                            tsemicolon
                        );
                        Push(4, astates);
                    }
                    break;
                case 260:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AIdentifierListitem aidentifierlistitem = new AIdentifierListitem(
                            null,
                            tidentifier
                        );
                        List<PIdentifierListitem> pidentifierlistitemlist = new List<PIdentifierListitem>();
                        pidentifierlistitemlist.Add(aidentifierlistitem);
                        Push(5, pidentifierlistitemlist);
                    }
                    break;
                case 261:
                    {
                        List<PIdentifierListitem> pidentifierlistitemlist = Pop<List<PIdentifierListitem>>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AIdentifierListitem aidentifierlistitem = new AIdentifierListitem(
                            null,
                            tidentifier
                        );
                        List<PIdentifierListitem> pidentifierlistitemlist2 = new List<PIdentifierListitem>();
                        pidentifierlistitemlist2.Add(aidentifierlistitem);
                        pidentifierlistitemlist2.AddRange(pidentifierlistitemlist);
                        Push(5, pidentifierlistitemlist2);
                    }
                    break;
                case 262:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TComma tcomma = Pop<TComma>();
                        AIdentifierListitem aidentifierlistitem = new AIdentifierListitem(
                            tcomma,
                            tidentifier
                        );
                        Push(6, aidentifierlistitem);
                    }
                    break;
                case 263:
                    {
                        List<PToken> ptokenlist = Pop<List<PToken>>();
                        TTokenstoken ttokenstoken = Pop<TTokenstoken>();
                        List<PToken> ptokenlist2 = new List<PToken>();
                        ptokenlist2.AddRange(ptokenlist);
                        ATokens atokens = new ATokens(
                            ttokenstoken,
                            ptokenlist2
                        );
                        Push(7, atokens);
                    }
                    break;
                case 264:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        PRegex pregex = Pop<PRegex>();
                        TEqual tequal = Pop<TEqual>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AToken atoken = new AToken(
                            null,
                            tidentifier,
                            tequal,
                            pregex,
                            null,
                            tsemicolon
                        );
                        Push(8, atoken);
                    }
                    break;
                case 265:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        PRegex pregex = Pop<PRegex>();
                        TEqual tequal = Pop<TEqual>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        PTokenstateList ptokenstatelist = Pop<PTokenstateList>();
                        AToken atoken = new AToken(
                            ptokenstatelist,
                            tidentifier,
                            tequal,
                            pregex,
                            null,
                            tsemicolon
                        );
                        Push(8, atoken);
                    }
                    break;
                case 266:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        PTokenlookahead ptokenlookahead = Pop<PTokenlookahead>();
                        PRegex pregex = Pop<PRegex>();
                        TEqual tequal = Pop<TEqual>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AToken atoken = new AToken(
                            null,
                            tidentifier,
                            tequal,
                            pregex,
                            ptokenlookahead,
                            tsemicolon
                        );
                        Push(8, atoken);
                    }
                    break;
                case 267:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        PTokenlookahead ptokenlookahead = Pop<PTokenlookahead>();
                        PRegex pregex = Pop<PRegex>();
                        TEqual tequal = Pop<TEqual>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        PTokenstateList ptokenstatelist = Pop<PTokenstateList>();
                        AToken atoken = new AToken(
                            ptokenstatelist,
                            tidentifier,
                            tequal,
                            pregex,
                            ptokenlookahead,
                            tsemicolon
                        );
                        Push(8, atoken);
                    }
                    break;
                case 268:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        ATokenstateListitem atokenstatelistitem = new ATokenstateListitem(
                            null,
                            tidentifier
                        );
                        List<PTokenstateListitem> ptokenstatelistitemlist = new List<PTokenstateListitem>();
                        ptokenstatelistitemlist.Add(atokenstatelistitem);
                        ATokenstateList atokenstatelist = new ATokenstateList(
                            tlbrace,
                            ptokenstatelistitemlist,
                            trbrace
                        );
                        Push(9, atokenstatelist);
                    }
                    break;
                case 269:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        List<PTokenstateListitem> ptokenstatelistitemlist = Pop<List<PTokenstateListitem>>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        ATokenstateListitem atokenstatelistitem = new ATokenstateListitem(
                            null,
                            tidentifier
                        );
                        List<PTokenstateListitem> ptokenstatelistitemlist2 = new List<PTokenstateListitem>();
                        ptokenstatelistitemlist2.Add(atokenstatelistitem);
                        ptokenstatelistitemlist2.AddRange(ptokenstatelistitemlist);
                        ATokenstateList atokenstatelist = new ATokenstateList(
                            tlbrace,
                            ptokenstatelistitemlist2,
                            trbrace
                        );
                        Push(9, atokenstatelist);
                    }
                    break;
                case 270:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        TIdentifier tidentifier2 = Pop<TIdentifier>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        ATransitionTokenstateListitem atransitiontokenstatelistitem = new ATransitionTokenstateListitem(
                            null,
                            tidentifier2,
                            tarrow,
                            tidentifier
                        );
                        List<PTokenstateListitem> ptokenstatelistitemlist = new List<PTokenstateListitem>();
                        ptokenstatelistitemlist.Add(atransitiontokenstatelistitem);
                        ATokenstateList atokenstatelist = new ATokenstateList(
                            tlbrace,
                            ptokenstatelistitemlist,
                            trbrace
                        );
                        Push(9, atokenstatelist);
                    }
                    break;
                case 271:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        List<PTokenstateListitem> ptokenstatelistitemlist = Pop<List<PTokenstateListitem>>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        TIdentifier tidentifier2 = Pop<TIdentifier>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        ATransitionTokenstateListitem atransitiontokenstatelistitem = new ATransitionTokenstateListitem(
                            null,
                            tidentifier2,
                            tarrow,
                            tidentifier
                        );
                        List<PTokenstateListitem> ptokenstatelistitemlist2 = new List<PTokenstateListitem>();
                        ptokenstatelistitemlist2.Add(atransitiontokenstatelistitem);
                        ptokenstatelistitemlist2.AddRange(ptokenstatelistitemlist);
                        ATokenstateList atokenstatelist = new ATokenstateList(
                            tlbrace,
                            ptokenstatelistitemlist2,
                            trbrace
                        );
                        Push(9, atokenstatelist);
                    }
                    break;
                case 272:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TComma tcomma = Pop<TComma>();
                        ATokenstateListitem atokenstatelistitem = new ATokenstateListitem(
                            tcomma,
                            tidentifier
                        );
                        Push(10, atokenstatelistitem);
                    }
                    break;
                case 273:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        TIdentifier tidentifier2 = Pop<TIdentifier>();
                        TComma tcomma = Pop<TComma>();
                        ATransitionTokenstateListitem atransitiontokenstatelistitem = new ATransitionTokenstateListitem(
                            tcomma,
                            tidentifier2,
                            tarrow,
                            tidentifier
                        );
                        Push(10, atransitiontokenstatelistitem);
                    }
                    break;
                case 274:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        List<PIdentifierListitem> pidentifierlistitemlist = Pop<List<PIdentifierListitem>>();
                        TTokenstoken ttokenstoken = Pop<TTokenstoken>();
                        TIgnoredtoken tignoredtoken = Pop<TIgnoredtoken>();
                        List<PIdentifierListitem> pidentifierlistitemlist2 = new List<PIdentifierListitem>();
                        pidentifierlistitemlist2.AddRange(pidentifierlistitemlist);
                        AIgnoredtokens aignoredtokens = new AIgnoredtokens(
                            tignoredtoken,
                            ttokenstoken,
                            pidentifierlistitemlist2,
                            tsemicolon
                        );
                        Push(11, aignoredtokens);
                    }
                    break;
                case 275:
                    {
                        PRegex pregex = Pop<PRegex>();
                        TSlash tslash = Pop<TSlash>();
                        ATokenlookahead atokenlookahead = new ATokenlookahead(
                            tslash,
                            pregex
                        );
                        Push(12, atokenlookahead);
                    }
                    break;
                case 276:
                    {
                        List<PRegexpart> pregexpartlist = Pop<List<PRegexpart>>();
                        List<PRegexpart> pregexpartlist2 = new List<PRegexpart>();
                        pregexpartlist2.AddRange(pregexpartlist);
                        ARegexOrpart aregexorpart = new ARegexOrpart(
                            null,
                            pregexpartlist2
                        );
                        List<POrpart> porpartlist = new List<POrpart>();
                        porpartlist.Add(aregexorpart);
                        ARegex aregex = new ARegex(
                            porpartlist
                        );
                        Push(13, aregex);
                    }
                    break;
                case 277:
                    {
                        List<POrpart> porpartlist = Pop<List<POrpart>>();
                        List<PRegexpart> pregexpartlist = Pop<List<PRegexpart>>();
                        List<PRegexpart> pregexpartlist2 = new List<PRegexpart>();
                        pregexpartlist2.AddRange(pregexpartlist);
                        ARegexOrpart aregexorpart = new ARegexOrpart(
                            null,
                            pregexpartlist2
                        );
                        List<POrpart> porpartlist2 = new List<POrpart>();
                        porpartlist2.Add(aregexorpart);
                        porpartlist2.AddRange(porpartlist);
                        ARegex aregex = new ARegex(
                            porpartlist2
                        );
                        Push(13, aregex);
                    }
                    break;
                case 278:
                    {
                        List<PRegexpart> pregexpartlist = Pop<List<PRegexpart>>();
                        TPipe tpipe = Pop<TPipe>();
                        List<PRegexpart> pregexpartlist2 = new List<PRegexpart>();
                        pregexpartlist2.AddRange(pregexpartlist);
                        ARegexOrpart aregexorpart = new ARegexOrpart(
                            tpipe,
                            pregexpartlist2
                        );
                        Push(14, aregexorpart);
                    }
                    break;
                case 279:
                    {
                        List<PRegexpart> pregexpartlist = Pop<List<PRegexpart>>();
                        List<PRegexpart> pregexpartlist2 = new List<PRegexpart>();
                        pregexpartlist2.AddRange(pregexpartlist);
                        Push(15, pregexpartlist2);
                    }
                    break;
                case 280:
                    {
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        Push(16, pregexpart);
                    }
                    break;
                case 281:
                    {
                        TStar tstar = Pop<TStar>();
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        AUnarystarRegexpart aunarystarregexpart = new AUnarystarRegexpart(
                            pregexpart,
                            tstar
                        );
                        Push(16, aunarystarregexpart);
                    }
                    break;
                case 282:
                    {
                        TQMark tqmark = Pop<TQMark>();
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        AUnaryquestionRegexpart aunaryquestionregexpart = new AUnaryquestionRegexpart(
                            pregexpart,
                            tqmark
                        );
                        Push(16, aunaryquestionregexpart);
                    }
                    break;
                case 283:
                    {
                        TPlus tplus = Pop<TPlus>();
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        AUnaryplusRegexpart aunaryplusregexpart = new AUnaryplusRegexpart(
                            pregexpart,
                            tplus
                        );
                        Push(16, aunaryplusregexpart);
                    }
                    break;
                case 284:
                    {
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        Push(17, pregexpart);
                    }
                    break;
                case 285:
                    {
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        Push(17, pregexpart);
                    }
                    break;
                case 286:
                    {
                        TString tstring = Pop<TString>();
                        AStringRegexpart astringregexpart = new AStringRegexpart(
                            tstring
                        );
                        Push(17, astringregexpart);
                    }
                    break;
                case 287:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AIdentifierRegexpart aidentifierregexpart = new AIdentifierRegexpart(
                            tidentifier
                        );
                        Push(17, aidentifierregexpart);
                    }
                    break;
                case 288:
                    {
                        TRPar trpar = Pop<TRPar>();
                        PRegex pregex = Pop<PRegex>();
                        TLPar tlpar = Pop<TLPar>();
                        AParenthesisRegexpart aparenthesisregexpart = new AParenthesisRegexpart(
                            tlpar,
                            pregex,
                            trpar
                        );
                        Push(17, aparenthesisregexpart);
                    }
                    break;
                case 289:
                    {
                        TCharacter tcharacter = Pop<TCharacter>();
                        ACharRegexpart acharregexpart = new ACharRegexpart(
                            tcharacter
                        );
                        Push(18, acharregexpart);
                    }
                    break;
                case 290:
                    {
                        TDecChar tdecchar = Pop<TDecChar>();
                        ADecRegexpart adecregexpart = new ADecRegexpart(
                            tdecchar
                        );
                        Push(18, adecregexpart);
                    }
                    break;
                case 291:
                    {
                        THexChar thexchar = Pop<THexChar>();
                        AHexRegexpart ahexregexpart = new AHexRegexpart(
                            thexchar
                        );
                        Push(18, ahexregexpart);
                    }
                    break;
                case 292:
                    {
                        TRBkt trbkt = Pop<TRBkt>();
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        TPlus tplus = Pop<TPlus>();
                        PRegexpart pregexpart2 = Pop<PRegexpart>();
                        TLBkt tlbkt = Pop<TLBkt>();
                        ABinaryplusRegexpart abinaryplusregexpart = new ABinaryplusRegexpart(
                            tlbkt,
                            pregexpart2,
                            tplus,
                            pregexpart,
                            trbkt
                        );
                        Push(19, abinaryplusregexpart);
                    }
                    break;
                case 293:
                    {
                        TRBkt trbkt = Pop<TRBkt>();
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        TMinus tminus = Pop<TMinus>();
                        PRegexpart pregexpart2 = Pop<PRegexpart>();
                        TLBkt tlbkt = Pop<TLBkt>();
                        ABinaryminusRegexpart abinaryminusregexpart = new ABinaryminusRegexpart(
                            tlbkt,
                            pregexpart2,
                            tminus,
                            pregexpart,
                            trbkt
                        );
                        Push(19, abinaryminusregexpart);
                    }
                    break;
                case 294:
                    {
                        TRBkt trbkt = Pop<TRBkt>();
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        TDDot tddot = Pop<TDDot>();
                        PRegexpart pregexpart2 = Pop<PRegexpart>();
                        TLBkt tlbkt = Pop<TLBkt>();
                        AIntervalRegexpart aintervalregexpart = new AIntervalRegexpart(
                            tlbkt,
                            pregexpart2,
                            tddot,
                            pregexpart,
                            trbkt
                        );
                        Push(19, aintervalregexpart);
                    }
                    break;
                case 295:
                    {
                        List<PProduction> pproductionlist = Pop<List<PProduction>>();
                        TProductionstoken tproductionstoken = Pop<TProductionstoken>();
                        List<PProduction> pproductionlist2 = new List<PProduction>();
                        pproductionlist2.AddRange(pproductionlist);
                        AProductions aproductions = new AProductions(
                            tproductionstoken,
                            pproductionlist2
                        );
                        Push(20, aproductions);
                    }
                    break;
                case 296:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        PProductionrule pproductionrule = Pop<PProductionrule>();
                        TEqual tequal = Pop<TEqual>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AProduction aproduction = new AProduction(
                            tidentifier,
                            null,
                            tequal,
                            pproductionrule,
                            tsemicolon
                        );
                        Push(21, aproduction);
                    }
                    break;
                case 297:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        PProductionrule pproductionrule = Pop<PProductionrule>();
                        TEqual tequal = Pop<TEqual>();
                        PProdtranslation pprodtranslation = Pop<PProdtranslation>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AProduction aproduction = new AProduction(
                            tidentifier,
                            pprodtranslation,
                            tequal,
                            pproductionrule,
                            tsemicolon
                        );
                        Push(21, aproduction);
                    }
                    break;
                case 298:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        ACleanProdtranslation acleanprodtranslation = new ACleanProdtranslation(
                            tlbrace,
                            tarrow,
                            tidentifier,
                            trbrace
                        );
                        Push(22, acleanprodtranslation);
                    }
                    break;
                case 299:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        TStar tstar = Pop<TStar>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AStarProdtranslation astarprodtranslation = new AStarProdtranslation(
                            tlbrace,
                            tarrow,
                            tidentifier,
                            tstar,
                            trbrace
                        );
                        Push(22, astarprodtranslation);
                    }
                    break;
                case 300:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        TPlus tplus = Pop<TPlus>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        APlusProdtranslation aplusprodtranslation = new APlusProdtranslation(
                            tlbrace,
                            tarrow,
                            tidentifier,
                            tplus,
                            trbrace
                        );
                        Push(22, aplusprodtranslation);
                    }
                    break;
                case 301:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        TQMark tqmark = Pop<TQMark>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AQuestionProdtranslation aquestionprodtranslation = new AQuestionProdtranslation(
                            tlbrace,
                            tarrow,
                            tidentifier,
                            tqmark,
                            trbrace
                        );
                        Push(22, aquestionprodtranslation);
                    }
                    break;
                case 302:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        PTranslation ptranslation = Pop<PTranslation>();
                        TArrow tarrow = Pop<TArrow>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AFullTranslation afulltranslation = new AFullTranslation(
                            tlbrace,
                            tarrow,
                            ptranslation,
                            trbrace
                        );
                        Push(23, afulltranslation);
                    }
                    break;
                case 303:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        Push(24, ptranslation);
                    }
                    break;
                case 304:
                    {
                        TRPar trpar = Pop<TRPar>();
                        TLPar tlpar = Pop<TLPar>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TNew tnew = Pop<TNew>();
                        List<PTranslationListitem> ptranslationlistitemlist = new List<PTranslationListitem>();
                        ANewTranslation anewtranslation = new ANewTranslation(
                            tnew,
                            tidentifier,
                            tlpar,
                            ptranslationlistitemlist,
                            trpar
                        );
                        Push(24, anewtranslation);
                    }
                    break;
                case 305:
                    {
                        TRPar trpar = Pop<TRPar>();
                        List<PTranslationListitem> ptranslationlistitemlist = Pop<List<PTranslationListitem>>();
                        TLPar tlpar = Pop<TLPar>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TNew tnew = Pop<TNew>();
                        List<PTranslationListitem> ptranslationlistitemlist2 = new List<PTranslationListitem>();
                        ptranslationlistitemlist2.AddRange(ptranslationlistitemlist);
                        ANewTranslation anewtranslation = new ANewTranslation(
                            tnew,
                            tidentifier,
                            tlpar,
                            ptranslationlistitemlist2,
                            trpar
                        );
                        Push(24, anewtranslation);
                    }
                    break;
                case 306:
                    {
                        TRPar trpar = Pop<TRPar>();
                        TLPar tlpar = Pop<TLPar>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TIdentifier tidentifier2 = Pop<TIdentifier>();
                        TNew tnew = Pop<TNew>();
                        List<PTranslationListitem> ptranslationlistitemlist = new List<PTranslationListitem>();
                        ANewalternativeTranslation anewalternativetranslation = new ANewalternativeTranslation(
                            tnew,
                            tidentifier2,
                            tdot,
                            tidentifier,
                            tlpar,
                            ptranslationlistitemlist,
                            trpar
                        );
                        Push(24, anewalternativetranslation);
                    }
                    break;
                case 307:
                    {
                        TRPar trpar = Pop<TRPar>();
                        List<PTranslationListitem> ptranslationlistitemlist = Pop<List<PTranslationListitem>>();
                        TLPar tlpar = Pop<TLPar>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TIdentifier tidentifier2 = Pop<TIdentifier>();
                        TNew tnew = Pop<TNew>();
                        List<PTranslationListitem> ptranslationlistitemlist2 = new List<PTranslationListitem>();
                        ptranslationlistitemlist2.AddRange(ptranslationlistitemlist);
                        ANewalternativeTranslation anewalternativetranslation = new ANewalternativeTranslation(
                            tnew,
                            tidentifier2,
                            tdot,
                            tidentifier,
                            tlpar,
                            ptranslationlistitemlist2,
                            trpar
                        );
                        Push(24, anewalternativetranslation);
                    }
                    break;
                case 308:
                    {
                        TNull tnull = Pop<TNull>();
                        ANullTranslation anulltranslation = new ANullTranslation(
                            tnull
                        );
                        Push(24, anulltranslation);
                    }
                    break;
                case 309:
                    {
                        TRBkt trbkt = Pop<TRBkt>();
                        TLBkt tlbkt = Pop<TLBkt>();
                        List<PTranslationListitem> ptranslationlistitemlist = new List<PTranslationListitem>();
                        AListTranslation alisttranslation = new AListTranslation(
                            tlbkt,
                            ptranslationlistitemlist,
                            trbkt
                        );
                        Push(24, alisttranslation);
                    }
                    break;
                case 310:
                    {
                        TRBkt trbkt = Pop<TRBkt>();
                        List<PTranslationListitem> ptranslationlistitemlist = Pop<List<PTranslationListitem>>();
                        TLBkt tlbkt = Pop<TLBkt>();
                        List<PTranslationListitem> ptranslationlistitemlist2 = new List<PTranslationListitem>();
                        ptranslationlistitemlist2.AddRange(ptranslationlistitemlist);
                        AListTranslation alisttranslation = new AListTranslation(
                            tlbkt,
                            ptranslationlistitemlist2,
                            trbkt
                        );
                        Push(24, alisttranslation);
                    }
                    break;
                case 311:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        ATranslationListitem atranslationlistitem = new ATranslationListitem(
                            null,
                            ptranslation
                        );
                        List<PTranslationListitem> ptranslationlistitemlist = new List<PTranslationListitem>();
                        ptranslationlistitemlist.Add(atranslationlistitem);
                        Push(25, ptranslationlistitemlist);
                    }
                    break;
                case 312:
                    {
                        List<PTranslationListitem> ptranslationlistitemlist = Pop<List<PTranslationListitem>>();
                        PTranslation ptranslation = Pop<PTranslation>();
                        ATranslationListitem atranslationlistitem = new ATranslationListitem(
                            null,
                            ptranslation
                        );
                        List<PTranslationListitem> ptranslationlistitemlist2 = new List<PTranslationListitem>();
                        ptranslationlistitemlist2.Add(atranslationlistitem);
                        ptranslationlistitemlist2.AddRange(ptranslationlistitemlist);
                        Push(25, ptranslationlistitemlist2);
                    }
                    break;
                case 313:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        TComma tcomma = Pop<TComma>();
                        ATranslationListitem atranslationlistitem = new ATranslationListitem(
                            tcomma,
                            ptranslation
                        );
                        Push(26, atranslationlistitem);
                    }
                    break;
                case 314:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AIdTranslation aidtranslation = new AIdTranslation(
                            tidentifier
                        );
                        Push(27, aidtranslation);
                    }
                    break;
                case 315:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TIdentifier tidentifier2 = Pop<TIdentifier>();
                        AIddotidTranslation aiddotidtranslation = new AIddotidTranslation(
                            tidentifier2,
                            tdot,
                            tidentifier
                        );
                        Push(27, aiddotidtranslation);
                    }
                    break;
                case 316:
                    {
                        List<PElement> pelementlist = new List<PElement>();
                        AElements aelements = new AElements(
                            pelementlist
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            null,
                            aelements,
                            null
                        );
                        List<PAlternative> palternativelist = new List<PAlternative>();
                        palternativelist.Add(aalternative);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 317:
                    {
                        PAlternativename palternativename = Pop<PAlternativename>();
                        List<PElement> pelementlist = new List<PElement>();
                        AElements aelements = new AElements(
                            pelementlist
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            palternativename,
                            aelements,
                            null
                        );
                        List<PAlternative> palternativelist = new List<PAlternative>();
                        palternativelist.Add(aalternative);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 318:
                    {
                        List<PElement> pelementlist = Pop<List<PElement>>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AElements aelements = new AElements(
                            pelementlist2
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            null,
                            aelements,
                            null
                        );
                        List<PAlternative> palternativelist = new List<PAlternative>();
                        palternativelist.Add(aalternative);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 319:
                    {
                        List<PElement> pelementlist = Pop<List<PElement>>();
                        PAlternativename palternativename = Pop<PAlternativename>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AElements aelements = new AElements(
                            pelementlist2
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            palternativename,
                            aelements,
                            null
                        );
                        List<PAlternative> palternativelist = new List<PAlternative>();
                        palternativelist.Add(aalternative);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 320:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        List<PElement> pelementlist = new List<PElement>();
                        AElements aelements = new AElements(
                            pelementlist
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            null,
                            aelements,
                            ptranslation
                        );
                        List<PAlternative> palternativelist = new List<PAlternative>();
                        palternativelist.Add(aalternative);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 321:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        PAlternativename palternativename = Pop<PAlternativename>();
                        List<PElement> pelementlist = new List<PElement>();
                        AElements aelements = new AElements(
                            pelementlist
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            palternativename,
                            aelements,
                            ptranslation
                        );
                        List<PAlternative> palternativelist = new List<PAlternative>();
                        palternativelist.Add(aalternative);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 322:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        List<PElement> pelementlist = Pop<List<PElement>>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AElements aelements = new AElements(
                            pelementlist2
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            null,
                            aelements,
                            ptranslation
                        );
                        List<PAlternative> palternativelist = new List<PAlternative>();
                        palternativelist.Add(aalternative);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 323:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        List<PElement> pelementlist = Pop<List<PElement>>();
                        PAlternativename palternativename = Pop<PAlternativename>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AElements aelements = new AElements(
                            pelementlist2
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            palternativename,
                            aelements,
                            ptranslation
                        );
                        List<PAlternative> palternativelist = new List<PAlternative>();
                        palternativelist.Add(aalternative);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 324:
                    {
                        List<PAlternative> palternativelist = Pop<List<PAlternative>>();
                        List<PElement> pelementlist = new List<PElement>();
                        AElements aelements = new AElements(
                            pelementlist
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            null,
                            aelements,
                            null
                        );
                        List<PAlternative> palternativelist2 = new List<PAlternative>();
                        palternativelist2.Add(aalternative);
                        palternativelist2.AddRange(palternativelist);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist2
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 325:
                    {
                        List<PAlternative> palternativelist = Pop<List<PAlternative>>();
                        PAlternativename palternativename = Pop<PAlternativename>();
                        List<PElement> pelementlist = new List<PElement>();
                        AElements aelements = new AElements(
                            pelementlist
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            palternativename,
                            aelements,
                            null
                        );
                        List<PAlternative> palternativelist2 = new List<PAlternative>();
                        palternativelist2.Add(aalternative);
                        palternativelist2.AddRange(palternativelist);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist2
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 326:
                    {
                        List<PAlternative> palternativelist = Pop<List<PAlternative>>();
                        List<PElement> pelementlist = Pop<List<PElement>>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AElements aelements = new AElements(
                            pelementlist2
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            null,
                            aelements,
                            null
                        );
                        List<PAlternative> palternativelist2 = new List<PAlternative>();
                        palternativelist2.Add(aalternative);
                        palternativelist2.AddRange(palternativelist);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist2
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 327:
                    {
                        List<PAlternative> palternativelist = Pop<List<PAlternative>>();
                        List<PElement> pelementlist = Pop<List<PElement>>();
                        PAlternativename palternativename = Pop<PAlternativename>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AElements aelements = new AElements(
                            pelementlist2
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            palternativename,
                            aelements,
                            null
                        );
                        List<PAlternative> palternativelist2 = new List<PAlternative>();
                        palternativelist2.Add(aalternative);
                        palternativelist2.AddRange(palternativelist);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist2
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 328:
                    {
                        List<PAlternative> palternativelist = Pop<List<PAlternative>>();
                        PTranslation ptranslation = Pop<PTranslation>();
                        List<PElement> pelementlist = new List<PElement>();
                        AElements aelements = new AElements(
                            pelementlist
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            null,
                            aelements,
                            ptranslation
                        );
                        List<PAlternative> palternativelist2 = new List<PAlternative>();
                        palternativelist2.Add(aalternative);
                        palternativelist2.AddRange(palternativelist);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist2
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 329:
                    {
                        List<PAlternative> palternativelist = Pop<List<PAlternative>>();
                        PTranslation ptranslation = Pop<PTranslation>();
                        PAlternativename palternativename = Pop<PAlternativename>();
                        List<PElement> pelementlist = new List<PElement>();
                        AElements aelements = new AElements(
                            pelementlist
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            palternativename,
                            aelements,
                            ptranslation
                        );
                        List<PAlternative> palternativelist2 = new List<PAlternative>();
                        palternativelist2.Add(aalternative);
                        palternativelist2.AddRange(palternativelist);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist2
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 330:
                    {
                        List<PAlternative> palternativelist = Pop<List<PAlternative>>();
                        PTranslation ptranslation = Pop<PTranslation>();
                        List<PElement> pelementlist = Pop<List<PElement>>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AElements aelements = new AElements(
                            pelementlist2
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            null,
                            aelements,
                            ptranslation
                        );
                        List<PAlternative> palternativelist2 = new List<PAlternative>();
                        palternativelist2.Add(aalternative);
                        palternativelist2.AddRange(palternativelist);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist2
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 331:
                    {
                        List<PAlternative> palternativelist = Pop<List<PAlternative>>();
                        PTranslation ptranslation = Pop<PTranslation>();
                        List<PElement> pelementlist = Pop<List<PElement>>();
                        PAlternativename palternativename = Pop<PAlternativename>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AElements aelements = new AElements(
                            pelementlist2
                        );
                        AAlternative aalternative = new AAlternative(
                            null,
                            palternativename,
                            aelements,
                            ptranslation
                        );
                        List<PAlternative> palternativelist2 = new List<PAlternative>();
                        palternativelist2.Add(aalternative);
                        palternativelist2.AddRange(palternativelist);
                        AProductionrule aproductionrule = new AProductionrule(
                            palternativelist2
                        );
                        Push(28, aproductionrule);
                    }
                    break;
                case 332:
                    {
                        TPipe tpipe = Pop<TPipe>();
                        List<PElement> pelementlist = new List<PElement>();
                        AElements aelements = new AElements(
                            pelementlist
                        );
                        AAlternative aalternative = new AAlternative(
                            tpipe,
                            null,
                            aelements,
                            null
                        );
                        Push(29, aalternative);
                    }
                    break;
                case 333:
                    {
                        PAlternativename palternativename = Pop<PAlternativename>();
                        TPipe tpipe = Pop<TPipe>();
                        List<PElement> pelementlist = new List<PElement>();
                        AElements aelements = new AElements(
                            pelementlist
                        );
                        AAlternative aalternative = new AAlternative(
                            tpipe,
                            palternativename,
                            aelements,
                            null
                        );
                        Push(29, aalternative);
                    }
                    break;
                case 334:
                    {
                        List<PElement> pelementlist = Pop<List<PElement>>();
                        TPipe tpipe = Pop<TPipe>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AElements aelements = new AElements(
                            pelementlist2
                        );
                        AAlternative aalternative = new AAlternative(
                            tpipe,
                            null,
                            aelements,
                            null
                        );
                        Push(29, aalternative);
                    }
                    break;
                case 335:
                    {
                        List<PElement> pelementlist = Pop<List<PElement>>();
                        PAlternativename palternativename = Pop<PAlternativename>();
                        TPipe tpipe = Pop<TPipe>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AElements aelements = new AElements(
                            pelementlist2
                        );
                        AAlternative aalternative = new AAlternative(
                            tpipe,
                            palternativename,
                            aelements,
                            null
                        );
                        Push(29, aalternative);
                    }
                    break;
                case 336:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        TPipe tpipe = Pop<TPipe>();
                        List<PElement> pelementlist = new List<PElement>();
                        AElements aelements = new AElements(
                            pelementlist
                        );
                        AAlternative aalternative = new AAlternative(
                            tpipe,
                            null,
                            aelements,
                            ptranslation
                        );
                        Push(29, aalternative);
                    }
                    break;
                case 337:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        PAlternativename palternativename = Pop<PAlternativename>();
                        TPipe tpipe = Pop<TPipe>();
                        List<PElement> pelementlist = new List<PElement>();
                        AElements aelements = new AElements(
                            pelementlist
                        );
                        AAlternative aalternative = new AAlternative(
                            tpipe,
                            palternativename,
                            aelements,
                            ptranslation
                        );
                        Push(29, aalternative);
                    }
                    break;
                case 338:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        List<PElement> pelementlist = Pop<List<PElement>>();
                        TPipe tpipe = Pop<TPipe>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AElements aelements = new AElements(
                            pelementlist2
                        );
                        AAlternative aalternative = new AAlternative(
                            tpipe,
                            null,
                            aelements,
                            ptranslation
                        );
                        Push(29, aalternative);
                    }
                    break;
                case 339:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        List<PElement> pelementlist = Pop<List<PElement>>();
                        PAlternativename palternativename = Pop<PAlternativename>();
                        TPipe tpipe = Pop<TPipe>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AElements aelements = new AElements(
                            pelementlist2
                        );
                        AAlternative aalternative = new AAlternative(
                            tpipe,
                            palternativename,
                            aelements,
                            ptranslation
                        );
                        Push(29, aalternative);
                    }
                    break;
                case 340:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AAlternativename aalternativename = new AAlternativename(
                            tlbrace,
                            tidentifier,
                            trbrace
                        );
                        Push(30, aalternativename);
                    }
                    break;
                case 341:
                    {
                        PElementid pelementid = Pop<PElementid>();
                        ASimpleElement asimpleelement = new ASimpleElement(
                            null,
                            pelementid
                        );
                        Push(31, asimpleelement);
                    }
                    break;
                case 342:
                    {
                        PElementid pelementid = Pop<PElementid>();
                        PElementname pelementname = Pop<PElementname>();
                        ASimpleElement asimpleelement = new ASimpleElement(
                            pelementname,
                            pelementid
                        );
                        Push(31, asimpleelement);
                    }
                    break;
                case 343:
                    {
                        TStar tstar = Pop<TStar>();
                        PElementid pelementid = Pop<PElementid>();
                        AStarElement astarelement = new AStarElement(
                            null,
                            pelementid,
                            tstar
                        );
                        Push(31, astarelement);
                    }
                    break;
                case 344:
                    {
                        TStar tstar = Pop<TStar>();
                        PElementid pelementid = Pop<PElementid>();
                        PElementname pelementname = Pop<PElementname>();
                        AStarElement astarelement = new AStarElement(
                            pelementname,
                            pelementid,
                            tstar
                        );
                        Push(31, astarelement);
                    }
                    break;
                case 345:
                    {
                        TQMark tqmark = Pop<TQMark>();
                        PElementid pelementid = Pop<PElementid>();
                        AQuestionElement aquestionelement = new AQuestionElement(
                            null,
                            pelementid,
                            tqmark
                        );
                        Push(31, aquestionelement);
                    }
                    break;
                case 346:
                    {
                        TQMark tqmark = Pop<TQMark>();
                        PElementid pelementid = Pop<PElementid>();
                        PElementname pelementname = Pop<PElementname>();
                        AQuestionElement aquestionelement = new AQuestionElement(
                            pelementname,
                            pelementid,
                            tqmark
                        );
                        Push(31, aquestionelement);
                    }
                    break;
                case 347:
                    {
                        TPlus tplus = Pop<TPlus>();
                        PElementid pelementid = Pop<PElementid>();
                        APlusElement apluselement = new APlusElement(
                            null,
                            pelementid,
                            tplus
                        );
                        Push(31, apluselement);
                    }
                    break;
                case 348:
                    {
                        TPlus tplus = Pop<TPlus>();
                        PElementid pelementid = Pop<PElementid>();
                        PElementname pelementname = Pop<PElementname>();
                        APlusElement apluselement = new APlusElement(
                            pelementname,
                            pelementid,
                            tplus
                        );
                        Push(31, apluselement);
                    }
                    break;
                case 349:
                    {
                        TColon tcolon = Pop<TColon>();
                        TRBkt trbkt = Pop<TRBkt>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TLBkt tlbkt = Pop<TLBkt>();
                        AElementname aelementname = new AElementname(
                            tlbkt,
                            tidentifier,
                            trbkt,
                            tcolon
                        );
                        Push(32, aelementname);
                    }
                    break;
                case 350:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        ACleanElementid acleanelementid = new ACleanElementid(
                            tidentifier
                        );
                        Push(33, acleanelementid);
                    }
                    break;
                case 351:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TTokenSpecifier ttokenspecifier = Pop<TTokenSpecifier>();
                        ATokenElementid atokenelementid = new ATokenElementid(
                            ttokenspecifier,
                            tdot,
                            tidentifier
                        );
                        Push(33, atokenelementid);
                    }
                    break;
                case 352:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TProductionSpecifier tproductionspecifier = Pop<TProductionSpecifier>();
                        AProductionElementid aproductionelementid = new AProductionElementid(
                            tproductionspecifier,
                            tdot,
                            tidentifier
                        );
                        Push(33, aproductionelementid);
                    }
                    break;
                case 353:
                    {
                        List<PProduction> pproductionlist = Pop<List<PProduction>>();
                        TAsttoken tasttoken = Pop<TAsttoken>();
                        List<PProduction> pproductionlist2 = new List<PProduction>();
                        pproductionlist2.AddRange(pproductionlist);
                        AAstproductions aastproductions = new AAstproductions(
                            tasttoken,
                            pproductionlist2
                        );
                        Push(34, aastproductions);
                    }
                    break;
                case 354:
                    {
                        List<PHighlightrule> phighlightrule = Pop<List<PHighlightrule>>();
                        THighlighttoken thighlighttoken = Pop<THighlighttoken>();
                        AHighlightrules ahighlightrules = new AHighlightrules(
                            thighlighttoken,
                            phighlightrule
                        );
                        Push(35, ahighlightrules);
                    }
                    break;
                case 355:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        List<PStyleListitem> pstylelistitemlist = Pop<List<PStyleListitem>>();
                        TRBrace trbrace = Pop<TRBrace>();
                        List<PIdentifierListitem> pidentifierlistitemlist = Pop<List<PIdentifierListitem>>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        List<PIdentifierListitem> pidentifierlistitemlist2 = new List<PIdentifierListitem>();
                        pidentifierlistitemlist2.AddRange(pidentifierlistitemlist);
                        List<PStyleListitem> pstylelistitemlist2 = new List<PStyleListitem>();
                        pstylelistitemlist2.AddRange(pstylelistitemlist);
                        AHighlightrule ahighlightrule = new AHighlightrule(
                            tidentifier,
                            tlbrace,
                            pidentifierlistitemlist2,
                            trbrace,
                            pstylelistitemlist2,
                            tsemicolon
                        );
                        Push(36, ahighlightrule);
                    }
                    break;
                case 356:
                    {
                        PHighlightStyle phighlightstyle = Pop<PHighlightStyle>();
                        AStyleListitem astylelistitem = new AStyleListitem(
                            null,
                            phighlightstyle
                        );
                        List<PStyleListitem> pstylelistitemlist = new List<PStyleListitem>();
                        pstylelistitemlist.Add(astylelistitem);
                        Push(37, pstylelistitemlist);
                    }
                    break;
                case 357:
                    {
                        List<PStyleListitem> pstylelistitemlist = Pop<List<PStyleListitem>>();
                        PHighlightStyle phighlightstyle = Pop<PHighlightStyle>();
                        AStyleListitem astylelistitem = new AStyleListitem(
                            null,
                            phighlightstyle
                        );
                        List<PStyleListitem> pstylelistitemlist2 = new List<PStyleListitem>();
                        pstylelistitemlist2.Add(astylelistitem);
                        pstylelistitemlist2.AddRange(pstylelistitemlist);
                        Push(37, pstylelistitemlist2);
                    }
                    break;
                case 358:
                    {
                        PHighlightStyle phighlightstyle = Pop<PHighlightStyle>();
                        TComma tcomma = Pop<TComma>();
                        AStyleListitem astylelistitem = new AStyleListitem(
                            tcomma,
                            phighlightstyle
                        );
                        Push(38, astylelistitem);
                    }
                    break;
                case 359:
                    {
                        TItalic titalic = Pop<TItalic>();
                        AItalicHighlightStyle aitalichighlightstyle = new AItalicHighlightStyle(
                            titalic
                        );
                        Push(39, aitalichighlightstyle);
                    }
                    break;
                case 360:
                    {
                        TBold tbold = Pop<TBold>();
                        ABoldHighlightStyle aboldhighlightstyle = new ABoldHighlightStyle(
                            tbold
                        );
                        Push(39, aboldhighlightstyle);
                    }
                    break;
                case 361:
                    {
                        PColor pcolor = Pop<PColor>();
                        TColon tcolon = Pop<TColon>();
                        TText ttext = Pop<TText>();
                        ATextHighlightStyle atexthighlightstyle = new ATextHighlightStyle(
                            ttext,
                            tcolon,
                            pcolor
                        );
                        Push(39, atexthighlightstyle);
                    }
                    break;
                case 362:
                    {
                        PColor pcolor = Pop<PColor>();
                        TColon tcolon = Pop<TColon>();
                        TBackground tbackground = Pop<TBackground>();
                        ABackgroundHighlightStyle abackgroundhighlightstyle = new ABackgroundHighlightStyle(
                            tbackground,
                            tcolon,
                            pcolor
                        );
                        Push(39, abackgroundhighlightstyle);
                    }
                    break;
                case 363:
                    {
                        TRPar trpar = Pop<TRPar>();
                        TDecChar tdecchar = Pop<TDecChar>();
                        TComma tcomma = Pop<TComma>();
                        TDecChar tdecchar2 = Pop<TDecChar>();
                        TComma tcomma2 = Pop<TComma>();
                        TDecChar tdecchar3 = Pop<TDecChar>();
                        TLPar tlpar = Pop<TLPar>();
                        TRgb trgb = Pop<TRgb>();
                        ARgbColor argbcolor = new ARgbColor(
                            trgb,
                            tlpar,
                            tdecchar3,
                            tcomma2,
                            tdecchar2,
                            tcomma,
                            tdecchar,
                            trpar
                        );
                        Push(40, argbcolor);
                    }
                    break;
                case 364:
                    {
                        TRPar trpar = Pop<TRPar>();
                        TDecChar tdecchar = Pop<TDecChar>();
                        TComma tcomma = Pop<TComma>();
                        TDecChar tdecchar2 = Pop<TDecChar>();
                        TComma tcomma2 = Pop<TComma>();
                        TDecChar tdecchar3 = Pop<TDecChar>();
                        TLPar tlpar = Pop<TLPar>();
                        THsv thsv = Pop<THsv>();
                        AHsvColor ahsvcolor = new AHsvColor(
                            thsv,
                            tlpar,
                            tdecchar3,
                            tcomma2,
                            tdecchar2,
                            tcomma,
                            tdecchar,
                            trpar
                        );
                        Push(40, ahsvcolor);
                    }
                    break;
                case 365:
                    {
                        THexColor thexcolor = Pop<THexColor>();
                        AHexColor ahexcolor = new AHexColor(
                            thexcolor
                        );
                        Push(40, ahexcolor);
                    }
                    break;
                case 366:
                    Push(41, new List<PHelper>() { Pop<PHelper>() });
                    break;
                case 367:
                    {
                        PHelper item = Pop<PHelper>();
                        List<PHelper> list = Pop<List<PHelper>>();
                        list.Add(item);
                        Push(41, list);
                    }
                    break;
                case 368:
                    Push(42, new List<PIdentifierListitem>() { Pop<PIdentifierListitem>() });
                    break;
                case 369:
                    {
                        PIdentifierListitem item = Pop<PIdentifierListitem>();
                        List<PIdentifierListitem> list = Pop<List<PIdentifierListitem>>();
                        list.Add(item);
                        Push(42, list);
                    }
                    break;
                case 370:
                    Push(43, new List<PToken>() { Pop<PToken>() });
                    break;
                case 371:
                    {
                        PToken item = Pop<PToken>();
                        List<PToken> list = Pop<List<PToken>>();
                        list.Add(item);
                        Push(43, list);
                    }
                    break;
                case 372:
                    Push(44, new List<PTokenstateListitem>() { Pop<PTokenstateListitem>() });
                    break;
                case 373:
                    {
                        PTokenstateListitem item = Pop<PTokenstateListitem>();
                        List<PTokenstateListitem> list = Pop<List<PTokenstateListitem>>();
                        list.Add(item);
                        Push(44, list);
                    }
                    break;
                case 374:
                    Push(45, new List<POrpart>() { Pop<POrpart>() });
                    break;
                case 375:
                    {
                        POrpart item = Pop<POrpart>();
                        List<POrpart> list = Pop<List<POrpart>>();
                        list.Add(item);
                        Push(45, list);
                    }
                    break;
                case 376:
                    Push(46, new List<PRegexpart>() { Pop<PRegexpart>() });
                    break;
                case 377:
                    {
                        PRegexpart item = Pop<PRegexpart>();
                        List<PRegexpart> list = Pop<List<PRegexpart>>();
                        list.Add(item);
                        Push(46, list);
                    }
                    break;
                case 378:
                    Push(47, new List<PProduction>() { Pop<PProduction>() });
                    break;
                case 379:
                    {
                        PProduction item = Pop<PProduction>();
                        List<PProduction> list = Pop<List<PProduction>>();
                        list.Add(item);
                        Push(47, list);
                    }
                    break;
                case 380:
                    Push(48, new List<PTranslationListitem>() { Pop<PTranslationListitem>() });
                    break;
                case 381:
                    {
                        PTranslationListitem item = Pop<PTranslationListitem>();
                        List<PTranslationListitem> list = Pop<List<PTranslationListitem>>();
                        list.Add(item);
                        Push(48, list);
                    }
                    break;
                case 382:
                    Push(49, new List<PElement>() { Pop<PElement>() });
                    break;
                case 383:
                    {
                        PElement item = Pop<PElement>();
                        List<PElement> list = Pop<List<PElement>>();
                        list.Add(item);
                        Push(49, list);
                    }
                    break;
                case 384:
                    Push(50, new List<PAlternative>() { Pop<PAlternative>() });
                    break;
                case 385:
                    {
                        PAlternative item = Pop<PAlternative>();
                        List<PAlternative> list = Pop<List<PAlternative>>();
                        list.Add(item);
                        Push(50, list);
                    }
                    break;
                case 386:
                    Push(51, new List<PHighlightrule>() { Pop<PHighlightrule>() });
                    break;
                case 387:
                    {
                        PHighlightrule item = Pop<PHighlightrule>();
                        List<PHighlightrule> list = Pop<List<PHighlightrule>>();
                        list.Add(item);
                        Push(51, list);
                    }
                    break;
                case 388:
                    Push(52, new List<PStyleListitem>() { Pop<PStyleListitem>() });
                    break;
                case 389:
                    {
                        PStyleListitem item = Pop<PStyleListitem>();
                        List<PStyleListitem> list = Pop<List<PStyleListitem>>();
                        list.Add(item);
                        Push(52, list);
                    }
                    break;
            }
        }
        
        private static int[][][] actionTable = {
            new int[][] {
                new int[] {-1, 1, 0},
                new int[] {1, 0, 1},
                new int[] {2, 0, 2},
                new int[] {3, 0, 3},
                new int[] {4, 0, 4},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 3, 1},
                new int[] {0, 0, 18},
            },
            new int[][] {
                new int[] {-1, 3, 2},
                new int[] {32, 0, 19},
            },
            new int[][] {
                new int[] {-1, 3, 3},
                new int[] {32, 0, 21},
            },
            new int[][] {
                new int[] {-1, 3, 4},
                new int[] {21, 0, 24},
                new int[] {32, 0, 25},
            },
            new int[][] {
                new int[] {-1, 3, 5},
                new int[] {4, 0, 29},
            },
            new int[][] {
                new int[] {-1, 3, 6},
                new int[] {32, 0, 30},
            },
            new int[][] {
                new int[] {-1, 3, 7},
                new int[] {32, 0, 30},
            },
            new int[][] {
                new int[] {-1, 3, 8},
                new int[] {32, 0, 34},
            },
            new int[][] {
                new int[] {-1, 3, 9},
                new int[] {44, 2, -1},
            },
            new int[][] {
                new int[] {-1, 1, 1},
                new int[] {2, 0, 2},
                new int[] {3, 0, 3},
                new int[] {4, 0, 4},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 2},
                new int[] {2, 0, 2},
                new int[] {4, 0, 4},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 4},
                new int[] {4, 0, 4},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 8},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 16},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 32},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 64},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 128},
            },
            new int[][] {
                new int[] {-1, 3, 18},
                new int[] {15, 0, 65},
            },
            new int[][] {
                new int[] {-1, 1, 260},
                new int[] {28, 0, 66},
            },
            new int[][] {
                new int[] {-1, 3, 20},
                new int[] {15, 0, 69},
            },
            new int[][] {
                new int[] {-1, 3, 21},
                new int[] {16, 0, 70},
            },
            new int[][] {
                new int[] {-1, 1, 366},
            },
            new int[][] {
                new int[] {-1, 1, 257},
                new int[] {32, 0, 21},
            },
            new int[][] {
                new int[] {-1, 3, 24},
                new int[] {32, 0, 72},
            },
            new int[][] {
                new int[] {-1, 3, 25},
                new int[] {16, 0, 73},
            },
            new int[][] {
                new int[] {-1, 1, 370},
            },
            new int[][] {
                new int[] {-1, 3, 27},
                new int[] {32, 0, 74},
            },
            new int[][] {
                new int[] {-1, 1, 263},
                new int[] {21, 0, 24},
                new int[] {32, 0, 25},
            },
            new int[][] {
                new int[] {-1, 3, 29},
                new int[] {32, 0, 19},
            },
            new int[][] {
                new int[] {-1, 3, 30},
                new int[] {16, 0, 77},
                new int[] {21, 0, 78},
            },
            new int[][] {
                new int[] {-1, 1, 378},
            },
            new int[][] {
                new int[] {-1, 1, 295},
                new int[] {32, 0, 30},
            },
            new int[][] {
                new int[] {-1, 1, 353},
                new int[] {32, 0, 30},
            },
            new int[][] {
                new int[] {-1, 3, 34},
                new int[] {21, 0, 81},
            },
            new int[][] {
                new int[] {-1, 1, 386},
            },
            new int[][] {
                new int[] {-1, 1, 354},
                new int[] {32, 0, 34},
            },
            new int[][] {
                new int[] {-1, 1, 3},
                new int[] {2, 0, 2},
                new int[] {4, 0, 4},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 5},
                new int[] {4, 0, 4},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 9},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 17},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 33},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 65},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 129},
            },
            new int[][] {
                new int[] {-1, 1, 6},
                new int[] {4, 0, 4},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 10},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 18},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 34},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 66},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 130},
            },
            new int[][] {
                new int[] {-1, 1, 12},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 20},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 36},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 68},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 132},
            },
            new int[][] {
                new int[] {-1, 1, 24},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 40},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 72},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 136},
            },
            new int[][] {
                new int[] {-1, 1, 48},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 80},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 144},
            },
            new int[][] {
                new int[] {-1, 1, 96},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 160},
            },
            new int[][] {
                new int[] {-1, 1, 192},
            },
            new int[][] {
                new int[] {-1, 1, 256},
            },
            new int[][] {
                new int[] {-1, 3, 66},
                new int[] {32, 0, 139},
            },
            new int[][] {
                new int[] {-1, 1, 368},
            },
            new int[][] {
                new int[] {-1, 1, 261},
                new int[] {28, 0, 66},
            },
            new int[][] {
                new int[] {-1, 1, 259},
            },
            new int[][] {
                new int[] {-1, 3, 70},
                new int[] {17, 0, 141},
                new int[] {19, 0, 142},
                new int[] {32, 0, 143},
                new int[] {33, 0, 144},
                new int[] {34, 0, 145},
                new int[] {35, 0, 146},
                new int[] {36, 0, 147},
            },
            new int[][] {
                new int[] {-1, 1, 367},
            },
            new int[][] {
                new int[] {-1, 3, 72},
                new int[] {22, 0, 155},
                new int[] {28, 0, 156},
                new int[] {30, 0, 157},
            },
            new int[][] {
                new int[] {-1, 3, 73},
                new int[] {17, 0, 141},
                new int[] {19, 0, 142},
                new int[] {32, 0, 143},
                new int[] {33, 0, 144},
                new int[] {34, 0, 145},
                new int[] {35, 0, 146},
                new int[] {36, 0, 147},
            },
            new int[][] {
                new int[] {-1, 3, 74},
                new int[] {16, 0, 161},
            },
            new int[][] {
                new int[] {-1, 1, 371},
            },
            new int[][] {
                new int[] {-1, 3, 76},
                new int[] {15, 0, 162},
            },
            new int[][] {
                new int[] {-1, 1, 316},
                new int[] {11, 0, 163},
                new int[] {12, 0, 164},
                new int[] {17, 0, 165},
                new int[] {21, 0, 166},
                new int[] {27, 0, 167},
                new int[] {32, 0, 168},
            },
            new int[][] {
                new int[] {-1, 3, 78},
                new int[] {30, 0, 178},
            },
            new int[][] {
                new int[] {-1, 3, 79},
                new int[] {16, 0, 179},
            },
            new int[][] {
                new int[] {-1, 1, 379},
            },
            new int[][] {
                new int[] {-1, 3, 81},
                new int[] {32, 0, 19},
            },
            new int[][] {
                new int[] {-1, 1, 387},
            },
            new int[][] {
                new int[] {-1, 1, 7},
                new int[] {4, 0, 4},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 11},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 19},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 35},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 67},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 131},
            },
            new int[][] {
                new int[] {-1, 1, 13},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 21},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 37},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 69},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 133},
            },
            new int[][] {
                new int[] {-1, 1, 25},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 41},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 73},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 137},
            },
            new int[][] {
                new int[] {-1, 1, 49},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 81},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 145},
            },
            new int[][] {
                new int[] {-1, 1, 97},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 161},
            },
            new int[][] {
                new int[] {-1, 1, 193},
            },
            new int[][] {
                new int[] {-1, 1, 14},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 22},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 38},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 70},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 134},
            },
            new int[][] {
                new int[] {-1, 1, 26},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 42},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 74},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 138},
            },
            new int[][] {
                new int[] {-1, 1, 50},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 82},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 146},
            },
            new int[][] {
                new int[] {-1, 1, 98},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 162},
            },
            new int[][] {
                new int[] {-1, 1, 194},
            },
            new int[][] {
                new int[] {-1, 1, 28},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 44},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 76},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 140},
            },
            new int[][] {
                new int[] {-1, 1, 52},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 84},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 148},
            },
            new int[][] {
                new int[] {-1, 1, 100},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 164},
            },
            new int[][] {
                new int[] {-1, 1, 196},
            },
            new int[][] {
                new int[] {-1, 1, 56},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 88},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 152},
            },
            new int[][] {
                new int[] {-1, 1, 104},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 168},
            },
            new int[][] {
                new int[] {-1, 1, 200},
            },
            new int[][] {
                new int[] {-1, 1, 112},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 176},
            },
            new int[][] {
                new int[] {-1, 1, 208},
            },
            new int[][] {
                new int[] {-1, 1, 224},
            },
            new int[][] {
                new int[] {-1, 1, 262},
            },
            new int[][] {
                new int[] {-1, 1, 369},
            },
            new int[][] {
                new int[] {-1, 3, 141},
                new int[] {17, 0, 141},
                new int[] {19, 0, 142},
                new int[] {32, 0, 143},
                new int[] {33, 0, 144},
                new int[] {34, 0, 145},
                new int[] {35, 0, 146},
                new int[] {36, 0, 147},
            },
            new int[][] {
                new int[] {-1, 3, 142},
                new int[] {17, 0, 141},
                new int[] {19, 0, 142},
                new int[] {32, 0, 143},
                new int[] {33, 0, 144},
                new int[] {34, 0, 145},
                new int[] {35, 0, 146},
                new int[] {36, 0, 147},
            },
            new int[][] {
                new int[] {-1, 1, 287},
            },
            new int[][] {
                new int[] {-1, 1, 289},
            },
            new int[][] {
                new int[] {-1, 1, 290},
            },
            new int[][] {
                new int[] {-1, 1, 291},
            },
            new int[][] {
                new int[] {-1, 1, 286},
            },
            new int[][] {
                new int[] {-1, 3, 148},
                new int[] {15, 0, 254},
            },
            new int[][] {
                new int[] {-1, 1, 276},
                new int[] {27, 0, 255},
            },
            new int[][] {
                new int[] {-1, 1, 376},
            },
            new int[][] {
                new int[] {-1, 1, 280},
                new int[] {23, 0, 258},
                new int[] {25, 0, 259},
                new int[] {26, 0, 260},
            },
            new int[][] {
                new int[] {-1, 1, 284},
            },
            new int[][] {
                new int[] {-1, 1, 285},
            },
            new int[][] {
                new int[] {-1, 1, 279},
                new int[] {17, 0, 141},
                new int[] {19, 0, 142},
                new int[] {32, 0, 143},
                new int[] {33, 0, 144},
                new int[] {34, 0, 145},
                new int[] {35, 0, 146},
                new int[] {36, 0, 147},
            },
            new int[][] {
                new int[] {-1, 1, 268},
            },
            new int[][] {
                new int[] {-1, 3, 156},
                new int[] {32, 0, 262},
            },
            new int[][] {
                new int[] {-1, 3, 157},
                new int[] {32, 0, 263},
            },
            new int[][] {
                new int[] {-1, 1, 372},
            },
            new int[][] {
                new int[] {-1, 3, 159},
                new int[] {22, 0, 264},
                new int[] {28, 0, 156},
            },
            new int[][] {
                new int[] {-1, 3, 160},
                new int[] {15, 0, 266},
                new int[] {29, 0, 267},
            },
            new int[][] {
                new int[] {-1, 3, 161},
                new int[] {17, 0, 141},
                new int[] {19, 0, 142},
                new int[] {32, 0, 143},
                new int[] {33, 0, 144},
                new int[] {34, 0, 145},
                new int[] {35, 0, 146},
                new int[] {36, 0, 147},
            },
            new int[][] {
                new int[] {-1, 1, 274},
            },
            new int[][] {
                new int[] {-1, 3, 163},
                new int[] {13, 0, 270},
            },
            new int[][] {
                new int[] {-1, 3, 164},
                new int[] {13, 0, 271},
            },
            new int[][] {
                new int[] {-1, 3, 165},
                new int[] {32, 0, 272},
            },
            new int[][] {
                new int[] {-1, 3, 166},
                new int[] {30, 0, 273},
                new int[] {32, 0, 274},
            },
            new int[][] {
                new int[] {-1, 1, 332},
                new int[] {11, 0, 163},
                new int[] {12, 0, 164},
                new int[] {17, 0, 165},
                new int[] {21, 0, 166},
                new int[] {32, 0, 168},
            },
            new int[][] {
                new int[] {-1, 1, 350},
            },
            new int[][] {
                new int[] {-1, 1, 320},
                new int[] {27, 0, 167},
            },
            new int[][] {
                new int[] {-1, 3, 170},
                new int[] {15, 0, 279},
            },
            new int[][] {
                new int[] {-1, 1, 384},
            },
            new int[][] {
                new int[] {-1, 1, 317},
                new int[] {11, 0, 163},
                new int[] {12, 0, 164},
                new int[] {17, 0, 165},
                new int[] {21, 0, 280},
                new int[] {27, 0, 167},
                new int[] {32, 0, 168},
            },
            new int[][] {
                new int[] {-1, 1, 382},
            },
            new int[][] {
                new int[] {-1, 3, 174},
                new int[] {11, 0, 163},
                new int[] {12, 0, 164},
                new int[] {32, 0, 168},
            },
            new int[][] {
                new int[] {-1, 1, 341},
                new int[] {23, 0, 285},
                new int[] {25, 0, 286},
                new int[] {26, 0, 287},
            },
            new int[][] {
                new int[] {-1, 1, 318},
                new int[] {11, 0, 163},
                new int[] {12, 0, 164},
                new int[] {17, 0, 165},
                new int[] {21, 0, 280},
                new int[] {27, 0, 167},
                new int[] {32, 0, 168},
            },
            new int[][] {
                new int[] {-1, 1, 324},
                new int[] {27, 0, 167},
            },
            new int[][] {
                new int[] {-1, 3, 178},
                new int[] {32, 0, 292},
            },
            new int[][] {
                new int[] {-1, 1, 316},
                new int[] {11, 0, 163},
                new int[] {12, 0, 164},
                new int[] {17, 0, 165},
                new int[] {21, 0, 166},
                new int[] {27, 0, 167},
                new int[] {32, 0, 168},
            },
            new int[][] {
                new int[] {-1, 3, 180},
                new int[] {22, 0, 294},
            },
            new int[][] {
                new int[] {-1, 1, 15},
                new int[] {5, 0, 5},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 23},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 39},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 71},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 135},
            },
            new int[][] {
                new int[] {-1, 1, 27},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 43},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 75},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 139},
            },
            new int[][] {
                new int[] {-1, 1, 51},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 83},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 147},
            },
            new int[][] {
                new int[] {-1, 1, 99},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 163},
            },
            new int[][] {
                new int[] {-1, 1, 195},
            },
            new int[][] {
                new int[] {-1, 1, 29},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 45},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 77},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 141},
            },
            new int[][] {
                new int[] {-1, 1, 53},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 85},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 149},
            },
            new int[][] {
                new int[] {-1, 1, 101},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 165},
            },
            new int[][] {
                new int[] {-1, 1, 197},
            },
            new int[][] {
                new int[] {-1, 1, 57},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 89},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 153},
            },
            new int[][] {
                new int[] {-1, 1, 105},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 169},
            },
            new int[][] {
                new int[] {-1, 1, 201},
            },
            new int[][] {
                new int[] {-1, 1, 113},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 177},
            },
            new int[][] {
                new int[] {-1, 1, 209},
            },
            new int[][] {
                new int[] {-1, 1, 225},
            },
            new int[][] {
                new int[] {-1, 1, 30},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 46},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 78},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 142},
            },
            new int[][] {
                new int[] {-1, 1, 54},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 86},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 150},
            },
            new int[][] {
                new int[] {-1, 1, 102},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 166},
            },
            new int[][] {
                new int[] {-1, 1, 198},
            },
            new int[][] {
                new int[] {-1, 1, 58},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 90},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 154},
            },
            new int[][] {
                new int[] {-1, 1, 106},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 170},
            },
            new int[][] {
                new int[] {-1, 1, 202},
            },
            new int[][] {
                new int[] {-1, 1, 114},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 178},
            },
            new int[][] {
                new int[] {-1, 1, 210},
            },
            new int[][] {
                new int[] {-1, 1, 226},
            },
            new int[][] {
                new int[] {-1, 1, 60},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 92},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 156},
            },
            new int[][] {
                new int[] {-1, 1, 108},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 172},
            },
            new int[][] {
                new int[] {-1, 1, 204},
            },
            new int[][] {
                new int[] {-1, 1, 116},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 180},
            },
            new int[][] {
                new int[] {-1, 1, 212},
            },
            new int[][] {
                new int[] {-1, 1, 228},
            },
            new int[][] {
                new int[] {-1, 1, 120},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 184},
            },
            new int[][] {
                new int[] {-1, 1, 216},
            },
            new int[][] {
                new int[] {-1, 1, 232},
            },
            new int[][] {
                new int[] {-1, 1, 240},
            },
            new int[][] {
                new int[] {-1, 3, 251},
                new int[] {23, 0, 351},
                new int[] {24, 0, 352},
            },
            new int[][] {
                new int[] {-1, 1, 284},
                new int[] {14, 0, 353},
            },
            new int[][] {
                new int[] {-1, 3, 253},
                new int[] {20, 0, 354},
            },
            new int[][] {
                new int[] {-1, 1, 258},
            },
            new int[][] {
                new int[] {-1, 3, 255},
                new int[] {17, 0, 141},
                new int[] {19, 0, 142},
                new int[] {32, 0, 143},
                new int[] {33, 0, 144},
                new int[] {34, 0, 145},
                new int[] {35, 0, 146},
                new int[] {36, 0, 147},
            },
            new int[][] {
                new int[] {-1, 1, 374},
            },
            new int[][] {
                new int[] {-1, 1, 277},
                new int[] {27, 0, 255},
            },
            new int[][] {
                new int[] {-1, 1, 283},
            },
            new int[][] {
                new int[] {-1, 1, 282},
            },
            new int[][] {
                new int[] {-1, 1, 281},
            },
            new int[][] {
                new int[] {-1, 1, 377},
            },
            new int[][] {
                new int[] {-1, 1, 272},
                new int[] {30, 0, 357},
            },
            new int[][] {
                new int[] {-1, 3, 263},
                new int[] {22, 0, 358},
                new int[] {28, 0, 156},
            },
            new int[][] {
                new int[] {-1, 1, 269},
            },
            new int[][] {
                new int[] {-1, 1, 373},
            },
            new int[][] {
                new int[] {-1, 1, 264},
            },
            new int[][] {
                new int[] {-1, 3, 267},
                new int[] {17, 0, 141},
                new int[] {19, 0, 142},
                new int[] {32, 0, 143},
                new int[] {33, 0, 144},
                new int[] {34, 0, 145},
                new int[] {35, 0, 146},
                new int[] {36, 0, 147},
            },
            new int[][] {
                new int[] {-1, 3, 268},
                new int[] {15, 0, 361},
            },
            new int[][] {
                new int[] {-1, 3, 269},
                new int[] {15, 0, 362},
                new int[] {29, 0, 267},
            },
            new int[][] {
                new int[] {-1, 3, 270},
                new int[] {32, 0, 364},
            },
            new int[][] {
                new int[] {-1, 3, 271},
                new int[] {32, 0, 365},
            },
            new int[][] {
                new int[] {-1, 3, 272},
                new int[] {18, 0, 366},
            },
            new int[][] {
                new int[] {-1, 3, 273},
                new int[] {9, 0, 367},
                new int[] {10, 0, 368},
                new int[] {17, 0, 369},
                new int[] {32, 0, 370},
            },
            new int[][] {
                new int[] {-1, 3, 274},
                new int[] {22, 0, 373},
            },
            new int[][] {
                new int[] {-1, 1, 336},
            },
            new int[][] {
                new int[] {-1, 1, 333},
                new int[] {11, 0, 163},
                new int[] {12, 0, 164},
                new int[] {17, 0, 165},
                new int[] {21, 0, 280},
                new int[] {32, 0, 168},
            },
            new int[][] {
                new int[] {-1, 1, 334},
                new int[] {11, 0, 163},
                new int[] {12, 0, 164},
                new int[] {17, 0, 165},
                new int[] {21, 0, 280},
                new int[] {32, 0, 168},
            },
            new int[][] {
                new int[] {-1, 1, 328},
                new int[] {27, 0, 167},
            },
            new int[][] {
                new int[] {-1, 1, 296},
            },
            new int[][] {
                new int[] {-1, 3, 280},
                new int[] {30, 0, 273},
            },
            new int[][] {
                new int[] {-1, 1, 321},
                new int[] {27, 0, 167},
            },
            new int[][] {
                new int[] {-1, 1, 319},
                new int[] {11, 0, 163},
                new int[] {12, 0, 164},
                new int[] {17, 0, 165},
                new int[] {21, 0, 280},
                new int[] {27, 0, 167},
                new int[] {32, 0, 168},
            },
            new int[][] {
                new int[] {-1, 1, 325},
                new int[] {27, 0, 167},
            },
            new int[][] {
                new int[] {-1, 1, 342},
                new int[] {23, 0, 380},
                new int[] {25, 0, 381},
                new int[] {26, 0, 382},
            },
            new int[][] {
                new int[] {-1, 1, 347},
            },
            new int[][] {
                new int[] {-1, 1, 345},
            },
            new int[][] {
                new int[] {-1, 1, 343},
            },
            new int[][] {
                new int[] {-1, 1, 322},
                new int[] {27, 0, 167},
            },
            new int[][] {
                new int[] {-1, 1, 383},
            },
            new int[][] {
                new int[] {-1, 1, 326},
                new int[] {27, 0, 167},
            },
            new int[][] {
                new int[] {-1, 1, 385},
            },
            new int[][] {
                new int[] {-1, 3, 292},
                new int[] {22, 0, 384},
                new int[] {23, 0, 385},
                new int[] {25, 0, 386},
                new int[] {26, 0, 387},
            },
            new int[][] {
                new int[] {-1, 3, 293},
                new int[] {15, 0, 388},
            },
            new int[][] {
                new int[] {-1, 3, 294},
                new int[] {37, 0, 389},
                new int[] {38, 0, 390},
                new int[] {39, 0, 391},
                new int[] {40, 0, 392},
            },
            new int[][] {
                new int[] {-1, 1, 31},
                new int[] {6, 0, 6},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 47},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 79},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 143},
            },
            new int[][] {
                new int[] {-1, 1, 55},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 87},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 151},
            },
            new int[][] {
                new int[] {-1, 1, 103},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 167},
            },
            new int[][] {
                new int[] {-1, 1, 199},
            },
            new int[][] {
                new int[] {-1, 1, 59},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 91},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 155},
            },
            new int[][] {
                new int[] {-1, 1, 107},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 171},
            },
            new int[][] {
                new int[] {-1, 1, 203},
            },
            new int[][] {
                new int[] {-1, 1, 115},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 179},
            },
            new int[][] {
                new int[] {-1, 1, 211},
            },
            new int[][] {
                new int[] {-1, 1, 227},
            },
            new int[][] {
                new int[] {-1, 1, 61},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 93},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 157},
            },
            new int[][] {
                new int[] {-1, 1, 109},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 173},
            },
            new int[][] {
                new int[] {-1, 1, 205},
            },
            new int[][] {
                new int[] {-1, 1, 117},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 181},
            },
            new int[][] {
                new int[] {-1, 1, 213},
            },
            new int[][] {
                new int[] {-1, 1, 229},
            },
            new int[][] {
                new int[] {-1, 1, 121},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 185},
            },
            new int[][] {
                new int[] {-1, 1, 217},
            },
            new int[][] {
                new int[] {-1, 1, 233},
            },
            new int[][] {
                new int[] {-1, 1, 241},
            },
            new int[][] {
                new int[] {-1, 1, 62},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 94},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 158},
            },
            new int[][] {
                new int[] {-1, 1, 110},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 174},
            },
            new int[][] {
                new int[] {-1, 1, 206},
            },
            new int[][] {
                new int[] {-1, 1, 118},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 182},
            },
            new int[][] {
                new int[] {-1, 1, 214},
            },
            new int[][] {
                new int[] {-1, 1, 230},
            },
            new int[][] {
                new int[] {-1, 1, 122},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 186},
            },
            new int[][] {
                new int[] {-1, 1, 218},
            },
            new int[][] {
                new int[] {-1, 1, 234},
            },
            new int[][] {
                new int[] {-1, 1, 242},
            },
            new int[][] {
                new int[] {-1, 1, 124},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 188},
            },
            new int[][] {
                new int[] {-1, 1, 220},
            },
            new int[][] {
                new int[] {-1, 1, 236},
            },
            new int[][] {
                new int[] {-1, 1, 244},
            },
            new int[][] {
                new int[] {-1, 1, 248},
            },
            new int[][] {
                new int[] {-1, 3, 351},
                new int[] {17, 0, 141},
                new int[] {19, 0, 142},
                new int[] {32, 0, 143},
                new int[] {33, 0, 144},
                new int[] {34, 0, 145},
                new int[] {35, 0, 146},
                new int[] {36, 0, 147},
            },
            new int[][] {
                new int[] {-1, 3, 352},
                new int[] {17, 0, 141},
                new int[] {19, 0, 142},
                new int[] {32, 0, 143},
                new int[] {33, 0, 144},
                new int[] {34, 0, 145},
                new int[] {35, 0, 146},
                new int[] {36, 0, 147},
            },
            new int[][] {
                new int[] {-1, 3, 353},
                new int[] {33, 0, 144},
                new int[] {34, 0, 145},
                new int[] {35, 0, 146},
            },
            new int[][] {
                new int[] {-1, 1, 288},
            },
            new int[][] {
                new int[] {-1, 1, 278},
            },
            new int[][] {
                new int[] {-1, 1, 375},
            },
            new int[][] {
                new int[] {-1, 3, 357},
                new int[] {32, 0, 426},
            },
            new int[][] {
                new int[] {-1, 1, 270},
            },
            new int[][] {
                new int[] {-1, 3, 359},
                new int[] {22, 0, 427},
                new int[] {28, 0, 156},
            },
            new int[][] {
                new int[] {-1, 1, 275},
            },
            new int[][] {
                new int[] {-1, 1, 266},
            },
            new int[][] {
                new int[] {-1, 1, 265},
            },
            new int[][] {
                new int[] {-1, 3, 363},
                new int[] {15, 0, 428},
            },
            new int[][] {
                new int[] {-1, 1, 351},
            },
            new int[][] {
                new int[] {-1, 1, 352},
            },
            new int[][] {
                new int[] {-1, 3, 366},
                new int[] {31, 0, 429},
            },
            new int[][] {
                new int[] {-1, 3, 367},
                new int[] {32, 0, 430},
            },
            new int[][] {
                new int[] {-1, 1, 308},
            },
            new int[][] {
                new int[] {-1, 3, 369},
                new int[] {9, 0, 367},
                new int[] {10, 0, 368},
                new int[] {17, 0, 369},
                new int[] {18, 0, 431},
                new int[] {32, 0, 370},
            },
            new int[][] {
                new int[] {-1, 1, 314},
                new int[] {13, 0, 434},
            },
            new int[][] {
                new int[] {-1, 3, 371},
                new int[] {22, 0, 435},
            },
            new int[][] {
                new int[] {-1, 1, 303},
            },
            new int[][] {
                new int[] {-1, 1, 340},
            },
            new int[][] {
                new int[] {-1, 1, 337},
            },
            new int[][] {
                new int[] {-1, 1, 335},
                new int[] {11, 0, 163},
                new int[] {12, 0, 164},
                new int[] {17, 0, 165},
                new int[] {21, 0, 280},
                new int[] {32, 0, 168},
            },
            new int[][] {
                new int[] {-1, 1, 338},
            },
            new int[][] {
                new int[] {-1, 1, 329},
                new int[] {27, 0, 167},
            },
            new int[][] {
                new int[] {-1, 1, 323},
                new int[] {27, 0, 167},
            },
            new int[][] {
                new int[] {-1, 1, 327},
                new int[] {27, 0, 167},
            },
            new int[][] {
                new int[] {-1, 1, 348},
            },
            new int[][] {
                new int[] {-1, 1, 346},
            },
            new int[][] {
                new int[] {-1, 1, 344},
            },
            new int[][] {
                new int[] {-1, 1, 330},
                new int[] {27, 0, 167},
            },
            new int[][] {
                new int[] {-1, 1, 298},
            },
            new int[][] {
                new int[] {-1, 3, 385},
                new int[] {22, 0, 438},
            },
            new int[][] {
                new int[] {-1, 3, 386},
                new int[] {22, 0, 439},
            },
            new int[][] {
                new int[] {-1, 3, 387},
                new int[] {22, 0, 440},
            },
            new int[][] {
                new int[] {-1, 1, 297},
            },
            new int[][] {
                new int[] {-1, 1, 359},
            },
            new int[][] {
                new int[] {-1, 1, 360},
            },
            new int[][] {
                new int[] {-1, 3, 391},
                new int[] {31, 0, 441},
            },
            new int[][] {
                new int[] {-1, 3, 392},
                new int[] {31, 0, 442},
            },
            new int[][] {
                new int[] {-1, 3, 393},
                new int[] {15, 0, 443},
            },
            new int[][] {
                new int[] {-1, 1, 356},
                new int[] {28, 0, 444},
            },
            new int[][] {
                new int[] {-1, 1, 63},
                new int[] {7, 0, 7},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 95},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 159},
            },
            new int[][] {
                new int[] {-1, 1, 111},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 175},
            },
            new int[][] {
                new int[] {-1, 1, 207},
            },
            new int[][] {
                new int[] {-1, 1, 119},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 183},
            },
            new int[][] {
                new int[] {-1, 1, 215},
            },
            new int[][] {
                new int[] {-1, 1, 231},
            },
            new int[][] {
                new int[] {-1, 1, 123},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 187},
            },
            new int[][] {
                new int[] {-1, 1, 219},
            },
            new int[][] {
                new int[] {-1, 1, 235},
            },
            new int[][] {
                new int[] {-1, 1, 243},
            },
            new int[][] {
                new int[] {-1, 1, 125},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 189},
            },
            new int[][] {
                new int[] {-1, 1, 221},
            },
            new int[][] {
                new int[] {-1, 1, 237},
            },
            new int[][] {
                new int[] {-1, 1, 245},
            },
            new int[][] {
                new int[] {-1, 1, 249},
            },
            new int[][] {
                new int[] {-1, 1, 126},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 190},
            },
            new int[][] {
                new int[] {-1, 1, 222},
            },
            new int[][] {
                new int[] {-1, 1, 238},
            },
            new int[][] {
                new int[] {-1, 1, 246},
            },
            new int[][] {
                new int[] {-1, 1, 250},
            },
            new int[][] {
                new int[] {-1, 1, 252},
            },
            new int[][] {
                new int[] {-1, 3, 423},
                new int[] {18, 0, 455},
            },
            new int[][] {
                new int[] {-1, 3, 424},
                new int[] {18, 0, 456},
            },
            new int[][] {
                new int[] {-1, 3, 425},
                new int[] {18, 0, 457},
            },
            new int[][] {
                new int[] {-1, 1, 273},
            },
            new int[][] {
                new int[] {-1, 1, 271},
            },
            new int[][] {
                new int[] {-1, 1, 267},
            },
            new int[][] {
                new int[] {-1, 1, 349},
            },
            new int[][] {
                new int[] {-1, 3, 430},
                new int[] {13, 0, 458},
                new int[] {19, 0, 459},
            },
            new int[][] {
                new int[] {-1, 1, 309},
            },
            new int[][] {
                new int[] {-1, 1, 311},
                new int[] {28, 0, 460},
            },
            new int[][] {
                new int[] {-1, 3, 433},
                new int[] {18, 0, 463},
            },
            new int[][] {
                new int[] {-1, 3, 434},
                new int[] {32, 0, 464},
            },
            new int[][] {
                new int[] {-1, 1, 302},
            },
            new int[][] {
                new int[] {-1, 1, 339},
            },
            new int[][] {
                new int[] {-1, 1, 331},
                new int[] {27, 0, 167},
            },
            new int[][] {
                new int[] {-1, 1, 300},
            },
            new int[][] {
                new int[] {-1, 1, 301},
            },
            new int[][] {
                new int[] {-1, 1, 299},
            },
            new int[][] {
                new int[] {-1, 3, 441},
                new int[] {41, 0, 465},
                new int[] {42, 0, 466},
                new int[] {43, 0, 467},
            },
            new int[][] {
                new int[] {-1, 3, 442},
                new int[] {41, 0, 465},
                new int[] {42, 0, 466},
                new int[] {43, 0, 467},
            },
            new int[][] {
                new int[] {-1, 1, 355},
            },
            new int[][] {
                new int[] {-1, 3, 444},
                new int[] {37, 0, 389},
                new int[] {38, 0, 390},
                new int[] {39, 0, 391},
                new int[] {40, 0, 392},
            },
            new int[][] {
                new int[] {-1, 1, 388},
            },
            new int[][] {
                new int[] {-1, 1, 357},
                new int[] {28, 0, 444},
            },
            new int[][] {
                new int[] {-1, 1, 127},
                new int[] {8, 0, 8},
            },
            new int[][] {
                new int[] {-1, 1, 191},
            },
            new int[][] {
                new int[] {-1, 1, 223},
            },
            new int[][] {
                new int[] {-1, 1, 239},
            },
            new int[][] {
                new int[] {-1, 1, 247},
            },
            new int[][] {
                new int[] {-1, 1, 251},
            },
            new int[][] {
                new int[] {-1, 1, 253},
            },
            new int[][] {
                new int[] {-1, 1, 254},
            },
            new int[][] {
                new int[] {-1, 1, 292},
            },
            new int[][] {
                new int[] {-1, 1, 293},
            },
            new int[][] {
                new int[] {-1, 1, 294},
            },
            new int[][] {
                new int[] {-1, 3, 458},
                new int[] {32, 0, 473},
            },
            new int[][] {
                new int[] {-1, 3, 459},
                new int[] {9, 0, 367},
                new int[] {10, 0, 368},
                new int[] {17, 0, 369},
                new int[] {20, 0, 474},
                new int[] {32, 0, 370},
            },
            new int[][] {
                new int[] {-1, 3, 460},
                new int[] {9, 0, 367},
                new int[] {10, 0, 368},
                new int[] {17, 0, 369},
                new int[] {32, 0, 370},
            },
            new int[][] {
                new int[] {-1, 1, 380},
            },
            new int[][] {
                new int[] {-1, 1, 312},
                new int[] {28, 0, 460},
            },
            new int[][] {
                new int[] {-1, 1, 310},
            },
            new int[][] {
                new int[] {-1, 1, 315},
            },
            new int[][] {
                new int[] {-1, 3, 465},
                new int[] {19, 0, 478},
            },
            new int[][] {
                new int[] {-1, 3, 466},
                new int[] {19, 0, 479},
            },
            new int[][] {
                new int[] {-1, 1, 365},
            },
            new int[][] {
                new int[] {-1, 1, 361},
            },
            new int[][] {
                new int[] {-1, 1, 362},
            },
            new int[][] {
                new int[] {-1, 1, 358},
            },
            new int[][] {
                new int[] {-1, 1, 389},
            },
            new int[][] {
                new int[] {-1, 1, 255},
            },
            new int[][] {
                new int[] {-1, 3, 473},
                new int[] {19, 0, 480},
            },
            new int[][] {
                new int[] {-1, 1, 304},
            },
            new int[][] {
                new int[] {-1, 3, 475},
                new int[] {20, 0, 481},
            },
            new int[][] {
                new int[] {-1, 1, 313},
            },
            new int[][] {
                new int[] {-1, 1, 381},
            },
            new int[][] {
                new int[] {-1, 3, 478},
                new int[] {34, 0, 482},
            },
            new int[][] {
                new int[] {-1, 3, 479},
                new int[] {34, 0, 483},
            },
            new int[][] {
                new int[] {-1, 3, 480},
                new int[] {9, 0, 367},
                new int[] {10, 0, 368},
                new int[] {17, 0, 369},
                new int[] {20, 0, 484},
                new int[] {32, 0, 370},
            },
            new int[][] {
                new int[] {-1, 1, 305},
            },
            new int[][] {
                new int[] {-1, 3, 482},
                new int[] {28, 0, 486},
            },
            new int[][] {
                new int[] {-1, 3, 483},
                new int[] {28, 0, 487},
            },
            new int[][] {
                new int[] {-1, 1, 306},
            },
            new int[][] {
                new int[] {-1, 3, 485},
                new int[] {20, 0, 488},
            },
            new int[][] {
                new int[] {-1, 3, 486},
                new int[] {34, 0, 489},
            },
            new int[][] {
                new int[] {-1, 3, 487},
                new int[] {34, 0, 490},
            },
            new int[][] {
                new int[] {-1, 1, 307},
            },
            new int[][] {
                new int[] {-1, 3, 489},
                new int[] {28, 0, 491},
            },
            new int[][] {
                new int[] {-1, 3, 490},
                new int[] {28, 0, 492},
            },
            new int[][] {
                new int[] {-1, 3, 491},
                new int[] {34, 0, 493},
            },
            new int[][] {
                new int[] {-1, 3, 492},
                new int[] {34, 0, 494},
            },
            new int[][] {
                new int[] {-1, 3, 493},
                new int[] {20, 0, 495},
            },
            new int[][] {
                new int[] {-1, 3, 494},
                new int[] {20, 0, 496},
            },
            new int[][] {
                new int[] {-1, 1, 363},
            },
            new int[][] {
                new int[] {-1, 1, 364},
            },
        };
        private static int[][][] gotoTable = {
            new int[][] {
                new int[] {-1, 9},
            },
            new int[][] {
                new int[] {-1, 10},
            },
            new int[][] {
                new int[] {-1, 11},
                new int[] {10, 37},
            },
            new int[][] {
                new int[] {-1, 22},
                new int[] {23, 71},
            },
            new int[][] {
                new int[] {-1, 12},
                new int[] {10, 38},
                new int[] {11, 44},
                new int[] {37, 83},
            },
            new int[][] {
                new int[] {-1, 20},
                new int[] {29, 76},
                new int[] {81, 180},
            },
            new int[][] {
                new int[] {-1, 67},
                new int[] {68, 140},
            },
            new int[][] {
                new int[] {-1, 13},
                new int[] {10, 39},
                new int[] {11, 45},
                new int[] {12, 50},
                new int[] {37, 84},
                new int[] {38, 89},
                new int[] {44, 104},
                new int[] {83, 181},
            },
            new int[][] {
                new int[] {-1, 26},
                new int[] {28, 75},
            },
            new int[][] {
                new int[] {-1, 27},
            },
            new int[][] {
                new int[] {-1, 158},
                new int[] {159, 265},
                new int[] {359, 265},
            },
            new int[][] {
                new int[] {-1, 14},
                new int[] {10, 40},
                new int[] {11, 46},
                new int[] {12, 51},
                new int[] {13, 55},
                new int[] {37, 85},
                new int[] {38, 90},
                new int[] {39, 94},
                new int[] {44, 105},
                new int[] {45, 109},
                new int[] {50, 119},
                new int[] {83, 182},
                new int[] {84, 186},
                new int[] {89, 196},
                new int[] {104, 216},
                new int[] {181, 295},
            },
            new int[][] {
                new int[] {-1, 268},
                new int[] {269, 363},
            },
            new int[][] {
                new int[] {-1, 148},
                new int[] {73, 160},
                new int[] {142, 253},
                new int[] {161, 269},
                new int[] {267, 360},
            },
            new int[][] {
                new int[] {-1, 256},
                new int[] {257, 356},
            },
            new int[][] {
                new int[] {-1, 149},
                new int[] {255, 355},
            },
            new int[][] {
                new int[] {-1, 150},
                new int[] {154, 261},
            },
            new int[][] {
                new int[] {-1, 151},
                new int[] {141, 251},
                new int[] {351, 423},
                new int[] {352, 424},
            },
            new int[][] {
                new int[] {-1, 152},
                new int[] {141, 252},
                new int[] {353, 425},
            },
            new int[][] {
                new int[] {-1, 153},
            },
            new int[][] {
                new int[] {-1, 15},
                new int[] {10, 41},
                new int[] {11, 47},
                new int[] {12, 52},
                new int[] {13, 56},
                new int[] {14, 59},
                new int[] {37, 86},
                new int[] {38, 91},
                new int[] {39, 95},
                new int[] {40, 98},
                new int[] {44, 106},
                new int[] {45, 110},
                new int[] {46, 113},
                new int[] {50, 120},
                new int[] {51, 123},
                new int[] {55, 129},
                new int[] {83, 183},
                new int[] {84, 187},
                new int[] {85, 190},
                new int[] {89, 197},
                new int[] {90, 200},
                new int[] {94, 206},
                new int[] {104, 217},
                new int[] {105, 220},
                new int[] {109, 226},
                new int[] {119, 236},
                new int[] {181, 296},
                new int[] {182, 299},
                new int[] {186, 305},
                new int[] {196, 315},
                new int[] {216, 330},
                new int[] {295, 395},
            },
            new int[][] {
                new int[] {-1, 31},
                new int[] {32, 80},
                new int[] {33, 80},
            },
            new int[][] {
                new int[] {-1, 79},
            },
            new int[][] {
                new int[] {-1, 169},
                new int[] {167, 275},
                new int[] {172, 281},
                new int[] {176, 288},
                new int[] {276, 374},
                new int[] {277, 376},
                new int[] {282, 378},
                new int[] {375, 436},
            },
            new int[][] {
                new int[] {-1, 432},
                new int[] {273, 371},
                new int[] {460, 476},
            },
            new int[][] {
                new int[] {-1, 433},
                new int[] {459, 475},
                new int[] {480, 485},
            },
            new int[][] {
                new int[] {-1, 461},
                new int[] {462, 477},
            },
            new int[][] {
                new int[] {-1, 372},
            },
            new int[][] {
                new int[] {-1, 170},
                new int[] {179, 293},
            },
            new int[][] {
                new int[] {-1, 171},
                new int[] {177, 291},
                new int[] {278, 291},
                new int[] {283, 291},
                new int[] {290, 291},
                new int[] {377, 291},
                new int[] {379, 291},
                new int[] {383, 291},
                new int[] {437, 291},
            },
            new int[][] {
                new int[] {-1, 172},
                new int[] {167, 276},
            },
            new int[][] {
                new int[] {-1, 173},
                new int[] {176, 289},
                new int[] {277, 289},
                new int[] {282, 289},
                new int[] {375, 289},
            },
            new int[][] {
                new int[] {-1, 174},
            },
            new int[][] {
                new int[] {-1, 175},
                new int[] {174, 284},
            },
            new int[][] {
                new int[] {-1, 16},
                new int[] {10, 42},
                new int[] {11, 48},
                new int[] {12, 53},
                new int[] {13, 57},
                new int[] {14, 60},
                new int[] {15, 62},
                new int[] {37, 87},
                new int[] {38, 92},
                new int[] {39, 96},
                new int[] {40, 99},
                new int[] {41, 101},
                new int[] {44, 107},
                new int[] {45, 111},
                new int[] {46, 114},
                new int[] {47, 116},
                new int[] {50, 121},
                new int[] {51, 124},
                new int[] {52, 126},
                new int[] {55, 130},
                new int[] {56, 132},
                new int[] {59, 135},
                new int[] {83, 184},
                new int[] {84, 188},
                new int[] {85, 191},
                new int[] {86, 193},
                new int[] {89, 198},
                new int[] {90, 201},
                new int[] {91, 203},
                new int[] {94, 207},
                new int[] {95, 209},
                new int[] {98, 212},
                new int[] {104, 218},
                new int[] {105, 221},
                new int[] {106, 223},
                new int[] {109, 227},
                new int[] {110, 229},
                new int[] {113, 232},
                new int[] {119, 237},
                new int[] {120, 239},
                new int[] {123, 242},
                new int[] {129, 246},
                new int[] {181, 297},
                new int[] {182, 300},
                new int[] {183, 302},
                new int[] {186, 306},
                new int[] {187, 308},
                new int[] {190, 311},
                new int[] {196, 316},
                new int[] {197, 318},
                new int[] {200, 321},
                new int[] {206, 325},
                new int[] {216, 331},
                new int[] {217, 333},
                new int[] {220, 336},
                new int[] {226, 340},
                new int[] {236, 345},
                new int[] {295, 396},
                new int[] {296, 398},
                new int[] {299, 401},
                new int[] {305, 405},
                new int[] {315, 410},
                new int[] {330, 416},
                new int[] {395, 447},
            },
            new int[][] {
                new int[] {-1, 17},
                new int[] {10, 43},
                new int[] {11, 49},
                new int[] {12, 54},
                new int[] {13, 58},
                new int[] {14, 61},
                new int[] {15, 63},
                new int[] {16, 64},
                new int[] {37, 88},
                new int[] {38, 93},
                new int[] {39, 97},
                new int[] {40, 100},
                new int[] {41, 102},
                new int[] {42, 103},
                new int[] {44, 108},
                new int[] {45, 112},
                new int[] {46, 115},
                new int[] {47, 117},
                new int[] {48, 118},
                new int[] {50, 122},
                new int[] {51, 125},
                new int[] {52, 127},
                new int[] {53, 128},
                new int[] {55, 131},
                new int[] {56, 133},
                new int[] {57, 134},
                new int[] {59, 136},
                new int[] {60, 137},
                new int[] {62, 138},
                new int[] {83, 185},
                new int[] {84, 189},
                new int[] {85, 192},
                new int[] {86, 194},
                new int[] {87, 195},
                new int[] {89, 199},
                new int[] {90, 202},
                new int[] {91, 204},
                new int[] {92, 205},
                new int[] {94, 208},
                new int[] {95, 210},
                new int[] {96, 211},
                new int[] {98, 213},
                new int[] {99, 214},
                new int[] {101, 215},
                new int[] {104, 219},
                new int[] {105, 222},
                new int[] {106, 224},
                new int[] {107, 225},
                new int[] {109, 228},
                new int[] {110, 230},
                new int[] {111, 231},
                new int[] {113, 233},
                new int[] {114, 234},
                new int[] {116, 235},
                new int[] {119, 238},
                new int[] {120, 240},
                new int[] {121, 241},
                new int[] {123, 243},
                new int[] {124, 244},
                new int[] {126, 245},
                new int[] {129, 247},
                new int[] {130, 248},
                new int[] {132, 249},
                new int[] {135, 250},
                new int[] {181, 298},
                new int[] {182, 301},
                new int[] {183, 303},
                new int[] {184, 304},
                new int[] {186, 307},
                new int[] {187, 309},
                new int[] {188, 310},
                new int[] {190, 312},
                new int[] {191, 313},
                new int[] {193, 314},
                new int[] {196, 317},
                new int[] {197, 319},
                new int[] {198, 320},
                new int[] {200, 322},
                new int[] {201, 323},
                new int[] {203, 324},
                new int[] {206, 326},
                new int[] {207, 327},
                new int[] {209, 328},
                new int[] {212, 329},
                new int[] {216, 332},
                new int[] {217, 334},
                new int[] {218, 335},
                new int[] {220, 337},
                new int[] {221, 338},
                new int[] {223, 339},
                new int[] {226, 341},
                new int[] {227, 342},
                new int[] {229, 343},
                new int[] {232, 344},
                new int[] {236, 346},
                new int[] {237, 347},
                new int[] {239, 348},
                new int[] {242, 349},
                new int[] {246, 350},
                new int[] {295, 397},
                new int[] {296, 399},
                new int[] {297, 400},
                new int[] {299, 402},
                new int[] {300, 403},
                new int[] {302, 404},
                new int[] {305, 406},
                new int[] {306, 407},
                new int[] {308, 408},
                new int[] {311, 409},
                new int[] {315, 411},
                new int[] {316, 412},
                new int[] {318, 413},
                new int[] {321, 414},
                new int[] {325, 415},
                new int[] {330, 417},
                new int[] {331, 418},
                new int[] {333, 419},
                new int[] {336, 420},
                new int[] {340, 421},
                new int[] {345, 422},
                new int[] {395, 448},
                new int[] {396, 449},
                new int[] {398, 450},
                new int[] {401, 451},
                new int[] {405, 452},
                new int[] {410, 453},
                new int[] {416, 454},
                new int[] {447, 472},
            },
            new int[][] {
                new int[] {-1, 35},
                new int[] {36, 82},
            },
            new int[][] {
                new int[] {-1, 393},
            },
            new int[][] {
                new int[] {-1, 445},
                new int[] {446, 471},
            },
            new int[][] {
                new int[] {-1, 394},
                new int[] {444, 470},
            },
            new int[][] {
                new int[] {-1, 468},
                new int[] {442, 469},
            },
            new int[][] {
                new int[] {-1, 23},
            },
            new int[][] {
                new int[] {-1, 68},
            },
            new int[][] {
                new int[] {-1, 28},
            },
            new int[][] {
                new int[] {-1, 159},
                new int[] {263, 359},
            },
            new int[][] {
                new int[] {-1, 257},
            },
            new int[][] {
                new int[] {-1, 154},
            },
            new int[][] {
                new int[] {-1, 32},
                new int[] {7, 33},
            },
            new int[][] {
                new int[] {-1, 462},
            },
            new int[][] {
                new int[] {-1, 176},
                new int[] {167, 277},
                new int[] {172, 282},
                new int[] {276, 375},
            },
            new int[][] {
                new int[] {-1, 177},
                new int[] {169, 278},
                new int[] {172, 283},
                new int[] {176, 290},
                new int[] {281, 377},
                new int[] {282, 379},
                new int[] {288, 383},
                new int[] {378, 437},
            },
            new int[][] {
                new int[] {-1, 36},
            },
            new int[][] {
                new int[] {-1, 446},
            },
        };
        private static string[] errorMessages = {
            "expecting: packagetoken, 'States', 'Helpers', 'Tokens', 'Ignored', 'Productions', asttoken, 'Token Syntax Highlight', EOF",
            "expecting: packagename",
            "expecting: identifier",
            "expecting: '{', identifier",
            "expecting: 'Tokens'",
            "expecting: EOF",
            "expecting: 'States', 'Helpers', 'Tokens', 'Ignored', 'Productions', asttoken, 'Token Syntax Highlight', EOF",
            "expecting: 'States', 'Tokens', 'Ignored', 'Productions', asttoken, 'Token Syntax Highlight', EOF",
            "expecting: 'Tokens', 'Ignored', 'Productions', asttoken, 'Token Syntax Highlight', EOF",
            "expecting: 'Ignored', 'Productions', asttoken, 'Token Syntax Highlight', EOF",
            "expecting: 'Productions', asttoken, 'Token Syntax Highlight', EOF",
            "expecting: asttoken, 'Token Syntax Highlight', EOF",
            "expecting: 'Token Syntax Highlight', EOF",
            "expecting: ';'",
            "expecting: ';', '}', ','",
            "expecting: '='",
            "expecting: 'States', 'Tokens', 'Ignored', 'Productions', asttoken, 'Token Syntax Highlight', identifier, EOF",
            "expecting: 'Ignored', 'Productions', asttoken, 'Token Syntax Highlight', '{', identifier, EOF",
            "expecting: '=', '{'",
            "expecting: asttoken, 'Token Syntax Highlight', identifier, EOF",
            "expecting: 'Token Syntax Highlight', identifier, EOF",
            "expecting: '{'",
            "expecting: identifier, EOF",
            "expecting: '[', '(', identifier, character, dec char, hex char, string",
            "expecting: '}', ',', '->'",
            "expecting: 'T', 'P', ';', '[', '{', '|', identifier",
            "expecting: '->'",
            "expecting: ';', '[', ']', '(', ')', '+', '-', '?', '*', '|', '/', identifier, character, dec char, hex char, string",
            "expecting: '..', ';', '[', ']', '(', ')', '+', '-', '?', '*', '|', '/', identifier, character, dec char, hex char, string",
            "expecting: ';', ')', '|', '/'",
            "expecting: ';', '[', '(', ')', '|', '/', identifier, character, dec char, hex char, string",
            "expecting: ';', '[', '(', ')', '+', '?', '*', '|', '/', identifier, character, dec char, hex char, string",
            "expecting: ';', '[', ']', '(', ')', '+', '?', '*', '|', '/', identifier, character, dec char, hex char, string",
            "expecting: '}', ','",
            "expecting: ';', '/'",
            "expecting: '.'",
            "expecting: '->', identifier",
            "expecting: 'T', 'P', ';', '[', '{', '+', '?', '*', '|', identifier",
            "expecting: ';', '|'",
            "expecting: 'T', 'P', identifier",
            "expecting: '}'",
            "expecting: '+', '-'",
            "expecting: '..', '+', '-'",
            "expecting: ')'",
            "expecting: ']'",
            "expecting: 'New', 'Null', '[', identifier",
            "expecting: '}', '+', '?', '*'",
            "expecting: 'italic', 'bold', 'text', 'background'",
            "expecting: character, dec char, hex char",
            "expecting: ':'",
            "expecting: ']', ')', '}', ','",
            "expecting: 'New', 'Null', '[', ']', identifier",
            "expecting: '.', ']', ')', '}', ','",
            "expecting: ';', ','",
            "expecting: '.', '('",
            "expecting: ']', ')', ','",
            "expecting: 'rgb', hsv, hex color",
            "expecting: 'New', 'Null', '[', ')', identifier",
            "expecting: '('",
            "expecting: dec char",
            "expecting: ','",
        };
        private static int[] errors = {
            0, 1, 2, 2, 3, 4, 2, 2, 2, 5, 6, 7, 8, 9, 10, 11,
            12, 5, 13, 14, 13, 15, 16, 16, 2, 15, 17, 2, 17, 2, 18, 19,
            19, 20, 21, 22, 22, 7, 8, 9, 10, 11, 12, 5, 8, 9, 10, 11,
            12, 5, 9, 10, 11, 12, 5, 10, 11, 12, 5, 11, 12, 5, 12, 5,
            5, 6, 2, 14, 14, 8, 23, 16, 24, 23, 15, 17, 13, 25, 26, 15,
            19, 2, 22, 8, 9, 10, 11, 12, 5, 9, 10, 11, 12, 5, 10, 11,
            12, 5, 11, 12, 5, 12, 5, 5, 9, 10, 11, 12, 5, 10, 11, 12,
            5, 11, 12, 5, 12, 5, 5, 10, 11, 12, 5, 11, 12, 5, 12, 5,
            5, 11, 12, 5, 12, 5, 5, 12, 5, 5, 5, 14, 14, 23, 23, 27,
            28, 28, 28, 27, 13, 29, 30, 31, 32, 27, 30, 2, 2, 2, 33, 33,
            34, 23, 10, 35, 35, 2, 36, 25, 37, 38, 13, 38, 25, 25, 39, 37,
            25, 38, 2, 25, 40, 9, 10, 11, 12, 5, 10, 11, 12, 5, 11, 12,
            5, 12, 5, 5, 10, 11, 12, 5, 11, 12, 5, 12, 5, 5, 11, 12,
            5, 12, 5, 5, 12, 5, 5, 5, 10, 11, 12, 5, 11, 12, 5, 12,
            5, 5, 11, 12, 5, 12, 5, 5, 12, 5, 5, 5, 11, 12, 5, 12,
            5, 5, 12, 5, 5, 5, 12, 5, 5, 5, 5, 41, 42, 43, 16, 23,
            29, 29, 30, 30, 30, 30, 24, 33, 2, 33, 17, 23, 13, 34, 2, 2,
            44, 45, 40, 38, 25, 25, 38, 19, 26, 38, 25, 38, 37, 25, 25, 25,
            38, 25, 38, 38, 46, 13, 47, 10, 11, 12, 5, 11, 12, 5, 12, 5,
            5, 11, 12, 5, 12, 5, 5, 12, 5, 5, 5, 11, 12, 5, 12, 5,
            5, 12, 5, 5, 5, 12, 5, 5, 5, 5, 11, 12, 5, 12, 5, 5,
            12, 5, 5, 5, 12, 5, 5, 5, 5, 12, 5, 5, 5, 5, 5, 23,
            23, 48, 27, 29, 29, 2, 2, 33, 13, 17, 17, 13, 37, 37, 49, 2,
            50, 51, 52, 40, 50, 25, 38, 25, 38, 38, 38, 38, 25, 25, 25, 38,
            15, 40, 40, 40, 19, 53, 53, 49, 49, 13, 53, 11, 12, 5, 12, 5,
            5, 12, 5, 5, 5, 12, 5, 5, 5, 5, 12, 5, 5, 5, 5, 5,
            12, 5, 5, 5, 5, 5, 5, 44, 44, 44, 33, 2, 17, 39, 54, 50,
            55, 44, 2, 38, 38, 38, 15, 15, 15, 56, 56, 22, 47, 53, 53, 12,
            5, 5, 5, 5, 5, 5, 5, 27, 27, 27, 2, 57, 45, 55, 55, 50,
            50, 58, 58, 53, 53, 53, 53, 53, 5, 58, 50, 43, 55, 55, 59, 59,
            57, 50, 60, 60, 50, 43, 59, 59, 50, 60, 60, 59, 59, 43, 43, 53,
            53,
        };
    }
}
