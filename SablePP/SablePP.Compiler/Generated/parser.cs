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
        
        private int getIndex(TNamespace node)
        {
            return 0;
        }
        private int getIndex(TNamespacetoken node)
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
                case 1:
                    {
                        List<PSection> psectionlist = isOn(1, index - 0) ? Pop<List<PSection>>() : new List<PSection>();
                        List<PSection> psectionlist2 = new List<PSection>();
                        psectionlist2.AddRange(psectionlist);
                        AGrammar agrammar = new AGrammar(
                            psectionlist2
                        );
                        Push(0, agrammar);
                    }
                    break;
                case 2:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        TNamespace tnamespace = Pop<TNamespace>();
                        TNamespacetoken tnamespacetoken = Pop<TNamespacetoken>();
                        ANamespaceSection anamespacesection = new ANamespaceSection(
                            tnamespacetoken,
                            tnamespace,
                            tsemicolon
                        );
                        Push(1, anamespacesection);
                    }
                    break;
                case 3:
                    {
                        List<PHelper> phelperlist = Pop<List<PHelper>>();
                        THelperstoken thelperstoken = Pop<THelperstoken>();
                        List<PHelper> phelperlist2 = new List<PHelper>();
                        phelperlist2.AddRange(phelperlist);
                        AHelpersSection ahelperssection = new AHelpersSection(
                            thelperstoken,
                            phelperlist2
                        );
                        Push(1, ahelperssection);
                    }
                    break;
                case 4:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        List<PState> pstatelist = Pop<List<PState>>();
                        TStatestoken tstatestoken = Pop<TStatestoken>();
                        List<PState> pstatelist2 = new List<PState>();
                        pstatelist2.AddRange(pstatelist);
                        AStatesSection astatessection = new AStatesSection(
                            tstatestoken,
                            pstatelist2,
                            tsemicolon
                        );
                        Push(1, astatessection);
                    }
                    break;
                case 5:
                    {
                        List<PToken> ptokenlist = Pop<List<PToken>>();
                        TTokenstoken ttokenstoken = Pop<TTokenstoken>();
                        List<PToken> ptokenlist2 = new List<PToken>();
                        ptokenlist2.AddRange(ptokenlist);
                        ATokensSection atokenssection = new ATokensSection(
                            ttokenstoken,
                            ptokenlist2
                        );
                        Push(1, atokenssection);
                    }
                    break;
                case 6:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        List<TIdentifier> tidentifierlist = Pop<List<TIdentifier>>();
                        TTokenstoken ttokenstoken = Pop<TTokenstoken>();
                        TIgnoredtoken tignoredtoken = Pop<TIgnoredtoken>();
                        List<TIdentifier> tidentifierlist2 = new List<TIdentifier>();
                        tidentifierlist2.AddRange(tidentifierlist);
                        AIgnoreSection aignoresection = new AIgnoreSection(
                            tignoredtoken,
                            ttokenstoken,
                            tidentifierlist2,
                            tsemicolon
                        );
                        Push(1, aignoresection);
                    }
                    break;
                case 7:
                    {
                        List<PProduction> pproductionlist = Pop<List<PProduction>>();
                        TProductionstoken tproductionstoken = Pop<TProductionstoken>();
                        List<PProduction> pproductionlist2 = new List<PProduction>();
                        pproductionlist2.AddRange(pproductionlist);
                        AProductionsSection aproductionssection = new AProductionsSection(
                            tproductionstoken,
                            pproductionlist2
                        );
                        Push(1, aproductionssection);
                    }
                    break;
                case 8:
                    {
                        List<PProduction> pproductionlist = Pop<List<PProduction>>();
                        TAsttoken tasttoken = Pop<TAsttoken>();
                        List<PProduction> pproductionlist2 = new List<PProduction>();
                        pproductionlist2.AddRange(pproductionlist);
                        AASTSection aastsection = new AASTSection(
                            tasttoken,
                            pproductionlist2
                        );
                        Push(1, aastsection);
                    }
                    break;
                case 9:
                    {
                        List<PHighlightrule> phighlightrulelist = Pop<List<PHighlightrule>>();
                        THighlighttoken thighlighttoken = Pop<THighlighttoken>();
                        List<PHighlightrule> phighlightrulelist2 = new List<PHighlightrule>();
                        phighlightrulelist2.AddRange(phighlightrulelist);
                        AHighlightSection ahighlightsection = new AHighlightSection(
                            thighlighttoken,
                            phighlightrulelist2
                        );
                        Push(1, ahighlightsection);
                    }
                    break;
                case 10:
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
                        Push(2, ahelper);
                    }
                    break;
                case 11:
                case 12:
                    {
                        List<PState> pstatelist = isOn(1, index - 11) ? Pop<List<PState>>() : new List<PState>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AState astate = new AState(
                            tidentifier
                        );
                        List<PState> pstatelist2 = new List<PState>();
                        pstatelist2.Add(astate);
                        pstatelist2.AddRange(pstatelist);
                        Push(3, pstatelist2);
                    }
                    break;
                case 13:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TComma tcomma = Pop<TComma>();
                        AState astate = new AState(
                            tidentifier
                        );
                        Push(4, astate);
                    }
                    break;
                case 14:
                case 15:
                    {
                        List<TIdentifier> tidentifierlist = isOn(1, index - 14) ? Pop<List<TIdentifier>>() : new List<TIdentifier>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        List<TIdentifier> tidentifierlist2 = new List<TIdentifier>();
                        tidentifierlist2.Add(tidentifier);
                        tidentifierlist2.AddRange(tidentifierlist);
                        Push(5, tidentifierlist2);
                    }
                    break;
                case 16:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TComma tcomma = Pop<TComma>();
                        Push(6, tidentifier);
                    }
                    break;
                case 17:
                case 18:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        PTokenlookahead ptokenlookahead = isOn(1, index - 17) ? Pop<PTokenlookahead>() : null;
                        PRegex pregex = Pop<PRegex>();
                        TEqual tequal = Pop<TEqual>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        List<PTokenState> ptokenstatelist = new List<PTokenState>();
                        AToken atoken = new AToken(
                            ptokenstatelist,
                            tidentifier,
                            tequal,
                            pregex,
                            ptokenlookahead,
                            tsemicolon
                        );
                        Push(7, atoken);
                    }
                    break;
                case 19:
                case 20:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        PTokenlookahead ptokenlookahead = isOn(1, index - 19) ? Pop<PTokenlookahead>() : null;
                        PRegex pregex = Pop<PRegex>();
                        TEqual tequal = Pop<TEqual>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        List<PTokenState> ptokenstatelist = Pop<List<PTokenState>>();
                        List<PTokenState> ptokenstatelist2 = new List<PTokenState>();
                        ptokenstatelist2.AddRange(ptokenstatelist);
                        AToken atoken = new AToken(
                            ptokenstatelist2,
                            tidentifier,
                            tequal,
                            pregex,
                            ptokenlookahead,
                            tsemicolon
                        );
                        Push(7, atoken);
                    }
                    break;
                case 21:
                case 22:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        List<PTokenState> ptokenstatelist = isOn(1, index - 21) ? Pop<List<PTokenState>>() : new List<PTokenState>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        ATokenState atokenstate = new ATokenState(
                            tidentifier
                        );
                        List<PTokenState> ptokenstatelist2 = new List<PTokenState>();
                        ptokenstatelist2.Add(atokenstate);
                        ptokenstatelist2.AddRange(ptokenstatelist);
                        Push(8, ptokenstatelist2);
                    }
                    break;
                case 23:
                case 24:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        List<PTokenState> ptokenstatelist = isOn(1, index - 23) ? Pop<List<PTokenState>>() : new List<PTokenState>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        TIdentifier tidentifier2 = Pop<TIdentifier>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        ATransitionTokenState atransitiontokenstate = new ATransitionTokenState(
                            tidentifier2,
                            tarrow,
                            tidentifier
                        );
                        List<PTokenState> ptokenstatelist2 = new List<PTokenState>();
                        ptokenstatelist2.Add(atransitiontokenstate);
                        ptokenstatelist2.AddRange(ptokenstatelist);
                        Push(8, ptokenstatelist2);
                    }
                    break;
                case 25:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TComma tcomma = Pop<TComma>();
                        ATokenState atokenstate = new ATokenState(
                            tidentifier
                        );
                        Push(9, atokenstate);
                    }
                    break;
                case 26:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        TIdentifier tidentifier2 = Pop<TIdentifier>();
                        TComma tcomma = Pop<TComma>();
                        ATransitionTokenState atransitiontokenstate = new ATransitionTokenState(
                            tidentifier2,
                            tarrow,
                            tidentifier
                        );
                        Push(9, atransitiontokenstate);
                    }
                    break;
                case 27:
                    {
                        PRegex pregex = Pop<PRegex>();
                        TSlash tslash = Pop<TSlash>();
                        ATokenlookahead atokenlookahead = new ATokenlookahead(
                            tslash,
                            pregex
                        );
                        Push(10, atokenlookahead);
                    }
                    break;
                case 28:
                    {
                        PRegex pregex = Pop<PRegex>();
                        Push(11, pregex);
                    }
                    break;
                case 29:
                    {
                        List<PRegex> pregexlist = Pop<List<PRegex>>();
                        PRegex pregex = Pop<PRegex>();
                        List<PRegex> pregexlist2 = new List<PRegex>();
                        pregexlist2.Add(pregex);
                        pregexlist2.AddRange(pregexlist);
                        AOrRegex aorregex = new AOrRegex(
                            pregexlist2
                        );
                        Push(11, aorregex);
                    }
                    break;
                case 30:
                    {
                        PRegex pregex = Pop<PRegex>();
                        TPipe tpipe = Pop<TPipe>();
                        Push(12, pregex);
                    }
                    break;
                case 31:
                    {
                        List<PRegex> pregexlist = Pop<List<PRegex>>();
                        List<PRegex> pregexlist2 = new List<PRegex>();
                        pregexlist2.AddRange(pregexlist);
                        AConcatenatedRegex aconcatenatedregex = new AConcatenatedRegex(
                            pregexlist2
                        );
                        Push(13, aconcatenatedregex);
                    }
                    break;
                case 32:
                    {
                        TStar tstar = Pop<TStar>();
                        AStarModifier astarmodifier = new AStarModifier(
                            tstar
                        );
                        Push(14, astarmodifier);
                    }
                    break;
                case 33:
                    {
                        TQMark tqmark = Pop<TQMark>();
                        AQuestionModifier aquestionmodifier = new AQuestionModifier(
                            tqmark
                        );
                        Push(14, aquestionmodifier);
                    }
                    break;
                case 34:
                    {
                        TPlus tplus = Pop<TPlus>();
                        APlusModifier aplusmodifier = new APlusModifier(
                            tplus
                        );
                        Push(14, aplusmodifier);
                    }
                    break;
                case 35:
                    {
                        PRegex pregex = Pop<PRegex>();
                        Push(15, pregex);
                    }
                    break;
                case 36:
                    {
                        PModifier pmodifier = Pop<PModifier>();
                        PRegex pregex = Pop<PRegex>();
                        AUnaryRegex aunaryregex = new AUnaryRegex(
                            pregex,
                            pmodifier
                        );
                        Push(15, aunaryregex);
                    }
                    break;
                case 37:
                    {
                        PRegex pregex = Pop<PRegex>();
                        Push(16, pregex);
                    }
                    break;
                case 38:
                    {
                        PRegex pregex = Pop<PRegex>();
                        Push(16, pregex);
                    }
                    break;
                case 39:
                    {
                        TString tstring = Pop<TString>();
                        AStringRegex astringregex = new AStringRegex(
                            tstring
                        );
                        Push(16, astringregex);
                    }
                    break;
                case 40:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AIdentifierRegex aidentifierregex = new AIdentifierRegex(
                            tidentifier
                        );
                        Push(16, aidentifierregex);
                    }
                    break;
                case 41:
                    {
                        TRPar trpar = Pop<TRPar>();
                        PRegex pregex = Pop<PRegex>();
                        TLPar tlpar = Pop<TLPar>();
                        AParenthesisRegex aparenthesisregex = new AParenthesisRegex(
                            tlpar,
                            pregex,
                            trpar
                        );
                        Push(16, aparenthesisregex);
                    }
                    break;
                case 42:
                    {
                        TCharacter tcharacter = Pop<TCharacter>();
                        ACharRegex acharregex = new ACharRegex(
                            tcharacter
                        );
                        Push(17, acharregex);
                    }
                    break;
                case 43:
                    {
                        TDecChar tdecchar = Pop<TDecChar>();
                        ADecRegex adecregex = new ADecRegex(
                            tdecchar
                        );
                        Push(17, adecregex);
                    }
                    break;
                case 44:
                    {
                        THexChar thexchar = Pop<THexChar>();
                        AHexRegex ahexregex = new AHexRegex(
                            thexchar
                        );
                        Push(17, ahexregex);
                    }
                    break;
                case 45:
                    {
                        TRBkt trbkt = Pop<TRBkt>();
                        PRegex pregex = Pop<PRegex>();
                        TPlus tplus = Pop<TPlus>();
                        PRegex pregex2 = Pop<PRegex>();
                        TLBkt tlbkt = Pop<TLBkt>();
                        ABinaryplusRegex abinaryplusregex = new ABinaryplusRegex(
                            tlbkt,
                            pregex2,
                            tplus,
                            pregex,
                            trbkt
                        );
                        Push(18, abinaryplusregex);
                    }
                    break;
                case 46:
                    {
                        TRBkt trbkt = Pop<TRBkt>();
                        PRegex pregex = Pop<PRegex>();
                        TMinus tminus = Pop<TMinus>();
                        PRegex pregex2 = Pop<PRegex>();
                        TLBkt tlbkt = Pop<TLBkt>();
                        ABinaryminusRegex abinaryminusregex = new ABinaryminusRegex(
                            tlbkt,
                            pregex2,
                            tminus,
                            pregex,
                            trbkt
                        );
                        Push(18, abinaryminusregex);
                    }
                    break;
                case 47:
                    {
                        TRBkt trbkt = Pop<TRBkt>();
                        PRegex pregex = Pop<PRegex>();
                        TDDot tddot = Pop<TDDot>();
                        PRegex pregex2 = Pop<PRegex>();
                        TLBkt tlbkt = Pop<TLBkt>();
                        AIntervalRegex aintervalregex = new AIntervalRegex(
                            tlbkt,
                            pregex2,
                            tddot,
                            pregex,
                            trbkt
                        );
                        Push(18, aintervalregex);
                    }
                    break;
                case 48:
                case 49:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        List<PAlternative> palternativelist = Pop<List<PAlternative>>();
                        TEqual tequal = Pop<TEqual>();
                        PProdtranslation pprodtranslation = isOn(1, index - 48) ? Pop<PProdtranslation>() : null;
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        List<PAlternative> palternativelist2 = new List<PAlternative>();
                        palternativelist2.AddRange(palternativelist);
                        AProduction aproduction = new AProduction(
                            tidentifier,
                            pprodtranslation,
                            tequal,
                            palternativelist2,
                            tsemicolon
                        );
                        Push(19, aproduction);
                    }
                    break;
                case 50:
                case 51:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        PModifier pmodifier = isOn(1, index - 50) ? Pop<PModifier>() : null;
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AProdtranslation aprodtranslation = new AProdtranslation(
                            tarrow,
                            tidentifier,
                            pmodifier
                        );
                        Push(20, aprodtranslation);
                    }
                    break;
                case 52:
                case 53:
                    {
                        PModifier pmodifier = isOn(1, index - 52) ? Pop<PModifier>() : null;
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        AProdtranslation aprodtranslation = new AProdtranslation(
                            tarrow,
                            tidentifier,
                            pmodifier
                        );
                        Push(20, aprodtranslation);
                    }
                    break;
                case 54:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        PTranslation ptranslation = Pop<PTranslation>();
                        TArrow tarrow = Pop<TArrow>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AFullTranslation afulltranslation = new AFullTranslation(
                            tarrow,
                            ptranslation
                        );
                        Push(21, afulltranslation);
                    }
                    break;
                case 55:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        TArrow tarrow = Pop<TArrow>();
                        AFullTranslation afulltranslation = new AFullTranslation(
                            tarrow,
                            ptranslation
                        );
                        Push(21, afulltranslation);
                    }
                    break;
                case 56:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        Push(22, ptranslation);
                    }
                    break;
                case 57:
                case 58:
                    {
                        TRPar trpar = Pop<TRPar>();
                        List<PTranslation> ptranslationlist = isOn(1, index - 57) ? Pop<List<PTranslation>>() : new List<PTranslation>();
                        TLPar tlpar = Pop<TLPar>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TNew tnew = Pop<TNew>();
                        List<PTranslation> ptranslationlist2 = new List<PTranslation>();
                        ptranslationlist2.AddRange(ptranslationlist);
                        ANewTranslation anewtranslation = new ANewTranslation(
                            tnew,
                            tidentifier,
                            tlpar,
                            ptranslationlist2,
                            trpar
                        );
                        Push(22, anewtranslation);
                    }
                    break;
                case 59:
                case 60:
                    {
                        TRPar trpar = Pop<TRPar>();
                        List<PTranslation> ptranslationlist = isOn(1, index - 59) ? Pop<List<PTranslation>>() : new List<PTranslation>();
                        TLPar tlpar = Pop<TLPar>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TIdentifier tidentifier2 = Pop<TIdentifier>();
                        TNew tnew = Pop<TNew>();
                        List<PTranslation> ptranslationlist2 = new List<PTranslation>();
                        ptranslationlist2.AddRange(ptranslationlist);
                        ANewalternativeTranslation anewalternativetranslation = new ANewalternativeTranslation(
                            tnew,
                            tidentifier2,
                            tdot,
                            tidentifier,
                            tlpar,
                            ptranslationlist2,
                            trpar
                        );
                        Push(22, anewalternativetranslation);
                    }
                    break;
                case 61:
                    {
                        TNull tnull = Pop<TNull>();
                        ANullTranslation anulltranslation = new ANullTranslation(
                            tnull
                        );
                        Push(22, anulltranslation);
                    }
                    break;
                case 62:
                case 63:
                    {
                        TRBkt trbkt = Pop<TRBkt>();
                        List<PTranslation> ptranslationlist = isOn(1, index - 62) ? Pop<List<PTranslation>>() : new List<PTranslation>();
                        TLBkt tlbkt = Pop<TLBkt>();
                        List<PTranslation> ptranslationlist2 = new List<PTranslation>();
                        ptranslationlist2.AddRange(ptranslationlist);
                        AListTranslation alisttranslation = new AListTranslation(
                            tlbkt,
                            ptranslationlist2,
                            trbkt
                        );
                        Push(22, alisttranslation);
                    }
                    break;
                case 64:
                case 65:
                    {
                        List<PTranslation> ptranslationlist = isOn(1, index - 64) ? Pop<List<PTranslation>>() : new List<PTranslation>();
                        PTranslation ptranslation = Pop<PTranslation>();
                        List<PTranslation> ptranslationlist2 = new List<PTranslation>();
                        ptranslationlist2.Add(ptranslation);
                        ptranslationlist2.AddRange(ptranslationlist);
                        Push(23, ptranslationlist2);
                    }
                    break;
                case 66:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        TComma tcomma = Pop<TComma>();
                        Push(24, ptranslation);
                    }
                    break;
                case 67:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AIdTranslation aidtranslation = new AIdTranslation(
                            tidentifier
                        );
                        Push(25, aidtranslation);
                    }
                    break;
                case 68:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TIdentifier tidentifier2 = Pop<TIdentifier>();
                        AIddotidTranslation aiddotidtranslation = new AIddotidTranslation(
                            tidentifier2,
                            tdot,
                            tidentifier
                        );
                        Push(25, aiddotidtranslation);
                    }
                    break;
                case 69:
                case 70:
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                case 76:
                    {
                        PTranslation ptranslation = isOn(4, index - 69) ? Pop<PTranslation>() : null;
                        List<PElement> pelementlist = isOn(2, index - 69) ? Pop<List<PElement>>() : new List<PElement>();
                        PAlternativename palternativename = isOn(1, index - 69) ? Pop<PAlternativename>() : null;
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AAlternative aalternative = new AAlternative(
                            palternativename,
                            pelementlist2,
                            ptranslation
                        );
                        List<PAlternative> palternativelist = new List<PAlternative>();
                        palternativelist.Add(aalternative);
                        Push(26, palternativelist);
                    }
                    break;
                case 77:
                case 78:
                case 79:
                case 80:
                case 81:
                case 82:
                case 83:
                case 84:
                    {
                        List<PAlternative> palternativelist = Pop<List<PAlternative>>();
                        PTranslation ptranslation = isOn(4, index - 77) ? Pop<PTranslation>() : null;
                        List<PElement> pelementlist = isOn(2, index - 77) ? Pop<List<PElement>>() : new List<PElement>();
                        PAlternativename palternativename = isOn(1, index - 77) ? Pop<PAlternativename>() : null;
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AAlternative aalternative = new AAlternative(
                            palternativename,
                            pelementlist2,
                            ptranslation
                        );
                        List<PAlternative> palternativelist2 = new List<PAlternative>();
                        palternativelist2.Add(aalternative);
                        palternativelist2.AddRange(palternativelist);
                        Push(26, palternativelist2);
                    }
                    break;
                case 85:
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                case 91:
                case 92:
                    {
                        PTranslation ptranslation = isOn(4, index - 85) ? Pop<PTranslation>() : null;
                        List<PElement> pelementlist = isOn(2, index - 85) ? Pop<List<PElement>>() : new List<PElement>();
                        PAlternativename palternativename = isOn(1, index - 85) ? Pop<PAlternativename>() : null;
                        TPipe tpipe = Pop<TPipe>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AAlternative aalternative = new AAlternative(
                            palternativename,
                            pelementlist2,
                            ptranslation
                        );
                        Push(27, aalternative);
                    }
                    break;
                case 93:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AAlternativename aalternativename = new AAlternativename(
                            tlbrace,
                            tidentifier,
                            trbrace
                        );
                        Push(28, aalternativename);
                    }
                    break;
                case 94:
                case 95:
                case 96:
                case 97:
                    {
                        PModifier pmodifier = isOn(2, index - 94) ? Pop<PModifier>() : null;
                        PElementid pelementid = Pop<PElementid>();
                        PElementname pelementname = isOn(1, index - 94) ? Pop<PElementname>() : null;
                        AElement aelement = new AElement(
                            pelementname,
                            pelementid,
                            pmodifier
                        );
                        Push(29, aelement);
                    }
                    break;
                case 98:
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
                        Push(30, aelementname);
                    }
                    break;
                case 99:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        ACleanElementid acleanelementid = new ACleanElementid(
                            tidentifier
                        );
                        Push(31, acleanelementid);
                    }
                    break;
                case 100:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TTokenSpecifier ttokenspecifier = Pop<TTokenSpecifier>();
                        ATokenElementid atokenelementid = new ATokenElementid(
                            ttokenspecifier,
                            tdot,
                            tidentifier
                        );
                        Push(31, atokenelementid);
                    }
                    break;
                case 101:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TProductionSpecifier tproductionspecifier = Pop<TProductionSpecifier>();
                        AProductionElementid aproductionelementid = new AProductionElementid(
                            tproductionspecifier,
                            tdot,
                            tidentifier
                        );
                        Push(31, aproductionelementid);
                    }
                    break;
                case 102:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        List<PHighlightStyle> phighlightstylelist = Pop<List<PHighlightStyle>>();
                        TRBrace trbrace = Pop<TRBrace>();
                        List<TIdentifier> tidentifierlist = Pop<List<TIdentifier>>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        List<TIdentifier> tidentifierlist2 = new List<TIdentifier>();
                        tidentifierlist2.AddRange(tidentifierlist);
                        List<PHighlightStyle> phighlightstylelist2 = new List<PHighlightStyle>();
                        phighlightstylelist2.AddRange(phighlightstylelist);
                        AHighlightrule ahighlightrule = new AHighlightrule(
                            tlbrace,
                            tidentifierlist2,
                            trbrace,
                            phighlightstylelist2,
                            tsemicolon
                        );
                        Push(32, ahighlightrule);
                    }
                    break;
                case 103:
                case 104:
                    {
                        List<PHighlightStyle> phighlightstylelist = isOn(1, index - 103) ? Pop<List<PHighlightStyle>>() : new List<PHighlightStyle>();
                        PHighlightStyle phighlightstyle = Pop<PHighlightStyle>();
                        List<PHighlightStyle> phighlightstylelist2 = new List<PHighlightStyle>();
                        phighlightstylelist2.Add(phighlightstyle);
                        phighlightstylelist2.AddRange(phighlightstylelist);
                        Push(33, phighlightstylelist2);
                    }
                    break;
                case 105:
                    {
                        PHighlightStyle phighlightstyle = Pop<PHighlightStyle>();
                        TComma tcomma = Pop<TComma>();
                        Push(34, phighlightstyle);
                    }
                    break;
                case 106:
                    {
                        TItalic titalic = Pop<TItalic>();
                        AItalicHighlightStyle aitalichighlightstyle = new AItalicHighlightStyle(
                            titalic
                        );
                        Push(35, aitalichighlightstyle);
                    }
                    break;
                case 107:
                    {
                        TBold tbold = Pop<TBold>();
                        ABoldHighlightStyle aboldhighlightstyle = new ABoldHighlightStyle(
                            tbold
                        );
                        Push(35, aboldhighlightstyle);
                    }
                    break;
                case 108:
                    {
                        PColor pcolor = Pop<PColor>();
                        TColon tcolon = Pop<TColon>();
                        TText ttext = Pop<TText>();
                        ATextHighlightStyle atexthighlightstyle = new ATextHighlightStyle(
                            ttext,
                            tcolon,
                            pcolor
                        );
                        Push(35, atexthighlightstyle);
                    }
                    break;
                case 109:
                    {
                        PColor pcolor = Pop<PColor>();
                        TColon tcolon = Pop<TColon>();
                        TBackground tbackground = Pop<TBackground>();
                        ABackgroundHighlightStyle abackgroundhighlightstyle = new ABackgroundHighlightStyle(
                            tbackground,
                            tcolon,
                            pcolor
                        );
                        Push(35, abackgroundhighlightstyle);
                    }
                    break;
                case 110:
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
                        Push(36, argbcolor);
                    }
                    break;
                case 111:
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
                        Push(36, ahsvcolor);
                    }
                    break;
                case 112:
                    {
                        THexColor thexcolor = Pop<THexColor>();
                        AHexColor ahexcolor = new AHexColor(
                            thexcolor
                        );
                        Push(36, ahexcolor);
                    }
                    break;
                case 113:
                    Push(37, new List<PSection>() { Pop<PSection>() });
                    break;
                case 114:
                    {
                        PSection item = Pop<PSection>();
                        List<PSection> list = Pop<List<PSection>>();
                        list.Add(item);
                        Push(37, list);
                    }
                    break;
                case 115:
                    Push(38, new List<PHelper>() { Pop<PHelper>() });
                    break;
                case 116:
                    {
                        PHelper item = Pop<PHelper>();
                        List<PHelper> list = Pop<List<PHelper>>();
                        list.Add(item);
                        Push(38, list);
                    }
                    break;
                case 117:
                    Push(39, new List<PToken>() { Pop<PToken>() });
                    break;
                case 118:
                    {
                        PToken item = Pop<PToken>();
                        List<PToken> list = Pop<List<PToken>>();
                        list.Add(item);
                        Push(39, list);
                    }
                    break;
                case 119:
                    Push(40, new List<PProduction>() { Pop<PProduction>() });
                    break;
                case 120:
                    {
                        PProduction item = Pop<PProduction>();
                        List<PProduction> list = Pop<List<PProduction>>();
                        list.Add(item);
                        Push(40, list);
                    }
                    break;
                case 121:
                    Push(41, new List<PHighlightrule>() { Pop<PHighlightrule>() });
                    break;
                case 122:
                    {
                        PHighlightrule item = Pop<PHighlightrule>();
                        List<PHighlightrule> list = Pop<List<PHighlightrule>>();
                        list.Add(item);
                        Push(41, list);
                    }
                    break;
                case 123:
                    Push(42, new List<PState>() { Pop<PState>() });
                    break;
                case 124:
                    {
                        PState item = Pop<PState>();
                        List<PState> list = Pop<List<PState>>();
                        list.Add(item);
                        Push(42, list);
                    }
                    break;
                case 125:
                    Push(43, new List<TIdentifier>() { Pop<TIdentifier>() });
                    break;
                case 126:
                    {
                        TIdentifier item = Pop<TIdentifier>();
                        List<TIdentifier> list = Pop<List<TIdentifier>>();
                        list.Add(item);
                        Push(43, list);
                    }
                    break;
                case 127:
                    Push(44, new List<PTokenState>() { Pop<PTokenState>() });
                    break;
                case 128:
                    {
                        PTokenState item = Pop<PTokenState>();
                        List<PTokenState> list = Pop<List<PTokenState>>();
                        list.Add(item);
                        Push(44, list);
                    }
                    break;
                case 129:
                    Push(45, new List<PRegex>() { Pop<PRegex>() });
                    break;
                case 130:
                    {
                        PRegex item = Pop<PRegex>();
                        List<PRegex> list = Pop<List<PRegex>>();
                        list.Add(item);
                        Push(45, list);
                    }
                    break;
                case 131:
                    Push(46, new List<PRegex>() { Pop<PRegex>() });
                    break;
                case 132:
                    {
                        PRegex item = Pop<PRegex>();
                        List<PRegex> list = Pop<List<PRegex>>();
                        list.Add(item);
                        Push(46, list);
                    }
                    break;
                case 133:
                    Push(47, new List<PTranslation>() { Pop<PTranslation>() });
                    break;
                case 134:
                    {
                        PTranslation item = Pop<PTranslation>();
                        List<PTranslation> list = Pop<List<PTranslation>>();
                        list.Add(item);
                        Push(47, list);
                    }
                    break;
                case 135:
                    Push(48, new List<PElement>() { Pop<PElement>() });
                    break;
                case 136:
                    {
                        PElement item = Pop<PElement>();
                        List<PElement> list = Pop<List<PElement>>();
                        list.Add(item);
                        Push(48, list);
                    }
                    break;
                case 137:
                    Push(49, new List<PAlternative>() { Pop<PAlternative>() });
                    break;
                case 138:
                    {
                        PAlternative item = Pop<PAlternative>();
                        List<PAlternative> list = Pop<List<PAlternative>>();
                        list.Add(item);
                        Push(49, list);
                    }
                    break;
                case 139:
                    Push(50, new List<PHighlightStyle>() { Pop<PHighlightStyle>() });
                    break;
                case 140:
                    {
                        PHighlightStyle item = Pop<PHighlightStyle>();
                        List<PHighlightStyle> list = Pop<List<PHighlightStyle>>();
                        list.Add(item);
                        Push(50, list);
                    }
                    break;
            }
        }
        
        #region actionTable
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
                new int[] {0, 0, 12},
            },
            new int[][] {
                new int[] {-1, 3, 2},
                new int[] {32, 0, 13},
            },
            new int[][] {
                new int[] {-1, 3, 3},
                new int[] {32, 0, 15},
            },
            new int[][] {
                new int[] {-1, 3, 4},
                new int[] {21, 0, 18},
                new int[] {32, 0, 19},
            },
            new int[][] {
                new int[] {-1, 3, 5},
                new int[] {4, 0, 23},
            },
            new int[][] {
                new int[] {-1, 3, 6},
                new int[] {32, 0, 24},
            },
            new int[][] {
                new int[] {-1, 3, 7},
                new int[] {32, 0, 24},
            },
            new int[][] {
                new int[] {-1, 3, 8},
                new int[] {21, 0, 28},
            },
            new int[][] {
                new int[] {-1, 3, 9},
                new int[] {44, 2, -1},
            },
            new int[][] {
                new int[] {-1, 1, 113},
            },
            new int[][] {
                new int[] {-1, 1, 1},
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
                new int[] {-1, 3, 12},
                new int[] {15, 0, 32},
            },
            new int[][] {
                new int[] {-1, 1, 11},
                new int[] {28, 0, 33},
            },
            new int[][] {
                new int[] {-1, 3, 14},
                new int[] {15, 0, 36},
            },
            new int[][] {
                new int[] {-1, 3, 15},
                new int[] {16, 0, 37},
            },
            new int[][] {
                new int[] {-1, 1, 115},
            },
            new int[][] {
                new int[] {-1, 1, 3},
                new int[] {32, 0, 15},
            },
            new int[][] {
                new int[] {-1, 3, 18},
                new int[] {32, 0, 39},
            },
            new int[][] {
                new int[] {-1, 3, 19},
                new int[] {16, 0, 40},
            },
            new int[][] {
                new int[] {-1, 1, 117},
            },
            new int[][] {
                new int[] {-1, 3, 21},
                new int[] {32, 0, 41},
            },
            new int[][] {
                new int[] {-1, 1, 5},
                new int[] {21, 0, 18},
                new int[] {32, 0, 19},
            },
            new int[][] {
                new int[] {-1, 3, 23},
                new int[] {32, 0, 43},
            },
            new int[][] {
                new int[] {-1, 3, 24},
                new int[] {16, 0, 45},
                new int[] {21, 0, 46},
                new int[] {30, 0, 47},
            },
            new int[][] {
                new int[] {-1, 1, 119},
            },
            new int[][] {
                new int[] {-1, 1, 7},
                new int[] {32, 0, 24},
            },
            new int[][] {
                new int[] {-1, 1, 8},
                new int[] {32, 0, 24},
            },
            new int[][] {
                new int[] {-1, 3, 28},
                new int[] {32, 0, 43},
            },
            new int[][] {
                new int[] {-1, 1, 121},
            },
            new int[][] {
                new int[] {-1, 1, 9},
                new int[] {21, 0, 28},
            },
            new int[][] {
                new int[] {-1, 1, 114},
            },
            new int[][] {
                new int[] {-1, 1, 2},
            },
            new int[][] {
                new int[] {-1, 3, 33},
                new int[] {32, 0, 52},
            },
            new int[][] {
                new int[] {-1, 1, 123},
            },
            new int[][] {
                new int[] {-1, 1, 12},
                new int[] {28, 0, 33},
            },
            new int[][] {
                new int[] {-1, 1, 4},
            },
            new int[][] {
                new int[] {-1, 3, 37},
                new int[] {17, 0, 54},
                new int[] {19, 0, 55},
                new int[] {32, 0, 56},
                new int[] {33, 0, 57},
                new int[] {34, 0, 58},
                new int[] {35, 0, 59},
                new int[] {36, 0, 60},
            },
            new int[][] {
                new int[] {-1, 1, 116},
            },
            new int[][] {
                new int[] {-1, 3, 39},
                new int[] {22, 0, 68},
                new int[] {28, 0, 69},
                new int[] {30, 0, 70},
            },
            new int[][] {
                new int[] {-1, 3, 40},
                new int[] {17, 0, 54},
                new int[] {19, 0, 55},
                new int[] {32, 0, 56},
                new int[] {33, 0, 57},
                new int[] {34, 0, 58},
                new int[] {35, 0, 59},
                new int[] {36, 0, 60},
            },
            new int[][] {
                new int[] {-1, 3, 41},
                new int[] {16, 0, 74},
            },
            new int[][] {
                new int[] {-1, 1, 118},
            },
            new int[][] {
                new int[] {-1, 1, 14},
                new int[] {28, 0, 75},
            },
            new int[][] {
                new int[] {-1, 3, 44},
                new int[] {15, 0, 78},
            },
            new int[][] {
                new int[] {-1, 1, 69},
                new int[] {11, 0, 79},
                new int[] {12, 0, 80},
                new int[] {17, 0, 81},
                new int[] {21, 0, 82},
                new int[] {27, 0, 83},
                new int[] {30, 0, 84},
                new int[] {32, 0, 85},
            },
            new int[][] {
                new int[] {-1, 3, 46},
                new int[] {30, 0, 95},
            },
            new int[][] {
                new int[] {-1, 3, 47},
                new int[] {32, 0, 96},
            },
            new int[][] {
                new int[] {-1, 3, 48},
                new int[] {16, 0, 97},
            },
            new int[][] {
                new int[] {-1, 1, 120},
            },
            new int[][] {
                new int[] {-1, 3, 50},
                new int[] {22, 0, 98},
            },
            new int[][] {
                new int[] {-1, 1, 122},
            },
            new int[][] {
                new int[] {-1, 1, 13},
            },
            new int[][] {
                new int[] {-1, 1, 124},
            },
            new int[][] {
                new int[] {-1, 3, 54},
                new int[] {17, 0, 54},
                new int[] {19, 0, 55},
                new int[] {32, 0, 56},
                new int[] {33, 0, 57},
                new int[] {34, 0, 58},
                new int[] {35, 0, 59},
                new int[] {36, 0, 60},
            },
            new int[][] {
                new int[] {-1, 3, 55},
                new int[] {17, 0, 54},
                new int[] {19, 0, 55},
                new int[] {32, 0, 56},
                new int[] {33, 0, 57},
                new int[] {34, 0, 58},
                new int[] {35, 0, 59},
                new int[] {36, 0, 60},
            },
            new int[][] {
                new int[] {-1, 1, 40},
            },
            new int[][] {
                new int[] {-1, 1, 42},
            },
            new int[][] {
                new int[] {-1, 1, 43},
            },
            new int[][] {
                new int[] {-1, 1, 44},
            },
            new int[][] {
                new int[] {-1, 1, 39},
            },
            new int[][] {
                new int[] {-1, 3, 61},
                new int[] {15, 0, 102},
            },
            new int[][] {
                new int[] {-1, 1, 28},
                new int[] {27, 0, 103},
            },
            new int[][] {
                new int[] {-1, 1, 131},
            },
            new int[][] {
                new int[] {-1, 1, 35},
                new int[] {23, 0, 106},
                new int[] {25, 0, 107},
                new int[] {26, 0, 108},
            },
            new int[][] {
                new int[] {-1, 1, 37},
            },
            new int[][] {
                new int[] {-1, 1, 38},
            },
            new int[][] {
                new int[] {-1, 1, 31},
                new int[] {17, 0, 54},
                new int[] {19, 0, 55},
                new int[] {32, 0, 56},
                new int[] {33, 0, 57},
                new int[] {34, 0, 58},
                new int[] {35, 0, 59},
                new int[] {36, 0, 60},
            },
            new int[][] {
                new int[] {-1, 1, 21},
            },
            new int[][] {
                new int[] {-1, 3, 69},
                new int[] {32, 0, 111},
            },
            new int[][] {
                new int[] {-1, 3, 70},
                new int[] {32, 0, 112},
            },
            new int[][] {
                new int[] {-1, 1, 127},
            },
            new int[][] {
                new int[] {-1, 3, 72},
                new int[] {22, 0, 113},
                new int[] {28, 0, 69},
            },
            new int[][] {
                new int[] {-1, 3, 73},
                new int[] {15, 0, 115},
                new int[] {29, 0, 116},
            },
            new int[][] {
                new int[] {-1, 3, 74},
                new int[] {17, 0, 54},
                new int[] {19, 0, 55},
                new int[] {32, 0, 56},
                new int[] {33, 0, 57},
                new int[] {34, 0, 58},
                new int[] {35, 0, 59},
                new int[] {36, 0, 60},
            },
            new int[][] {
                new int[] {-1, 3, 75},
                new int[] {32, 0, 119},
            },
            new int[][] {
                new int[] {-1, 1, 125},
            },
            new int[][] {
                new int[] {-1, 1, 15},
                new int[] {28, 0, 75},
            },
            new int[][] {
                new int[] {-1, 1, 6},
            },
            new int[][] {
                new int[] {-1, 3, 79},
                new int[] {13, 0, 121},
            },
            new int[][] {
                new int[] {-1, 3, 80},
                new int[] {13, 0, 122},
            },
            new int[][] {
                new int[] {-1, 3, 81},
                new int[] {32, 0, 123},
            },
            new int[][] {
                new int[] {-1, 3, 82},
                new int[] {30, 0, 124},
                new int[] {32, 0, 125},
            },
            new int[][] {
                new int[] {-1, 1, 85},
                new int[] {11, 0, 79},
                new int[] {12, 0, 80},
                new int[] {17, 0, 81},
                new int[] {21, 0, 82},
                new int[] {30, 0, 84},
                new int[] {32, 0, 85},
            },
            new int[][] {
                new int[] {-1, 3, 84},
                new int[] {9, 0, 129},
                new int[] {10, 0, 130},
                new int[] {17, 0, 131},
                new int[] {32, 0, 132},
            },
            new int[][] {
                new int[] {-1, 1, 99},
            },
            new int[][] {
                new int[] {-1, 1, 73},
                new int[] {27, 0, 83},
            },
            new int[][] {
                new int[] {-1, 3, 87},
                new int[] {15, 0, 136},
            },
            new int[][] {
                new int[] {-1, 1, 137},
            },
            new int[][] {
                new int[] {-1, 1, 70},
                new int[] {11, 0, 79},
                new int[] {12, 0, 80},
                new int[] {17, 0, 81},
                new int[] {21, 0, 137},
                new int[] {27, 0, 83},
                new int[] {30, 0, 84},
                new int[] {32, 0, 85},
            },
            new int[][] {
                new int[] {-1, 1, 135},
            },
            new int[][] {
                new int[] {-1, 3, 91},
                new int[] {11, 0, 79},
                new int[] {12, 0, 80},
                new int[] {32, 0, 85},
            },
            new int[][] {
                new int[] {-1, 1, 94},
                new int[] {23, 0, 106},
                new int[] {25, 0, 107},
                new int[] {26, 0, 108},
            },
            new int[][] {
                new int[] {-1, 1, 71},
                new int[] {11, 0, 79},
                new int[] {12, 0, 80},
                new int[] {17, 0, 81},
                new int[] {21, 0, 137},
                new int[] {27, 0, 83},
                new int[] {30, 0, 84},
                new int[] {32, 0, 85},
            },
            new int[][] {
                new int[] {-1, 1, 77},
                new int[] {27, 0, 83},
            },
            new int[][] {
                new int[] {-1, 3, 95},
                new int[] {32, 0, 147},
            },
            new int[][] {
                new int[] {-1, 1, 52},
                new int[] {23, 0, 106},
                new int[] {25, 0, 107},
                new int[] {26, 0, 108},
            },
            new int[][] {
                new int[] {-1, 1, 69},
                new int[] {11, 0, 79},
                new int[] {12, 0, 80},
                new int[] {17, 0, 81},
                new int[] {21, 0, 82},
                new int[] {27, 0, 83},
                new int[] {30, 0, 84},
                new int[] {32, 0, 85},
            },
            new int[][] {
                new int[] {-1, 3, 98},
                new int[] {37, 0, 150},
                new int[] {38, 0, 151},
                new int[] {39, 0, 152},
                new int[] {40, 0, 153},
            },
            new int[][] {
                new int[] {-1, 3, 99},
                new int[] {23, 0, 156},
                new int[] {24, 0, 157},
            },
            new int[][] {
                new int[] {-1, 1, 37},
                new int[] {14, 0, 158},
            },
            new int[][] {
                new int[] {-1, 3, 101},
                new int[] {20, 0, 159},
            },
            new int[][] {
                new int[] {-1, 1, 10},
            },
            new int[][] {
                new int[] {-1, 3, 103},
                new int[] {17, 0, 54},
                new int[] {19, 0, 55},
                new int[] {32, 0, 56},
                new int[] {33, 0, 57},
                new int[] {34, 0, 58},
                new int[] {35, 0, 59},
                new int[] {36, 0, 60},
            },
            new int[][] {
                new int[] {-1, 1, 129},
            },
            new int[][] {
                new int[] {-1, 1, 29},
                new int[] {27, 0, 103},
            },
            new int[][] {
                new int[] {-1, 1, 34},
            },
            new int[][] {
                new int[] {-1, 1, 33},
            },
            new int[][] {
                new int[] {-1, 1, 32},
            },
            new int[][] {
                new int[] {-1, 1, 36},
            },
            new int[][] {
                new int[] {-1, 1, 132},
            },
            new int[][] {
                new int[] {-1, 1, 25},
                new int[] {30, 0, 162},
            },
            new int[][] {
                new int[] {-1, 3, 112},
                new int[] {22, 0, 163},
                new int[] {28, 0, 69},
            },
            new int[][] {
                new int[] {-1, 1, 22},
            },
            new int[][] {
                new int[] {-1, 1, 128},
            },
            new int[][] {
                new int[] {-1, 1, 17},
            },
            new int[][] {
                new int[] {-1, 3, 116},
                new int[] {17, 0, 54},
                new int[] {19, 0, 55},
                new int[] {32, 0, 56},
                new int[] {33, 0, 57},
                new int[] {34, 0, 58},
                new int[] {35, 0, 59},
                new int[] {36, 0, 60},
            },
            new int[][] {
                new int[] {-1, 3, 117},
                new int[] {15, 0, 166},
            },
            new int[][] {
                new int[] {-1, 3, 118},
                new int[] {15, 0, 167},
                new int[] {29, 0, 116},
            },
            new int[][] {
                new int[] {-1, 1, 16},
            },
            new int[][] {
                new int[] {-1, 1, 126},
            },
            new int[][] {
                new int[] {-1, 3, 121},
                new int[] {32, 0, 169},
            },
            new int[][] {
                new int[] {-1, 3, 122},
                new int[] {32, 0, 170},
            },
            new int[][] {
                new int[] {-1, 3, 123},
                new int[] {18, 0, 171},
            },
            new int[][] {
                new int[] {-1, 3, 124},
                new int[] {9, 0, 129},
                new int[] {10, 0, 130},
                new int[] {17, 0, 131},
                new int[] {32, 0, 132},
            },
            new int[][] {
                new int[] {-1, 3, 125},
                new int[] {22, 0, 173},
            },
            new int[][] {
                new int[] {-1, 1, 89},
            },
            new int[][] {
                new int[] {-1, 1, 86},
                new int[] {11, 0, 79},
                new int[] {12, 0, 80},
                new int[] {17, 0, 81},
                new int[] {21, 0, 137},
                new int[] {30, 0, 84},
                new int[] {32, 0, 85},
            },
            new int[][] {
                new int[] {-1, 1, 87},
                new int[] {11, 0, 79},
                new int[] {12, 0, 80},
                new int[] {17, 0, 81},
                new int[] {21, 0, 137},
                new int[] {30, 0, 84},
                new int[] {32, 0, 85},
            },
            new int[][] {
                new int[] {-1, 3, 129},
                new int[] {32, 0, 177},
            },
            new int[][] {
                new int[] {-1, 1, 61},
            },
            new int[][] {
                new int[] {-1, 3, 131},
                new int[] {9, 0, 129},
                new int[] {10, 0, 130},
                new int[] {17, 0, 131},
                new int[] {18, 0, 178},
                new int[] {32, 0, 132},
            },
            new int[][] {
                new int[] {-1, 1, 67},
                new int[] {13, 0, 181},
            },
            new int[][] {
                new int[] {-1, 1, 55},
            },
            new int[][] {
                new int[] {-1, 1, 56},
            },
            new int[][] {
                new int[] {-1, 1, 81},
                new int[] {27, 0, 83},
            },
            new int[][] {
                new int[] {-1, 1, 48},
            },
            new int[][] {
                new int[] {-1, 3, 137},
                new int[] {30, 0, 124},
            },
            new int[][] {
                new int[] {-1, 1, 74},
                new int[] {27, 0, 83},
            },
            new int[][] {
                new int[] {-1, 1, 72},
                new int[] {11, 0, 79},
                new int[] {12, 0, 80},
                new int[] {17, 0, 81},
                new int[] {21, 0, 137},
                new int[] {27, 0, 83},
                new int[] {30, 0, 84},
                new int[] {32, 0, 85},
            },
            new int[][] {
                new int[] {-1, 1, 78},
                new int[] {27, 0, 83},
            },
            new int[][] {
                new int[] {-1, 1, 95},
                new int[] {23, 0, 106},
                new int[] {25, 0, 107},
                new int[] {26, 0, 108},
            },
            new int[][] {
                new int[] {-1, 1, 96},
            },
            new int[][] {
                new int[] {-1, 1, 75},
                new int[] {27, 0, 83},
            },
            new int[][] {
                new int[] {-1, 1, 136},
            },
            new int[][] {
                new int[] {-1, 1, 79},
                new int[] {27, 0, 83},
            },
            new int[][] {
                new int[] {-1, 1, 138},
            },
            new int[][] {
                new int[] {-1, 3, 147},
                new int[] {22, 0, 187},
                new int[] {23, 0, 106},
                new int[] {25, 0, 107},
                new int[] {26, 0, 108},
            },
            new int[][] {
                new int[] {-1, 1, 53},
            },
            new int[][] {
                new int[] {-1, 3, 149},
                new int[] {15, 0, 189},
            },
            new int[][] {
                new int[] {-1, 1, 106},
            },
            new int[][] {
                new int[] {-1, 1, 107},
            },
            new int[][] {
                new int[] {-1, 3, 152},
                new int[] {31, 0, 190},
            },
            new int[][] {
                new int[] {-1, 3, 153},
                new int[] {31, 0, 191},
            },
            new int[][] {
                new int[] {-1, 3, 154},
                new int[] {15, 0, 192},
            },
            new int[][] {
                new int[] {-1, 1, 103},
                new int[] {28, 0, 193},
            },
            new int[][] {
                new int[] {-1, 3, 156},
                new int[] {17, 0, 54},
                new int[] {19, 0, 55},
                new int[] {32, 0, 56},
                new int[] {33, 0, 57},
                new int[] {34, 0, 58},
                new int[] {35, 0, 59},
                new int[] {36, 0, 60},
            },
            new int[][] {
                new int[] {-1, 3, 157},
                new int[] {17, 0, 54},
                new int[] {19, 0, 55},
                new int[] {32, 0, 56},
                new int[] {33, 0, 57},
                new int[] {34, 0, 58},
                new int[] {35, 0, 59},
                new int[] {36, 0, 60},
            },
            new int[][] {
                new int[] {-1, 3, 158},
                new int[] {33, 0, 57},
                new int[] {34, 0, 58},
                new int[] {35, 0, 59},
            },
            new int[][] {
                new int[] {-1, 1, 41},
            },
            new int[][] {
                new int[] {-1, 1, 30},
            },
            new int[][] {
                new int[] {-1, 1, 130},
            },
            new int[][] {
                new int[] {-1, 3, 162},
                new int[] {32, 0, 199},
            },
            new int[][] {
                new int[] {-1, 1, 23},
            },
            new int[][] {
                new int[] {-1, 3, 164},
                new int[] {22, 0, 200},
                new int[] {28, 0, 69},
            },
            new int[][] {
                new int[] {-1, 1, 27},
            },
            new int[][] {
                new int[] {-1, 1, 18},
            },
            new int[][] {
                new int[] {-1, 1, 19},
            },
            new int[][] {
                new int[] {-1, 3, 168},
                new int[] {15, 0, 201},
            },
            new int[][] {
                new int[] {-1, 1, 100},
            },
            new int[][] {
                new int[] {-1, 1, 101},
            },
            new int[][] {
                new int[] {-1, 3, 171},
                new int[] {31, 0, 202},
            },
            new int[][] {
                new int[] {-1, 3, 172},
                new int[] {22, 0, 203},
            },
            new int[][] {
                new int[] {-1, 1, 93},
            },
            new int[][] {
                new int[] {-1, 1, 90},
            },
            new int[][] {
                new int[] {-1, 1, 88},
                new int[] {11, 0, 79},
                new int[] {12, 0, 80},
                new int[] {17, 0, 81},
                new int[] {21, 0, 137},
                new int[] {30, 0, 84},
                new int[] {32, 0, 85},
            },
            new int[][] {
                new int[] {-1, 1, 91},
            },
            new int[][] {
                new int[] {-1, 3, 177},
                new int[] {13, 0, 205},
                new int[] {19, 0, 206},
            },
            new int[][] {
                new int[] {-1, 1, 62},
            },
            new int[][] {
                new int[] {-1, 1, 64},
                new int[] {28, 0, 207},
            },
            new int[][] {
                new int[] {-1, 3, 180},
                new int[] {18, 0, 210},
            },
            new int[][] {
                new int[] {-1, 3, 181},
                new int[] {32, 0, 211},
            },
            new int[][] {
                new int[] {-1, 1, 82},
                new int[] {27, 0, 83},
            },
            new int[][] {
                new int[] {-1, 1, 76},
                new int[] {27, 0, 83},
            },
            new int[][] {
                new int[] {-1, 1, 80},
                new int[] {27, 0, 83},
            },
            new int[][] {
                new int[] {-1, 1, 97},
            },
            new int[][] {
                new int[] {-1, 1, 83},
                new int[] {27, 0, 83},
            },
            new int[][] {
                new int[] {-1, 1, 50},
            },
            new int[][] {
                new int[] {-1, 3, 188},
                new int[] {22, 0, 213},
            },
            new int[][] {
                new int[] {-1, 1, 49},
            },
            new int[][] {
                new int[] {-1, 3, 190},
                new int[] {41, 0, 214},
                new int[] {42, 0, 215},
                new int[] {43, 0, 216},
            },
            new int[][] {
                new int[] {-1, 3, 191},
                new int[] {41, 0, 214},
                new int[] {42, 0, 215},
                new int[] {43, 0, 216},
            },
            new int[][] {
                new int[] {-1, 1, 102},
            },
            new int[][] {
                new int[] {-1, 3, 193},
                new int[] {37, 0, 150},
                new int[] {38, 0, 151},
                new int[] {39, 0, 152},
                new int[] {40, 0, 153},
            },
            new int[][] {
                new int[] {-1, 1, 139},
            },
            new int[][] {
                new int[] {-1, 1, 104},
                new int[] {28, 0, 193},
            },
            new int[][] {
                new int[] {-1, 3, 196},
                new int[] {18, 0, 221},
            },
            new int[][] {
                new int[] {-1, 3, 197},
                new int[] {18, 0, 222},
            },
            new int[][] {
                new int[] {-1, 3, 198},
                new int[] {18, 0, 223},
            },
            new int[][] {
                new int[] {-1, 1, 26},
            },
            new int[][] {
                new int[] {-1, 1, 24},
            },
            new int[][] {
                new int[] {-1, 1, 20},
            },
            new int[][] {
                new int[] {-1, 1, 98},
            },
            new int[][] {
                new int[] {-1, 1, 54},
            },
            new int[][] {
                new int[] {-1, 1, 92},
            },
            new int[][] {
                new int[] {-1, 3, 205},
                new int[] {32, 0, 224},
            },
            new int[][] {
                new int[] {-1, 3, 206},
                new int[] {9, 0, 129},
                new int[] {10, 0, 130},
                new int[] {17, 0, 131},
                new int[] {20, 0, 225},
                new int[] {32, 0, 132},
            },
            new int[][] {
                new int[] {-1, 3, 207},
                new int[] {9, 0, 129},
                new int[] {10, 0, 130},
                new int[] {17, 0, 131},
                new int[] {32, 0, 132},
            },
            new int[][] {
                new int[] {-1, 1, 133},
            },
            new int[][] {
                new int[] {-1, 1, 65},
                new int[] {28, 0, 207},
            },
            new int[][] {
                new int[] {-1, 1, 63},
            },
            new int[][] {
                new int[] {-1, 1, 68},
            },
            new int[][] {
                new int[] {-1, 1, 84},
                new int[] {27, 0, 83},
            },
            new int[][] {
                new int[] {-1, 1, 51},
            },
            new int[][] {
                new int[] {-1, 3, 214},
                new int[] {19, 0, 229},
            },
            new int[][] {
                new int[] {-1, 3, 215},
                new int[] {19, 0, 230},
            },
            new int[][] {
                new int[] {-1, 1, 112},
            },
            new int[][] {
                new int[] {-1, 1, 108},
            },
            new int[][] {
                new int[] {-1, 1, 109},
            },
            new int[][] {
                new int[] {-1, 1, 105},
            },
            new int[][] {
                new int[] {-1, 1, 140},
            },
            new int[][] {
                new int[] {-1, 1, 45},
            },
            new int[][] {
                new int[] {-1, 1, 46},
            },
            new int[][] {
                new int[] {-1, 1, 47},
            },
            new int[][] {
                new int[] {-1, 3, 224},
                new int[] {19, 0, 231},
            },
            new int[][] {
                new int[] {-1, 1, 57},
            },
            new int[][] {
                new int[] {-1, 3, 226},
                new int[] {20, 0, 232},
            },
            new int[][] {
                new int[] {-1, 1, 66},
            },
            new int[][] {
                new int[] {-1, 1, 134},
            },
            new int[][] {
                new int[] {-1, 3, 229},
                new int[] {34, 0, 233},
            },
            new int[][] {
                new int[] {-1, 3, 230},
                new int[] {34, 0, 234},
            },
            new int[][] {
                new int[] {-1, 3, 231},
                new int[] {9, 0, 129},
                new int[] {10, 0, 130},
                new int[] {17, 0, 131},
                new int[] {20, 0, 235},
                new int[] {32, 0, 132},
            },
            new int[][] {
                new int[] {-1, 1, 58},
            },
            new int[][] {
                new int[] {-1, 3, 233},
                new int[] {28, 0, 237},
            },
            new int[][] {
                new int[] {-1, 3, 234},
                new int[] {28, 0, 238},
            },
            new int[][] {
                new int[] {-1, 1, 59},
            },
            new int[][] {
                new int[] {-1, 3, 236},
                new int[] {20, 0, 239},
            },
            new int[][] {
                new int[] {-1, 3, 237},
                new int[] {34, 0, 240},
            },
            new int[][] {
                new int[] {-1, 3, 238},
                new int[] {34, 0, 241},
            },
            new int[][] {
                new int[] {-1, 1, 60},
            },
            new int[][] {
                new int[] {-1, 3, 240},
                new int[] {28, 0, 242},
            },
            new int[][] {
                new int[] {-1, 3, 241},
                new int[] {28, 0, 243},
            },
            new int[][] {
                new int[] {-1, 3, 242},
                new int[] {34, 0, 244},
            },
            new int[][] {
                new int[] {-1, 3, 243},
                new int[] {34, 0, 245},
            },
            new int[][] {
                new int[] {-1, 3, 244},
                new int[] {20, 0, 246},
            },
            new int[][] {
                new int[] {-1, 3, 245},
                new int[] {20, 0, 247},
            },
            new int[][] {
                new int[] {-1, 1, 110},
            },
            new int[][] {
                new int[] {-1, 1, 111},
            },
        };
        #endregion
        #region gotoTable
        private static int[][][] gotoTable = {
            new int[][] {
                new int[] {-1, 9},
            },
            new int[][] {
                new int[] {-1, 10},
                new int[] {11, 31},
            },
            new int[][] {
                new int[] {-1, 16},
                new int[] {17, 38},
            },
            new int[][] {
                new int[] {-1, 14},
            },
            new int[][] {
                new int[] {-1, 34},
                new int[] {35, 53},
            },
            new int[][] {
                new int[] {-1, 44},
                new int[] {28, 50},
            },
            new int[][] {
                new int[] {-1, 76},
                new int[] {77, 120},
            },
            new int[][] {
                new int[] {-1, 20},
                new int[] {22, 42},
            },
            new int[][] {
                new int[] {-1, 21},
            },
            new int[][] {
                new int[] {-1, 71},
                new int[] {72, 114},
                new int[] {164, 114},
            },
            new int[][] {
                new int[] {-1, 117},
                new int[] {118, 168},
            },
            new int[][] {
                new int[] {-1, 61},
                new int[] {40, 73},
                new int[] {55, 101},
                new int[] {74, 118},
                new int[] {116, 165},
            },
            new int[][] {
                new int[] {-1, 104},
                new int[] {105, 161},
            },
            new int[][] {
                new int[] {-1, 62},
                new int[] {103, 160},
            },
            new int[][] {
                new int[] {-1, 109},
                new int[] {92, 142},
                new int[] {96, 148},
                new int[] {141, 185},
                new int[] {147, 188},
            },
            new int[][] {
                new int[] {-1, 63},
                new int[] {67, 110},
            },
            new int[][] {
                new int[] {-1, 64},
                new int[] {54, 99},
                new int[] {156, 196},
                new int[] {157, 197},
            },
            new int[][] {
                new int[] {-1, 65},
                new int[] {54, 100},
                new int[] {158, 198},
            },
            new int[][] {
                new int[] {-1, 66},
            },
            new int[][] {
                new int[] {-1, 25},
                new int[] {26, 49},
                new int[] {27, 49},
            },
            new int[][] {
                new int[] {-1, 48},
            },
            new int[][] {
                new int[] {-1, 86},
                new int[] {83, 126},
                new int[] {89, 138},
                new int[] {93, 143},
                new int[] {127, 174},
                new int[] {128, 176},
                new int[] {139, 183},
                new int[] {175, 204},
            },
            new int[][] {
                new int[] {-1, 179},
                new int[] {84, 133},
                new int[] {124, 172},
                new int[] {207, 227},
            },
            new int[][] {
                new int[] {-1, 180},
                new int[] {206, 226},
                new int[] {231, 236},
            },
            new int[][] {
                new int[] {-1, 208},
                new int[] {209, 228},
            },
            new int[][] {
                new int[] {-1, 134},
            },
            new int[][] {
                new int[] {-1, 87},
                new int[] {97, 149},
            },
            new int[][] {
                new int[] {-1, 88},
                new int[] {94, 146},
                new int[] {135, 146},
                new int[] {140, 146},
                new int[] {145, 146},
                new int[] {182, 146},
                new int[] {184, 146},
                new int[] {186, 146},
                new int[] {212, 146},
            },
            new int[][] {
                new int[] {-1, 89},
                new int[] {83, 127},
            },
            new int[][] {
                new int[] {-1, 90},
                new int[] {93, 144},
                new int[] {128, 144},
                new int[] {139, 144},
                new int[] {175, 144},
            },
            new int[][] {
                new int[] {-1, 91},
            },
            new int[][] {
                new int[] {-1, 92},
                new int[] {91, 141},
            },
            new int[][] {
                new int[] {-1, 29},
                new int[] {30, 51},
            },
            new int[][] {
                new int[] {-1, 154},
            },
            new int[][] {
                new int[] {-1, 194},
                new int[] {195, 220},
            },
            new int[][] {
                new int[] {-1, 155},
                new int[] {193, 219},
            },
            new int[][] {
                new int[] {-1, 217},
                new int[] {191, 218},
            },
            new int[][] {
                new int[] {-1, 11},
            },
            new int[][] {
                new int[] {-1, 17},
            },
            new int[][] {
                new int[] {-1, 22},
            },
            new int[][] {
                new int[] {-1, 26},
                new int[] {7, 27},
            },
            new int[][] {
                new int[] {-1, 30},
            },
            new int[][] {
                new int[] {-1, 35},
            },
            new int[][] {
                new int[] {-1, 77},
            },
            new int[][] {
                new int[] {-1, 72},
                new int[] {112, 164},
            },
            new int[][] {
                new int[] {-1, 105},
            },
            new int[][] {
                new int[] {-1, 67},
            },
            new int[][] {
                new int[] {-1, 209},
            },
            new int[][] {
                new int[] {-1, 93},
                new int[] {83, 128},
                new int[] {89, 139},
                new int[] {127, 175},
            },
            new int[][] {
                new int[] {-1, 94},
                new int[] {86, 135},
                new int[] {89, 140},
                new int[] {93, 145},
                new int[] {138, 182},
                new int[] {139, 184},
                new int[] {143, 186},
                new int[] {183, 212},
            },
            new int[][] {
                new int[] {-1, 195},
            },
        };
        #endregion
        #region errorMessages
        private static string[] errorMessages = {
            "Expecting: 'Namespace', 'States', 'Helpers', 'Tokens', 'Ignored', 'Productions', TAsttoken, 'Token Syntax Highlight' or end of file",
            "Expecting: TNamespace",
            "Expecting: TIdentifier",
            "Expecting: '{' or TIdentifier",
            "Expecting: 'Tokens'",
            "Expecting: '{'",
            "Expecting: end of file",
            "Expecting: ';'",
            "Expecting: ';' or ','",
            "Expecting: '='",
            "Expecting: 'Namespace', 'States', 'Helpers', 'Tokens', 'Ignored', 'Productions', TAsttoken, 'Token Syntax Highlight', TIdentifier or end of file",
            "Expecting: 'Namespace', 'States', 'Helpers', 'Tokens', 'Ignored', 'Productions', TAsttoken, 'Token Syntax Highlight', '{', TIdentifier or end of file",
            "Expecting: '=', '{' or '->'",
            "Expecting: 'Namespace', 'States', 'Helpers', 'Tokens', 'Ignored', 'Productions', TAsttoken, 'Token Syntax Highlight', '{' or end of file",
            "Expecting: '[', '(', TIdentifier, TCharacter, TDecChar, THexChar or TString",
            "Expecting: '}', ',' or '->'",
            "Expecting: ';', '}' or ','",
            "Expecting: 'T', 'P', ';', '[', '{', '|', '->' or TIdentifier",
            "Expecting: '->'",
            "Expecting: '}'",
            "Expecting: ';', '[', ']', '(', ')', '+', '-', '?', '*', '|', '/', TIdentifier, TCharacter, TDecChar, THexChar or TString",
            "Expecting: '..', ';', '[', ']', '(', ')', '+', '-', '?', '*', '|', '/', TIdentifier, TCharacter, TDecChar, THexChar or TString",
            "Expecting: ';', ')', '|' or '/'",
            "Expecting: ';', '[', '(', ')', '|', '/', TIdentifier, TCharacter, TDecChar, THexChar or TString",
            "Expecting: ';', '[', '(', ')', '+', '?', '*', '|', '/', TIdentifier, TCharacter, TDecChar, THexChar or TString",
            "Expecting: ';', '[', ']', '(', ')', '+', '?', '*', '|', '/', TIdentifier, TCharacter, TDecChar, THexChar or TString",
            "Expecting: '}' or ','",
            "Expecting: ';' or '/'",
            "Expecting: '.'",
            "Expecting: '->' or TIdentifier",
            "Expecting: 'New', 'Null', '[' or TIdentifier",
            "Expecting: 'T', 'P', ';', '[', '{', '+', '?', '*', '|', '->' or TIdentifier",
            "Expecting: ';' or '|'",
            "Expecting: 'T', 'P' or TIdentifier",
            "Expecting: '=', '+', '?' or '*'",
            "Expecting: 'italic', 'bold', 'text' or 'background'",
            "Expecting: '+' or '-'",
            "Expecting: '..', '+' or '-'",
            "Expecting: ')'",
            "Expecting: 'T', 'P', ';', '=', '[', '(', ')', '{', '}', '|', '/', '->', TIdentifier, TCharacter, TDecChar, THexChar or TString",
            "Expecting: ']'",
            "Expecting: ';', ']', ')', '}', '|' or ','",
            "Expecting: 'New', 'Null', '[', ']' or TIdentifier",
            "Expecting: '.', ';', ']', ')', '}', '|' or ','",
            "Expecting: '}', '+', '?' or '*'",
            "Expecting: ':'",
            "Expecting: TCharacter, TDecChar or THexChar",
            "Expecting: '.' or '('",
            "Expecting: ']', ')' or ','",
            "Expecting: 'rgb', THsv or THexColor",
            "Expecting: 'New', 'Null', '[', ')' or TIdentifier",
            "Expecting: '('",
            "Expecting: TDecChar",
            "Expecting: ','",
        };
        #endregion
        #region errors
        private static int[] errors = {
            0, 1, 2, 2, 3, 4, 2, 2, 5, 6, 0, 0, 7, 8, 7, 9,
            10, 10, 2, 9, 11, 2, 11, 2, 12, 10, 10, 10, 2, 13, 13, 0,
            0, 2, 8, 8, 0, 14, 10, 15, 14, 9, 11, 16, 7, 17, 18, 2,
            9, 10, 19, 13, 8, 8, 14, 14, 20, 21, 21, 21, 20, 7, 22, 23,
            24, 25, 20, 23, 2, 2, 2, 26, 26, 27, 14, 2, 16, 16, 0, 28,
            28, 2, 29, 17, 30, 31, 32, 7, 32, 17, 17, 33, 31, 17, 32, 2,
            34, 17, 35, 36, 37, 38, 10, 14, 22, 22, 39, 39, 39, 23, 23, 15,
            26, 2, 26, 11, 14, 7, 27, 16, 16, 2, 2, 40, 30, 19, 32, 17,
            17, 2, 41, 42, 43, 32, 41, 32, 10, 18, 32, 17, 32, 31, 17, 32,
            17, 32, 32, 44, 9, 7, 8, 8, 45, 45, 7, 8, 14, 14, 46, 20,
            22, 22, 2, 2, 26, 7, 11, 11, 7, 31, 31, 45, 19, 17, 32, 17,
            32, 47, 41, 48, 40, 2, 32, 32, 32, 17, 32, 9, 19, 10, 49, 49,
            13, 35, 8, 8, 40, 40, 40, 26, 2, 11, 33, 32, 32, 2, 50, 30,
            48, 48, 41, 41, 32, 9, 51, 51, 8, 8, 8, 8, 8, 20, 20, 20,
            51, 41, 38, 48, 48, 52, 52, 50, 41, 53, 53, 41, 38, 52, 52, 41,
            53, 53, 52, 52, 38, 38, 8, 8,
        };
        #endregion
    }
}
