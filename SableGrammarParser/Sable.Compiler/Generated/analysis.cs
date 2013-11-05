using System;
using System.Collections.Generic;
using Sable.Tools.Analysis;
using Sable.Tools.Nodes;
using Sable.Compiler.Nodes;

namespace Sable.Compiler.Analysis
{
    public class AnalysisAdapter : AnalysisAdapter<object>
    {
    }
    
    public class AnalysisAdapter<TValue> : Adapter<TValue, PGrammar>
    {
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
    }
    
    public class ReturnAnalysisAdapter : ReturnAnalysisAdapter<object>
    {
    }
    
    public class ReturnAnalysisAdapter<TValue> : ReturnAdapter<TValue, PGrammar>
    {
        public TValue Visit(AGrammar node, TValue arg)
        {
            return CaseAGrammar(node, arg);
        }
        public virtual TValue CaseAGrammar(AGrammar node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(APackage node, TValue arg)
        {
            return CaseAPackage(node, arg);
        }
        public virtual TValue CaseAPackage(APackage node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AHelpers node, TValue arg)
        {
            return CaseAHelpers(node, arg);
        }
        public virtual TValue CaseAHelpers(AHelpers node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AHelper node, TValue arg)
        {
            return CaseAHelper(node, arg);
        }
        public virtual TValue CaseAHelper(AHelper node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ATokens node, TValue arg)
        {
            return CaseATokens(node, arg);
        }
        public virtual TValue CaseATokens(ATokens node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AToken node, TValue arg)
        {
            return CaseAToken(node, arg);
        }
        public virtual TValue CaseAToken(AToken node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ATokenlookahead node, TValue arg)
        {
            return CaseATokenlookahead(node, arg);
        }
        public virtual TValue CaseATokenlookahead(ATokenlookahead node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ARegex node, TValue arg)
        {
            return CaseARegex(node, arg);
        }
        public virtual TValue CaseARegex(ARegex node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ARegexOrpart node, TValue arg)
        {
            return CaseARegexOrpart(node, arg);
        }
        public virtual TValue CaseARegexOrpart(ARegexOrpart node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ACharRegexpart node, TValue arg)
        {
            return CaseACharRegexpart(node, arg);
        }
        public virtual TValue CaseACharRegexpart(ACharRegexpart node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ADecRegexpart node, TValue arg)
        {
            return CaseADecRegexpart(node, arg);
        }
        public virtual TValue CaseADecRegexpart(ADecRegexpart node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AHexRegexpart node, TValue arg)
        {
            return CaseAHexRegexpart(node, arg);
        }
        public virtual TValue CaseAHexRegexpart(AHexRegexpart node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AUnarystarRegexpart node, TValue arg)
        {
            return CaseAUnarystarRegexpart(node, arg);
        }
        public virtual TValue CaseAUnarystarRegexpart(AUnarystarRegexpart node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AUnaryquestionRegexpart node, TValue arg)
        {
            return CaseAUnaryquestionRegexpart(node, arg);
        }
        public virtual TValue CaseAUnaryquestionRegexpart(AUnaryquestionRegexpart node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AUnaryplusRegexpart node, TValue arg)
        {
            return CaseAUnaryplusRegexpart(node, arg);
        }
        public virtual TValue CaseAUnaryplusRegexpart(AUnaryplusRegexpart node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ABinaryplusRegexpart node, TValue arg)
        {
            return CaseABinaryplusRegexpart(node, arg);
        }
        public virtual TValue CaseABinaryplusRegexpart(ABinaryplusRegexpart node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ABinaryminusRegexpart node, TValue arg)
        {
            return CaseABinaryminusRegexpart(node, arg);
        }
        public virtual TValue CaseABinaryminusRegexpart(ABinaryminusRegexpart node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AIntervalRegexpart node, TValue arg)
        {
            return CaseAIntervalRegexpart(node, arg);
        }
        public virtual TValue CaseAIntervalRegexpart(AIntervalRegexpart node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AStringRegexpart node, TValue arg)
        {
            return CaseAStringRegexpart(node, arg);
        }
        public virtual TValue CaseAStringRegexpart(AStringRegexpart node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AIdentifierRegexpart node, TValue arg)
        {
            return CaseAIdentifierRegexpart(node, arg);
        }
        public virtual TValue CaseAIdentifierRegexpart(AIdentifierRegexpart node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AParenthesisRegexpart node, TValue arg)
        {
            return CaseAParenthesisRegexpart(node, arg);
        }
        public virtual TValue CaseAParenthesisRegexpart(AParenthesisRegexpart node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AStates node, TValue arg)
        {
            return CaseAStates(node, arg);
        }
        public virtual TValue CaseAStates(AStates node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AIgnoredtokens node, TValue arg)
        {
            return CaseAIgnoredtokens(node, arg);
        }
        public virtual TValue CaseAIgnoredtokens(AIgnoredtokens node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AIdentifierList node, TValue arg)
        {
            return CaseAIdentifierList(node, arg);
        }
        public virtual TValue CaseAIdentifierList(AIdentifierList node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ATokenstateList node, TValue arg)
        {
            return CaseATokenstateList(node, arg);
        }
        public virtual TValue CaseATokenstateList(ATokenstateList node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ATranslationList node, TValue arg)
        {
            return CaseATranslationList(node, arg);
        }
        public virtual TValue CaseATranslationList(ATranslationList node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AIdentifierListitem node, TValue arg)
        {
            return CaseAIdentifierListitem(node, arg);
        }
        public virtual TValue CaseAIdentifierListitem(AIdentifierListitem node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ATokenstateListitem node, TValue arg)
        {
            return CaseATokenstateListitem(node, arg);
        }
        public virtual TValue CaseATokenstateListitem(ATokenstateListitem node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ATokenstatetransitionListitem node, TValue arg)
        {
            return CaseATokenstatetransitionListitem(node, arg);
        }
        public virtual TValue CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ATranslationListitem node, TValue arg)
        {
            return CaseATranslationListitem(node, arg);
        }
        public virtual TValue CaseATranslationListitem(ATranslationListitem node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AProductions node, TValue arg)
        {
            return CaseAProductions(node, arg);
        }
        public virtual TValue CaseAProductions(AProductions node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AAstproductions node, TValue arg)
        {
            return CaseAAstproductions(node, arg);
        }
        public virtual TValue CaseAAstproductions(AAstproductions node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AProduction node, TValue arg)
        {
            return CaseAProduction(node, arg);
        }
        public virtual TValue CaseAProduction(AProduction node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ACleanProdtranslation node, TValue arg)
        {
            return CaseACleanProdtranslation(node, arg);
        }
        public virtual TValue CaseACleanProdtranslation(ACleanProdtranslation node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AStarProdtranslation node, TValue arg)
        {
            return CaseAStarProdtranslation(node, arg);
        }
        public virtual TValue CaseAStarProdtranslation(AStarProdtranslation node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(APlusProdtranslation node, TValue arg)
        {
            return CaseAPlusProdtranslation(node, arg);
        }
        public virtual TValue CaseAPlusProdtranslation(APlusProdtranslation node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AQuestionProdtranslation node, TValue arg)
        {
            return CaseAQuestionProdtranslation(node, arg);
        }
        public virtual TValue CaseAQuestionProdtranslation(AQuestionProdtranslation node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AFullTranslation node, TValue arg)
        {
            return CaseAFullTranslation(node, arg);
        }
        public virtual TValue CaseAFullTranslation(AFullTranslation node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ANewTranslation node, TValue arg)
        {
            return CaseANewTranslation(node, arg);
        }
        public virtual TValue CaseANewTranslation(ANewTranslation node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ANewalternativeTranslation node, TValue arg)
        {
            return CaseANewalternativeTranslation(node, arg);
        }
        public virtual TValue CaseANewalternativeTranslation(ANewalternativeTranslation node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AListTranslation node, TValue arg)
        {
            return CaseAListTranslation(node, arg);
        }
        public virtual TValue CaseAListTranslation(AListTranslation node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ANullTranslation node, TValue arg)
        {
            return CaseANullTranslation(node, arg);
        }
        public virtual TValue CaseANullTranslation(ANullTranslation node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AIdTranslation node, TValue arg)
        {
            return CaseAIdTranslation(node, arg);
        }
        public virtual TValue CaseAIdTranslation(AIdTranslation node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AIddotidTranslation node, TValue arg)
        {
            return CaseAIddotidTranslation(node, arg);
        }
        public virtual TValue CaseAIddotidTranslation(AIddotidTranslation node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AProductionrule node, TValue arg)
        {
            return CaseAProductionrule(node, arg);
        }
        public virtual TValue CaseAProductionrule(AProductionrule node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AAlternative node, TValue arg)
        {
            return CaseAAlternative(node, arg);
        }
        public virtual TValue CaseAAlternative(AAlternative node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AAlternativename node, TValue arg)
        {
            return CaseAAlternativename(node, arg);
        }
        public virtual TValue CaseAAlternativename(AAlternativename node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AElements node, TValue arg)
        {
            return CaseAElements(node, arg);
        }
        public virtual TValue CaseAElements(AElements node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ASimpleElement node, TValue arg)
        {
            return CaseASimpleElement(node, arg);
        }
        public virtual TValue CaseASimpleElement(ASimpleElement node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AStarElement node, TValue arg)
        {
            return CaseAStarElement(node, arg);
        }
        public virtual TValue CaseAStarElement(AStarElement node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AQuestionElement node, TValue arg)
        {
            return CaseAQuestionElement(node, arg);
        }
        public virtual TValue CaseAQuestionElement(AQuestionElement node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(APlusElement node, TValue arg)
        {
            return CaseAPlusElement(node, arg);
        }
        public virtual TValue CaseAPlusElement(APlusElement node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AElementname node, TValue arg)
        {
            return CaseAElementname(node, arg);
        }
        public virtual TValue CaseAElementname(AElementname node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ACleanElementid node, TValue arg)
        {
            return CaseACleanElementid(node, arg);
        }
        public virtual TValue CaseACleanElementid(ACleanElementid node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(ATokenElementid node, TValue arg)
        {
            return CaseATokenElementid(node, arg);
        }
        public virtual TValue CaseATokenElementid(ATokenElementid node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(AProductionElementid node, TValue arg)
        {
            return CaseAProductionElementid(node, arg);
        }
        public virtual TValue CaseAProductionElementid(AProductionElementid node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        
        public TValue Visit(TPackagename node, TValue arg)
        {
            return CaseTPackagename(node, arg);
        }
        public virtual TValue CaseTPackagename(TPackagename node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TPackagetoken node, TValue arg)
        {
            return CaseTPackagetoken(node, arg);
        }
        public virtual TValue CaseTPackagetoken(TPackagetoken node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TStatestoken node, TValue arg)
        {
            return CaseTStatestoken(node, arg);
        }
        public virtual TValue CaseTStatestoken(TStatestoken node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(THelperstoken node, TValue arg)
        {
            return CaseTHelperstoken(node, arg);
        }
        public virtual TValue CaseTHelperstoken(THelperstoken node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TTokenstoken node, TValue arg)
        {
            return CaseTTokenstoken(node, arg);
        }
        public virtual TValue CaseTTokenstoken(TTokenstoken node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TIgnoredtoken node, TValue arg)
        {
            return CaseTIgnoredtoken(node, arg);
        }
        public virtual TValue CaseTIgnoredtoken(TIgnoredtoken node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TProductionstoken node, TValue arg)
        {
            return CaseTProductionstoken(node, arg);
        }
        public virtual TValue CaseTProductionstoken(TProductionstoken node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TAsttoken node, TValue arg)
        {
            return CaseTAsttoken(node, arg);
        }
        public virtual TValue CaseTAsttoken(TAsttoken node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TNew node, TValue arg)
        {
            return CaseTNew(node, arg);
        }
        public virtual TValue CaseTNew(TNew node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TNull node, TValue arg)
        {
            return CaseTNull(node, arg);
        }
        public virtual TValue CaseTNull(TNull node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TTokenSpecifier node, TValue arg)
        {
            return CaseTTokenSpecifier(node, arg);
        }
        public virtual TValue CaseTTokenSpecifier(TTokenSpecifier node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TProductionSpecifier node, TValue arg)
        {
            return CaseTProductionSpecifier(node, arg);
        }
        public virtual TValue CaseTProductionSpecifier(TProductionSpecifier node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TDot node, TValue arg)
        {
            return CaseTDot(node, arg);
        }
        public virtual TValue CaseTDot(TDot node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TDDot node, TValue arg)
        {
            return CaseTDDot(node, arg);
        }
        public virtual TValue CaseTDDot(TDDot node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TSemicolon node, TValue arg)
        {
            return CaseTSemicolon(node, arg);
        }
        public virtual TValue CaseTSemicolon(TSemicolon node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TEqual node, TValue arg)
        {
            return CaseTEqual(node, arg);
        }
        public virtual TValue CaseTEqual(TEqual node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TLBkt node, TValue arg)
        {
            return CaseTLBkt(node, arg);
        }
        public virtual TValue CaseTLBkt(TLBkt node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TRBkt node, TValue arg)
        {
            return CaseTRBkt(node, arg);
        }
        public virtual TValue CaseTRBkt(TRBkt node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TLPar node, TValue arg)
        {
            return CaseTLPar(node, arg);
        }
        public virtual TValue CaseTLPar(TLPar node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TRPar node, TValue arg)
        {
            return CaseTRPar(node, arg);
        }
        public virtual TValue CaseTRPar(TRPar node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TLBrace node, TValue arg)
        {
            return CaseTLBrace(node, arg);
        }
        public virtual TValue CaseTLBrace(TLBrace node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TRBrace node, TValue arg)
        {
            return CaseTRBrace(node, arg);
        }
        public virtual TValue CaseTRBrace(TRBrace node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TPlus node, TValue arg)
        {
            return CaseTPlus(node, arg);
        }
        public virtual TValue CaseTPlus(TPlus node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TMinus node, TValue arg)
        {
            return CaseTMinus(node, arg);
        }
        public virtual TValue CaseTMinus(TMinus node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TQMark node, TValue arg)
        {
            return CaseTQMark(node, arg);
        }
        public virtual TValue CaseTQMark(TQMark node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TStar node, TValue arg)
        {
            return CaseTStar(node, arg);
        }
        public virtual TValue CaseTStar(TStar node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TPipe node, TValue arg)
        {
            return CaseTPipe(node, arg);
        }
        public virtual TValue CaseTPipe(TPipe node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TComma node, TValue arg)
        {
            return CaseTComma(node, arg);
        }
        public virtual TValue CaseTComma(TComma node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TSlash node, TValue arg)
        {
            return CaseTSlash(node, arg);
        }
        public virtual TValue CaseTSlash(TSlash node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TArrow node, TValue arg)
        {
            return CaseTArrow(node, arg);
        }
        public virtual TValue CaseTArrow(TArrow node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TColon node, TValue arg)
        {
            return CaseTColon(node, arg);
        }
        public virtual TValue CaseTColon(TColon node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TIdentifier node, TValue arg)
        {
            return CaseTIdentifier(node, arg);
        }
        public virtual TValue CaseTIdentifier(TIdentifier node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TCharacter node, TValue arg)
        {
            return CaseTCharacter(node, arg);
        }
        public virtual TValue CaseTCharacter(TCharacter node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TDecChar node, TValue arg)
        {
            return CaseTDecChar(node, arg);
        }
        public virtual TValue CaseTDecChar(TDecChar node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(THexChar node, TValue arg)
        {
            return CaseTHexChar(node, arg);
        }
        public virtual TValue CaseTHexChar(THexChar node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TString node, TValue arg)
        {
            return CaseTString(node, arg);
        }
        public virtual TValue CaseTString(TString node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TBlank node, TValue arg)
        {
            return CaseTBlank(node, arg);
        }
        public virtual TValue CaseTBlank(TBlank node, TValue arg)
        {
            return DefaultCase(node, arg);
        }
        public TValue Visit(TComment node, TValue arg)
        {
            return CaseTComment(node, arg);
        }
        public virtual TValue CaseTComment(TComment node, TValue arg)
        {
            return DefaultCase(node, arg);
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
            
            if(node.HasPackage)
                Visit((dynamic)node.Package);
            if(node.HasHelpers)
                Visit((dynamic)node.Helpers);
            if(node.HasStates)
                Visit((dynamic)node.States);
            if(node.HasTokens)
                Visit((dynamic)node.Tokens);
            if(node.HasIgnoredtokens)
                Visit((dynamic)node.Ignoredtokens);
            if(node.HasProductions)
                Visit((dynamic)node.Productions);
            if(node.HasAstproductions)
                Visit((dynamic)node.Astproductions);
            
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
                for(int i = 0; i < temp.Length; i ++)
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
                for(int i = 0; i < temp.Length; i ++)
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
            
            if(node.HasStatelist)
                Visit((dynamic)node.Statelist);
            Visit(node.Identifier);
            Visit(node.Equal);
            Visit((dynamic)node.Regex);
            if(node.HasTokenlookahead)
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
                for(int i = 0; i < temp.Length; i ++)
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
            
            if(node.HasPipe)
                Visit(node.Pipe);
            
            {
                PRegexpart[] temp = new PRegexpart[node.Regexpart.Count];
                node.Regexpart.CopyTo(temp, 0);
                for(int i = 0; i < temp.Length; i ++)
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
                for(int i = 0; i < temp.Length; i ++)
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
                for(int i = 0; i < temp.Length; i ++)
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
                for(int i = 0; i < temp.Length; i ++)
                    Visit((dynamic)temp[i]);
            }
            
            OutATranslationList(node);
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
            
            if(node.HasComma)
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
            
            if(node.HasComma)
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
            
            if(node.HasComma)
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
            
            if(node.HasComma)
                Visit(node.Comma);
            Visit((dynamic)node.Translation);
            
            OutATranslationListitem(node);
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
                for(int i = 0; i < temp.Length; i ++)
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
                for(int i = 0; i < temp.Length; i ++)
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
            if(node.HasProdtranslation)
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
                for(int i = 0; i < temp.Length; i ++)
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
            
            if(node.HasPipe)
                Visit(node.Pipe);
            if(node.HasAlternativename)
                Visit((dynamic)node.Alternativename);
            Visit((dynamic)node.Elements);
            if(node.HasTranslation)
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
                for(int i = 0; i < temp.Length; i ++)
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
            
            if(node.HasElementname)
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
            
            if(node.HasElementname)
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
            
            if(node.HasElementname)
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
            
            if(node.HasElementname)
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
    }
    
    public class DepthFirstReturnAdapter : DepthFirstReturnAdapter<object>
    {
    }
    
    public class DepthFirstReturnAdapter<T> : ReturnAnalysisAdapter<T>
    {
    }
}
