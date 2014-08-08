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
    public class AnalysisAdapter<Value> : Adapter<Value, PGrammar>
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
        public void Visit(ASectionGrammar node)
        {
            CaseASectionGrammar(node);
        }
        public virtual void CaseASectionGrammar(ASectionGrammar node)
        {
            DefaultCase(node);
        }
        public void Visit(APackageSection node)
        {
            CaseAPackageSection(node);
        }
        public virtual void CaseAPackageSection(APackageSection node)
        {
            DefaultCase(node);
        }
        public void Visit(AHelpersSection node)
        {
            CaseAHelpersSection(node);
        }
        public virtual void CaseAHelpersSection(AHelpersSection node)
        {
            DefaultCase(node);
        }
        public void Visit(AStatesSection node)
        {
            CaseAStatesSection(node);
        }
        public virtual void CaseAStatesSection(AStatesSection node)
        {
            DefaultCase(node);
        }
        public void Visit(ATokensSection node)
        {
            CaseATokensSection(node);
        }
        public virtual void CaseATokensSection(ATokensSection node)
        {
            DefaultCase(node);
        }
        public void Visit(AIgnoreSection node)
        {
            CaseAIgnoreSection(node);
        }
        public virtual void CaseAIgnoreSection(AIgnoreSection node)
        {
            DefaultCase(node);
        }
        public void Visit(AProductionsSection node)
        {
            CaseAProductionsSection(node);
        }
        public virtual void CaseAProductionsSection(AProductionsSection node)
        {
            DefaultCase(node);
        }
        public void Visit(AASTSection node)
        {
            CaseAASTSection(node);
        }
        public virtual void CaseAASTSection(AASTSection node)
        {
            DefaultCase(node);
        }
        public void Visit(AHighlightSection node)
        {
            CaseAHighlightSection(node);
        }
        public virtual void CaseAHighlightSection(AHighlightSection node)
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
        public void Visit(ACharRegex node)
        {
            CaseACharRegex(node);
        }
        public virtual void CaseACharRegex(ACharRegex node)
        {
            DefaultCase(node);
        }
        public void Visit(ADecRegex node)
        {
            CaseADecRegex(node);
        }
        public virtual void CaseADecRegex(ADecRegex node)
        {
            DefaultCase(node);
        }
        public void Visit(AHexRegex node)
        {
            CaseAHexRegex(node);
        }
        public virtual void CaseAHexRegex(AHexRegex node)
        {
            DefaultCase(node);
        }
        public void Visit(AConcatenatedRegex node)
        {
            CaseAConcatenatedRegex(node);
        }
        public virtual void CaseAConcatenatedRegex(AConcatenatedRegex node)
        {
            DefaultCase(node);
        }
        public void Visit(AUnaryRegex node)
        {
            CaseAUnaryRegex(node);
        }
        public virtual void CaseAUnaryRegex(AUnaryRegex node)
        {
            DefaultCase(node);
        }
        public void Visit(ABinaryplusRegex node)
        {
            CaseABinaryplusRegex(node);
        }
        public virtual void CaseABinaryplusRegex(ABinaryplusRegex node)
        {
            DefaultCase(node);
        }
        public void Visit(ABinaryminusRegex node)
        {
            CaseABinaryminusRegex(node);
        }
        public virtual void CaseABinaryminusRegex(ABinaryminusRegex node)
        {
            DefaultCase(node);
        }
        public void Visit(AIntervalRegex node)
        {
            CaseAIntervalRegex(node);
        }
        public virtual void CaseAIntervalRegex(AIntervalRegex node)
        {
            DefaultCase(node);
        }
        public void Visit(AStringRegex node)
        {
            CaseAStringRegex(node);
        }
        public virtual void CaseAStringRegex(AStringRegex node)
        {
            DefaultCase(node);
        }
        public void Visit(AIdentifierRegex node)
        {
            CaseAIdentifierRegex(node);
        }
        public virtual void CaseAIdentifierRegex(AIdentifierRegex node)
        {
            DefaultCase(node);
        }
        public void Visit(AParenthesisRegex node)
        {
            CaseAParenthesisRegex(node);
        }
        public virtual void CaseAParenthesisRegex(AParenthesisRegex node)
        {
            DefaultCase(node);
        }
        public void Visit(AOrRegex node)
        {
            CaseAOrRegex(node);
        }
        public virtual void CaseAOrRegex(AOrRegex node)
        {
            DefaultCase(node);
        }
        public void Visit(AStarModifier node)
        {
            CaseAStarModifier(node);
        }
        public virtual void CaseAStarModifier(AStarModifier node)
        {
            DefaultCase(node);
        }
        public void Visit(AQuestionModifier node)
        {
            CaseAQuestionModifier(node);
        }
        public virtual void CaseAQuestionModifier(AQuestionModifier node)
        {
            DefaultCase(node);
        }
        public void Visit(APlusModifier node)
        {
            CaseAPlusModifier(node);
        }
        public virtual void CaseAPlusModifier(APlusModifier node)
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
        public void Visit(ATokenstateList node)
        {
            CaseATokenstateList(node);
        }
        public virtual void CaseATokenstateList(ATokenstateList node)
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
        public void Visit(ATransitionTokenstateListitem node)
        {
            CaseATransitionTokenstateListitem(node);
        }
        public virtual void CaseATransitionTokenstateListitem(ATransitionTokenstateListitem node)
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
        public void Visit(AProdtranslation node)
        {
            CaseAProdtranslation(node);
        }
        public virtual void CaseAProdtranslation(AProdtranslation node)
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
        public void Visit(AElement node)
        {
            CaseAElement(node);
        }
        public virtual void CaseAElement(AElement node)
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
    public class DepthFirstAdapter<Value> : AnalysisAdapter<Value>
    {
        public void Visit<Element>(Production.NodeList<Element> elements) where Element : Node
        {
            Element[] temp = new Element[elements.Count];
            elements.CopyTo(temp, 0);
            for (int i = 0; i < temp.Length; i++)
                Visit((dynamic)temp[i]);
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
            if (node.HasHighlightrules)
                Visit((dynamic)node.Highlightrules);
            
            OutAGrammar(node);
            OutPGrammar(node);
        }
        public virtual void InASectionGrammar(ASectionGrammar node)
        {
            DefaultAIn(node);
        }
        public virtual void OutASectionGrammar(ASectionGrammar node)
        {
            DefaultAOut(node);
        }
        public override void CaseASectionGrammar(ASectionGrammar node)
        {
            InPGrammar(node);
            InASectionGrammar(node);
            
            Visit(node.Sections);
            
            OutASectionGrammar(node);
            OutPGrammar(node);
        }
        
        public virtual void InPSection(PSection node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPSection(PSection node)
        {
            DefaultPOut(node);
        }
        public virtual void InAPackageSection(APackageSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAPackageSection(APackageSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAPackageSection(APackageSection node)
        {
            InPSection(node);
            InAPackageSection(node);
            
            Visit((dynamic)node.Package);
            
            OutAPackageSection(node);
            OutPSection(node);
        }
        public virtual void InAHelpersSection(AHelpersSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHelpersSection(AHelpersSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHelpersSection(AHelpersSection node)
        {
            InPSection(node);
            InAHelpersSection(node);
            
            Visit((dynamic)node.Helpers);
            
            OutAHelpersSection(node);
            OutPSection(node);
        }
        public virtual void InAStatesSection(AStatesSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStatesSection(AStatesSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStatesSection(AStatesSection node)
        {
            InPSection(node);
            InAStatesSection(node);
            
            Visit((dynamic)node.States);
            
            OutAStatesSection(node);
            OutPSection(node);
        }
        public virtual void InATokensSection(ATokensSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokensSection(ATokensSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokensSection(ATokensSection node)
        {
            InPSection(node);
            InATokensSection(node);
            
            Visit((dynamic)node.Tokens);
            
            OutATokensSection(node);
            OutPSection(node);
        }
        public virtual void InAIgnoreSection(AIgnoreSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIgnoreSection(AIgnoreSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIgnoreSection(AIgnoreSection node)
        {
            InPSection(node);
            InAIgnoreSection(node);
            
            Visit((dynamic)node.Ignoredtokens);
            
            OutAIgnoreSection(node);
            OutPSection(node);
        }
        public virtual void InAProductionsSection(AProductionsSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAProductionsSection(AProductionsSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAProductionsSection(AProductionsSection node)
        {
            InPSection(node);
            InAProductionsSection(node);
            
            Visit((dynamic)node.Productions);
            
            OutAProductionsSection(node);
            OutPSection(node);
        }
        public virtual void InAASTSection(AASTSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAASTSection(AASTSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAASTSection(AASTSection node)
        {
            InPSection(node);
            InAASTSection(node);
            
            Visit((dynamic)node.Astproductions);
            
            OutAASTSection(node);
            OutPSection(node);
        }
        public virtual void InAHighlightSection(AHighlightSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHighlightSection(AHighlightSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHighlightSection(AHighlightSection node)
        {
            InPSection(node);
            InAHighlightSection(node);
            
            Visit((dynamic)node.Highlightrules);
            
            OutAHighlightSection(node);
            OutPSection(node);
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
            Visit(node.Helpers);
            
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
            Visit(node.Tokens);
            
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
        public virtual void InACharRegex(ACharRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutACharRegex(ACharRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseACharRegex(ACharRegex node)
        {
            InPRegex(node);
            InACharRegex(node);
            
            Visit(node.Character);
            
            OutACharRegex(node);
            OutPRegex(node);
        }
        public virtual void InADecRegex(ADecRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutADecRegex(ADecRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseADecRegex(ADecRegex node)
        {
            InPRegex(node);
            InADecRegex(node);
            
            Visit(node.DecChar);
            
            OutADecRegex(node);
            OutPRegex(node);
        }
        public virtual void InAHexRegex(AHexRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHexRegex(AHexRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHexRegex(AHexRegex node)
        {
            InPRegex(node);
            InAHexRegex(node);
            
            Visit(node.HexChar);
            
            OutAHexRegex(node);
            OutPRegex(node);
        }
        public virtual void InAConcatenatedRegex(AConcatenatedRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAConcatenatedRegex(AConcatenatedRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAConcatenatedRegex(AConcatenatedRegex node)
        {
            InPRegex(node);
            InAConcatenatedRegex(node);
            
            Visit(node.Regexs);
            
            OutAConcatenatedRegex(node);
            OutPRegex(node);
        }
        public virtual void InAUnaryRegex(AUnaryRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAUnaryRegex(AUnaryRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAUnaryRegex(AUnaryRegex node)
        {
            InPRegex(node);
            InAUnaryRegex(node);
            
            Visit((dynamic)node.Regex);
            Visit((dynamic)node.Modifier);
            
            OutAUnaryRegex(node);
            OutPRegex(node);
        }
        public virtual void InABinaryplusRegex(ABinaryplusRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutABinaryplusRegex(ABinaryplusRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseABinaryplusRegex(ABinaryplusRegex node)
        {
            InPRegex(node);
            InABinaryplusRegex(node);
            
            Visit(node.Lpar);
            Visit((dynamic)node.Left);
            Visit(node.Plus);
            Visit((dynamic)node.Right);
            Visit(node.Rpar);
            
            OutABinaryplusRegex(node);
            OutPRegex(node);
        }
        public virtual void InABinaryminusRegex(ABinaryminusRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutABinaryminusRegex(ABinaryminusRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseABinaryminusRegex(ABinaryminusRegex node)
        {
            InPRegex(node);
            InABinaryminusRegex(node);
            
            Visit(node.Lpar);
            Visit((dynamic)node.Left);
            Visit(node.Minus);
            Visit((dynamic)node.Right);
            Visit(node.Rpar);
            
            OutABinaryminusRegex(node);
            OutPRegex(node);
        }
        public virtual void InAIntervalRegex(AIntervalRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIntervalRegex(AIntervalRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIntervalRegex(AIntervalRegex node)
        {
            InPRegex(node);
            InAIntervalRegex(node);
            
            Visit(node.Lpar);
            Visit((dynamic)node.Left);
            Visit(node.Dots);
            Visit((dynamic)node.Right);
            Visit(node.Rpar);
            
            OutAIntervalRegex(node);
            OutPRegex(node);
        }
        public virtual void InAStringRegex(AStringRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStringRegex(AStringRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStringRegex(AStringRegex node)
        {
            InPRegex(node);
            InAStringRegex(node);
            
            Visit(node.String);
            
            OutAStringRegex(node);
            OutPRegex(node);
        }
        public virtual void InAIdentifierRegex(AIdentifierRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIdentifierRegex(AIdentifierRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIdentifierRegex(AIdentifierRegex node)
        {
            InPRegex(node);
            InAIdentifierRegex(node);
            
            Visit(node.Identifier);
            
            OutAIdentifierRegex(node);
            OutPRegex(node);
        }
        public virtual void InAParenthesisRegex(AParenthesisRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAParenthesisRegex(AParenthesisRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAParenthesisRegex(AParenthesisRegex node)
        {
            InPRegex(node);
            InAParenthesisRegex(node);
            
            Visit(node.Lpar);
            Visit((dynamic)node.Regex);
            Visit(node.Rpar);
            
            OutAParenthesisRegex(node);
            OutPRegex(node);
        }
        public virtual void InAOrRegex(AOrRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAOrRegex(AOrRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAOrRegex(AOrRegex node)
        {
            InPRegex(node);
            InAOrRegex(node);
            
            Visit(node.Regexs);
            
            OutAOrRegex(node);
            OutPRegex(node);
        }
        
        public virtual void InPModifier(PModifier node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPModifier(PModifier node)
        {
            DefaultPOut(node);
        }
        public virtual void InAStarModifier(AStarModifier node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStarModifier(AStarModifier node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStarModifier(AStarModifier node)
        {
            InPModifier(node);
            InAStarModifier(node);
            
            Visit(node.Star);
            
            OutAStarModifier(node);
            OutPModifier(node);
        }
        public virtual void InAQuestionModifier(AQuestionModifier node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAQuestionModifier(AQuestionModifier node)
        {
            DefaultAOut(node);
        }
        public override void CaseAQuestionModifier(AQuestionModifier node)
        {
            InPModifier(node);
            InAQuestionModifier(node);
            
            Visit(node.QMark);
            
            OutAQuestionModifier(node);
            OutPModifier(node);
        }
        public virtual void InAPlusModifier(APlusModifier node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAPlusModifier(APlusModifier node)
        {
            DefaultAOut(node);
        }
        public override void CaseAPlusModifier(APlusModifier node)
        {
            InPModifier(node);
            InAPlusModifier(node);
            
            Visit(node.Plus);
            
            OutAPlusModifier(node);
            OutPModifier(node);
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
            Visit(node.States);
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
            Visit(node.Tokens);
            Visit(node.Semicolon);
            
            OutAIgnoredtokens(node);
            OutPIgnoredtokens(node);
        }
        
        public virtual void InPTokenstateList(PTokenstateList node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPTokenstateList(PTokenstateList node)
        {
            DefaultPOut(node);
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
            InPTokenstateList(node);
            InATokenstateList(node);
            
            Visit(node.Lpar);
            Visit(node.States);
            Visit(node.Rpar);
            
            OutATokenstateList(node);
            OutPTokenstateList(node);
        }
        
        public virtual void InPTokenstateListitem(PTokenstateListitem node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPTokenstateListitem(PTokenstateListitem node)
        {
            DefaultPOut(node);
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
            InPTokenstateListitem(node);
            InATokenstateListitem(node);
            
            if (node.HasComma)
                Visit(node.Comma);
            Visit(node.Identifier);
            
            OutATokenstateListitem(node);
            OutPTokenstateListitem(node);
        }
        public virtual void InATransitionTokenstateListitem(ATransitionTokenstateListitem node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATransitionTokenstateListitem(ATransitionTokenstateListitem node)
        {
            DefaultAOut(node);
        }
        public override void CaseATransitionTokenstateListitem(ATransitionTokenstateListitem node)
        {
            InPTokenstateListitem(node);
            InATransitionTokenstateListitem(node);
            
            if (node.HasComma)
                Visit(node.Comma);
            Visit(node.From);
            Visit(node.Arrow);
            Visit(node.To);
            
            OutATransitionTokenstateListitem(node);
            OutPTokenstateListitem(node);
        }
        
        public virtual void InPTranslationListitem(PTranslationListitem node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPTranslationListitem(PTranslationListitem node)
        {
            DefaultPOut(node);
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
            InPTranslationListitem(node);
            InATranslationListitem(node);
            
            if (node.HasComma)
                Visit(node.Comma);
            Visit((dynamic)node.Translation);
            
            OutATranslationListitem(node);
            OutPTranslationListitem(node);
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
            Visit(node.Productions);
            
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
            Visit(node.Productions);
            
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
            Visit(node.Alternatives);
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
        public virtual void InAProdtranslation(AProdtranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAProdtranslation(AProdtranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAProdtranslation(AProdtranslation node)
        {
            InPProdtranslation(node);
            InAProdtranslation(node);
            
            Visit(node.Arrow);
            Visit(node.Identifier);
            if (node.HasModifier)
                Visit((dynamic)node.Modifier);
            
            OutAProdtranslation(node);
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
            
            Visit(node.Arrow);
            Visit((dynamic)node.Translation);
            
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
            Visit(node.Arguments);
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
            Visit(node.Arguments);
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
            Visit(node.Elements);
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
            Visit(node.Elements);
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
        
        public virtual void InPElement(PElement node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPElement(PElement node)
        {
            DefaultPOut(node);
        }
        public virtual void InAElement(AElement node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAElement(AElement node)
        {
            DefaultAOut(node);
        }
        public override void CaseAElement(AElement node)
        {
            InPElement(node);
            InAElement(node);
            
            if (node.HasElementname)
                Visit((dynamic)node.Elementname);
            Visit((dynamic)node.Elementid);
            if (node.HasModifier)
                Visit((dynamic)node.Modifier);
            
            OutAElement(node);
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
            Visit(node.Highlightrules);
            
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
            Visit(node.Tokens);
            Visit(node.Rpar);
            Visit(node.Styles);
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
    public class ReverseDepthFirstAdapter<Value> : AnalysisAdapter<Value>
    {
        public void Visit<Element>(Production.NodeList<Element> elements) where Element : Node
        {
            Element[] temp = new Element[elements.Count];
            elements.CopyTo(temp, 0);
            for (int i = temp.Length - 1; i >= 0; i--)
                Visit((dynamic)temp[i]);
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
        public virtual void InASectionGrammar(ASectionGrammar node)
        {
            DefaultAIn(node);
        }
        public virtual void OutASectionGrammar(ASectionGrammar node)
        {
            DefaultAOut(node);
        }
        public override void CaseASectionGrammar(ASectionGrammar node)
        {
            InPGrammar(node);
            InASectionGrammar(node);
            
            Visit(node.Sections);
            
            OutASectionGrammar(node);
            OutPGrammar(node);
        }
        
        public virtual void InPSection(PSection node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPSection(PSection node)
        {
            DefaultPOut(node);
        }
        public virtual void InAPackageSection(APackageSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAPackageSection(APackageSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAPackageSection(APackageSection node)
        {
            InPSection(node);
            InAPackageSection(node);
            
            Visit((dynamic)node.Package);
            
            OutAPackageSection(node);
            OutPSection(node);
        }
        public virtual void InAHelpersSection(AHelpersSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHelpersSection(AHelpersSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHelpersSection(AHelpersSection node)
        {
            InPSection(node);
            InAHelpersSection(node);
            
            Visit((dynamic)node.Helpers);
            
            OutAHelpersSection(node);
            OutPSection(node);
        }
        public virtual void InAStatesSection(AStatesSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStatesSection(AStatesSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStatesSection(AStatesSection node)
        {
            InPSection(node);
            InAStatesSection(node);
            
            Visit((dynamic)node.States);
            
            OutAStatesSection(node);
            OutPSection(node);
        }
        public virtual void InATokensSection(ATokensSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATokensSection(ATokensSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseATokensSection(ATokensSection node)
        {
            InPSection(node);
            InATokensSection(node);
            
            Visit((dynamic)node.Tokens);
            
            OutATokensSection(node);
            OutPSection(node);
        }
        public virtual void InAIgnoreSection(AIgnoreSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIgnoreSection(AIgnoreSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIgnoreSection(AIgnoreSection node)
        {
            InPSection(node);
            InAIgnoreSection(node);
            
            Visit((dynamic)node.Ignoredtokens);
            
            OutAIgnoreSection(node);
            OutPSection(node);
        }
        public virtual void InAProductionsSection(AProductionsSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAProductionsSection(AProductionsSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAProductionsSection(AProductionsSection node)
        {
            InPSection(node);
            InAProductionsSection(node);
            
            Visit((dynamic)node.Productions);
            
            OutAProductionsSection(node);
            OutPSection(node);
        }
        public virtual void InAASTSection(AASTSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAASTSection(AASTSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAASTSection(AASTSection node)
        {
            InPSection(node);
            InAASTSection(node);
            
            Visit((dynamic)node.Astproductions);
            
            OutAASTSection(node);
            OutPSection(node);
        }
        public virtual void InAHighlightSection(AHighlightSection node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHighlightSection(AHighlightSection node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHighlightSection(AHighlightSection node)
        {
            InPSection(node);
            InAHighlightSection(node);
            
            Visit((dynamic)node.Highlightrules);
            
            OutAHighlightSection(node);
            OutPSection(node);
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
            
            Visit(node.Helpers);
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
            
            Visit(node.Tokens);
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
        public virtual void InACharRegex(ACharRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutACharRegex(ACharRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseACharRegex(ACharRegex node)
        {
            InPRegex(node);
            InACharRegex(node);
            
            Visit(node.Character);
            
            OutACharRegex(node);
            OutPRegex(node);
        }
        public virtual void InADecRegex(ADecRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutADecRegex(ADecRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseADecRegex(ADecRegex node)
        {
            InPRegex(node);
            InADecRegex(node);
            
            Visit(node.DecChar);
            
            OutADecRegex(node);
            OutPRegex(node);
        }
        public virtual void InAHexRegex(AHexRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAHexRegex(AHexRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAHexRegex(AHexRegex node)
        {
            InPRegex(node);
            InAHexRegex(node);
            
            Visit(node.HexChar);
            
            OutAHexRegex(node);
            OutPRegex(node);
        }
        public virtual void InAConcatenatedRegex(AConcatenatedRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAConcatenatedRegex(AConcatenatedRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAConcatenatedRegex(AConcatenatedRegex node)
        {
            InPRegex(node);
            InAConcatenatedRegex(node);
            
            Visit(node.Regexs);
            
            OutAConcatenatedRegex(node);
            OutPRegex(node);
        }
        public virtual void InAUnaryRegex(AUnaryRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAUnaryRegex(AUnaryRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAUnaryRegex(AUnaryRegex node)
        {
            InPRegex(node);
            InAUnaryRegex(node);
            
            Visit((dynamic)node.Modifier);
            Visit((dynamic)node.Regex);
            
            OutAUnaryRegex(node);
            OutPRegex(node);
        }
        public virtual void InABinaryplusRegex(ABinaryplusRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutABinaryplusRegex(ABinaryplusRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseABinaryplusRegex(ABinaryplusRegex node)
        {
            InPRegex(node);
            InABinaryplusRegex(node);
            
            Visit(node.Rpar);
            Visit((dynamic)node.Right);
            Visit(node.Plus);
            Visit((dynamic)node.Left);
            Visit(node.Lpar);
            
            OutABinaryplusRegex(node);
            OutPRegex(node);
        }
        public virtual void InABinaryminusRegex(ABinaryminusRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutABinaryminusRegex(ABinaryminusRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseABinaryminusRegex(ABinaryminusRegex node)
        {
            InPRegex(node);
            InABinaryminusRegex(node);
            
            Visit(node.Rpar);
            Visit((dynamic)node.Right);
            Visit(node.Minus);
            Visit((dynamic)node.Left);
            Visit(node.Lpar);
            
            OutABinaryminusRegex(node);
            OutPRegex(node);
        }
        public virtual void InAIntervalRegex(AIntervalRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIntervalRegex(AIntervalRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIntervalRegex(AIntervalRegex node)
        {
            InPRegex(node);
            InAIntervalRegex(node);
            
            Visit(node.Rpar);
            Visit((dynamic)node.Right);
            Visit(node.Dots);
            Visit((dynamic)node.Left);
            Visit(node.Lpar);
            
            OutAIntervalRegex(node);
            OutPRegex(node);
        }
        public virtual void InAStringRegex(AStringRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStringRegex(AStringRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStringRegex(AStringRegex node)
        {
            InPRegex(node);
            InAStringRegex(node);
            
            Visit(node.String);
            
            OutAStringRegex(node);
            OutPRegex(node);
        }
        public virtual void InAIdentifierRegex(AIdentifierRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAIdentifierRegex(AIdentifierRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAIdentifierRegex(AIdentifierRegex node)
        {
            InPRegex(node);
            InAIdentifierRegex(node);
            
            Visit(node.Identifier);
            
            OutAIdentifierRegex(node);
            OutPRegex(node);
        }
        public virtual void InAParenthesisRegex(AParenthesisRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAParenthesisRegex(AParenthesisRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAParenthesisRegex(AParenthesisRegex node)
        {
            InPRegex(node);
            InAParenthesisRegex(node);
            
            Visit(node.Rpar);
            Visit((dynamic)node.Regex);
            Visit(node.Lpar);
            
            OutAParenthesisRegex(node);
            OutPRegex(node);
        }
        public virtual void InAOrRegex(AOrRegex node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAOrRegex(AOrRegex node)
        {
            DefaultAOut(node);
        }
        public override void CaseAOrRegex(AOrRegex node)
        {
            InPRegex(node);
            InAOrRegex(node);
            
            Visit(node.Regexs);
            
            OutAOrRegex(node);
            OutPRegex(node);
        }
        
        public virtual void InPModifier(PModifier node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPModifier(PModifier node)
        {
            DefaultPOut(node);
        }
        public virtual void InAStarModifier(AStarModifier node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAStarModifier(AStarModifier node)
        {
            DefaultAOut(node);
        }
        public override void CaseAStarModifier(AStarModifier node)
        {
            InPModifier(node);
            InAStarModifier(node);
            
            Visit(node.Star);
            
            OutAStarModifier(node);
            OutPModifier(node);
        }
        public virtual void InAQuestionModifier(AQuestionModifier node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAQuestionModifier(AQuestionModifier node)
        {
            DefaultAOut(node);
        }
        public override void CaseAQuestionModifier(AQuestionModifier node)
        {
            InPModifier(node);
            InAQuestionModifier(node);
            
            Visit(node.QMark);
            
            OutAQuestionModifier(node);
            OutPModifier(node);
        }
        public virtual void InAPlusModifier(APlusModifier node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAPlusModifier(APlusModifier node)
        {
            DefaultAOut(node);
        }
        public override void CaseAPlusModifier(APlusModifier node)
        {
            InPModifier(node);
            InAPlusModifier(node);
            
            Visit(node.Plus);
            
            OutAPlusModifier(node);
            OutPModifier(node);
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
            Visit(node.States);
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
            Visit(node.Tokens);
            Visit(node.Tokenstoken);
            Visit(node.Ignoredtoken);
            
            OutAIgnoredtokens(node);
            OutPIgnoredtokens(node);
        }
        
        public virtual void InPTokenstateList(PTokenstateList node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPTokenstateList(PTokenstateList node)
        {
            DefaultPOut(node);
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
            InPTokenstateList(node);
            InATokenstateList(node);
            
            Visit(node.Rpar);
            Visit(node.States);
            Visit(node.Lpar);
            
            OutATokenstateList(node);
            OutPTokenstateList(node);
        }
        
        public virtual void InPTokenstateListitem(PTokenstateListitem node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPTokenstateListitem(PTokenstateListitem node)
        {
            DefaultPOut(node);
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
            InPTokenstateListitem(node);
            InATokenstateListitem(node);
            
            Visit(node.Identifier);
            if (node.HasComma)
                Visit(node.Comma);
            
            OutATokenstateListitem(node);
            OutPTokenstateListitem(node);
        }
        public virtual void InATransitionTokenstateListitem(ATransitionTokenstateListitem node)
        {
            DefaultAIn(node);
        }
        public virtual void OutATransitionTokenstateListitem(ATransitionTokenstateListitem node)
        {
            DefaultAOut(node);
        }
        public override void CaseATransitionTokenstateListitem(ATransitionTokenstateListitem node)
        {
            InPTokenstateListitem(node);
            InATransitionTokenstateListitem(node);
            
            Visit(node.To);
            Visit(node.Arrow);
            Visit(node.From);
            if (node.HasComma)
                Visit(node.Comma);
            
            OutATransitionTokenstateListitem(node);
            OutPTokenstateListitem(node);
        }
        
        public virtual void InPTranslationListitem(PTranslationListitem node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPTranslationListitem(PTranslationListitem node)
        {
            DefaultPOut(node);
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
            InPTranslationListitem(node);
            InATranslationListitem(node);
            
            Visit((dynamic)node.Translation);
            if (node.HasComma)
                Visit(node.Comma);
            
            OutATranslationListitem(node);
            OutPTranslationListitem(node);
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
            
            Visit(node.Productions);
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
            
            Visit(node.Productions);
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
            Visit(node.Alternatives);
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
        public virtual void InAProdtranslation(AProdtranslation node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAProdtranslation(AProdtranslation node)
        {
            DefaultAOut(node);
        }
        public override void CaseAProdtranslation(AProdtranslation node)
        {
            InPProdtranslation(node);
            InAProdtranslation(node);
            
            if (node.HasModifier)
                Visit((dynamic)node.Modifier);
            Visit(node.Identifier);
            Visit(node.Arrow);
            
            OutAProdtranslation(node);
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
            
            Visit((dynamic)node.Translation);
            Visit(node.Arrow);
            
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
            Visit(node.Arguments);
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
            Visit(node.Arguments);
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
            Visit(node.Elements);
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
            Visit(node.Elements);
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
        
        public virtual void InPElement(PElement node)
        {
            DefaultPIn(node);
        }
        public virtual void OutPElement(PElement node)
        {
            DefaultPOut(node);
        }
        public virtual void InAElement(AElement node)
        {
            DefaultAIn(node);
        }
        public virtual void OutAElement(AElement node)
        {
            DefaultAOut(node);
        }
        public override void CaseAElement(AElement node)
        {
            InPElement(node);
            InAElement(node);
            
            if (node.HasModifier)
                Visit((dynamic)node.Modifier);
            Visit((dynamic)node.Elementid);
            if (node.HasElementname)
                Visit((dynamic)node.Elementname);
            
            OutAElement(node);
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
            
            Visit(node.Highlightrules);
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
            Visit(node.Styles);
            Visit(node.Rpar);
            Visit(node.Tokens);
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
    
    public class ReturnAnalysisAdapter<Result> : ReturnAdapter<Result, PGrammar>
    {
        public override Result Visit(Node node)
        {
            return Visit((dynamic)node);
        }
        
        public Result Visit(AGrammar node)
        {
            return CaseAGrammar(node);
        }
        public virtual Result CaseAGrammar(AGrammar node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ASectionGrammar node)
        {
            return CaseASectionGrammar(node);
        }
        public virtual Result CaseASectionGrammar(ASectionGrammar node)
        {
            return DefaultCase(node);
        }
        public Result Visit(APackageSection node)
        {
            return CaseAPackageSection(node);
        }
        public virtual Result CaseAPackageSection(APackageSection node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AHelpersSection node)
        {
            return CaseAHelpersSection(node);
        }
        public virtual Result CaseAHelpersSection(AHelpersSection node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AStatesSection node)
        {
            return CaseAStatesSection(node);
        }
        public virtual Result CaseAStatesSection(AStatesSection node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ATokensSection node)
        {
            return CaseATokensSection(node);
        }
        public virtual Result CaseATokensSection(ATokensSection node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AIgnoreSection node)
        {
            return CaseAIgnoreSection(node);
        }
        public virtual Result CaseAIgnoreSection(AIgnoreSection node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AProductionsSection node)
        {
            return CaseAProductionsSection(node);
        }
        public virtual Result CaseAProductionsSection(AProductionsSection node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AASTSection node)
        {
            return CaseAASTSection(node);
        }
        public virtual Result CaseAASTSection(AASTSection node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AHighlightSection node)
        {
            return CaseAHighlightSection(node);
        }
        public virtual Result CaseAHighlightSection(AHighlightSection node)
        {
            return DefaultCase(node);
        }
        public Result Visit(APackage node)
        {
            return CaseAPackage(node);
        }
        public virtual Result CaseAPackage(APackage node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AHelpers node)
        {
            return CaseAHelpers(node);
        }
        public virtual Result CaseAHelpers(AHelpers node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AHelper node)
        {
            return CaseAHelper(node);
        }
        public virtual Result CaseAHelper(AHelper node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ATokens node)
        {
            return CaseATokens(node);
        }
        public virtual Result CaseATokens(ATokens node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AToken node)
        {
            return CaseAToken(node);
        }
        public virtual Result CaseAToken(AToken node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ATokenlookahead node)
        {
            return CaseATokenlookahead(node);
        }
        public virtual Result CaseATokenlookahead(ATokenlookahead node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ACharRegex node)
        {
            return CaseACharRegex(node);
        }
        public virtual Result CaseACharRegex(ACharRegex node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ADecRegex node)
        {
            return CaseADecRegex(node);
        }
        public virtual Result CaseADecRegex(ADecRegex node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AHexRegex node)
        {
            return CaseAHexRegex(node);
        }
        public virtual Result CaseAHexRegex(AHexRegex node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AConcatenatedRegex node)
        {
            return CaseAConcatenatedRegex(node);
        }
        public virtual Result CaseAConcatenatedRegex(AConcatenatedRegex node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AUnaryRegex node)
        {
            return CaseAUnaryRegex(node);
        }
        public virtual Result CaseAUnaryRegex(AUnaryRegex node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ABinaryplusRegex node)
        {
            return CaseABinaryplusRegex(node);
        }
        public virtual Result CaseABinaryplusRegex(ABinaryplusRegex node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ABinaryminusRegex node)
        {
            return CaseABinaryminusRegex(node);
        }
        public virtual Result CaseABinaryminusRegex(ABinaryminusRegex node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AIntervalRegex node)
        {
            return CaseAIntervalRegex(node);
        }
        public virtual Result CaseAIntervalRegex(AIntervalRegex node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AStringRegex node)
        {
            return CaseAStringRegex(node);
        }
        public virtual Result CaseAStringRegex(AStringRegex node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AIdentifierRegex node)
        {
            return CaseAIdentifierRegex(node);
        }
        public virtual Result CaseAIdentifierRegex(AIdentifierRegex node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AParenthesisRegex node)
        {
            return CaseAParenthesisRegex(node);
        }
        public virtual Result CaseAParenthesisRegex(AParenthesisRegex node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AOrRegex node)
        {
            return CaseAOrRegex(node);
        }
        public virtual Result CaseAOrRegex(AOrRegex node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AStarModifier node)
        {
            return CaseAStarModifier(node);
        }
        public virtual Result CaseAStarModifier(AStarModifier node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AQuestionModifier node)
        {
            return CaseAQuestionModifier(node);
        }
        public virtual Result CaseAQuestionModifier(AQuestionModifier node)
        {
            return DefaultCase(node);
        }
        public Result Visit(APlusModifier node)
        {
            return CaseAPlusModifier(node);
        }
        public virtual Result CaseAPlusModifier(APlusModifier node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AStates node)
        {
            return CaseAStates(node);
        }
        public virtual Result CaseAStates(AStates node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AIgnoredtokens node)
        {
            return CaseAIgnoredtokens(node);
        }
        public virtual Result CaseAIgnoredtokens(AIgnoredtokens node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ATokenstateList node)
        {
            return CaseATokenstateList(node);
        }
        public virtual Result CaseATokenstateList(ATokenstateList node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ATokenstateListitem node)
        {
            return CaseATokenstateListitem(node);
        }
        public virtual Result CaseATokenstateListitem(ATokenstateListitem node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ATransitionTokenstateListitem node)
        {
            return CaseATransitionTokenstateListitem(node);
        }
        public virtual Result CaseATransitionTokenstateListitem(ATransitionTokenstateListitem node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ATranslationListitem node)
        {
            return CaseATranslationListitem(node);
        }
        public virtual Result CaseATranslationListitem(ATranslationListitem node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AProductions node)
        {
            return CaseAProductions(node);
        }
        public virtual Result CaseAProductions(AProductions node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AAstproductions node)
        {
            return CaseAAstproductions(node);
        }
        public virtual Result CaseAAstproductions(AAstproductions node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AProduction node)
        {
            return CaseAProduction(node);
        }
        public virtual Result CaseAProduction(AProduction node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AProdtranslation node)
        {
            return CaseAProdtranslation(node);
        }
        public virtual Result CaseAProdtranslation(AProdtranslation node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AFullTranslation node)
        {
            return CaseAFullTranslation(node);
        }
        public virtual Result CaseAFullTranslation(AFullTranslation node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ANewTranslation node)
        {
            return CaseANewTranslation(node);
        }
        public virtual Result CaseANewTranslation(ANewTranslation node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ANewalternativeTranslation node)
        {
            return CaseANewalternativeTranslation(node);
        }
        public virtual Result CaseANewalternativeTranslation(ANewalternativeTranslation node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AListTranslation node)
        {
            return CaseAListTranslation(node);
        }
        public virtual Result CaseAListTranslation(AListTranslation node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ANullTranslation node)
        {
            return CaseANullTranslation(node);
        }
        public virtual Result CaseANullTranslation(ANullTranslation node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AIdTranslation node)
        {
            return CaseAIdTranslation(node);
        }
        public virtual Result CaseAIdTranslation(AIdTranslation node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AIddotidTranslation node)
        {
            return CaseAIddotidTranslation(node);
        }
        public virtual Result CaseAIddotidTranslation(AIddotidTranslation node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AAlternative node)
        {
            return CaseAAlternative(node);
        }
        public virtual Result CaseAAlternative(AAlternative node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AAlternativename node)
        {
            return CaseAAlternativename(node);
        }
        public virtual Result CaseAAlternativename(AAlternativename node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AElement node)
        {
            return CaseAElement(node);
        }
        public virtual Result CaseAElement(AElement node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AElementname node)
        {
            return CaseAElementname(node);
        }
        public virtual Result CaseAElementname(AElementname node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ACleanElementid node)
        {
            return CaseACleanElementid(node);
        }
        public virtual Result CaseACleanElementid(ACleanElementid node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ATokenElementid node)
        {
            return CaseATokenElementid(node);
        }
        public virtual Result CaseATokenElementid(ATokenElementid node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AProductionElementid node)
        {
            return CaseAProductionElementid(node);
        }
        public virtual Result CaseAProductionElementid(AProductionElementid node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AHighlightrules node)
        {
            return CaseAHighlightrules(node);
        }
        public virtual Result CaseAHighlightrules(AHighlightrules node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AHighlightrule node)
        {
            return CaseAHighlightrule(node);
        }
        public virtual Result CaseAHighlightrule(AHighlightrule node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AItalicHighlightStyle node)
        {
            return CaseAItalicHighlightStyle(node);
        }
        public virtual Result CaseAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ABoldHighlightStyle node)
        {
            return CaseABoldHighlightStyle(node);
        }
        public virtual Result CaseABoldHighlightStyle(ABoldHighlightStyle node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ATextHighlightStyle node)
        {
            return CaseATextHighlightStyle(node);
        }
        public virtual Result CaseATextHighlightStyle(ATextHighlightStyle node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ABackgroundHighlightStyle node)
        {
            return CaseABackgroundHighlightStyle(node);
        }
        public virtual Result CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            return DefaultCase(node);
        }
        public Result Visit(ARgbColor node)
        {
            return CaseARgbColor(node);
        }
        public virtual Result CaseARgbColor(ARgbColor node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AHsvColor node)
        {
            return CaseAHsvColor(node);
        }
        public virtual Result CaseAHsvColor(AHsvColor node)
        {
            return DefaultCase(node);
        }
        public Result Visit(AHexColor node)
        {
            return CaseAHexColor(node);
        }
        public virtual Result CaseAHexColor(AHexColor node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TPackagename node)
        {
            return CaseTPackagename(node);
        }
        public virtual Result CaseTPackagename(TPackagename node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TPackagetoken node)
        {
            return CaseTPackagetoken(node);
        }
        public virtual Result CaseTPackagetoken(TPackagetoken node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TStatestoken node)
        {
            return CaseTStatestoken(node);
        }
        public virtual Result CaseTStatestoken(TStatestoken node)
        {
            return DefaultCase(node);
        }
        public Result Visit(THelperstoken node)
        {
            return CaseTHelperstoken(node);
        }
        public virtual Result CaseTHelperstoken(THelperstoken node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TTokenstoken node)
        {
            return CaseTTokenstoken(node);
        }
        public virtual Result CaseTTokenstoken(TTokenstoken node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TIgnoredtoken node)
        {
            return CaseTIgnoredtoken(node);
        }
        public virtual Result CaseTIgnoredtoken(TIgnoredtoken node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TProductionstoken node)
        {
            return CaseTProductionstoken(node);
        }
        public virtual Result CaseTProductionstoken(TProductionstoken node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TAsttoken node)
        {
            return CaseTAsttoken(node);
        }
        public virtual Result CaseTAsttoken(TAsttoken node)
        {
            return DefaultCase(node);
        }
        public Result Visit(THighlighttoken node)
        {
            return CaseTHighlighttoken(node);
        }
        public virtual Result CaseTHighlighttoken(THighlighttoken node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TNew node)
        {
            return CaseTNew(node);
        }
        public virtual Result CaseTNew(TNew node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TNull node)
        {
            return CaseTNull(node);
        }
        public virtual Result CaseTNull(TNull node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TTokenSpecifier node)
        {
            return CaseTTokenSpecifier(node);
        }
        public virtual Result CaseTTokenSpecifier(TTokenSpecifier node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TProductionSpecifier node)
        {
            return CaseTProductionSpecifier(node);
        }
        public virtual Result CaseTProductionSpecifier(TProductionSpecifier node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TDot node)
        {
            return CaseTDot(node);
        }
        public virtual Result CaseTDot(TDot node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TDDot node)
        {
            return CaseTDDot(node);
        }
        public virtual Result CaseTDDot(TDDot node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TSemicolon node)
        {
            return CaseTSemicolon(node);
        }
        public virtual Result CaseTSemicolon(TSemicolon node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TEqual node)
        {
            return CaseTEqual(node);
        }
        public virtual Result CaseTEqual(TEqual node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TLBkt node)
        {
            return CaseTLBkt(node);
        }
        public virtual Result CaseTLBkt(TLBkt node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TRBkt node)
        {
            return CaseTRBkt(node);
        }
        public virtual Result CaseTRBkt(TRBkt node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TLPar node)
        {
            return CaseTLPar(node);
        }
        public virtual Result CaseTLPar(TLPar node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TRPar node)
        {
            return CaseTRPar(node);
        }
        public virtual Result CaseTRPar(TRPar node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TLBrace node)
        {
            return CaseTLBrace(node);
        }
        public virtual Result CaseTLBrace(TLBrace node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TRBrace node)
        {
            return CaseTRBrace(node);
        }
        public virtual Result CaseTRBrace(TRBrace node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TPlus node)
        {
            return CaseTPlus(node);
        }
        public virtual Result CaseTPlus(TPlus node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TMinus node)
        {
            return CaseTMinus(node);
        }
        public virtual Result CaseTMinus(TMinus node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TQMark node)
        {
            return CaseTQMark(node);
        }
        public virtual Result CaseTQMark(TQMark node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TStar node)
        {
            return CaseTStar(node);
        }
        public virtual Result CaseTStar(TStar node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TPipe node)
        {
            return CaseTPipe(node);
        }
        public virtual Result CaseTPipe(TPipe node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TComma node)
        {
            return CaseTComma(node);
        }
        public virtual Result CaseTComma(TComma node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TSlash node)
        {
            return CaseTSlash(node);
        }
        public virtual Result CaseTSlash(TSlash node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TArrow node)
        {
            return CaseTArrow(node);
        }
        public virtual Result CaseTArrow(TArrow node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TColon node)
        {
            return CaseTColon(node);
        }
        public virtual Result CaseTColon(TColon node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TIdentifier node)
        {
            return CaseTIdentifier(node);
        }
        public virtual Result CaseTIdentifier(TIdentifier node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TCharacter node)
        {
            return CaseTCharacter(node);
        }
        public virtual Result CaseTCharacter(TCharacter node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TDecChar node)
        {
            return CaseTDecChar(node);
        }
        public virtual Result CaseTDecChar(TDecChar node)
        {
            return DefaultCase(node);
        }
        public Result Visit(THexChar node)
        {
            return CaseTHexChar(node);
        }
        public virtual Result CaseTHexChar(THexChar node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TString node)
        {
            return CaseTString(node);
        }
        public virtual Result CaseTString(TString node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TBlank node)
        {
            return CaseTBlank(node);
        }
        public virtual Result CaseTBlank(TBlank node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TComment node)
        {
            return CaseTComment(node);
        }
        public virtual Result CaseTComment(TComment node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TItalic node)
        {
            return CaseTItalic(node);
        }
        public virtual Result CaseTItalic(TItalic node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TBold node)
        {
            return CaseTBold(node);
        }
        public virtual Result CaseTBold(TBold node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TText node)
        {
            return CaseTText(node);
        }
        public virtual Result CaseTText(TText node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TBackground node)
        {
            return CaseTBackground(node);
        }
        public virtual Result CaseTBackground(TBackground node)
        {
            return DefaultCase(node);
        }
        public Result Visit(TRgb node)
        {
            return CaseTRgb(node);
        }
        public virtual Result CaseTRgb(TRgb node)
        {
            return DefaultCase(node);
        }
        public Result Visit(THsv node)
        {
            return CaseTHsv(node);
        }
        public virtual Result CaseTHsv(THsv node)
        {
            return DefaultCase(node);
        }
        public Result Visit(THexColor node)
        {
            return CaseTHexColor(node);
        }
        public virtual Result CaseTHexColor(THexColor node)
        {
            return DefaultCase(node);
        }
    }
    public class ReturnAnalysisAdapter<T1, Result> : ReturnAdapter<T1, Result, PGrammar>
    {
        public override Result Visit(Node node, T1 arg1)
        {
            return Visit((dynamic)node, arg1);
        }
        
        public Result Visit(AGrammar node, T1 arg1)
        {
            return CaseAGrammar(node, arg1);
        }
        public virtual Result CaseAGrammar(AGrammar node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ASectionGrammar node, T1 arg1)
        {
            return CaseASectionGrammar(node, arg1);
        }
        public virtual Result CaseASectionGrammar(ASectionGrammar node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(APackageSection node, T1 arg1)
        {
            return CaseAPackageSection(node, arg1);
        }
        public virtual Result CaseAPackageSection(APackageSection node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AHelpersSection node, T1 arg1)
        {
            return CaseAHelpersSection(node, arg1);
        }
        public virtual Result CaseAHelpersSection(AHelpersSection node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AStatesSection node, T1 arg1)
        {
            return CaseAStatesSection(node, arg1);
        }
        public virtual Result CaseAStatesSection(AStatesSection node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ATokensSection node, T1 arg1)
        {
            return CaseATokensSection(node, arg1);
        }
        public virtual Result CaseATokensSection(ATokensSection node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AIgnoreSection node, T1 arg1)
        {
            return CaseAIgnoreSection(node, arg1);
        }
        public virtual Result CaseAIgnoreSection(AIgnoreSection node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AProductionsSection node, T1 arg1)
        {
            return CaseAProductionsSection(node, arg1);
        }
        public virtual Result CaseAProductionsSection(AProductionsSection node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AASTSection node, T1 arg1)
        {
            return CaseAASTSection(node, arg1);
        }
        public virtual Result CaseAASTSection(AASTSection node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AHighlightSection node, T1 arg1)
        {
            return CaseAHighlightSection(node, arg1);
        }
        public virtual Result CaseAHighlightSection(AHighlightSection node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(APackage node, T1 arg1)
        {
            return CaseAPackage(node, arg1);
        }
        public virtual Result CaseAPackage(APackage node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AHelpers node, T1 arg1)
        {
            return CaseAHelpers(node, arg1);
        }
        public virtual Result CaseAHelpers(AHelpers node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AHelper node, T1 arg1)
        {
            return CaseAHelper(node, arg1);
        }
        public virtual Result CaseAHelper(AHelper node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ATokens node, T1 arg1)
        {
            return CaseATokens(node, arg1);
        }
        public virtual Result CaseATokens(ATokens node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AToken node, T1 arg1)
        {
            return CaseAToken(node, arg1);
        }
        public virtual Result CaseAToken(AToken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ATokenlookahead node, T1 arg1)
        {
            return CaseATokenlookahead(node, arg1);
        }
        public virtual Result CaseATokenlookahead(ATokenlookahead node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ACharRegex node, T1 arg1)
        {
            return CaseACharRegex(node, arg1);
        }
        public virtual Result CaseACharRegex(ACharRegex node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ADecRegex node, T1 arg1)
        {
            return CaseADecRegex(node, arg1);
        }
        public virtual Result CaseADecRegex(ADecRegex node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AHexRegex node, T1 arg1)
        {
            return CaseAHexRegex(node, arg1);
        }
        public virtual Result CaseAHexRegex(AHexRegex node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AConcatenatedRegex node, T1 arg1)
        {
            return CaseAConcatenatedRegex(node, arg1);
        }
        public virtual Result CaseAConcatenatedRegex(AConcatenatedRegex node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AUnaryRegex node, T1 arg1)
        {
            return CaseAUnaryRegex(node, arg1);
        }
        public virtual Result CaseAUnaryRegex(AUnaryRegex node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ABinaryplusRegex node, T1 arg1)
        {
            return CaseABinaryplusRegex(node, arg1);
        }
        public virtual Result CaseABinaryplusRegex(ABinaryplusRegex node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ABinaryminusRegex node, T1 arg1)
        {
            return CaseABinaryminusRegex(node, arg1);
        }
        public virtual Result CaseABinaryminusRegex(ABinaryminusRegex node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AIntervalRegex node, T1 arg1)
        {
            return CaseAIntervalRegex(node, arg1);
        }
        public virtual Result CaseAIntervalRegex(AIntervalRegex node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AStringRegex node, T1 arg1)
        {
            return CaseAStringRegex(node, arg1);
        }
        public virtual Result CaseAStringRegex(AStringRegex node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AIdentifierRegex node, T1 arg1)
        {
            return CaseAIdentifierRegex(node, arg1);
        }
        public virtual Result CaseAIdentifierRegex(AIdentifierRegex node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AParenthesisRegex node, T1 arg1)
        {
            return CaseAParenthesisRegex(node, arg1);
        }
        public virtual Result CaseAParenthesisRegex(AParenthesisRegex node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AOrRegex node, T1 arg1)
        {
            return CaseAOrRegex(node, arg1);
        }
        public virtual Result CaseAOrRegex(AOrRegex node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AStarModifier node, T1 arg1)
        {
            return CaseAStarModifier(node, arg1);
        }
        public virtual Result CaseAStarModifier(AStarModifier node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AQuestionModifier node, T1 arg1)
        {
            return CaseAQuestionModifier(node, arg1);
        }
        public virtual Result CaseAQuestionModifier(AQuestionModifier node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(APlusModifier node, T1 arg1)
        {
            return CaseAPlusModifier(node, arg1);
        }
        public virtual Result CaseAPlusModifier(APlusModifier node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AStates node, T1 arg1)
        {
            return CaseAStates(node, arg1);
        }
        public virtual Result CaseAStates(AStates node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AIgnoredtokens node, T1 arg1)
        {
            return CaseAIgnoredtokens(node, arg1);
        }
        public virtual Result CaseAIgnoredtokens(AIgnoredtokens node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ATokenstateList node, T1 arg1)
        {
            return CaseATokenstateList(node, arg1);
        }
        public virtual Result CaseATokenstateList(ATokenstateList node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ATokenstateListitem node, T1 arg1)
        {
            return CaseATokenstateListitem(node, arg1);
        }
        public virtual Result CaseATokenstateListitem(ATokenstateListitem node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ATransitionTokenstateListitem node, T1 arg1)
        {
            return CaseATransitionTokenstateListitem(node, arg1);
        }
        public virtual Result CaseATransitionTokenstateListitem(ATransitionTokenstateListitem node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ATranslationListitem node, T1 arg1)
        {
            return CaseATranslationListitem(node, arg1);
        }
        public virtual Result CaseATranslationListitem(ATranslationListitem node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AProductions node, T1 arg1)
        {
            return CaseAProductions(node, arg1);
        }
        public virtual Result CaseAProductions(AProductions node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AAstproductions node, T1 arg1)
        {
            return CaseAAstproductions(node, arg1);
        }
        public virtual Result CaseAAstproductions(AAstproductions node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AProduction node, T1 arg1)
        {
            return CaseAProduction(node, arg1);
        }
        public virtual Result CaseAProduction(AProduction node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AProdtranslation node, T1 arg1)
        {
            return CaseAProdtranslation(node, arg1);
        }
        public virtual Result CaseAProdtranslation(AProdtranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AFullTranslation node, T1 arg1)
        {
            return CaseAFullTranslation(node, arg1);
        }
        public virtual Result CaseAFullTranslation(AFullTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ANewTranslation node, T1 arg1)
        {
            return CaseANewTranslation(node, arg1);
        }
        public virtual Result CaseANewTranslation(ANewTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ANewalternativeTranslation node, T1 arg1)
        {
            return CaseANewalternativeTranslation(node, arg1);
        }
        public virtual Result CaseANewalternativeTranslation(ANewalternativeTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AListTranslation node, T1 arg1)
        {
            return CaseAListTranslation(node, arg1);
        }
        public virtual Result CaseAListTranslation(AListTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ANullTranslation node, T1 arg1)
        {
            return CaseANullTranslation(node, arg1);
        }
        public virtual Result CaseANullTranslation(ANullTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AIdTranslation node, T1 arg1)
        {
            return CaseAIdTranslation(node, arg1);
        }
        public virtual Result CaseAIdTranslation(AIdTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AIddotidTranslation node, T1 arg1)
        {
            return CaseAIddotidTranslation(node, arg1);
        }
        public virtual Result CaseAIddotidTranslation(AIddotidTranslation node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AAlternative node, T1 arg1)
        {
            return CaseAAlternative(node, arg1);
        }
        public virtual Result CaseAAlternative(AAlternative node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AAlternativename node, T1 arg1)
        {
            return CaseAAlternativename(node, arg1);
        }
        public virtual Result CaseAAlternativename(AAlternativename node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AElement node, T1 arg1)
        {
            return CaseAElement(node, arg1);
        }
        public virtual Result CaseAElement(AElement node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AElementname node, T1 arg1)
        {
            return CaseAElementname(node, arg1);
        }
        public virtual Result CaseAElementname(AElementname node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ACleanElementid node, T1 arg1)
        {
            return CaseACleanElementid(node, arg1);
        }
        public virtual Result CaseACleanElementid(ACleanElementid node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ATokenElementid node, T1 arg1)
        {
            return CaseATokenElementid(node, arg1);
        }
        public virtual Result CaseATokenElementid(ATokenElementid node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AProductionElementid node, T1 arg1)
        {
            return CaseAProductionElementid(node, arg1);
        }
        public virtual Result CaseAProductionElementid(AProductionElementid node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AHighlightrules node, T1 arg1)
        {
            return CaseAHighlightrules(node, arg1);
        }
        public virtual Result CaseAHighlightrules(AHighlightrules node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AHighlightrule node, T1 arg1)
        {
            return CaseAHighlightrule(node, arg1);
        }
        public virtual Result CaseAHighlightrule(AHighlightrule node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AItalicHighlightStyle node, T1 arg1)
        {
            return CaseAItalicHighlightStyle(node, arg1);
        }
        public virtual Result CaseAItalicHighlightStyle(AItalicHighlightStyle node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ABoldHighlightStyle node, T1 arg1)
        {
            return CaseABoldHighlightStyle(node, arg1);
        }
        public virtual Result CaseABoldHighlightStyle(ABoldHighlightStyle node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ATextHighlightStyle node, T1 arg1)
        {
            return CaseATextHighlightStyle(node, arg1);
        }
        public virtual Result CaseATextHighlightStyle(ATextHighlightStyle node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ABackgroundHighlightStyle node, T1 arg1)
        {
            return CaseABackgroundHighlightStyle(node, arg1);
        }
        public virtual Result CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(ARgbColor node, T1 arg1)
        {
            return CaseARgbColor(node, arg1);
        }
        public virtual Result CaseARgbColor(ARgbColor node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AHsvColor node, T1 arg1)
        {
            return CaseAHsvColor(node, arg1);
        }
        public virtual Result CaseAHsvColor(AHsvColor node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(AHexColor node, T1 arg1)
        {
            return CaseAHexColor(node, arg1);
        }
        public virtual Result CaseAHexColor(AHexColor node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TPackagename node, T1 arg1)
        {
            return CaseTPackagename(node, arg1);
        }
        public virtual Result CaseTPackagename(TPackagename node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TPackagetoken node, T1 arg1)
        {
            return CaseTPackagetoken(node, arg1);
        }
        public virtual Result CaseTPackagetoken(TPackagetoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TStatestoken node, T1 arg1)
        {
            return CaseTStatestoken(node, arg1);
        }
        public virtual Result CaseTStatestoken(TStatestoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(THelperstoken node, T1 arg1)
        {
            return CaseTHelperstoken(node, arg1);
        }
        public virtual Result CaseTHelperstoken(THelperstoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TTokenstoken node, T1 arg1)
        {
            return CaseTTokenstoken(node, arg1);
        }
        public virtual Result CaseTTokenstoken(TTokenstoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TIgnoredtoken node, T1 arg1)
        {
            return CaseTIgnoredtoken(node, arg1);
        }
        public virtual Result CaseTIgnoredtoken(TIgnoredtoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TProductionstoken node, T1 arg1)
        {
            return CaseTProductionstoken(node, arg1);
        }
        public virtual Result CaseTProductionstoken(TProductionstoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TAsttoken node, T1 arg1)
        {
            return CaseTAsttoken(node, arg1);
        }
        public virtual Result CaseTAsttoken(TAsttoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(THighlighttoken node, T1 arg1)
        {
            return CaseTHighlighttoken(node, arg1);
        }
        public virtual Result CaseTHighlighttoken(THighlighttoken node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TNew node, T1 arg1)
        {
            return CaseTNew(node, arg1);
        }
        public virtual Result CaseTNew(TNew node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TNull node, T1 arg1)
        {
            return CaseTNull(node, arg1);
        }
        public virtual Result CaseTNull(TNull node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TTokenSpecifier node, T1 arg1)
        {
            return CaseTTokenSpecifier(node, arg1);
        }
        public virtual Result CaseTTokenSpecifier(TTokenSpecifier node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TProductionSpecifier node, T1 arg1)
        {
            return CaseTProductionSpecifier(node, arg1);
        }
        public virtual Result CaseTProductionSpecifier(TProductionSpecifier node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TDot node, T1 arg1)
        {
            return CaseTDot(node, arg1);
        }
        public virtual Result CaseTDot(TDot node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TDDot node, T1 arg1)
        {
            return CaseTDDot(node, arg1);
        }
        public virtual Result CaseTDDot(TDDot node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TSemicolon node, T1 arg1)
        {
            return CaseTSemicolon(node, arg1);
        }
        public virtual Result CaseTSemicolon(TSemicolon node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TEqual node, T1 arg1)
        {
            return CaseTEqual(node, arg1);
        }
        public virtual Result CaseTEqual(TEqual node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TLBkt node, T1 arg1)
        {
            return CaseTLBkt(node, arg1);
        }
        public virtual Result CaseTLBkt(TLBkt node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TRBkt node, T1 arg1)
        {
            return CaseTRBkt(node, arg1);
        }
        public virtual Result CaseTRBkt(TRBkt node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TLPar node, T1 arg1)
        {
            return CaseTLPar(node, arg1);
        }
        public virtual Result CaseTLPar(TLPar node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TRPar node, T1 arg1)
        {
            return CaseTRPar(node, arg1);
        }
        public virtual Result CaseTRPar(TRPar node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TLBrace node, T1 arg1)
        {
            return CaseTLBrace(node, arg1);
        }
        public virtual Result CaseTLBrace(TLBrace node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TRBrace node, T1 arg1)
        {
            return CaseTRBrace(node, arg1);
        }
        public virtual Result CaseTRBrace(TRBrace node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TPlus node, T1 arg1)
        {
            return CaseTPlus(node, arg1);
        }
        public virtual Result CaseTPlus(TPlus node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TMinus node, T1 arg1)
        {
            return CaseTMinus(node, arg1);
        }
        public virtual Result CaseTMinus(TMinus node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TQMark node, T1 arg1)
        {
            return CaseTQMark(node, arg1);
        }
        public virtual Result CaseTQMark(TQMark node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TStar node, T1 arg1)
        {
            return CaseTStar(node, arg1);
        }
        public virtual Result CaseTStar(TStar node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TPipe node, T1 arg1)
        {
            return CaseTPipe(node, arg1);
        }
        public virtual Result CaseTPipe(TPipe node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TComma node, T1 arg1)
        {
            return CaseTComma(node, arg1);
        }
        public virtual Result CaseTComma(TComma node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TSlash node, T1 arg1)
        {
            return CaseTSlash(node, arg1);
        }
        public virtual Result CaseTSlash(TSlash node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TArrow node, T1 arg1)
        {
            return CaseTArrow(node, arg1);
        }
        public virtual Result CaseTArrow(TArrow node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TColon node, T1 arg1)
        {
            return CaseTColon(node, arg1);
        }
        public virtual Result CaseTColon(TColon node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TIdentifier node, T1 arg1)
        {
            return CaseTIdentifier(node, arg1);
        }
        public virtual Result CaseTIdentifier(TIdentifier node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TCharacter node, T1 arg1)
        {
            return CaseTCharacter(node, arg1);
        }
        public virtual Result CaseTCharacter(TCharacter node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TDecChar node, T1 arg1)
        {
            return CaseTDecChar(node, arg1);
        }
        public virtual Result CaseTDecChar(TDecChar node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(THexChar node, T1 arg1)
        {
            return CaseTHexChar(node, arg1);
        }
        public virtual Result CaseTHexChar(THexChar node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TString node, T1 arg1)
        {
            return CaseTString(node, arg1);
        }
        public virtual Result CaseTString(TString node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TBlank node, T1 arg1)
        {
            return CaseTBlank(node, arg1);
        }
        public virtual Result CaseTBlank(TBlank node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TComment node, T1 arg1)
        {
            return CaseTComment(node, arg1);
        }
        public virtual Result CaseTComment(TComment node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TItalic node, T1 arg1)
        {
            return CaseTItalic(node, arg1);
        }
        public virtual Result CaseTItalic(TItalic node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TBold node, T1 arg1)
        {
            return CaseTBold(node, arg1);
        }
        public virtual Result CaseTBold(TBold node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TText node, T1 arg1)
        {
            return CaseTText(node, arg1);
        }
        public virtual Result CaseTText(TText node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TBackground node, T1 arg1)
        {
            return CaseTBackground(node, arg1);
        }
        public virtual Result CaseTBackground(TBackground node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(TRgb node, T1 arg1)
        {
            return CaseTRgb(node, arg1);
        }
        public virtual Result CaseTRgb(TRgb node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(THsv node, T1 arg1)
        {
            return CaseTHsv(node, arg1);
        }
        public virtual Result CaseTHsv(THsv node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
        public Result Visit(THexColor node, T1 arg1)
        {
            return CaseTHexColor(node, arg1);
        }
        public virtual Result CaseTHexColor(THexColor node, T1 arg1)
        {
            return DefaultCase(node, arg1);
        }
    }
    public class ReturnAnalysisAdapter<T1, T2, Result> : ReturnAdapter<T1, T2, Result, PGrammar>
    {
        public override Result Visit(Node node, T1 arg1, T2 arg2)
        {
            return Visit((dynamic)node, arg1, arg2);
        }
        
        public Result Visit(AGrammar node, T1 arg1, T2 arg2)
        {
            return CaseAGrammar(node, arg1, arg2);
        }
        public virtual Result CaseAGrammar(AGrammar node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ASectionGrammar node, T1 arg1, T2 arg2)
        {
            return CaseASectionGrammar(node, arg1, arg2);
        }
        public virtual Result CaseASectionGrammar(ASectionGrammar node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(APackageSection node, T1 arg1, T2 arg2)
        {
            return CaseAPackageSection(node, arg1, arg2);
        }
        public virtual Result CaseAPackageSection(APackageSection node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AHelpersSection node, T1 arg1, T2 arg2)
        {
            return CaseAHelpersSection(node, arg1, arg2);
        }
        public virtual Result CaseAHelpersSection(AHelpersSection node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AStatesSection node, T1 arg1, T2 arg2)
        {
            return CaseAStatesSection(node, arg1, arg2);
        }
        public virtual Result CaseAStatesSection(AStatesSection node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ATokensSection node, T1 arg1, T2 arg2)
        {
            return CaseATokensSection(node, arg1, arg2);
        }
        public virtual Result CaseATokensSection(ATokensSection node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AIgnoreSection node, T1 arg1, T2 arg2)
        {
            return CaseAIgnoreSection(node, arg1, arg2);
        }
        public virtual Result CaseAIgnoreSection(AIgnoreSection node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AProductionsSection node, T1 arg1, T2 arg2)
        {
            return CaseAProductionsSection(node, arg1, arg2);
        }
        public virtual Result CaseAProductionsSection(AProductionsSection node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AASTSection node, T1 arg1, T2 arg2)
        {
            return CaseAASTSection(node, arg1, arg2);
        }
        public virtual Result CaseAASTSection(AASTSection node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AHighlightSection node, T1 arg1, T2 arg2)
        {
            return CaseAHighlightSection(node, arg1, arg2);
        }
        public virtual Result CaseAHighlightSection(AHighlightSection node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(APackage node, T1 arg1, T2 arg2)
        {
            return CaseAPackage(node, arg1, arg2);
        }
        public virtual Result CaseAPackage(APackage node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AHelpers node, T1 arg1, T2 arg2)
        {
            return CaseAHelpers(node, arg1, arg2);
        }
        public virtual Result CaseAHelpers(AHelpers node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AHelper node, T1 arg1, T2 arg2)
        {
            return CaseAHelper(node, arg1, arg2);
        }
        public virtual Result CaseAHelper(AHelper node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ATokens node, T1 arg1, T2 arg2)
        {
            return CaseATokens(node, arg1, arg2);
        }
        public virtual Result CaseATokens(ATokens node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AToken node, T1 arg1, T2 arg2)
        {
            return CaseAToken(node, arg1, arg2);
        }
        public virtual Result CaseAToken(AToken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ATokenlookahead node, T1 arg1, T2 arg2)
        {
            return CaseATokenlookahead(node, arg1, arg2);
        }
        public virtual Result CaseATokenlookahead(ATokenlookahead node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ACharRegex node, T1 arg1, T2 arg2)
        {
            return CaseACharRegex(node, arg1, arg2);
        }
        public virtual Result CaseACharRegex(ACharRegex node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ADecRegex node, T1 arg1, T2 arg2)
        {
            return CaseADecRegex(node, arg1, arg2);
        }
        public virtual Result CaseADecRegex(ADecRegex node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AHexRegex node, T1 arg1, T2 arg2)
        {
            return CaseAHexRegex(node, arg1, arg2);
        }
        public virtual Result CaseAHexRegex(AHexRegex node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AConcatenatedRegex node, T1 arg1, T2 arg2)
        {
            return CaseAConcatenatedRegex(node, arg1, arg2);
        }
        public virtual Result CaseAConcatenatedRegex(AConcatenatedRegex node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AUnaryRegex node, T1 arg1, T2 arg2)
        {
            return CaseAUnaryRegex(node, arg1, arg2);
        }
        public virtual Result CaseAUnaryRegex(AUnaryRegex node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ABinaryplusRegex node, T1 arg1, T2 arg2)
        {
            return CaseABinaryplusRegex(node, arg1, arg2);
        }
        public virtual Result CaseABinaryplusRegex(ABinaryplusRegex node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ABinaryminusRegex node, T1 arg1, T2 arg2)
        {
            return CaseABinaryminusRegex(node, arg1, arg2);
        }
        public virtual Result CaseABinaryminusRegex(ABinaryminusRegex node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AIntervalRegex node, T1 arg1, T2 arg2)
        {
            return CaseAIntervalRegex(node, arg1, arg2);
        }
        public virtual Result CaseAIntervalRegex(AIntervalRegex node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AStringRegex node, T1 arg1, T2 arg2)
        {
            return CaseAStringRegex(node, arg1, arg2);
        }
        public virtual Result CaseAStringRegex(AStringRegex node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AIdentifierRegex node, T1 arg1, T2 arg2)
        {
            return CaseAIdentifierRegex(node, arg1, arg2);
        }
        public virtual Result CaseAIdentifierRegex(AIdentifierRegex node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AParenthesisRegex node, T1 arg1, T2 arg2)
        {
            return CaseAParenthesisRegex(node, arg1, arg2);
        }
        public virtual Result CaseAParenthesisRegex(AParenthesisRegex node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AOrRegex node, T1 arg1, T2 arg2)
        {
            return CaseAOrRegex(node, arg1, arg2);
        }
        public virtual Result CaseAOrRegex(AOrRegex node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AStarModifier node, T1 arg1, T2 arg2)
        {
            return CaseAStarModifier(node, arg1, arg2);
        }
        public virtual Result CaseAStarModifier(AStarModifier node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AQuestionModifier node, T1 arg1, T2 arg2)
        {
            return CaseAQuestionModifier(node, arg1, arg2);
        }
        public virtual Result CaseAQuestionModifier(AQuestionModifier node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(APlusModifier node, T1 arg1, T2 arg2)
        {
            return CaseAPlusModifier(node, arg1, arg2);
        }
        public virtual Result CaseAPlusModifier(APlusModifier node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AStates node, T1 arg1, T2 arg2)
        {
            return CaseAStates(node, arg1, arg2);
        }
        public virtual Result CaseAStates(AStates node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AIgnoredtokens node, T1 arg1, T2 arg2)
        {
            return CaseAIgnoredtokens(node, arg1, arg2);
        }
        public virtual Result CaseAIgnoredtokens(AIgnoredtokens node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ATokenstateList node, T1 arg1, T2 arg2)
        {
            return CaseATokenstateList(node, arg1, arg2);
        }
        public virtual Result CaseATokenstateList(ATokenstateList node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ATokenstateListitem node, T1 arg1, T2 arg2)
        {
            return CaseATokenstateListitem(node, arg1, arg2);
        }
        public virtual Result CaseATokenstateListitem(ATokenstateListitem node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ATransitionTokenstateListitem node, T1 arg1, T2 arg2)
        {
            return CaseATransitionTokenstateListitem(node, arg1, arg2);
        }
        public virtual Result CaseATransitionTokenstateListitem(ATransitionTokenstateListitem node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ATranslationListitem node, T1 arg1, T2 arg2)
        {
            return CaseATranslationListitem(node, arg1, arg2);
        }
        public virtual Result CaseATranslationListitem(ATranslationListitem node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AProductions node, T1 arg1, T2 arg2)
        {
            return CaseAProductions(node, arg1, arg2);
        }
        public virtual Result CaseAProductions(AProductions node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AAstproductions node, T1 arg1, T2 arg2)
        {
            return CaseAAstproductions(node, arg1, arg2);
        }
        public virtual Result CaseAAstproductions(AAstproductions node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AProduction node, T1 arg1, T2 arg2)
        {
            return CaseAProduction(node, arg1, arg2);
        }
        public virtual Result CaseAProduction(AProduction node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AProdtranslation node, T1 arg1, T2 arg2)
        {
            return CaseAProdtranslation(node, arg1, arg2);
        }
        public virtual Result CaseAProdtranslation(AProdtranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AFullTranslation node, T1 arg1, T2 arg2)
        {
            return CaseAFullTranslation(node, arg1, arg2);
        }
        public virtual Result CaseAFullTranslation(AFullTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ANewTranslation node, T1 arg1, T2 arg2)
        {
            return CaseANewTranslation(node, arg1, arg2);
        }
        public virtual Result CaseANewTranslation(ANewTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ANewalternativeTranslation node, T1 arg1, T2 arg2)
        {
            return CaseANewalternativeTranslation(node, arg1, arg2);
        }
        public virtual Result CaseANewalternativeTranslation(ANewalternativeTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AListTranslation node, T1 arg1, T2 arg2)
        {
            return CaseAListTranslation(node, arg1, arg2);
        }
        public virtual Result CaseAListTranslation(AListTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ANullTranslation node, T1 arg1, T2 arg2)
        {
            return CaseANullTranslation(node, arg1, arg2);
        }
        public virtual Result CaseANullTranslation(ANullTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AIdTranslation node, T1 arg1, T2 arg2)
        {
            return CaseAIdTranslation(node, arg1, arg2);
        }
        public virtual Result CaseAIdTranslation(AIdTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AIddotidTranslation node, T1 arg1, T2 arg2)
        {
            return CaseAIddotidTranslation(node, arg1, arg2);
        }
        public virtual Result CaseAIddotidTranslation(AIddotidTranslation node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AAlternative node, T1 arg1, T2 arg2)
        {
            return CaseAAlternative(node, arg1, arg2);
        }
        public virtual Result CaseAAlternative(AAlternative node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AAlternativename node, T1 arg1, T2 arg2)
        {
            return CaseAAlternativename(node, arg1, arg2);
        }
        public virtual Result CaseAAlternativename(AAlternativename node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AElement node, T1 arg1, T2 arg2)
        {
            return CaseAElement(node, arg1, arg2);
        }
        public virtual Result CaseAElement(AElement node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AElementname node, T1 arg1, T2 arg2)
        {
            return CaseAElementname(node, arg1, arg2);
        }
        public virtual Result CaseAElementname(AElementname node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ACleanElementid node, T1 arg1, T2 arg2)
        {
            return CaseACleanElementid(node, arg1, arg2);
        }
        public virtual Result CaseACleanElementid(ACleanElementid node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ATokenElementid node, T1 arg1, T2 arg2)
        {
            return CaseATokenElementid(node, arg1, arg2);
        }
        public virtual Result CaseATokenElementid(ATokenElementid node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AProductionElementid node, T1 arg1, T2 arg2)
        {
            return CaseAProductionElementid(node, arg1, arg2);
        }
        public virtual Result CaseAProductionElementid(AProductionElementid node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AHighlightrules node, T1 arg1, T2 arg2)
        {
            return CaseAHighlightrules(node, arg1, arg2);
        }
        public virtual Result CaseAHighlightrules(AHighlightrules node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AHighlightrule node, T1 arg1, T2 arg2)
        {
            return CaseAHighlightrule(node, arg1, arg2);
        }
        public virtual Result CaseAHighlightrule(AHighlightrule node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AItalicHighlightStyle node, T1 arg1, T2 arg2)
        {
            return CaseAItalicHighlightStyle(node, arg1, arg2);
        }
        public virtual Result CaseAItalicHighlightStyle(AItalicHighlightStyle node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ABoldHighlightStyle node, T1 arg1, T2 arg2)
        {
            return CaseABoldHighlightStyle(node, arg1, arg2);
        }
        public virtual Result CaseABoldHighlightStyle(ABoldHighlightStyle node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ATextHighlightStyle node, T1 arg1, T2 arg2)
        {
            return CaseATextHighlightStyle(node, arg1, arg2);
        }
        public virtual Result CaseATextHighlightStyle(ATextHighlightStyle node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ABackgroundHighlightStyle node, T1 arg1, T2 arg2)
        {
            return CaseABackgroundHighlightStyle(node, arg1, arg2);
        }
        public virtual Result CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(ARgbColor node, T1 arg1, T2 arg2)
        {
            return CaseARgbColor(node, arg1, arg2);
        }
        public virtual Result CaseARgbColor(ARgbColor node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AHsvColor node, T1 arg1, T2 arg2)
        {
            return CaseAHsvColor(node, arg1, arg2);
        }
        public virtual Result CaseAHsvColor(AHsvColor node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(AHexColor node, T1 arg1, T2 arg2)
        {
            return CaseAHexColor(node, arg1, arg2);
        }
        public virtual Result CaseAHexColor(AHexColor node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TPackagename node, T1 arg1, T2 arg2)
        {
            return CaseTPackagename(node, arg1, arg2);
        }
        public virtual Result CaseTPackagename(TPackagename node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TPackagetoken node, T1 arg1, T2 arg2)
        {
            return CaseTPackagetoken(node, arg1, arg2);
        }
        public virtual Result CaseTPackagetoken(TPackagetoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TStatestoken node, T1 arg1, T2 arg2)
        {
            return CaseTStatestoken(node, arg1, arg2);
        }
        public virtual Result CaseTStatestoken(TStatestoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(THelperstoken node, T1 arg1, T2 arg2)
        {
            return CaseTHelperstoken(node, arg1, arg2);
        }
        public virtual Result CaseTHelperstoken(THelperstoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TTokenstoken node, T1 arg1, T2 arg2)
        {
            return CaseTTokenstoken(node, arg1, arg2);
        }
        public virtual Result CaseTTokenstoken(TTokenstoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TIgnoredtoken node, T1 arg1, T2 arg2)
        {
            return CaseTIgnoredtoken(node, arg1, arg2);
        }
        public virtual Result CaseTIgnoredtoken(TIgnoredtoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TProductionstoken node, T1 arg1, T2 arg2)
        {
            return CaseTProductionstoken(node, arg1, arg2);
        }
        public virtual Result CaseTProductionstoken(TProductionstoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TAsttoken node, T1 arg1, T2 arg2)
        {
            return CaseTAsttoken(node, arg1, arg2);
        }
        public virtual Result CaseTAsttoken(TAsttoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(THighlighttoken node, T1 arg1, T2 arg2)
        {
            return CaseTHighlighttoken(node, arg1, arg2);
        }
        public virtual Result CaseTHighlighttoken(THighlighttoken node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TNew node, T1 arg1, T2 arg2)
        {
            return CaseTNew(node, arg1, arg2);
        }
        public virtual Result CaseTNew(TNew node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TNull node, T1 arg1, T2 arg2)
        {
            return CaseTNull(node, arg1, arg2);
        }
        public virtual Result CaseTNull(TNull node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TTokenSpecifier node, T1 arg1, T2 arg2)
        {
            return CaseTTokenSpecifier(node, arg1, arg2);
        }
        public virtual Result CaseTTokenSpecifier(TTokenSpecifier node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TProductionSpecifier node, T1 arg1, T2 arg2)
        {
            return CaseTProductionSpecifier(node, arg1, arg2);
        }
        public virtual Result CaseTProductionSpecifier(TProductionSpecifier node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TDot node, T1 arg1, T2 arg2)
        {
            return CaseTDot(node, arg1, arg2);
        }
        public virtual Result CaseTDot(TDot node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TDDot node, T1 arg1, T2 arg2)
        {
            return CaseTDDot(node, arg1, arg2);
        }
        public virtual Result CaseTDDot(TDDot node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TSemicolon node, T1 arg1, T2 arg2)
        {
            return CaseTSemicolon(node, arg1, arg2);
        }
        public virtual Result CaseTSemicolon(TSemicolon node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TEqual node, T1 arg1, T2 arg2)
        {
            return CaseTEqual(node, arg1, arg2);
        }
        public virtual Result CaseTEqual(TEqual node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TLBkt node, T1 arg1, T2 arg2)
        {
            return CaseTLBkt(node, arg1, arg2);
        }
        public virtual Result CaseTLBkt(TLBkt node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TRBkt node, T1 arg1, T2 arg2)
        {
            return CaseTRBkt(node, arg1, arg2);
        }
        public virtual Result CaseTRBkt(TRBkt node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TLPar node, T1 arg1, T2 arg2)
        {
            return CaseTLPar(node, arg1, arg2);
        }
        public virtual Result CaseTLPar(TLPar node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TRPar node, T1 arg1, T2 arg2)
        {
            return CaseTRPar(node, arg1, arg2);
        }
        public virtual Result CaseTRPar(TRPar node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TLBrace node, T1 arg1, T2 arg2)
        {
            return CaseTLBrace(node, arg1, arg2);
        }
        public virtual Result CaseTLBrace(TLBrace node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TRBrace node, T1 arg1, T2 arg2)
        {
            return CaseTRBrace(node, arg1, arg2);
        }
        public virtual Result CaseTRBrace(TRBrace node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TPlus node, T1 arg1, T2 arg2)
        {
            return CaseTPlus(node, arg1, arg2);
        }
        public virtual Result CaseTPlus(TPlus node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TMinus node, T1 arg1, T2 arg2)
        {
            return CaseTMinus(node, arg1, arg2);
        }
        public virtual Result CaseTMinus(TMinus node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TQMark node, T1 arg1, T2 arg2)
        {
            return CaseTQMark(node, arg1, arg2);
        }
        public virtual Result CaseTQMark(TQMark node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TStar node, T1 arg1, T2 arg2)
        {
            return CaseTStar(node, arg1, arg2);
        }
        public virtual Result CaseTStar(TStar node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TPipe node, T1 arg1, T2 arg2)
        {
            return CaseTPipe(node, arg1, arg2);
        }
        public virtual Result CaseTPipe(TPipe node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TComma node, T1 arg1, T2 arg2)
        {
            return CaseTComma(node, arg1, arg2);
        }
        public virtual Result CaseTComma(TComma node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TSlash node, T1 arg1, T2 arg2)
        {
            return CaseTSlash(node, arg1, arg2);
        }
        public virtual Result CaseTSlash(TSlash node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TArrow node, T1 arg1, T2 arg2)
        {
            return CaseTArrow(node, arg1, arg2);
        }
        public virtual Result CaseTArrow(TArrow node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TColon node, T1 arg1, T2 arg2)
        {
            return CaseTColon(node, arg1, arg2);
        }
        public virtual Result CaseTColon(TColon node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TIdentifier node, T1 arg1, T2 arg2)
        {
            return CaseTIdentifier(node, arg1, arg2);
        }
        public virtual Result CaseTIdentifier(TIdentifier node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TCharacter node, T1 arg1, T2 arg2)
        {
            return CaseTCharacter(node, arg1, arg2);
        }
        public virtual Result CaseTCharacter(TCharacter node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TDecChar node, T1 arg1, T2 arg2)
        {
            return CaseTDecChar(node, arg1, arg2);
        }
        public virtual Result CaseTDecChar(TDecChar node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(THexChar node, T1 arg1, T2 arg2)
        {
            return CaseTHexChar(node, arg1, arg2);
        }
        public virtual Result CaseTHexChar(THexChar node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TString node, T1 arg1, T2 arg2)
        {
            return CaseTString(node, arg1, arg2);
        }
        public virtual Result CaseTString(TString node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TBlank node, T1 arg1, T2 arg2)
        {
            return CaseTBlank(node, arg1, arg2);
        }
        public virtual Result CaseTBlank(TBlank node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TComment node, T1 arg1, T2 arg2)
        {
            return CaseTComment(node, arg1, arg2);
        }
        public virtual Result CaseTComment(TComment node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TItalic node, T1 arg1, T2 arg2)
        {
            return CaseTItalic(node, arg1, arg2);
        }
        public virtual Result CaseTItalic(TItalic node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TBold node, T1 arg1, T2 arg2)
        {
            return CaseTBold(node, arg1, arg2);
        }
        public virtual Result CaseTBold(TBold node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TText node, T1 arg1, T2 arg2)
        {
            return CaseTText(node, arg1, arg2);
        }
        public virtual Result CaseTText(TText node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TBackground node, T1 arg1, T2 arg2)
        {
            return CaseTBackground(node, arg1, arg2);
        }
        public virtual Result CaseTBackground(TBackground node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(TRgb node, T1 arg1, T2 arg2)
        {
            return CaseTRgb(node, arg1, arg2);
        }
        public virtual Result CaseTRgb(TRgb node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(THsv node, T1 arg1, T2 arg2)
        {
            return CaseTHsv(node, arg1, arg2);
        }
        public virtual Result CaseTHsv(THsv node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
        public Result Visit(THexColor node, T1 arg1, T2 arg2)
        {
            return CaseTHexColor(node, arg1, arg2);
        }
        public virtual Result CaseTHexColor(THexColor node, T1 arg1, T2 arg2)
        {
            return DefaultCase(node, arg1, arg2);
        }
    }
    public class ReturnAnalysisAdapter<T1, T2, T3, Result> : ReturnAdapter<T1, T2, T3, Result, PGrammar>
    {
        public override Result Visit(Node node, T1 arg1, T2 arg2, T3 arg3)
        {
            return Visit((dynamic)node, arg1, arg2, arg3);
        }
        
        public Result Visit(AGrammar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAGrammar(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAGrammar(AGrammar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ASectionGrammar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseASectionGrammar(node, arg1, arg2, arg3);
        }
        public virtual Result CaseASectionGrammar(ASectionGrammar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(APackageSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAPackageSection(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAPackageSection(APackageSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AHelpersSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHelpersSection(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAHelpersSection(AHelpersSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AStatesSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAStatesSection(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAStatesSection(AStatesSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ATokensSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATokensSection(node, arg1, arg2, arg3);
        }
        public virtual Result CaseATokensSection(ATokensSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AIgnoreSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAIgnoreSection(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAIgnoreSection(AIgnoreSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AProductionsSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAProductionsSection(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAProductionsSection(AProductionsSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AASTSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAASTSection(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAASTSection(AASTSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AHighlightSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHighlightSection(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAHighlightSection(AHighlightSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(APackage node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAPackage(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAPackage(APackage node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AHelpers node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHelpers(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAHelpers(AHelpers node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AHelper node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHelper(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAHelper(AHelper node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ATokens node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATokens(node, arg1, arg2, arg3);
        }
        public virtual Result CaseATokens(ATokens node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AToken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAToken(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAToken(AToken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ATokenlookahead node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATokenlookahead(node, arg1, arg2, arg3);
        }
        public virtual Result CaseATokenlookahead(ATokenlookahead node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ACharRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseACharRegex(node, arg1, arg2, arg3);
        }
        public virtual Result CaseACharRegex(ACharRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ADecRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseADecRegex(node, arg1, arg2, arg3);
        }
        public virtual Result CaseADecRegex(ADecRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AHexRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHexRegex(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAHexRegex(AHexRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AConcatenatedRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAConcatenatedRegex(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAConcatenatedRegex(AConcatenatedRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AUnaryRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAUnaryRegex(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAUnaryRegex(AUnaryRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ABinaryplusRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseABinaryplusRegex(node, arg1, arg2, arg3);
        }
        public virtual Result CaseABinaryplusRegex(ABinaryplusRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ABinaryminusRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseABinaryminusRegex(node, arg1, arg2, arg3);
        }
        public virtual Result CaseABinaryminusRegex(ABinaryminusRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AIntervalRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAIntervalRegex(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAIntervalRegex(AIntervalRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AStringRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAStringRegex(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAStringRegex(AStringRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AIdentifierRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAIdentifierRegex(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAIdentifierRegex(AIdentifierRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AParenthesisRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAParenthesisRegex(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAParenthesisRegex(AParenthesisRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AOrRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAOrRegex(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAOrRegex(AOrRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AStarModifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAStarModifier(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAStarModifier(AStarModifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AQuestionModifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAQuestionModifier(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAQuestionModifier(AQuestionModifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(APlusModifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAPlusModifier(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAPlusModifier(APlusModifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AStates node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAStates(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAStates(AStates node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AIgnoredtokens node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAIgnoredtokens(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAIgnoredtokens(AIgnoredtokens node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ATokenstateList node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATokenstateList(node, arg1, arg2, arg3);
        }
        public virtual Result CaseATokenstateList(ATokenstateList node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ATokenstateListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATokenstateListitem(node, arg1, arg2, arg3);
        }
        public virtual Result CaseATokenstateListitem(ATokenstateListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ATransitionTokenstateListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATransitionTokenstateListitem(node, arg1, arg2, arg3);
        }
        public virtual Result CaseATransitionTokenstateListitem(ATransitionTokenstateListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ATranslationListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATranslationListitem(node, arg1, arg2, arg3);
        }
        public virtual Result CaseATranslationListitem(ATranslationListitem node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AProductions node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAProductions(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAProductions(AProductions node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AAstproductions node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAAstproductions(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAAstproductions(AAstproductions node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AProduction node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAProduction(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAProduction(AProduction node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AProdtranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAProdtranslation(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAProdtranslation(AProdtranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AFullTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAFullTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAFullTranslation(AFullTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ANewTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseANewTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result CaseANewTranslation(ANewTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ANewalternativeTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseANewalternativeTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result CaseANewalternativeTranslation(ANewalternativeTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AListTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAListTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAListTranslation(AListTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ANullTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseANullTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result CaseANullTranslation(ANullTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AIdTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAIdTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAIdTranslation(AIdTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AIddotidTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAIddotidTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAIddotidTranslation(AIddotidTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AAlternative node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAAlternative(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAAlternative(AAlternative node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AAlternativename node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAAlternativename(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAAlternativename(AAlternativename node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AElement node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAElement(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAElement(AElement node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AElementname node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAElementname(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAElementname(AElementname node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ACleanElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseACleanElementid(node, arg1, arg2, arg3);
        }
        public virtual Result CaseACleanElementid(ACleanElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ATokenElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATokenElementid(node, arg1, arg2, arg3);
        }
        public virtual Result CaseATokenElementid(ATokenElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AProductionElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAProductionElementid(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAProductionElementid(AProductionElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AHighlightrules node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHighlightrules(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAHighlightrules(AHighlightrules node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AHighlightrule node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHighlightrule(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAHighlightrule(AHighlightrule node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AItalicHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAItalicHighlightStyle(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAItalicHighlightStyle(AItalicHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ABoldHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseABoldHighlightStyle(node, arg1, arg2, arg3);
        }
        public virtual Result CaseABoldHighlightStyle(ABoldHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ATextHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseATextHighlightStyle(node, arg1, arg2, arg3);
        }
        public virtual Result CaseATextHighlightStyle(ATextHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ABackgroundHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseABackgroundHighlightStyle(node, arg1, arg2, arg3);
        }
        public virtual Result CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(ARgbColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseARgbColor(node, arg1, arg2, arg3);
        }
        public virtual Result CaseARgbColor(ARgbColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AHsvColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHsvColor(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAHsvColor(AHsvColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(AHexColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseAHexColor(node, arg1, arg2, arg3);
        }
        public virtual Result CaseAHexColor(AHexColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TPackagename node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTPackagename(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTPackagename(TPackagename node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TPackagetoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTPackagetoken(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTPackagetoken(TPackagetoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TStatestoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTStatestoken(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTStatestoken(TStatestoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(THelperstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTHelperstoken(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTHelperstoken(THelperstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TTokenstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTTokenstoken(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTTokenstoken(TTokenstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TIgnoredtoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTIgnoredtoken(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTIgnoredtoken(TIgnoredtoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TProductionstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTProductionstoken(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTProductionstoken(TProductionstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TAsttoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTAsttoken(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTAsttoken(TAsttoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(THighlighttoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTHighlighttoken(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTHighlighttoken(THighlighttoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TNew node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTNew(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTNew(TNew node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TNull node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTNull(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTNull(TNull node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TTokenSpecifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTTokenSpecifier(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTTokenSpecifier(TTokenSpecifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TProductionSpecifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTProductionSpecifier(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTProductionSpecifier(TProductionSpecifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TDot node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTDot(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTDot(TDot node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TDDot node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTDDot(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTDDot(TDDot node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TSemicolon node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTSemicolon(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTSemicolon(TSemicolon node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TEqual node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTEqual(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTEqual(TEqual node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TLBkt node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTLBkt(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTLBkt(TLBkt node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TRBkt node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTRBkt(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTRBkt(TRBkt node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TLPar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTLPar(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTLPar(TLPar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TRPar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTRPar(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTRPar(TRPar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TLBrace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTLBrace(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTLBrace(TLBrace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TRBrace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTRBrace(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTRBrace(TRBrace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TPlus node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTPlus(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTPlus(TPlus node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TMinus node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTMinus(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTMinus(TMinus node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TQMark node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTQMark(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTQMark(TQMark node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TStar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTStar(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTStar(TStar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TPipe node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTPipe(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTPipe(TPipe node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TComma node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTComma(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTComma(TComma node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TSlash node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTSlash(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTSlash(TSlash node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TArrow node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTArrow(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTArrow(TArrow node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TColon node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTColon(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTColon(TColon node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TIdentifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTIdentifier(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTIdentifier(TIdentifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TCharacter node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTCharacter(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTCharacter(TCharacter node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TDecChar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTDecChar(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTDecChar(TDecChar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(THexChar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTHexChar(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTHexChar(THexChar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TString node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTString(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTString(TString node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TBlank node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTBlank(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTBlank(TBlank node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TComment node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTComment(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTComment(TComment node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TItalic node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTItalic(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTItalic(TItalic node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TBold node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTBold(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTBold(TBold node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TText node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTText(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTText(TText node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TBackground node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTBackground(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTBackground(TBackground node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(TRgb node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTRgb(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTRgb(TRgb node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(THsv node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTHsv(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTHsv(THsv node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
        public Result Visit(THexColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return CaseTHexColor(node, arg1, arg2, arg3);
        }
        public virtual Result CaseTHexColor(THexColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return DefaultCase(node, arg1, arg2, arg3);
        }
    }
    
    #endregion
}
