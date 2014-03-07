using System;
using System.Collections.Generic;
using SablePP.Tools.Analysis;
using SablePP.Tools.Nodes;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Analysis
{
    #region Analysis adapters
    
    public class AnalysisAdapter : AnalysisAdapter<object>
    {
    }
    public class AnalysisAdapter<TValue> : Adapter<TValue, PGrammar>
    {
        public override void Visit(Node node)
        {
            Visit((dynamic)node);
        }
        
        public void Visit(AGrammar node)
        {
            CaseAGrammar(node);
        }
        public virtual void CaseAGrammar(AGrammar node)
        {
            DefaultCase(node);
        }
        public void Visit(APackage node)
        {
            CaseAPackage(node);
        }
        public virtual void CaseAPackage(APackage node)
        {
            DefaultCase(node);
        }
        public void Visit(AHelpers node)
        {
            CaseAHelpers(node);
        }
        public virtual void CaseAHelpers(AHelpers node)
        {
            DefaultCase(node);
        }
        public void Visit(AHelper node)
        {
            CaseAHelper(node);
        }
        public virtual void CaseAHelper(AHelper node)
        {
            DefaultCase(node);
        }
        public void Visit(ATokens node)
        {
            CaseATokens(node);
        }
        public virtual void CaseATokens(ATokens node)
        {
            DefaultCase(node);
        }
        public void Visit(AToken node)
        {
            CaseAToken(node);
        }
        public virtual void CaseAToken(AToken node)
        {
            DefaultCase(node);
        }
        public void Visit(ATokenlookahead node)
        {
            CaseATokenlookahead(node);
        }
        public virtual void CaseATokenlookahead(ATokenlookahead node)
        {
            DefaultCase(node);
        }
        public void Visit(ARegex node)
        {
            CaseARegex(node);
        }
        public virtual void CaseARegex(ARegex node)
        {
            DefaultCase(node);
        }
        public void Visit(ARegexOrpart node)
        {
            CaseARegexOrpart(node);
        }
        public virtual void CaseARegexOrpart(ARegexOrpart node)
        {
            DefaultCase(node);
        }
        public void Visit(ACharRegexpart node)
        {
            CaseACharRegexpart(node);
        }
        public virtual void CaseACharRegexpart(ACharRegexpart node)
        {
            DefaultCase(node);
        }
        public void Visit(ADecRegexpart node)
        {
            CaseADecRegexpart(node);
        }
        public virtual void CaseADecRegexpart(ADecRegexpart node)
        {
            DefaultCase(node);
        }
        public void Visit(AHexRegexpart node)
        {
            CaseAHexRegexpart(node);
        }
        public virtual void CaseAHexRegexpart(AHexRegexpart node)
        {
            DefaultCase(node);
        }
        public void Visit(AUnarystarRegexpart node)
        {
            CaseAUnarystarRegexpart(node);
        }
        public virtual void CaseAUnarystarRegexpart(AUnarystarRegexpart node)
        {
            DefaultCase(node);
        }
        public void Visit(AUnaryquestionRegexpart node)
        {
            CaseAUnaryquestionRegexpart(node);
        }
        public virtual void CaseAUnaryquestionRegexpart(AUnaryquestionRegexpart node)
        {
            DefaultCase(node);
        }
        public void Visit(AUnaryplusRegexpart node)
        {
            CaseAUnaryplusRegexpart(node);
        }
        public virtual void CaseAUnaryplusRegexpart(AUnaryplusRegexpart node)
        {
            DefaultCase(node);
        }
        public void Visit(ABinaryplusRegexpart node)
        {
            CaseABinaryplusRegexpart(node);
        }
        public virtual void CaseABinaryplusRegexpart(ABinaryplusRegexpart node)
        {
            DefaultCase(node);
        }
        public void Visit(ABinaryminusRegexpart node)
        {
            CaseABinaryminusRegexpart(node);
        }
        public virtual void CaseABinaryminusRegexpart(ABinaryminusRegexpart node)
        {
            DefaultCase(node);
        }
        public void Visit(AIntervalRegexpart node)
        {
            CaseAIntervalRegexpart(node);
        }
        public virtual void CaseAIntervalRegexpart(AIntervalRegexpart node)
        {
            DefaultCase(node);
        }
        public void Visit(AStringRegexpart node)
        {
            CaseAStringRegexpart(node);
        }
        public virtual void CaseAStringRegexpart(AStringRegexpart node)
        {
            DefaultCase(node);
        }
        public void Visit(AIdentifierRegexpart node)
        {
            CaseAIdentifierRegexpart(node);
        }
        public virtual void CaseAIdentifierRegexpart(AIdentifierRegexpart node)
        {
            DefaultCase(node);
        }
        public void Visit(AParenthesisRegexpart node)
        {
            CaseAParenthesisRegexpart(node);
        }
        public virtual void CaseAParenthesisRegexpart(AParenthesisRegexpart node)
        {
            DefaultCase(node);
        }
        public void Visit(AStates node)
        {
            CaseAStates(node);
        }
        public virtual void CaseAStates(AStates node)
        {
            DefaultCase(node);
        }
        public void Visit(AIgnoredtokens node)
        {
            CaseAIgnoredtokens(node);
        }
        public virtual void CaseAIgnoredtokens(AIgnoredtokens node)
        {
            DefaultCase(node);
        }
        public void Visit(AIdentifierList node)
        {
            CaseAIdentifierList(node);
        }
        public virtual void CaseAIdentifierList(AIdentifierList node)
        {
            DefaultCase(node);
        }
        public void Visit(ATokenstateList node)
        {
            CaseATokenstateList(node);
        }
        public virtual void CaseATokenstateList(ATokenstateList node)
        {
            DefaultCase(node);
        }
        public void Visit(ATranslationList node)
        {
            CaseATranslationList(node);
        }
        public virtual void CaseATranslationList(ATranslationList node)
        {
            DefaultCase(node);
        }
        public void Visit(AStyleList node)
        {
            CaseAStyleList(node);
        }
        public virtual void CaseAStyleList(AStyleList node)
        {
            DefaultCase(node);
        }
        public void Visit(AIdentifierListitem node)
        {
            CaseAIdentifierListitem(node);
        }
        public virtual void CaseAIdentifierListitem(AIdentifierListitem node)
        {
            DefaultCase(node);
        }
        public void Visit(ATokenstateListitem node)
        {
            CaseATokenstateListitem(node);
        }
        public virtual void CaseATokenstateListitem(ATokenstateListitem node)
        {
            DefaultCase(node);
        }
        public void Visit(ATokenstatetransitionListitem node)
        {
            CaseATokenstatetransitionListitem(node);
        }
        public virtual void CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node)
        {
            DefaultCase(node);
        }
        public void Visit(ATranslationListitem node)
        {
            CaseATranslationListitem(node);
        }
        public virtual void CaseATranslationListitem(ATranslationListitem node)
        {
            DefaultCase(node);
        }
        public void Visit(AStyleListitem node)
        {
            CaseAStyleListitem(node);
        }
        public virtual void CaseAStyleListitem(AStyleListitem node)
        {
            DefaultCase(node);
        }
        public void Visit(AProductions node)
        {
            CaseAProductions(node);
        }
        public virtual void CaseAProductions(AProductions node)
        {
            DefaultCase(node);
        }
        public void Visit(AAstproductions node)
        {
            CaseAAstproductions(node);
        }
        public virtual void CaseAAstproductions(AAstproductions node)
        {
            DefaultCase(node);
        }
        public void Visit(AProduction node)
        {
            CaseAProduction(node);
        }
        public virtual void CaseAProduction(AProduction node)
        {
            DefaultCase(node);
        }
        public void Visit(ACleanProdtranslation node)
        {
            CaseACleanProdtranslation(node);
        }
        public virtual void CaseACleanProdtranslation(ACleanProdtranslation node)
        {
            DefaultCase(node);
        }
        public void Visit(AStarProdtranslation node)
        {
            CaseAStarProdtranslation(node);
        }
        public virtual void CaseAStarProdtranslation(AStarProdtranslation node)
        {
            DefaultCase(node);
        }
        public void Visit(APlusProdtranslation node)
        {
            CaseAPlusProdtranslation(node);
        }
        public virtual void CaseAPlusProdtranslation(APlusProdtranslation node)
        {
            DefaultCase(node);
        }
        public void Visit(AQuestionProdtranslation node)
        {
            CaseAQuestionProdtranslation(node);
        }
        public virtual void CaseAQuestionProdtranslation(AQuestionProdtranslation node)
        {
            DefaultCase(node);
        }
        public void Visit(AFullTranslation node)
        {
            CaseAFullTranslation(node);
        }
        public virtual void CaseAFullTranslation(AFullTranslation node)
        {
            DefaultCase(node);
        }
        public void Visit(ANewTranslation node)
        {
            CaseANewTranslation(node);
        }
        public virtual void CaseANewTranslation(ANewTranslation node)
        {
            DefaultCase(node);
        }
        public void Visit(ANewalternativeTranslation node)
        {
            CaseANewalternativeTranslation(node);
        }
        public virtual void CaseANewalternativeTranslation(ANewalternativeTranslation node)
        {
            DefaultCase(node);
        }
        public void Visit(AListTranslation node)
        {
            CaseAListTranslation(node);
        }
        public virtual void CaseAListTranslation(AListTranslation node)
        {
            DefaultCase(node);
        }
        public void Visit(ANullTranslation node)
        {
            CaseANullTranslation(node);
        }
        public virtual void CaseANullTranslation(ANullTranslation node)
        {
            DefaultCase(node);
        }
        public void Visit(AIdTranslation node)
        {
            CaseAIdTranslation(node);
        }
        public virtual void CaseAIdTranslation(AIdTranslation node)
        {
            DefaultCase(node);
        }
        public void Visit(AIddotidTranslation node)
        {
            CaseAIddotidTranslation(node);
        }
        public virtual void CaseAIddotidTranslation(AIddotidTranslation node)
        {
            DefaultCase(node);
        }
        public void Visit(AProductionrule node)
        {
            CaseAProductionrule(node);
        }
        public virtual void CaseAProductionrule(AProductionrule node)
        {
            DefaultCase(node);
        }
        public void Visit(AAlternative node)
        {
            CaseAAlternative(node);
        }
        public virtual void CaseAAlternative(AAlternative node)
        {
            DefaultCase(node);
        }
        public void Visit(AAlternativename node)
        {
            CaseAAlternativename(node);
        }
        public virtual void CaseAAlternativename(AAlternativename node)
        {
            DefaultCase(node);
        }
        public void Visit(AElements node)
        {
            CaseAElements(node);
        }
        public virtual void CaseAElements(AElements node)
        {
            DefaultCase(node);
        }
        public void Visit(ASimpleElement node)
        {
            CaseASimpleElement(node);
        }
        public virtual void CaseASimpleElement(ASimpleElement node)
        {
            DefaultCase(node);
        }
        public void Visit(AStarElement node)
        {
            CaseAStarElement(node);
        }
        public virtual void CaseAStarElement(AStarElement node)
        {
            DefaultCase(node);
        }
        public void Visit(AQuestionElement node)
        {
            CaseAQuestionElement(node);
        }
        public virtual void CaseAQuestionElement(AQuestionElement node)
        {
            DefaultCase(node);
        }
        public void Visit(APlusElement node)
        {
            CaseAPlusElement(node);
        }
        public virtual void CaseAPlusElement(APlusElement node)
        {
            DefaultCase(node);
        }
        public void Visit(AElementname node)
        {
            CaseAElementname(node);
        }
        public virtual void CaseAElementname(AElementname node)
        {
            DefaultCase(node);
        }
        public void Visit(ACleanElementid node)
        {
            CaseACleanElementid(node);
        }
        public virtual void CaseACleanElementid(ACleanElementid node)
        {
            DefaultCase(node);
        }
        public void Visit(ATokenElementid node)
        {
            CaseATokenElementid(node);
        }
        public virtual void CaseATokenElementid(ATokenElementid node)
        {
            DefaultCase(node);
        }
        public void Visit(AProductionElementid node)
        {
            CaseAProductionElementid(node);
        }
        public virtual void CaseAProductionElementid(AProductionElementid node)
        {
            DefaultCase(node);
        }
        public void Visit(AHighlightrules node)
        {
            CaseAHighlightrules(node);
        }
        public virtual void CaseAHighlightrules(AHighlightrules node)
        {
            DefaultCase(node);
        }
        public void Visit(AHighlightrule node)
        {
            CaseAHighlightrule(node);
        }
        public virtual void CaseAHighlightrule(AHighlightrule node)
        {
            DefaultCase(node);
        }
        public void Visit(AItalicHighlightStyle node)
        {
            CaseAItalicHighlightStyle(node);
        }
        public virtual void CaseAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            DefaultCase(node);
        }
        public void Visit(ABoldHighlightStyle node)
        {
            CaseABoldHighlightStyle(node);
        }
        public virtual void CaseABoldHighlightStyle(ABoldHighlightStyle node)
        {
            DefaultCase(node);
        }
        public void Visit(ATextHighlightStyle node)
        {
            CaseATextHighlightStyle(node);
        }
        public virtual void CaseATextHighlightStyle(ATextHighlightStyle node)
        {
            DefaultCase(node);
        }
        public void Visit(ABackgroundHighlightStyle node)
        {
            CaseABackgroundHighlightStyle(node);
        }
        public virtual void CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            DefaultCase(node);
        }
        public void Visit(ARgbColor node)
        {
            CaseARgbColor(node);
        }
        public virtual void CaseARgbColor(ARgbColor node)
        {
            DefaultCase(node);
        }
        public void Visit(AHsvColor node)
        {
            CaseAHsvColor(node);
        }
        public virtual void CaseAHsvColor(AHsvColor node)
        {
            DefaultCase(node);
        }
        public void Visit(AHexColor node)
        {
            CaseAHexColor(node);
        }
        public virtual void CaseAHexColor(AHexColor node)
        {
            DefaultCase(node);
        }
        public void Visit(TPackagename node)
        {
            CaseTPackagename(node);
        }
        public virtual void CaseTPackagename(TPackagename node)
        {
            DefaultCase(node);
        }
        public void Visit(TPackagetoken node)
        {
            CaseTPackagetoken(node);
        }
        public virtual void CaseTPackagetoken(TPackagetoken node)
        {
            DefaultCase(node);
        }
        public void Visit(TStatestoken node)
        {
            CaseTStatestoken(node);
        }
        public virtual void CaseTStatestoken(TStatestoken node)
        {
            DefaultCase(node);
        }
        public void Visit(THelperstoken node)
        {
            CaseTHelperstoken(node);
        }
        public virtual void CaseTHelperstoken(THelperstoken node)
        {
            DefaultCase(node);
        }
        public void Visit(TTokenstoken node)
        {
            CaseTTokenstoken(node);
        }
        public virtual void CaseTTokenstoken(TTokenstoken node)
        {
            DefaultCase(node);
        }
        public void Visit(TIgnoredtoken node)
        {
            CaseTIgnoredtoken(node);
        }
        public virtual void CaseTIgnoredtoken(TIgnoredtoken node)
        {
            DefaultCase(node);
        }
        public void Visit(TProductionstoken node)
        {
            CaseTProductionstoken(node);
        }
        public virtual void CaseTProductionstoken(TProductionstoken node)
        {
            DefaultCase(node);
        }
        public void Visit(TAsttoken node)
        {
            CaseTAsttoken(node);
        }
        public virtual void CaseTAsttoken(TAsttoken node)
        {
            DefaultCase(node);
        }
        public void Visit(THighlighttoken node)
        {
            CaseTHighlighttoken(node);
        }
        public virtual void CaseTHighlighttoken(THighlighttoken node)
        {
            DefaultCase(node);
        }
        public void Visit(TNew node)
        {
            CaseTNew(node);
        }
        public virtual void CaseTNew(TNew node)
        {
            DefaultCase(node);
        }
        public void Visit(TNull node)
        {
            CaseTNull(node);
        }
        public virtual void CaseTNull(TNull node)
        {
            DefaultCase(node);
        }
        public void Visit(TTokenSpecifier node)
        {
            CaseTTokenSpecifier(node);
        }
        public virtual void CaseTTokenSpecifier(TTokenSpecifier node)
        {
            DefaultCase(node);
        }
        public void Visit(TProductionSpecifier node)
        {
            CaseTProductionSpecifier(node);
        }
        public virtual void CaseTProductionSpecifier(TProductionSpecifier node)
        {
            DefaultCase(node);
        }
        public void Visit(TDot node)
        {
            CaseTDot(node);
        }
        public virtual void CaseTDot(TDot node)
        {
            DefaultCase(node);
        }
        public void Visit(TDDot node)
        {
            CaseTDDot(node);
        }
        public virtual void CaseTDDot(TDDot node)
        {
            DefaultCase(node);
        }
        public void Visit(TSemicolon node)
        {
            CaseTSemicolon(node);
        }
        public virtual void CaseTSemicolon(TSemicolon node)
        {
            DefaultCase(node);
        }
        public void Visit(TEqual node)
        {
            CaseTEqual(node);
        }
        public virtual void CaseTEqual(TEqual node)
        {
            DefaultCase(node);
        }
        public void Visit(TLBkt node)
        {
            CaseTLBkt(node);
        }
        public virtual void CaseTLBkt(TLBkt node)
        {
            DefaultCase(node);
        }
        public void Visit(TRBkt node)
        {
            CaseTRBkt(node);
        }
        public virtual void CaseTRBkt(TRBkt node)
        {
            DefaultCase(node);
        }
        public void Visit(TLPar node)
        {
            CaseTLPar(node);
        }
        public virtual void CaseTLPar(TLPar node)
        {
            DefaultCase(node);
        }
        public void Visit(TRPar node)
        {
            CaseTRPar(node);
        }
        public virtual void CaseTRPar(TRPar node)
        {
            DefaultCase(node);
        }
        public void Visit(TLBrace node)
        {
            CaseTLBrace(node);
        }
        public virtual void CaseTLBrace(TLBrace node)
        {
            DefaultCase(node);
        }
        public void Visit(TRBrace node)
        {
            CaseTRBrace(node);
        }
        public virtual void CaseTRBrace(TRBrace node)
        {
            DefaultCase(node);
        }
        public void Visit(TPlus node)
        {
            CaseTPlus(node);
        }
        public virtual void CaseTPlus(TPlus node)
        {
            DefaultCase(node);
        }
        public void Visit(TMinus node)
        {
            CaseTMinus(node);
        }
        public virtual void CaseTMinus(TMinus node)
        {
            DefaultCase(node);
        }
        public void Visit(TQMark node)
        {
            CaseTQMark(node);
        }
        public virtual void CaseTQMark(TQMark node)
        {
            DefaultCase(node);
        }
        public void Visit(TStar node)
        {
            CaseTStar(node);
        }
        public virtual void CaseTStar(TStar node)
        {
            DefaultCase(node);
        }
        public void Visit(TPipe node)
        {
            CaseTPipe(node);
        }
        public virtual void CaseTPipe(TPipe node)
        {
            DefaultCase(node);
        }
        public void Visit(TComma node)
        {
            CaseTComma(node);
        }
        public virtual void CaseTComma(TComma node)
        {
            DefaultCase(node);
        }
        public void Visit(TSlash node)
        {
            CaseTSlash(node);
        }
        public virtual void CaseTSlash(TSlash node)
        {
            DefaultCase(node);
        }
        public void Visit(TArrow node)
        {
            CaseTArrow(node);
        }
        public virtual void CaseTArrow(TArrow node)
        {
            DefaultCase(node);
        }
        public void Visit(TColon node)
        {
            CaseTColon(node);
        }
        public virtual void CaseTColon(TColon node)
        {
            DefaultCase(node);
        }
        public void Visit(TIdentifier node)
        {
            CaseTIdentifier(node);
        }
        public virtual void CaseTIdentifier(TIdentifier node)
        {
            DefaultCase(node);
        }
        public void Visit(TCharacter node)
        {
            CaseTCharacter(node);
        }
        public virtual void CaseTCharacter(TCharacter node)
        {
            DefaultCase(node);
        }
        public void Visit(TDecChar node)
        {
            CaseTDecChar(node);
        }
        public virtual void CaseTDecChar(TDecChar node)
        {
            DefaultCase(node);
        }
        public void Visit(THexChar node)
        {
            CaseTHexChar(node);
        }
        public virtual void CaseTHexChar(THexChar node)
        {
            DefaultCase(node);
        }
        public void Visit(TString node)
        {
            CaseTString(node);
        }
        public virtual void CaseTString(TString node)
        {
            DefaultCase(node);
        }
        public void Visit(TBlank node)
        {
            CaseTBlank(node);
        }
        public virtual void CaseTBlank(TBlank node)
        {
            DefaultCase(node);
        }
        public void Visit(TComment node)
        {
            CaseTComment(node);
        }
        public virtual void CaseTComment(TComment node)
        {
            DefaultCase(node);
        }
        public void Visit(TItalic node)
        {
            CaseTItalic(node);
        }
        public virtual void CaseTItalic(TItalic node)
        {
            DefaultCase(node);
        }
        public void Visit(TBold node)
        {
            CaseTBold(node);
        }
        public virtual void CaseTBold(TBold node)
        {
            DefaultCase(node);
        }
        public void Visit(TText node)
        {
            CaseTText(node);
        }
        public virtual void CaseTText(TText node)
        {
            DefaultCase(node);
        }
        public void Visit(TBackground node)
        {
            CaseTBackground(node);
        }
        public virtual void CaseTBackground(TBackground node)
        {
            DefaultCase(node);
        }
        public void Visit(TRgb node)
        {
            CaseTRgb(node);
        }
        public virtual void CaseTRgb(TRgb node)
        {
            DefaultCase(node);
        }
        public void Visit(THsv node)
        {
            CaseTHsv(node);
        }
        public virtual void CaseTHsv(THsv node)
        {
            DefaultCase(node);
        }
        public void Visit(THexColor node)
        {
            CaseTHexColor(node);
        }
        public virtual void CaseTHexColor(THexColor node)
        {
            DefaultCase(node);
        }
    }
    
    public class DepthFirstAdapter : DepthFirstAdapter<object>
    {
    }
    public class DepthFirstAdapter<TValue> : AnalysisAdapter<TValue>
    {
        public virtual void InStart(Start<PGrammar> node)
        {
        }
        public virtual void OutStart(Start<PGrammar> node)
        {
        }
        public override void CaseStart(Start<PGrammar> node)
        {
            InStart(node);
            
            Visit((dynamic)node.Root);
            Visit(node.EOF);
            
            OutStart(node);
        }
        
        public virtual void DefaultPIn(Node node)
        {
        }
        public virtual void DefaultPOut(Node node)
        {
        }
        public virtual void DefaultAIn(Node node)
        {
        }
        public virtual void DefaultAOut(Node node)
        {
        }
        
        public virtual void InPGrammar(PGrammar node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPGrammar(PGrammar node)
        {
            DefaultPOut(node);
        }
        public virtual void InAGrammar(AGrammar node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAGrammar(AGrammar node)
        {
            DefaultAOut(node);
        }
        public override void CaseAGrammar(AGrammar node)
        {
            InPGrammar(node);
            InAGrammar(node);
            
            if (node.HasPackage)
                Visit((dynamic)node.Package);
            if (node.HasHelpers)
                Visit((dynamic)node.Helpers);
            if (node.HasStates)
                Visit((dynamic)node.States);
            if (node.HasTokens)
                Visit((dynamic)node.Tokens);
            if (node.HasIgnoredtokens)
                Visit((dynamic)node.Ignoredtokens);
            if (node.HasProductions)
                Visit((dynamic)node.Productions);
            if (node.HasAstproductions)
                Visit((dynamic)node.Astproductions);
            if (node.HasHighlightrules)
                Visit((dynamic)node.Highlightrules);
            
            OutAGrammar(node);
            OutPGrammar(node);
        }
        
        public virtual void InPPackage(PPackage node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPPackage(PPackage node)
        {
            DefaultPOut(node);
        }
        public virtual void InAPackage(APackage node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAPackage(APackage node)
        {
            DefaultAOut(node);
        }
        public override void CaseAPackage(APackage node)
        {
            InPPackage(node);
            InAPackage(node);
            
            Visit(node.Packagetoken);
            Visit(node.Packagename);
            Visit(node.Semicolon);
            
            OutAPackage(node);
            OutPPackage(node);
        }
        
        public virtual void InPHelpers(PHelpers node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPHelpers(PHelpers node)
        {
            DefaultPOut(node);
        }
        public virtual void InAHelpers(AHelpers node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHelpers(AHelpers node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHelpers(AHelpers node)
        {
            InPHelpers(node);
            InAHelpers(node);
            
            Visit(node.Helperstoken);
            {
                PHelper[] temp = new PHelper[node.Helpers.Count];
                node.Helpers.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    Visit((dynamic)temp[i]);
            }
            
            OutAHelpers(node);
            OutPHelpers(node);
        }
        
        public virtual void InPHelper(PHelper node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPHelper(PHelper node)
        {
            DefaultPOut(node);
        }
        public virtual void InAHelper(AHelper node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHelper(AHelper node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHelper(AHelper node)
        {
            InPHelper(node);
            InAHelper(node);
            
            Visit(node.Identifier);
            Visit(node.Equal);
            Visit((dynamic)node.Regex);
            Visit(node.Semicolon);
            
            OutAHelper(node);
            OutPHelper(node);
        }
        
        public virtual void InPTokens(PTokens node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPTokens(PTokens node)
        {
            DefaultPOut(node);
        }
        public virtual void InATokens(ATokens node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokens(ATokens node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokens(ATokens node)
        {
            InPTokens(node);
            InATokens(node);
            
            Visit(node.Tokenstoken);
            {
                PToken[] temp = new PToken[node.Tokens.Count];
                node.Tokens.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    Visit((dynamic)temp[i]);
            }
            
            OutATokens(node);
            OutPTokens(node);
        }
        
        public virtual void InPToken(PToken node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPToken(PToken node)
        {
            DefaultPOut(node);
        }
        public virtual void InAToken(AToken node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAToken(AToken node)
        {
            DefaultAOut(node);
        }
        public override void CaseAToken(AToken node)
        {
            InPToken(node);
            InAToken(node);
            
            if (node.HasStatelist)
                Visit((dynamic)node.Statelist);
            Visit(node.Identifier);
            Visit(node.Equal);
            Visit((dynamic)node.Regex);
            if (node.HasTokenlookahead)
                Visit((dynamic)node.Tokenlookahead);
            Visit(node.Semicolon);
            
            OutAToken(node);
            OutPToken(node);
        }
        
        public virtual void InPTokenlookahead(PTokenlookahead node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPTokenlookahead(PTokenlookahead node)
        {
            DefaultPOut(node);
        }
        public virtual void InATokenlookahead(ATokenlookahead node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokenlookahead(ATokenlookahead node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokenlookahead(ATokenlookahead node)
        {
            InPTokenlookahead(node);
            InATokenlookahead(node);
            
            Visit(node.Slash);
            Visit((dynamic)node.Regex);
            
            OutATokenlookahead(node);
            OutPTokenlookahead(node);
        }
        
        public virtual void InPRegex(PRegex node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPRegex(PRegex node)
        {
            DefaultPOut(node);
        }
        public virtual void InARegex(ARegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutARegex(ARegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseARegex(ARegex node)
        {
            InPRegex(node);
            InARegex(node);
            
            {
                POrpart[] temp = new POrpart[node.Parts.Count];
                node.Parts.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    Visit((dynamic)temp[i]);
            }
            
            OutARegex(node);
            OutPRegex(node);
        }
        
        public virtual void InPOrpart(POrpart node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPOrpart(POrpart node)
        {
            DefaultPOut(node);
        }
        public virtual void InARegexOrpart(ARegexOrpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutARegexOrpart(ARegexOrpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseARegexOrpart(ARegexOrpart node)
        {
            InPOrpart(node);
            InARegexOrpart(node);
            
            if (node.HasPipe)
                Visit(node.Pipe);
            {
                PRegexpart[] temp = new PRegexpart[node.Regexpart.Count];
                node.Regexpart.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    Visit((dynamic)temp[i]);
            }
            
            OutARegexOrpart(node);
            OutPOrpart(node);
        }
        
        public virtual void InPRegexpart(PRegexpart node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPRegexpart(PRegexpart node)
        {
            DefaultPOut(node);
        }
        public virtual void InACharRegexpart(ACharRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutACharRegexpart(ACharRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseACharRegexpart(ACharRegexpart node)
        {
            InPRegexpart(node);
            InACharRegexpart(node);
            
            Visit(node.Character);
            
            OutACharRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InADecRegexpart(ADecRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutADecRegexpart(ADecRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseADecRegexpart(ADecRegexpart node)
        {
            InPRegexpart(node);
            InADecRegexpart(node);
            
            Visit(node.DecChar);
            
            OutADecRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAHexRegexpart(AHexRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHexRegexpart(AHexRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHexRegexpart(AHexRegexpart node)
        {
            InPRegexpart(node);
            InAHexRegexpart(node);
            
            Visit(node.HexChar);
            
            OutAHexRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAUnarystarRegexpart(AUnarystarRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAUnarystarRegexpart(AUnarystarRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAUnarystarRegexpart(AUnarystarRegexpart node)
        {
            InPRegexpart(node);
            InAUnarystarRegexpart(node);
            
            Visit((dynamic)node.Regexpart);
            Visit(node.Star);
            
            OutAUnarystarRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAUnaryquestionRegexpart(AUnaryquestionRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAUnaryquestionRegexpart(AUnaryquestionRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAUnaryquestionRegexpart(AUnaryquestionRegexpart node)
        {
            InPRegexpart(node);
            InAUnaryquestionRegexpart(node);
            
            Visit((dynamic)node.Regexpart);
            Visit(node.Question);
            
            OutAUnaryquestionRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAUnaryplusRegexpart(AUnaryplusRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAUnaryplusRegexpart(AUnaryplusRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAUnaryplusRegexpart(AUnaryplusRegexpart node)
        {
            InPRegexpart(node);
            InAUnaryplusRegexpart(node);
            
            Visit((dynamic)node.Regexpart);
            Visit(node.Plus);
            
            OutAUnaryplusRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InABinaryplusRegexpart(ABinaryplusRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutABinaryplusRegexpart(ABinaryplusRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseABinaryplusRegexpart(ABinaryplusRegexpart node)
        {
            InPRegexpart(node);
            InABinaryplusRegexpart(node);
            
            Visit(node.Lpar);
            Visit((dynamic)node.Left);
            Visit(node.Plus);
            Visit((dynamic)node.Right);
            Visit(node.Rpar);
            
            OutABinaryplusRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InABinaryminusRegexpart(ABinaryminusRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutABinaryminusRegexpart(ABinaryminusRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseABinaryminusRegexpart(ABinaryminusRegexpart node)
        {
            InPRegexpart(node);
            InABinaryminusRegexpart(node);
            
            Visit(node.Lpar);
            Visit((dynamic)node.Left);
            Visit(node.Minus);
            Visit((dynamic)node.Right);
            Visit(node.Rpar);
            
            OutABinaryminusRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAIntervalRegexpart(AIntervalRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIntervalRegexpart(AIntervalRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIntervalRegexpart(AIntervalRegexpart node)
        {
            InPRegexpart(node);
            InAIntervalRegexpart(node);
            
            Visit(node.Lpar);
            Visit((dynamic)node.Left);
            Visit(node.Dots);
            Visit((dynamic)node.Right);
            Visit(node.Rpar);
            
            OutAIntervalRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAStringRegexpart(AStringRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStringRegexpart(AStringRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStringRegexpart(AStringRegexpart node)
        {
            InPRegexpart(node);
            InAStringRegexpart(node);
            
            Visit(node.String);
            
            OutAStringRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAIdentifierRegexpart(AIdentifierRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIdentifierRegexpart(AIdentifierRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIdentifierRegexpart(AIdentifierRegexpart node)
        {
            InPRegexpart(node);
            InAIdentifierRegexpart(node);
            
            Visit(node.Identifier);
            
            OutAIdentifierRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAParenthesisRegexpart(AParenthesisRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAParenthesisRegexpart(AParenthesisRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAParenthesisRegexpart(AParenthesisRegexpart node)
        {
            InPRegexpart(node);
            InAParenthesisRegexpart(node);
            
            Visit(node.Lpar);
            Visit((dynamic)node.Regex);
            Visit(node.Rpar);
            
            OutAParenthesisRegexpart(node);
            OutPRegexpart(node);
        }
        
        public virtual void InPStates(PStates node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPStates(PStates node)
        {
            DefaultPOut(node);
        }
        public virtual void InAStates(AStates node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStates(AStates node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStates(AStates node)
        {
            InPStates(node);
            InAStates(node);
            
            Visit(node.Statestoken);
            Visit((dynamic)node.List);
            Visit(node.Semicolon);
            
            OutAStates(node);
            OutPStates(node);
        }
        
        public virtual void InPIgnoredtokens(PIgnoredtokens node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPIgnoredtokens(PIgnoredtokens node)
        {
            DefaultPOut(node);
        }
        public virtual void InAIgnoredtokens(AIgnoredtokens node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIgnoredtokens(AIgnoredtokens node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIgnoredtokens(AIgnoredtokens node)
        {
            InPIgnoredtokens(node);
            InAIgnoredtokens(node);
            
            Visit(node.Ignoredtoken);
            Visit(node.Tokenstoken);
            Visit((dynamic)node.List);
            Visit(node.Semicolon);
            
            OutAIgnoredtokens(node);
            OutPIgnoredtokens(node);
        }
        
        public virtual void InPList(PList node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPList(PList node)
        {
            DefaultPOut(node);
        }
        public virtual void InAIdentifierList(AIdentifierList node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIdentifierList(AIdentifierList node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIdentifierList(AIdentifierList node)
        {
            InPList(node);
            InAIdentifierList(node);
            
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    Visit((dynamic)temp[i]);
            }
            
            OutAIdentifierList(node);
            OutPList(node);
        }
        public virtual void InATokenstateList(ATokenstateList node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokenstateList(ATokenstateList node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokenstateList(ATokenstateList node)
        {
            InPList(node);
            InATokenstateList(node);
            
            Visit(node.Lpar);
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    Visit((dynamic)temp[i]);
            }
            Visit(node.Rpar);
            
            OutATokenstateList(node);
            OutPList(node);
        }
        public virtual void InATranslationList(ATranslationList node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATranslationList(ATranslationList node)
        {
            DefaultAOut(node);
        }
        public override void CaseATranslationList(ATranslationList node)
        {
            InPList(node);
            InATranslationList(node);
            
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    Visit((dynamic)temp[i]);
            }
            
            OutATranslationList(node);
            OutPList(node);
        }
        public virtual void InAStyleList(AStyleList node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStyleList(AStyleList node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStyleList(AStyleList node)
        {
            InPList(node);
            InAStyleList(node);
            
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    Visit((dynamic)temp[i]);
            }
            
            OutAStyleList(node);
            OutPList(node);
        }
        
        public virtual void InPListitem(PListitem node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPListitem(PListitem node)
        {
            DefaultPOut(node);
        }
        public virtual void InAIdentifierListitem(AIdentifierListitem node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIdentifierListitem(AIdentifierListitem node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIdentifierListitem(AIdentifierListitem node)
        {
            InPListitem(node);
            InAIdentifierListitem(node);
            
            if (node.HasComma)
                Visit(node.Comma);
            Visit(node.Identifier);
            
            OutAIdentifierListitem(node);
            OutPListitem(node);
        }
        public virtual void InATokenstateListitem(ATokenstateListitem node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokenstateListitem(ATokenstateListitem node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokenstateListitem(ATokenstateListitem node)
        {
            InPListitem(node);
            InATokenstateListitem(node);
            
            if (node.HasComma)
                Visit(node.Comma);
            Visit(node.Identifier);
            
            OutATokenstateListitem(node);
            OutPListitem(node);
        }
        public virtual void InATokenstatetransitionListitem(ATokenstatetransitionListitem node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokenstatetransitionListitem(ATokenstatetransitionListitem node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node)
        {
            InPListitem(node);
            InATokenstatetransitionListitem(node);
            
            if (node.HasComma)
                Visit(node.Comma);
            Visit(node.From);
            Visit(node.Arrow);
            Visit(node.To);
            
            OutATokenstatetransitionListitem(node);
            OutPListitem(node);
        }
        public virtual void InATranslationListitem(ATranslationListitem node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATranslationListitem(ATranslationListitem node)
        {
            DefaultAOut(node);
        }
        public override void CaseATranslationListitem(ATranslationListitem node)
        {
            InPListitem(node);
            InATranslationListitem(node);
            
            if (node.HasComma)
                Visit(node.Comma);
            Visit((dynamic)node.Translation);
            
            OutATranslationListitem(node);
            OutPListitem(node);
        }
        public virtual void InAStyleListitem(AStyleListitem node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStyleListitem(AStyleListitem node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStyleListitem(AStyleListitem node)
        {
            InPListitem(node);
            InAStyleListitem(node);
            
            if (node.HasComma)
                Visit(node.Comma);
            Visit((dynamic)node.HighlightStyle);
            
            OutAStyleListitem(node);
            OutPListitem(node);
        }
        
        public virtual void InPProductions(PProductions node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPProductions(PProductions node)
        {
            DefaultPOut(node);
        }
        public virtual void InAProductions(AProductions node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAProductions(AProductions node)
        {
            DefaultAOut(node);
        }
        public override void CaseAProductions(AProductions node)
        {
            InPProductions(node);
            InAProductions(node);
            
            Visit(node.Productionstoken);
            {
                PProduction[] temp = new PProduction[node.Productions.Count];
                node.Productions.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    Visit((dynamic)temp[i]);
            }
            
            OutAProductions(node);
            OutPProductions(node);
        }
        
        public virtual void InPAstproductions(PAstproductions node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPAstproductions(PAstproductions node)
        {
            DefaultPOut(node);
        }
        public virtual void InAAstproductions(AAstproductions node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAAstproductions(AAstproductions node)
        {
            DefaultAOut(node);
        }
        public override void CaseAAstproductions(AAstproductions node)
        {
            InPAstproductions(node);
            InAAstproductions(node);
            
            Visit(node.Asttoken);
            {
                PProduction[] temp = new PProduction[node.Productions.Count];
                node.Productions.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    Visit((dynamic)temp[i]);
            }
            
            OutAAstproductions(node);
            OutPAstproductions(node);
        }
        
        public virtual void InPProduction(PProduction node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPProduction(PProduction node)
        {
            DefaultPOut(node);
        }
        public virtual void InAProduction(AProduction node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAProduction(AProduction node)
        {
            DefaultAOut(node);
        }
        public override void CaseAProduction(AProduction node)
        {
            InPProduction(node);
            InAProduction(node);
            
            Visit(node.Identifier);
            if (node.HasProdtranslation)
                Visit((dynamic)node.Prodtranslation);
            Visit(node.Equal);
            Visit((dynamic)node.Productionrule);
            Visit(node.Semicolon);
            
            OutAProduction(node);
            OutPProduction(node);
        }
        
        public virtual void InPProdtranslation(PProdtranslation node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPProdtranslation(PProdtranslation node)
        {
            DefaultPOut(node);
        }
        public virtual void InACleanProdtranslation(ACleanProdtranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutACleanProdtranslation(ACleanProdtranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseACleanProdtranslation(ACleanProdtranslation node)
        {
            InPProdtranslation(node);
            InACleanProdtranslation(node);
            
            Visit(node.Lpar);
            Visit(node.Arrow);
            Visit(node.Identifier);
            Visit(node.Rpar);
            
            OutACleanProdtranslation(node);
            OutPProdtranslation(node);
        }
        public virtual void InAStarProdtranslation(AStarProdtranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStarProdtranslation(AStarProdtranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStarProdtranslation(AStarProdtranslation node)
        {
            InPProdtranslation(node);
            InAStarProdtranslation(node);
            
            Visit(node.Lpar);
            Visit(node.Arrow);
            Visit(node.Identifier);
            Visit(node.Star);
            Visit(node.Rpar);
            
            OutAStarProdtranslation(node);
            OutPProdtranslation(node);
        }
        public virtual void InAPlusProdtranslation(APlusProdtranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAPlusProdtranslation(APlusProdtranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAPlusProdtranslation(APlusProdtranslation node)
        {
            InPProdtranslation(node);
            InAPlusProdtranslation(node);
            
            Visit(node.Lpar);
            Visit(node.Arrow);
            Visit(node.Identifier);
            Visit(node.Plus);
            Visit(node.Rpar);
            
            OutAPlusProdtranslation(node);
            OutPProdtranslation(node);
        }
        public virtual void InAQuestionProdtranslation(AQuestionProdtranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAQuestionProdtranslation(AQuestionProdtranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAQuestionProdtranslation(AQuestionProdtranslation node)
        {
            InPProdtranslation(node);
            InAQuestionProdtranslation(node);
            
            Visit(node.Lpar);
            Visit(node.Arrow);
            Visit(node.Identifier);
            Visit(node.QMark);
            Visit(node.Rpar);
            
            OutAQuestionProdtranslation(node);
            OutPProdtranslation(node);
        }
        
        public virtual void InPTranslation(PTranslation node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPTranslation(PTranslation node)
        {
            DefaultPOut(node);
        }
        public virtual void InAFullTranslation(AFullTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAFullTranslation(AFullTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAFullTranslation(AFullTranslation node)
        {
            InPTranslation(node);
            InAFullTranslation(node);
            
            Visit(node.Lpar);
            Visit(node.Arrow);
            Visit((dynamic)node.Translation);
            Visit(node.Rpar);
            
            OutAFullTranslation(node);
            OutPTranslation(node);
        }
        public virtual void InANewTranslation(ANewTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutANewTranslation(ANewTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseANewTranslation(ANewTranslation node)
        {
            InPTranslation(node);
            InANewTranslation(node);
            
            Visit(node.New);
            Visit(node.Production);
            Visit(node.Lpar);
            Visit((dynamic)node.Arguments);
            Visit(node.Rpar);
            
            OutANewTranslation(node);
            OutPTranslation(node);
        }
        public virtual void InANewalternativeTranslation(ANewalternativeTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutANewalternativeTranslation(ANewalternativeTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseANewalternativeTranslation(ANewalternativeTranslation node)
        {
            InPTranslation(node);
            InANewalternativeTranslation(node);
            
            Visit(node.New);
            Visit(node.Production);
            Visit(node.Dot);
            Visit(node.Alternative);
            Visit(node.Lpar);
            Visit((dynamic)node.Arguments);
            Visit(node.Rpar);
            
            OutANewalternativeTranslation(node);
            OutPTranslation(node);
        }
        public virtual void InAListTranslation(AListTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAListTranslation(AListTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAListTranslation(AListTranslation node)
        {
            InPTranslation(node);
            InAListTranslation(node);
            
            Visit(node.Lpar);
            Visit((dynamic)node.Elements);
            Visit(node.Rpar);
            
            OutAListTranslation(node);
            OutPTranslation(node);
        }
        public virtual void InANullTranslation(ANullTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutANullTranslation(ANullTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseANullTranslation(ANullTranslation node)
        {
            InPTranslation(node);
            InANullTranslation(node);
            
            Visit(node.Null);
            
            OutANullTranslation(node);
            OutPTranslation(node);
        }
        public virtual void InAIdTranslation(AIdTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIdTranslation(AIdTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIdTranslation(AIdTranslation node)
        {
            InPTranslation(node);
            InAIdTranslation(node);
            
            Visit(node.Identifier);
            
            OutAIdTranslation(node);
            OutPTranslation(node);
        }
        public virtual void InAIddotidTranslation(AIddotidTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIddotidTranslation(AIddotidTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIddotidTranslation(AIddotidTranslation node)
        {
            InPTranslation(node);
            InAIddotidTranslation(node);
            
            Visit(node.Identifier);
            Visit(node.Dot);
            Visit(node.Production);
            
            OutAIddotidTranslation(node);
            OutPTranslation(node);
        }
        
        public virtual void InPProductionrule(PProductionrule node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPProductionrule(PProductionrule node)
        {
            DefaultPOut(node);
        }
        public virtual void InAProductionrule(AProductionrule node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAProductionrule(AProductionrule node)
        {
            DefaultAOut(node);
        }
        public override void CaseAProductionrule(AProductionrule node)
        {
            InPProductionrule(node);
            InAProductionrule(node);
            
            {
                PAlternative[] temp = new PAlternative[node.Alternatives.Count];
                node.Alternatives.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    Visit((dynamic)temp[i]);
            }
            
            OutAProductionrule(node);
            OutPProductionrule(node);
        }
        
        public virtual void InPAlternative(PAlternative node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPAlternative(PAlternative node)
        {
            DefaultPOut(node);
        }
        public virtual void InAAlternative(AAlternative node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAAlternative(AAlternative node)
        {
            DefaultAOut(node);
        }
        public override void CaseAAlternative(AAlternative node)
        {
            InPAlternative(node);
            InAAlternative(node);
            
            if (node.HasPipe)
                Visit(node.Pipe);
            if (node.HasAlternativename)
                Visit((dynamic)node.Alternativename);
            Visit((dynamic)node.Elements);
            if (node.HasTranslation)
                Visit((dynamic)node.Translation);
            
            OutAAlternative(node);
            OutPAlternative(node);
        }
        
        public virtual void InPAlternativename(PAlternativename node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPAlternativename(PAlternativename node)
        {
            DefaultPOut(node);
        }
        public virtual void InAAlternativename(AAlternativename node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAAlternativename(AAlternativename node)
        {
            DefaultAOut(node);
        }
        public override void CaseAAlternativename(AAlternativename node)
        {
            InPAlternativename(node);
            InAAlternativename(node);
            
            Visit(node.Lpar);
            Visit(node.Name);
            Visit(node.Rpar);
            
            OutAAlternativename(node);
            OutPAlternativename(node);
        }
        
        public virtual void InPElements(PElements node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPElements(PElements node)
        {
            DefaultPOut(node);
        }
        public virtual void InAElements(AElements node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAElements(AElements node)
        {
            DefaultAOut(node);
        }
        public override void CaseAElements(AElements node)
        {
            InPElements(node);
            InAElements(node);
            
            {
                PElement[] temp = new PElement[node.Element.Count];
                node.Element.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    Visit((dynamic)temp[i]);
            }
            
            OutAElements(node);
            OutPElements(node);
        }
        
        public virtual void InPElement(PElement node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPElement(PElement node)
        {
            DefaultPOut(node);
        }
        public virtual void InASimpleElement(ASimpleElement node)
        {
            DefaultAIn(node);
        }
        public virtual void OutASimpleElement(ASimpleElement node)
        {
            DefaultAOut(node);
        }
        public override void CaseASimpleElement(ASimpleElement node)
        {
            InPElement(node);
            InASimpleElement(node);
            
            if (node.HasElementname)
                Visit((dynamic)node.Elementname);
            Visit((dynamic)node.Elementid);
            
            OutASimpleElement(node);
            OutPElement(node);
        }
        public virtual void InAStarElement(AStarElement node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStarElement(AStarElement node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStarElement(AStarElement node)
        {
            InPElement(node);
            InAStarElement(node);
            
            if (node.HasElementname)
                Visit((dynamic)node.Elementname);
            Visit((dynamic)node.Elementid);
            Visit(node.Star);
            
            OutAStarElement(node);
            OutPElement(node);
        }
        public virtual void InAQuestionElement(AQuestionElement node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAQuestionElement(AQuestionElement node)
        {
            DefaultAOut(node);
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            InPElement(node);
            InAQuestionElement(node);
            
            if (node.HasElementname)
                Visit((dynamic)node.Elementname);
            Visit((dynamic)node.Elementid);
            Visit(node.QMark);
            
            OutAQuestionElement(node);
            OutPElement(node);
        }
        public virtual void InAPlusElement(APlusElement node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAPlusElement(APlusElement node)
        {
            DefaultAOut(node);
        }
        public override void CaseAPlusElement(APlusElement node)
        {
            InPElement(node);
            InAPlusElement(node);
            
            if (node.HasElementname)
                Visit((dynamic)node.Elementname);
            Visit((dynamic)node.Elementid);
            Visit(node.Plus);
            
            OutAPlusElement(node);
            OutPElement(node);
        }
        
        public virtual void InPElementname(PElementname node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPElementname(PElementname node)
        {
            DefaultPOut(node);
        }
        public virtual void InAElementname(AElementname node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAElementname(AElementname node)
        {
            DefaultAOut(node);
        }
        public override void CaseAElementname(AElementname node)
        {
            InPElementname(node);
            InAElementname(node);
            
            Visit(node.Lpar);
            Visit(node.Name);
            Visit(node.Rpar);
            Visit(node.Colon);
            
            OutAElementname(node);
            OutPElementname(node);
        }
        
        public virtual void InPElementid(PElementid node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPElementid(PElementid node)
        {
            DefaultPOut(node);
        }
        public virtual void InACleanElementid(ACleanElementid node)
        {
            DefaultAIn(node);
        }
        public virtual void OutACleanElementid(ACleanElementid node)
        {
            DefaultAOut(node);
        }
        public override void CaseACleanElementid(ACleanElementid node)
        {
            InPElementid(node);
            InACleanElementid(node);
            
            Visit(node.Identifier);
            
            OutACleanElementid(node);
            OutPElementid(node);
        }
        public virtual void InATokenElementid(ATokenElementid node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokenElementid(ATokenElementid node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokenElementid(ATokenElementid node)
        {
            InPElementid(node);
            InATokenElementid(node);
            
            Visit(node.TokenSpecifier);
            Visit(node.Dot);
            Visit(node.Identifier);
            
            OutATokenElementid(node);
            OutPElementid(node);
        }
        public virtual void InAProductionElementid(AProductionElementid node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAProductionElementid(AProductionElementid node)
        {
            DefaultAOut(node);
        }
        public override void CaseAProductionElementid(AProductionElementid node)
        {
            InPElementid(node);
            InAProductionElementid(node);
            
            Visit(node.ProductionSpecifier);
            Visit(node.Dot);
            Visit(node.Identifier);
            
            OutAProductionElementid(node);
            OutPElementid(node);
        }
        
        public virtual void InPHighlightrules(PHighlightrules node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPHighlightrules(PHighlightrules node)
        {
            DefaultPOut(node);
        }
        public virtual void InAHighlightrules(AHighlightrules node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHighlightrules(AHighlightrules node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHighlightrules(AHighlightrules node)
        {
            InPHighlightrules(node);
            InAHighlightrules(node);
            
            Visit(node.Highlighttoken);
            {
                PHighlightrule[] temp = new PHighlightrule[node.Highlightrule.Count];
                node.Highlightrule.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    Visit((dynamic)temp[i]);
            }
            
            OutAHighlightrules(node);
            OutPHighlightrules(node);
        }
        
        public virtual void InPHighlightrule(PHighlightrule node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPHighlightrule(PHighlightrule node)
        {
            DefaultPOut(node);
        }
        public virtual void InAHighlightrule(AHighlightrule node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHighlightrule(AHighlightrule node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHighlightrule(AHighlightrule node)
        {
            InPHighlightrule(node);
            InAHighlightrule(node);
            
            Visit(node.Name);
            Visit(node.Lpar);
            Visit((dynamic)node.Tokens);
            Visit(node.Rpar);
            Visit((dynamic)node.List);
            Visit(node.Semicolon);
            
            OutAHighlightrule(node);
            OutPHighlightrule(node);
        }
        
        public virtual void InPHighlightStyle(PHighlightStyle node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPHighlightStyle(PHighlightStyle node)
        {
            DefaultPOut(node);
        }
        public virtual void InAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            DefaultAOut(node);
        }
        public override void CaseAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            InPHighlightStyle(node);
            InAItalicHighlightStyle(node);
            
            Visit(node.Italic);
            
            OutAItalicHighlightStyle(node);
            OutPHighlightStyle(node);
        }
        public virtual void InABoldHighlightStyle(ABoldHighlightStyle node)
        {
            DefaultAIn(node);
        }
        public virtual void OutABoldHighlightStyle(ABoldHighlightStyle node)
        {
            DefaultAOut(node);
        }
        public override void CaseABoldHighlightStyle(ABoldHighlightStyle node)
        {
            InPHighlightStyle(node);
            InABoldHighlightStyle(node);
            
            Visit(node.Bold);
            
            OutABoldHighlightStyle(node);
            OutPHighlightStyle(node);
        }
        public virtual void InATextHighlightStyle(ATextHighlightStyle node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATextHighlightStyle(ATextHighlightStyle node)
        {
            DefaultAOut(node);
        }
        public override void CaseATextHighlightStyle(ATextHighlightStyle node)
        {
            InPHighlightStyle(node);
            InATextHighlightStyle(node);
            
            Visit(node.Text);
            Visit(node.Colon);
            Visit((dynamic)node.Color);
            
            OutATextHighlightStyle(node);
            OutPHighlightStyle(node);
        }
        public virtual void InABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            DefaultAIn(node);
        }
        public virtual void OutABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            DefaultAOut(node);
        }
        public override void CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            InPHighlightStyle(node);
            InABackgroundHighlightStyle(node);
            
            Visit(node.Background);
            Visit(node.Colon);
            Visit((dynamic)node.Color);
            
            OutABackgroundHighlightStyle(node);
            OutPHighlightStyle(node);
        }
        
        public virtual void InPColor(PColor node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPColor(PColor node)
        {
            DefaultPOut(node);
        }
        public virtual void InARgbColor(ARgbColor node)
        {
            DefaultAIn(node);
        }
        public virtual void OutARgbColor(ARgbColor node)
        {
            DefaultAOut(node);
        }
        public override void CaseARgbColor(ARgbColor node)
        {
            InPColor(node);
            InARgbColor(node);
            
            Visit(node.Rgb);
            Visit(node.LPar);
            Visit(node.Red);
            Visit(node.Comma1);
            Visit(node.Green);
            Visit(node.Comma2);
            Visit(node.Blue);
            Visit(node.RPar);
            
            OutARgbColor(node);
            OutPColor(node);
        }
        public virtual void InAHsvColor(AHsvColor node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHsvColor(AHsvColor node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHsvColor(AHsvColor node)
        {
            InPColor(node);
            InAHsvColor(node);
            
            Visit(node.Hsv);
            Visit(node.LPar);
            Visit(node.Hue);
            Visit(node.Comma1);
            Visit(node.Saturation);
            Visit(node.Comma2);
            Visit(node.Brightness);
            Visit(node.RPar);
            
            OutAHsvColor(node);
            OutPColor(node);
        }
        public virtual void InAHexColor(AHexColor node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHexColor(AHexColor node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHexColor(AHexColor node)
        {
            InPColor(node);
            InAHexColor(node);
            
            Visit(node.Color);
            
            OutAHexColor(node);
            OutPColor(node);
        }
    }
    
    public class ReverseDepthFirstAdapter : ReverseDepthFirstAdapter<object>
    {
    }
    public class ReverseDepthFirstAdapter<TValue> : AnalysisAdapter<TValue>
    {
        public virtual void InStart(Start<PGrammar> node)
        {
        }
        public virtual void OutStart(Start<PGrammar> node)
        {
        }
        public override void CaseStart(Start<PGrammar> node)
        {
            InStart(node);
            
            Visit(node.EOF);
            Visit((dynamic)node.Root);
            
            OutStart(node);
        }
        
        public virtual void DefaultPIn(Node node)
        {
        }
        public virtual void DefaultPOut(Node node)
        {
        }
        public virtual void DefaultAIn(Node node)
        {
        }
        public virtual void DefaultAOut(Node node)
        {
        }
        
        public virtual void InPGrammar(PGrammar node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPGrammar(PGrammar node)
        {
            DefaultPOut(node);
        }
        public virtual void InAGrammar(AGrammar node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAGrammar(AGrammar node)
        {
            DefaultAOut(node);
        }
        public override void CaseAGrammar(AGrammar node)
        {
            InPGrammar(node);
            InAGrammar(node);
            
            if (node.HasHighlightrules)
                Visit((dynamic)node.Highlightrules);
            if (node.HasAstproductions)
                Visit((dynamic)node.Astproductions);
            if (node.HasProductions)
                Visit((dynamic)node.Productions);
            if (node.HasIgnoredtokens)
                Visit((dynamic)node.Ignoredtokens);
            if (node.HasTokens)
                Visit((dynamic)node.Tokens);
            if (node.HasStates)
                Visit((dynamic)node.States);
            if (node.HasHelpers)
                Visit((dynamic)node.Helpers);
            if (node.HasPackage)
                Visit((dynamic)node.Package);
            
            OutAGrammar(node);
            OutPGrammar(node);
        }
        
        public virtual void InPPackage(PPackage node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPPackage(PPackage node)
        {
            DefaultPOut(node);
        }
        public virtual void InAPackage(APackage node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAPackage(APackage node)
        {
            DefaultAOut(node);
        }
        public override void CaseAPackage(APackage node)
        {
            InPPackage(node);
            InAPackage(node);
            
            Visit(node.Semicolon);
            Visit(node.Packagename);
            Visit(node.Packagetoken);
            
            OutAPackage(node);
            OutPPackage(node);
        }
        
        public virtual void InPHelpers(PHelpers node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPHelpers(PHelpers node)
        {
            DefaultPOut(node);
        }
        public virtual void InAHelpers(AHelpers node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHelpers(AHelpers node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHelpers(AHelpers node)
        {
            InPHelpers(node);
            InAHelpers(node);
            
            {
                PHelper[] temp = new PHelper[node.Helpers.Count];
                node.Helpers.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    Visit((dynamic)temp[i]);
            }
            Visit(node.Helperstoken);
            
            OutAHelpers(node);
            OutPHelpers(node);
        }
        
        public virtual void InPHelper(PHelper node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPHelper(PHelper node)
        {
            DefaultPOut(node);
        }
        public virtual void InAHelper(AHelper node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHelper(AHelper node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHelper(AHelper node)
        {
            InPHelper(node);
            InAHelper(node);
            
            Visit(node.Semicolon);
            Visit((dynamic)node.Regex);
            Visit(node.Equal);
            Visit(node.Identifier);
            
            OutAHelper(node);
            OutPHelper(node);
        }
        
        public virtual void InPTokens(PTokens node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPTokens(PTokens node)
        {
            DefaultPOut(node);
        }
        public virtual void InATokens(ATokens node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokens(ATokens node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokens(ATokens node)
        {
            InPTokens(node);
            InATokens(node);
            
            {
                PToken[] temp = new PToken[node.Tokens.Count];
                node.Tokens.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    Visit((dynamic)temp[i]);
            }
            Visit(node.Tokenstoken);
            
            OutATokens(node);
            OutPTokens(node);
        }
        
        public virtual void InPToken(PToken node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPToken(PToken node)
        {
            DefaultPOut(node);
        }
        public virtual void InAToken(AToken node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAToken(AToken node)
        {
            DefaultAOut(node);
        }
        public override void CaseAToken(AToken node)
        {
            InPToken(node);
            InAToken(node);
            
            Visit(node.Semicolon);
            if (node.HasTokenlookahead)
                Visit((dynamic)node.Tokenlookahead);
            Visit((dynamic)node.Regex);
            Visit(node.Equal);
            Visit(node.Identifier);
            if (node.HasStatelist)
                Visit((dynamic)node.Statelist);
            
            OutAToken(node);
            OutPToken(node);
        }
        
        public virtual void InPTokenlookahead(PTokenlookahead node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPTokenlookahead(PTokenlookahead node)
        {
            DefaultPOut(node);
        }
        public virtual void InATokenlookahead(ATokenlookahead node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokenlookahead(ATokenlookahead node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokenlookahead(ATokenlookahead node)
        {
            InPTokenlookahead(node);
            InATokenlookahead(node);
            
            Visit((dynamic)node.Regex);
            Visit(node.Slash);
            
            OutATokenlookahead(node);
            OutPTokenlookahead(node);
        }
        
        public virtual void InPRegex(PRegex node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPRegex(PRegex node)
        {
            DefaultPOut(node);
        }
        public virtual void InARegex(ARegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutARegex(ARegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseARegex(ARegex node)
        {
            InPRegex(node);
            InARegex(node);
            
            {
                POrpart[] temp = new POrpart[node.Parts.Count];
                node.Parts.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    Visit((dynamic)temp[i]);
            }
            
            OutARegex(node);
            OutPRegex(node);
        }
        
        public virtual void InPOrpart(POrpart node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPOrpart(POrpart node)
        {
            DefaultPOut(node);
        }
        public virtual void InARegexOrpart(ARegexOrpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutARegexOrpart(ARegexOrpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseARegexOrpart(ARegexOrpart node)
        {
            InPOrpart(node);
            InARegexOrpart(node);
            
            {
                PRegexpart[] temp = new PRegexpart[node.Regexpart.Count];
                node.Regexpart.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    Visit((dynamic)temp[i]);
            }
            if (node.HasPipe)
                Visit(node.Pipe);
            
            OutARegexOrpart(node);
            OutPOrpart(node);
        }
        
        public virtual void InPRegexpart(PRegexpart node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPRegexpart(PRegexpart node)
        {
            DefaultPOut(node);
        }
        public virtual void InACharRegexpart(ACharRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutACharRegexpart(ACharRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseACharRegexpart(ACharRegexpart node)
        {
            InPRegexpart(node);
            InACharRegexpart(node);
            
            Visit(node.Character);
            
            OutACharRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InADecRegexpart(ADecRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutADecRegexpart(ADecRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseADecRegexpart(ADecRegexpart node)
        {
            InPRegexpart(node);
            InADecRegexpart(node);
            
            Visit(node.DecChar);
            
            OutADecRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAHexRegexpart(AHexRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHexRegexpart(AHexRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHexRegexpart(AHexRegexpart node)
        {
            InPRegexpart(node);
            InAHexRegexpart(node);
            
            Visit(node.HexChar);
            
            OutAHexRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAUnarystarRegexpart(AUnarystarRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAUnarystarRegexpart(AUnarystarRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAUnarystarRegexpart(AUnarystarRegexpart node)
        {
            InPRegexpart(node);
            InAUnarystarRegexpart(node);
            
            Visit(node.Star);
            Visit((dynamic)node.Regexpart);
            
            OutAUnarystarRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAUnaryquestionRegexpart(AUnaryquestionRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAUnaryquestionRegexpart(AUnaryquestionRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAUnaryquestionRegexpart(AUnaryquestionRegexpart node)
        {
            InPRegexpart(node);
            InAUnaryquestionRegexpart(node);
            
            Visit(node.Question);
            Visit((dynamic)node.Regexpart);
            
            OutAUnaryquestionRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAUnaryplusRegexpart(AUnaryplusRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAUnaryplusRegexpart(AUnaryplusRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAUnaryplusRegexpart(AUnaryplusRegexpart node)
        {
            InPRegexpart(node);
            InAUnaryplusRegexpart(node);
            
            Visit(node.Plus);
            Visit((dynamic)node.Regexpart);
            
            OutAUnaryplusRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InABinaryplusRegexpart(ABinaryplusRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutABinaryplusRegexpart(ABinaryplusRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseABinaryplusRegexpart(ABinaryplusRegexpart node)
        {
            InPRegexpart(node);
            InABinaryplusRegexpart(node);
            
            Visit(node.Rpar);
            Visit((dynamic)node.Right);
            Visit(node.Plus);
            Visit((dynamic)node.Left);
            Visit(node.Lpar);
            
            OutABinaryplusRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InABinaryminusRegexpart(ABinaryminusRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutABinaryminusRegexpart(ABinaryminusRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseABinaryminusRegexpart(ABinaryminusRegexpart node)
        {
            InPRegexpart(node);
            InABinaryminusRegexpart(node);
            
            Visit(node.Rpar);
            Visit((dynamic)node.Right);
            Visit(node.Minus);
            Visit((dynamic)node.Left);
            Visit(node.Lpar);
            
            OutABinaryminusRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAIntervalRegexpart(AIntervalRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIntervalRegexpart(AIntervalRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIntervalRegexpart(AIntervalRegexpart node)
        {
            InPRegexpart(node);
            InAIntervalRegexpart(node);
            
            Visit(node.Rpar);
            Visit((dynamic)node.Right);
            Visit(node.Dots);
            Visit((dynamic)node.Left);
            Visit(node.Lpar);
            
            OutAIntervalRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAStringRegexpart(AStringRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStringRegexpart(AStringRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStringRegexpart(AStringRegexpart node)
        {
            InPRegexpart(node);
            InAStringRegexpart(node);
            
            Visit(node.String);
            
            OutAStringRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAIdentifierRegexpart(AIdentifierRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIdentifierRegexpart(AIdentifierRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIdentifierRegexpart(AIdentifierRegexpart node)
        {
            InPRegexpart(node);
            InAIdentifierRegexpart(node);
            
            Visit(node.Identifier);
            
            OutAIdentifierRegexpart(node);
            OutPRegexpart(node);
        }
        public virtual void InAParenthesisRegexpart(AParenthesisRegexpart node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAParenthesisRegexpart(AParenthesisRegexpart node)
        {
            DefaultAOut(node);
        }
        public override void CaseAParenthesisRegexpart(AParenthesisRegexpart node)
        {
            InPRegexpart(node);
            InAParenthesisRegexpart(node);
            
            Visit(node.Rpar);
            Visit((dynamic)node.Regex);
            Visit(node.Lpar);
            
            OutAParenthesisRegexpart(node);
            OutPRegexpart(node);
        }
        
        public virtual void InPStates(PStates node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPStates(PStates node)
        {
            DefaultPOut(node);
        }
        public virtual void InAStates(AStates node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStates(AStates node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStates(AStates node)
        {
            InPStates(node);
            InAStates(node);
            
            Visit(node.Semicolon);
            Visit((dynamic)node.List);
            Visit(node.Statestoken);
            
            OutAStates(node);
            OutPStates(node);
        }
        
        public virtual void InPIgnoredtokens(PIgnoredtokens node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPIgnoredtokens(PIgnoredtokens node)
        {
            DefaultPOut(node);
        }
        public virtual void InAIgnoredtokens(AIgnoredtokens node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIgnoredtokens(AIgnoredtokens node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIgnoredtokens(AIgnoredtokens node)
        {
            InPIgnoredtokens(node);
            InAIgnoredtokens(node);
            
            Visit(node.Semicolon);
            Visit((dynamic)node.List);
            Visit(node.Tokenstoken);
            Visit(node.Ignoredtoken);
            
            OutAIgnoredtokens(node);
            OutPIgnoredtokens(node);
        }
        
        public virtual void InPList(PList node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPList(PList node)
        {
            DefaultPOut(node);
        }
        public virtual void InAIdentifierList(AIdentifierList node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIdentifierList(AIdentifierList node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIdentifierList(AIdentifierList node)
        {
            InPList(node);
            InAIdentifierList(node);
            
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    Visit((dynamic)temp[i]);
            }
            
            OutAIdentifierList(node);
            OutPList(node);
        }
        public virtual void InATokenstateList(ATokenstateList node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokenstateList(ATokenstateList node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokenstateList(ATokenstateList node)
        {
            InPList(node);
            InATokenstateList(node);
            
            Visit(node.Rpar);
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    Visit((dynamic)temp[i]);
            }
            Visit(node.Lpar);
            
            OutATokenstateList(node);
            OutPList(node);
        }
        public virtual void InATranslationList(ATranslationList node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATranslationList(ATranslationList node)
        {
            DefaultAOut(node);
        }
        public override void CaseATranslationList(ATranslationList node)
        {
            InPList(node);
            InATranslationList(node);
            
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    Visit((dynamic)temp[i]);
            }
            
            OutATranslationList(node);
            OutPList(node);
        }
        public virtual void InAStyleList(AStyleList node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStyleList(AStyleList node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStyleList(AStyleList node)
        {
            InPList(node);
            InAStyleList(node);
            
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    Visit((dynamic)temp[i]);
            }
            
            OutAStyleList(node);
            OutPList(node);
        }
        
        public virtual void InPListitem(PListitem node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPListitem(PListitem node)
        {
            DefaultPOut(node);
        }
        public virtual void InAIdentifierListitem(AIdentifierListitem node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIdentifierListitem(AIdentifierListitem node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIdentifierListitem(AIdentifierListitem node)
        {
            InPListitem(node);
            InAIdentifierListitem(node);
            
            Visit(node.Identifier);
            if (node.HasComma)
                Visit(node.Comma);
            
            OutAIdentifierListitem(node);
            OutPListitem(node);
        }
        public virtual void InATokenstateListitem(ATokenstateListitem node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokenstateListitem(ATokenstateListitem node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokenstateListitem(ATokenstateListitem node)
        {
            InPListitem(node);
            InATokenstateListitem(node);
            
            Visit(node.Identifier);
            if (node.HasComma)
                Visit(node.Comma);
            
            OutATokenstateListitem(node);
            OutPListitem(node);
        }
        public virtual void InATokenstatetransitionListitem(ATokenstatetransitionListitem node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokenstatetransitionListitem(ATokenstatetransitionListitem node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node)
        {
            InPListitem(node);
            InATokenstatetransitionListitem(node);
            
            Visit(node.To);
            Visit(node.Arrow);
            Visit(node.From);
            if (node.HasComma)
                Visit(node.Comma);
            
            OutATokenstatetransitionListitem(node);
            OutPListitem(node);
        }
        public virtual void InATranslationListitem(ATranslationListitem node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATranslationListitem(ATranslationListitem node)
        {
            DefaultAOut(node);
        }
        public override void CaseATranslationListitem(ATranslationListitem node)
        {
            InPListitem(node);
            InATranslationListitem(node);
            
            Visit((dynamic)node.Translation);
            if (node.HasComma)
                Visit(node.Comma);
            
            OutATranslationListitem(node);
            OutPListitem(node);
        }
        public virtual void InAStyleListitem(AStyleListitem node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStyleListitem(AStyleListitem node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStyleListitem(AStyleListitem node)
        {
            InPListitem(node);
            InAStyleListitem(node);
            
            Visit((dynamic)node.HighlightStyle);
            if (node.HasComma)
                Visit(node.Comma);
            
            OutAStyleListitem(node);
            OutPListitem(node);
        }
        
        public virtual void InPProductions(PProductions node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPProductions(PProductions node)
        {
            DefaultPOut(node);
        }
        public virtual void InAProductions(AProductions node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAProductions(AProductions node)
        {
            DefaultAOut(node);
        }
        public override void CaseAProductions(AProductions node)
        {
            InPProductions(node);
            InAProductions(node);
            
            {
                PProduction[] temp = new PProduction[node.Productions.Count];
                node.Productions.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    Visit((dynamic)temp[i]);
            }
            Visit(node.Productionstoken);
            
            OutAProductions(node);
            OutPProductions(node);
        }
        
        public virtual void InPAstproductions(PAstproductions node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPAstproductions(PAstproductions node)
        {
            DefaultPOut(node);
        }
        public virtual void InAAstproductions(AAstproductions node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAAstproductions(AAstproductions node)
        {
            DefaultAOut(node);
        }
        public override void CaseAAstproductions(AAstproductions node)
        {
            InPAstproductions(node);
            InAAstproductions(node);
            
            {
                PProduction[] temp = new PProduction[node.Productions.Count];
                node.Productions.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    Visit((dynamic)temp[i]);
            }
            Visit(node.Asttoken);
            
            OutAAstproductions(node);
            OutPAstproductions(node);
        }
        
        public virtual void InPProduction(PProduction node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPProduction(PProduction node)
        {
            DefaultPOut(node);
        }
        public virtual void InAProduction(AProduction node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAProduction(AProduction node)
        {
            DefaultAOut(node);
        }
        public override void CaseAProduction(AProduction node)
        {
            InPProduction(node);
            InAProduction(node);
            
            Visit(node.Semicolon);
            Visit((dynamic)node.Productionrule);
            Visit(node.Equal);
            if (node.HasProdtranslation)
                Visit((dynamic)node.Prodtranslation);
            Visit(node.Identifier);
            
            OutAProduction(node);
            OutPProduction(node);
        }
        
        public virtual void InPProdtranslation(PProdtranslation node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPProdtranslation(PProdtranslation node)
        {
            DefaultPOut(node);
        }
        public virtual void InACleanProdtranslation(ACleanProdtranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutACleanProdtranslation(ACleanProdtranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseACleanProdtranslation(ACleanProdtranslation node)
        {
            InPProdtranslation(node);
            InACleanProdtranslation(node);
            
            Visit(node.Rpar);
            Visit(node.Identifier);
            Visit(node.Arrow);
            Visit(node.Lpar);
            
            OutACleanProdtranslation(node);
            OutPProdtranslation(node);
        }
        public virtual void InAStarProdtranslation(AStarProdtranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStarProdtranslation(AStarProdtranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStarProdtranslation(AStarProdtranslation node)
        {
            InPProdtranslation(node);
            InAStarProdtranslation(node);
            
            Visit(node.Rpar);
            Visit(node.Star);
            Visit(node.Identifier);
            Visit(node.Arrow);
            Visit(node.Lpar);
            
            OutAStarProdtranslation(node);
            OutPProdtranslation(node);
        }
        public virtual void InAPlusProdtranslation(APlusProdtranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAPlusProdtranslation(APlusProdtranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAPlusProdtranslation(APlusProdtranslation node)
        {
            InPProdtranslation(node);
            InAPlusProdtranslation(node);
            
            Visit(node.Rpar);
            Visit(node.Plus);
            Visit(node.Identifier);
            Visit(node.Arrow);
            Visit(node.Lpar);
            
            OutAPlusProdtranslation(node);
            OutPProdtranslation(node);
        }
        public virtual void InAQuestionProdtranslation(AQuestionProdtranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAQuestionProdtranslation(AQuestionProdtranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAQuestionProdtranslation(AQuestionProdtranslation node)
        {
            InPProdtranslation(node);
            InAQuestionProdtranslation(node);
            
            Visit(node.Rpar);
            Visit(node.QMark);
            Visit(node.Identifier);
            Visit(node.Arrow);
            Visit(node.Lpar);
            
            OutAQuestionProdtranslation(node);
            OutPProdtranslation(node);
        }
        
        public virtual void InPTranslation(PTranslation node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPTranslation(PTranslation node)
        {
            DefaultPOut(node);
        }
        public virtual void InAFullTranslation(AFullTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAFullTranslation(AFullTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAFullTranslation(AFullTranslation node)
        {
            InPTranslation(node);
            InAFullTranslation(node);
            
            Visit(node.Rpar);
            Visit((dynamic)node.Translation);
            Visit(node.Arrow);
            Visit(node.Lpar);
            
            OutAFullTranslation(node);
            OutPTranslation(node);
        }
        public virtual void InANewTranslation(ANewTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutANewTranslation(ANewTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseANewTranslation(ANewTranslation node)
        {
            InPTranslation(node);
            InANewTranslation(node);
            
            Visit(node.Rpar);
            Visit((dynamic)node.Arguments);
            Visit(node.Lpar);
            Visit(node.Production);
            Visit(node.New);
            
            OutANewTranslation(node);
            OutPTranslation(node);
        }
        public virtual void InANewalternativeTranslation(ANewalternativeTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutANewalternativeTranslation(ANewalternativeTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseANewalternativeTranslation(ANewalternativeTranslation node)
        {
            InPTranslation(node);
            InANewalternativeTranslation(node);
            
            Visit(node.Rpar);
            Visit((dynamic)node.Arguments);
            Visit(node.Lpar);
            Visit(node.Alternative);
            Visit(node.Dot);
            Visit(node.Production);
            Visit(node.New);
            
            OutANewalternativeTranslation(node);
            OutPTranslation(node);
        }
        public virtual void InAListTranslation(AListTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAListTranslation(AListTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAListTranslation(AListTranslation node)
        {
            InPTranslation(node);
            InAListTranslation(node);
            
            Visit(node.Rpar);
            Visit((dynamic)node.Elements);
            Visit(node.Lpar);
            
            OutAListTranslation(node);
            OutPTranslation(node);
        }
        public virtual void InANullTranslation(ANullTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutANullTranslation(ANullTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseANullTranslation(ANullTranslation node)
        {
            InPTranslation(node);
            InANullTranslation(node);
            
            Visit(node.Null);
            
            OutANullTranslation(node);
            OutPTranslation(node);
        }
        public virtual void InAIdTranslation(AIdTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIdTranslation(AIdTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIdTranslation(AIdTranslation node)
        {
            InPTranslation(node);
            InAIdTranslation(node);
            
            Visit(node.Identifier);
            
            OutAIdTranslation(node);
            OutPTranslation(node);
        }
        public virtual void InAIddotidTranslation(AIddotidTranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIddotidTranslation(AIddotidTranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIddotidTranslation(AIddotidTranslation node)
        {
            InPTranslation(node);
            InAIddotidTranslation(node);
            
            Visit(node.Production);
            Visit(node.Dot);
            Visit(node.Identifier);
            
            OutAIddotidTranslation(node);
            OutPTranslation(node);
        }
        
        public virtual void InPProductionrule(PProductionrule node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPProductionrule(PProductionrule node)
        {
            DefaultPOut(node);
        }
        public virtual void InAProductionrule(AProductionrule node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAProductionrule(AProductionrule node)
        {
            DefaultAOut(node);
        }
        public override void CaseAProductionrule(AProductionrule node)
        {
            InPProductionrule(node);
            InAProductionrule(node);
            
            {
                PAlternative[] temp = new PAlternative[node.Alternatives.Count];
                node.Alternatives.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    Visit((dynamic)temp[i]);
            }
            
            OutAProductionrule(node);
            OutPProductionrule(node);
        }
        
        public virtual void InPAlternative(PAlternative node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPAlternative(PAlternative node)
        {
            DefaultPOut(node);
        }
        public virtual void InAAlternative(AAlternative node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAAlternative(AAlternative node)
        {
            DefaultAOut(node);
        }
        public override void CaseAAlternative(AAlternative node)
        {
            InPAlternative(node);
            InAAlternative(node);
            
            if (node.HasTranslation)
                Visit((dynamic)node.Translation);
            Visit((dynamic)node.Elements);
            if (node.HasAlternativename)
                Visit((dynamic)node.Alternativename);
            if (node.HasPipe)
                Visit(node.Pipe);
            
            OutAAlternative(node);
            OutPAlternative(node);
        }
        
        public virtual void InPAlternativename(PAlternativename node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPAlternativename(PAlternativename node)
        {
            DefaultPOut(node);
        }
        public virtual void InAAlternativename(AAlternativename node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAAlternativename(AAlternativename node)
        {
            DefaultAOut(node);
        }
        public override void CaseAAlternativename(AAlternativename node)
        {
            InPAlternativename(node);
            InAAlternativename(node);
            
            Visit(node.Rpar);
            Visit(node.Name);
            Visit(node.Lpar);
            
            OutAAlternativename(node);
            OutPAlternativename(node);
        }
        
        public virtual void InPElements(PElements node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPElements(PElements node)
        {
            DefaultPOut(node);
        }
        public virtual void InAElements(AElements node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAElements(AElements node)
        {
            DefaultAOut(node);
        }
        public override void CaseAElements(AElements node)
        {
            InPElements(node);
            InAElements(node);
            
            {
                PElement[] temp = new PElement[node.Element.Count];
                node.Element.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    Visit((dynamic)temp[i]);
            }
            
            OutAElements(node);
            OutPElements(node);
        }
        
        public virtual void InPElement(PElement node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPElement(PElement node)
        {
            DefaultPOut(node);
        }
        public virtual void InASimpleElement(ASimpleElement node)
        {
            DefaultAIn(node);
        }
        public virtual void OutASimpleElement(ASimpleElement node)
        {
            DefaultAOut(node);
        }
        public override void CaseASimpleElement(ASimpleElement node)
        {
            InPElement(node);
            InASimpleElement(node);
            
            Visit((dynamic)node.Elementid);
            if (node.HasElementname)
                Visit((dynamic)node.Elementname);
            
            OutASimpleElement(node);
            OutPElement(node);
        }
        public virtual void InAStarElement(AStarElement node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStarElement(AStarElement node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStarElement(AStarElement node)
        {
            InPElement(node);
            InAStarElement(node);
            
            Visit(node.Star);
            Visit((dynamic)node.Elementid);
            if (node.HasElementname)
                Visit((dynamic)node.Elementname);
            
            OutAStarElement(node);
            OutPElement(node);
        }
        public virtual void InAQuestionElement(AQuestionElement node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAQuestionElement(AQuestionElement node)
        {
            DefaultAOut(node);
        }
        public override void CaseAQuestionElement(AQuestionElement node)
        {
            InPElement(node);
            InAQuestionElement(node);
            
            Visit(node.QMark);
            Visit((dynamic)node.Elementid);
            if (node.HasElementname)
                Visit((dynamic)node.Elementname);
            
            OutAQuestionElement(node);
            OutPElement(node);
        }
        public virtual void InAPlusElement(APlusElement node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAPlusElement(APlusElement node)
        {
            DefaultAOut(node);
        }
        public override void CaseAPlusElement(APlusElement node)
        {
            InPElement(node);
            InAPlusElement(node);
            
            Visit(node.Plus);
            Visit((dynamic)node.Elementid);
            if (node.HasElementname)
                Visit((dynamic)node.Elementname);
            
            OutAPlusElement(node);
            OutPElement(node);
        }
        
        public virtual void InPElementname(PElementname node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPElementname(PElementname node)
        {
            DefaultPOut(node);
        }
        public virtual void InAElementname(AElementname node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAElementname(AElementname node)
        {
            DefaultAOut(node);
        }
        public override void CaseAElementname(AElementname node)
        {
            InPElementname(node);
            InAElementname(node);
            
            Visit(node.Colon);
            Visit(node.Rpar);
            Visit(node.Name);
            Visit(node.Lpar);
            
            OutAElementname(node);
            OutPElementname(node);
        }
        
        public virtual void InPElementid(PElementid node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPElementid(PElementid node)
        {
            DefaultPOut(node);
        }
        public virtual void InACleanElementid(ACleanElementid node)
        {
            DefaultAIn(node);
        }
        public virtual void OutACleanElementid(ACleanElementid node)
        {
            DefaultAOut(node);
        }
        public override void CaseACleanElementid(ACleanElementid node)
        {
            InPElementid(node);
            InACleanElementid(node);
            
            Visit(node.Identifier);
            
            OutACleanElementid(node);
            OutPElementid(node);
        }
        public virtual void InATokenElementid(ATokenElementid node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokenElementid(ATokenElementid node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokenElementid(ATokenElementid node)
        {
            InPElementid(node);
            InATokenElementid(node);
            
            Visit(node.Identifier);
            Visit(node.Dot);
            Visit(node.TokenSpecifier);
            
            OutATokenElementid(node);
            OutPElementid(node);
        }
        public virtual void InAProductionElementid(AProductionElementid node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAProductionElementid(AProductionElementid node)
        {
            DefaultAOut(node);
        }
        public override void CaseAProductionElementid(AProductionElementid node)
        {
            InPElementid(node);
            InAProductionElementid(node);
            
            Visit(node.Identifier);
            Visit(node.Dot);
            Visit(node.ProductionSpecifier);
            
            OutAProductionElementid(node);
            OutPElementid(node);
        }
        
        public virtual void InPHighlightrules(PHighlightrules node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPHighlightrules(PHighlightrules node)
        {
            DefaultPOut(node);
        }
        public virtual void InAHighlightrules(AHighlightrules node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHighlightrules(AHighlightrules node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHighlightrules(AHighlightrules node)
        {
            InPHighlightrules(node);
            InAHighlightrules(node);
            
            {
                PHighlightrule[] temp = new PHighlightrule[node.Highlightrule.Count];
                node.Highlightrule.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    Visit((dynamic)temp[i]);
            }
            Visit(node.Highlighttoken);
            
            OutAHighlightrules(node);
            OutPHighlightrules(node);
        }
        
        public virtual void InPHighlightrule(PHighlightrule node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPHighlightrule(PHighlightrule node)
        {
            DefaultPOut(node);
        }
        public virtual void InAHighlightrule(AHighlightrule node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHighlightrule(AHighlightrule node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHighlightrule(AHighlightrule node)
        {
            InPHighlightrule(node);
            InAHighlightrule(node);
            
            Visit(node.Semicolon);
            Visit((dynamic)node.List);
            Visit(node.Rpar);
            Visit((dynamic)node.Tokens);
            Visit(node.Lpar);
            Visit(node.Name);
            
            OutAHighlightrule(node);
            OutPHighlightrule(node);
        }
        
        public virtual void InPHighlightStyle(PHighlightStyle node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPHighlightStyle(PHighlightStyle node)
        {
            DefaultPOut(node);
        }
        public virtual void InAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            DefaultAOut(node);
        }
        public override void CaseAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            InPHighlightStyle(node);
            InAItalicHighlightStyle(node);
            
            Visit(node.Italic);
            
            OutAItalicHighlightStyle(node);
            OutPHighlightStyle(node);
        }
        public virtual void InABoldHighlightStyle(ABoldHighlightStyle node)
        {
            DefaultAIn(node);
        }
        public virtual void OutABoldHighlightStyle(ABoldHighlightStyle node)
        {
            DefaultAOut(node);
        }
        public override void CaseABoldHighlightStyle(ABoldHighlightStyle node)
        {
            InPHighlightStyle(node);
            InABoldHighlightStyle(node);
            
            Visit(node.Bold);
            
            OutABoldHighlightStyle(node);
            OutPHighlightStyle(node);
        }
        public virtual void InATextHighlightStyle(ATextHighlightStyle node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATextHighlightStyle(ATextHighlightStyle node)
        {
            DefaultAOut(node);
        }
        public override void CaseATextHighlightStyle(ATextHighlightStyle node)
        {
            InPHighlightStyle(node);
            InATextHighlightStyle(node);
            
            Visit((dynamic)node.Color);
            Visit(node.Colon);
            Visit(node.Text);
            
            OutATextHighlightStyle(node);
            OutPHighlightStyle(node);
        }
        public virtual void InABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            DefaultAIn(node);
        }
        public virtual void OutABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            DefaultAOut(node);
        }
        public override void CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            InPHighlightStyle(node);
            InABackgroundHighlightStyle(node);
            
            Visit((dynamic)node.Color);
            Visit(node.Colon);
            Visit(node.Background);
            
            OutABackgroundHighlightStyle(node);
            OutPHighlightStyle(node);
        }
        
        public virtual void InPColor(PColor node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPColor(PColor node)
        {
            DefaultPOut(node);
        }
        public virtual void InARgbColor(ARgbColor node)
        {
            DefaultAIn(node);
        }
        public virtual void OutARgbColor(ARgbColor node)
        {
            DefaultAOut(node);
        }
        public override void CaseARgbColor(ARgbColor node)
        {
            InPColor(node);
            InARgbColor(node);
            
            Visit(node.RPar);
            Visit(node.Blue);
            Visit(node.Comma2);
            Visit(node.Green);
            Visit(node.Comma1);
            Visit(node.Red);
            Visit(node.LPar);
            Visit(node.Rgb);
            
            OutARgbColor(node);
            OutPColor(node);
        }
        public virtual void InAHsvColor(AHsvColor node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHsvColor(AHsvColor node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHsvColor(AHsvColor node)
        {
            InPColor(node);
            InAHsvColor(node);
            
            Visit(node.RPar);
            Visit(node.Brightness);
            Visit(node.Comma2);
            Visit(node.Saturation);
            Visit(node.Comma1);
            Visit(node.Hue);
            Visit(node.LPar);
            Visit(node.Hsv);
            
            OutAHsvColor(node);
            OutPColor(node);
        }
        public virtual void InAHexColor(AHexColor node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHexColor(AHexColor node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHexColor(AHexColor node)
        {
            InPColor(node);
            InAHexColor(node);
            
            Visit(node.Color);
            
            OutAHexColor(node);
            OutPColor(node);
        }
    }
    
    #endregion
    
    #region Return analysis adapters
    
    public class ReturnAnalysisAdapter<TResult> : ReturnAdapter<TResult, PGrammar>
    {
        public override TResult Visit(Node node)
        {
            return Visit((dynamic)node);
        }
        
        public TResult Visit(AGrammar node)
        {
            return CaseAGrammar(node);
        }
        public virtual TResult CaseAGrammar(AGrammar node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(APackage node)
        {
            return CaseAPackage(node);
        }
        public virtual TResult CaseAPackage(APackage node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AHelpers node)
        {
            return CaseAHelpers(node);
        }
        public virtual TResult CaseAHelpers(AHelpers node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AHelper node)
        {
            return CaseAHelper(node);
        }
        public virtual TResult CaseAHelper(AHelper node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ATokens node)
        {
            return CaseATokens(node);
        }
        public virtual TResult CaseATokens(ATokens node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AToken node)
        {
            return CaseAToken(node);
        }
        public virtual TResult CaseAToken(AToken node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ATokenlookahead node)
        {
            return CaseATokenlookahead(node);
        }
        public virtual TResult CaseATokenlookahead(ATokenlookahead node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ARegex node)
        {
            return CaseARegex(node);
        }
        public virtual TResult CaseARegex(ARegex node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ARegexOrpart node)
        {
            return CaseARegexOrpart(node);
        }
        public virtual TResult CaseARegexOrpart(ARegexOrpart node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ACharRegexpart node)
        {
            return CaseACharRegexpart(node);
        }
        public virtual TResult CaseACharRegexpart(ACharRegexpart node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ADecRegexpart node)
        {
            return CaseADecRegexpart(node);
        }
        public virtual TResult CaseADecRegexpart(ADecRegexpart node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AHexRegexpart node)
        {
            return CaseAHexRegexpart(node);
        }
        public virtual TResult CaseAHexRegexpart(AHexRegexpart node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AUnarystarRegexpart node)
        {
            return CaseAUnarystarRegexpart(node);
        }
        public virtual TResult CaseAUnarystarRegexpart(AUnarystarRegexpart node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AUnaryquestionRegexpart node)
        {
            return CaseAUnaryquestionRegexpart(node);
        }
        public virtual TResult CaseAUnaryquestionRegexpart(AUnaryquestionRegexpart node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AUnaryplusRegexpart node)
        {
            return CaseAUnaryplusRegexpart(node);
        }
        public virtual TResult CaseAUnaryplusRegexpart(AUnaryplusRegexpart node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ABinaryplusRegexpart node)
        {
            return CaseABinaryplusRegexpart(node);
        }
        public virtual TResult CaseABinaryplusRegexpart(ABinaryplusRegexpart node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ABinaryminusRegexpart node)
        {
            return CaseABinaryminusRegexpart(node);
        }
        public virtual TResult CaseABinaryminusRegexpart(ABinaryminusRegexpart node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AIntervalRegexpart node)
        {
            return CaseAIntervalRegexpart(node);
        }
        public virtual TResult CaseAIntervalRegexpart(AIntervalRegexpart node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AStringRegexpart node)
        {
            return CaseAStringRegexpart(node);
        }
        public virtual TResult CaseAStringRegexpart(AStringRegexpart node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AIdentifierRegexpart node)
        {
            return CaseAIdentifierRegexpart(node);
        }
        public virtual TResult CaseAIdentifierRegexpart(AIdentifierRegexpart node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AParenthesisRegexpart node)
        {
            return CaseAParenthesisRegexpart(node);
        }
        public virtual TResult CaseAParenthesisRegexpart(AParenthesisRegexpart node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AStates node)
        {
            return CaseAStates(node);
        }
        public virtual TResult CaseAStates(AStates node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AIgnoredtokens node)
        {
            return CaseAIgnoredtokens(node);
        }
        public virtual TResult CaseAIgnoredtokens(AIgnoredtokens node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AIdentifierList node)
        {
            return CaseAIdentifierList(node);
        }
        public virtual TResult CaseAIdentifierList(AIdentifierList node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ATokenstateList node)
        {
            return CaseATokenstateList(node);
        }
        public virtual TResult CaseATokenstateList(ATokenstateList node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ATranslationList node)
        {
            return CaseATranslationList(node);
        }
        public virtual TResult CaseATranslationList(ATranslationList node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AStyleList node)
        {
            return CaseAStyleList(node);
        }
        public virtual TResult CaseAStyleList(AStyleList node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AIdentifierListitem node)
        {
            return CaseAIdentifierListitem(node);
        }
        public virtual TResult CaseAIdentifierListitem(AIdentifierListitem node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ATokenstateListitem node)
        {
            return CaseATokenstateListitem(node);
        }
        public virtual TResult CaseATokenstateListitem(ATokenstateListitem node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ATokenstatetransitionListitem node)
        {
            return CaseATokenstatetransitionListitem(node);
        }
        public virtual TResult CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ATranslationListitem node)
        {
            return CaseATranslationListitem(node);
        }
        public virtual TResult CaseATranslationListitem(ATranslationListitem node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AStyleListitem node)
        {
            return CaseAStyleListitem(node);
        }
        public virtual TResult CaseAStyleListitem(AStyleListitem node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AProductions node)
        {
            return CaseAProductions(node);
        }
        public virtual TResult CaseAProductions(AProductions node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AAstproductions node)
        {
            return CaseAAstproductions(node);
        }
        public virtual TResult CaseAAstproductions(AAstproductions node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AProduction node)
        {
            return CaseAProduction(node);
        }
        public virtual TResult CaseAProduction(AProduction node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ACleanProdtranslation node)
        {
            return CaseACleanProdtranslation(node);
        }
        public virtual TResult CaseACleanProdtranslation(ACleanProdtranslation node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AStarProdtranslation node)
        {
            return CaseAStarProdtranslation(node);
        }
        public virtual TResult CaseAStarProdtranslation(AStarProdtranslation node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(APlusProdtranslation node)
        {
            return CaseAPlusProdtranslation(node);
        }
        public virtual TResult CaseAPlusProdtranslation(APlusProdtranslation node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AQuestionProdtranslation node)
        {
            return CaseAQuestionProdtranslation(node);
        }
        public virtual TResult CaseAQuestionProdtranslation(AQuestionProdtranslation node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AFullTranslation node)
        {
            return CaseAFullTranslation(node);
        }
        public virtual TResult CaseAFullTranslation(AFullTranslation node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ANewTranslation node)
        {
            return CaseANewTranslation(node);
        }
        public virtual TResult CaseANewTranslation(ANewTranslation node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ANewalternativeTranslation node)
        {
            return CaseANewalternativeTranslation(node);
        }
        public virtual TResult CaseANewalternativeTranslation(ANewalternativeTranslation node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AListTranslation node)
        {
            return CaseAListTranslation(node);
        }
        public virtual TResult CaseAListTranslation(AListTranslation node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ANullTranslation node)
        {
            return CaseANullTranslation(node);
        }
        public virtual TResult CaseANullTranslation(ANullTranslation node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AIdTranslation node)
        {
            return CaseAIdTranslation(node);
        }
        public virtual TResult CaseAIdTranslation(AIdTranslation node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AIddotidTranslation node)
        {
            return CaseAIddotidTranslation(node);
        }
        public virtual TResult CaseAIddotidTranslation(AIddotidTranslation node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AProductionrule node)
        {
            return CaseAProductionrule(node);
        }
        public virtual TResult CaseAProductionrule(AProductionrule node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AAlternative node)
        {
            return CaseAAlternative(node);
        }
        public virtual TResult CaseAAlternative(AAlternative node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AAlternativename node)
        {
            return CaseAAlternativename(node);
        }
        public virtual TResult CaseAAlternativename(AAlternativename node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AElements node)
        {
            return CaseAElements(node);
        }
        public virtual TResult CaseAElements(AElements node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ASimpleElement node)
        {
            return CaseASimpleElement(node);
        }
        public virtual TResult CaseASimpleElement(ASimpleElement node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AStarElement node)
        {
            return CaseAStarElement(node);
        }
        public virtual TResult CaseAStarElement(AStarElement node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AQuestionElement node)
        {
            return CaseAQuestionElement(node);
        }
        public virtual TResult CaseAQuestionElement(AQuestionElement node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(APlusElement node)
        {
            return CaseAPlusElement(node);
        }
        public virtual TResult CaseAPlusElement(APlusElement node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AElementname node)
        {
            return CaseAElementname(node);
        }
        public virtual TResult CaseAElementname(AElementname node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ACleanElementid node)
        {
            return CaseACleanElementid(node);
        }
        public virtual TResult CaseACleanElementid(ACleanElementid node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ATokenElementid node)
        {
            return CaseATokenElementid(node);
        }
        public virtual TResult CaseATokenElementid(ATokenElementid node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AProductionElementid node)
        {
            return CaseAProductionElementid(node);
        }
        public virtual TResult CaseAProductionElementid(AProductionElementid node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AHighlightrules node)
        {
            return CaseAHighlightrules(node);
        }
        public virtual TResult CaseAHighlightrules(AHighlightrules node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AHighlightrule node)
        {
            return CaseAHighlightrule(node);
        }
        public virtual TResult CaseAHighlightrule(AHighlightrule node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AItalicHighlightStyle node)
        {
            return CaseAItalicHighlightStyle(node);
        }
        public virtual TResult CaseAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ABoldHighlightStyle node)
        {
            return CaseABoldHighlightStyle(node);
        }
        public virtual TResult CaseABoldHighlightStyle(ABoldHighlightStyle node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ATextHighlightStyle node)
        {
            return CaseATextHighlightStyle(node);
        }
        public virtual TResult CaseATextHighlightStyle(ATextHighlightStyle node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ABackgroundHighlightStyle node)
        {
            return CaseABackgroundHighlightStyle(node);
        }
        public virtual TResult CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(ARgbColor node)
        {
            return CaseARgbColor(node);
        }
        public virtual TResult CaseARgbColor(ARgbColor node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AHsvColor node)
        {
            return CaseAHsvColor(node);
        }
        public virtual TResult CaseAHsvColor(AHsvColor node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(AHexColor node)
        {
            return CaseAHexColor(node);
        }
        public virtual TResult CaseAHexColor(AHexColor node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TPackagename node)
        {
            return CaseTPackagename(node);
        }
        public virtual TResult CaseTPackagename(TPackagename node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TPackagetoken node)
        {
            return CaseTPackagetoken(node);
        }
        public virtual TResult CaseTPackagetoken(TPackagetoken node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TStatestoken node)
        {
            return CaseTStatestoken(node);
        }
        public virtual TResult CaseTStatestoken(TStatestoken node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(THelperstoken node)
        {
            return CaseTHelperstoken(node);
        }
        public virtual TResult CaseTHelperstoken(THelperstoken node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TTokenstoken node)
        {
            return CaseTTokenstoken(node);
        }
        public virtual TResult CaseTTokenstoken(TTokenstoken node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TIgnoredtoken node)
        {
            return CaseTIgnoredtoken(node);
        }
        public virtual TResult CaseTIgnoredtoken(TIgnoredtoken node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TProductionstoken node)
        {
            return CaseTProductionstoken(node);
        }
        public virtual TResult CaseTProductionstoken(TProductionstoken node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TAsttoken node)
        {
            return CaseTAsttoken(node);
        }
        public virtual TResult CaseTAsttoken(TAsttoken node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(THighlighttoken node)
        {
            return CaseTHighlighttoken(node);
        }
        public virtual TResult CaseTHighlighttoken(THighlighttoken node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TNew node)
        {
            return CaseTNew(node);
        }
        public virtual TResult CaseTNew(TNew node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TNull node)
        {
            return CaseTNull(node);
        }
        public virtual TResult CaseTNull(TNull node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TTokenSpecifier node)
        {
            return CaseTTokenSpecifier(node);
        }
        public virtual TResult CaseTTokenSpecifier(TTokenSpecifier node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TProductionSpecifier node)
        {
            return CaseTProductionSpecifier(node);
        }
        public virtual TResult CaseTProductionSpecifier(TProductionSpecifier node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TDot node)
        {
            return CaseTDot(node);
        }
        public virtual TResult CaseTDot(TDot node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TDDot node)
        {
            return CaseTDDot(node);
        }
        public virtual TResult CaseTDDot(TDDot node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TSemicolon node)
        {
            return CaseTSemicolon(node);
        }
        public virtual TResult CaseTSemicolon(TSemicolon node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TEqual node)
        {
            return CaseTEqual(node);
        }
        public virtual TResult CaseTEqual(TEqual node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TLBkt node)
        {
            return CaseTLBkt(node);
        }
        public virtual TResult CaseTLBkt(TLBkt node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TRBkt node)
        {
            return CaseTRBkt(node);
        }
        public virtual TResult CaseTRBkt(TRBkt node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TLPar node)
        {
            return CaseTLPar(node);
        }
        public virtual TResult CaseTLPar(TLPar node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TRPar node)
        {
            return CaseTRPar(node);
        }
        public virtual TResult CaseTRPar(TRPar node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TLBrace node)
        {
            return CaseTLBrace(node);
        }
        public virtual TResult CaseTLBrace(TLBrace node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TRBrace node)
        {
            return CaseTRBrace(node);
        }
        public virtual TResult CaseTRBrace(TRBrace node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TPlus node)
        {
            return CaseTPlus(node);
        }
        public virtual TResult CaseTPlus(TPlus node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TMinus node)
        {
            return CaseTMinus(node);
        }
        public virtual TResult CaseTMinus(TMinus node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TQMark node)
        {
            return CaseTQMark(node);
        }
        public virtual TResult CaseTQMark(TQMark node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TStar node)
        {
            return CaseTStar(node);
        }
        public virtual TResult CaseTStar(TStar node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TPipe node)
        {
            return CaseTPipe(node);
        }
        public virtual TResult CaseTPipe(TPipe node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TComma node)
        {
            return CaseTComma(node);
        }
        public virtual TResult CaseTComma(TComma node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TSlash node)
        {
            return CaseTSlash(node);
        }
        public virtual TResult CaseTSlash(TSlash node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TArrow node)
        {
            return CaseTArrow(node);
        }
        public virtual TResult CaseTArrow(TArrow node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TColon node)
        {
            return CaseTColon(node);
        }
        public virtual TResult CaseTColon(TColon node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TIdentifier node)
        {
            return CaseTIdentifier(node);
        }
        public virtual TResult CaseTIdentifier(TIdentifier node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TCharacter node)
        {
            return CaseTCharacter(node);
        }
        public virtual TResult CaseTCharacter(TCharacter node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TDecChar node)
        {
            return CaseTDecChar(node);
        }
        public virtual TResult CaseTDecChar(TDecChar node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(THexChar node)
        {
            return CaseTHexChar(node);
        }
        public virtual TResult CaseTHexChar(THexChar node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TString node)
        {
            return CaseTString(node);
        }
        public virtual TResult CaseTString(TString node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TBlank node)
        {
            return CaseTBlank(node);
        }
        public virtual TResult CaseTBlank(TBlank node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TComment node)
        {
            return CaseTComment(node);
        }
        public virtual TResult CaseTComment(TComment node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TItalic node)
        {
            return CaseTItalic(node);
        }
        public virtual TResult CaseTItalic(TItalic node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TBold node)
        {
            return CaseTBold(node);
        }
        public virtual TResult CaseTBold(TBold node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TText node)
        {
            return CaseTText(node);
        }
        public virtual TResult CaseTText(TText node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TBackground node)
        {
            return CaseTBackground(node);
        }
        public virtual TResult CaseTBackground(TBackground node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(TRgb node)
        {
            return CaseTRgb(node);
        }
        public virtual TResult CaseTRgb(TRgb node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(THsv node)
        {
            return CaseTHsv(node);
        }
        public virtual TResult CaseTHsv(THsv node)
        {
            return DefaultCase(node);
        }
        public TResult Visit(THexColor node)
        {
            return CaseTHexColor(node);
        }
        public virtual TResult CaseTHexColor(THexColor node)
        {
            return DefaultCase(node);
        }
    }
    public class ReturnAnalysisAdapter<T1, TResult> : ReturnAdapter<T1, TResult, PGrammar>
    {
        public override TResult Visit(Node node, T1 arg1)
        {
            return Visit((dynamic)node, arg1);
        }
        
        public TResult Visit(AGrammar node, T1 arg1)
        {
            return CaseAGrammar(node, arg1);
        }
        public virtual TResult CaseAGrammar(AGrammar node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(APackage node, T1 arg1)
        {
            return CaseAPackage(node, arg1);
        }
        public virtual TResult CaseAPackage(APackage node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AHelpers node, T1 arg1)
        {
            return CaseAHelpers(node, arg1);
        }
        public virtual TResult CaseAHelpers(AHelpers node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AHelper node, T1 arg1)
        {
            return CaseAHelper(node, arg1);
        }
        public virtual TResult CaseAHelper(AHelper node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ATokens node, T1 arg1)
        {
            return CaseATokens(node, arg1);
        }
        public virtual TResult CaseATokens(ATokens node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AToken node, T1 arg1)
        {
            return CaseAToken(node, arg1);
        }
        public virtual TResult CaseAToken(AToken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ATokenlookahead node, T1 arg1)
        {
            return CaseATokenlookahead(node, arg1);
        }
        public virtual TResult CaseATokenlookahead(ATokenlookahead node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ARegex node, T1 arg1)
        {
            return CaseARegex(node, arg1);
        }
        public virtual TResult CaseARegex(ARegex node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ARegexOrpart node, T1 arg1)
        {
            return CaseARegexOrpart(node, arg1);
        }
        public virtual TResult CaseARegexOrpart(ARegexOrpart node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ACharRegexpart node, T1 arg1)
        {
            return CaseACharRegexpart(node, arg1);
        }
        public virtual TResult CaseACharRegexpart(ACharRegexpart node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ADecRegexpart node, T1 arg1)
        {
            return CaseADecRegexpart(node, arg1);
        }
        public virtual TResult CaseADecRegexpart(ADecRegexpart node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AHexRegexpart node, T1 arg1)
        {
            return CaseAHexRegexpart(node, arg1);
        }
        public virtual TResult CaseAHexRegexpart(AHexRegexpart node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AUnarystarRegexpart node, T1 arg1)
        {
            return CaseAUnarystarRegexpart(node, arg1);
        }
        public virtual TResult CaseAUnarystarRegexpart(AUnarystarRegexpart node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AUnaryquestionRegexpart node, T1 arg1)
        {
            return CaseAUnaryquestionRegexpart(node, arg1);
        }
        public virtual TResult CaseAUnaryquestionRegexpart(AUnaryquestionRegexpart node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AUnaryplusRegexpart node, T1 arg1)
        {
            return CaseAUnaryplusRegexpart(node, arg1);
        }
        public virtual TResult CaseAUnaryplusRegexpart(AUnaryplusRegexpart node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ABinaryplusRegexpart node, T1 arg1)
        {
            return CaseABinaryplusRegexpart(node, arg1);
        }
        public virtual TResult CaseABinaryplusRegexpart(ABinaryplusRegexpart node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ABinaryminusRegexpart node, T1 arg1)
        {
            return CaseABinaryminusRegexpart(node, arg1);
        }
        public virtual TResult CaseABinaryminusRegexpart(ABinaryminusRegexpart node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AIntervalRegexpart node, T1 arg1)
        {
            return CaseAIntervalRegexpart(node, arg1);
        }
        public virtual TResult CaseAIntervalRegexpart(AIntervalRegexpart node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AStringRegexpart node, T1 arg1)
        {
            return CaseAStringRegexpart(node, arg1);
        }
        public virtual TResult CaseAStringRegexpart(AStringRegexpart node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AIdentifierRegexpart node, T1 arg1)
        {
            return CaseAIdentifierRegexpart(node, arg1);
        }
        public virtual TResult CaseAIdentifierRegexpart(AIdentifierRegexpart node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AParenthesisRegexpart node, T1 arg1)
        {
            return CaseAParenthesisRegexpart(node, arg1);
        }
        public virtual TResult CaseAParenthesisRegexpart(AParenthesisRegexpart node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AStates node, T1 arg1)
        {
            return CaseAStates(node, arg1);
        }
        public virtual TResult CaseAStates(AStates node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AIgnoredtokens node, T1 arg1)
        {
            return CaseAIgnoredtokens(node, arg1);
        }
        public virtual TResult CaseAIgnoredtokens(AIgnoredtokens node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AIdentifierList node, T1 arg1)
        {
            return CaseAIdentifierList(node, arg1);
        }
        public virtual TResult CaseAIdentifierList(AIdentifierList node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ATokenstateList node, T1 arg1)
        {
            return CaseATokenstateList(node, arg1);
        }
        public virtual TResult CaseATokenstateList(ATokenstateList node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ATranslationList node, T1 arg1)
        {
            return CaseATranslationList(node, arg1);
        }
        public virtual TResult CaseATranslationList(ATranslationList node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AStyleList node, T1 arg1)
        {
            return CaseAStyleList(node, arg1);
        }
        public virtual TResult CaseAStyleList(AStyleList node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AIdentifierListitem node, T1 arg1)
        {
            return CaseAIdentifierListitem(node, arg1);
        }
        public virtual TResult CaseAIdentifierListitem(AIdentifierListitem node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ATokenstateListitem node, T1 arg1)
        {
            return CaseATokenstateListitem(node, arg1);
        }
        public virtual TResult CaseATokenstateListitem(ATokenstateListitem node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ATokenstatetransitionListitem node, T1 arg1)
        {
            return CaseATokenstatetransitionListitem(node, arg1);
        }
        public virtual TResult CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ATranslationListitem node, T1 arg1)
        {
            return CaseATranslationListitem(node, arg1);
        }
        public virtual TResult CaseATranslationListitem(ATranslationListitem node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AStyleListitem node, T1 arg1)
        {
            return CaseAStyleListitem(node, arg1);
        }
        public virtual TResult CaseAStyleListitem(AStyleListitem node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AProductions node, T1 arg1)
        {
            return CaseAProductions(node, arg1);
        }
        public virtual TResult CaseAProductions(AProductions node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AAstproductions node, T1 arg1)
        {
            return CaseAAstproductions(node, arg1);
        }
        public virtual TResult CaseAAstproductions(AAstproductions node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AProduction node, T1 arg1)
        {
            return CaseAProduction(node, arg1);
        }
        public virtual TResult CaseAProduction(AProduction node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ACleanProdtranslation node, T1 arg1)
        {
            return CaseACleanProdtranslation(node, arg1);
        }
        public virtual TResult CaseACleanProdtranslation(ACleanProdtranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AStarProdtranslation node, T1 arg1)
        {
            return CaseAStarProdtranslation(node, arg1);
        }
        public virtual TResult CaseAStarProdtranslation(AStarProdtranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(APlusProdtranslation node, T1 arg1)
        {
            return CaseAPlusProdtranslation(node, arg1);
        }
        public virtual TResult CaseAPlusProdtranslation(APlusProdtranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AQuestionProdtranslation node, T1 arg1)
        {
            return CaseAQuestionProdtranslation(node, arg1);
        }
        public virtual TResult CaseAQuestionProdtranslation(AQuestionProdtranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AFullTranslation node, T1 arg1)
        {
            return CaseAFullTranslation(node, arg1);
        }
        public virtual TResult CaseAFullTranslation(AFullTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ANewTranslation node, T1 arg1)
        {
            return CaseANewTranslation(node, arg1);
        }
        public virtual TResult CaseANewTranslation(ANewTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ANewalternativeTranslation node, T1 arg1)
        {
            return CaseANewalternativeTranslation(node, arg1);
        }
        public virtual TResult CaseANewalternativeTranslation(ANewalternativeTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AListTranslation node, T1 arg1)
        {
            return CaseAListTranslation(node, arg1);
        }
        public virtual TResult CaseAListTranslation(AListTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ANullTranslation node, T1 arg1)
        {
            return CaseANullTranslation(node, arg1);
        }
        public virtual TResult CaseANullTranslation(ANullTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AIdTranslation node, T1 arg1)
        {
            return CaseAIdTranslation(node, arg1);
        }
        public virtual TResult CaseAIdTranslation(AIdTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AIddotidTranslation node, T1 arg1)
        {
            return CaseAIddotidTranslation(node, arg1);
        }
        public virtual TResult CaseAIddotidTranslation(AIddotidTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AProductionrule node, T1 arg1)
        {
            return CaseAProductionrule(node, arg1);
        }
        public virtual TResult CaseAProductionrule(AProductionrule node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AAlternative node, T1 arg1)
        {
            return CaseAAlternative(node, arg1);
        }
        public virtual TResult CaseAAlternative(AAlternative node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AAlternativename node, T1 arg1)
        {
            return CaseAAlternativename(node, arg1);
        }
        public virtual TResult CaseAAlternativename(AAlternativename node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AElements node, T1 arg1)
        {
            return CaseAElements(node, arg1);
        }
        public virtual TResult CaseAElements(AElements node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ASimpleElement node, T1 arg1)
        {
            return CaseASimpleElement(node, arg1);
        }
        public virtual TResult CaseASimpleElement(ASimpleElement node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AStarElement node, T1 arg1)
        {
            return CaseAStarElement(node, arg1);
        }
        public virtual TResult CaseAStarElement(AStarElement node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AQuestionElement node, T1 arg1)
        {
            return CaseAQuestionElement(node, arg1);
        }
        public virtual TResult CaseAQuestionElement(AQuestionElement node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(APlusElement node, T1 arg1)
        {
            return CaseAPlusElement(node, arg1);
        }
        public virtual TResult CaseAPlusElement(APlusElement node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AElementname node, T1 arg1)
        {
            return CaseAElementname(node, arg1);
        }
        public virtual TResult CaseAElementname(AElementname node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ACleanElementid node, T1 arg1)
        {
            return CaseACleanElementid(node, arg1);
        }
        public virtual TResult CaseACleanElementid(ACleanElementid node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ATokenElementid node, T1 arg1)
        {
            return CaseATokenElementid(node, arg1);
        }
        public virtual TResult CaseATokenElementid(ATokenElementid node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AProductionElementid node, T1 arg1)
        {
            return CaseAProductionElementid(node, arg1);
        }
        public virtual TResult CaseAProductionElementid(AProductionElementid node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AHighlightrules node, T1 arg1)
        {
            return CaseAHighlightrules(node, arg1);
        }
        public virtual TResult CaseAHighlightrules(AHighlightrules node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AHighlightrule node, T1 arg1)
        {
            return CaseAHighlightrule(node, arg1);
        }
        public virtual TResult CaseAHighlightrule(AHighlightrule node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AItalicHighlightStyle node, T1 arg1)
        {
            return CaseAItalicHighlightStyle(node, arg1);
        }
        public virtual TResult CaseAItalicHighlightStyle(AItalicHighlightStyle node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ABoldHighlightStyle node, T1 arg1)
        {
            return CaseABoldHighlightStyle(node, arg1);
        }
        public virtual TResult CaseABoldHighlightStyle(ABoldHighlightStyle node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ATextHighlightStyle node, T1 arg1)
        {
            return CaseATextHighlightStyle(node, arg1);
        }
        public virtual TResult CaseATextHighlightStyle(ATextHighlightStyle node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ABackgroundHighlightStyle node, T1 arg1)
        {
            return CaseABackgroundHighlightStyle(node, arg1);
        }
        public virtual TResult CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(ARgbColor node, T1 arg1)
        {
            return CaseARgbColor(node, arg1);
        }
        public virtual TResult CaseARgbColor(ARgbColor node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AHsvColor node, T1 arg1)
        {
            return CaseAHsvColor(node, arg1);
        }
        public virtual TResult CaseAHsvColor(AHsvColor node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(AHexColor node, T1 arg1)
        {
            return CaseAHexColor(node, arg1);
        }
        public virtual TResult CaseAHexColor(AHexColor node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TPackagename node, T1 arg1)
        {
            return CaseTPackagename(node, arg1);
        }
        public virtual TResult CaseTPackagename(TPackagename node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TPackagetoken node, T1 arg1)
        {
            return CaseTPackagetoken(node, arg1);
        }
        public virtual TResult CaseTPackagetoken(TPackagetoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TStatestoken node, T1 arg1)
        {
            return CaseTStatestoken(node, arg1);
        }
        public virtual TResult CaseTStatestoken(TStatestoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(THelperstoken node, T1 arg1)
        {
            return CaseTHelperstoken(node, arg1);
        }
        public virtual TResult CaseTHelperstoken(THelperstoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TTokenstoken node, T1 arg1)
        {
            return CaseTTokenstoken(node, arg1);
        }
        public virtual TResult CaseTTokenstoken(TTokenstoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TIgnoredtoken node, T1 arg1)
        {
            return CaseTIgnoredtoken(node, arg1);
        }
        public virtual TResult CaseTIgnoredtoken(TIgnoredtoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TProductionstoken node, T1 arg1)
        {
            return CaseTProductionstoken(node, arg1);
        }
        public virtual TResult CaseTProductionstoken(TProductionstoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TAsttoken node, T1 arg1)
        {
            return CaseTAsttoken(node, arg1);
        }
        public virtual TResult CaseTAsttoken(TAsttoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(THighlighttoken node, T1 arg1)
        {
            return CaseTHighlighttoken(node, arg1);
        }
        public virtual TResult CaseTHighlighttoken(THighlighttoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TNew node, T1 arg1)
        {
            return CaseTNew(node, arg1);
        }
        public virtual TResult CaseTNew(TNew node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TNull node, T1 arg1)
        {
            return CaseTNull(node, arg1);
        }
        public virtual TResult CaseTNull(TNull node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TTokenSpecifier node, T1 arg1)
        {
            return CaseTTokenSpecifier(node, arg1);
        }
        public virtual TResult CaseTTokenSpecifier(TTokenSpecifier node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TProductionSpecifier node, T1 arg1)
        {
            return CaseTProductionSpecifier(node, arg1);
        }
        public virtual TResult CaseTProductionSpecifier(TProductionSpecifier node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TDot node, T1 arg1)
        {
            return CaseTDot(node, arg1);
        }
        public virtual TResult CaseTDot(TDot node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TDDot node, T1 arg1)
        {
            return CaseTDDot(node, arg1);
        }
        public virtual TResult CaseTDDot(TDDot node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TSemicolon node, T1 arg1)
        {
            return CaseTSemicolon(node, arg1);
        }
        public virtual TResult CaseTSemicolon(TSemicolon node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TEqual node, T1 arg1)
        {
            return CaseTEqual(node, arg1);
        }
        public virtual TResult CaseTEqual(TEqual node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TLBkt node, T1 arg1)
        {
            return CaseTLBkt(node, arg1);
        }
        public virtual TResult CaseTLBkt(TLBkt node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TRBkt node, T1 arg1)
        {
            return CaseTRBkt(node, arg1);
        }
        public virtual TResult CaseTRBkt(TRBkt node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TLPar node, T1 arg1)
        {
            return CaseTLPar(node, arg1);
        }
        public virtual TResult CaseTLPar(TLPar node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TRPar node, T1 arg1)
        {
            return CaseTRPar(node, arg1);
        }
        public virtual TResult CaseTRPar(TRPar node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TLBrace node, T1 arg1)
        {
            return CaseTLBrace(node, arg1);
        }
        public virtual TResult CaseTLBrace(TLBrace node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TRBrace node, T1 arg1)
        {
            return CaseTRBrace(node, arg1);
        }
        public virtual TResult CaseTRBrace(TRBrace node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TPlus node, T1 arg1)
        {
            return CaseTPlus(node, arg1);
        }
        public virtual TResult CaseTPlus(TPlus node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TMinus node, T1 arg1)
        {
            return CaseTMinus(node, arg1);
        }
        public virtual TResult CaseTMinus(TMinus node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TQMark node, T1 arg1)
        {
            return CaseTQMark(node, arg1);
        }
        public virtual TResult CaseTQMark(TQMark node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TStar node, T1 arg1)
        {
            return CaseTStar(node, arg1);
        }
        public virtual TResult CaseTStar(TStar node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TPipe node, T1 arg1)
        {
            return CaseTPipe(node, arg1);
        }
        public virtual TResult CaseTPipe(TPipe node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TComma node, T1 arg1)
        {
            return CaseTComma(node, arg1);
        }
        public virtual TResult CaseTComma(TComma node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TSlash node, T1 arg1)
        {
            return CaseTSlash(node, arg1);
        }
        public virtual TResult CaseTSlash(TSlash node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TArrow node, T1 arg1)
        {
            return CaseTArrow(node, arg1);
        }
        public virtual TResult CaseTArrow(TArrow node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TColon node, T1 arg1)
        {
            return CaseTColon(node, arg1);
        }
        public virtual TResult CaseTColon(TColon node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TIdentifier node, T1 arg1)
        {
            return CaseTIdentifier(node, arg1);
        }
        public virtual TResult CaseTIdentifier(TIdentifier node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TCharacter node, T1 arg1)
        {
            return CaseTCharacter(node, arg1);
        }
        public virtual TResult CaseTCharacter(TCharacter node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TDecChar node, T1 arg1)
        {
            return CaseTDecChar(node, arg1);
        }
        public virtual TResult CaseTDecChar(TDecChar node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(THexChar node, T1 arg1)
        {
            return CaseTHexChar(node, arg1);
        }
        public virtual TResult CaseTHexChar(THexChar node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TString node, T1 arg1)
        {
            return CaseTString(node, arg1);
        }
        public virtual TResult CaseTString(TString node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TBlank node, T1 arg1)
        {
            return CaseTBlank(node, arg1);
        }
        public virtual TResult CaseTBlank(TBlank node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TComment node, T1 arg1)
        {
            return CaseTComment(node, arg1);
        }
        public virtual TResult CaseTComment(TComment node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TItalic node, T1 arg1)
        {
            return CaseTItalic(node, arg1);
        }
        public virtual TResult CaseTItalic(TItalic node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TBold node, T1 arg1)
        {
            return CaseTBold(node, arg1);
        }
        public virtual TResult CaseTBold(TBold node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TText node, T1 arg1)
        {
            return CaseTText(node, arg1);
        }
        public virtual TResult CaseTText(TText node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TBackground node, T1 arg1)
        {
            return CaseTBackground(node, arg1);
        }
        public virtual TResult CaseTBackground(TBackground node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(TRgb node, T1 arg1)
        {
            return CaseTRgb(node, arg1);
        }
        public virtual TResult CaseTRgb(TRgb node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(THsv node, T1 arg1)
        {
            return CaseTHsv(node, arg1);
        }
        public virtual TResult CaseTHsv(THsv node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public TResult Visit(THexColor node, T1 arg1)
        {
            return CaseTHexColor(node, arg1);
        }
        public virtual TResult CaseTHexColor(THexColor node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
    }
    public class ReturnAnalysisAdapter<T1, T2, TResult> : ReturnAdapter<T1, T2, TResult, PGrammar>
    {
        public override TResult Visit(Node node, T1 arg1, T2 arg2)
        {
            return Visit((dynamic)node, arg1, arg2);
        }
        
        public TResult Visit(AGrammar node, T1 arg1, T2 arg2)
        {
            return CaseAGrammar(node, arg1, arg2);
        }
        public virtual TResult CaseAGrammar(AGrammar node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(APackage node, T1 arg1, T2 arg2)
        {
            return CaseAPackage(node, arg1, arg2);
        }
        public virtual TResult CaseAPackage(APackage node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AHelpers node, T1 arg1, T2 arg2)
        {
            return CaseAHelpers(node, arg1, arg2);
        }
        public virtual TResult CaseAHelpers(AHelpers node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AHelper node, T1 arg1, T2 arg2)
        {
            return CaseAHelper(node, arg1, arg2);
        }
        public virtual TResult CaseAHelper(AHelper node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ATokens node, T1 arg1, T2 arg2)
        {
            return CaseATokens(node, arg1, arg2);
        }
        public virtual TResult CaseATokens(ATokens node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AToken node, T1 arg1, T2 arg2)
        {
            return CaseAToken(node, arg1, arg2);
        }
        public virtual TResult CaseAToken(AToken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ATokenlookahead node, T1 arg1, T2 arg2)
        {
            return CaseATokenlookahead(node, arg1, arg2);
        }
        public virtual TResult CaseATokenlookahead(ATokenlookahead node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ARegex node, T1 arg1, T2 arg2)
        {
            return CaseARegex(node, arg1, arg2);
        }
        public virtual TResult CaseARegex(ARegex node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ARegexOrpart node, T1 arg1, T2 arg2)
        {
            return CaseARegexOrpart(node, arg1, arg2);
        }
        public virtual TResult CaseARegexOrpart(ARegexOrpart node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ACharRegexpart node, T1 arg1, T2 arg2)
        {
            return CaseACharRegexpart(node, arg1, arg2);
        }
        public virtual TResult CaseACharRegexpart(ACharRegexpart node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ADecRegexpart node, T1 arg1, T2 arg2)
        {
            return CaseADecRegexpart(node, arg1, arg2);
        }
        public virtual TResult CaseADecRegexpart(ADecRegexpart node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AHexRegexpart node, T1 arg1, T2 arg2)
        {
            return CaseAHexRegexpart(node, arg1, arg2);
        }
        public virtual TResult CaseAHexRegexpart(AHexRegexpart node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AUnarystarRegexpart node, T1 arg1, T2 arg2)
        {
            return CaseAUnarystarRegexpart(node, arg1, arg2);
        }
        public virtual TResult CaseAUnarystarRegexpart(AUnarystarRegexpart node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AUnaryquestionRegexpart node, T1 arg1, T2 arg2)
        {
            return CaseAUnaryquestionRegexpart(node, arg1, arg2);
        }
        public virtual TResult CaseAUnaryquestionRegexpart(AUnaryquestionRegexpart node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AUnaryplusRegexpart node, T1 arg1, T2 arg2)
        {
            return CaseAUnaryplusRegexpart(node, arg1, arg2);
        }
        public virtual TResult CaseAUnaryplusRegexpart(AUnaryplusRegexpart node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ABinaryplusRegexpart node, T1 arg1, T2 arg2)
        {
            return CaseABinaryplusRegexpart(node, arg1, arg2);
        }
        public virtual TResult CaseABinaryplusRegexpart(ABinaryplusRegexpart node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ABinaryminusRegexpart node, T1 arg1, T2 arg2)
        {
            return CaseABinaryminusRegexpart(node, arg1, arg2);
        }
        public virtual TResult CaseABinaryminusRegexpart(ABinaryminusRegexpart node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AIntervalRegexpart node, T1 arg1, T2 arg2)
        {
            return CaseAIntervalRegexpart(node, arg1, arg2);
        }
        public virtual TResult CaseAIntervalRegexpart(AIntervalRegexpart node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AStringRegexpart node, T1 arg1, T2 arg2)
        {
            return CaseAStringRegexpart(node, arg1, arg2);
        }
        public virtual TResult CaseAStringRegexpart(AStringRegexpart node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AIdentifierRegexpart node, T1 arg1, T2 arg2)
        {
            return CaseAIdentifierRegexpart(node, arg1, arg2);
        }
        public virtual TResult CaseAIdentifierRegexpart(AIdentifierRegexpart node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AParenthesisRegexpart node, T1 arg1, T2 arg2)
        {
            return CaseAParenthesisRegexpart(node, arg1, arg2);
        }
        public virtual TResult CaseAParenthesisRegexpart(AParenthesisRegexpart node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AStates node, T1 arg1, T2 arg2)
        {
            return CaseAStates(node, arg1, arg2);
        }
        public virtual TResult CaseAStates(AStates node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AIgnoredtokens node, T1 arg1, T2 arg2)
        {
            return CaseAIgnoredtokens(node, arg1, arg2);
        }
        public virtual TResult CaseAIgnoredtokens(AIgnoredtokens node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AIdentifierList node, T1 arg1, T2 arg2)
        {
            return CaseAIdentifierList(node, arg1, arg2);
        }
        public virtual TResult CaseAIdentifierList(AIdentifierList node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ATokenstateList node, T1 arg1, T2 arg2)
        {
            return CaseATokenstateList(node, arg1, arg2);
        }
        public virtual TResult CaseATokenstateList(ATokenstateList node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ATranslationList node, T1 arg1, T2 arg2)
        {
            return CaseATranslationList(node, arg1, arg2);
        }
        public virtual TResult CaseATranslationList(ATranslationList node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AStyleList node, T1 arg1, T2 arg2)
        {
            return CaseAStyleList(node, arg1, arg2);
        }
        public virtual TResult CaseAStyleList(AStyleList node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AIdentifierListitem node, T1 arg1, T2 arg2)
        {
            return CaseAIdentifierListitem(node, arg1, arg2);
        }
        public virtual TResult CaseAIdentifierListitem(AIdentifierListitem node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ATokenstateListitem node, T1 arg1, T2 arg2)
        {
            return CaseATokenstateListitem(node, arg1, arg2);
        }
        public virtual TResult CaseATokenstateListitem(ATokenstateListitem node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ATokenstatetransitionListitem node, T1 arg1, T2 arg2)
        {
            return CaseATokenstatetransitionListitem(node, arg1, arg2);
        }
        public virtual TResult CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ATranslationListitem node, T1 arg1, T2 arg2)
        {
            return CaseATranslationListitem(node, arg1, arg2);
        }
        public virtual TResult CaseATranslationListitem(ATranslationListitem node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AStyleListitem node, T1 arg1, T2 arg2)
        {
            return CaseAStyleListitem(node, arg1, arg2);
        }
        public virtual TResult CaseAStyleListitem(AStyleListitem node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AProductions node, T1 arg1, T2 arg2)
        {
            return CaseAProductions(node, arg1, arg2);
        }
        public virtual TResult CaseAProductions(AProductions node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AAstproductions node, T1 arg1, T2 arg2)
        {
            return CaseAAstproductions(node, arg1, arg2);
        }
        public virtual TResult CaseAAstproductions(AAstproductions node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AProduction node, T1 arg1, T2 arg2)
        {
            return CaseAProduction(node, arg1, arg2);
        }
        public virtual TResult CaseAProduction(AProduction node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ACleanProdtranslation node, T1 arg1, T2 arg2)
        {
            return CaseACleanProdtranslation(node, arg1, arg2);
        }
        public virtual TResult CaseACleanProdtranslation(ACleanProdtranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AStarProdtranslation node, T1 arg1, T2 arg2)
        {
            return CaseAStarProdtranslation(node, arg1, arg2);
        }
        public virtual TResult CaseAStarProdtranslation(AStarProdtranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(APlusProdtranslation node, T1 arg1, T2 arg2)
        {
            return CaseAPlusProdtranslation(node, arg1, arg2);
        }
        public virtual TResult CaseAPlusProdtranslation(APlusProdtranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AQuestionProdtranslation node, T1 arg1, T2 arg2)
        {
            return CaseAQuestionProdtranslation(node, arg1, arg2);
        }
        public virtual TResult CaseAQuestionProdtranslation(AQuestionProdtranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AFullTranslation node, T1 arg1, T2 arg2)
        {
            return CaseAFullTranslation(node, arg1, arg2);
        }
        public virtual TResult CaseAFullTranslation(AFullTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ANewTranslation node, T1 arg1, T2 arg2)
        {
            return CaseANewTranslation(node, arg1, arg2);
        }
        public virtual TResult CaseANewTranslation(ANewTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ANewalternativeTranslation node, T1 arg1, T2 arg2)
        {
            return CaseANewalternativeTranslation(node, arg1, arg2);
        }
        public virtual TResult CaseANewalternativeTranslation(ANewalternativeTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AListTranslation node, T1 arg1, T2 arg2)
        {
            return CaseAListTranslation(node, arg1, arg2);
        }
        public virtual TResult CaseAListTranslation(AListTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ANullTranslation node, T1 arg1, T2 arg2)
        {
            return CaseANullTranslation(node, arg1, arg2);
        }
        public virtual TResult CaseANullTranslation(ANullTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AIdTranslation node, T1 arg1, T2 arg2)
        {
            return CaseAIdTranslation(node, arg1, arg2);
        }
        public virtual TResult CaseAIdTranslation(AIdTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AIddotidTranslation node, T1 arg1, T2 arg2)
        {
            return CaseAIddotidTranslation(node, arg1, arg2);
        }
        public virtual TResult CaseAIddotidTranslation(AIddotidTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AProductionrule node, T1 arg1, T2 arg2)
        {
            return CaseAProductionrule(node, arg1, arg2);
        }
        public virtual TResult CaseAProductionrule(AProductionrule node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AAlternative node, T1 arg1, T2 arg2)
        {
            return CaseAAlternative(node, arg1, arg2);
        }
        public virtual TResult CaseAAlternative(AAlternative node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AAlternativename node, T1 arg1, T2 arg2)
        {
            return CaseAAlternativename(node, arg1, arg2);
        }
        public virtual TResult CaseAAlternativename(AAlternativename node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AElements node, T1 arg1, T2 arg2)
        {
            return CaseAElements(node, arg1, arg2);
        }
        public virtual TResult CaseAElements(AElements node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ASimpleElement node, T1 arg1, T2 arg2)
        {
            return CaseASimpleElement(node, arg1, arg2);
        }
        public virtual TResult CaseASimpleElement(ASimpleElement node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AStarElement node, T1 arg1, T2 arg2)
        {
            return CaseAStarElement(node, arg1, arg2);
        }
        public virtual TResult CaseAStarElement(AStarElement node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AQuestionElement node, T1 arg1, T2 arg2)
        {
            return CaseAQuestionElement(node, arg1, arg2);
        }
        public virtual TResult CaseAQuestionElement(AQuestionElement node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(APlusElement node, T1 arg1, T2 arg2)
        {
            return CaseAPlusElement(node, arg1, arg2);
        }
        public virtual TResult CaseAPlusElement(APlusElement node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AElementname node, T1 arg1, T2 arg2)
        {
            return CaseAElementname(node, arg1, arg2);
        }
        public virtual TResult CaseAElementname(AElementname node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ACleanElementid node, T1 arg1, T2 arg2)
        {
            return CaseACleanElementid(node, arg1, arg2);
        }
        public virtual TResult CaseACleanElementid(ACleanElementid node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ATokenElementid node, T1 arg1, T2 arg2)
        {
            return CaseATokenElementid(node, arg1, arg2);
        }
        public virtual TResult CaseATokenElementid(ATokenElementid node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AProductionElementid node, T1 arg1, T2 arg2)
        {
            return CaseAProductionElementid(node, arg1, arg2);
        }
        public virtual TResult CaseAProductionElementid(AProductionElementid node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AHighlightrules node, T1 arg1, T2 arg2)
        {
            return CaseAHighlightrules(node, arg1, arg2);
        }
        public virtual TResult CaseAHighlightrules(AHighlightrules node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AHighlightrule node, T1 arg1, T2 arg2)
        {
            return CaseAHighlightrule(node, arg1, arg2);
        }
        public virtual TResult CaseAHighlightrule(AHighlightrule node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AItalicHighlightStyle node, T1 arg1, T2 arg2)
        {
            return CaseAItalicHighlightStyle(node, arg1, arg2);
        }
        public virtual TResult CaseAItalicHighlightStyle(AItalicHighlightStyle node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ABoldHighlightStyle node, T1 arg1, T2 arg2)
        {
            return CaseABoldHighlightStyle(node, arg1, arg2);
        }
        public virtual TResult CaseABoldHighlightStyle(ABoldHighlightStyle node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ATextHighlightStyle node, T1 arg1, T2 arg2)
        {
            return CaseATextHighlightStyle(node, arg1, arg2);
        }
        public virtual TResult CaseATextHighlightStyle(ATextHighlightStyle node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ABackgroundHighlightStyle node, T1 arg1, T2 arg2)
        {
            return CaseABackgroundHighlightStyle(node, arg1, arg2);
        }
        public virtual TResult CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(ARgbColor node, T1 arg1, T2 arg2)
        {
            return CaseARgbColor(node, arg1, arg2);
        }
        public virtual TResult CaseARgbColor(ARgbColor node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AHsvColor node, T1 arg1, T2 arg2)
        {
            return CaseAHsvColor(node, arg1, arg2);
        }
        public virtual TResult CaseAHsvColor(AHsvColor node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(AHexColor node, T1 arg1, T2 arg2)
        {
            return CaseAHexColor(node, arg1, arg2);
        }
        public virtual TResult CaseAHexColor(AHexColor node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TPackagename node, T1 arg1, T2 arg2)
        {
            return CaseTPackagename(node, arg1, arg2);
        }
        public virtual TResult CaseTPackagename(TPackagename node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TPackagetoken node, T1 arg1, T2 arg2)
        {
            return CaseTPackagetoken(node, arg1, arg2);
        }
        public virtual TResult CaseTPackagetoken(TPackagetoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TStatestoken node, T1 arg1, T2 arg2)
        {
            return CaseTStatestoken(node, arg1, arg2);
        }
        public virtual TResult CaseTStatestoken(TStatestoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(THelperstoken node, T1 arg1, T2 arg2)
        {
            return CaseTHelperstoken(node, arg1, arg2);
        }
        public virtual TResult CaseTHelperstoken(THelperstoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TTokenstoken node, T1 arg1, T2 arg2)
        {
            return CaseTTokenstoken(node, arg1, arg2);
        }
        public virtual TResult CaseTTokenstoken(TTokenstoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TIgnoredtoken node, T1 arg1, T2 arg2)
        {
            return CaseTIgnoredtoken(node, arg1, arg2);
        }
        public virtual TResult CaseTIgnoredtoken(TIgnoredtoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TProductionstoken node, T1 arg1, T2 arg2)
        {
            return CaseTProductionstoken(node, arg1, arg2);
        }
        public virtual TResult CaseTProductionstoken(TProductionstoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TAsttoken node, T1 arg1, T2 arg2)
        {
            return CaseTAsttoken(node, arg1, arg2);
        }
        public virtual TResult CaseTAsttoken(TAsttoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(THighlighttoken node, T1 arg1, T2 arg2)
        {
            return CaseTHighlighttoken(node, arg1, arg2);
        }
        public virtual TResult CaseTHighlighttoken(THighlighttoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TNew node, T1 arg1, T2 arg2)
        {
            return CaseTNew(node, arg1, arg2);
        }
        public virtual TResult CaseTNew(TNew node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TNull node, T1 arg1, T2 arg2)
        {
            return CaseTNull(node, arg1, arg2);
        }
        public virtual TResult CaseTNull(TNull node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TTokenSpecifier node, T1 arg1, T2 arg2)
        {
            return CaseTTokenSpecifier(node, arg1, arg2);
        }
        public virtual TResult CaseTTokenSpecifier(TTokenSpecifier node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TProductionSpecifier node, T1 arg1, T2 arg2)
        {
            return CaseTProductionSpecifier(node, arg1, arg2);
        }
        public virtual TResult CaseTProductionSpecifier(TProductionSpecifier node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TDot node, T1 arg1, T2 arg2)
        {
            return CaseTDot(node, arg1, arg2);
        }
        public virtual TResult CaseTDot(TDot node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TDDot node, T1 arg1, T2 arg2)
        {
            return CaseTDDot(node, arg1, arg2);
        }
        public virtual TResult CaseTDDot(TDDot node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TSemicolon node, T1 arg1, T2 arg2)
        {
            return CaseTSemicolon(node, arg1, arg2);
        }
        public virtual TResult CaseTSemicolon(TSemicolon node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TEqual node, T1 arg1, T2 arg2)
        {
            return CaseTEqual(node, arg1, arg2);
        }
        public virtual TResult CaseTEqual(TEqual node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TLBkt node, T1 arg1, T2 arg2)
        {
            return CaseTLBkt(node, arg1, arg2);
        }
        public virtual TResult CaseTLBkt(TLBkt node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TRBkt node, T1 arg1, T2 arg2)
        {
            return CaseTRBkt(node, arg1, arg2);
        }
        public virtual TResult CaseTRBkt(TRBkt node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TLPar node, T1 arg1, T2 arg2)
        {
            return CaseTLPar(node, arg1, arg2);
        }
        public virtual TResult CaseTLPar(TLPar node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TRPar node, T1 arg1, T2 arg2)
        {
            return CaseTRPar(node, arg1, arg2);
        }
        public virtual TResult CaseTRPar(TRPar node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TLBrace node, T1 arg1, T2 arg2)
        {
            return CaseTLBrace(node, arg1, arg2);
        }
        public virtual TResult CaseTLBrace(TLBrace node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TRBrace node, T1 arg1, T2 arg2)
        {
            return CaseTRBrace(node, arg1, arg2);
        }
        public virtual TResult CaseTRBrace(TRBrace node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TPlus node, T1 arg1, T2 arg2)
        {
            return CaseTPlus(node, arg1, arg2);
        }
        public virtual TResult CaseTPlus(TPlus node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TMinus node, T1 arg1, T2 arg2)
        {
            return CaseTMinus(node, arg1, arg2);
        }
        public virtual TResult CaseTMinus(TMinus node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TQMark node, T1 arg1, T2 arg2)
        {
            return CaseTQMark(node, arg1, arg2);
        }
        public virtual TResult CaseTQMark(TQMark node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TStar node, T1 arg1, T2 arg2)
        {
            return CaseTStar(node, arg1, arg2);
        }
        public virtual TResult CaseTStar(TStar node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TPipe node, T1 arg1, T2 arg2)
        {
            return CaseTPipe(node, arg1, arg2);
        }
        public virtual TResult CaseTPipe(TPipe node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TComma node, T1 arg1, T2 arg2)
        {
            return CaseTComma(node, arg1, arg2);
        }
        public virtual TResult CaseTComma(TComma node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TSlash node, T1 arg1, T2 arg2)
        {
            return CaseTSlash(node, arg1, arg2);
        }
        public virtual TResult CaseTSlash(TSlash node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TArrow node, T1 arg1, T2 arg2)
        {
            return CaseTArrow(node, arg1, arg2);
        }
        public virtual TResult CaseTArrow(TArrow node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TColon node, T1 arg1, T2 arg2)
        {
            return CaseTColon(node, arg1, arg2);
        }
        public virtual TResult CaseTColon(TColon node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TIdentifier node, T1 arg1, T2 arg2)
        {
            return CaseTIdentifier(node, arg1, arg2);
        }
        public virtual TResult CaseTIdentifier(TIdentifier node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TCharacter node, T1 arg1, T2 arg2)
        {
            return CaseTCharacter(node, arg1, arg2);
        }
        public virtual TResult CaseTCharacter(TCharacter node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TDecChar node, T1 arg1, T2 arg2)
        {
            return CaseTDecChar(node, arg1, arg2);
        }
        public virtual TResult CaseTDecChar(TDecChar node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(THexChar node, T1 arg1, T2 arg2)
        {
            return CaseTHexChar(node, arg1, arg2);
        }
        public virtual TResult CaseTHexChar(THexChar node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TString node, T1 arg1, T2 arg2)
        {
            return CaseTString(node, arg1, arg2);
        }
        public virtual TResult CaseTString(TString node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TBlank node, T1 arg1, T2 arg2)
        {
            return CaseTBlank(node, arg1, arg2);
        }
        public virtual TResult CaseTBlank(TBlank node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TComment node, T1 arg1, T2 arg2)
        {
            return CaseTComment(node, arg1, arg2);
        }
        public virtual TResult CaseTComment(TComment node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TItalic node, T1 arg1, T2 arg2)
        {
            return CaseTItalic(node, arg1, arg2);
        }
        public virtual TResult CaseTItalic(TItalic node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TBold node, T1 arg1, T2 arg2)
        {
            return CaseTBold(node, arg1, arg2);
        }
        public virtual TResult CaseTBold(TBold node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TText node, T1 arg1, T2 arg2)
        {
            return CaseTText(node, arg1, arg2);
        }
        public virtual TResult CaseTText(TText node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TBackground node, T1 arg1, T2 arg2)
        {
            return CaseTBackground(node, arg1, arg2);
        }
        public virtual TResult CaseTBackground(TBackground node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(TRgb node, T1 arg1, T2 arg2)
        {
            return CaseTRgb(node, arg1, arg2);
        }
        public virtual TResult CaseTRgb(TRgb node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(THsv node, T1 arg1, T2 arg2)
        {
            return CaseTHsv(node, arg1, arg2);
        }
        public virtual TResult CaseTHsv(THsv node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public TResult Visit(THexColor node, T1 arg1, T2 arg2)
        {
            return CaseTHexColor(node, arg1, arg2);
        }
        public virtual TResult CaseTHexColor(THexColor node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
    }
    public class ReturnAnalysisAdapter<T1, T2, T3, TResult> : ReturnAdapter<T1, T2, T3, TResult, PGrammar>
    {
        public override TResult Visit(Node node, T1 arg1, T2 arg2, T3 arg3)
        {
            return Visit((dynamic)node, arg1, arg2, arg3);
        }
        
        public TResult Visit(AGrammar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAGrammar(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAGrammar(AGrammar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(APackage node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAPackage(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAPackage(APackage node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AHelpers node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHelpers(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAHelpers(AHelpers node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AHelper node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHelper(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAHelper(AHelper node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ATokens node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATokens(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseATokens(ATokens node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AToken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAToken(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAToken(AToken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ATokenlookahead node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATokenlookahead(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseATokenlookahead(ATokenlookahead node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ARegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseARegex(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseARegex(ARegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ARegexOrpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseARegexOrpart(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseARegexOrpart(ARegexOrpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ACharRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseACharRegexpart(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseACharRegexpart(ACharRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ADecRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseADecRegexpart(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseADecRegexpart(ADecRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AHexRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHexRegexpart(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAHexRegexpart(AHexRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AUnarystarRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAUnarystarRegexpart(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAUnarystarRegexpart(AUnarystarRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AUnaryquestionRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAUnaryquestionRegexpart(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAUnaryquestionRegexpart(AUnaryquestionRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AUnaryplusRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAUnaryplusRegexpart(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAUnaryplusRegexpart(AUnaryplusRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ABinaryplusRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseABinaryplusRegexpart(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseABinaryplusRegexpart(ABinaryplusRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ABinaryminusRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseABinaryminusRegexpart(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseABinaryminusRegexpart(ABinaryminusRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AIntervalRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAIntervalRegexpart(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAIntervalRegexpart(AIntervalRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AStringRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAStringRegexpart(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAStringRegexpart(AStringRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AIdentifierRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAIdentifierRegexpart(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAIdentifierRegexpart(AIdentifierRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AParenthesisRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAParenthesisRegexpart(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAParenthesisRegexpart(AParenthesisRegexpart node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AStates node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAStates(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAStates(AStates node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AIgnoredtokens node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAIgnoredtokens(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAIgnoredtokens(AIgnoredtokens node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AIdentifierList node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAIdentifierList(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAIdentifierList(AIdentifierList node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ATokenstateList node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATokenstateList(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseATokenstateList(ATokenstateList node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ATranslationList node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATranslationList(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseATranslationList(ATranslationList node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AStyleList node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAStyleList(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAStyleList(AStyleList node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AIdentifierListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAIdentifierListitem(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAIdentifierListitem(AIdentifierListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ATokenstateListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATokenstateListitem(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseATokenstateListitem(ATokenstateListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ATokenstatetransitionListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATokenstatetransitionListitem(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ATranslationListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATranslationListitem(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseATranslationListitem(ATranslationListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AStyleListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAStyleListitem(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAStyleListitem(AStyleListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AProductions node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAProductions(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAProductions(AProductions node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AAstproductions node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAAstproductions(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAAstproductions(AAstproductions node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AProduction node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAProduction(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAProduction(AProduction node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ACleanProdtranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseACleanProdtranslation(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseACleanProdtranslation(ACleanProdtranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AStarProdtranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAStarProdtranslation(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAStarProdtranslation(AStarProdtranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(APlusProdtranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAPlusProdtranslation(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAPlusProdtranslation(APlusProdtranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AQuestionProdtranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAQuestionProdtranslation(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAQuestionProdtranslation(AQuestionProdtranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AFullTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAFullTranslation(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAFullTranslation(AFullTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ANewTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseANewTranslation(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseANewTranslation(ANewTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ANewalternativeTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseANewalternativeTranslation(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseANewalternativeTranslation(ANewalternativeTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AListTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAListTranslation(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAListTranslation(AListTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ANullTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseANullTranslation(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseANullTranslation(ANullTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AIdTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAIdTranslation(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAIdTranslation(AIdTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AIddotidTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAIddotidTranslation(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAIddotidTranslation(AIddotidTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AProductionrule node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAProductionrule(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAProductionrule(AProductionrule node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AAlternative node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAAlternative(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAAlternative(AAlternative node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AAlternativename node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAAlternativename(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAAlternativename(AAlternativename node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AElements node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAElements(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAElements(AElements node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ASimpleElement node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseASimpleElement(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseASimpleElement(ASimpleElement node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AStarElement node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAStarElement(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAStarElement(AStarElement node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AQuestionElement node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAQuestionElement(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAQuestionElement(AQuestionElement node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(APlusElement node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAPlusElement(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAPlusElement(APlusElement node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AElementname node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAElementname(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAElementname(AElementname node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ACleanElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseACleanElementid(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseACleanElementid(ACleanElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ATokenElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATokenElementid(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseATokenElementid(ATokenElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AProductionElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAProductionElementid(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAProductionElementid(AProductionElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AHighlightrules node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHighlightrules(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAHighlightrules(AHighlightrules node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AHighlightrule node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHighlightrule(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAHighlightrule(AHighlightrule node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AItalicHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAItalicHighlightStyle(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAItalicHighlightStyle(AItalicHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ABoldHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseABoldHighlightStyle(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseABoldHighlightStyle(ABoldHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ATextHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATextHighlightStyle(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseATextHighlightStyle(ATextHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ABackgroundHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseABackgroundHighlightStyle(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(ARgbColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseARgbColor(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseARgbColor(ARgbColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AHsvColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHsvColor(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAHsvColor(AHsvColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(AHexColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHexColor(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseAHexColor(AHexColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TPackagename node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTPackagename(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTPackagename(TPackagename node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TPackagetoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTPackagetoken(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTPackagetoken(TPackagetoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TStatestoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTStatestoken(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTStatestoken(TStatestoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(THelperstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTHelperstoken(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTHelperstoken(THelperstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TTokenstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTTokenstoken(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTTokenstoken(TTokenstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TIgnoredtoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTIgnoredtoken(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTIgnoredtoken(TIgnoredtoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TProductionstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTProductionstoken(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTProductionstoken(TProductionstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TAsttoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTAsttoken(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTAsttoken(TAsttoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(THighlighttoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTHighlighttoken(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTHighlighttoken(THighlighttoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TNew node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTNew(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTNew(TNew node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TNull node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTNull(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTNull(TNull node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TTokenSpecifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTTokenSpecifier(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTTokenSpecifier(TTokenSpecifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TProductionSpecifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTProductionSpecifier(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTProductionSpecifier(TProductionSpecifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TDot node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTDot(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTDot(TDot node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TDDot node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTDDot(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTDDot(TDDot node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TSemicolon node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTSemicolon(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTSemicolon(TSemicolon node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TEqual node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTEqual(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTEqual(TEqual node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TLBkt node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTLBkt(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTLBkt(TLBkt node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TRBkt node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTRBkt(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTRBkt(TRBkt node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TLPar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTLPar(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTLPar(TLPar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TRPar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTRPar(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTRPar(TRPar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TLBrace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTLBrace(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTLBrace(TLBrace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TRBrace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTRBrace(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTRBrace(TRBrace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TPlus node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTPlus(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTPlus(TPlus node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TMinus node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTMinus(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTMinus(TMinus node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TQMark node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTQMark(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTQMark(TQMark node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TStar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTStar(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTStar(TStar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TPipe node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTPipe(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTPipe(TPipe node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TComma node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTComma(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTComma(TComma node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TSlash node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTSlash(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTSlash(TSlash node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TArrow node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTArrow(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTArrow(TArrow node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TColon node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTColon(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTColon(TColon node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TIdentifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTIdentifier(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTIdentifier(TIdentifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TCharacter node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTCharacter(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTCharacter(TCharacter node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TDecChar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTDecChar(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTDecChar(TDecChar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(THexChar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTHexChar(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTHexChar(THexChar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TString node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTString(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTString(TString node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TBlank node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTBlank(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTBlank(TBlank node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TComment node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTComment(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTComment(TComment node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TItalic node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTItalic(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTItalic(TItalic node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TBold node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTBold(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTBold(TBold node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TText node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTText(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTText(TText node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TBackground node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTBackground(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTBackground(TBackground node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(TRgb node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTRgb(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTRgb(TRgb node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(THsv node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTHsv(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTHsv(THsv node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public TResult Visit(THexColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTHexColor(node, arg1, arg2, arg3);
        }
        public virtual TResult CaseTHexColor(THexColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
    }
    
    #endregion
}
