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
                case 1:
                    {
                        List<PSection> psectionlist = isOn(1, index - 0) ? Pop<List<PSection>>() : new List<PSection>();
                        List<PSection> psectionlist2 = new List<PSection>();
                        psectionlist2.AddRange(psectionlist);
                        ASectionGrammar asectiongrammar = new ASectionGrammar(
                            psectionlist2
                        );
                        Push(0, asectiongrammar);
                    }
                    break;
                case 2:
                    {
                        PPackage ppackage = Pop<PPackage>();
                        APackageSection apackagesection = new APackageSection(
                            ppackage
                        );
                        Push(1, apackagesection);
                    }
                    break;
                case 3:
                    {
                        PHelpers phelpers = Pop<PHelpers>();
                        AHelpersSection ahelperssection = new AHelpersSection(
                            phelpers
                        );
                        Push(1, ahelperssection);
                    }
                    break;
                case 4:
                    {
                        PStates pstates = Pop<PStates>();
                        AStatesSection astatessection = new AStatesSection(
                            pstates
                        );
                        Push(1, astatessection);
                    }
                    break;
                case 5:
                    {
                        PTokens ptokens = Pop<PTokens>();
                        ATokensSection atokenssection = new ATokensSection(
                            ptokens
                        );
                        Push(1, atokenssection);
                    }
                    break;
                case 6:
                    {
                        PIgnoredtokens pignoredtokens = Pop<PIgnoredtokens>();
                        AIgnoreSection aignoresection = new AIgnoreSection(
                            pignoredtokens
                        );
                        Push(1, aignoresection);
                    }
                    break;
                case 7:
                    {
                        PProductions pproductions = Pop<PProductions>();
                        AProductionsSection aproductionssection = new AProductionsSection(
                            pproductions
                        );
                        Push(1, aproductionssection);
                    }
                    break;
                case 8:
                    {
                        PAstproductions pastproductions = Pop<PAstproductions>();
                        AASTSection aastsection = new AASTSection(
                            pastproductions
                        );
                        Push(1, aastsection);
                    }
                    break;
                case 9:
                    {
                        PHighlightrules phighlightrules = Pop<PHighlightrules>();
                        AHighlightSection ahighlightsection = new AHighlightSection(
                            phighlightrules
                        );
                        Push(1, ahighlightsection);
                    }
                    break;
                case 10:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        TPackagename tpackagename = Pop<TPackagename>();
                        TPackagetoken tpackagetoken = Pop<TPackagetoken>();
                        APackage apackage = new APackage(
                            tpackagetoken,
                            tpackagename,
                            tsemicolon
                        );
                        Push(2, apackage);
                    }
                    break;
                case 11:
                    {
                        List<PHelper> phelperlist = Pop<List<PHelper>>();
                        THelperstoken thelperstoken = Pop<THelperstoken>();
                        List<PHelper> phelperlist2 = new List<PHelper>();
                        phelperlist2.AddRange(phelperlist);
                        AHelpers ahelpers = new AHelpers(
                            thelperstoken,
                            phelperlist2
                        );
                        Push(3, ahelpers);
                    }
                    break;
                case 12:
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
                        Push(4, ahelper);
                    }
                    break;
                case 13:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        List<PState> pstatelist = Pop<List<PState>>();
                        TStatestoken tstatestoken = Pop<TStatestoken>();
                        List<PState> pstatelist2 = new List<PState>();
                        pstatelist2.AddRange(pstatelist);
                        AStates astates = new AStates(
                            tstatestoken,
                            pstatelist2,
                            tsemicolon
                        );
                        Push(5, astates);
                    }
                    break;
                case 14:
                case 15:
                    {
                        List<PState> pstatelist = isOn(1, index - 14) ? Pop<List<PState>>() : new List<PState>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AState astate = new AState(
                            tidentifier
                        );
                        List<PState> pstatelist2 = new List<PState>();
                        pstatelist2.Add(astate);
                        pstatelist2.AddRange(pstatelist);
                        Push(6, pstatelist2);
                    }
                    break;
                case 16:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TComma tcomma = Pop<TComma>();
                        AState astate = new AState(
                            tidentifier
                        );
                        Push(7, astate);
                    }
                    break;
                case 17:
                case 18:
                    {
                        List<TIdentifier> tidentifierlist = isOn(1, index - 17) ? Pop<List<TIdentifier>>() : new List<TIdentifier>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        List<TIdentifier> tidentifierlist2 = new List<TIdentifier>();
                        tidentifierlist2.Add(tidentifier);
                        tidentifierlist2.AddRange(tidentifierlist);
                        Push(8, tidentifierlist2);
                    }
                    break;
                case 19:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TComma tcomma = Pop<TComma>();
                        Push(9, tidentifier);
                    }
                    break;
                case 20:
                    {
                        List<PToken> ptokenlist = Pop<List<PToken>>();
                        TTokenstoken ttokenstoken = Pop<TTokenstoken>();
                        List<PToken> ptokenlist2 = new List<PToken>();
                        ptokenlist2.AddRange(ptokenlist);
                        ATokens atokens = new ATokens(
                            ttokenstoken,
                            ptokenlist2
                        );
                        Push(10, atokens);
                    }
                    break;
                case 21:
                case 22:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        PTokenlookahead ptokenlookahead = isOn(1, index - 21) ? Pop<PTokenlookahead>() : null;
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
                        Push(11, atoken);
                    }
                    break;
                case 23:
                case 24:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        PTokenlookahead ptokenlookahead = isOn(1, index - 23) ? Pop<PTokenlookahead>() : null;
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
                        Push(11, atoken);
                    }
                    break;
                case 25:
                case 26:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        List<PTokenState> ptokenstatelist = isOn(1, index - 25) ? Pop<List<PTokenState>>() : new List<PTokenState>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        ATokenState atokenstate = new ATokenState(
                            tidentifier
                        );
                        List<PTokenState> ptokenstatelist2 = new List<PTokenState>();
                        ptokenstatelist2.Add(atokenstate);
                        ptokenstatelist2.AddRange(ptokenstatelist);
                        Push(12, ptokenstatelist2);
                    }
                    break;
                case 27:
                case 28:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        List<PTokenState> ptokenstatelist = isOn(1, index - 27) ? Pop<List<PTokenState>>() : new List<PTokenState>();
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
                        Push(12, ptokenstatelist2);
                    }
                    break;
                case 29:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TComma tcomma = Pop<TComma>();
                        ATokenState atokenstate = new ATokenState(
                            tidentifier
                        );
                        Push(13, atokenstate);
                    }
                    break;
                case 30:
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
                        Push(13, atransitiontokenstate);
                    }
                    break;
                case 31:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        List<TIdentifier> tidentifierlist = Pop<List<TIdentifier>>();
                        TTokenstoken ttokenstoken = Pop<TTokenstoken>();
                        TIgnoredtoken tignoredtoken = Pop<TIgnoredtoken>();
                        List<TIdentifier> tidentifierlist2 = new List<TIdentifier>();
                        tidentifierlist2.AddRange(tidentifierlist);
                        AIgnoredtokens aignoredtokens = new AIgnoredtokens(
                            tignoredtoken,
                            ttokenstoken,
                            tidentifierlist2,
                            tsemicolon
                        );
                        Push(14, aignoredtokens);
                    }
                    break;
                case 32:
                    {
                        PRegex pregex = Pop<PRegex>();
                        TSlash tslash = Pop<TSlash>();
                        ATokenlookahead atokenlookahead = new ATokenlookahead(
                            tslash,
                            pregex
                        );
                        Push(15, atokenlookahead);
                    }
                    break;
                case 33:
                    {
                        PRegex pregex = Pop<PRegex>();
                        Push(16, pregex);
                    }
                    break;
                case 34:
                    {
                        List<PRegex> pregexlist = Pop<List<PRegex>>();
                        PRegex pregex = Pop<PRegex>();
                        List<PRegex> pregexlist2 = new List<PRegex>();
                        pregexlist2.Add(pregex);
                        pregexlist2.AddRange(pregexlist);
                        AOrRegex aorregex = new AOrRegex(
                            pregexlist2
                        );
                        Push(16, aorregex);
                    }
                    break;
                case 35:
                    {
                        PRegex pregex = Pop<PRegex>();
                        TPipe tpipe = Pop<TPipe>();
                        Push(17, pregex);
                    }
                    break;
                case 36:
                    {
                        List<PRegex> pregexlist = Pop<List<PRegex>>();
                        List<PRegex> pregexlist2 = new List<PRegex>();
                        pregexlist2.AddRange(pregexlist);
                        AConcatenatedRegex aconcatenatedregex = new AConcatenatedRegex(
                            pregexlist2
                        );
                        Push(18, aconcatenatedregex);
                    }
                    break;
                case 37:
                    {
                        TStar tstar = Pop<TStar>();
                        AStarModifier astarmodifier = new AStarModifier(
                            tstar
                        );
                        Push(19, astarmodifier);
                    }
                    break;
                case 38:
                    {
                        TQMark tqmark = Pop<TQMark>();
                        AQuestionModifier aquestionmodifier = new AQuestionModifier(
                            tqmark
                        );
                        Push(19, aquestionmodifier);
                    }
                    break;
                case 39:
                    {
                        TPlus tplus = Pop<TPlus>();
                        APlusModifier aplusmodifier = new APlusModifier(
                            tplus
                        );
                        Push(19, aplusmodifier);
                    }
                    break;
                case 40:
                    {
                        PRegex pregex = Pop<PRegex>();
                        Push(20, pregex);
                    }
                    break;
                case 41:
                    {
                        PModifier pmodifier = Pop<PModifier>();
                        PRegex pregex = Pop<PRegex>();
                        AUnaryRegex aunaryregex = new AUnaryRegex(
                            pregex,
                            pmodifier
                        );
                        Push(20, aunaryregex);
                    }
                    break;
                case 42:
                    {
                        PRegex pregex = Pop<PRegex>();
                        Push(21, pregex);
                    }
                    break;
                case 43:
                    {
                        PRegex pregex = Pop<PRegex>();
                        Push(21, pregex);
                    }
                    break;
                case 44:
                    {
                        TString tstring = Pop<TString>();
                        AStringRegex astringregex = new AStringRegex(
                            tstring
                        );
                        Push(21, astringregex);
                    }
                    break;
                case 45:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AIdentifierRegex aidentifierregex = new AIdentifierRegex(
                            tidentifier
                        );
                        Push(21, aidentifierregex);
                    }
                    break;
                case 46:
                    {
                        TRPar trpar = Pop<TRPar>();
                        PRegex pregex = Pop<PRegex>();
                        TLPar tlpar = Pop<TLPar>();
                        AParenthesisRegex aparenthesisregex = new AParenthesisRegex(
                            tlpar,
                            pregex,
                            trpar
                        );
                        Push(21, aparenthesisregex);
                    }
                    break;
                case 47:
                    {
                        TCharacter tcharacter = Pop<TCharacter>();
                        ACharRegex acharregex = new ACharRegex(
                            tcharacter
                        );
                        Push(22, acharregex);
                    }
                    break;
                case 48:
                    {
                        TDecChar tdecchar = Pop<TDecChar>();
                        ADecRegex adecregex = new ADecRegex(
                            tdecchar
                        );
                        Push(22, adecregex);
                    }
                    break;
                case 49:
                    {
                        THexChar thexchar = Pop<THexChar>();
                        AHexRegex ahexregex = new AHexRegex(
                            thexchar
                        );
                        Push(22, ahexregex);
                    }
                    break;
                case 50:
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
                        Push(23, abinaryplusregex);
                    }
                    break;
                case 51:
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
                        Push(23, abinaryminusregex);
                    }
                    break;
                case 52:
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
                        Push(23, aintervalregex);
                    }
                    break;
                case 53:
                    {
                        List<PProduction> pproductionlist = Pop<List<PProduction>>();
                        TProductionstoken tproductionstoken = Pop<TProductionstoken>();
                        List<PProduction> pproductionlist2 = new List<PProduction>();
                        pproductionlist2.AddRange(pproductionlist);
                        AProductions aproductions = new AProductions(
                            tproductionstoken,
                            pproductionlist2
                        );
                        Push(24, aproductions);
                    }
                    break;
                case 54:
                case 55:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        List<PAlternative> palternativelist = Pop<List<PAlternative>>();
                        TEqual tequal = Pop<TEqual>();
                        PProdtranslation pprodtranslation = isOn(1, index - 54) ? Pop<PProdtranslation>() : null;
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
                        Push(25, aproduction);
                    }
                    break;
                case 56:
                case 57:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        PModifier pmodifier = isOn(1, index - 56) ? Pop<PModifier>() : null;
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AProdtranslation aprodtranslation = new AProdtranslation(
                            tarrow,
                            tidentifier,
                            pmodifier
                        );
                        Push(26, aprodtranslation);
                    }
                    break;
                case 58:
                case 59:
                    {
                        PModifier pmodifier = isOn(1, index - 58) ? Pop<PModifier>() : null;
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        AProdtranslation aprodtranslation = new AProdtranslation(
                            tarrow,
                            tidentifier,
                            pmodifier
                        );
                        Push(26, aprodtranslation);
                    }
                    break;
                case 60:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        PTranslation ptranslation = Pop<PTranslation>();
                        TArrow tarrow = Pop<TArrow>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AFullTranslation afulltranslation = new AFullTranslation(
                            tarrow,
                            ptranslation
                        );
                        Push(27, afulltranslation);
                    }
                    break;
                case 61:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        TArrow tarrow = Pop<TArrow>();
                        AFullTranslation afulltranslation = new AFullTranslation(
                            tarrow,
                            ptranslation
                        );
                        Push(27, afulltranslation);
                    }
                    break;
                case 62:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        Push(28, ptranslation);
                    }
                    break;
                case 63:
                case 64:
                    {
                        TRPar trpar = Pop<TRPar>();
                        List<PTranslation> ptranslationlist = isOn(1, index - 63) ? Pop<List<PTranslation>>() : new List<PTranslation>();
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
                        Push(28, anewtranslation);
                    }
                    break;
                case 65:
                case 66:
                    {
                        TRPar trpar = Pop<TRPar>();
                        List<PTranslation> ptranslationlist = isOn(1, index - 65) ? Pop<List<PTranslation>>() : new List<PTranslation>();
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
                        Push(28, anewalternativetranslation);
                    }
                    break;
                case 67:
                    {
                        TNull tnull = Pop<TNull>();
                        ANullTranslation anulltranslation = new ANullTranslation(
                            tnull
                        );
                        Push(28, anulltranslation);
                    }
                    break;
                case 68:
                case 69:
                    {
                        TRBkt trbkt = Pop<TRBkt>();
                        List<PTranslation> ptranslationlist = isOn(1, index - 68) ? Pop<List<PTranslation>>() : new List<PTranslation>();
                        TLBkt tlbkt = Pop<TLBkt>();
                        List<PTranslation> ptranslationlist2 = new List<PTranslation>();
                        ptranslationlist2.AddRange(ptranslationlist);
                        AListTranslation alisttranslation = new AListTranslation(
                            tlbkt,
                            ptranslationlist2,
                            trbkt
                        );
                        Push(28, alisttranslation);
                    }
                    break;
                case 70:
                case 71:
                    {
                        List<PTranslation> ptranslationlist = isOn(1, index - 70) ? Pop<List<PTranslation>>() : new List<PTranslation>();
                        PTranslation ptranslation = Pop<PTranslation>();
                        List<PTranslation> ptranslationlist2 = new List<PTranslation>();
                        ptranslationlist2.Add(ptranslation);
                        ptranslationlist2.AddRange(ptranslationlist);
                        Push(29, ptranslationlist2);
                    }
                    break;
                case 72:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        TComma tcomma = Pop<TComma>();
                        Push(30, ptranslation);
                    }
                    break;
                case 73:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AIdTranslation aidtranslation = new AIdTranslation(
                            tidentifier
                        );
                        Push(31, aidtranslation);
                    }
                    break;
                case 74:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TIdentifier tidentifier2 = Pop<TIdentifier>();
                        AIddotidTranslation aiddotidtranslation = new AIddotidTranslation(
                            tidentifier2,
                            tdot,
                            tidentifier
                        );
                        Push(31, aiddotidtranslation);
                    }
                    break;
                case 75:
                case 76:
                case 77:
                case 78:
                case 79:
                case 80:
                case 81:
                case 82:
                    {
                        PTranslation ptranslation = isOn(4, index - 75) ? Pop<PTranslation>() : null;
                        List<PElement> pelementlist = isOn(2, index - 75) ? Pop<List<PElement>>() : new List<PElement>();
                        PAlternativename palternativename = isOn(1, index - 75) ? Pop<PAlternativename>() : null;
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AAlternative aalternative = new AAlternative(
                            palternativename,
                            pelementlist2,
                            ptranslation
                        );
                        List<PAlternative> palternativelist = new List<PAlternative>();
                        palternativelist.Add(aalternative);
                        Push(32, palternativelist);
                    }
                    break;
                case 83:
                case 84:
                case 85:
                case 86:
                case 87:
                case 88:
                case 89:
                case 90:
                    {
                        List<PAlternative> palternativelist = Pop<List<PAlternative>>();
                        PTranslation ptranslation = isOn(4, index - 83) ? Pop<PTranslation>() : null;
                        List<PElement> pelementlist = isOn(2, index - 83) ? Pop<List<PElement>>() : new List<PElement>();
                        PAlternativename palternativename = isOn(1, index - 83) ? Pop<PAlternativename>() : null;
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
                        Push(32, palternativelist2);
                    }
                    break;
                case 91:
                case 92:
                case 93:
                case 94:
                case 95:
                case 96:
                case 97:
                case 98:
                    {
                        PTranslation ptranslation = isOn(4, index - 91) ? Pop<PTranslation>() : null;
                        List<PElement> pelementlist = isOn(2, index - 91) ? Pop<List<PElement>>() : new List<PElement>();
                        PAlternativename palternativename = isOn(1, index - 91) ? Pop<PAlternativename>() : null;
                        TPipe tpipe = Pop<TPipe>();
                        List<PElement> pelementlist2 = new List<PElement>();
                        pelementlist2.AddRange(pelementlist);
                        AAlternative aalternative = new AAlternative(
                            palternativename,
                            pelementlist2,
                            ptranslation
                        );
                        Push(33, aalternative);
                    }
                    break;
                case 99:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AAlternativename aalternativename = new AAlternativename(
                            tlbrace,
                            tidentifier,
                            trbrace
                        );
                        Push(34, aalternativename);
                    }
                    break;
                case 100:
                case 101:
                case 102:
                case 103:
                    {
                        PModifier pmodifier = isOn(2, index - 100) ? Pop<PModifier>() : null;
                        PElementid pelementid = Pop<PElementid>();
                        PElementname pelementname = isOn(1, index - 100) ? Pop<PElementname>() : null;
                        AElement aelement = new AElement(
                            pelementname,
                            pelementid,
                            pmodifier
                        );
                        Push(35, aelement);
                    }
                    break;
                case 104:
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
                        Push(36, aelementname);
                    }
                    break;
                case 105:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        ACleanElementid acleanelementid = new ACleanElementid(
                            tidentifier
                        );
                        Push(37, acleanelementid);
                    }
                    break;
                case 106:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TTokenSpecifier ttokenspecifier = Pop<TTokenSpecifier>();
                        ATokenElementid atokenelementid = new ATokenElementid(
                            ttokenspecifier,
                            tdot,
                            tidentifier
                        );
                        Push(37, atokenelementid);
                    }
                    break;
                case 107:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TProductionSpecifier tproductionspecifier = Pop<TProductionSpecifier>();
                        AProductionElementid aproductionelementid = new AProductionElementid(
                            tproductionspecifier,
                            tdot,
                            tidentifier
                        );
                        Push(37, aproductionelementid);
                    }
                    break;
                case 108:
                    {
                        List<PProduction> pproductionlist = Pop<List<PProduction>>();
                        TAsttoken tasttoken = Pop<TAsttoken>();
                        List<PProduction> pproductionlist2 = new List<PProduction>();
                        pproductionlist2.AddRange(pproductionlist);
                        AAstproductions aastproductions = new AAstproductions(
                            tasttoken,
                            pproductionlist2
                        );
                        Push(38, aastproductions);
                    }
                    break;
                case 109:
                    {
                        List<PHighlightrule> phighlightrulelist = Pop<List<PHighlightrule>>();
                        THighlighttoken thighlighttoken = Pop<THighlighttoken>();
                        List<PHighlightrule> phighlightrulelist2 = new List<PHighlightrule>();
                        phighlightrulelist2.AddRange(phighlightrulelist);
                        AHighlightrules ahighlightrules = new AHighlightrules(
                            thighlighttoken,
                            phighlightrulelist2
                        );
                        Push(39, ahighlightrules);
                    }
                    break;
                case 110:
                    {
                        TSemicolon tsemicolon = Pop<TSemicolon>();
                        List<PHighlightStyle> phighlightstylelist = Pop<List<PHighlightStyle>>();
                        TRBrace trbrace = Pop<TRBrace>();
                        List<TIdentifier> tidentifierlist = Pop<List<TIdentifier>>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        List<TIdentifier> tidentifierlist2 = new List<TIdentifier>();
                        tidentifierlist2.AddRange(tidentifierlist);
                        List<PHighlightStyle> phighlightstylelist2 = new List<PHighlightStyle>();
                        phighlightstylelist2.AddRange(phighlightstylelist);
                        AHighlightrule ahighlightrule = new AHighlightrule(
                            tidentifier,
                            tlbrace,
                            tidentifierlist2,
                            trbrace,
                            phighlightstylelist2,
                            tsemicolon
                        );
                        Push(40, ahighlightrule);
                    }
                    break;
                case 111:
                case 112:
                    {
                        List<PHighlightStyle> phighlightstylelist = isOn(1, index - 111) ? Pop<List<PHighlightStyle>>() : new List<PHighlightStyle>();
                        PHighlightStyle phighlightstyle = Pop<PHighlightStyle>();
                        List<PHighlightStyle> phighlightstylelist2 = new List<PHighlightStyle>();
                        phighlightstylelist2.Add(phighlightstyle);
                        phighlightstylelist2.AddRange(phighlightstylelist);
                        Push(41, phighlightstylelist2);
                    }
                    break;
                case 113:
                    {
                        PHighlightStyle phighlightstyle = Pop<PHighlightStyle>();
                        TComma tcomma = Pop<TComma>();
                        Push(42, phighlightstyle);
                    }
                    break;
                case 114:
                    {
                        TItalic titalic = Pop<TItalic>();
                        AItalicHighlightStyle aitalichighlightstyle = new AItalicHighlightStyle(
                            titalic
                        );
                        Push(43, aitalichighlightstyle);
                    }
                    break;
                case 115:
                    {
                        TBold tbold = Pop<TBold>();
                        ABoldHighlightStyle aboldhighlightstyle = new ABoldHighlightStyle(
                            tbold
                        );
                        Push(43, aboldhighlightstyle);
                    }
                    break;
                case 116:
                    {
                        PColor pcolor = Pop<PColor>();
                        TColon tcolon = Pop<TColon>();
                        TText ttext = Pop<TText>();
                        ATextHighlightStyle atexthighlightstyle = new ATextHighlightStyle(
                            ttext,
                            tcolon,
                            pcolor
                        );
                        Push(43, atexthighlightstyle);
                    }
                    break;
                case 117:
                    {
                        PColor pcolor = Pop<PColor>();
                        TColon tcolon = Pop<TColon>();
                        TBackground tbackground = Pop<TBackground>();
                        ABackgroundHighlightStyle abackgroundhighlightstyle = new ABackgroundHighlightStyle(
                            tbackground,
                            tcolon,
                            pcolor
                        );
                        Push(43, abackgroundhighlightstyle);
                    }
                    break;
                case 118:
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
                        Push(44, argbcolor);
                    }
                    break;
                case 119:
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
                        Push(44, ahsvcolor);
                    }
                    break;
                case 120:
                    {
                        THexColor thexcolor = Pop<THexColor>();
                        AHexColor ahexcolor = new AHexColor(
                            thexcolor
                        );
                        Push(44, ahexcolor);
                    }
                    break;
                case 121:
                    Push(45, new List<PSection>() { Pop<PSection>() });
                    break;
                case 122:
                    {
                        PSection item = Pop<PSection>();
                        List<PSection> list = Pop<List<PSection>>();
                        list.Add(item);
                        Push(45, list);
                    }
                    break;
                case 123:
                    Push(46, new List<PHelper>() { Pop<PHelper>() });
                    break;
                case 124:
                    {
                        PHelper item = Pop<PHelper>();
                        List<PHelper> list = Pop<List<PHelper>>();
                        list.Add(item);
                        Push(46, list);
                    }
                    break;
                case 125:
                    Push(47, new List<PState>() { Pop<PState>() });
                    break;
                case 126:
                    {
                        PState item = Pop<PState>();
                        List<PState> list = Pop<List<PState>>();
                        list.Add(item);
                        Push(47, list);
                    }
                    break;
                case 127:
                    Push(48, new List<TIdentifier>() { Pop<TIdentifier>() });
                    break;
                case 128:
                    {
                        TIdentifier item = Pop<TIdentifier>();
                        List<TIdentifier> list = Pop<List<TIdentifier>>();
                        list.Add(item);
                        Push(48, list);
                    }
                    break;
                case 129:
                    Push(49, new List<PToken>() { Pop<PToken>() });
                    break;
                case 130:
                    {
                        PToken item = Pop<PToken>();
                        List<PToken> list = Pop<List<PToken>>();
                        list.Add(item);
                        Push(49, list);
                    }
                    break;
                case 131:
                    Push(50, new List<PTokenState>() { Pop<PTokenState>() });
                    break;
                case 132:
                    {
                        PTokenState item = Pop<PTokenState>();
                        List<PTokenState> list = Pop<List<PTokenState>>();
                        list.Add(item);
                        Push(50, list);
                    }
                    break;
                case 133:
                    Push(51, new List<PRegex>() { Pop<PRegex>() });
                    break;
                case 134:
                    {
                        PRegex item = Pop<PRegex>();
                        List<PRegex> list = Pop<List<PRegex>>();
                        list.Add(item);
                        Push(51, list);
                    }
                    break;
                case 135:
                    Push(52, new List<PRegex>() { Pop<PRegex>() });
                    break;
                case 136:
                    {
                        PRegex item = Pop<PRegex>();
                        List<PRegex> list = Pop<List<PRegex>>();
                        list.Add(item);
                        Push(52, list);
                    }
                    break;
                case 137:
                    Push(53, new List<PProduction>() { Pop<PProduction>() });
                    break;
                case 138:
                    {
                        PProduction item = Pop<PProduction>();
                        List<PProduction> list = Pop<List<PProduction>>();
                        list.Add(item);
                        Push(53, list);
                    }
                    break;
                case 139:
                    Push(54, new List<PTranslation>() { Pop<PTranslation>() });
                    break;
                case 140:
                    {
                        PTranslation item = Pop<PTranslation>();
                        List<PTranslation> list = Pop<List<PTranslation>>();
                        list.Add(item);
                        Push(54, list);
                    }
                    break;
                case 141:
                    Push(55, new List<PElement>() { Pop<PElement>() });
                    break;
                case 142:
                    {
                        PElement item = Pop<PElement>();
                        List<PElement> list = Pop<List<PElement>>();
                        list.Add(item);
                        Push(55, list);
                    }
                    break;
                case 143:
                    Push(56, new List<PAlternative>() { Pop<PAlternative>() });
                    break;
                case 144:
                    {
                        PAlternative item = Pop<PAlternative>();
                        List<PAlternative> list = Pop<List<PAlternative>>();
                        list.Add(item);
                        Push(56, list);
                    }
                    break;
                case 145:
                    Push(57, new List<PHighlightrule>() { Pop<PHighlightrule>() });
                    break;
                case 146:
                    {
                        PHighlightrule item = Pop<PHighlightrule>();
                        List<PHighlightrule> list = Pop<List<PHighlightrule>>();
                        list.Add(item);
                        Push(57, list);
                    }
                    break;
                case 147:
                    Push(58, new List<PHighlightStyle>() { Pop<PHighlightStyle>() });
                    break;
                case 148:
                    {
                        PHighlightStyle item = Pop<PHighlightStyle>();
                        List<PHighlightStyle> list = Pop<List<PHighlightStyle>>();
                        list.Add(item);
                        Push(58, list);
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
                new int[] {0, 0, 20},
            },
            new int[][] {
                new int[] {-1, 3, 2},
                new int[] {32, 0, 21},
            },
            new int[][] {
                new int[] {-1, 3, 3},
                new int[] {32, 0, 23},
            },
            new int[][] {
                new int[] {-1, 3, 4},
                new int[] {21, 0, 26},
                new int[] {32, 0, 27},
            },
            new int[][] {
                new int[] {-1, 3, 5},
                new int[] {4, 0, 31},
            },
            new int[][] {
                new int[] {-1, 3, 6},
                new int[] {32, 0, 32},
            },
            new int[][] {
                new int[] {-1, 3, 7},
                new int[] {32, 0, 32},
            },
            new int[][] {
                new int[] {-1, 3, 8},
                new int[] {32, 0, 36},
            },
            new int[][] {
                new int[] {-1, 3, 9},
                new int[] {44, 2, -1},
            },
            new int[][] {
                new int[] {-1, 1, 121},
            },
            new int[][] {
                new int[] {-1, 1, 2},
            },
            new int[][] {
                new int[] {-1, 1, 3},
            },
            new int[][] {
                new int[] {-1, 1, 4},
            },
            new int[][] {
                new int[] {-1, 1, 5},
            },
            new int[][] {
                new int[] {-1, 1, 6},
            },
            new int[][] {
                new int[] {-1, 1, 7},
            },
            new int[][] {
                new int[] {-1, 1, 8},
            },
            new int[][] {
                new int[] {-1, 1, 9},
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
                new int[] {-1, 3, 20},
                new int[] {15, 0, 40},
            },
            new int[][] {
                new int[] {-1, 1, 14},
                new int[] {28, 0, 41},
            },
            new int[][] {
                new int[] {-1, 3, 22},
                new int[] {15, 0, 44},
            },
            new int[][] {
                new int[] {-1, 3, 23},
                new int[] {16, 0, 45},
            },
            new int[][] {
                new int[] {-1, 1, 123},
            },
            new int[][] {
                new int[] {-1, 1, 11},
                new int[] {32, 0, 23},
            },
            new int[][] {
                new int[] {-1, 3, 26},
                new int[] {32, 0, 47},
            },
            new int[][] {
                new int[] {-1, 3, 27},
                new int[] {16, 0, 48},
            },
            new int[][] {
                new int[] {-1, 1, 129},
            },
            new int[][] {
                new int[] {-1, 3, 29},
                new int[] {32, 0, 49},
            },
            new int[][] {
                new int[] {-1, 1, 20},
                new int[] {21, 0, 26},
                new int[] {32, 0, 27},
            },
            new int[][] {
                new int[] {-1, 3, 31},
                new int[] {32, 0, 51},
            },
            new int[][] {
                new int[] {-1, 3, 32},
                new int[] {16, 0, 53},
                new int[] {21, 0, 54},
                new int[] {30, 0, 55},
            },
            new int[][] {
                new int[] {-1, 1, 137},
            },
            new int[][] {
                new int[] {-1, 1, 53},
                new int[] {32, 0, 32},
            },
            new int[][] {
                new int[] {-1, 1, 108},
                new int[] {32, 0, 32},
            },
            new int[][] {
                new int[] {-1, 3, 36},
                new int[] {21, 0, 58},
            },
            new int[][] {
                new int[] {-1, 1, 145},
            },
            new int[][] {
                new int[] {-1, 1, 109},
                new int[] {32, 0, 36},
            },
            new int[][] {
                new int[] {-1, 1, 122},
            },
            new int[][] {
                new int[] {-1, 1, 10},
            },
            new int[][] {
                new int[] {-1, 3, 41},
                new int[] {32, 0, 60},
            },
            new int[][] {
                new int[] {-1, 1, 125},
            },
            new int[][] {
                new int[] {-1, 1, 15},
                new int[] {28, 0, 41},
            },
            new int[][] {
                new int[] {-1, 1, 13},
            },
            new int[][] {
                new int[] {-1, 3, 45},
                new int[] {17, 0, 62},
                new int[] {19, 0, 63},
                new int[] {32, 0, 64},
                new int[] {33, 0, 65},
                new int[] {34, 0, 66},
                new int[] {35, 0, 67},
                new int[] {36, 0, 68},
            },
            new int[][] {
                new int[] {-1, 1, 124},
            },
            new int[][] {
                new int[] {-1, 3, 47},
                new int[] {22, 0, 76},
                new int[] {28, 0, 77},
                new int[] {30, 0, 78},
            },
            new int[][] {
                new int[] {-1, 3, 48},
                new int[] {17, 0, 62},
                new int[] {19, 0, 63},
                new int[] {32, 0, 64},
                new int[] {33, 0, 65},
                new int[] {34, 0, 66},
                new int[] {35, 0, 67},
                new int[] {36, 0, 68},
            },
            new int[][] {
                new int[] {-1, 3, 49},
                new int[] {16, 0, 82},
            },
            new int[][] {
                new int[] {-1, 1, 130},
            },
            new int[][] {
                new int[] {-1, 1, 17},
                new int[] {28, 0, 83},
            },
            new int[][] {
                new int[] {-1, 3, 52},
                new int[] {15, 0, 86},
            },
            new int[][] {
                new int[] {-1, 1, 75},
                new int[] {11, 0, 87},
                new int[] {12, 0, 88},
                new int[] {17, 0, 89},
                new int[] {21, 0, 90},
                new int[] {27, 0, 91},
                new int[] {30, 0, 92},
                new int[] {32, 0, 93},
            },
            new int[][] {
                new int[] {-1, 3, 54},
                new int[] {30, 0, 103},
            },
            new int[][] {
                new int[] {-1, 3, 55},
                new int[] {32, 0, 104},
            },
            new int[][] {
                new int[] {-1, 3, 56},
                new int[] {16, 0, 105},
            },
            new int[][] {
                new int[] {-1, 1, 138},
            },
            new int[][] {
                new int[] {-1, 3, 58},
                new int[] {32, 0, 51},
            },
            new int[][] {
                new int[] {-1, 1, 146},
            },
            new int[][] {
                new int[] {-1, 1, 16},
            },
            new int[][] {
                new int[] {-1, 1, 126},
            },
            new int[][] {
                new int[] {-1, 3, 62},
                new int[] {17, 0, 62},
                new int[] {19, 0, 63},
                new int[] {32, 0, 64},
                new int[] {33, 0, 65},
                new int[] {34, 0, 66},
                new int[] {35, 0, 67},
                new int[] {36, 0, 68},
            },
            new int[][] {
                new int[] {-1, 3, 63},
                new int[] {17, 0, 62},
                new int[] {19, 0, 63},
                new int[] {32, 0, 64},
                new int[] {33, 0, 65},
                new int[] {34, 0, 66},
                new int[] {35, 0, 67},
                new int[] {36, 0, 68},
            },
            new int[][] {
                new int[] {-1, 1, 45},
            },
            new int[][] {
                new int[] {-1, 1, 47},
            },
            new int[][] {
                new int[] {-1, 1, 48},
            },
            new int[][] {
                new int[] {-1, 1, 49},
            },
            new int[][] {
                new int[] {-1, 1, 44},
            },
            new int[][] {
                new int[] {-1, 3, 69},
                new int[] {15, 0, 110},
            },
            new int[][] {
                new int[] {-1, 1, 33},
                new int[] {27, 0, 111},
            },
            new int[][] {
                new int[] {-1, 1, 135},
            },
            new int[][] {
                new int[] {-1, 1, 40},
                new int[] {23, 0, 114},
                new int[] {25, 0, 115},
                new int[] {26, 0, 116},
            },
            new int[][] {
                new int[] {-1, 1, 42},
            },
            new int[][] {
                new int[] {-1, 1, 43},
            },
            new int[][] {
                new int[] {-1, 1, 36},
                new int[] {17, 0, 62},
                new int[] {19, 0, 63},
                new int[] {32, 0, 64},
                new int[] {33, 0, 65},
                new int[] {34, 0, 66},
                new int[] {35, 0, 67},
                new int[] {36, 0, 68},
            },
            new int[][] {
                new int[] {-1, 1, 25},
            },
            new int[][] {
                new int[] {-1, 3, 77},
                new int[] {32, 0, 119},
            },
            new int[][] {
                new int[] {-1, 3, 78},
                new int[] {32, 0, 120},
            },
            new int[][] {
                new int[] {-1, 1, 131},
            },
            new int[][] {
                new int[] {-1, 3, 80},
                new int[] {22, 0, 121},
                new int[] {28, 0, 77},
            },
            new int[][] {
                new int[] {-1, 3, 81},
                new int[] {15, 0, 123},
                new int[] {29, 0, 124},
            },
            new int[][] {
                new int[] {-1, 3, 82},
                new int[] {17, 0, 62},
                new int[] {19, 0, 63},
                new int[] {32, 0, 64},
                new int[] {33, 0, 65},
                new int[] {34, 0, 66},
                new int[] {35, 0, 67},
                new int[] {36, 0, 68},
            },
            new int[][] {
                new int[] {-1, 3, 83},
                new int[] {32, 0, 127},
            },
            new int[][] {
                new int[] {-1, 1, 127},
            },
            new int[][] {
                new int[] {-1, 1, 18},
                new int[] {28, 0, 83},
            },
            new int[][] {
                new int[] {-1, 1, 31},
            },
            new int[][] {
                new int[] {-1, 3, 87},
                new int[] {13, 0, 129},
            },
            new int[][] {
                new int[] {-1, 3, 88},
                new int[] {13, 0, 130},
            },
            new int[][] {
                new int[] {-1, 3, 89},
                new int[] {32, 0, 131},
            },
            new int[][] {
                new int[] {-1, 3, 90},
                new int[] {30, 0, 132},
                new int[] {32, 0, 133},
            },
            new int[][] {
                new int[] {-1, 1, 91},
                new int[] {11, 0, 87},
                new int[] {12, 0, 88},
                new int[] {17, 0, 89},
                new int[] {21, 0, 90},
                new int[] {30, 0, 92},
                new int[] {32, 0, 93},
            },
            new int[][] {
                new int[] {-1, 3, 92},
                new int[] {9, 0, 137},
                new int[] {10, 0, 138},
                new int[] {17, 0, 139},
                new int[] {32, 0, 140},
            },
            new int[][] {
                new int[] {-1, 1, 105},
            },
            new int[][] {
                new int[] {-1, 1, 79},
                new int[] {27, 0, 91},
            },
            new int[][] {
                new int[] {-1, 3, 95},
                new int[] {15, 0, 144},
            },
            new int[][] {
                new int[] {-1, 1, 143},
            },
            new int[][] {
                new int[] {-1, 1, 76},
                new int[] {11, 0, 87},
                new int[] {12, 0, 88},
                new int[] {17, 0, 89},
                new int[] {21, 0, 145},
                new int[] {27, 0, 91},
                new int[] {30, 0, 92},
                new int[] {32, 0, 93},
            },
            new int[][] {
                new int[] {-1, 1, 141},
            },
            new int[][] {
                new int[] {-1, 3, 99},
                new int[] {11, 0, 87},
                new int[] {12, 0, 88},
                new int[] {32, 0, 93},
            },
            new int[][] {
                new int[] {-1, 1, 100},
                new int[] {23, 0, 114},
                new int[] {25, 0, 115},
                new int[] {26, 0, 116},
            },
            new int[][] {
                new int[] {-1, 1, 77},
                new int[] {11, 0, 87},
                new int[] {12, 0, 88},
                new int[] {17, 0, 89},
                new int[] {21, 0, 145},
                new int[] {27, 0, 91},
                new int[] {30, 0, 92},
                new int[] {32, 0, 93},
            },
            new int[][] {
                new int[] {-1, 1, 83},
                new int[] {27, 0, 91},
            },
            new int[][] {
                new int[] {-1, 3, 103},
                new int[] {32, 0, 155},
            },
            new int[][] {
                new int[] {-1, 1, 58},
                new int[] {23, 0, 114},
                new int[] {25, 0, 115},
                new int[] {26, 0, 116},
            },
            new int[][] {
                new int[] {-1, 1, 75},
                new int[] {11, 0, 87},
                new int[] {12, 0, 88},
                new int[] {17, 0, 89},
                new int[] {21, 0, 90},
                new int[] {27, 0, 91},
                new int[] {30, 0, 92},
                new int[] {32, 0, 93},
            },
            new int[][] {
                new int[] {-1, 3, 106},
                new int[] {22, 0, 158},
            },
            new int[][] {
                new int[] {-1, 3, 107},
                new int[] {23, 0, 159},
                new int[] {24, 0, 160},
            },
            new int[][] {
                new int[] {-1, 1, 42},
                new int[] {14, 0, 161},
            },
            new int[][] {
                new int[] {-1, 3, 109},
                new int[] {20, 0, 162},
            },
            new int[][] {
                new int[] {-1, 1, 12},
            },
            new int[][] {
                new int[] {-1, 3, 111},
                new int[] {17, 0, 62},
                new int[] {19, 0, 63},
                new int[] {32, 0, 64},
                new int[] {33, 0, 65},
                new int[] {34, 0, 66},
                new int[] {35, 0, 67},
                new int[] {36, 0, 68},
            },
            new int[][] {
                new int[] {-1, 1, 133},
            },
            new int[][] {
                new int[] {-1, 1, 34},
                new int[] {27, 0, 111},
            },
            new int[][] {
                new int[] {-1, 1, 39},
            },
            new int[][] {
                new int[] {-1, 1, 38},
            },
            new int[][] {
                new int[] {-1, 1, 37},
            },
            new int[][] {
                new int[] {-1, 1, 41},
            },
            new int[][] {
                new int[] {-1, 1, 136},
            },
            new int[][] {
                new int[] {-1, 1, 29},
                new int[] {30, 0, 165},
            },
            new int[][] {
                new int[] {-1, 3, 120},
                new int[] {22, 0, 166},
                new int[] {28, 0, 77},
            },
            new int[][] {
                new int[] {-1, 1, 26},
            },
            new int[][] {
                new int[] {-1, 1, 132},
            },
            new int[][] {
                new int[] {-1, 1, 21},
            },
            new int[][] {
                new int[] {-1, 3, 124},
                new int[] {17, 0, 62},
                new int[] {19, 0, 63},
                new int[] {32, 0, 64},
                new int[] {33, 0, 65},
                new int[] {34, 0, 66},
                new int[] {35, 0, 67},
                new int[] {36, 0, 68},
            },
            new int[][] {
                new int[] {-1, 3, 125},
                new int[] {15, 0, 169},
            },
            new int[][] {
                new int[] {-1, 3, 126},
                new int[] {15, 0, 170},
                new int[] {29, 0, 124},
            },
            new int[][] {
                new int[] {-1, 1, 19},
            },
            new int[][] {
                new int[] {-1, 1, 128},
            },
            new int[][] {
                new int[] {-1, 3, 129},
                new int[] {32, 0, 172},
            },
            new int[][] {
                new int[] {-1, 3, 130},
                new int[] {32, 0, 173},
            },
            new int[][] {
                new int[] {-1, 3, 131},
                new int[] {18, 0, 174},
            },
            new int[][] {
                new int[] {-1, 3, 132},
                new int[] {9, 0, 137},
                new int[] {10, 0, 138},
                new int[] {17, 0, 139},
                new int[] {32, 0, 140},
            },
            new int[][] {
                new int[] {-1, 3, 133},
                new int[] {22, 0, 176},
            },
            new int[][] {
                new int[] {-1, 1, 95},
            },
            new int[][] {
                new int[] {-1, 1, 92},
                new int[] {11, 0, 87},
                new int[] {12, 0, 88},
                new int[] {17, 0, 89},
                new int[] {21, 0, 145},
                new int[] {30, 0, 92},
                new int[] {32, 0, 93},
            },
            new int[][] {
                new int[] {-1, 1, 93},
                new int[] {11, 0, 87},
                new int[] {12, 0, 88},
                new int[] {17, 0, 89},
                new int[] {21, 0, 145},
                new int[] {30, 0, 92},
                new int[] {32, 0, 93},
            },
            new int[][] {
                new int[] {-1, 3, 137},
                new int[] {32, 0, 180},
            },
            new int[][] {
                new int[] {-1, 1, 67},
            },
            new int[][] {
                new int[] {-1, 3, 139},
                new int[] {9, 0, 137},
                new int[] {10, 0, 138},
                new int[] {17, 0, 139},
                new int[] {18, 0, 181},
                new int[] {32, 0, 140},
            },
            new int[][] {
                new int[] {-1, 1, 73},
                new int[] {13, 0, 184},
            },
            new int[][] {
                new int[] {-1, 1, 61},
            },
            new int[][] {
                new int[] {-1, 1, 62},
            },
            new int[][] {
                new int[] {-1, 1, 87},
                new int[] {27, 0, 91},
            },
            new int[][] {
                new int[] {-1, 1, 54},
            },
            new int[][] {
                new int[] {-1, 3, 145},
                new int[] {30, 0, 132},
            },
            new int[][] {
                new int[] {-1, 1, 80},
                new int[] {27, 0, 91},
            },
            new int[][] {
                new int[] {-1, 1, 78},
                new int[] {11, 0, 87},
                new int[] {12, 0, 88},
                new int[] {17, 0, 89},
                new int[] {21, 0, 145},
                new int[] {27, 0, 91},
                new int[] {30, 0, 92},
                new int[] {32, 0, 93},
            },
            new int[][] {
                new int[] {-1, 1, 84},
                new int[] {27, 0, 91},
            },
            new int[][] {
                new int[] {-1, 1, 101},
                new int[] {23, 0, 114},
                new int[] {25, 0, 115},
                new int[] {26, 0, 116},
            },
            new int[][] {
                new int[] {-1, 1, 102},
            },
            new int[][] {
                new int[] {-1, 1, 81},
                new int[] {27, 0, 91},
            },
            new int[][] {
                new int[] {-1, 1, 142},
            },
            new int[][] {
                new int[] {-1, 1, 85},
                new int[] {27, 0, 91},
            },
            new int[][] {
                new int[] {-1, 1, 144},
            },
            new int[][] {
                new int[] {-1, 3, 155},
                new int[] {22, 0, 190},
                new int[] {23, 0, 114},
                new int[] {25, 0, 115},
                new int[] {26, 0, 116},
            },
            new int[][] {
                new int[] {-1, 1, 59},
            },
            new int[][] {
                new int[] {-1, 3, 157},
                new int[] {15, 0, 192},
            },
            new int[][] {
                new int[] {-1, 3, 158},
                new int[] {37, 0, 193},
                new int[] {38, 0, 194},
                new int[] {39, 0, 195},
                new int[] {40, 0, 196},
            },
            new int[][] {
                new int[] {-1, 3, 159},
                new int[] {17, 0, 62},
                new int[] {19, 0, 63},
                new int[] {32, 0, 64},
                new int[] {33, 0, 65},
                new int[] {34, 0, 66},
                new int[] {35, 0, 67},
                new int[] {36, 0, 68},
            },
            new int[][] {
                new int[] {-1, 3, 160},
                new int[] {17, 0, 62},
                new int[] {19, 0, 63},
                new int[] {32, 0, 64},
                new int[] {33, 0, 65},
                new int[] {34, 0, 66},
                new int[] {35, 0, 67},
                new int[] {36, 0, 68},
            },
            new int[][] {
                new int[] {-1, 3, 161},
                new int[] {33, 0, 65},
                new int[] {34, 0, 66},
                new int[] {35, 0, 67},
            },
            new int[][] {
                new int[] {-1, 1, 46},
            },
            new int[][] {
                new int[] {-1, 1, 35},
            },
            new int[][] {
                new int[] {-1, 1, 134},
            },
            new int[][] {
                new int[] {-1, 3, 165},
                new int[] {32, 0, 202},
            },
            new int[][] {
                new int[] {-1, 1, 27},
            },
            new int[][] {
                new int[] {-1, 3, 167},
                new int[] {22, 0, 203},
                new int[] {28, 0, 77},
            },
            new int[][] {
                new int[] {-1, 1, 32},
            },
            new int[][] {
                new int[] {-1, 1, 22},
            },
            new int[][] {
                new int[] {-1, 1, 23},
            },
            new int[][] {
                new int[] {-1, 3, 171},
                new int[] {15, 0, 204},
            },
            new int[][] {
                new int[] {-1, 1, 106},
            },
            new int[][] {
                new int[] {-1, 1, 107},
            },
            new int[][] {
                new int[] {-1, 3, 174},
                new int[] {31, 0, 205},
            },
            new int[][] {
                new int[] {-1, 3, 175},
                new int[] {22, 0, 206},
            },
            new int[][] {
                new int[] {-1, 1, 99},
            },
            new int[][] {
                new int[] {-1, 1, 96},
            },
            new int[][] {
                new int[] {-1, 1, 94},
                new int[] {11, 0, 87},
                new int[] {12, 0, 88},
                new int[] {17, 0, 89},
                new int[] {21, 0, 145},
                new int[] {30, 0, 92},
                new int[] {32, 0, 93},
            },
            new int[][] {
                new int[] {-1, 1, 97},
            },
            new int[][] {
                new int[] {-1, 3, 180},
                new int[] {13, 0, 208},
                new int[] {19, 0, 209},
            },
            new int[][] {
                new int[] {-1, 1, 68},
            },
            new int[][] {
                new int[] {-1, 1, 70},
                new int[] {28, 0, 210},
            },
            new int[][] {
                new int[] {-1, 3, 183},
                new int[] {18, 0, 213},
            },
            new int[][] {
                new int[] {-1, 3, 184},
                new int[] {32, 0, 214},
            },
            new int[][] {
                new int[] {-1, 1, 88},
                new int[] {27, 0, 91},
            },
            new int[][] {
                new int[] {-1, 1, 82},
                new int[] {27, 0, 91},
            },
            new int[][] {
                new int[] {-1, 1, 86},
                new int[] {27, 0, 91},
            },
            new int[][] {
                new int[] {-1, 1, 103},
            },
            new int[][] {
                new int[] {-1, 1, 89},
                new int[] {27, 0, 91},
            },
            new int[][] {
                new int[] {-1, 1, 56},
            },
            new int[][] {
                new int[] {-1, 3, 191},
                new int[] {22, 0, 216},
            },
            new int[][] {
                new int[] {-1, 1, 55},
            },
            new int[][] {
                new int[] {-1, 1, 114},
            },
            new int[][] {
                new int[] {-1, 1, 115},
            },
            new int[][] {
                new int[] {-1, 3, 195},
                new int[] {31, 0, 217},
            },
            new int[][] {
                new int[] {-1, 3, 196},
                new int[] {31, 0, 218},
            },
            new int[][] {
                new int[] {-1, 3, 197},
                new int[] {15, 0, 219},
            },
            new int[][] {
                new int[] {-1, 1, 111},
                new int[] {28, 0, 220},
            },
            new int[][] {
                new int[] {-1, 3, 199},
                new int[] {18, 0, 223},
            },
            new int[][] {
                new int[] {-1, 3, 200},
                new int[] {18, 0, 224},
            },
            new int[][] {
                new int[] {-1, 3, 201},
                new int[] {18, 0, 225},
            },
            new int[][] {
                new int[] {-1, 1, 30},
            },
            new int[][] {
                new int[] {-1, 1, 28},
            },
            new int[][] {
                new int[] {-1, 1, 24},
            },
            new int[][] {
                new int[] {-1, 1, 104},
            },
            new int[][] {
                new int[] {-1, 1, 60},
            },
            new int[][] {
                new int[] {-1, 1, 98},
            },
            new int[][] {
                new int[] {-1, 3, 208},
                new int[] {32, 0, 226},
            },
            new int[][] {
                new int[] {-1, 3, 209},
                new int[] {9, 0, 137},
                new int[] {10, 0, 138},
                new int[] {17, 0, 139},
                new int[] {20, 0, 227},
                new int[] {32, 0, 140},
            },
            new int[][] {
                new int[] {-1, 3, 210},
                new int[] {9, 0, 137},
                new int[] {10, 0, 138},
                new int[] {17, 0, 139},
                new int[] {32, 0, 140},
            },
            new int[][] {
                new int[] {-1, 1, 139},
            },
            new int[][] {
                new int[] {-1, 1, 71},
                new int[] {28, 0, 210},
            },
            new int[][] {
                new int[] {-1, 1, 69},
            },
            new int[][] {
                new int[] {-1, 1, 74},
            },
            new int[][] {
                new int[] {-1, 1, 90},
                new int[] {27, 0, 91},
            },
            new int[][] {
                new int[] {-1, 1, 57},
            },
            new int[][] {
                new int[] {-1, 3, 217},
                new int[] {41, 0, 231},
                new int[] {42, 0, 232},
                new int[] {43, 0, 233},
            },
            new int[][] {
                new int[] {-1, 3, 218},
                new int[] {41, 0, 231},
                new int[] {42, 0, 232},
                new int[] {43, 0, 233},
            },
            new int[][] {
                new int[] {-1, 1, 110},
            },
            new int[][] {
                new int[] {-1, 3, 220},
                new int[] {37, 0, 193},
                new int[] {38, 0, 194},
                new int[] {39, 0, 195},
                new int[] {40, 0, 196},
            },
            new int[][] {
                new int[] {-1, 1, 147},
            },
            new int[][] {
                new int[] {-1, 1, 112},
                new int[] {28, 0, 220},
            },
            new int[][] {
                new int[] {-1, 1, 50},
            },
            new int[][] {
                new int[] {-1, 1, 51},
            },
            new int[][] {
                new int[] {-1, 1, 52},
            },
            new int[][] {
                new int[] {-1, 3, 226},
                new int[] {19, 0, 238},
            },
            new int[][] {
                new int[] {-1, 1, 63},
            },
            new int[][] {
                new int[] {-1, 3, 228},
                new int[] {20, 0, 239},
            },
            new int[][] {
                new int[] {-1, 1, 72},
            },
            new int[][] {
                new int[] {-1, 1, 140},
            },
            new int[][] {
                new int[] {-1, 3, 231},
                new int[] {19, 0, 240},
            },
            new int[][] {
                new int[] {-1, 3, 232},
                new int[] {19, 0, 241},
            },
            new int[][] {
                new int[] {-1, 1, 120},
            },
            new int[][] {
                new int[] {-1, 1, 116},
            },
            new int[][] {
                new int[] {-1, 1, 117},
            },
            new int[][] {
                new int[] {-1, 1, 113},
            },
            new int[][] {
                new int[] {-1, 1, 148},
            },
            new int[][] {
                new int[] {-1, 3, 238},
                new int[] {9, 0, 137},
                new int[] {10, 0, 138},
                new int[] {17, 0, 139},
                new int[] {20, 0, 242},
                new int[] {32, 0, 140},
            },
            new int[][] {
                new int[] {-1, 1, 64},
            },
            new int[][] {
                new int[] {-1, 3, 240},
                new int[] {34, 0, 244},
            },
            new int[][] {
                new int[] {-1, 3, 241},
                new int[] {34, 0, 245},
            },
            new int[][] {
                new int[] {-1, 1, 65},
            },
            new int[][] {
                new int[] {-1, 3, 243},
                new int[] {20, 0, 246},
            },
            new int[][] {
                new int[] {-1, 3, 244},
                new int[] {28, 0, 247},
            },
            new int[][] {
                new int[] {-1, 3, 245},
                new int[] {28, 0, 248},
            },
            new int[][] {
                new int[] {-1, 1, 66},
            },
            new int[][] {
                new int[] {-1, 3, 247},
                new int[] {34, 0, 249},
            },
            new int[][] {
                new int[] {-1, 3, 248},
                new int[] {34, 0, 250},
            },
            new int[][] {
                new int[] {-1, 3, 249},
                new int[] {28, 0, 251},
            },
            new int[][] {
                new int[] {-1, 3, 250},
                new int[] {28, 0, 252},
            },
            new int[][] {
                new int[] {-1, 3, 251},
                new int[] {34, 0, 253},
            },
            new int[][] {
                new int[] {-1, 3, 252},
                new int[] {34, 0, 254},
            },
            new int[][] {
                new int[] {-1, 3, 253},
                new int[] {20, 0, 255},
            },
            new int[][] {
                new int[] {-1, 3, 254},
                new int[] {20, 0, 256},
            },
            new int[][] {
                new int[] {-1, 1, 118},
            },
            new int[][] {
                new int[] {-1, 1, 119},
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
                new int[] {19, 39},
            },
            new int[][] {
                new int[] {-1, 11},
            },
            new int[][] {
                new int[] {-1, 12},
            },
            new int[][] {
                new int[] {-1, 24},
                new int[] {25, 46},
            },
            new int[][] {
                new int[] {-1, 13},
            },
            new int[][] {
                new int[] {-1, 22},
            },
            new int[][] {
                new int[] {-1, 42},
                new int[] {43, 61},
            },
            new int[][] {
                new int[] {-1, 52},
                new int[] {58, 106},
            },
            new int[][] {
                new int[] {-1, 84},
                new int[] {85, 128},
            },
            new int[][] {
                new int[] {-1, 14},
            },
            new int[][] {
                new int[] {-1, 28},
                new int[] {30, 50},
            },
            new int[][] {
                new int[] {-1, 29},
            },
            new int[][] {
                new int[] {-1, 79},
                new int[] {80, 122},
                new int[] {167, 122},
            },
            new int[][] {
                new int[] {-1, 15},
            },
            new int[][] {
                new int[] {-1, 125},
                new int[] {126, 171},
            },
            new int[][] {
                new int[] {-1, 69},
                new int[] {48, 81},
                new int[] {63, 109},
                new int[] {82, 126},
                new int[] {124, 168},
            },
            new int[][] {
                new int[] {-1, 112},
                new int[] {113, 164},
            },
            new int[][] {
                new int[] {-1, 70},
                new int[] {111, 163},
            },
            new int[][] {
                new int[] {-1, 117},
                new int[] {100, 150},
                new int[] {104, 156},
                new int[] {149, 188},
                new int[] {155, 191},
            },
            new int[][] {
                new int[] {-1, 71},
                new int[] {75, 118},
            },
            new int[][] {
                new int[] {-1, 72},
                new int[] {62, 107},
                new int[] {159, 199},
                new int[] {160, 200},
            },
            new int[][] {
                new int[] {-1, 73},
                new int[] {62, 108},
                new int[] {161, 201},
            },
            new int[][] {
                new int[] {-1, 74},
            },
            new int[][] {
                new int[] {-1, 16},
            },
            new int[][] {
                new int[] {-1, 33},
                new int[] {34, 57},
                new int[] {35, 57},
            },
            new int[][] {
                new int[] {-1, 56},
            },
            new int[][] {
                new int[] {-1, 94},
                new int[] {91, 134},
                new int[] {97, 146},
                new int[] {101, 151},
                new int[] {135, 177},
                new int[] {136, 179},
                new int[] {147, 186},
                new int[] {178, 207},
            },
            new int[][] {
                new int[] {-1, 182},
                new int[] {92, 141},
                new int[] {132, 175},
                new int[] {210, 229},
            },
            new int[][] {
                new int[] {-1, 183},
                new int[] {209, 228},
                new int[] {238, 243},
            },
            new int[][] {
                new int[] {-1, 211},
                new int[] {212, 230},
            },
            new int[][] {
                new int[] {-1, 142},
            },
            new int[][] {
                new int[] {-1, 95},
                new int[] {105, 157},
            },
            new int[][] {
                new int[] {-1, 96},
                new int[] {102, 154},
                new int[] {143, 154},
                new int[] {148, 154},
                new int[] {153, 154},
                new int[] {185, 154},
                new int[] {187, 154},
                new int[] {189, 154},
                new int[] {215, 154},
            },
            new int[][] {
                new int[] {-1, 97},
                new int[] {91, 135},
            },
            new int[][] {
                new int[] {-1, 98},
                new int[] {101, 152},
                new int[] {136, 152},
                new int[] {147, 152},
                new int[] {178, 152},
            },
            new int[][] {
                new int[] {-1, 99},
            },
            new int[][] {
                new int[] {-1, 100},
                new int[] {99, 149},
            },
            new int[][] {
                new int[] {-1, 17},
            },
            new int[][] {
                new int[] {-1, 18},
            },
            new int[][] {
                new int[] {-1, 37},
                new int[] {38, 59},
            },
            new int[][] {
                new int[] {-1, 197},
            },
            new int[][] {
                new int[] {-1, 221},
                new int[] {222, 237},
            },
            new int[][] {
                new int[] {-1, 198},
                new int[] {220, 236},
            },
            new int[][] {
                new int[] {-1, 234},
                new int[] {218, 235},
            },
            new int[][] {
                new int[] {-1, 19},
            },
            new int[][] {
                new int[] {-1, 25},
            },
            new int[][] {
                new int[] {-1, 43},
            },
            new int[][] {
                new int[] {-1, 85},
            },
            new int[][] {
                new int[] {-1, 30},
            },
            new int[][] {
                new int[] {-1, 80},
                new int[] {120, 167},
            },
            new int[][] {
                new int[] {-1, 113},
            },
            new int[][] {
                new int[] {-1, 75},
            },
            new int[][] {
                new int[] {-1, 34},
                new int[] {7, 35},
            },
            new int[][] {
                new int[] {-1, 212},
            },
            new int[][] {
                new int[] {-1, 101},
                new int[] {91, 136},
                new int[] {97, 147},
                new int[] {135, 178},
            },
            new int[][] {
                new int[] {-1, 102},
                new int[] {94, 143},
                new int[] {97, 148},
                new int[] {101, 153},
                new int[] {146, 185},
                new int[] {147, 187},
                new int[] {151, 189},
                new int[] {186, 215},
            },
            new int[][] {
                new int[] {-1, 38},
            },
            new int[][] {
                new int[] {-1, 222},
            },
        };
        #endregion
        #region errorMessages
        private static string[] errorMessages = {
            "Expecting: TPackagetoken, 'States', 'Helpers', 'Tokens', 'Ignored', 'Productions', TAsttoken, 'Token Syntax Highlight' or end of file",
            "Expecting: TPackagename",
            "Expecting: TIdentifier",
            "Expecting: '{' or TIdentifier",
            "Expecting: 'Tokens'",
            "Expecting: end of file",
            "Expecting: ';'",
            "Expecting: ';' or ','",
            "Expecting: '='",
            "Expecting: TPackagetoken, 'States', 'Helpers', 'Tokens', 'Ignored', 'Productions', TAsttoken, 'Token Syntax Highlight', TIdentifier or end of file",
            "Expecting: TPackagetoken, 'States', 'Helpers', 'Tokens', 'Ignored', 'Productions', TAsttoken, 'Token Syntax Highlight', '{', TIdentifier or end of file",
            "Expecting: '=', '{' or '->'",
            "Expecting: '{'",
            "Expecting: '[', '(', TIdentifier, TCharacter, TDecChar, THexChar or TString",
            "Expecting: '}', ',' or '->'",
            "Expecting: ';', '}' or ','",
            "Expecting: 'T', 'P', ';', '[', '{', '|', '->' or TIdentifier",
            "Expecting: '->'",
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
            "Expecting: '}'",
            "Expecting: '+' or '-'",
            "Expecting: '..', '+' or '-'",
            "Expecting: ')'",
            "Expecting: 'T', 'P', ';', '=', '[', '(', ')', '{', '}', '|', '/', '->', TIdentifier, TCharacter, TDecChar, THexChar or TString",
            "Expecting: ']'",
            "Expecting: ';', ']', ')', '}', '|' or ','",
            "Expecting: 'New', 'Null', '[', ']' or TIdentifier",
            "Expecting: '.', ';', ']', ')', '}', '|' or ','",
            "Expecting: '}', '+', '?' or '*'",
            "Expecting: 'italic', 'bold', 'text' or 'background'",
            "Expecting: TCharacter, TDecChar or THexChar",
            "Expecting: ':'",
            "Expecting: '.' or '('",
            "Expecting: ']', ')' or ','",
            "Expecting: 'New', 'Null', '[', ')' or TIdentifier",
            "Expecting: 'rgb', THsv or THexColor",
            "Expecting: '('",
            "Expecting: TDecChar",
            "Expecting: ','",
        };
        #endregion
        #region errors
        private static int[] errors = {
            0, 1, 2, 2, 3, 4, 2, 2, 2, 5, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 6, 7, 6, 8, 9, 9, 2, 8, 10, 2, 10, 2,
            11, 9, 9, 9, 12, 9, 9, 0, 0, 2, 7, 7, 0, 13, 9, 14,
            13, 8, 10, 15, 6, 16, 17, 2, 8, 9, 2, 9, 7, 7, 13, 13,
            18, 19, 19, 19, 18, 6, 20, 21, 22, 23, 18, 21, 2, 2, 2, 24,
            24, 25, 13, 2, 15, 15, 0, 26, 26, 2, 27, 16, 28, 29, 30, 6,
            30, 16, 16, 31, 29, 16, 30, 2, 32, 16, 33, 34, 35, 36, 9, 13,
            20, 20, 37, 37, 37, 21, 21, 14, 24, 2, 24, 10, 13, 6, 25, 15,
            15, 2, 2, 38, 28, 33, 30, 16, 16, 2, 39, 40, 41, 30, 39, 30,
            9, 17, 30, 16, 30, 29, 16, 30, 16, 30, 30, 42, 8, 6, 43, 13,
            13, 44, 18, 20, 20, 2, 2, 24, 6, 10, 10, 6, 29, 29, 45, 33,
            16, 30, 16, 30, 46, 39, 47, 38, 2, 30, 30, 30, 16, 30, 8, 33,
            9, 7, 7, 45, 45, 6, 7, 38, 38, 38, 24, 2, 10, 31, 30, 30,
            2, 48, 28, 47, 47, 39, 39, 30, 8, 49, 49, 9, 43, 7, 7, 18,
            18, 18, 50, 39, 36, 47, 47, 50, 50, 7, 7, 7, 7, 7, 48, 39,
            51, 51, 39, 36, 52, 52, 39, 51, 51, 52, 52, 51, 51, 36, 36, 7,
            7,
        };
        #endregion
    }
}
