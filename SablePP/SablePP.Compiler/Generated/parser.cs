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
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        Push(17, pregexpart);
                    }
                    break;
                case 35:
                    {
                        TStar tstar = Pop<TStar>();
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        AUnarystarRegexpart aunarystarregexpart = new AUnarystarRegexpart(
                            pregexpart,
                            tstar
                        );
                        Push(17, aunarystarregexpart);
                    }
                    break;
                case 36:
                    {
                        TQMark tqmark = Pop<TQMark>();
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        AUnaryquestionRegexpart aunaryquestionregexpart = new AUnaryquestionRegexpart(
                            pregexpart,
                            tqmark
                        );
                        Push(17, aunaryquestionregexpart);
                    }
                    break;
                case 37:
                    {
                        TPlus tplus = Pop<TPlus>();
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        AUnaryplusRegexpart aunaryplusregexpart = new AUnaryplusRegexpart(
                            pregexpart,
                            tplus
                        );
                        Push(17, aunaryplusregexpart);
                    }
                    break;
                case 38:
                    {
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        Push(18, pregexpart);
                    }
                    break;
                case 39:
                    {
                        PRegexpart pregexpart = Pop<PRegexpart>();
                        Push(18, pregexpart);
                    }
                    break;
                case 40:
                    {
                        TString tstring = Pop<TString>();
                        AStringRegexpart astringregexpart = new AStringRegexpart(
                            tstring
                        );
                        Push(18, astringregexpart);
                    }
                    break;
                case 41:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AIdentifierRegexpart aidentifierregexpart = new AIdentifierRegexpart(
                            tidentifier
                        );
                        Push(18, aidentifierregexpart);
                    }
                    break;
                case 42:
                    {
                        TRPar trpar = Pop<TRPar>();
                        PRegex pregex = Pop<PRegex>();
                        TLPar tlpar = Pop<TLPar>();
                        AParenthesisRegexpart aparenthesisregexpart = new AParenthesisRegexpart(
                            tlpar,
                            pregex,
                            trpar
                        );
                        Push(18, aparenthesisregexpart);
                    }
                    break;
                case 43:
                    {
                        TCharacter tcharacter = Pop<TCharacter>();
                        ACharRegexpart acharregexpart = new ACharRegexpart(
                            tcharacter
                        );
                        Push(19, acharregexpart);
                    }
                    break;
                case 44:
                    {
                        TDecChar tdecchar = Pop<TDecChar>();
                        ADecRegexpart adecregexpart = new ADecRegexpart(
                            tdecchar
                        );
                        Push(19, adecregexpart);
                    }
                    break;
                case 45:
                    {
                        THexChar thexchar = Pop<THexChar>();
                        AHexRegexpart ahexregexpart = new AHexRegexpart(
                            thexchar
                        );
                        Push(19, ahexregexpart);
                    }
                    break;
                case 46:
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
                        Push(20, abinaryplusregexpart);
                    }
                    break;
                case 47:
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
                        Push(20, abinaryminusregexpart);
                    }
                    break;
                case 48:
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
                        Push(20, aintervalregexpart);
                    }
                    break;
                case 49:
                    {
                        List<PProduction> pproductionlist = Pop<List<PProduction>>();
                        TProductionstoken tproductionstoken = Pop<TProductionstoken>();
                        List<PProduction> pproductionlist2 = new List<PProduction>();
                        pproductionlist2.AddRange(pproductionlist);
                        AProductions aproductions = new AProductions(
                            tproductionstoken,
                            pproductionlist2
                        );
                        Push(21, aproductions);
                    }
                    break;
                case 50:
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
                        Push(22, aproduction);
                    }
                    break;
                case 51:
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
                        Push(22, aproduction);
                    }
                    break;
                case 52:
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
                        Push(23, acleanprodtranslation);
                    }
                    break;
                case 53:
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
                        Push(23, astarprodtranslation);
                    }
                    break;
                case 54:
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
                        Push(23, aplusprodtranslation);
                    }
                    break;
                case 55:
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
                        Push(23, aquestionprodtranslation);
                    }
                    break;
                case 56:
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
                        Push(24, afulltranslation);
                    }
                    break;
                case 57:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        Push(25, ptranslation);
                    }
                    break;
                case 58:
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
                        Push(25, anewtranslation);
                    }
                    break;
                case 59:
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
                        Push(25, anewtranslation);
                    }
                    break;
                case 60:
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
                        Push(25, anewalternativetranslation);
                    }
                    break;
                case 61:
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
                        Push(25, anewalternativetranslation);
                    }
                    break;
                case 62:
                    {
                        TNull tnull = Pop<TNull>();
                        ANullTranslation anulltranslation = new ANullTranslation(
                            tnull
                        );
                        Push(25, anulltranslation);
                    }
                    break;
                case 63:
                    {
                        TRBkt trbkt = Pop<TRBkt>();
                        TLBkt tlbkt = Pop<TLBkt>();
                        List<PTranslationListitem> ptranslationlistitemlist = new List<PTranslationListitem>();
                        AListTranslation alisttranslation = new AListTranslation(
                            tlbkt,
                            ptranslationlistitemlist,
                            trbkt
                        );
                        Push(25, alisttranslation);
                    }
                    break;
                case 64:
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
                        Push(25, alisttranslation);
                    }
                    break;
                case 65:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        ATranslationListitem atranslationlistitem = new ATranslationListitem(
                            null,
                            ptranslation
                        );
                        List<PTranslationListitem> ptranslationlistitemlist = new List<PTranslationListitem>();
                        ptranslationlistitemlist.Add(atranslationlistitem);
                        Push(26, ptranslationlistitemlist);
                    }
                    break;
                case 66:
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
                        Push(26, ptranslationlistitemlist2);
                    }
                    break;
                case 67:
                    {
                        PTranslation ptranslation = Pop<PTranslation>();
                        TComma tcomma = Pop<TComma>();
                        ATranslationListitem atranslationlistitem = new ATranslationListitem(
                            tcomma,
                            ptranslation
                        );
                        Push(27, atranslationlistitem);
                    }
                    break;
                case 68:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        AIdTranslation aidtranslation = new AIdTranslation(
                            tidentifier
                        );
                        Push(28, aidtranslation);
                    }
                    break;
                case 69:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TIdentifier tidentifier2 = Pop<TIdentifier>();
                        AIddotidTranslation aiddotidtranslation = new AIddotidTranslation(
                            tidentifier2,
                            tdot,
                            tidentifier
                        );
                        Push(28, aiddotidtranslation);
                    }
                    break;
                case 70:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 71:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 72:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 73:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 74:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 75:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 76:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 77:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 78:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 79:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 80:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 81:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 82:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 83:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 84:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 85:
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
                        Push(29, aproductionrule);
                    }
                    break;
                case 86:
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
                        Push(30, aalternative);
                    }
                    break;
                case 87:
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
                        Push(30, aalternative);
                    }
                    break;
                case 88:
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
                        Push(30, aalternative);
                    }
                    break;
                case 89:
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
                        Push(30, aalternative);
                    }
                    break;
                case 90:
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
                        Push(30, aalternative);
                    }
                    break;
                case 91:
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
                        Push(30, aalternative);
                    }
                    break;
                case 92:
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
                        Push(30, aalternative);
                    }
                    break;
                case 93:
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
                        Push(30, aalternative);
                    }
                    break;
                case 94:
                    {
                        TRBrace trbrace = Pop<TRBrace>();
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TLBrace tlbrace = Pop<TLBrace>();
                        AAlternativename aalternativename = new AAlternativename(
                            tlbrace,
                            tidentifier,
                            trbrace
                        );
                        Push(31, aalternativename);
                    }
                    break;
                case 95:
                    {
                        PElementid pelementid = Pop<PElementid>();
                        ASimpleElement asimpleelement = new ASimpleElement(
                            null,
                            pelementid
                        );
                        Push(32, asimpleelement);
                    }
                    break;
                case 96:
                    {
                        PElementid pelementid = Pop<PElementid>();
                        PElementname pelementname = Pop<PElementname>();
                        ASimpleElement asimpleelement = new ASimpleElement(
                            pelementname,
                            pelementid
                        );
                        Push(32, asimpleelement);
                    }
                    break;
                case 97:
                    {
                        TStar tstar = Pop<TStar>();
                        PElementid pelementid = Pop<PElementid>();
                        AStarElement astarelement = new AStarElement(
                            null,
                            pelementid,
                            tstar
                        );
                        Push(32, astarelement);
                    }
                    break;
                case 98:
                    {
                        TStar tstar = Pop<TStar>();
                        PElementid pelementid = Pop<PElementid>();
                        PElementname pelementname = Pop<PElementname>();
                        AStarElement astarelement = new AStarElement(
                            pelementname,
                            pelementid,
                            tstar
                        );
                        Push(32, astarelement);
                    }
                    break;
                case 99:
                    {
                        TQMark tqmark = Pop<TQMark>();
                        PElementid pelementid = Pop<PElementid>();
                        AQuestionElement aquestionelement = new AQuestionElement(
                            null,
                            pelementid,
                            tqmark
                        );
                        Push(32, aquestionelement);
                    }
                    break;
                case 100:
                    {
                        TQMark tqmark = Pop<TQMark>();
                        PElementid pelementid = Pop<PElementid>();
                        PElementname pelementname = Pop<PElementname>();
                        AQuestionElement aquestionelement = new AQuestionElement(
                            pelementname,
                            pelementid,
                            tqmark
                        );
                        Push(32, aquestionelement);
                    }
                    break;
                case 101:
                    {
                        TPlus tplus = Pop<TPlus>();
                        PElementid pelementid = Pop<PElementid>();
                        APlusElement apluselement = new APlusElement(
                            null,
                            pelementid,
                            tplus
                        );
                        Push(32, apluselement);
                    }
                    break;
                case 102:
                    {
                        TPlus tplus = Pop<TPlus>();
                        PElementid pelementid = Pop<PElementid>();
                        PElementname pelementname = Pop<PElementname>();
                        APlusElement apluselement = new APlusElement(
                            pelementname,
                            pelementid,
                            tplus
                        );
                        Push(32, apluselement);
                    }
                    break;
                case 103:
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
                        Push(33, aelementname);
                    }
                    break;
                case 104:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        ACleanElementid acleanelementid = new ACleanElementid(
                            tidentifier
                        );
                        Push(34, acleanelementid);
                    }
                    break;
                case 105:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TTokenSpecifier ttokenspecifier = Pop<TTokenSpecifier>();
                        ATokenElementid atokenelementid = new ATokenElementid(
                            ttokenspecifier,
                            tdot,
                            tidentifier
                        );
                        Push(34, atokenelementid);
                    }
                    break;
                case 106:
                    {
                        TIdentifier tidentifier = Pop<TIdentifier>();
                        TDot tdot = Pop<TDot>();
                        TProductionSpecifier tproductionspecifier = Pop<TProductionSpecifier>();
                        AProductionElementid aproductionelementid = new AProductionElementid(
                            tproductionspecifier,
                            tdot,
                            tidentifier
                        );
                        Push(34, aproductionelementid);
                    }
                    break;
                case 107:
                    {
                        List<PProduction> pproductionlist = Pop<List<PProduction>>();
                        TAsttoken tasttoken = Pop<TAsttoken>();
                        List<PProduction> pproductionlist2 = new List<PProduction>();
                        pproductionlist2.AddRange(pproductionlist);
                        AAstproductions aastproductions = new AAstproductions(
                            tasttoken,
                            pproductionlist2
                        );
                        Push(35, aastproductions);
                    }
                    break;
                case 108:
                    {
                        List<PHighlightrule> phighlightrule = Pop<List<PHighlightrule>>();
                        THighlighttoken thighlighttoken = Pop<THighlighttoken>();
                        AHighlightrules ahighlightrules = new AHighlightrules(
                            thighlighttoken,
                            phighlightrule
                        );
                        Push(36, ahighlightrules);
                    }
                    break;
                case 109:
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
                        Push(37, ahighlightrule);
                    }
                    break;
                case 110:
                    {
                        PHighlightStyle phighlightstyle = Pop<PHighlightStyle>();
                        AStyleListitem astylelistitem = new AStyleListitem(
                            null,
                            phighlightstyle
                        );
                        List<PStyleListitem> pstylelistitemlist = new List<PStyleListitem>();
                        pstylelistitemlist.Add(astylelistitem);
                        Push(38, pstylelistitemlist);
                    }
                    break;
                case 111:
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
                        Push(38, pstylelistitemlist2);
                    }
                    break;
                case 112:
                    {
                        PHighlightStyle phighlightstyle = Pop<PHighlightStyle>();
                        TComma tcomma = Pop<TComma>();
                        AStyleListitem astylelistitem = new AStyleListitem(
                            tcomma,
                            phighlightstyle
                        );
                        Push(39, astylelistitem);
                    }
                    break;
                case 113:
                    {
                        TItalic titalic = Pop<TItalic>();
                        AItalicHighlightStyle aitalichighlightstyle = new AItalicHighlightStyle(
                            titalic
                        );
                        Push(40, aitalichighlightstyle);
                    }
                    break;
                case 114:
                    {
                        TBold tbold = Pop<TBold>();
                        ABoldHighlightStyle aboldhighlightstyle = new ABoldHighlightStyle(
                            tbold
                        );
                        Push(40, aboldhighlightstyle);
                    }
                    break;
                case 115:
                    {
                        PColor pcolor = Pop<PColor>();
                        TColon tcolon = Pop<TColon>();
                        TText ttext = Pop<TText>();
                        ATextHighlightStyle atexthighlightstyle = new ATextHighlightStyle(
                            ttext,
                            tcolon,
                            pcolor
                        );
                        Push(40, atexthighlightstyle);
                    }
                    break;
                case 116:
                    {
                        PColor pcolor = Pop<PColor>();
                        TColon tcolon = Pop<TColon>();
                        TBackground tbackground = Pop<TBackground>();
                        ABackgroundHighlightStyle abackgroundhighlightstyle = new ABackgroundHighlightStyle(
                            tbackground,
                            tcolon,
                            pcolor
                        );
                        Push(40, abackgroundhighlightstyle);
                    }
                    break;
                case 117:
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
                        Push(41, argbcolor);
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
                        Push(41, ahsvcolor);
                    }
                    break;
                case 119:
                    {
                        THexColor thexcolor = Pop<THexColor>();
                        AHexColor ahexcolor = new AHexColor(
                            thexcolor
                        );
                        Push(41, ahexcolor);
                    }
                    break;
                case 120:
                    Push(42, new List<PSection>() { Pop<PSection>() });
                    break;
                case 121:
                    {
                        PSection item = Pop<PSection>();
                        List<PSection> list = Pop<List<PSection>>();
                        list.Add(item);
                        Push(42, list);
                    }
                    break;
                case 122:
                    Push(43, new List<PHelper>() { Pop<PHelper>() });
                    break;
                case 123:
                    {
                        PHelper item = Pop<PHelper>();
                        List<PHelper> list = Pop<List<PHelper>>();
                        list.Add(item);
                        Push(43, list);
                    }
                    break;
                case 124:
                    Push(44, new List<PIdentifierListitem>() { Pop<PIdentifierListitem>() });
                    break;
                case 125:
                    {
                        PIdentifierListitem item = Pop<PIdentifierListitem>();
                        List<PIdentifierListitem> list = Pop<List<PIdentifierListitem>>();
                        list.Add(item);
                        Push(44, list);
                    }
                    break;
                case 126:
                    Push(45, new List<PToken>() { Pop<PToken>() });
                    break;
                case 127:
                    {
                        PToken item = Pop<PToken>();
                        List<PToken> list = Pop<List<PToken>>();
                        list.Add(item);
                        Push(45, list);
                    }
                    break;
                case 128:
                    Push(46, new List<PTokenstateListitem>() { Pop<PTokenstateListitem>() });
                    break;
                case 129:
                    {
                        PTokenstateListitem item = Pop<PTokenstateListitem>();
                        List<PTokenstateListitem> list = Pop<List<PTokenstateListitem>>();
                        list.Add(item);
                        Push(46, list);
                    }
                    break;
                case 130:
                    Push(47, new List<POrpart>() { Pop<POrpart>() });
                    break;
                case 131:
                    {
                        POrpart item = Pop<POrpart>();
                        List<POrpart> list = Pop<List<POrpart>>();
                        list.Add(item);
                        Push(47, list);
                    }
                    break;
                case 132:
                    Push(48, new List<PRegexpart>() { Pop<PRegexpart>() });
                    break;
                case 133:
                    {
                        PRegexpart item = Pop<PRegexpart>();
                        List<PRegexpart> list = Pop<List<PRegexpart>>();
                        list.Add(item);
                        Push(48, list);
                    }
                    break;
                case 134:
                    Push(49, new List<PProduction>() { Pop<PProduction>() });
                    break;
                case 135:
                    {
                        PProduction item = Pop<PProduction>();
                        List<PProduction> list = Pop<List<PProduction>>();
                        list.Add(item);
                        Push(49, list);
                    }
                    break;
                case 136:
                    Push(50, new List<PTranslationListitem>() { Pop<PTranslationListitem>() });
                    break;
                case 137:
                    {
                        PTranslationListitem item = Pop<PTranslationListitem>();
                        List<PTranslationListitem> list = Pop<List<PTranslationListitem>>();
                        list.Add(item);
                        Push(50, list);
                    }
                    break;
                case 138:
                    Push(51, new List<PElement>() { Pop<PElement>() });
                    break;
                case 139:
                    {
                        PElement item = Pop<PElement>();
                        List<PElement> list = Pop<List<PElement>>();
                        list.Add(item);
                        Push(51, list);
                    }
                    break;
                case 140:
                    Push(52, new List<PAlternative>() { Pop<PAlternative>() });
                    break;
                case 141:
                    {
                        PAlternative item = Pop<PAlternative>();
                        List<PAlternative> list = Pop<List<PAlternative>>();
                        list.Add(item);
                        Push(52, list);
                    }
                    break;
                case 142:
                    Push(53, new List<PHighlightrule>() { Pop<PHighlightrule>() });
                    break;
                case 143:
                    {
                        PHighlightrule item = Pop<PHighlightrule>();
                        List<PHighlightrule> list = Pop<List<PHighlightrule>>();
                        list.Add(item);
                        Push(53, list);
                    }
                    break;
                case 144:
                    Push(54, new List<PStyleListitem>() { Pop<PStyleListitem>() });
                    break;
                case 145:
                    {
                        PStyleListitem item = Pop<PStyleListitem>();
                        List<PStyleListitem> list = Pop<List<PStyleListitem>>();
                        list.Add(item);
                        Push(54, list);
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
                new int[] {-1, 1, 120},
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
                new int[] {-1, 1, 122},
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
                new int[] {-1, 1, 126},
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
            },
            new int[][] {
                new int[] {-1, 1, 134},
            },
            new int[][] {
                new int[] {-1, 1, 49},
                new int[] {32, 0, 32},
            },
            new int[][] {
                new int[] {-1, 1, 107},
                new int[] {32, 0, 32},
            },
            new int[][] {
                new int[] {-1, 3, 36},
                new int[] {21, 0, 56},
            },
            new int[][] {
                new int[] {-1, 1, 142},
            },
            new int[][] {
                new int[] {-1, 1, 108},
                new int[] {32, 0, 36},
            },
            new int[][] {
                new int[] {-1, 1, 121},
            },
            new int[][] {
                new int[] {-1, 1, 10},
            },
            new int[][] {
                new int[] {-1, 3, 41},
                new int[] {32, 0, 58},
            },
            new int[][] {
                new int[] {-1, 1, 124},
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
                new int[] {17, 0, 60},
                new int[] {19, 0, 61},
                new int[] {32, 0, 62},
                new int[] {33, 0, 63},
                new int[] {34, 0, 64},
                new int[] {35, 0, 65},
                new int[] {36, 0, 66},
            },
            new int[][] {
                new int[] {-1, 1, 123},
            },
            new int[][] {
                new int[] {-1, 3, 47},
                new int[] {22, 0, 74},
                new int[] {28, 0, 75},
                new int[] {30, 0, 76},
            },
            new int[][] {
                new int[] {-1, 3, 48},
                new int[] {17, 0, 60},
                new int[] {19, 0, 61},
                new int[] {32, 0, 62},
                new int[] {33, 0, 63},
                new int[] {34, 0, 64},
                new int[] {35, 0, 65},
                new int[] {36, 0, 66},
            },
            new int[][] {
                new int[] {-1, 3, 49},
                new int[] {16, 0, 80},
            },
            new int[][] {
                new int[] {-1, 1, 127},
            },
            new int[][] {
                new int[] {-1, 3, 51},
                new int[] {15, 0, 81},
            },
            new int[][] {
                new int[] {-1, 1, 70},
                new int[] {11, 0, 82},
                new int[] {12, 0, 83},
                new int[] {17, 0, 84},
                new int[] {21, 0, 85},
                new int[] {27, 0, 86},
                new int[] {32, 0, 87},
            },
            new int[][] {
                new int[] {-1, 3, 53},
                new int[] {30, 0, 97},
            },
            new int[][] {
                new int[] {-1, 3, 54},
                new int[] {16, 0, 98},
            },
            new int[][] {
                new int[] {-1, 1, 135},
            },
            new int[][] {
                new int[] {-1, 3, 56},
                new int[] {32, 0, 21},
            },
            new int[][] {
                new int[] {-1, 1, 143},
            },
            new int[][] {
                new int[] {-1, 1, 16},
            },
            new int[][] {
                new int[] {-1, 1, 125},
            },
            new int[][] {
                new int[] {-1, 3, 60},
                new int[] {17, 0, 60},
                new int[] {19, 0, 61},
                new int[] {32, 0, 62},
                new int[] {33, 0, 63},
                new int[] {34, 0, 64},
                new int[] {35, 0, 65},
                new int[] {36, 0, 66},
            },
            new int[][] {
                new int[] {-1, 3, 61},
                new int[] {17, 0, 60},
                new int[] {19, 0, 61},
                new int[] {32, 0, 62},
                new int[] {33, 0, 63},
                new int[] {34, 0, 64},
                new int[] {35, 0, 65},
                new int[] {36, 0, 66},
            },
            new int[][] {
                new int[] {-1, 1, 41},
            },
            new int[][] {
                new int[] {-1, 1, 43},
            },
            new int[][] {
                new int[] {-1, 1, 44},
            },
            new int[][] {
                new int[] {-1, 1, 45},
            },
            new int[][] {
                new int[] {-1, 1, 40},
            },
            new int[][] {
                new int[] {-1, 3, 67},
                new int[] {15, 0, 103},
            },
            new int[][] {
                new int[] {-1, 1, 30},
                new int[] {27, 0, 104},
            },
            new int[][] {
                new int[] {-1, 1, 132},
            },
            new int[][] {
                new int[] {-1, 1, 34},
                new int[] {23, 0, 107},
                new int[] {25, 0, 108},
                new int[] {26, 0, 109},
            },
            new int[][] {
                new int[] {-1, 1, 38},
            },
            new int[][] {
                new int[] {-1, 1, 39},
            },
            new int[][] {
                new int[] {-1, 1, 33},
                new int[] {17, 0, 60},
                new int[] {19, 0, 61},
                new int[] {32, 0, 62},
                new int[] {33, 0, 63},
                new int[] {34, 0, 64},
                new int[] {35, 0, 65},
                new int[] {36, 0, 66},
            },
            new int[][] {
                new int[] {-1, 1, 22},
            },
            new int[][] {
                new int[] {-1, 3, 75},
                new int[] {32, 0, 111},
            },
            new int[][] {
                new int[] {-1, 3, 76},
                new int[] {32, 0, 112},
            },
            new int[][] {
                new int[] {-1, 1, 128},
            },
            new int[][] {
                new int[] {-1, 3, 78},
                new int[] {22, 0, 113},
                new int[] {28, 0, 75},
            },
            new int[][] {
                new int[] {-1, 3, 79},
                new int[] {15, 0, 115},
                new int[] {29, 0, 116},
            },
            new int[][] {
                new int[] {-1, 3, 80},
                new int[] {17, 0, 60},
                new int[] {19, 0, 61},
                new int[] {32, 0, 62},
                new int[] {33, 0, 63},
                new int[] {34, 0, 64},
                new int[] {35, 0, 65},
                new int[] {36, 0, 66},
            },
            new int[][] {
                new int[] {-1, 1, 28},
            },
            new int[][] {
                new int[] {-1, 3, 82},
                new int[] {13, 0, 119},
            },
            new int[][] {
                new int[] {-1, 3, 83},
                new int[] {13, 0, 120},
            },
            new int[][] {
                new int[] {-1, 3, 84},
                new int[] {32, 0, 121},
            },
            new int[][] {
                new int[] {-1, 3, 85},
                new int[] {30, 0, 122},
                new int[] {32, 0, 123},
            },
            new int[][] {
                new int[] {-1, 1, 86},
                new int[] {11, 0, 82},
                new int[] {12, 0, 83},
                new int[] {17, 0, 84},
                new int[] {21, 0, 85},
                new int[] {32, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 104},
            },
            new int[][] {
                new int[] {-1, 1, 74},
                new int[] {27, 0, 86},
            },
            new int[][] {
                new int[] {-1, 3, 89},
                new int[] {15, 0, 128},
            },
            new int[][] {
                new int[] {-1, 1, 140},
            },
            new int[][] {
                new int[] {-1, 1, 71},
                new int[] {11, 0, 82},
                new int[] {12, 0, 83},
                new int[] {17, 0, 84},
                new int[] {21, 0, 129},
                new int[] {27, 0, 86},
                new int[] {32, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 138},
            },
            new int[][] {
                new int[] {-1, 3, 93},
                new int[] {11, 0, 82},
                new int[] {12, 0, 83},
                new int[] {32, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 95},
                new int[] {23, 0, 134},
                new int[] {25, 0, 135},
                new int[] {26, 0, 136},
            },
            new int[][] {
                new int[] {-1, 1, 72},
                new int[] {11, 0, 82},
                new int[] {12, 0, 83},
                new int[] {17, 0, 84},
                new int[] {21, 0, 129},
                new int[] {27, 0, 86},
                new int[] {32, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 78},
                new int[] {27, 0, 86},
            },
            new int[][] {
                new int[] {-1, 3, 97},
                new int[] {32, 0, 141},
            },
            new int[][] {
                new int[] {-1, 1, 70},
                new int[] {11, 0, 82},
                new int[] {12, 0, 83},
                new int[] {17, 0, 84},
                new int[] {21, 0, 85},
                new int[] {27, 0, 86},
                new int[] {32, 0, 87},
            },
            new int[][] {
                new int[] {-1, 3, 99},
                new int[] {22, 0, 143},
            },
            new int[][] {
                new int[] {-1, 3, 100},
                new int[] {23, 0, 144},
                new int[] {24, 0, 145},
            },
            new int[][] {
                new int[] {-1, 1, 38},
                new int[] {14, 0, 146},
            },
            new int[][] {
                new int[] {-1, 3, 102},
                new int[] {20, 0, 147},
            },
            new int[][] {
                new int[] {-1, 1, 12},
            },
            new int[][] {
                new int[] {-1, 3, 104},
                new int[] {17, 0, 60},
                new int[] {19, 0, 61},
                new int[] {32, 0, 62},
                new int[] {33, 0, 63},
                new int[] {34, 0, 64},
                new int[] {35, 0, 65},
                new int[] {36, 0, 66},
            },
            new int[][] {
                new int[] {-1, 1, 130},
            },
            new int[][] {
                new int[] {-1, 1, 31},
                new int[] {27, 0, 104},
            },
            new int[][] {
                new int[] {-1, 1, 37},
            },
            new int[][] {
                new int[] {-1, 1, 36},
            },
            new int[][] {
                new int[] {-1, 1, 35},
            },
            new int[][] {
                new int[] {-1, 1, 133},
            },
            new int[][] {
                new int[] {-1, 1, 26},
                new int[] {30, 0, 150},
            },
            new int[][] {
                new int[] {-1, 3, 112},
                new int[] {22, 0, 151},
                new int[] {28, 0, 75},
            },
            new int[][] {
                new int[] {-1, 1, 23},
            },
            new int[][] {
                new int[] {-1, 1, 129},
            },
            new int[][] {
                new int[] {-1, 1, 18},
            },
            new int[][] {
                new int[] {-1, 3, 116},
                new int[] {17, 0, 60},
                new int[] {19, 0, 61},
                new int[] {32, 0, 62},
                new int[] {33, 0, 63},
                new int[] {34, 0, 64},
                new int[] {35, 0, 65},
                new int[] {36, 0, 66},
            },
            new int[][] {
                new int[] {-1, 3, 117},
                new int[] {15, 0, 154},
            },
            new int[][] {
                new int[] {-1, 3, 118},
                new int[] {15, 0, 155},
                new int[] {29, 0, 116},
            },
            new int[][] {
                new int[] {-1, 3, 119},
                new int[] {32, 0, 157},
            },
            new int[][] {
                new int[] {-1, 3, 120},
                new int[] {32, 0, 158},
            },
            new int[][] {
                new int[] {-1, 3, 121},
                new int[] {18, 0, 159},
            },
            new int[][] {
                new int[] {-1, 3, 122},
                new int[] {9, 0, 160},
                new int[] {10, 0, 161},
                new int[] {17, 0, 162},
                new int[] {32, 0, 163},
            },
            new int[][] {
                new int[] {-1, 3, 123},
                new int[] {22, 0, 166},
            },
            new int[][] {
                new int[] {-1, 1, 90},
            },
            new int[][] {
                new int[] {-1, 1, 87},
                new int[] {11, 0, 82},
                new int[] {12, 0, 83},
                new int[] {17, 0, 84},
                new int[] {21, 0, 129},
                new int[] {32, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 88},
                new int[] {11, 0, 82},
                new int[] {12, 0, 83},
                new int[] {17, 0, 84},
                new int[] {21, 0, 129},
                new int[] {32, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 82},
                new int[] {27, 0, 86},
            },
            new int[][] {
                new int[] {-1, 1, 50},
            },
            new int[][] {
                new int[] {-1, 3, 129},
                new int[] {30, 0, 122},
            },
            new int[][] {
                new int[] {-1, 1, 75},
                new int[] {27, 0, 86},
            },
            new int[][] {
                new int[] {-1, 1, 73},
                new int[] {11, 0, 82},
                new int[] {12, 0, 83},
                new int[] {17, 0, 84},
                new int[] {21, 0, 129},
                new int[] {27, 0, 86},
                new int[] {32, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 79},
                new int[] {27, 0, 86},
            },
            new int[][] {
                new int[] {-1, 1, 96},
                new int[] {23, 0, 173},
                new int[] {25, 0, 174},
                new int[] {26, 0, 175},
            },
            new int[][] {
                new int[] {-1, 1, 101},
            },
            new int[][] {
                new int[] {-1, 1, 99},
            },
            new int[][] {
                new int[] {-1, 1, 97},
            },
            new int[][] {
                new int[] {-1, 1, 76},
                new int[] {27, 0, 86},
            },
            new int[][] {
                new int[] {-1, 1, 139},
            },
            new int[][] {
                new int[] {-1, 1, 80},
                new int[] {27, 0, 86},
            },
            new int[][] {
                new int[] {-1, 1, 141},
            },
            new int[][] {
                new int[] {-1, 3, 141},
                new int[] {22, 0, 177},
                new int[] {23, 0, 178},
                new int[] {25, 0, 179},
                new int[] {26, 0, 180},
            },
            new int[][] {
                new int[] {-1, 3, 142},
                new int[] {15, 0, 181},
            },
            new int[][] {
                new int[] {-1, 3, 143},
                new int[] {37, 0, 182},
                new int[] {38, 0, 183},
                new int[] {39, 0, 184},
                new int[] {40, 0, 185},
            },
            new int[][] {
                new int[] {-1, 3, 144},
                new int[] {17, 0, 60},
                new int[] {19, 0, 61},
                new int[] {32, 0, 62},
                new int[] {33, 0, 63},
                new int[] {34, 0, 64},
                new int[] {35, 0, 65},
                new int[] {36, 0, 66},
            },
            new int[][] {
                new int[] {-1, 3, 145},
                new int[] {17, 0, 60},
                new int[] {19, 0, 61},
                new int[] {32, 0, 62},
                new int[] {33, 0, 63},
                new int[] {34, 0, 64},
                new int[] {35, 0, 65},
                new int[] {36, 0, 66},
            },
            new int[][] {
                new int[] {-1, 3, 146},
                new int[] {33, 0, 63},
                new int[] {34, 0, 64},
                new int[] {35, 0, 65},
            },
            new int[][] {
                new int[] {-1, 1, 42},
            },
            new int[][] {
                new int[] {-1, 1, 32},
            },
            new int[][] {
                new int[] {-1, 1, 131},
            },
            new int[][] {
                new int[] {-1, 3, 150},
                new int[] {32, 0, 191},
            },
            new int[][] {
                new int[] {-1, 1, 24},
            },
            new int[][] {
                new int[] {-1, 3, 152},
                new int[] {22, 0, 192},
                new int[] {28, 0, 75},
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
                new int[] {-1, 3, 156},
                new int[] {15, 0, 193},
            },
            new int[][] {
                new int[] {-1, 1, 105},
            },
            new int[][] {
                new int[] {-1, 1, 106},
            },
            new int[][] {
                new int[] {-1, 3, 159},
                new int[] {31, 0, 194},
            },
            new int[][] {
                new int[] {-1, 3, 160},
                new int[] {32, 0, 195},
            },
            new int[][] {
                new int[] {-1, 1, 62},
            },
            new int[][] {
                new int[] {-1, 3, 162},
                new int[] {9, 0, 160},
                new int[] {10, 0, 161},
                new int[] {17, 0, 162},
                new int[] {18, 0, 196},
                new int[] {32, 0, 163},
            },
            new int[][] {
                new int[] {-1, 1, 68},
                new int[] {13, 0, 199},
            },
            new int[][] {
                new int[] {-1, 3, 164},
                new int[] {22, 0, 200},
            },
            new int[][] {
                new int[] {-1, 1, 57},
            },
            new int[][] {
                new int[] {-1, 1, 94},
            },
            new int[][] {
                new int[] {-1, 1, 91},
            },
            new int[][] {
                new int[] {-1, 1, 89},
                new int[] {11, 0, 82},
                new int[] {12, 0, 83},
                new int[] {17, 0, 84},
                new int[] {21, 0, 129},
                new int[] {32, 0, 87},
            },
            new int[][] {
                new int[] {-1, 1, 92},
            },
            new int[][] {
                new int[] {-1, 1, 83},
                new int[] {27, 0, 86},
            },
            new int[][] {
                new int[] {-1, 1, 77},
                new int[] {27, 0, 86},
            },
            new int[][] {
                new int[] {-1, 1, 81},
                new int[] {27, 0, 86},
            },
            new int[][] {
                new int[] {-1, 1, 102},
            },
            new int[][] {
                new int[] {-1, 1, 100},
            },
            new int[][] {
                new int[] {-1, 1, 98},
            },
            new int[][] {
                new int[] {-1, 1, 84},
                new int[] {27, 0, 86},
            },
            new int[][] {
                new int[] {-1, 1, 52},
            },
            new int[][] {
                new int[] {-1, 3, 178},
                new int[] {22, 0, 203},
            },
            new int[][] {
                new int[] {-1, 3, 179},
                new int[] {22, 0, 204},
            },
            new int[][] {
                new int[] {-1, 3, 180},
                new int[] {22, 0, 205},
            },
            new int[][] {
                new int[] {-1, 1, 51},
            },
            new int[][] {
                new int[] {-1, 1, 113},
            },
            new int[][] {
                new int[] {-1, 1, 114},
            },
            new int[][] {
                new int[] {-1, 3, 184},
                new int[] {31, 0, 206},
            },
            new int[][] {
                new int[] {-1, 3, 185},
                new int[] {31, 0, 207},
            },
            new int[][] {
                new int[] {-1, 3, 186},
                new int[] {15, 0, 208},
            },
            new int[][] {
                new int[] {-1, 1, 110},
                new int[] {28, 0, 209},
            },
            new int[][] {
                new int[] {-1, 3, 188},
                new int[] {18, 0, 212},
            },
            new int[][] {
                new int[] {-1, 3, 189},
                new int[] {18, 0, 213},
            },
            new int[][] {
                new int[] {-1, 3, 190},
                new int[] {18, 0, 214},
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
                new int[] {-1, 1, 103},
            },
            new int[][] {
                new int[] {-1, 3, 195},
                new int[] {13, 0, 215},
                new int[] {19, 0, 216},
            },
            new int[][] {
                new int[] {-1, 1, 63},
            },
            new int[][] {
                new int[] {-1, 1, 65},
                new int[] {28, 0, 217},
            },
            new int[][] {
                new int[] {-1, 3, 198},
                new int[] {18, 0, 220},
            },
            new int[][] {
                new int[] {-1, 3, 199},
                new int[] {32, 0, 221},
            },
            new int[][] {
                new int[] {-1, 1, 56},
            },
            new int[][] {
                new int[] {-1, 1, 93},
            },
            new int[][] {
                new int[] {-1, 1, 85},
                new int[] {27, 0, 86},
            },
            new int[][] {
                new int[] {-1, 1, 54},
            },
            new int[][] {
                new int[] {-1, 1, 55},
            },
            new int[][] {
                new int[] {-1, 1, 53},
            },
            new int[][] {
                new int[] {-1, 3, 206},
                new int[] {41, 0, 222},
                new int[] {42, 0, 223},
                new int[] {43, 0, 224},
            },
            new int[][] {
                new int[] {-1, 3, 207},
                new int[] {41, 0, 222},
                new int[] {42, 0, 223},
                new int[] {43, 0, 224},
            },
            new int[][] {
                new int[] {-1, 1, 109},
            },
            new int[][] {
                new int[] {-1, 3, 209},
                new int[] {37, 0, 182},
                new int[] {38, 0, 183},
                new int[] {39, 0, 184},
                new int[] {40, 0, 185},
            },
            new int[][] {
                new int[] {-1, 1, 144},
            },
            new int[][] {
                new int[] {-1, 1, 111},
                new int[] {28, 0, 209},
            },
            new int[][] {
                new int[] {-1, 1, 46},
            },
            new int[][] {
                new int[] {-1, 1, 47},
            },
            new int[][] {
                new int[] {-1, 1, 48},
            },
            new int[][] {
                new int[] {-1, 3, 215},
                new int[] {32, 0, 229},
            },
            new int[][] {
                new int[] {-1, 3, 216},
                new int[] {9, 0, 160},
                new int[] {10, 0, 161},
                new int[] {17, 0, 162},
                new int[] {20, 0, 230},
                new int[] {32, 0, 163},
            },
            new int[][] {
                new int[] {-1, 3, 217},
                new int[] {9, 0, 160},
                new int[] {10, 0, 161},
                new int[] {17, 0, 162},
                new int[] {32, 0, 163},
            },
            new int[][] {
                new int[] {-1, 1, 136},
            },
            new int[][] {
                new int[] {-1, 1, 66},
                new int[] {28, 0, 217},
            },
            new int[][] {
                new int[] {-1, 1, 64},
            },
            new int[][] {
                new int[] {-1, 1, 69},
            },
            new int[][] {
                new int[] {-1, 3, 222},
                new int[] {19, 0, 234},
            },
            new int[][] {
                new int[] {-1, 3, 223},
                new int[] {19, 0, 235},
            },
            new int[][] {
                new int[] {-1, 1, 119},
            },
            new int[][] {
                new int[] {-1, 1, 115},
            },
            new int[][] {
                new int[] {-1, 1, 116},
            },
            new int[][] {
                new int[] {-1, 1, 112},
            },
            new int[][] {
                new int[] {-1, 1, 145},
            },
            new int[][] {
                new int[] {-1, 3, 229},
                new int[] {19, 0, 236},
            },
            new int[][] {
                new int[] {-1, 1, 58},
            },
            new int[][] {
                new int[] {-1, 3, 231},
                new int[] {20, 0, 237},
            },
            new int[][] {
                new int[] {-1, 1, 67},
            },
            new int[][] {
                new int[] {-1, 1, 137},
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
                new int[] {-1, 3, 236},
                new int[] {9, 0, 160},
                new int[] {10, 0, 161},
                new int[] {17, 0, 162},
                new int[] {20, 0, 240},
                new int[] {32, 0, 163},
            },
            new int[][] {
                new int[] {-1, 1, 59},
            },
            new int[][] {
                new int[] {-1, 3, 238},
                new int[] {28, 0, 242},
            },
            new int[][] {
                new int[] {-1, 3, 239},
                new int[] {28, 0, 243},
            },
            new int[][] {
                new int[] {-1, 1, 60},
            },
            new int[][] {
                new int[] {-1, 3, 241},
                new int[] {20, 0, 244},
            },
            new int[][] {
                new int[] {-1, 3, 242},
                new int[] {34, 0, 245},
            },
            new int[][] {
                new int[] {-1, 3, 243},
                new int[] {34, 0, 246},
            },
            new int[][] {
                new int[] {-1, 1, 61},
            },
            new int[][] {
                new int[] {-1, 3, 245},
                new int[] {28, 0, 247},
            },
            new int[][] {
                new int[] {-1, 3, 246},
                new int[] {28, 0, 248},
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
                new int[] {20, 0, 251},
            },
            new int[][] {
                new int[] {-1, 3, 250},
                new int[] {20, 0, 252},
            },
            new int[][] {
                new int[] {-1, 1, 117},
            },
            new int[][] {
                new int[] {-1, 1, 118},
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
                new int[] {56, 99},
            },
            new int[][] {
                new int[] {-1, 42},
                new int[] {43, 59},
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
                new int[] {-1, 77},
                new int[] {78, 114},
                new int[] {152, 114},
            },
            new int[][] {
                new int[] {-1, 15},
            },
            new int[][] {
                new int[] {-1, 117},
                new int[] {118, 156},
            },
            new int[][] {
                new int[] {-1, 67},
                new int[] {48, 79},
                new int[] {61, 102},
                new int[] {80, 118},
                new int[] {116, 153},
            },
            new int[][] {
                new int[] {-1, 105},
                new int[] {106, 149},
            },
            new int[][] {
                new int[] {-1, 68},
                new int[] {104, 148},
            },
            new int[][] {
                new int[] {-1, 69},
                new int[] {73, 110},
            },
            new int[][] {
                new int[] {-1, 70},
                new int[] {60, 100},
                new int[] {144, 188},
                new int[] {145, 189},
            },
            new int[][] {
                new int[] {-1, 71},
                new int[] {60, 101},
                new int[] {146, 190},
            },
            new int[][] {
                new int[] {-1, 72},
            },
            new int[][] {
                new int[] {-1, 16},
            },
            new int[][] {
                new int[] {-1, 33},
                new int[] {34, 55},
                new int[] {35, 55},
            },
            new int[][] {
                new int[] {-1, 54},
            },
            new int[][] {
                new int[] {-1, 88},
                new int[] {86, 124},
                new int[] {91, 130},
                new int[] {95, 137},
                new int[] {125, 167},
                new int[] {126, 169},
                new int[] {131, 171},
                new int[] {168, 201},
            },
            new int[][] {
                new int[] {-1, 197},
                new int[] {122, 164},
                new int[] {217, 232},
            },
            new int[][] {
                new int[] {-1, 198},
                new int[] {216, 231},
                new int[] {236, 241},
            },
            new int[][] {
                new int[] {-1, 218},
                new int[] {219, 233},
            },
            new int[][] {
                new int[] {-1, 165},
            },
            new int[][] {
                new int[] {-1, 89},
                new int[] {98, 142},
            },
            new int[][] {
                new int[] {-1, 90},
                new int[] {96, 140},
                new int[] {127, 140},
                new int[] {132, 140},
                new int[] {139, 140},
                new int[] {170, 140},
                new int[] {172, 140},
                new int[] {176, 140},
                new int[] {202, 140},
            },
            new int[][] {
                new int[] {-1, 91},
                new int[] {86, 125},
            },
            new int[][] {
                new int[] {-1, 92},
                new int[] {95, 138},
                new int[] {126, 138},
                new int[] {131, 138},
                new int[] {168, 138},
            },
            new int[][] {
                new int[] {-1, 93},
            },
            new int[][] {
                new int[] {-1, 94},
                new int[] {93, 133},
            },
            new int[][] {
                new int[] {-1, 17},
            },
            new int[][] {
                new int[] {-1, 18},
            },
            new int[][] {
                new int[] {-1, 37},
                new int[] {38, 57},
            },
            new int[][] {
                new int[] {-1, 186},
            },
            new int[][] {
                new int[] {-1, 210},
                new int[] {211, 228},
            },
            new int[][] {
                new int[] {-1, 187},
                new int[] {209, 227},
            },
            new int[][] {
                new int[] {-1, 225},
                new int[] {207, 226},
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
                new int[] {-1, 78},
                new int[] {112, 152},
            },
            new int[][] {
                new int[] {-1, 106},
            },
            new int[][] {
                new int[] {-1, 73},
            },
            new int[][] {
                new int[] {-1, 34},
                new int[] {7, 35},
            },
            new int[][] {
                new int[] {-1, 219},
            },
            new int[][] {
                new int[] {-1, 95},
                new int[] {86, 126},
                new int[] {91, 131},
                new int[] {125, 168},
            },
            new int[][] {
                new int[] {-1, 96},
                new int[] {88, 127},
                new int[] {91, 132},
                new int[] {95, 139},
                new int[] {130, 170},
                new int[] {131, 172},
                new int[] {137, 176},
                new int[] {171, 202},
            },
            new int[][] {
                new int[] {-1, 38},
            },
            new int[][] {
                new int[] {-1, 211},
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
            "expecting: '=', '{'",
            "expecting: '{'",
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
            0, 1, 2, 2, 3, 4, 2, 2, 2, 5, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 6, 7, 6, 8, 9, 9, 2, 8, 10, 2, 10, 2,
            11, 9, 9, 9, 12, 9, 9, 0, 0, 2, 7, 7, 0, 13, 9, 14,
            13, 8, 10, 6, 15, 16, 8, 9, 2, 9, 7, 7, 13, 13, 17, 18,
            18, 18, 17, 6, 19, 20, 21, 22, 17, 20, 2, 2, 2, 23, 23, 24,
            13, 0, 25, 25, 2, 26, 15, 27, 28, 6, 28, 15, 15, 29, 27, 15,
            28, 2, 15, 30, 31, 32, 33, 9, 13, 19, 19, 20, 20, 20, 20, 14,
            23, 2, 23, 10, 13, 6, 24, 2, 2, 34, 35, 30, 28, 15, 15, 28,
            9, 16, 28, 15, 28, 27, 15, 15, 15, 28, 15, 28, 28, 36, 6, 37,
            13, 13, 38, 17, 19, 19, 2, 2, 23, 6, 10, 10, 6, 27, 27, 39,
            2, 40, 41, 42, 30, 40, 15, 28, 15, 28, 28, 28, 28, 15, 15, 15,
            28, 8, 30, 30, 30, 9, 43, 43, 39, 39, 6, 43, 34, 34, 34, 23,
            2, 10, 29, 44, 40, 45, 34, 2, 28, 28, 28, 8, 8, 8, 46, 46,
            9, 37, 43, 43, 17, 17, 17, 2, 47, 35, 45, 45, 40, 40, 48, 48,
            43, 43, 43, 43, 43, 48, 40, 33, 45, 45, 49, 49, 47, 40, 50, 50,
            40, 33, 49, 49, 40, 50, 50, 49, 49, 33, 33, 43, 43,
        };
    }
}
