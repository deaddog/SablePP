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
                        List<PSection> psectionlist = new List<PSection>();
                        ASectionGrammar asectiongrammar = new ASectionGrammar(
                            psectionlist
                        );
                        Push(0, asectiongrammar);
                    }
                    break;
                case 1:
                    {
                        List<PSection> psectionlist = Pop<List<PSection>>();
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
                        List<PIdentifierListitem> pidentifierlistitemlist = Pop<List<PIdentifierListitem>>();
                        TStatestoken tstatestoken = Pop<TStatestoken>();
                        List<PIdentifierListitem> pidentifierlistitemlist2 = new List<PIdentifierListitem>();
                        pidentifierlistitemlist2.AddRange(pidentifierlistitemlist);
                        AStates astates = new AStates(
                            tstatestoken,
                            pidentifierlistitemlist2,
                            tsemicolon
                        );
                        Push(5, astates);
                    }
                    break;
                case 14:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AIdentifierListitem aidentifierlistitem = new AIdentifierListitem(
                            null,
                            tidentifier
                        );
                        List<PIdentifierListitem> pidentifierlistitemlist = new List<PIdentifierListitem>();
                        pidentifierlistitemlist.Add(aidentifierlistitem);
                        Push(6, pidentifierlistitemlist);
                    }
                    break;
                case 15:
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
                        Push(6, pidentifierlistitemlist2);
                    }
                    break;
                case 16:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TComma tcomma = Pop<TComma>();
                        AIdentifierListitem aidentifierlistitem = new AIdentifierListitem(
                            tcomma,
                            tidentifier
                        );
                        Push(7, aidentifierlistitem);
                    }
                    break;
                case 17:
                    {
                        List<PToken> ptokenlist = Pop<List<PToken>>();
                        TTokenstoken ttokenstoken = Pop<TTokenstoken>();
                        List<PToken> ptokenlist2 = new List<PToken>();
                        ptokenlist2.AddRange(ptokenlist);
                        ATokens atokens = new ATokens(
                            ttokenstoken,
                            ptokenlist2
                        );
                        Push(8, atokens);
                    }
                    break;
                case 18:
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
                        Push(9, atoken);
                    }
                    break;
                case 19:
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
                        Push(9, atoken);
                    }
                    break;
                case 20:
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
                        Push(9, atoken);
                    }
                    break;
                case 21:
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
                        Push(9, atoken);
                    }
                    break;
                case 22:
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
                        Push(10, atokenstatelist);
                    }
                    break;
                case 23:
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
                        Push(10, atokenstatelist);
                    }
                    break;
                case 24:
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
                        Push(10, atokenstatelist);
                    }
                    break;
                case 25:
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
                        Push(10, atokenstatelist);
                    }
                    break;
                case 26:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TComma tcomma = Pop<TComma>();
                        ATokenstateListitem atokenstatelistitem = new ATokenstateListitem(
                            tcomma,
                            tidentifier
                        );
                        Push(11, atokenstatelistitem);
                    }
                    break;
                case 27:
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
                        Push(11, atransitiontokenstatelistitem);
                    }
                    break;
                case 28:
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
                        Push(12, aignoredtokens);
                    }
                    break;
                case 29:
                    {
                        PRegex pregex = Pop<PRegex>();
                        TSlash tslash = Pop<TSlash>();
                        ATokenlookahead atokenlookahead = new ATokenlookahead(
                            tslash,
                            pregex
                        );
                        Push(13, atokenlookahead);
                    }
                    break;
                case 30:
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
                        Push(14, aregex);
                    }
                    break;
                case 31:
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
                        Push(14, aregex);
                    }
                    break;
                case 32:
                    {
                        List<PRegexpart> pregexpartlist = Pop<List<PRegexpart>>();
                        TPipe tpipe = Pop<TPipe>();
                        List<PRegexpart> pregexpartlist2 = new List<PRegexpart>();
                        pregexpartlist2.AddRange(pregexpartlist);
                        ARegexOrpart aregexorpart = new ARegexOrpart(
                            tpipe,
                            pregexpartlist2
                        );
                        Push(15, aregexorpart);
                    }
                    break;
                case 33:
                    {
                        List<PRegexpart> pregexpartlist = Pop<List<PRegexpart>>();
                        List<PRegexpart> pregexpartlist2 = new List<PRegexpart>();
                        pregexpartlist2.AddRange(pregexpartlist);
                        Push(16, pregexpartlist2);
                    }
                    break;
                case 34:
                    {
                        TStar tstar = Pop<TStar>();
                        AStarModifier astarmodifier = new AStarModifier(
                            tstar
                        );
                        Push(17, astarmodifier);
                    }
                    break;
                case 35:
                    {
                        TQMark tqmark = Pop<TQMark>();
                        AQuestionModifier aquestionmodifier = new AQuestionModifier(
                            tqmark
                        );
                        Push(17, aquestionmodifier);
                    }
                    break;
                case 36:
                    {
                        TPlus tplus = Pop<TPlus>();
                        APlusModifier aplusmodifier = new APlusModifier(
                            tplus
                        );
                        Push(17, aplusmodifier);
                    }
                    break;
                case 37:
                    {
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        Push(18, pregexpart);
                    }
                    break;
                case 38:
                    {
                        PModifier pmodifier = Pop<PModifier>();
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        AUnaryRegexpart aunaryregexpart = new AUnaryRegexpart(
                            pregexpart,
                            pmodifier
                        );
                        Push(18, aunaryregexpart);
                    }
                    break;
                case 39:
                    {
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        Push(19, pregexpart);
                    }
                    break;
                case 40:
                    {
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        Push(19, pregexpart);
                    }
                    break;
                case 41:
                    {
                        TString tstring = Pop<TString>();
                        AStringRegexpart astringregexpart = new AStringRegexpart(
                            tstring
                        );
                        Push(19, astringregexpart);
                    }
                    break;
                case 42:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AIdentifierRegexpart aidentifierregexpart = new AIdentifierRegexpart(
                            tidentifier
                        );
                        Push(19, aidentifierregexpart);
                    }
                    break;
                case 43:
                    {
                        TRPar trpar = Pop<TRPar>();
                        PRegex pregex = Pop<PRegex>();
                        TLPar tlpar = Pop<TLPar>();
                        AParenthesisRegexpart aparenthesisregexpart = new AParenthesisRegexpart(
                            tlpar,
                            pregex,
                            trpar
                        );
                        Push(19, aparenthesisregexpart);
                    }
                    break;
                case 44:
                    {
                        TCharacter tcharacter = Pop<TCharacter>();
                        ACharRegexpart acharregexpart = new ACharRegexpart(
                            tcharacter
                        );
                        Push(20, acharregexpart);
                    }
                    break;
                case 45:
                    {
                        TDecChar tdecchar = Pop<TDecChar>();
                        ADecRegexpart adecregexpart = new ADecRegexpart(
                            tdecchar
                        );
                        Push(20, adecregexpart);
                    }
                    break;
                case 46:
                    {
                        THexChar thexchar = Pop<THexChar>();
                        AHexRegexpart ahexregexpart = new AHexRegexpart(
                            thexchar
                        );
                        Push(20, ahexregexpart);
                    }
                    break;
                case 47:
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
                        Push(21, abinaryplusregexpart);
                    }
                    break;
                case 48:
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
                        Push(21, abinaryminusregexpart);
                    }
                    break;
                case 49:
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
                        Push(21, aintervalregexpart);
                    }
                    break;
                case 50:
                    {
                        List<PProduction> pproductionlist = Pop<List<PProduction>>();
                        TProductionstoken tproductionstoken = Pop<TProductionstoken>();
                        List<PProduction> pproductionlist2 = new List<PProduction>();
                        pproductionlist2.AddRange(pproductionlist);
                        AProductions aproductions = new AProductions(
                            tproductionstoken,
                            pproductionlist2
                        );
                        Push(22, aproductions);
                    }
                    break;
                case 51:
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
                        Push(23, aproduction);
                    }
                    break;
                case 52:
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
                        Push(23, aproduction);
                    }
                    break;
                case 53:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AProdtranslation aprodtranslation = new AProdtranslation(
                            tarrow,
                            tidentifier,
                            null
                        );
                        Push(24, aprodtranslation);
                    }
                    break;
                case 54:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        PModifier pmodifier = Pop<PModifier>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AProdtranslation aprodtranslation = new AProdtranslation(
                            tarrow,
                            tidentifier,
                            pmodifier
                        );
                        Push(24, aprodtranslation);
                    }
                    break;
                case 55:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        AProdtranslation aprodtranslation = new AProdtranslation(
                            tarrow,
                            tidentifier,
                            null
                        );
                        Push(24, aprodtranslation);
                    }
                    break;
                case 56:
                    {
                        PModifier pmodifier = Pop<PModifier>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TArrow tarrow = Pop<TArrow>();
                        AProdtranslation aprodtranslation = new AProdtranslation(
                            tarrow,
                            tidentifier,
                            pmodifier
                        );
                        Push(24, aprodtranslation);
                    }
                    break;
                case 57:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        PTranslation ptranslation = Pop<PTranslation>();
                        TArrow tarrow = Pop<TArrow>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AFullTranslation afulltranslation = new AFullTranslation(
                            tarrow,
                            ptranslation
                        );
                        Push(25, afulltranslation);
                    }
                    break;
                case 58:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        TArrow tarrow = Pop<TArrow>();
                        AFullTranslation afulltranslation = new AFullTranslation(
                            tarrow,
                            ptranslation
                        );
                        Push(25, afulltranslation);
                    }
                    break;
                case 59:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        Push(26, ptranslation);
                    }
                    break;
                case 60:
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
                        Push(26, anewtranslation);
                    }
                    break;
                case 61:
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
                        Push(26, anewtranslation);
                    }
                    break;
                case 62:
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
                        Push(26, anewalternativetranslation);
                    }
                    break;
                case 63:
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
                        Push(26, anewalternativetranslation);
                    }
                    break;
                case 64:
                    {
                        TNull tnull = Pop<TNull>();
                        ANullTranslation anulltranslation = new ANullTranslation(
                            tnull
                        );
                        Push(26, anulltranslation);
                    }
                    break;
                case 65:
                    {
                        TRBkt trbkt = Pop<TRBkt>();
                        TLBkt tlbkt = Pop<TLBkt>();
                        List<PTranslationListitem> ptranslationlistitemlist = new List<PTranslationListitem>();
                        AListTranslation alisttranslation = new AListTranslation(
                            tlbkt,
                            ptranslationlistitemlist,
                            trbkt
                        );
                        Push(26, alisttranslation);
                    }
                    break;
                case 66:
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
                        Push(26, alisttranslation);
                    }
                    break;
                case 67:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        ATranslationListitem atranslationlistitem = new ATranslationListitem(
                            null,
                            ptranslation
                        );
                        List<PTranslationListitem> ptranslationlistitemlist = new List<PTranslationListitem>();
                        ptranslationlistitemlist.Add(atranslationlistitem);
                        Push(27, ptranslationlistitemlist);
                    }
                    break;
                case 68:
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
                        Push(27, ptranslationlistitemlist2);
                    }
                    break;
                case 69:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        TComma tcomma = Pop<TComma>();
                        ATranslationListitem atranslationlistitem = new ATranslationListitem(
                            tcomma,
                            ptranslation
                        );
                        Push(28, atranslationlistitem);
                    }
                    break;
                case 70:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AIdTranslation aidtranslation = new AIdTranslation(
                            tidentifier
                        );
                        Push(29, aidtranslation);
                    }
                    break;
                case 71:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TIdentifier tidentifier2 = Pop<TIdentifier>();
                        AIddotidTranslation aiddotidtranslation = new AIddotidTranslation(
                            tidentifier2,
                            tdot,
                            tidentifier
                        );
                        Push(29, aiddotidtranslation);
                    }
                    break;
                case 72:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 73:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 74:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 75:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 76:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 77:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 78:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 79:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 80:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 81:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 82:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 83:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 84:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 85:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 86:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 87:
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
                        Push(30, aproductionrule);
                    }
                    break;
                case 88:
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
                        Push(31, aalternative);
                    }
                    break;
                case 89:
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
                        Push(31, aalternative);
                    }
                    break;
                case 90:
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
                        Push(31, aalternative);
                    }
                    break;
                case 91:
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
                        Push(31, aalternative);
                    }
                    break;
                case 92:
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
                        Push(31, aalternative);
                    }
                    break;
                case 93:
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
                        Push(31, aalternative);
                    }
                    break;
                case 94:
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
                        Push(31, aalternative);
                    }
                    break;
                case 95:
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
                        Push(31, aalternative);
                    }
                    break;
                case 96:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AAlternativename aalternativename = new AAlternativename(
                            tlbrace,
                            tidentifier,
                            trbrace
                        );
                        Push(32, aalternativename);
                    }
                    break;
                case 97:
                    {
                        PElementid pelementid = Pop<PElementid>();
                        AElement aelement = new AElement(
                            null,
                            pelementid,
                            null
                        );
                        Push(33, aelement);
                    }
                    break;
                case 98:
                    {
                        PElementid pelementid = Pop<PElementid>();
                        PElementname pelementname = Pop<PElementname>();
                        AElement aelement = new AElement(
                            pelementname,
                            pelementid,
                            null
                        );
                        Push(33, aelement);
                    }
                    break;
                case 99:
                    {
                        PModifier pmodifier = Pop<PModifier>();
                        PElementid pelementid = Pop<PElementid>();
                        AElement aelement = new AElement(
                            null,
                            pelementid,
                            pmodifier
                        );
                        Push(33, aelement);
                    }
                    break;
                case 100:
                    {
                        PModifier pmodifier = Pop<PModifier>();
                        PElementid pelementid = Pop<PElementid>();
                        PElementname pelementname = Pop<PElementname>();
                        AElement aelement = new AElement(
                            pelementname,
                            pelementid,
                            pmodifier
                        );
                        Push(33, aelement);
                    }
                    break;
                case 101:
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
                        Push(34, aelementname);
                    }
                    break;
                case 102:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        ACleanElementid acleanelementid = new ACleanElementid(
                            tidentifier
                        );
                        Push(35, acleanelementid);
                    }
                    break;
                case 103:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TTokenSpecifier ttokenspecifier = Pop<TTokenSpecifier>();
                        ATokenElementid atokenelementid = new ATokenElementid(
                            ttokenspecifier,
                            tdot,
                            tidentifier
                        );
                        Push(35, atokenelementid);
                    }
                    break;
                case 104:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TProductionSpecifier tproductionspecifier = Pop<TProductionSpecifier>();
                        AProductionElementid aproductionelementid = new AProductionElementid(
                            tproductionspecifier,
                            tdot,
                            tidentifier
                        );
                        Push(35, aproductionelementid);
                    }
                    break;
                case 105:
                    {
                        List<PProduction> pproductionlist = Pop<List<PProduction>>();
                        TAsttoken tasttoken = Pop<TAsttoken>();
                        List<PProduction> pproductionlist2 = new List<PProduction>();
                        pproductionlist2.AddRange(pproductionlist);
                        AAstproductions aastproductions = new AAstproductions(
                            tasttoken,
                            pproductionlist2
                        );
                        Push(36, aastproductions);
                    }
                    break;
                case 106:
                    {
                        List<PHighlightrule> phighlightrule = Pop<List<PHighlightrule>>();
                        THighlighttoken thighlighttoken = Pop<THighlighttoken>();
                        AHighlightrules ahighlightrules = new AHighlightrules(
                            thighlighttoken,
                            phighlightrule
                        );
                        Push(37, ahighlightrules);
                    }
                    break;
                case 107:
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
                        Push(38, ahighlightrule);
                    }
                    break;
                case 108:
                    {
                        PHighlightStyle phighlightstyle = Pop<PHighlightStyle>();
                        AStyleListitem astylelistitem = new AStyleListitem(
                            null,
                            phighlightstyle
                        );
                        List<PStyleListitem> pstylelistitemlist = new List<PStyleListitem>();
                        pstylelistitemlist.Add(astylelistitem);
                        Push(39, pstylelistitemlist);
                    }
                    break;
                case 109:
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
                        Push(39, pstylelistitemlist2);
                    }
                    break;
                case 110:
                    {
                        PHighlightStyle phighlightstyle = Pop<PHighlightStyle>();
                        TComma tcomma = Pop<TComma>();
                        AStyleListitem astylelistitem = new AStyleListitem(
                            tcomma,
                            phighlightstyle
                        );
                        Push(40, astylelistitem);
                    }
                    break;
                case 111:
                    {
                        TItalic titalic = Pop<TItalic>();
                        AItalicHighlightStyle aitalichighlightstyle = new AItalicHighlightStyle(
                            titalic
                        );
                        Push(41, aitalichighlightstyle);
                    }
                    break;
                case 112:
                    {
                        TBold tbold = Pop<TBold>();
                        ABoldHighlightStyle aboldhighlightstyle = new ABoldHighlightStyle(
                            tbold
                        );
                        Push(41, aboldhighlightstyle);
                    }
                    break;
                case 113:
                    {
                        PColor pcolor = Pop<PColor>();
                        TColon tcolon = Pop<TColon>();
                        TText ttext = Pop<TText>();
                        ATextHighlightStyle atexthighlightstyle = new ATextHighlightStyle(
                            ttext,
                            tcolon,
                            pcolor
                        );
                        Push(41, atexthighlightstyle);
                    }
                    break;
                case 114:
                    {
                        PColor pcolor = Pop<PColor>();
                        TColon tcolon = Pop<TColon>();
                        TBackground tbackground = Pop<TBackground>();
                        ABackgroundHighlightStyle abackgroundhighlightstyle = new ABackgroundHighlightStyle(
                            tbackground,
                            tcolon,
                            pcolor
                        );
                        Push(41, abackgroundhighlightstyle);
                    }
                    break;
                case 115:
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
                        Push(42, argbcolor);
                    }
                    break;
                case 116:
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
                        Push(42, ahsvcolor);
                    }
                    break;
                case 117:
                    {
                        THexColor thexcolor = Pop<THexColor>();
                        AHexColor ahexcolor = new AHexColor(
                            thexcolor
                        );
                        Push(42, ahexcolor);
                    }
                    break;
                case 118:
                    Push(43, new List<PSection>() { Pop<PSection>() });
                    break;
                case 119:
                    {
                        PSection item = Pop<PSection>();
                        List<PSection> list = Pop<List<PSection>>();
                        list.Add(item);
                        Push(43, list);
                    }
                    break;
                case 120:
                    Push(44, new List<PHelper>() { Pop<PHelper>() });
                    break;
                case 121:
                    {
                        PHelper item = Pop<PHelper>();
                        List<PHelper> list = Pop<List<PHelper>>();
                        list.Add(item);
                        Push(44, list);
                    }
                    break;
                case 122:
                    Push(45, new List<PIdentifierListitem>() { Pop<PIdentifierListitem>() });
                    break;
                case 123:
                    {
                        PIdentifierListitem item = Pop<PIdentifierListitem>();
                        List<PIdentifierListitem> list = Pop<List<PIdentifierListitem>>();
                        list.Add(item);
                        Push(45, list);
                    }
                    break;
                case 124:
                    Push(46, new List<PToken>() { Pop<PToken>() });
                    break;
                case 125:
                    {
                        PToken item = Pop<PToken>();
                        List<PToken> list = Pop<List<PToken>>();
                        list.Add(item);
                        Push(46, list);
                    }
                    break;
                case 126:
                    Push(47, new List<PTokenstateListitem>() { Pop<PTokenstateListitem>() });
                    break;
                case 127:
                    {
                        PTokenstateListitem item = Pop<PTokenstateListitem>();
                        List<PTokenstateListitem> list = Pop<List<PTokenstateListitem>>();
                        list.Add(item);
                        Push(47, list);
                    }
                    break;
                case 128:
                    Push(48, new List<POrpart>() { Pop<POrpart>() });
                    break;
                case 129:
                    {
                        POrpart item = Pop<POrpart>();
                        List<POrpart> list = Pop<List<POrpart>>();
                        list.Add(item);
                        Push(48, list);
                    }
                    break;
                case 130:
                    Push(49, new List<PRegexpart>() { Pop<PRegexpart>() });
                    break;
                case 131:
                    {
                        PRegexpart item = Pop<PRegexpart>();
                        List<PRegexpart> list = Pop<List<PRegexpart>>();
                        list.Add(item);
                        Push(49, list);
                    }
                    break;
                case 132:
                    Push(50, new List<PProduction>() { Pop<PProduction>() });
                    break;
                case 133:
                    {
                        PProduction item = Pop<PProduction>();
                        List<PProduction> list = Pop<List<PProduction>>();
                        list.Add(item);
                        Push(50, list);
                    }
                    break;
                case 134:
                    Push(51, new List<PTranslationListitem>() { Pop<PTranslationListitem>() });
                    break;
                case 135:
                    {
                        PTranslationListitem item = Pop<PTranslationListitem>();
                        List<PTranslationListitem> list = Pop<List<PTranslationListitem>>();
                        list.Add(item);
                        Push(51, list);
                    }
                    break;
                case 136:
                    Push(52, new List<PElement>() { Pop<PElement>() });
                    break;
                case 137:
                    {
                        PElement item = Pop<PElement>();
                        List<PElement> list = Pop<List<PElement>>();
                        list.Add(item);
                        Push(52, list);
                    }
                    break;
                case 138:
                    Push(53, new List<PAlternative>() { Pop<PAlternative>() });
                    break;
                case 139:
                    {
                        PAlternative item = Pop<PAlternative>();
                        List<PAlternative> list = Pop<List<PAlternative>>();
                        list.Add(item);
                        Push(53, list);
                    }
                    break;
                case 140:
                    Push(54, new List<PHighlightrule>() { Pop<PHighlightrule>() });
                    break;
                case 141:
                    {
                        PHighlightrule item = Pop<PHighlightrule>();
                        List<PHighlightrule> list = Pop<List<PHighlightrule>>();
                        list.Add(item);
                        Push(54, list);
                    }
                    break;
                case 142:
                    Push(55, new List<PStyleListitem>() { Pop<PStyleListitem>() });
                    break;
                case 143:
                    {
                        PStyleListitem item = Pop<PStyleListitem>();
                        List<PStyleListitem> list = Pop<List<PStyleListitem>>();
                        list.Add(item);
                        Push(55, list);
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
                new int[] {-1, 1, 118},
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
                new int[] {-1, 1, 120},
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
                new int[] {-1, 1, 124},
            },
            new int[][] {
                new int[] {-1, 3, 29},
                new int[] {32, 0, 49},
            },
            new int[][] {
                new int[] {-1, 1, 17},
                new int[] {21, 0, 26},
                new int[] {32, 0, 27},
            },
            new int[][] {
                new int[] {-1, 3, 31},
                new int[] {32, 0, 21},
            },
            new int[][] {
                new int[] {-1, 3, 32},
                new int[] {16, 0, 52},
                new int[] {21, 0, 53},
                new int[] {30, 0, 54},
            },
            new int[][] {
                new int[] {-1, 1, 132},
            },
            new int[][] {
                new int[] {-1, 1, 50},
                new int[] {32, 0, 32},
            },
            new int[][] {
                new int[] {-1, 1, 105},
                new int[] {32, 0, 32},
            },
            new int[][] {
                new int[] {-1, 3, 36},
                new int[] {21, 0, 57},
            },
            new int[][] {
                new int[] {-1, 1, 140},
            },
            new int[][] {
                new int[] {-1, 1, 106},
                new int[] {32, 0, 36},
            },
            new int[][] {
                new int[] {-1, 1, 119},
            },
            new int[][] {
                new int[] {-1, 1, 10},
            },
            new int[][] {
                new int[] {-1, 3, 41},
                new int[] {32, 0, 59},
            },
            new int[][] {
                new int[] {-1, 1, 122},
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
                new int[] {17, 0, 61},
                new int[] {19, 0, 62},
                new int[] {32, 0, 63},
                new int[] {33, 0, 64},
                new int[] {34, 0, 65},
                new int[] {35, 0, 66},
                new int[] {36, 0, 67},
            },
            new int[][] {
                new int[] {-1, 1, 121},
            },
            new int[][] {
                new int[] {-1, 3, 47},
                new int[] {22, 0, 75},
                new int[] {28, 0, 76},
                new int[] {30, 0, 77},
            },
            new int[][] {
                new int[] {-1, 3, 48},
                new int[] {17, 0, 61},
                new int[] {19, 0, 62},
                new int[] {32, 0, 63},
                new int[] {33, 0, 64},
                new int[] {34, 0, 65},
                new int[] {35, 0, 66},
                new int[] {36, 0, 67},
            },
            new int[][] {
                new int[] {-1, 3, 49},
                new int[] {16, 0, 81},
            },
            new int[][] {
                new int[] {-1, 1, 125},
            },
            new int[][] {
                new int[] {-1, 3, 51},
                new int[] {15, 0, 82},
            },
            new int[][] {
                new int[] {-1, 1, 72},
                new int[] {11, 0, 83},
                new int[] {12, 0, 84},
                new int[] {17, 0, 85},
                new int[] {21, 0, 86},
                new int[] {27, 0, 87},
                new int[] {30, 0, 88},
                new int[] {32, 0, 89},
            },
            new int[][] {
                new int[] {-1, 3, 53},
                new int[] {30, 0, 99},
            },
            new int[][] {
                new int[] {-1, 3, 54},
                new int[] {32, 0, 100},
            },
            new int[][] {
                new int[] {-1, 3, 55},
                new int[] {16, 0, 101},
            },
            new int[][] {
                new int[] {-1, 1, 133},
            },
            new int[][] {
                new int[] {-1, 3, 57},
                new int[] {32, 0, 21},
            },
            new int[][] {
                new int[] {-1, 1, 141},
            },
            new int[][] {
                new int[] {-1, 1, 16},
            },
            new int[][] {
                new int[] {-1, 1, 123},
            },
            new int[][] {
                new int[] {-1, 3, 61},
                new int[] {17, 0, 61},
                new int[] {19, 0, 62},
                new int[] {32, 0, 63},
                new int[] {33, 0, 64},
                new int[] {34, 0, 65},
                new int[] {35, 0, 66},
                new int[] {36, 0, 67},
            },
            new int[][] {
                new int[] {-1, 3, 62},
                new int[] {17, 0, 61},
                new int[] {19, 0, 62},
                new int[] {32, 0, 63},
                new int[] {33, 0, 64},
                new int[] {34, 0, 65},
                new int[] {35, 0, 66},
                new int[] {36, 0, 67},
            },
            new int[][] {
                new int[] {-1, 1, 42},
            },
            new int[][] {
                new int[] {-1, 1, 44},
            },
            new int[][] {
                new int[] {-1, 1, 45},
            },
            new int[][] {
                new int[] {-1, 1, 46},
            },
            new int[][] {
                new int[] {-1, 1, 41},
            },
            new int[][] {
                new int[] {-1, 3, 68},
                new int[] {15, 0, 106},
            },
            new int[][] {
                new int[] {-1, 1, 30},
                new int[] {27, 0, 107},
            },
            new int[][] {
                new int[] {-1, 1, 130},
            },
            new int[][] {
                new int[] {-1, 1, 37},
                new int[] {23, 0, 110},
                new int[] {25, 0, 111},
                new int[] {26, 0, 112},
            },
            new int[][] {
                new int[] {-1, 1, 39},
            },
            new int[][] {
                new int[] {-1, 1, 40},
            },
            new int[][] {
                new int[] {-1, 1, 33},
                new int[] {17, 0, 61},
                new int[] {19, 0, 62},
                new int[] {32, 0, 63},
                new int[] {33, 0, 64},
                new int[] {34, 0, 65},
                new int[] {35, 0, 66},
                new int[] {36, 0, 67},
            },
            new int[][] {
                new int[] {-1, 1, 22},
            },
            new int[][] {
                new int[] {-1, 3, 76},
                new int[] {32, 0, 115},
            },
            new int[][] {
                new int[] {-1, 3, 77},
                new int[] {32, 0, 116},
            },
            new int[][] {
                new int[] {-1, 1, 126},
            },
            new int[][] {
                new int[] {-1, 3, 79},
                new int[] {22, 0, 117},
                new int[] {28, 0, 76},
            },
            new int[][] {
                new int[] {-1, 3, 80},
                new int[] {15, 0, 119},
                new int[] {29, 0, 120},
            },
            new int[][] {
                new int[] {-1, 3, 81},
                new int[] {17, 0, 61},
                new int[] {19, 0, 62},
                new int[] {32, 0, 63},
                new int[] {33, 0, 64},
                new int[] {34, 0, 65},
                new int[] {35, 0, 66},
                new int[] {36, 0, 67},
            },
            new int[][] {
                new int[] {-1, 1, 28},
            },
            new int[][] {
                new int[] {-1, 3, 83},
                new int[] {13, 0, 123},
            },
            new int[][] {
                new int[] {-1, 3, 84},
                new int[] {13, 0, 124},
            },
            new int[][] {
                new int[] {-1, 3, 85},
                new int[] {32, 0, 125},
            },
            new int[][] {
                new int[] {-1, 3, 86},
                new int[] {30, 0, 126},
                new int[] {32, 0, 127},
            },
            new int[][] {
                new int[] {-1, 1, 88},
                new int[] {11, 0, 83},
                new int[] {12, 0, 84},
                new int[] {17, 0, 85},
                new int[] {21, 0, 86},
                new int[] {30, 0, 88},
                new int[] {32, 0, 89},
            },
            new int[][] {
                new int[] {-1, 3, 88},
                new int[] {9, 0, 131},
                new int[] {10, 0, 132},
                new int[] {17, 0, 133},
                new int[] {32, 0, 134},
            },
            new int[][] {
                new int[] {-1, 1, 102},
            },
            new int[][] {
                new int[] {-1, 1, 76},
                new int[] {27, 0, 87},
            },
            new int[][] {
                new int[] {-1, 3, 91},
                new int[] {15, 0, 138},
            },
            new int[][] {
                new int[] {-1, 1, 138},
            },
            new int[][] {
                new int[] {-1, 1, 73},
                new int[] {11, 0, 83},
                new int[] {12, 0, 84},
                new int[] {17, 0, 85},
                new int[] {21, 0, 139},
                new int[] {27, 0, 87},
                new int[] {30, 0, 88},
                new int[] {32, 0, 89},
            },
            new int[][] {
                new int[] {-1, 1, 136},
            },
            new int[][] {
                new int[] {-1, 3, 95},
                new int[] {11, 0, 83},
                new int[] {12, 0, 84},
                new int[] {32, 0, 89},
            },
            new int[][] {
                new int[] {-1, 1, 97},
                new int[] {23, 0, 110},
                new int[] {25, 0, 111},
                new int[] {26, 0, 112},
            },
            new int[][] {
                new int[] {-1, 1, 74},
                new int[] {11, 0, 83},
                new int[] {12, 0, 84},
                new int[] {17, 0, 85},
                new int[] {21, 0, 139},
                new int[] {27, 0, 87},
                new int[] {30, 0, 88},
                new int[] {32, 0, 89},
            },
            new int[][] {
                new int[] {-1, 1, 80},
                new int[] {27, 0, 87},
            },
            new int[][] {
                new int[] {-1, 3, 99},
                new int[] {32, 0, 149},
            },
            new int[][] {
                new int[] {-1, 1, 55},
                new int[] {23, 0, 110},
                new int[] {25, 0, 111},
                new int[] {26, 0, 112},
            },
            new int[][] {
                new int[] {-1, 1, 72},
                new int[] {11, 0, 83},
                new int[] {12, 0, 84},
                new int[] {17, 0, 85},
                new int[] {21, 0, 86},
                new int[] {27, 0, 87},
                new int[] {30, 0, 88},
                new int[] {32, 0, 89},
            },
            new int[][] {
                new int[] {-1, 3, 102},
                new int[] {22, 0, 152},
            },
            new int[][] {
                new int[] {-1, 3, 103},
                new int[] {23, 0, 153},
                new int[] {24, 0, 154},
            },
            new int[][] {
                new int[] {-1, 1, 39},
                new int[] {14, 0, 155},
            },
            new int[][] {
                new int[] {-1, 3, 105},
                new int[] {20, 0, 156},
            },
            new int[][] {
                new int[] {-1, 1, 12},
            },
            new int[][] {
                new int[] {-1, 3, 107},
                new int[] {17, 0, 61},
                new int[] {19, 0, 62},
                new int[] {32, 0, 63},
                new int[] {33, 0, 64},
                new int[] {34, 0, 65},
                new int[] {35, 0, 66},
                new int[] {36, 0, 67},
            },
            new int[][] {
                new int[] {-1, 1, 128},
            },
            new int[][] {
                new int[] {-1, 1, 31},
                new int[] {27, 0, 107},
            },
            new int[][] {
                new int[] {-1, 1, 36},
            },
            new int[][] {
                new int[] {-1, 1, 35},
            },
            new int[][] {
                new int[] {-1, 1, 34},
            },
            new int[][] {
                new int[] {-1, 1, 38},
            },
            new int[][] {
                new int[] {-1, 1, 131},
            },
            new int[][] {
                new int[] {-1, 1, 26},
                new int[] {30, 0, 159},
            },
            new int[][] {
                new int[] {-1, 3, 116},
                new int[] {22, 0, 160},
                new int[] {28, 0, 76},
            },
            new int[][] {
                new int[] {-1, 1, 23},
            },
            new int[][] {
                new int[] {-1, 1, 127},
            },
            new int[][] {
                new int[] {-1, 1, 18},
            },
            new int[][] {
                new int[] {-1, 3, 120},
                new int[] {17, 0, 61},
                new int[] {19, 0, 62},
                new int[] {32, 0, 63},
                new int[] {33, 0, 64},
                new int[] {34, 0, 65},
                new int[] {35, 0, 66},
                new int[] {36, 0, 67},
            },
            new int[][] {
                new int[] {-1, 3, 121},
                new int[] {15, 0, 163},
            },
            new int[][] {
                new int[] {-1, 3, 122},
                new int[] {15, 0, 164},
                new int[] {29, 0, 120},
            },
            new int[][] {
                new int[] {-1, 3, 123},
                new int[] {32, 0, 166},
            },
            new int[][] {
                new int[] {-1, 3, 124},
                new int[] {32, 0, 167},
            },
            new int[][] {
                new int[] {-1, 3, 125},
                new int[] {18, 0, 168},
            },
            new int[][] {
                new int[] {-1, 3, 126},
                new int[] {9, 0, 131},
                new int[] {10, 0, 132},
                new int[] {17, 0, 133},
                new int[] {32, 0, 134},
            },
            new int[][] {
                new int[] {-1, 3, 127},
                new int[] {22, 0, 170},
            },
            new int[][] {
                new int[] {-1, 1, 92},
            },
            new int[][] {
                new int[] {-1, 1, 89},
                new int[] {11, 0, 83},
                new int[] {12, 0, 84},
                new int[] {17, 0, 85},
                new int[] {21, 0, 139},
                new int[] {30, 0, 88},
                new int[] {32, 0, 89},
            },
            new int[][] {
                new int[] {-1, 1, 90},
                new int[] {11, 0, 83},
                new int[] {12, 0, 84},
                new int[] {17, 0, 85},
                new int[] {21, 0, 139},
                new int[] {30, 0, 88},
                new int[] {32, 0, 89},
            },
            new int[][] {
                new int[] {-1, 3, 131},
                new int[] {32, 0, 174},
            },
            new int[][] {
                new int[] {-1, 1, 64},
            },
            new int[][] {
                new int[] {-1, 3, 133},
                new int[] {9, 0, 131},
                new int[] {10, 0, 132},
                new int[] {17, 0, 133},
                new int[] {18, 0, 175},
                new int[] {32, 0, 134},
            },
            new int[][] {
                new int[] {-1, 1, 70},
                new int[] {13, 0, 178},
            },
            new int[][] {
                new int[] {-1, 1, 58},
            },
            new int[][] {
                new int[] {-1, 1, 59},
            },
            new int[][] {
                new int[] {-1, 1, 84},
                new int[] {27, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 51},
            },
            new int[][] {
                new int[] {-1, 3, 139},
                new int[] {30, 0, 126},
            },
            new int[][] {
                new int[] {-1, 1, 77},
                new int[] {27, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 75},
                new int[] {11, 0, 83},
                new int[] {12, 0, 84},
                new int[] {17, 0, 85},
                new int[] {21, 0, 139},
                new int[] {27, 0, 87},
                new int[] {30, 0, 88},
                new int[] {32, 0, 89},
            },
            new int[][] {
                new int[] {-1, 1, 81},
                new int[] {27, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 98},
                new int[] {23, 0, 110},
                new int[] {25, 0, 111},
                new int[] {26, 0, 112},
            },
            new int[][] {
                new int[] {-1, 1, 99},
            },
            new int[][] {
                new int[] {-1, 1, 78},
                new int[] {27, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 137},
            },
            new int[][] {
                new int[] {-1, 1, 82},
                new int[] {27, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 139},
            },
            new int[][] {
                new int[] {-1, 3, 149},
                new int[] {22, 0, 184},
                new int[] {23, 0, 110},
                new int[] {25, 0, 111},
                new int[] {26, 0, 112},
            },
            new int[][] {
                new int[] {-1, 1, 56},
            },
            new int[][] {
                new int[] {-1, 3, 151},
                new int[] {15, 0, 186},
            },
            new int[][] {
                new int[] {-1, 3, 152},
                new int[] {37, 0, 187},
                new int[] {38, 0, 188},
                new int[] {39, 0, 189},
                new int[] {40, 0, 190},
            },
            new int[][] {
                new int[] {-1, 3, 153},
                new int[] {17, 0, 61},
                new int[] {19, 0, 62},
                new int[] {32, 0, 63},
                new int[] {33, 0, 64},
                new int[] {34, 0, 65},
                new int[] {35, 0, 66},
                new int[] {36, 0, 67},
            },
            new int[][] {
                new int[] {-1, 3, 154},
                new int[] {17, 0, 61},
                new int[] {19, 0, 62},
                new int[] {32, 0, 63},
                new int[] {33, 0, 64},
                new int[] {34, 0, 65},
                new int[] {35, 0, 66},
                new int[] {36, 0, 67},
            },
            new int[][] {
                new int[] {-1, 3, 155},
                new int[] {33, 0, 64},
                new int[] {34, 0, 65},
                new int[] {35, 0, 66},
            },
            new int[][] {
                new int[] {-1, 1, 43},
            },
            new int[][] {
                new int[] {-1, 1, 32},
            },
            new int[][] {
                new int[] {-1, 1, 129},
            },
            new int[][] {
                new int[] {-1, 3, 159},
                new int[] {32, 0, 196},
            },
            new int[][] {
                new int[] {-1, 1, 24},
            },
            new int[][] {
                new int[] {-1, 3, 161},
                new int[] {22, 0, 197},
                new int[] {28, 0, 76},
            },
            new int[][] {
                new int[] {-1, 1, 29},
            },
            new int[][] {
                new int[] {-1, 1, 20},
            },
            new int[][] {
                new int[] {-1, 1, 19},
            },
            new int[][] {
                new int[] {-1, 3, 165},
                new int[] {15, 0, 198},
            },
            new int[][] {
                new int[] {-1, 1, 103},
            },
            new int[][] {
                new int[] {-1, 1, 104},
            },
            new int[][] {
                new int[] {-1, 3, 168},
                new int[] {31, 0, 199},
            },
            new int[][] {
                new int[] {-1, 3, 169},
                new int[] {22, 0, 200},
            },
            new int[][] {
                new int[] {-1, 1, 96},
            },
            new int[][] {
                new int[] {-1, 1, 93},
            },
            new int[][] {
                new int[] {-1, 1, 91},
                new int[] {11, 0, 83},
                new int[] {12, 0, 84},
                new int[] {17, 0, 85},
                new int[] {21, 0, 139},
                new int[] {30, 0, 88},
                new int[] {32, 0, 89},
            },
            new int[][] {
                new int[] {-1, 1, 94},
            },
            new int[][] {
                new int[] {-1, 3, 174},
                new int[] {13, 0, 202},
                new int[] {19, 0, 203},
            },
            new int[][] {
                new int[] {-1, 1, 65},
            },
            new int[][] {
                new int[] {-1, 1, 67},
                new int[] {28, 0, 204},
            },
            new int[][] {
                new int[] {-1, 3, 177},
                new int[] {18, 0, 207},
            },
            new int[][] {
                new int[] {-1, 3, 178},
                new int[] {32, 0, 208},
            },
            new int[][] {
                new int[] {-1, 1, 85},
                new int[] {27, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 79},
                new int[] {27, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 83},
                new int[] {27, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 100},
            },
            new int[][] {
                new int[] {-1, 1, 86},
                new int[] {27, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 53},
            },
            new int[][] {
                new int[] {-1, 3, 185},
                new int[] {22, 0, 210},
            },
            new int[][] {
                new int[] {-1, 1, 52},
            },
            new int[][] {
                new int[] {-1, 1, 111},
            },
            new int[][] {
                new int[] {-1, 1, 112},
            },
            new int[][] {
                new int[] {-1, 3, 189},
                new int[] {31, 0, 211},
            },
            new int[][] {
                new int[] {-1, 3, 190},
                new int[] {31, 0, 212},
            },
            new int[][] {
                new int[] {-1, 3, 191},
                new int[] {15, 0, 213},
            },
            new int[][] {
                new int[] {-1, 1, 108},
                new int[] {28, 0, 214},
            },
            new int[][] {
                new int[] {-1, 3, 193},
                new int[] {18, 0, 217},
            },
            new int[][] {
                new int[] {-1, 3, 194},
                new int[] {18, 0, 218},
            },
            new int[][] {
                new int[] {-1, 3, 195},
                new int[] {18, 0, 219},
            },
            new int[][] {
                new int[] {-1, 1, 27},
            },
            new int[][] {
                new int[] {-1, 1, 25},
            },
            new int[][] {
                new int[] {-1, 1, 21},
            },
            new int[][] {
                new int[] {-1, 1, 101},
            },
            new int[][] {
                new int[] {-1, 1, 57},
            },
            new int[][] {
                new int[] {-1, 1, 95},
            },
            new int[][] {
                new int[] {-1, 3, 202},
                new int[] {32, 0, 220},
            },
            new int[][] {
                new int[] {-1, 3, 203},
                new int[] {9, 0, 131},
                new int[] {10, 0, 132},
                new int[] {17, 0, 133},
                new int[] {20, 0, 221},
                new int[] {32, 0, 134},
            },
            new int[][] {
                new int[] {-1, 3, 204},
                new int[] {9, 0, 131},
                new int[] {10, 0, 132},
                new int[] {17, 0, 133},
                new int[] {32, 0, 134},
            },
            new int[][] {
                new int[] {-1, 1, 134},
            },
            new int[][] {
                new int[] {-1, 1, 68},
                new int[] {28, 0, 204},
            },
            new int[][] {
                new int[] {-1, 1, 66},
            },
            new int[][] {
                new int[] {-1, 1, 71},
            },
            new int[][] {
                new int[] {-1, 1, 87},
                new int[] {27, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 54},
            },
            new int[][] {
                new int[] {-1, 3, 211},
                new int[] {41, 0, 225},
                new int[] {42, 0, 226},
                new int[] {43, 0, 227},
            },
            new int[][] {
                new int[] {-1, 3, 212},
                new int[] {41, 0, 225},
                new int[] {42, 0, 226},
                new int[] {43, 0, 227},
            },
            new int[][] {
                new int[] {-1, 1, 107},
            },
            new int[][] {
                new int[] {-1, 3, 214},
                new int[] {37, 0, 187},
                new int[] {38, 0, 188},
                new int[] {39, 0, 189},
                new int[] {40, 0, 190},
            },
            new int[][] {
                new int[] {-1, 1, 142},
            },
            new int[][] {
                new int[] {-1, 1, 109},
                new int[] {28, 0, 214},
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
                new int[] {-1, 3, 220},
                new int[] {19, 0, 232},
            },
            new int[][] {
                new int[] {-1, 1, 60},
            },
            new int[][] {
                new int[] {-1, 3, 222},
                new int[] {20, 0, 233},
            },
            new int[][] {
                new int[] {-1, 1, 69},
            },
            new int[][] {
                new int[] {-1, 1, 135},
            },
            new int[][] {
                new int[] {-1, 3, 225},
                new int[] {19, 0, 234},
            },
            new int[][] {
                new int[] {-1, 3, 226},
                new int[] {19, 0, 235},
            },
            new int[][] {
                new int[] {-1, 1, 117},
            },
            new int[][] {
                new int[] {-1, 1, 113},
            },
            new int[][] {
                new int[] {-1, 1, 114},
            },
            new int[][] {
                new int[] {-1, 1, 110},
            },
            new int[][] {
                new int[] {-1, 1, 143},
            },
            new int[][] {
                new int[] {-1, 3, 232},
                new int[] {9, 0, 131},
                new int[] {10, 0, 132},
                new int[] {17, 0, 133},
                new int[] {20, 0, 236},
                new int[] {32, 0, 134},
            },
            new int[][] {
                new int[] {-1, 1, 61},
            },
            new int[][] {
                new int[] {-1, 3, 234},
                new int[] {34, 0, 238},
            },
            new int[][] {
                new int[] {-1, 3, 235},
                new int[] {34, 0, 239},
            },
            new int[][] {
                new int[] {-1, 1, 62},
            },
            new int[][] {
                new int[] {-1, 3, 237},
                new int[] {20, 0, 240},
            },
            new int[][] {
                new int[] {-1, 3, 238},
                new int[] {28, 0, 241},
            },
            new int[][] {
                new int[] {-1, 3, 239},
                new int[] {28, 0, 242},
            },
            new int[][] {
                new int[] {-1, 1, 63},
            },
            new int[][] {
                new int[] {-1, 3, 241},
                new int[] {34, 0, 243},
            },
            new int[][] {
                new int[] {-1, 3, 242},
                new int[] {34, 0, 244},
            },
            new int[][] {
                new int[] {-1, 3, 243},
                new int[] {28, 0, 245},
            },
            new int[][] {
                new int[] {-1, 3, 244},
                new int[] {28, 0, 246},
            },
            new int[][] {
                new int[] {-1, 3, 245},
                new int[] {34, 0, 247},
            },
            new int[][] {
                new int[] {-1, 3, 246},
                new int[] {34, 0, 248},
            },
            new int[][] {
                new int[] {-1, 3, 247},
                new int[] {20, 0, 249},
            },
            new int[][] {
                new int[] {-1, 3, 248},
                new int[] {20, 0, 250},
            },
            new int[][] {
                new int[] {-1, 1, 115},
            },
            new int[][] {
                new int[] {-1, 1, 116},
            },
        };
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
                new int[] {31, 51},
                new int[] {57, 102},
            },
            new int[][] {
                new int[] {-1, 42},
                new int[] {43, 60},
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
                new int[] {-1, 78},
                new int[] {79, 118},
                new int[] {161, 118},
            },
            new int[][] {
                new int[] {-1, 15},
            },
            new int[][] {
                new int[] {-1, 121},
                new int[] {122, 165},
            },
            new int[][] {
                new int[] {-1, 68},
                new int[] {48, 80},
                new int[] {62, 105},
                new int[] {81, 122},
                new int[] {120, 162},
            },
            new int[][] {
                new int[] {-1, 108},
                new int[] {109, 158},
            },
            new int[][] {
                new int[] {-1, 69},
                new int[] {107, 157},
            },
            new int[][] {
                new int[] {-1, 113},
                new int[] {96, 144},
                new int[] {100, 150},
                new int[] {143, 182},
                new int[] {149, 185},
            },
            new int[][] {
                new int[] {-1, 70},
                new int[] {74, 114},
            },
            new int[][] {
                new int[] {-1, 71},
                new int[] {61, 103},
                new int[] {153, 193},
                new int[] {154, 194},
            },
            new int[][] {
                new int[] {-1, 72},
                new int[] {61, 104},
                new int[] {155, 195},
            },
            new int[][] {
                new int[] {-1, 73},
            },
            new int[][] {
                new int[] {-1, 16},
            },
            new int[][] {
                new int[] {-1, 33},
                new int[] {34, 56},
                new int[] {35, 56},
            },
            new int[][] {
                new int[] {-1, 55},
            },
            new int[][] {
                new int[] {-1, 90},
                new int[] {87, 128},
                new int[] {93, 140},
                new int[] {97, 145},
                new int[] {129, 171},
                new int[] {130, 173},
                new int[] {141, 180},
                new int[] {172, 201},
            },
            new int[][] {
                new int[] {-1, 176},
                new int[] {88, 135},
                new int[] {126, 169},
                new int[] {204, 223},
            },
            new int[][] {
                new int[] {-1, 177},
                new int[] {203, 222},
                new int[] {232, 237},
            },
            new int[][] {
                new int[] {-1, 205},
                new int[] {206, 224},
            },
            new int[][] {
                new int[] {-1, 136},
            },
            new int[][] {
                new int[] {-1, 91},
                new int[] {101, 151},
            },
            new int[][] {
                new int[] {-1, 92},
                new int[] {98, 148},
                new int[] {137, 148},
                new int[] {142, 148},
                new int[] {147, 148},
                new int[] {179, 148},
                new int[] {181, 148},
                new int[] {183, 148},
                new int[] {209, 148},
            },
            new int[][] {
                new int[] {-1, 93},
                new int[] {87, 129},
            },
            new int[][] {
                new int[] {-1, 94},
                new int[] {97, 146},
                new int[] {130, 146},
                new int[] {141, 146},
                new int[] {172, 146},
            },
            new int[][] {
                new int[] {-1, 95},
            },
            new int[][] {
                new int[] {-1, 96},
                new int[] {95, 143},
            },
            new int[][] {
                new int[] {-1, 17},
            },
            new int[][] {
                new int[] {-1, 18},
            },
            new int[][] {
                new int[] {-1, 37},
                new int[] {38, 58},
            },
            new int[][] {
                new int[] {-1, 191},
            },
            new int[][] {
                new int[] {-1, 215},
                new int[] {216, 231},
            },
            new int[][] {
                new int[] {-1, 192},
                new int[] {214, 230},
            },
            new int[][] {
                new int[] {-1, 228},
                new int[] {212, 229},
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
                new int[] {-1, 30},
            },
            new int[][] {
                new int[] {-1, 79},
                new int[] {116, 161},
            },
            new int[][] {
                new int[] {-1, 109},
            },
            new int[][] {
                new int[] {-1, 74},
            },
            new int[][] {
                new int[] {-1, 34},
                new int[] {7, 35},
            },
            new int[][] {
                new int[] {-1, 206},
            },
            new int[][] {
                new int[] {-1, 97},
                new int[] {87, 130},
                new int[] {93, 141},
                new int[] {129, 172},
            },
            new int[][] {
                new int[] {-1, 98},
                new int[] {90, 137},
                new int[] {93, 142},
                new int[] {97, 147},
                new int[] {140, 179},
                new int[] {141, 181},
                new int[] {145, 183},
                new int[] {180, 209},
            },
            new int[][] {
                new int[] {-1, 38},
            },
            new int[][] {
                new int[] {-1, 216},
            },
        };
        private static string[] errorMessages = {
            "expecting: packagetoken, 'States', 'Helpers', 'Tokens', 'Ignored', 'Productions', asttoken, 'Token Syntax Highlight', EOF",
            "expecting: packagename",
            "expecting: identifier",
            "expecting: '{', identifier",
            "expecting: 'Tokens'",
            "expecting: EOF",
            "expecting: ';'",
            "expecting: ';', '}', ','",
            "expecting: '='",
            "expecting: packagetoken, 'States', 'Helpers', 'Tokens', 'Ignored', 'Productions', asttoken, 'Token Syntax Highlight', identifier, EOF",
            "expecting: packagetoken, 'States', 'Helpers', 'Tokens', 'Ignored', 'Productions', asttoken, 'Token Syntax Highlight', '{', identifier, EOF",
            "expecting: '=', '{', '->'",
            "expecting: '{'",
            "expecting: '[', '(', identifier, character, dec char, hex char, string",
            "expecting: '}', ',', '->'",
            "expecting: 'T', 'P', ';', '[', '{', '|', '->', identifier",
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
            "expecting: 'New', 'Null', '[', identifier",
            "expecting: 'T', 'P', ';', '[', '{', '+', '?', '*', '|', '->', identifier",
            "expecting: ';', '|'",
            "expecting: 'T', 'P', identifier",
            "expecting: '=', '+', '?', '*'",
            "expecting: '}'",
            "expecting: '+', '-'",
            "expecting: '..', '+', '-'",
            "expecting: ')'",
            "expecting: 'T', 'P', ';', '=', '[', '(', ')', '{', '}', '|', '/', '->', identifier, character, dec char, hex char, string",
            "expecting: ']'",
            "expecting: ';', ']', ')', '}', '|', ','",
            "expecting: 'New', 'Null', '[', ']', identifier",
            "expecting: '.', ';', ']', ')', '}', '|', ','",
            "expecting: '}', '+', '?', '*'",
            "expecting: 'italic', 'bold', 'text', 'background'",
            "expecting: character, dec char, hex char",
            "expecting: ':'",
            "expecting: '.', '('",
            "expecting: ']', ')', ','",
            "expecting: ';', ','",
            "expecting: 'New', 'Null', '[', ')', identifier",
            "expecting: 'rgb', hsv, hex color",
            "expecting: '('",
            "expecting: dec char",
            "expecting: ','",
        };
        private static int[] errors = {
            0, 1, 2, 2, 3, 4, 2, 2, 2, 5, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 6, 7, 6, 8, 9, 9, 2, 8, 10, 2, 10, 2,
            11, 9, 9, 9, 12, 9, 9, 0, 0, 2, 7, 7, 0, 13, 9, 14,
            13, 8, 10, 6, 15, 16, 2, 8, 9, 2, 9, 7, 7, 13, 13, 17,
            18, 18, 18, 17, 6, 19, 20, 21, 22, 17, 20, 2, 2, 2, 23, 23,
            24, 13, 0, 25, 25, 2, 26, 15, 27, 28, 29, 6, 29, 15, 15, 30,
            28, 15, 29, 2, 31, 15, 32, 33, 34, 35, 9, 13, 19, 19, 36, 36,
            36, 20, 20, 14, 23, 2, 23, 10, 13, 6, 24, 2, 2, 37, 27, 32,
            29, 15, 15, 2, 38, 39, 40, 29, 38, 29, 9, 16, 29, 15, 29, 28,
            15, 29, 15, 29, 29, 41, 8, 6, 42, 13, 13, 43, 17, 19, 19, 2,
            2, 23, 6, 10, 10, 6, 28, 28, 44, 32, 15, 29, 15, 29, 45, 38,
            46, 37, 2, 29, 29, 29, 15, 29, 8, 32, 9, 47, 47, 44, 44, 6,
            47, 37, 37, 37, 23, 2, 10, 30, 29, 29, 2, 48, 27, 46, 46, 38,
            38, 29, 8, 49, 49, 9, 42, 47, 47, 17, 17, 17, 50, 38, 35, 46,
            46, 50, 50, 47, 47, 47, 47, 47, 48, 38, 51, 51, 38, 35, 52, 52,
            38, 51, 51, 52, 52, 51, 51, 35, 35, 47, 47,
        };
    }
}
