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
    
    public class DepthFirstAdapter : DepthFirstAdapter<object>
    {
    }
    public class DepthFirstAdapter<TValue> : AnalysisAdapter<TValue>
    {
        public override void Visit(Node node)
        {
            Visit((dynamic)node);
        }
        
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
    }
    
    public class ReverseDepthFirstAdapter : ReverseDepthFirstAdapter<object>
    {
    }
    public class ReverseDepthFirstAdapter<TValue> : AnalysisAdapter<TValue>
    {
        public override void Visit(Node node)
        {
            Visit((dynamic)node);
        }
        
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
    }
    
    #endregion
    
    #region Return analysis adapters
    
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
    
    public class DepthFirstReturnAdapter : DepthFirstReturnAdapter<object>
    {
    }
    public class DepthFirstReturnAdapter<TValue> : ReturnAnalysisAdapter<TValue>
    {
        public override TValue Visit(Node node, TValue arg)
        {
            return Visit((dynamic)node, arg);
        }
        
        public virtual TValue InStart(Start<PGrammar> node, TValue arg)
        {
            return arg;
        }
        public virtual TValue OutStart(Start<PGrammar> node, TValue arg)
        {
            return arg;
        }
        public override TValue CaseStart(Start<PGrammar> node, TValue arg)
        {
            arg = InStart(node, arg);
            
            arg = Visit((dynamic)node.Root, arg);
            arg = Visit(node.EOF, arg);
            
            arg = OutStart(node, arg);
            
            return arg;
        }
        
        public virtual TValue DefaultPIn(Node node, TValue arg)
        {
            return arg;
        }
        public virtual TValue DefaultPOut(Node node, TValue arg)
        {
            return arg;
        }
        public virtual TValue DefaultAIn(Node node, TValue arg)
        {
            return arg;
        }
        public virtual TValue DefaultAOut(Node node, TValue arg)
        {
            return arg;
        }
        
        public virtual TValue InPGrammar(PGrammar node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPGrammar(PGrammar node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAGrammar(AGrammar node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAGrammar(AGrammar node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAGrammar(AGrammar node, TValue arg)
        {
            arg = InPGrammar(node, arg);
            arg = InAGrammar(node, arg);
            
            if (node.HasPackage)
                arg = Visit((dynamic)node.Package, arg);
            if (node.HasHelpers)
                arg = Visit((dynamic)node.Helpers, arg);
            if (node.HasStates)
                arg = Visit((dynamic)node.States, arg);
            if (node.HasTokens)
                arg = Visit((dynamic)node.Tokens, arg);
            if (node.HasIgnoredtokens)
                arg = Visit((dynamic)node.Ignoredtokens, arg);
            if (node.HasProductions)
                arg = Visit((dynamic)node.Productions, arg);
            if (node.HasAstproductions)
                arg = Visit((dynamic)node.Astproductions, arg);
            
            arg = OutAGrammar(node, arg);
            arg = OutPGrammar(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPPackage(PPackage node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPPackage(PPackage node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAPackage(APackage node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAPackage(APackage node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAPackage(APackage node, TValue arg)
        {
            arg = InPPackage(node, arg);
            arg = InAPackage(node, arg);
            
            arg = Visit(node.Packagetoken, arg);
            arg = Visit(node.Packagename, arg);
            arg = Visit(node.Semicolon, arg);
            
            arg = OutAPackage(node, arg);
            arg = OutPPackage(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPHelpers(PHelpers node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPHelpers(PHelpers node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAHelpers(AHelpers node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAHelpers(AHelpers node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAHelpers(AHelpers node, TValue arg)
        {
            arg = InPHelpers(node, arg);
            arg = InAHelpers(node, arg);
            
            arg = Visit(node.Helperstoken, arg);
            {
                PHelper[] temp = new PHelper[node.Helpers.Count];
                node.Helpers.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutAHelpers(node, arg);
            arg = OutPHelpers(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPHelper(PHelper node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPHelper(PHelper node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAHelper(AHelper node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAHelper(AHelper node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAHelper(AHelper node, TValue arg)
        {
            arg = InPHelper(node, arg);
            arg = InAHelper(node, arg);
            
            arg = Visit(node.Identifier, arg);
            arg = Visit(node.Equal, arg);
            arg = Visit((dynamic)node.Regex, arg);
            arg = Visit(node.Semicolon, arg);
            
            arg = OutAHelper(node, arg);
            arg = OutPHelper(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPTokens(PTokens node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPTokens(PTokens node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InATokens(ATokens node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATokens(ATokens node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATokens(ATokens node, TValue arg)
        {
            arg = InPTokens(node, arg);
            arg = InATokens(node, arg);
            
            arg = Visit(node.Tokenstoken, arg);
            {
                PToken[] temp = new PToken[node.Tokens.Count];
                node.Tokens.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutATokens(node, arg);
            arg = OutPTokens(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPToken(PToken node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPToken(PToken node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAToken(AToken node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAToken(AToken node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAToken(AToken node, TValue arg)
        {
            arg = InPToken(node, arg);
            arg = InAToken(node, arg);
            
            if (node.HasStatelist)
                arg = Visit((dynamic)node.Statelist, arg);
            arg = Visit(node.Identifier, arg);
            arg = Visit(node.Equal, arg);
            arg = Visit((dynamic)node.Regex, arg);
            if (node.HasTokenlookahead)
                arg = Visit((dynamic)node.Tokenlookahead, arg);
            arg = Visit(node.Semicolon, arg);
            
            arg = OutAToken(node, arg);
            arg = OutPToken(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPTokenlookahead(PTokenlookahead node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPTokenlookahead(PTokenlookahead node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InATokenlookahead(ATokenlookahead node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATokenlookahead(ATokenlookahead node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATokenlookahead(ATokenlookahead node, TValue arg)
        {
            arg = InPTokenlookahead(node, arg);
            arg = InATokenlookahead(node, arg);
            
            arg = Visit(node.Slash, arg);
            arg = Visit((dynamic)node.Regex, arg);
            
            arg = OutATokenlookahead(node, arg);
            arg = OutPTokenlookahead(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPRegex(PRegex node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPRegex(PRegex node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InARegex(ARegex node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutARegex(ARegex node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseARegex(ARegex node, TValue arg)
        {
            arg = InPRegex(node, arg);
            arg = InARegex(node, arg);
            
            {
                POrpart[] temp = new POrpart[node.Parts.Count];
                node.Parts.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutARegex(node, arg);
            arg = OutPRegex(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPOrpart(POrpart node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPOrpart(POrpart node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InARegexOrpart(ARegexOrpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutARegexOrpart(ARegexOrpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseARegexOrpart(ARegexOrpart node, TValue arg)
        {
            arg = InPOrpart(node, arg);
            arg = InARegexOrpart(node, arg);
            
            if (node.HasPipe)
                arg = Visit(node.Pipe, arg);
            {
                PRegexpart[] temp = new PRegexpart[node.Regexpart.Count];
                node.Regexpart.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutARegexOrpart(node, arg);
            arg = OutPOrpart(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPRegexpart(PRegexpart node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPRegexpart(PRegexpart node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InACharRegexpart(ACharRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutACharRegexpart(ACharRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseACharRegexpart(ACharRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InACharRegexpart(node, arg);
            
            arg = Visit(node.Character, arg);
            
            arg = OutACharRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InADecRegexpart(ADecRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutADecRegexpart(ADecRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseADecRegexpart(ADecRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InADecRegexpart(node, arg);
            
            arg = Visit(node.DecChar, arg);
            
            arg = OutADecRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAHexRegexpart(AHexRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAHexRegexpart(AHexRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAHexRegexpart(AHexRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAHexRegexpart(node, arg);
            
            arg = Visit(node.HexChar, arg);
            
            arg = OutAHexRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAUnarystarRegexpart(AUnarystarRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAUnarystarRegexpart(AUnarystarRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAUnarystarRegexpart(AUnarystarRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAUnarystarRegexpart(node, arg);
            
            arg = Visit((dynamic)node.Regexpart, arg);
            arg = Visit(node.Star, arg);
            
            arg = OutAUnarystarRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAUnaryquestionRegexpart(AUnaryquestionRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAUnaryquestionRegexpart(AUnaryquestionRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAUnaryquestionRegexpart(AUnaryquestionRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAUnaryquestionRegexpart(node, arg);
            
            arg = Visit((dynamic)node.Regexpart, arg);
            arg = Visit(node.Question, arg);
            
            arg = OutAUnaryquestionRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAUnaryplusRegexpart(AUnaryplusRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAUnaryplusRegexpart(AUnaryplusRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAUnaryplusRegexpart(AUnaryplusRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAUnaryplusRegexpart(node, arg);
            
            arg = Visit((dynamic)node.Regexpart, arg);
            arg = Visit(node.Plus, arg);
            
            arg = OutAUnaryplusRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InABinaryplusRegexpart(ABinaryplusRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutABinaryplusRegexpart(ABinaryplusRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseABinaryplusRegexpart(ABinaryplusRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InABinaryplusRegexpart(node, arg);
            
            arg = Visit(node.Lpar, arg);
            arg = Visit((dynamic)node.Left, arg);
            arg = Visit(node.Plus, arg);
            arg = Visit((dynamic)node.Right, arg);
            arg = Visit(node.Rpar, arg);
            
            arg = OutABinaryplusRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InABinaryminusRegexpart(ABinaryminusRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutABinaryminusRegexpart(ABinaryminusRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseABinaryminusRegexpart(ABinaryminusRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InABinaryminusRegexpart(node, arg);
            
            arg = Visit(node.Lpar, arg);
            arg = Visit((dynamic)node.Left, arg);
            arg = Visit(node.Minus, arg);
            arg = Visit((dynamic)node.Right, arg);
            arg = Visit(node.Rpar, arg);
            
            arg = OutABinaryminusRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAIntervalRegexpart(AIntervalRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIntervalRegexpart(AIntervalRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIntervalRegexpart(AIntervalRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAIntervalRegexpart(node, arg);
            
            arg = Visit(node.Lpar, arg);
            arg = Visit((dynamic)node.Left, arg);
            arg = Visit(node.Dots, arg);
            arg = Visit((dynamic)node.Right, arg);
            arg = Visit(node.Rpar, arg);
            
            arg = OutAIntervalRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAStringRegexpart(AStringRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAStringRegexpart(AStringRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAStringRegexpart(AStringRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAStringRegexpart(node, arg);
            
            arg = Visit(node.String, arg);
            
            arg = OutAStringRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAIdentifierRegexpart(AIdentifierRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIdentifierRegexpart(AIdentifierRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIdentifierRegexpart(AIdentifierRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAIdentifierRegexpart(node, arg);
            
            arg = Visit(node.Identifier, arg);
            
            arg = OutAIdentifierRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAParenthesisRegexpart(AParenthesisRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAParenthesisRegexpart(AParenthesisRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAParenthesisRegexpart(AParenthesisRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAParenthesisRegexpart(node, arg);
            
            arg = Visit(node.Lpar, arg);
            arg = Visit((dynamic)node.Regex, arg);
            arg = Visit(node.Rpar, arg);
            
            arg = OutAParenthesisRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPStates(PStates node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPStates(PStates node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAStates(AStates node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAStates(AStates node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAStates(AStates node, TValue arg)
        {
            arg = InPStates(node, arg);
            arg = InAStates(node, arg);
            
            arg = Visit(node.Statestoken, arg);
            arg = Visit((dynamic)node.List, arg);
            arg = Visit(node.Semicolon, arg);
            
            arg = OutAStates(node, arg);
            arg = OutPStates(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPIgnoredtokens(PIgnoredtokens node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPIgnoredtokens(PIgnoredtokens node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAIgnoredtokens(AIgnoredtokens node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIgnoredtokens(AIgnoredtokens node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIgnoredtokens(AIgnoredtokens node, TValue arg)
        {
            arg = InPIgnoredtokens(node, arg);
            arg = InAIgnoredtokens(node, arg);
            
            arg = Visit(node.Ignoredtoken, arg);
            arg = Visit(node.Tokenstoken, arg);
            arg = Visit((dynamic)node.List, arg);
            arg = Visit(node.Semicolon, arg);
            
            arg = OutAIgnoredtokens(node, arg);
            arg = OutPIgnoredtokens(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPList(PList node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPList(PList node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAIdentifierList(AIdentifierList node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIdentifierList(AIdentifierList node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIdentifierList(AIdentifierList node, TValue arg)
        {
            arg = InPList(node, arg);
            arg = InAIdentifierList(node, arg);
            
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutAIdentifierList(node, arg);
            arg = OutPList(node, arg);
            
            return arg;
        }
        public virtual TValue InATokenstateList(ATokenstateList node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATokenstateList(ATokenstateList node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATokenstateList(ATokenstateList node, TValue arg)
        {
            arg = InPList(node, arg);
            arg = InATokenstateList(node, arg);
            
            arg = Visit(node.Lpar, arg);
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    arg = Visit((dynamic)temp[i], arg);
            }
            arg = Visit(node.Rpar, arg);
            
            arg = OutATokenstateList(node, arg);
            arg = OutPList(node, arg);
            
            return arg;
        }
        public virtual TValue InATranslationList(ATranslationList node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATranslationList(ATranslationList node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATranslationList(ATranslationList node, TValue arg)
        {
            arg = InPList(node, arg);
            arg = InATranslationList(node, arg);
            
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutATranslationList(node, arg);
            arg = OutPList(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPListitem(PListitem node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPListitem(PListitem node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAIdentifierListitem(AIdentifierListitem node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIdentifierListitem(AIdentifierListitem node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIdentifierListitem(AIdentifierListitem node, TValue arg)
        {
            arg = InPListitem(node, arg);
            arg = InAIdentifierListitem(node, arg);
            
            if (node.HasComma)
                arg = Visit(node.Comma, arg);
            arg = Visit(node.Identifier, arg);
            
            arg = OutAIdentifierListitem(node, arg);
            arg = OutPListitem(node, arg);
            
            return arg;
        }
        public virtual TValue InATokenstateListitem(ATokenstateListitem node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATokenstateListitem(ATokenstateListitem node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATokenstateListitem(ATokenstateListitem node, TValue arg)
        {
            arg = InPListitem(node, arg);
            arg = InATokenstateListitem(node, arg);
            
            if (node.HasComma)
                arg = Visit(node.Comma, arg);
            arg = Visit(node.Identifier, arg);
            
            arg = OutATokenstateListitem(node, arg);
            arg = OutPListitem(node, arg);
            
            return arg;
        }
        public virtual TValue InATokenstatetransitionListitem(ATokenstatetransitionListitem node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATokenstatetransitionListitem(ATokenstatetransitionListitem node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node, TValue arg)
        {
            arg = InPListitem(node, arg);
            arg = InATokenstatetransitionListitem(node, arg);
            
            if (node.HasComma)
                arg = Visit(node.Comma, arg);
            arg = Visit(node.From, arg);
            arg = Visit(node.Arrow, arg);
            arg = Visit(node.To, arg);
            
            arg = OutATokenstatetransitionListitem(node, arg);
            arg = OutPListitem(node, arg);
            
            return arg;
        }
        public virtual TValue InATranslationListitem(ATranslationListitem node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATranslationListitem(ATranslationListitem node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATranslationListitem(ATranslationListitem node, TValue arg)
        {
            arg = InPListitem(node, arg);
            arg = InATranslationListitem(node, arg);
            
            if (node.HasComma)
                arg = Visit(node.Comma, arg);
            arg = Visit((dynamic)node.Translation, arg);
            
            arg = OutATranslationListitem(node, arg);
            arg = OutPListitem(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPProductions(PProductions node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPProductions(PProductions node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAProductions(AProductions node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAProductions(AProductions node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAProductions(AProductions node, TValue arg)
        {
            arg = InPProductions(node, arg);
            arg = InAProductions(node, arg);
            
            arg = Visit(node.Productionstoken, arg);
            {
                PProduction[] temp = new PProduction[node.Productions.Count];
                node.Productions.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutAProductions(node, arg);
            arg = OutPProductions(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPAstproductions(PAstproductions node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPAstproductions(PAstproductions node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAAstproductions(AAstproductions node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAAstproductions(AAstproductions node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAAstproductions(AAstproductions node, TValue arg)
        {
            arg = InPAstproductions(node, arg);
            arg = InAAstproductions(node, arg);
            
            arg = Visit(node.Asttoken, arg);
            {
                PProduction[] temp = new PProduction[node.Productions.Count];
                node.Productions.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutAAstproductions(node, arg);
            arg = OutPAstproductions(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPProduction(PProduction node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPProduction(PProduction node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAProduction(AProduction node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAProduction(AProduction node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAProduction(AProduction node, TValue arg)
        {
            arg = InPProduction(node, arg);
            arg = InAProduction(node, arg);
            
            arg = Visit(node.Identifier, arg);
            if (node.HasProdtranslation)
                arg = Visit((dynamic)node.Prodtranslation, arg);
            arg = Visit(node.Equal, arg);
            arg = Visit((dynamic)node.Productionrule, arg);
            arg = Visit(node.Semicolon, arg);
            
            arg = OutAProduction(node, arg);
            arg = OutPProduction(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPProdtranslation(PProdtranslation node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPProdtranslation(PProdtranslation node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InACleanProdtranslation(ACleanProdtranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutACleanProdtranslation(ACleanProdtranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseACleanProdtranslation(ACleanProdtranslation node, TValue arg)
        {
            arg = InPProdtranslation(node, arg);
            arg = InACleanProdtranslation(node, arg);
            
            arg = Visit(node.Lpar, arg);
            arg = Visit(node.Arrow, arg);
            arg = Visit(node.Identifier, arg);
            arg = Visit(node.Rpar, arg);
            
            arg = OutACleanProdtranslation(node, arg);
            arg = OutPProdtranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InAStarProdtranslation(AStarProdtranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAStarProdtranslation(AStarProdtranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAStarProdtranslation(AStarProdtranslation node, TValue arg)
        {
            arg = InPProdtranslation(node, arg);
            arg = InAStarProdtranslation(node, arg);
            
            arg = Visit(node.Lpar, arg);
            arg = Visit(node.Arrow, arg);
            arg = Visit(node.Identifier, arg);
            arg = Visit(node.Star, arg);
            arg = Visit(node.Rpar, arg);
            
            arg = OutAStarProdtranslation(node, arg);
            arg = OutPProdtranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InAPlusProdtranslation(APlusProdtranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAPlusProdtranslation(APlusProdtranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAPlusProdtranslation(APlusProdtranslation node, TValue arg)
        {
            arg = InPProdtranslation(node, arg);
            arg = InAPlusProdtranslation(node, arg);
            
            arg = Visit(node.Lpar, arg);
            arg = Visit(node.Arrow, arg);
            arg = Visit(node.Identifier, arg);
            arg = Visit(node.Plus, arg);
            arg = Visit(node.Rpar, arg);
            
            arg = OutAPlusProdtranslation(node, arg);
            arg = OutPProdtranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InAQuestionProdtranslation(AQuestionProdtranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAQuestionProdtranslation(AQuestionProdtranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAQuestionProdtranslation(AQuestionProdtranslation node, TValue arg)
        {
            arg = InPProdtranslation(node, arg);
            arg = InAQuestionProdtranslation(node, arg);
            
            arg = Visit(node.Lpar, arg);
            arg = Visit(node.Arrow, arg);
            arg = Visit(node.Identifier, arg);
            arg = Visit(node.QMark, arg);
            arg = Visit(node.Rpar, arg);
            
            arg = OutAQuestionProdtranslation(node, arg);
            arg = OutPProdtranslation(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPTranslation(PTranslation node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPTranslation(PTranslation node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAFullTranslation(AFullTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAFullTranslation(AFullTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAFullTranslation(AFullTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InAFullTranslation(node, arg);
            
            arg = Visit(node.Lpar, arg);
            arg = Visit(node.Arrow, arg);
            arg = Visit((dynamic)node.Translation, arg);
            arg = Visit(node.Rpar, arg);
            
            arg = OutAFullTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InANewTranslation(ANewTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutANewTranslation(ANewTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseANewTranslation(ANewTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InANewTranslation(node, arg);
            
            arg = Visit(node.New, arg);
            arg = Visit(node.Production, arg);
            arg = Visit(node.Lpar, arg);
            arg = Visit((dynamic)node.Arguments, arg);
            arg = Visit(node.Rpar, arg);
            
            arg = OutANewTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InANewalternativeTranslation(ANewalternativeTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutANewalternativeTranslation(ANewalternativeTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseANewalternativeTranslation(ANewalternativeTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InANewalternativeTranslation(node, arg);
            
            arg = Visit(node.New, arg);
            arg = Visit(node.Production, arg);
            arg = Visit(node.Dot, arg);
            arg = Visit(node.Alternative, arg);
            arg = Visit(node.Lpar, arg);
            arg = Visit((dynamic)node.Arguments, arg);
            arg = Visit(node.Rpar, arg);
            
            arg = OutANewalternativeTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InAListTranslation(AListTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAListTranslation(AListTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAListTranslation(AListTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InAListTranslation(node, arg);
            
            arg = Visit(node.Lpar, arg);
            arg = Visit((dynamic)node.Elements, arg);
            arg = Visit(node.Rpar, arg);
            
            arg = OutAListTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InANullTranslation(ANullTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutANullTranslation(ANullTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseANullTranslation(ANullTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InANullTranslation(node, arg);
            
            arg = Visit(node.Null, arg);
            
            arg = OutANullTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InAIdTranslation(AIdTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIdTranslation(AIdTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIdTranslation(AIdTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InAIdTranslation(node, arg);
            
            arg = Visit(node.Identifier, arg);
            
            arg = OutAIdTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InAIddotidTranslation(AIddotidTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIddotidTranslation(AIddotidTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIddotidTranslation(AIddotidTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InAIddotidTranslation(node, arg);
            
            arg = Visit(node.Identifier, arg);
            arg = Visit(node.Dot, arg);
            arg = Visit(node.Production, arg);
            
            arg = OutAIddotidTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPProductionrule(PProductionrule node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPProductionrule(PProductionrule node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAProductionrule(AProductionrule node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAProductionrule(AProductionrule node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAProductionrule(AProductionrule node, TValue arg)
        {
            arg = InPProductionrule(node, arg);
            arg = InAProductionrule(node, arg);
            
            {
                PAlternative[] temp = new PAlternative[node.Alternatives.Count];
                node.Alternatives.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutAProductionrule(node, arg);
            arg = OutPProductionrule(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPAlternative(PAlternative node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPAlternative(PAlternative node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAAlternative(AAlternative node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAAlternative(AAlternative node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAAlternative(AAlternative node, TValue arg)
        {
            arg = InPAlternative(node, arg);
            arg = InAAlternative(node, arg);
            
            if (node.HasPipe)
                arg = Visit(node.Pipe, arg);
            if (node.HasAlternativename)
                arg = Visit((dynamic)node.Alternativename, arg);
            arg = Visit((dynamic)node.Elements, arg);
            if (node.HasTranslation)
                arg = Visit((dynamic)node.Translation, arg);
            
            arg = OutAAlternative(node, arg);
            arg = OutPAlternative(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPAlternativename(PAlternativename node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPAlternativename(PAlternativename node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAAlternativename(AAlternativename node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAAlternativename(AAlternativename node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAAlternativename(AAlternativename node, TValue arg)
        {
            arg = InPAlternativename(node, arg);
            arg = InAAlternativename(node, arg);
            
            arg = Visit(node.Lpar, arg);
            arg = Visit(node.Name, arg);
            arg = Visit(node.Rpar, arg);
            
            arg = OutAAlternativename(node, arg);
            arg = OutPAlternativename(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPElements(PElements node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPElements(PElements node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAElements(AElements node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAElements(AElements node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAElements(AElements node, TValue arg)
        {
            arg = InPElements(node, arg);
            arg = InAElements(node, arg);
            
            {
                PElement[] temp = new PElement[node.Element.Count];
                node.Element.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutAElements(node, arg);
            arg = OutPElements(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPElement(PElement node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPElement(PElement node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InASimpleElement(ASimpleElement node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutASimpleElement(ASimpleElement node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseASimpleElement(ASimpleElement node, TValue arg)
        {
            arg = InPElement(node, arg);
            arg = InASimpleElement(node, arg);
            
            if (node.HasElementname)
                arg = Visit((dynamic)node.Elementname, arg);
            arg = Visit((dynamic)node.Elementid, arg);
            
            arg = OutASimpleElement(node, arg);
            arg = OutPElement(node, arg);
            
            return arg;
        }
        public virtual TValue InAStarElement(AStarElement node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAStarElement(AStarElement node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAStarElement(AStarElement node, TValue arg)
        {
            arg = InPElement(node, arg);
            arg = InAStarElement(node, arg);
            
            if (node.HasElementname)
                arg = Visit((dynamic)node.Elementname, arg);
            arg = Visit((dynamic)node.Elementid, arg);
            arg = Visit(node.Star, arg);
            
            arg = OutAStarElement(node, arg);
            arg = OutPElement(node, arg);
            
            return arg;
        }
        public virtual TValue InAQuestionElement(AQuestionElement node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAQuestionElement(AQuestionElement node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAQuestionElement(AQuestionElement node, TValue arg)
        {
            arg = InPElement(node, arg);
            arg = InAQuestionElement(node, arg);
            
            if (node.HasElementname)
                arg = Visit((dynamic)node.Elementname, arg);
            arg = Visit((dynamic)node.Elementid, arg);
            arg = Visit(node.QMark, arg);
            
            arg = OutAQuestionElement(node, arg);
            arg = OutPElement(node, arg);
            
            return arg;
        }
        public virtual TValue InAPlusElement(APlusElement node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAPlusElement(APlusElement node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAPlusElement(APlusElement node, TValue arg)
        {
            arg = InPElement(node, arg);
            arg = InAPlusElement(node, arg);
            
            if (node.HasElementname)
                arg = Visit((dynamic)node.Elementname, arg);
            arg = Visit((dynamic)node.Elementid, arg);
            arg = Visit(node.Plus, arg);
            
            arg = OutAPlusElement(node, arg);
            arg = OutPElement(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPElementname(PElementname node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPElementname(PElementname node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAElementname(AElementname node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAElementname(AElementname node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAElementname(AElementname node, TValue arg)
        {
            arg = InPElementname(node, arg);
            arg = InAElementname(node, arg);
            
            arg = Visit(node.Lpar, arg);
            arg = Visit(node.Name, arg);
            arg = Visit(node.Rpar, arg);
            arg = Visit(node.Colon, arg);
            
            arg = OutAElementname(node, arg);
            arg = OutPElementname(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPElementid(PElementid node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPElementid(PElementid node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InACleanElementid(ACleanElementid node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutACleanElementid(ACleanElementid node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseACleanElementid(ACleanElementid node, TValue arg)
        {
            arg = InPElementid(node, arg);
            arg = InACleanElementid(node, arg);
            
            arg = Visit(node.Identifier, arg);
            
            arg = OutACleanElementid(node, arg);
            arg = OutPElementid(node, arg);
            
            return arg;
        }
        public virtual TValue InATokenElementid(ATokenElementid node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATokenElementid(ATokenElementid node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATokenElementid(ATokenElementid node, TValue arg)
        {
            arg = InPElementid(node, arg);
            arg = InATokenElementid(node, arg);
            
            arg = Visit(node.TokenSpecifier, arg);
            arg = Visit(node.Dot, arg);
            arg = Visit(node.Identifier, arg);
            
            arg = OutATokenElementid(node, arg);
            arg = OutPElementid(node, arg);
            
            return arg;
        }
        public virtual TValue InAProductionElementid(AProductionElementid node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAProductionElementid(AProductionElementid node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAProductionElementid(AProductionElementid node, TValue arg)
        {
            arg = InPElementid(node, arg);
            arg = InAProductionElementid(node, arg);
            
            arg = Visit(node.ProductionSpecifier, arg);
            arg = Visit(node.Dot, arg);
            arg = Visit(node.Identifier, arg);
            
            arg = OutAProductionElementid(node, arg);
            arg = OutPElementid(node, arg);
            
            return arg;
        }
    }
    
    public class ReverseDepthFirstReturnAdapter : ReverseDepthFirstReturnAdapter<object>
    {
    }
    public class ReverseDepthFirstReturnAdapter<TValue> : ReturnAnalysisAdapter<TValue>
    {
        public override TValue Visit(Node node, TValue arg)
        {
            return Visit((dynamic)node, arg);
        }
        
        public virtual TValue InStart(Start<PGrammar> node, TValue arg)
        {
            return arg;
        }
        public virtual TValue OutStart(Start<PGrammar> node, TValue arg)
        {
            return arg;
        }
        public override TValue CaseStart(Start<PGrammar> node, TValue arg)
        {
            arg = InStart(node, arg);
            
            arg = Visit(node.EOF, arg);
            arg = Visit((dynamic)node.Root, arg);
            
            arg = OutStart(node, arg);
            
            return arg;
        }
        
        public virtual TValue DefaultPIn(Node node, TValue arg)
        {
            return arg;
        }
        public virtual TValue DefaultPOut(Node node, TValue arg)
        {
            return arg;
        }
        public virtual TValue DefaultAIn(Node node, TValue arg)
        {
            return arg;
        }
        public virtual TValue DefaultAOut(Node node, TValue arg)
        {
            return arg;
        }
        
        public virtual TValue InPGrammar(PGrammar node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPGrammar(PGrammar node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAGrammar(AGrammar node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAGrammar(AGrammar node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAGrammar(AGrammar node, TValue arg)
        {
            arg = InPGrammar(node, arg);
            arg = InAGrammar(node, arg);
            
            if (node.HasAstproductions)
                arg = Visit((dynamic)node.Astproductions, arg);
            if (node.HasProductions)
                arg = Visit((dynamic)node.Productions, arg);
            if (node.HasIgnoredtokens)
                arg = Visit((dynamic)node.Ignoredtokens, arg);
            if (node.HasTokens)
                arg = Visit((dynamic)node.Tokens, arg);
            if (node.HasStates)
                arg = Visit((dynamic)node.States, arg);
            if (node.HasHelpers)
                arg = Visit((dynamic)node.Helpers, arg);
            if (node.HasPackage)
                arg = Visit((dynamic)node.Package, arg);
            
            arg = OutAGrammar(node, arg);
            arg = OutPGrammar(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPPackage(PPackage node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPPackage(PPackage node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAPackage(APackage node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAPackage(APackage node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAPackage(APackage node, TValue arg)
        {
            arg = InPPackage(node, arg);
            arg = InAPackage(node, arg);
            
            arg = Visit(node.Semicolon, arg);
            arg = Visit(node.Packagename, arg);
            arg = Visit(node.Packagetoken, arg);
            
            arg = OutAPackage(node, arg);
            arg = OutPPackage(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPHelpers(PHelpers node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPHelpers(PHelpers node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAHelpers(AHelpers node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAHelpers(AHelpers node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAHelpers(AHelpers node, TValue arg)
        {
            arg = InPHelpers(node, arg);
            arg = InAHelpers(node, arg);
            
            {
                PHelper[] temp = new PHelper[node.Helpers.Count];
                node.Helpers.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    arg = Visit((dynamic)temp[i], arg);
            }
            arg = Visit(node.Helperstoken, arg);
            
            arg = OutAHelpers(node, arg);
            arg = OutPHelpers(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPHelper(PHelper node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPHelper(PHelper node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAHelper(AHelper node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAHelper(AHelper node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAHelper(AHelper node, TValue arg)
        {
            arg = InPHelper(node, arg);
            arg = InAHelper(node, arg);
            
            arg = Visit(node.Semicolon, arg);
            arg = Visit((dynamic)node.Regex, arg);
            arg = Visit(node.Equal, arg);
            arg = Visit(node.Identifier, arg);
            
            arg = OutAHelper(node, arg);
            arg = OutPHelper(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPTokens(PTokens node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPTokens(PTokens node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InATokens(ATokens node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATokens(ATokens node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATokens(ATokens node, TValue arg)
        {
            arg = InPTokens(node, arg);
            arg = InATokens(node, arg);
            
            {
                PToken[] temp = new PToken[node.Tokens.Count];
                node.Tokens.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    arg = Visit((dynamic)temp[i], arg);
            }
            arg = Visit(node.Tokenstoken, arg);
            
            arg = OutATokens(node, arg);
            arg = OutPTokens(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPToken(PToken node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPToken(PToken node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAToken(AToken node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAToken(AToken node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAToken(AToken node, TValue arg)
        {
            arg = InPToken(node, arg);
            arg = InAToken(node, arg);
            
            arg = Visit(node.Semicolon, arg);
            if (node.HasTokenlookahead)
                arg = Visit((dynamic)node.Tokenlookahead, arg);
            arg = Visit((dynamic)node.Regex, arg);
            arg = Visit(node.Equal, arg);
            arg = Visit(node.Identifier, arg);
            if (node.HasStatelist)
                arg = Visit((dynamic)node.Statelist, arg);
            
            arg = OutAToken(node, arg);
            arg = OutPToken(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPTokenlookahead(PTokenlookahead node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPTokenlookahead(PTokenlookahead node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InATokenlookahead(ATokenlookahead node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATokenlookahead(ATokenlookahead node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATokenlookahead(ATokenlookahead node, TValue arg)
        {
            arg = InPTokenlookahead(node, arg);
            arg = InATokenlookahead(node, arg);
            
            arg = Visit((dynamic)node.Regex, arg);
            arg = Visit(node.Slash, arg);
            
            arg = OutATokenlookahead(node, arg);
            arg = OutPTokenlookahead(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPRegex(PRegex node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPRegex(PRegex node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InARegex(ARegex node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutARegex(ARegex node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseARegex(ARegex node, TValue arg)
        {
            arg = InPRegex(node, arg);
            arg = InARegex(node, arg);
            
            {
                POrpart[] temp = new POrpart[node.Parts.Count];
                node.Parts.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutARegex(node, arg);
            arg = OutPRegex(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPOrpart(POrpart node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPOrpart(POrpart node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InARegexOrpart(ARegexOrpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutARegexOrpart(ARegexOrpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseARegexOrpart(ARegexOrpart node, TValue arg)
        {
            arg = InPOrpart(node, arg);
            arg = InARegexOrpart(node, arg);
            
            {
                PRegexpart[] temp = new PRegexpart[node.Regexpart.Count];
                node.Regexpart.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    arg = Visit((dynamic)temp[i], arg);
            }
            if (node.HasPipe)
                arg = Visit(node.Pipe, arg);
            
            arg = OutARegexOrpart(node, arg);
            arg = OutPOrpart(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPRegexpart(PRegexpart node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPRegexpart(PRegexpart node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InACharRegexpart(ACharRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutACharRegexpart(ACharRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseACharRegexpart(ACharRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InACharRegexpart(node, arg);
            
            arg = Visit(node.Character, arg);
            
            arg = OutACharRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InADecRegexpart(ADecRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutADecRegexpart(ADecRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseADecRegexpart(ADecRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InADecRegexpart(node, arg);
            
            arg = Visit(node.DecChar, arg);
            
            arg = OutADecRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAHexRegexpart(AHexRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAHexRegexpart(AHexRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAHexRegexpart(AHexRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAHexRegexpart(node, arg);
            
            arg = Visit(node.HexChar, arg);
            
            arg = OutAHexRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAUnarystarRegexpart(AUnarystarRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAUnarystarRegexpart(AUnarystarRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAUnarystarRegexpart(AUnarystarRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAUnarystarRegexpart(node, arg);
            
            arg = Visit(node.Star, arg);
            arg = Visit((dynamic)node.Regexpart, arg);
            
            arg = OutAUnarystarRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAUnaryquestionRegexpart(AUnaryquestionRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAUnaryquestionRegexpart(AUnaryquestionRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAUnaryquestionRegexpart(AUnaryquestionRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAUnaryquestionRegexpart(node, arg);
            
            arg = Visit(node.Question, arg);
            arg = Visit((dynamic)node.Regexpart, arg);
            
            arg = OutAUnaryquestionRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAUnaryplusRegexpart(AUnaryplusRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAUnaryplusRegexpart(AUnaryplusRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAUnaryplusRegexpart(AUnaryplusRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAUnaryplusRegexpart(node, arg);
            
            arg = Visit(node.Plus, arg);
            arg = Visit((dynamic)node.Regexpart, arg);
            
            arg = OutAUnaryplusRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InABinaryplusRegexpart(ABinaryplusRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutABinaryplusRegexpart(ABinaryplusRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseABinaryplusRegexpart(ABinaryplusRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InABinaryplusRegexpart(node, arg);
            
            arg = Visit(node.Rpar, arg);
            arg = Visit((dynamic)node.Right, arg);
            arg = Visit(node.Plus, arg);
            arg = Visit((dynamic)node.Left, arg);
            arg = Visit(node.Lpar, arg);
            
            arg = OutABinaryplusRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InABinaryminusRegexpart(ABinaryminusRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutABinaryminusRegexpart(ABinaryminusRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseABinaryminusRegexpart(ABinaryminusRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InABinaryminusRegexpart(node, arg);
            
            arg = Visit(node.Rpar, arg);
            arg = Visit((dynamic)node.Right, arg);
            arg = Visit(node.Minus, arg);
            arg = Visit((dynamic)node.Left, arg);
            arg = Visit(node.Lpar, arg);
            
            arg = OutABinaryminusRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAIntervalRegexpart(AIntervalRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIntervalRegexpart(AIntervalRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIntervalRegexpart(AIntervalRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAIntervalRegexpart(node, arg);
            
            arg = Visit(node.Rpar, arg);
            arg = Visit((dynamic)node.Right, arg);
            arg = Visit(node.Dots, arg);
            arg = Visit((dynamic)node.Left, arg);
            arg = Visit(node.Lpar, arg);
            
            arg = OutAIntervalRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAStringRegexpart(AStringRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAStringRegexpart(AStringRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAStringRegexpart(AStringRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAStringRegexpart(node, arg);
            
            arg = Visit(node.String, arg);
            
            arg = OutAStringRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAIdentifierRegexpart(AIdentifierRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIdentifierRegexpart(AIdentifierRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIdentifierRegexpart(AIdentifierRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAIdentifierRegexpart(node, arg);
            
            arg = Visit(node.Identifier, arg);
            
            arg = OutAIdentifierRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        public virtual TValue InAParenthesisRegexpart(AParenthesisRegexpart node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAParenthesisRegexpart(AParenthesisRegexpart node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAParenthesisRegexpart(AParenthesisRegexpart node, TValue arg)
        {
            arg = InPRegexpart(node, arg);
            arg = InAParenthesisRegexpart(node, arg);
            
            arg = Visit(node.Rpar, arg);
            arg = Visit((dynamic)node.Regex, arg);
            arg = Visit(node.Lpar, arg);
            
            arg = OutAParenthesisRegexpart(node, arg);
            arg = OutPRegexpart(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPStates(PStates node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPStates(PStates node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAStates(AStates node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAStates(AStates node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAStates(AStates node, TValue arg)
        {
            arg = InPStates(node, arg);
            arg = InAStates(node, arg);
            
            arg = Visit(node.Semicolon, arg);
            arg = Visit((dynamic)node.List, arg);
            arg = Visit(node.Statestoken, arg);
            
            arg = OutAStates(node, arg);
            arg = OutPStates(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPIgnoredtokens(PIgnoredtokens node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPIgnoredtokens(PIgnoredtokens node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAIgnoredtokens(AIgnoredtokens node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIgnoredtokens(AIgnoredtokens node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIgnoredtokens(AIgnoredtokens node, TValue arg)
        {
            arg = InPIgnoredtokens(node, arg);
            arg = InAIgnoredtokens(node, arg);
            
            arg = Visit(node.Semicolon, arg);
            arg = Visit((dynamic)node.List, arg);
            arg = Visit(node.Tokenstoken, arg);
            arg = Visit(node.Ignoredtoken, arg);
            
            arg = OutAIgnoredtokens(node, arg);
            arg = OutPIgnoredtokens(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPList(PList node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPList(PList node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAIdentifierList(AIdentifierList node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIdentifierList(AIdentifierList node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIdentifierList(AIdentifierList node, TValue arg)
        {
            arg = InPList(node, arg);
            arg = InAIdentifierList(node, arg);
            
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutAIdentifierList(node, arg);
            arg = OutPList(node, arg);
            
            return arg;
        }
        public virtual TValue InATokenstateList(ATokenstateList node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATokenstateList(ATokenstateList node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATokenstateList(ATokenstateList node, TValue arg)
        {
            arg = InPList(node, arg);
            arg = InATokenstateList(node, arg);
            
            arg = Visit(node.Rpar, arg);
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    arg = Visit((dynamic)temp[i], arg);
            }
            arg = Visit(node.Lpar, arg);
            
            arg = OutATokenstateList(node, arg);
            arg = OutPList(node, arg);
            
            return arg;
        }
        public virtual TValue InATranslationList(ATranslationList node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATranslationList(ATranslationList node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATranslationList(ATranslationList node, TValue arg)
        {
            arg = InPList(node, arg);
            arg = InATranslationList(node, arg);
            
            {
                PListitem[] temp = new PListitem[node.Listitem.Count];
                node.Listitem.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutATranslationList(node, arg);
            arg = OutPList(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPListitem(PListitem node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPListitem(PListitem node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAIdentifierListitem(AIdentifierListitem node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIdentifierListitem(AIdentifierListitem node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIdentifierListitem(AIdentifierListitem node, TValue arg)
        {
            arg = InPListitem(node, arg);
            arg = InAIdentifierListitem(node, arg);
            
            arg = Visit(node.Identifier, arg);
            if (node.HasComma)
                arg = Visit(node.Comma, arg);
            
            arg = OutAIdentifierListitem(node, arg);
            arg = OutPListitem(node, arg);
            
            return arg;
        }
        public virtual TValue InATokenstateListitem(ATokenstateListitem node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATokenstateListitem(ATokenstateListitem node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATokenstateListitem(ATokenstateListitem node, TValue arg)
        {
            arg = InPListitem(node, arg);
            arg = InATokenstateListitem(node, arg);
            
            arg = Visit(node.Identifier, arg);
            if (node.HasComma)
                arg = Visit(node.Comma, arg);
            
            arg = OutATokenstateListitem(node, arg);
            arg = OutPListitem(node, arg);
            
            return arg;
        }
        public virtual TValue InATokenstatetransitionListitem(ATokenstatetransitionListitem node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATokenstatetransitionListitem(ATokenstatetransitionListitem node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATokenstatetransitionListitem(ATokenstatetransitionListitem node, TValue arg)
        {
            arg = InPListitem(node, arg);
            arg = InATokenstatetransitionListitem(node, arg);
            
            arg = Visit(node.To, arg);
            arg = Visit(node.Arrow, arg);
            arg = Visit(node.From, arg);
            if (node.HasComma)
                arg = Visit(node.Comma, arg);
            
            arg = OutATokenstatetransitionListitem(node, arg);
            arg = OutPListitem(node, arg);
            
            return arg;
        }
        public virtual TValue InATranslationListitem(ATranslationListitem node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATranslationListitem(ATranslationListitem node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATranslationListitem(ATranslationListitem node, TValue arg)
        {
            arg = InPListitem(node, arg);
            arg = InATranslationListitem(node, arg);
            
            arg = Visit((dynamic)node.Translation, arg);
            if (node.HasComma)
                arg = Visit(node.Comma, arg);
            
            arg = OutATranslationListitem(node, arg);
            arg = OutPListitem(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPProductions(PProductions node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPProductions(PProductions node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAProductions(AProductions node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAProductions(AProductions node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAProductions(AProductions node, TValue arg)
        {
            arg = InPProductions(node, arg);
            arg = InAProductions(node, arg);
            
            {
                PProduction[] temp = new PProduction[node.Productions.Count];
                node.Productions.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    arg = Visit((dynamic)temp[i], arg);
            }
            arg = Visit(node.Productionstoken, arg);
            
            arg = OutAProductions(node, arg);
            arg = OutPProductions(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPAstproductions(PAstproductions node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPAstproductions(PAstproductions node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAAstproductions(AAstproductions node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAAstproductions(AAstproductions node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAAstproductions(AAstproductions node, TValue arg)
        {
            arg = InPAstproductions(node, arg);
            arg = InAAstproductions(node, arg);
            
            {
                PProduction[] temp = new PProduction[node.Productions.Count];
                node.Productions.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    arg = Visit((dynamic)temp[i], arg);
            }
            arg = Visit(node.Asttoken, arg);
            
            arg = OutAAstproductions(node, arg);
            arg = OutPAstproductions(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPProduction(PProduction node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPProduction(PProduction node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAProduction(AProduction node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAProduction(AProduction node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAProduction(AProduction node, TValue arg)
        {
            arg = InPProduction(node, arg);
            arg = InAProduction(node, arg);
            
            arg = Visit(node.Semicolon, arg);
            arg = Visit((dynamic)node.Productionrule, arg);
            arg = Visit(node.Equal, arg);
            if (node.HasProdtranslation)
                arg = Visit((dynamic)node.Prodtranslation, arg);
            arg = Visit(node.Identifier, arg);
            
            arg = OutAProduction(node, arg);
            arg = OutPProduction(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPProdtranslation(PProdtranslation node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPProdtranslation(PProdtranslation node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InACleanProdtranslation(ACleanProdtranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutACleanProdtranslation(ACleanProdtranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseACleanProdtranslation(ACleanProdtranslation node, TValue arg)
        {
            arg = InPProdtranslation(node, arg);
            arg = InACleanProdtranslation(node, arg);
            
            arg = Visit(node.Rpar, arg);
            arg = Visit(node.Identifier, arg);
            arg = Visit(node.Arrow, arg);
            arg = Visit(node.Lpar, arg);
            
            arg = OutACleanProdtranslation(node, arg);
            arg = OutPProdtranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InAStarProdtranslation(AStarProdtranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAStarProdtranslation(AStarProdtranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAStarProdtranslation(AStarProdtranslation node, TValue arg)
        {
            arg = InPProdtranslation(node, arg);
            arg = InAStarProdtranslation(node, arg);
            
            arg = Visit(node.Rpar, arg);
            arg = Visit(node.Star, arg);
            arg = Visit(node.Identifier, arg);
            arg = Visit(node.Arrow, arg);
            arg = Visit(node.Lpar, arg);
            
            arg = OutAStarProdtranslation(node, arg);
            arg = OutPProdtranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InAPlusProdtranslation(APlusProdtranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAPlusProdtranslation(APlusProdtranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAPlusProdtranslation(APlusProdtranslation node, TValue arg)
        {
            arg = InPProdtranslation(node, arg);
            arg = InAPlusProdtranslation(node, arg);
            
            arg = Visit(node.Rpar, arg);
            arg = Visit(node.Plus, arg);
            arg = Visit(node.Identifier, arg);
            arg = Visit(node.Arrow, arg);
            arg = Visit(node.Lpar, arg);
            
            arg = OutAPlusProdtranslation(node, arg);
            arg = OutPProdtranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InAQuestionProdtranslation(AQuestionProdtranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAQuestionProdtranslation(AQuestionProdtranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAQuestionProdtranslation(AQuestionProdtranslation node, TValue arg)
        {
            arg = InPProdtranslation(node, arg);
            arg = InAQuestionProdtranslation(node, arg);
            
            arg = Visit(node.Rpar, arg);
            arg = Visit(node.QMark, arg);
            arg = Visit(node.Identifier, arg);
            arg = Visit(node.Arrow, arg);
            arg = Visit(node.Lpar, arg);
            
            arg = OutAQuestionProdtranslation(node, arg);
            arg = OutPProdtranslation(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPTranslation(PTranslation node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPTranslation(PTranslation node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAFullTranslation(AFullTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAFullTranslation(AFullTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAFullTranslation(AFullTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InAFullTranslation(node, arg);
            
            arg = Visit(node.Rpar, arg);
            arg = Visit((dynamic)node.Translation, arg);
            arg = Visit(node.Arrow, arg);
            arg = Visit(node.Lpar, arg);
            
            arg = OutAFullTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InANewTranslation(ANewTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutANewTranslation(ANewTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseANewTranslation(ANewTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InANewTranslation(node, arg);
            
            arg = Visit(node.Rpar, arg);
            arg = Visit((dynamic)node.Arguments, arg);
            arg = Visit(node.Lpar, arg);
            arg = Visit(node.Production, arg);
            arg = Visit(node.New, arg);
            
            arg = OutANewTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InANewalternativeTranslation(ANewalternativeTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutANewalternativeTranslation(ANewalternativeTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseANewalternativeTranslation(ANewalternativeTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InANewalternativeTranslation(node, arg);
            
            arg = Visit(node.Rpar, arg);
            arg = Visit((dynamic)node.Arguments, arg);
            arg = Visit(node.Lpar, arg);
            arg = Visit(node.Alternative, arg);
            arg = Visit(node.Dot, arg);
            arg = Visit(node.Production, arg);
            arg = Visit(node.New, arg);
            
            arg = OutANewalternativeTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InAListTranslation(AListTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAListTranslation(AListTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAListTranslation(AListTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InAListTranslation(node, arg);
            
            arg = Visit(node.Rpar, arg);
            arg = Visit((dynamic)node.Elements, arg);
            arg = Visit(node.Lpar, arg);
            
            arg = OutAListTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InANullTranslation(ANullTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutANullTranslation(ANullTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseANullTranslation(ANullTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InANullTranslation(node, arg);
            
            arg = Visit(node.Null, arg);
            
            arg = OutANullTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InAIdTranslation(AIdTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIdTranslation(AIdTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIdTranslation(AIdTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InAIdTranslation(node, arg);
            
            arg = Visit(node.Identifier, arg);
            
            arg = OutAIdTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        public virtual TValue InAIddotidTranslation(AIddotidTranslation node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAIddotidTranslation(AIddotidTranslation node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAIddotidTranslation(AIddotidTranslation node, TValue arg)
        {
            arg = InPTranslation(node, arg);
            arg = InAIddotidTranslation(node, arg);
            
            arg = Visit(node.Production, arg);
            arg = Visit(node.Dot, arg);
            arg = Visit(node.Identifier, arg);
            
            arg = OutAIddotidTranslation(node, arg);
            arg = OutPTranslation(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPProductionrule(PProductionrule node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPProductionrule(PProductionrule node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAProductionrule(AProductionrule node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAProductionrule(AProductionrule node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAProductionrule(AProductionrule node, TValue arg)
        {
            arg = InPProductionrule(node, arg);
            arg = InAProductionrule(node, arg);
            
            {
                PAlternative[] temp = new PAlternative[node.Alternatives.Count];
                node.Alternatives.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutAProductionrule(node, arg);
            arg = OutPProductionrule(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPAlternative(PAlternative node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPAlternative(PAlternative node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAAlternative(AAlternative node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAAlternative(AAlternative node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAAlternative(AAlternative node, TValue arg)
        {
            arg = InPAlternative(node, arg);
            arg = InAAlternative(node, arg);
            
            if (node.HasTranslation)
                arg = Visit((dynamic)node.Translation, arg);
            arg = Visit((dynamic)node.Elements, arg);
            if (node.HasAlternativename)
                arg = Visit((dynamic)node.Alternativename, arg);
            if (node.HasPipe)
                arg = Visit(node.Pipe, arg);
            
            arg = OutAAlternative(node, arg);
            arg = OutPAlternative(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPAlternativename(PAlternativename node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPAlternativename(PAlternativename node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAAlternativename(AAlternativename node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAAlternativename(AAlternativename node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAAlternativename(AAlternativename node, TValue arg)
        {
            arg = InPAlternativename(node, arg);
            arg = InAAlternativename(node, arg);
            
            arg = Visit(node.Rpar, arg);
            arg = Visit(node.Name, arg);
            arg = Visit(node.Lpar, arg);
            
            arg = OutAAlternativename(node, arg);
            arg = OutPAlternativename(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPElements(PElements node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPElements(PElements node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAElements(AElements node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAElements(AElements node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAElements(AElements node, TValue arg)
        {
            arg = InPElements(node, arg);
            arg = InAElements(node, arg);
            
            {
                PElement[] temp = new PElement[node.Element.Count];
                node.Element.CopyTo(temp, 0);
                for (int i = temp.Length - 1; i >= 0; i--)
                    arg = Visit((dynamic)temp[i], arg);
            }
            
            arg = OutAElements(node, arg);
            arg = OutPElements(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPElement(PElement node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPElement(PElement node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InASimpleElement(ASimpleElement node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutASimpleElement(ASimpleElement node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseASimpleElement(ASimpleElement node, TValue arg)
        {
            arg = InPElement(node, arg);
            arg = InASimpleElement(node, arg);
            
            arg = Visit((dynamic)node.Elementid, arg);
            if (node.HasElementname)
                arg = Visit((dynamic)node.Elementname, arg);
            
            arg = OutASimpleElement(node, arg);
            arg = OutPElement(node, arg);
            
            return arg;
        }
        public virtual TValue InAStarElement(AStarElement node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAStarElement(AStarElement node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAStarElement(AStarElement node, TValue arg)
        {
            arg = InPElement(node, arg);
            arg = InAStarElement(node, arg);
            
            arg = Visit(node.Star, arg);
            arg = Visit((dynamic)node.Elementid, arg);
            if (node.HasElementname)
                arg = Visit((dynamic)node.Elementname, arg);
            
            arg = OutAStarElement(node, arg);
            arg = OutPElement(node, arg);
            
            return arg;
        }
        public virtual TValue InAQuestionElement(AQuestionElement node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAQuestionElement(AQuestionElement node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAQuestionElement(AQuestionElement node, TValue arg)
        {
            arg = InPElement(node, arg);
            arg = InAQuestionElement(node, arg);
            
            arg = Visit(node.QMark, arg);
            arg = Visit((dynamic)node.Elementid, arg);
            if (node.HasElementname)
                arg = Visit((dynamic)node.Elementname, arg);
            
            arg = OutAQuestionElement(node, arg);
            arg = OutPElement(node, arg);
            
            return arg;
        }
        public virtual TValue InAPlusElement(APlusElement node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAPlusElement(APlusElement node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAPlusElement(APlusElement node, TValue arg)
        {
            arg = InPElement(node, arg);
            arg = InAPlusElement(node, arg);
            
            arg = Visit(node.Plus, arg);
            arg = Visit((dynamic)node.Elementid, arg);
            if (node.HasElementname)
                arg = Visit((dynamic)node.Elementname, arg);
            
            arg = OutAPlusElement(node, arg);
            arg = OutPElement(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPElementname(PElementname node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPElementname(PElementname node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InAElementname(AElementname node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAElementname(AElementname node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAElementname(AElementname node, TValue arg)
        {
            arg = InPElementname(node, arg);
            arg = InAElementname(node, arg);
            
            arg = Visit(node.Colon, arg);
            arg = Visit(node.Rpar, arg);
            arg = Visit(node.Name, arg);
            arg = Visit(node.Lpar, arg);
            
            arg = OutAElementname(node, arg);
            arg = OutPElementname(node, arg);
            
            return arg;
        }
        
        public virtual TValue InPElementid(PElementid node, TValue arg)
        {
            return DefaultPIn(node, arg);
        }
        public virtual TValue OutPElementid(PElementid node, TValue arg)
        {
            return DefaultPOut(node, arg);
        }
        public virtual TValue InACleanElementid(ACleanElementid node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutACleanElementid(ACleanElementid node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseACleanElementid(ACleanElementid node, TValue arg)
        {
            arg = InPElementid(node, arg);
            arg = InACleanElementid(node, arg);
            
            arg = Visit(node.Identifier, arg);
            
            arg = OutACleanElementid(node, arg);
            arg = OutPElementid(node, arg);
            
            return arg;
        }
        public virtual TValue InATokenElementid(ATokenElementid node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutATokenElementid(ATokenElementid node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseATokenElementid(ATokenElementid node, TValue arg)
        {
            arg = InPElementid(node, arg);
            arg = InATokenElementid(node, arg);
            
            arg = Visit(node.Identifier, arg);
            arg = Visit(node.Dot, arg);
            arg = Visit(node.TokenSpecifier, arg);
            
            arg = OutATokenElementid(node, arg);
            arg = OutPElementid(node, arg);
            
            return arg;
        }
        public virtual TValue InAProductionElementid(AProductionElementid node, TValue arg)
        {
            return DefaultAIn(node, arg);
        }
        public virtual TValue OutAProductionElementid(AProductionElementid node, TValue arg)
        {
            return DefaultAOut(node, arg);
        }
        public override TValue CaseAProductionElementid(AProductionElementid node, TValue arg)
        {
            arg = InPElementid(node, arg);
            arg = InAProductionElementid(node, arg);
            
            arg = Visit(node.Identifier, arg);
            arg = Visit(node.Dot, arg);
            arg = Visit(node.ProductionSpecifier, arg);
            
            arg = OutAProductionElementid(node, arg);
            arg = OutPElementid(node, arg);
            
            return arg;
        }
    }
    
    #endregion
}
