using System.Collections.Generic;
using System.Linq;
using SablePP.Tools.Analysis;
using SablePP.Tools.Nodes;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Analysis
{
    #region Analysis adapters
    
    public partial class AnalysisAdapter : AnalysisAdapter<object>
    {
    }
    public partial class AnalysisAdapter<Value> : Adapter<Value, PGrammar>
    {
        public void Visit(PGrammar node)
        {
            HandlePGrammar(node);
        }
        protected virtual void HandlePGrammar(PGrammar node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AGrammar node)
        {
            HandleAGrammar(node);
        }
        protected virtual void HandleAGrammar(AGrammar node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PSection node)
        {
            HandlePSection(node);
        }
        protected virtual void HandlePSection(PSection node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(ANamespaceSection node)
        {
            HandleANamespaceSection(node);
        }
        protected virtual void HandleANamespaceSection(ANamespaceSection node)
        {
            HandleDefault(node);
        }
        private void dispatch(AHelpersSection node)
        {
            HandleAHelpersSection(node);
        }
        protected virtual void HandleAHelpersSection(AHelpersSection node)
        {
            HandleDefault(node);
        }
        private void dispatch(AStatesSection node)
        {
            HandleAStatesSection(node);
        }
        protected virtual void HandleAStatesSection(AStatesSection node)
        {
            HandleDefault(node);
        }
        private void dispatch(ATokensSection node)
        {
            HandleATokensSection(node);
        }
        protected virtual void HandleATokensSection(ATokensSection node)
        {
            HandleDefault(node);
        }
        private void dispatch(AIgnoreSection node)
        {
            HandleAIgnoreSection(node);
        }
        protected virtual void HandleAIgnoreSection(AIgnoreSection node)
        {
            HandleDefault(node);
        }
        private void dispatch(AProductionsSection node)
        {
            HandleAProductionsSection(node);
        }
        protected virtual void HandleAProductionsSection(AProductionsSection node)
        {
            HandleDefault(node);
        }
        private void dispatch(AASTSection node)
        {
            HandleAASTSection(node);
        }
        protected virtual void HandleAASTSection(AASTSection node)
        {
            HandleDefault(node);
        }
        private void dispatch(AHighlightSection node)
        {
            HandleAHighlightSection(node);
        }
        protected virtual void HandleAHighlightSection(AHighlightSection node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PHelper node)
        {
            HandlePHelper(node);
        }
        protected virtual void HandlePHelper(PHelper node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AHelper node)
        {
            HandleAHelper(node);
        }
        protected virtual void HandleAHelper(AHelper node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PToken node)
        {
            HandlePToken(node);
        }
        protected virtual void HandlePToken(PToken node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AToken node)
        {
            HandleAToken(node);
        }
        protected virtual void HandleAToken(AToken node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PTokenlookahead node)
        {
            HandlePTokenlookahead(node);
        }
        protected virtual void HandlePTokenlookahead(PTokenlookahead node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(ATokenlookahead node)
        {
            HandleATokenlookahead(node);
        }
        protected virtual void HandleATokenlookahead(ATokenlookahead node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PRegex node)
        {
            HandlePRegex(node);
        }
        protected virtual void HandlePRegex(PRegex node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(ACharRegex node)
        {
            HandleACharRegex(node);
        }
        protected virtual void HandleACharRegex(ACharRegex node)
        {
            HandleDefault(node);
        }
        private void dispatch(ADecRegex node)
        {
            HandleADecRegex(node);
        }
        protected virtual void HandleADecRegex(ADecRegex node)
        {
            HandleDefault(node);
        }
        private void dispatch(AHexRegex node)
        {
            HandleAHexRegex(node);
        }
        protected virtual void HandleAHexRegex(AHexRegex node)
        {
            HandleDefault(node);
        }
        private void dispatch(AConcatenatedRegex node)
        {
            HandleAConcatenatedRegex(node);
        }
        protected virtual void HandleAConcatenatedRegex(AConcatenatedRegex node)
        {
            HandleDefault(node);
        }
        private void dispatch(AUnaryRegex node)
        {
            HandleAUnaryRegex(node);
        }
        protected virtual void HandleAUnaryRegex(AUnaryRegex node)
        {
            HandleDefault(node);
        }
        private void dispatch(ABinaryplusRegex node)
        {
            HandleABinaryplusRegex(node);
        }
        protected virtual void HandleABinaryplusRegex(ABinaryplusRegex node)
        {
            HandleDefault(node);
        }
        private void dispatch(ABinaryminusRegex node)
        {
            HandleABinaryminusRegex(node);
        }
        protected virtual void HandleABinaryminusRegex(ABinaryminusRegex node)
        {
            HandleDefault(node);
        }
        private void dispatch(AIntervalRegex node)
        {
            HandleAIntervalRegex(node);
        }
        protected virtual void HandleAIntervalRegex(AIntervalRegex node)
        {
            HandleDefault(node);
        }
        private void dispatch(AStringRegex node)
        {
            HandleAStringRegex(node);
        }
        protected virtual void HandleAStringRegex(AStringRegex node)
        {
            HandleDefault(node);
        }
        private void dispatch(AIdentifierRegex node)
        {
            HandleAIdentifierRegex(node);
        }
        protected virtual void HandleAIdentifierRegex(AIdentifierRegex node)
        {
            HandleDefault(node);
        }
        private void dispatch(AParenthesisRegex node)
        {
            HandleAParenthesisRegex(node);
        }
        protected virtual void HandleAParenthesisRegex(AParenthesisRegex node)
        {
            HandleDefault(node);
        }
        private void dispatch(AOrRegex node)
        {
            HandleAOrRegex(node);
        }
        protected virtual void HandleAOrRegex(AOrRegex node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PModifier node)
        {
            HandlePModifier(node);
        }
        protected virtual void HandlePModifier(PModifier node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AStarModifier node)
        {
            HandleAStarModifier(node);
        }
        protected virtual void HandleAStarModifier(AStarModifier node)
        {
            HandleDefault(node);
        }
        private void dispatch(AQuestionModifier node)
        {
            HandleAQuestionModifier(node);
        }
        protected virtual void HandleAQuestionModifier(AQuestionModifier node)
        {
            HandleDefault(node);
        }
        private void dispatch(APlusModifier node)
        {
            HandleAPlusModifier(node);
        }
        protected virtual void HandleAPlusModifier(APlusModifier node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PState node)
        {
            HandlePState(node);
        }
        protected virtual void HandlePState(PState node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AState node)
        {
            HandleAState(node);
        }
        protected virtual void HandleAState(AState node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PTokenState node)
        {
            HandlePTokenState(node);
        }
        protected virtual void HandlePTokenState(PTokenState node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(ATokenState node)
        {
            HandleATokenState(node);
        }
        protected virtual void HandleATokenState(ATokenState node)
        {
            HandleDefault(node);
        }
        private void dispatch(ATransitionTokenState node)
        {
            HandleATransitionTokenState(node);
        }
        protected virtual void HandleATransitionTokenState(ATransitionTokenState node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PProduction node)
        {
            HandlePProduction(node);
        }
        protected virtual void HandlePProduction(PProduction node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AProduction node)
        {
            HandleAProduction(node);
        }
        protected virtual void HandleAProduction(AProduction node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PProdtranslation node)
        {
            HandlePProdtranslation(node);
        }
        protected virtual void HandlePProdtranslation(PProdtranslation node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AProdtranslation node)
        {
            HandleAProdtranslation(node);
        }
        protected virtual void HandleAProdtranslation(AProdtranslation node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PTranslation node)
        {
            HandlePTranslation(node);
        }
        protected virtual void HandlePTranslation(PTranslation node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AFullTranslation node)
        {
            HandleAFullTranslation(node);
        }
        protected virtual void HandleAFullTranslation(AFullTranslation node)
        {
            HandleDefault(node);
        }
        private void dispatch(ANewTranslation node)
        {
            HandleANewTranslation(node);
        }
        protected virtual void HandleANewTranslation(ANewTranslation node)
        {
            HandleDefault(node);
        }
        private void dispatch(ANewalternativeTranslation node)
        {
            HandleANewalternativeTranslation(node);
        }
        protected virtual void HandleANewalternativeTranslation(ANewalternativeTranslation node)
        {
            HandleDefault(node);
        }
        private void dispatch(AListTranslation node)
        {
            HandleAListTranslation(node);
        }
        protected virtual void HandleAListTranslation(AListTranslation node)
        {
            HandleDefault(node);
        }
        private void dispatch(ANullTranslation node)
        {
            HandleANullTranslation(node);
        }
        protected virtual void HandleANullTranslation(ANullTranslation node)
        {
            HandleDefault(node);
        }
        private void dispatch(AIdTranslation node)
        {
            HandleAIdTranslation(node);
        }
        protected virtual void HandleAIdTranslation(AIdTranslation node)
        {
            HandleDefault(node);
        }
        private void dispatch(AIddotidTranslation node)
        {
            HandleAIddotidTranslation(node);
        }
        protected virtual void HandleAIddotidTranslation(AIddotidTranslation node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PAlternative node)
        {
            HandlePAlternative(node);
        }
        protected virtual void HandlePAlternative(PAlternative node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AAlternative node)
        {
            HandleAAlternative(node);
        }
        protected virtual void HandleAAlternative(AAlternative node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PAlternativename node)
        {
            HandlePAlternativename(node);
        }
        protected virtual void HandlePAlternativename(PAlternativename node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AAlternativename node)
        {
            HandleAAlternativename(node);
        }
        protected virtual void HandleAAlternativename(AAlternativename node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PElement node)
        {
            HandlePElement(node);
        }
        protected virtual void HandlePElement(PElement node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AElement node)
        {
            HandleAElement(node);
        }
        protected virtual void HandleAElement(AElement node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PElementname node)
        {
            HandlePElementname(node);
        }
        protected virtual void HandlePElementname(PElementname node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AElementname node)
        {
            HandleAElementname(node);
        }
        protected virtual void HandleAElementname(AElementname node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PElementid node)
        {
            HandlePElementid(node);
        }
        protected virtual void HandlePElementid(PElementid node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(ACleanElementid node)
        {
            HandleACleanElementid(node);
        }
        protected virtual void HandleACleanElementid(ACleanElementid node)
        {
            HandleDefault(node);
        }
        private void dispatch(ATokenElementid node)
        {
            HandleATokenElementid(node);
        }
        protected virtual void HandleATokenElementid(ATokenElementid node)
        {
            HandleDefault(node);
        }
        private void dispatch(AProductionElementid node)
        {
            HandleAProductionElementid(node);
        }
        protected virtual void HandleAProductionElementid(AProductionElementid node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PHighlightrule node)
        {
            HandlePHighlightrule(node);
        }
        protected virtual void HandlePHighlightrule(PHighlightrule node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AHighlightrule node)
        {
            HandleAHighlightrule(node);
        }
        protected virtual void HandleAHighlightrule(AHighlightrule node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PHighlightStyle node)
        {
            HandlePHighlightStyle(node);
        }
        protected virtual void HandlePHighlightStyle(PHighlightStyle node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(AItalicHighlightStyle node)
        {
            HandleAItalicHighlightStyle(node);
        }
        protected virtual void HandleAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            HandleDefault(node);
        }
        private void dispatch(ABoldHighlightStyle node)
        {
            HandleABoldHighlightStyle(node);
        }
        protected virtual void HandleABoldHighlightStyle(ABoldHighlightStyle node)
        {
            HandleDefault(node);
        }
        private void dispatch(ATextHighlightStyle node)
        {
            HandleATextHighlightStyle(node);
        }
        protected virtual void HandleATextHighlightStyle(ATextHighlightStyle node)
        {
            HandleDefault(node);
        }
        private void dispatch(ABackgroundHighlightStyle node)
        {
            HandleABackgroundHighlightStyle(node);
        }
        protected virtual void HandleABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            HandleDefault(node);
        }
        
        public void Visit(PColor node)
        {
            HandlePColor(node);
        }
        protected virtual void HandlePColor(PColor node)
        {
            dispatch((dynamic)node);
        }
        private void dispatch(ARgbColor node)
        {
            HandleARgbColor(node);
        }
        protected virtual void HandleARgbColor(ARgbColor node)
        {
            HandleDefault(node);
        }
        private void dispatch(AHsvColor node)
        {
            HandleAHsvColor(node);
        }
        protected virtual void HandleAHsvColor(AHsvColor node)
        {
            HandleDefault(node);
        }
        private void dispatch(AHexColor node)
        {
            HandleAHexColor(node);
        }
        protected virtual void HandleAHexColor(AHexColor node)
        {
            HandleDefault(node);
        }
        
        public void Visit(TNamespace node)
        {
            HandleTNamespace(node);
        }
        protected virtual void HandleTNamespace(TNamespace node)
        {
            HandleDefault(node);
        }
        public void Visit(TNamespacetoken node)
        {
            HandleTNamespacetoken(node);
        }
        protected virtual void HandleTNamespacetoken(TNamespacetoken node)
        {
            HandleDefault(node);
        }
        public void Visit(TStatestoken node)
        {
            HandleTStatestoken(node);
        }
        protected virtual void HandleTStatestoken(TStatestoken node)
        {
            HandleDefault(node);
        }
        public void Visit(THelperstoken node)
        {
            HandleTHelperstoken(node);
        }
        protected virtual void HandleTHelperstoken(THelperstoken node)
        {
            HandleDefault(node);
        }
        public void Visit(TTokenstoken node)
        {
            HandleTTokenstoken(node);
        }
        protected virtual void HandleTTokenstoken(TTokenstoken node)
        {
            HandleDefault(node);
        }
        public void Visit(TIgnoredtoken node)
        {
            HandleTIgnoredtoken(node);
        }
        protected virtual void HandleTIgnoredtoken(TIgnoredtoken node)
        {
            HandleDefault(node);
        }
        public void Visit(TProductionstoken node)
        {
            HandleTProductionstoken(node);
        }
        protected virtual void HandleTProductionstoken(TProductionstoken node)
        {
            HandleDefault(node);
        }
        public void Visit(TAsttoken node)
        {
            HandleTAsttoken(node);
        }
        protected virtual void HandleTAsttoken(TAsttoken node)
        {
            HandleDefault(node);
        }
        public void Visit(THighlighttoken node)
        {
            HandleTHighlighttoken(node);
        }
        protected virtual void HandleTHighlighttoken(THighlighttoken node)
        {
            HandleDefault(node);
        }
        public void Visit(TNew node)
        {
            HandleTNew(node);
        }
        protected virtual void HandleTNew(TNew node)
        {
            HandleDefault(node);
        }
        public void Visit(TNull node)
        {
            HandleTNull(node);
        }
        protected virtual void HandleTNull(TNull node)
        {
            HandleDefault(node);
        }
        public void Visit(TTokenSpecifier node)
        {
            HandleTTokenSpecifier(node);
        }
        protected virtual void HandleTTokenSpecifier(TTokenSpecifier node)
        {
            HandleDefault(node);
        }
        public void Visit(TProductionSpecifier node)
        {
            HandleTProductionSpecifier(node);
        }
        protected virtual void HandleTProductionSpecifier(TProductionSpecifier node)
        {
            HandleDefault(node);
        }
        public void Visit(TDot node)
        {
            HandleTDot(node);
        }
        protected virtual void HandleTDot(TDot node)
        {
            HandleDefault(node);
        }
        public void Visit(TDDot node)
        {
            HandleTDDot(node);
        }
        protected virtual void HandleTDDot(TDDot node)
        {
            HandleDefault(node);
        }
        public void Visit(TSemicolon node)
        {
            HandleTSemicolon(node);
        }
        protected virtual void HandleTSemicolon(TSemicolon node)
        {
            HandleDefault(node);
        }
        public void Visit(TEqual node)
        {
            HandleTEqual(node);
        }
        protected virtual void HandleTEqual(TEqual node)
        {
            HandleDefault(node);
        }
        public void Visit(TLBkt node)
        {
            HandleTLBkt(node);
        }
        protected virtual void HandleTLBkt(TLBkt node)
        {
            HandleDefault(node);
        }
        public void Visit(TRBkt node)
        {
            HandleTRBkt(node);
        }
        protected virtual void HandleTRBkt(TRBkt node)
        {
            HandleDefault(node);
        }
        public void Visit(TLPar node)
        {
            HandleTLPar(node);
        }
        protected virtual void HandleTLPar(TLPar node)
        {
            HandleDefault(node);
        }
        public void Visit(TRPar node)
        {
            HandleTRPar(node);
        }
        protected virtual void HandleTRPar(TRPar node)
        {
            HandleDefault(node);
        }
        public void Visit(TLBrace node)
        {
            HandleTLBrace(node);
        }
        protected virtual void HandleTLBrace(TLBrace node)
        {
            HandleDefault(node);
        }
        public void Visit(TRBrace node)
        {
            HandleTRBrace(node);
        }
        protected virtual void HandleTRBrace(TRBrace node)
        {
            HandleDefault(node);
        }
        public void Visit(TPlus node)
        {
            HandleTPlus(node);
        }
        protected virtual void HandleTPlus(TPlus node)
        {
            HandleDefault(node);
        }
        public void Visit(TMinus node)
        {
            HandleTMinus(node);
        }
        protected virtual void HandleTMinus(TMinus node)
        {
            HandleDefault(node);
        }
        public void Visit(TQMark node)
        {
            HandleTQMark(node);
        }
        protected virtual void HandleTQMark(TQMark node)
        {
            HandleDefault(node);
        }
        public void Visit(TStar node)
        {
            HandleTStar(node);
        }
        protected virtual void HandleTStar(TStar node)
        {
            HandleDefault(node);
        }
        public void Visit(TPipe node)
        {
            HandleTPipe(node);
        }
        protected virtual void HandleTPipe(TPipe node)
        {
            HandleDefault(node);
        }
        public void Visit(TComma node)
        {
            HandleTComma(node);
        }
        protected virtual void HandleTComma(TComma node)
        {
            HandleDefault(node);
        }
        public void Visit(TSlash node)
        {
            HandleTSlash(node);
        }
        protected virtual void HandleTSlash(TSlash node)
        {
            HandleDefault(node);
        }
        public void Visit(TArrow node)
        {
            HandleTArrow(node);
        }
        protected virtual void HandleTArrow(TArrow node)
        {
            HandleDefault(node);
        }
        public void Visit(TColon node)
        {
            HandleTColon(node);
        }
        protected virtual void HandleTColon(TColon node)
        {
            HandleDefault(node);
        }
        public void Visit(TIdentifier node)
        {
            HandleTIdentifier(node);
        }
        protected virtual void HandleTIdentifier(TIdentifier node)
        {
            HandleDefault(node);
        }
        public void Visit(TCharacter node)
        {
            HandleTCharacter(node);
        }
        protected virtual void HandleTCharacter(TCharacter node)
        {
            HandleDefault(node);
        }
        public void Visit(TDecChar node)
        {
            HandleTDecChar(node);
        }
        protected virtual void HandleTDecChar(TDecChar node)
        {
            HandleDefault(node);
        }
        public void Visit(THexChar node)
        {
            HandleTHexChar(node);
        }
        protected virtual void HandleTHexChar(THexChar node)
        {
            HandleDefault(node);
        }
        public void Visit(TString node)
        {
            HandleTString(node);
        }
        protected virtual void HandleTString(TString node)
        {
            HandleDefault(node);
        }
        public void Visit(TBlank node)
        {
            HandleTBlank(node);
        }
        protected virtual void HandleTBlank(TBlank node)
        {
            HandleDefault(node);
        }
        public void Visit(TComment node)
        {
            HandleTComment(node);
        }
        protected virtual void HandleTComment(TComment node)
        {
            HandleDefault(node);
        }
        public void Visit(TItalic node)
        {
            HandleTItalic(node);
        }
        protected virtual void HandleTItalic(TItalic node)
        {
            HandleDefault(node);
        }
        public void Visit(TBold node)
        {
            HandleTBold(node);
        }
        protected virtual void HandleTBold(TBold node)
        {
            HandleDefault(node);
        }
        public void Visit(TText node)
        {
            HandleTText(node);
        }
        protected virtual void HandleTText(TText node)
        {
            HandleDefault(node);
        }
        public void Visit(TBackground node)
        {
            HandleTBackground(node);
        }
        protected virtual void HandleTBackground(TBackground node)
        {
            HandleDefault(node);
        }
        public void Visit(TRgb node)
        {
            HandleTRgb(node);
        }
        protected virtual void HandleTRgb(TRgb node)
        {
            HandleDefault(node);
        }
        public void Visit(THsv node)
        {
            HandleTHsv(node);
        }
        protected virtual void HandleTHsv(THsv node)
        {
            HandleDefault(node);
        }
        public void Visit(THexColor node)
        {
            HandleTHexColor(node);
        }
        protected virtual void HandleTHexColor(THexColor node)
        {
            HandleDefault(node);
        }
    }
    
    public partial class DepthFirstAdapter : DepthFirstAdapter<object>
    {
    }
    public partial class DepthFirstAdapter<Value> : AnalysisAdapter<Value>
    {
        public void Visit<Element>(IEnumerable<Element> elements) where Element : Node
        {
            Element[] temp = elements.ToArray();
            for (int i = 0; i < temp.Length; i++)
                Visit((dynamic)temp[i]);
        }
        
        protected override void HandleStart(Start<PGrammar> node)
        {
            Visit(node.Root);
            Visit(node.EOF);
        }
        
        protected override void HandleAGrammar(AGrammar node)
        {
            Visit(node.Sections);
        }
        protected override void HandleANamespaceSection(ANamespaceSection node)
        {
            Visit(node.Namespacetoken);
            Visit(node.Namespace);
            Visit(node.Semicolon);
        }
        protected override void HandleAHelpersSection(AHelpersSection node)
        {
            Visit(node.Helperstoken);
            Visit(node.Helpers);
        }
        protected override void HandleAStatesSection(AStatesSection node)
        {
            Visit(node.Statestoken);
            Visit(node.States);
            Visit(node.Semicolon);
        }
        protected override void HandleATokensSection(ATokensSection node)
        {
            Visit(node.Tokenstoken);
            Visit(node.Tokens);
        }
        protected override void HandleAIgnoreSection(AIgnoreSection node)
        {
            Visit(node.Ignoredtoken);
            Visit(node.Tokenstoken);
            Visit(node.Tokens);
            Visit(node.Semicolon);
        }
        protected override void HandleAProductionsSection(AProductionsSection node)
        {
            Visit(node.Productionstoken);
            Visit(node.Productions);
        }
        protected override void HandleAASTSection(AASTSection node)
        {
            Visit(node.Asttoken);
            Visit(node.Productions);
        }
        protected override void HandleAHighlightSection(AHighlightSection node)
        {
            Visit(node.Highlighttoken);
            Visit(node.Highlightrules);
        }
        protected override void HandleAHelper(AHelper node)
        {
            Visit(node.Identifier);
            Visit(node.Equal);
            Visit(node.Regex);
            Visit(node.Semicolon);
        }
        protected override void HandleAToken(AToken node)
        {
            Visit(node.Statelist);
            Visit(node.Identifier);
            Visit(node.Equal);
            Visit(node.Regex);
            if (node.HasTokenlookahead)
                Visit(node.Tokenlookahead);
            Visit(node.Semicolon);
        }
        protected override void HandleATokenlookahead(ATokenlookahead node)
        {
            Visit(node.Slash);
            Visit(node.Regex);
        }
        protected override void HandleACharRegex(ACharRegex node)
        {
            Visit(node.Character);
        }
        protected override void HandleADecRegex(ADecRegex node)
        {
            Visit(node.DecChar);
        }
        protected override void HandleAHexRegex(AHexRegex node)
        {
            Visit(node.HexChar);
        }
        protected override void HandleAConcatenatedRegex(AConcatenatedRegex node)
        {
            Visit(node.Regexs);
        }
        protected override void HandleAUnaryRegex(AUnaryRegex node)
        {
            Visit(node.Regex);
            Visit(node.Modifier);
        }
        protected override void HandleABinaryplusRegex(ABinaryplusRegex node)
        {
            Visit(node.Lpar);
            Visit(node.Left);
            Visit(node.Plus);
            Visit(node.Right);
            Visit(node.Rpar);
        }
        protected override void HandleABinaryminusRegex(ABinaryminusRegex node)
        {
            Visit(node.Lpar);
            Visit(node.Left);
            Visit(node.Minus);
            Visit(node.Right);
            Visit(node.Rpar);
        }
        protected override void HandleAIntervalRegex(AIntervalRegex node)
        {
            Visit(node.Lpar);
            Visit(node.Left);
            Visit(node.Dots);
            Visit(node.Right);
            Visit(node.Rpar);
        }
        protected override void HandleAStringRegex(AStringRegex node)
        {
            Visit(node.String);
        }
        protected override void HandleAIdentifierRegex(AIdentifierRegex node)
        {
            Visit(node.Identifier);
        }
        protected override void HandleAParenthesisRegex(AParenthesisRegex node)
        {
            Visit(node.Lpar);
            Visit(node.Regex);
            Visit(node.Rpar);
        }
        protected override void HandleAOrRegex(AOrRegex node)
        {
            Visit(node.Regexs);
        }
        protected override void HandleAStarModifier(AStarModifier node)
        {
            Visit(node.Star);
        }
        protected override void HandleAQuestionModifier(AQuestionModifier node)
        {
            Visit(node.QMark);
        }
        protected override void HandleAPlusModifier(APlusModifier node)
        {
            Visit(node.Plus);
        }
        protected override void HandleAState(AState node)
        {
            Visit(node.Identifier);
        }
        protected override void HandleATokenState(ATokenState node)
        {
            Visit(node.Identifier);
        }
        protected override void HandleATransitionTokenState(ATransitionTokenState node)
        {
            Visit(node.From);
            Visit(node.Arrow);
            Visit(node.To);
        }
        protected override void HandleAProduction(AProduction node)
        {
            Visit(node.Identifier);
            if (node.HasProdtranslation)
                Visit(node.Prodtranslation);
            Visit(node.Equal);
            Visit(node.Alternatives);
            Visit(node.Semicolon);
        }
        protected override void HandleAProdtranslation(AProdtranslation node)
        {
            Visit(node.Arrow);
            Visit(node.Identifier);
            if (node.HasModifier)
                Visit(node.Modifier);
        }
        protected override void HandleAFullTranslation(AFullTranslation node)
        {
            Visit(node.Arrow);
            Visit(node.Translation);
        }
        protected override void HandleANewTranslation(ANewTranslation node)
        {
            Visit(node.New);
            Visit(node.Production);
            Visit(node.Lpar);
            Visit(node.Arguments);
            Visit(node.Rpar);
        }
        protected override void HandleANewalternativeTranslation(ANewalternativeTranslation node)
        {
            Visit(node.New);
            Visit(node.Production);
            Visit(node.Dot);
            Visit(node.Alternative);
            Visit(node.Lpar);
            Visit(node.Arguments);
            Visit(node.Rpar);
        }
        protected override void HandleAListTranslation(AListTranslation node)
        {
            Visit(node.Lpar);
            Visit(node.Elements);
            Visit(node.Rpar);
        }
        protected override void HandleANullTranslation(ANullTranslation node)
        {
            Visit(node.Null);
        }
        protected override void HandleAIdTranslation(AIdTranslation node)
        {
            Visit(node.Identifier);
        }
        protected override void HandleAIddotidTranslation(AIddotidTranslation node)
        {
            Visit(node.Identifier);
            Visit(node.Dot);
            Visit(node.Production);
        }
        protected override void HandleAAlternative(AAlternative node)
        {
            if (node.HasAlternativename)
                Visit(node.Alternativename);
            Visit(node.Elements);
            if (node.HasTranslation)
                Visit(node.Translation);
        }
        protected override void HandleAAlternativename(AAlternativename node)
        {
            Visit(node.Lpar);
            Visit(node.Name);
            Visit(node.Rpar);
        }
        protected override void HandleAElement(AElement node)
        {
            if (node.HasElementname)
                Visit(node.Elementname);
            Visit(node.Elementid);
            if (node.HasModifier)
                Visit(node.Modifier);
        }
        protected override void HandleAElementname(AElementname node)
        {
            Visit(node.Lpar);
            Visit(node.Name);
            Visit(node.Rpar);
            Visit(node.Colon);
        }
        protected override void HandleACleanElementid(ACleanElementid node)
        {
            Visit(node.Identifier);
        }
        protected override void HandleATokenElementid(ATokenElementid node)
        {
            Visit(node.TokenSpecifier);
            Visit(node.Dot);
            Visit(node.Identifier);
        }
        protected override void HandleAProductionElementid(AProductionElementid node)
        {
            Visit(node.ProductionSpecifier);
            Visit(node.Dot);
            Visit(node.Identifier);
        }
        protected override void HandleAHighlightrule(AHighlightrule node)
        {
            Visit(node.Lpar);
            Visit(node.Tokens);
            Visit(node.Rpar);
            Visit(node.Styles);
            Visit(node.Semicolon);
        }
        protected override void HandleAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            Visit(node.Italic);
        }
        protected override void HandleABoldHighlightStyle(ABoldHighlightStyle node)
        {
            Visit(node.Bold);
        }
        protected override void HandleATextHighlightStyle(ATextHighlightStyle node)
        {
            Visit(node.Text);
            Visit(node.Colon);
            Visit(node.Color);
        }
        protected override void HandleABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            Visit(node.Background);
            Visit(node.Colon);
            Visit(node.Color);
        }
        protected override void HandleARgbColor(ARgbColor node)
        {
            Visit(node.Rgb);
            Visit(node.LPar);
            Visit(node.Red);
            Visit(node.Comma1);
            Visit(node.Green);
            Visit(node.Comma2);
            Visit(node.Blue);
            Visit(node.RPar);
        }
        protected override void HandleAHsvColor(AHsvColor node)
        {
            Visit(node.Hsv);
            Visit(node.LPar);
            Visit(node.Hue);
            Visit(node.Comma1);
            Visit(node.Saturation);
            Visit(node.Comma2);
            Visit(node.Brightness);
            Visit(node.RPar);
        }
        protected override void HandleAHexColor(AHexColor node)
        {
            Visit(node.Color);
        }
    }
    
    public partial class ReverseDepthFirstAdapter : ReverseDepthFirstAdapter<object>
    {
    }
    public partial class ReverseDepthFirstAdapter<Value> : AnalysisAdapter<Value>
    {
        public void Visit<Element>(IEnumerable<Element> elements) where Element : Node
        {
            Element[] temp = elements.ToArray();
            for (int i = temp.Length - 1; i >= 0; i--)
                Visit((dynamic)temp[i]);
        }
        
        protected override void HandleStart(Start<PGrammar> node)
        {
            Visit(node.EOF);
            Visit(node.Root);
        }
        
        protected override void HandleAGrammar(AGrammar node)
        {
            Visit(node.Sections);
        }
        protected override void HandleANamespaceSection(ANamespaceSection node)
        {
            Visit(node.Semicolon);
            Visit(node.Namespace);
            Visit(node.Namespacetoken);
        }
        protected override void HandleAHelpersSection(AHelpersSection node)
        {
            Visit(node.Helpers);
            Visit(node.Helperstoken);
        }
        protected override void HandleAStatesSection(AStatesSection node)
        {
            Visit(node.Semicolon);
            Visit(node.States);
            Visit(node.Statestoken);
        }
        protected override void HandleATokensSection(ATokensSection node)
        {
            Visit(node.Tokens);
            Visit(node.Tokenstoken);
        }
        protected override void HandleAIgnoreSection(AIgnoreSection node)
        {
            Visit(node.Semicolon);
            Visit(node.Tokens);
            Visit(node.Tokenstoken);
            Visit(node.Ignoredtoken);
        }
        protected override void HandleAProductionsSection(AProductionsSection node)
        {
            Visit(node.Productions);
            Visit(node.Productionstoken);
        }
        protected override void HandleAASTSection(AASTSection node)
        {
            Visit(node.Productions);
            Visit(node.Asttoken);
        }
        protected override void HandleAHighlightSection(AHighlightSection node)
        {
            Visit(node.Highlightrules);
            Visit(node.Highlighttoken);
        }
        protected override void HandleAHelper(AHelper node)
        {
            Visit(node.Semicolon);
            Visit(node.Regex);
            Visit(node.Equal);
            Visit(node.Identifier);
        }
        protected override void HandleAToken(AToken node)
        {
            Visit(node.Semicolon);
            if (node.HasTokenlookahead)
                Visit(node.Tokenlookahead);
            Visit(node.Regex);
            Visit(node.Equal);
            Visit(node.Identifier);
            Visit(node.Statelist);
        }
        protected override void HandleATokenlookahead(ATokenlookahead node)
        {
            Visit(node.Regex);
            Visit(node.Slash);
        }
        protected override void HandleACharRegex(ACharRegex node)
        {
            Visit(node.Character);
        }
        protected override void HandleADecRegex(ADecRegex node)
        {
            Visit(node.DecChar);
        }
        protected override void HandleAHexRegex(AHexRegex node)
        {
            Visit(node.HexChar);
        }
        protected override void HandleAConcatenatedRegex(AConcatenatedRegex node)
        {
            Visit(node.Regexs);
        }
        protected override void HandleAUnaryRegex(AUnaryRegex node)
        {
            Visit(node.Modifier);
            Visit(node.Regex);
        }
        protected override void HandleABinaryplusRegex(ABinaryplusRegex node)
        {
            Visit(node.Rpar);
            Visit(node.Right);
            Visit(node.Plus);
            Visit(node.Left);
            Visit(node.Lpar);
        }
        protected override void HandleABinaryminusRegex(ABinaryminusRegex node)
        {
            Visit(node.Rpar);
            Visit(node.Right);
            Visit(node.Minus);
            Visit(node.Left);
            Visit(node.Lpar);
        }
        protected override void HandleAIntervalRegex(AIntervalRegex node)
        {
            Visit(node.Rpar);
            Visit(node.Right);
            Visit(node.Dots);
            Visit(node.Left);
            Visit(node.Lpar);
        }
        protected override void HandleAStringRegex(AStringRegex node)
        {
            Visit(node.String);
        }
        protected override void HandleAIdentifierRegex(AIdentifierRegex node)
        {
            Visit(node.Identifier);
        }
        protected override void HandleAParenthesisRegex(AParenthesisRegex node)
        {
            Visit(node.Rpar);
            Visit(node.Regex);
            Visit(node.Lpar);
        }
        protected override void HandleAOrRegex(AOrRegex node)
        {
            Visit(node.Regexs);
        }
        protected override void HandleAStarModifier(AStarModifier node)
        {
            Visit(node.Star);
        }
        protected override void HandleAQuestionModifier(AQuestionModifier node)
        {
            Visit(node.QMark);
        }
        protected override void HandleAPlusModifier(APlusModifier node)
        {
            Visit(node.Plus);
        }
        protected override void HandleAState(AState node)
        {
            Visit(node.Identifier);
        }
        protected override void HandleATokenState(ATokenState node)
        {
            Visit(node.Identifier);
        }
        protected override void HandleATransitionTokenState(ATransitionTokenState node)
        {
            Visit(node.To);
            Visit(node.Arrow);
            Visit(node.From);
        }
        protected override void HandleAProduction(AProduction node)
        {
            Visit(node.Semicolon);
            Visit(node.Alternatives);
            Visit(node.Equal);
            if (node.HasProdtranslation)
                Visit(node.Prodtranslation);
            Visit(node.Identifier);
        }
        protected override void HandleAProdtranslation(AProdtranslation node)
        {
            if (node.HasModifier)
                Visit(node.Modifier);
            Visit(node.Identifier);
            Visit(node.Arrow);
        }
        protected override void HandleAFullTranslation(AFullTranslation node)
        {
            Visit(node.Translation);
            Visit(node.Arrow);
        }
        protected override void HandleANewTranslation(ANewTranslation node)
        {
            Visit(node.Rpar);
            Visit(node.Arguments);
            Visit(node.Lpar);
            Visit(node.Production);
            Visit(node.New);
        }
        protected override void HandleANewalternativeTranslation(ANewalternativeTranslation node)
        {
            Visit(node.Rpar);
            Visit(node.Arguments);
            Visit(node.Lpar);
            Visit(node.Alternative);
            Visit(node.Dot);
            Visit(node.Production);
            Visit(node.New);
        }
        protected override void HandleAListTranslation(AListTranslation node)
        {
            Visit(node.Rpar);
            Visit(node.Elements);
            Visit(node.Lpar);
        }
        protected override void HandleANullTranslation(ANullTranslation node)
        {
            Visit(node.Null);
        }
        protected override void HandleAIdTranslation(AIdTranslation node)
        {
            Visit(node.Identifier);
        }
        protected override void HandleAIddotidTranslation(AIddotidTranslation node)
        {
            Visit(node.Production);
            Visit(node.Dot);
            Visit(node.Identifier);
        }
        protected override void HandleAAlternative(AAlternative node)
        {
            if (node.HasTranslation)
                Visit(node.Translation);
            Visit(node.Elements);
            if (node.HasAlternativename)
                Visit(node.Alternativename);
        }
        protected override void HandleAAlternativename(AAlternativename node)
        {
            Visit(node.Rpar);
            Visit(node.Name);
            Visit(node.Lpar);
        }
        protected override void HandleAElement(AElement node)
        {
            if (node.HasModifier)
                Visit(node.Modifier);
            Visit(node.Elementid);
            if (node.HasElementname)
                Visit(node.Elementname);
        }
        protected override void HandleAElementname(AElementname node)
        {
            Visit(node.Colon);
            Visit(node.Rpar);
            Visit(node.Name);
            Visit(node.Lpar);
        }
        protected override void HandleACleanElementid(ACleanElementid node)
        {
            Visit(node.Identifier);
        }
        protected override void HandleATokenElementid(ATokenElementid node)
        {
            Visit(node.Identifier);
            Visit(node.Dot);
            Visit(node.TokenSpecifier);
        }
        protected override void HandleAProductionElementid(AProductionElementid node)
        {
            Visit(node.Identifier);
            Visit(node.Dot);
            Visit(node.ProductionSpecifier);
        }
        protected override void HandleAHighlightrule(AHighlightrule node)
        {
            Visit(node.Semicolon);
            Visit(node.Styles);
            Visit(node.Rpar);
            Visit(node.Tokens);
            Visit(node.Lpar);
        }
        protected override void HandleAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            Visit(node.Italic);
        }
        protected override void HandleABoldHighlightStyle(ABoldHighlightStyle node)
        {
            Visit(node.Bold);
        }
        protected override void HandleATextHighlightStyle(ATextHighlightStyle node)
        {
            Visit(node.Color);
            Visit(node.Colon);
            Visit(node.Text);
        }
        protected override void HandleABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            Visit(node.Color);
            Visit(node.Colon);
            Visit(node.Background);
        }
        protected override void HandleARgbColor(ARgbColor node)
        {
            Visit(node.RPar);
            Visit(node.Blue);
            Visit(node.Comma2);
            Visit(node.Green);
            Visit(node.Comma1);
            Visit(node.Red);
            Visit(node.LPar);
            Visit(node.Rgb);
        }
        protected override void HandleAHsvColor(AHsvColor node)
        {
            Visit(node.RPar);
            Visit(node.Brightness);
            Visit(node.Comma2);
            Visit(node.Saturation);
            Visit(node.Comma1);
            Visit(node.Hue);
            Visit(node.LPar);
            Visit(node.Hsv);
        }
        protected override void HandleAHexColor(AHexColor node)
        {
            Visit(node.Color);
        }
    }
    
    #endregion
    
    #region Return analysis adapters
    
    public partial class ReturnAnalysisAdapter<Result> : ReturnAdapter<Result, PGrammar>
    {
        public Result Visit(AGrammar node)
        {
            return HandleAGrammar(node);
        }
        public virtual Result HandleAGrammar(AGrammar node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ANamespaceSection node)
        {
            return HandleANamespaceSection(node);
        }
        public virtual Result HandleANamespaceSection(ANamespaceSection node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AHelpersSection node)
        {
            return HandleAHelpersSection(node);
        }
        public virtual Result HandleAHelpersSection(AHelpersSection node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AStatesSection node)
        {
            return HandleAStatesSection(node);
        }
        public virtual Result HandleAStatesSection(AStatesSection node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ATokensSection node)
        {
            return HandleATokensSection(node);
        }
        public virtual Result HandleATokensSection(ATokensSection node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AIgnoreSection node)
        {
            return HandleAIgnoreSection(node);
        }
        public virtual Result HandleAIgnoreSection(AIgnoreSection node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AProductionsSection node)
        {
            return HandleAProductionsSection(node);
        }
        public virtual Result HandleAProductionsSection(AProductionsSection node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AASTSection node)
        {
            return HandleAASTSection(node);
        }
        public virtual Result HandleAASTSection(AASTSection node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AHighlightSection node)
        {
            return HandleAHighlightSection(node);
        }
        public virtual Result HandleAHighlightSection(AHighlightSection node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AHelper node)
        {
            return HandleAHelper(node);
        }
        public virtual Result HandleAHelper(AHelper node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AToken node)
        {
            return HandleAToken(node);
        }
        public virtual Result HandleAToken(AToken node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ATokenlookahead node)
        {
            return HandleATokenlookahead(node);
        }
        public virtual Result HandleATokenlookahead(ATokenlookahead node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ACharRegex node)
        {
            return HandleACharRegex(node);
        }
        public virtual Result HandleACharRegex(ACharRegex node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ADecRegex node)
        {
            return HandleADecRegex(node);
        }
        public virtual Result HandleADecRegex(ADecRegex node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AHexRegex node)
        {
            return HandleAHexRegex(node);
        }
        public virtual Result HandleAHexRegex(AHexRegex node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AConcatenatedRegex node)
        {
            return HandleAConcatenatedRegex(node);
        }
        public virtual Result HandleAConcatenatedRegex(AConcatenatedRegex node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AUnaryRegex node)
        {
            return HandleAUnaryRegex(node);
        }
        public virtual Result HandleAUnaryRegex(AUnaryRegex node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ABinaryplusRegex node)
        {
            return HandleABinaryplusRegex(node);
        }
        public virtual Result HandleABinaryplusRegex(ABinaryplusRegex node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ABinaryminusRegex node)
        {
            return HandleABinaryminusRegex(node);
        }
        public virtual Result HandleABinaryminusRegex(ABinaryminusRegex node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AIntervalRegex node)
        {
            return HandleAIntervalRegex(node);
        }
        public virtual Result HandleAIntervalRegex(AIntervalRegex node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AStringRegex node)
        {
            return HandleAStringRegex(node);
        }
        public virtual Result HandleAStringRegex(AStringRegex node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AIdentifierRegex node)
        {
            return HandleAIdentifierRegex(node);
        }
        public virtual Result HandleAIdentifierRegex(AIdentifierRegex node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AParenthesisRegex node)
        {
            return HandleAParenthesisRegex(node);
        }
        public virtual Result HandleAParenthesisRegex(AParenthesisRegex node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AOrRegex node)
        {
            return HandleAOrRegex(node);
        }
        public virtual Result HandleAOrRegex(AOrRegex node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AStarModifier node)
        {
            return HandleAStarModifier(node);
        }
        public virtual Result HandleAStarModifier(AStarModifier node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AQuestionModifier node)
        {
            return HandleAQuestionModifier(node);
        }
        public virtual Result HandleAQuestionModifier(AQuestionModifier node)
        {
            return HandleDefault(node);
        }
        public Result Visit(APlusModifier node)
        {
            return HandleAPlusModifier(node);
        }
        public virtual Result HandleAPlusModifier(APlusModifier node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AState node)
        {
            return HandleAState(node);
        }
        public virtual Result HandleAState(AState node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ATokenState node)
        {
            return HandleATokenState(node);
        }
        public virtual Result HandleATokenState(ATokenState node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ATransitionTokenState node)
        {
            return HandleATransitionTokenState(node);
        }
        public virtual Result HandleATransitionTokenState(ATransitionTokenState node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AProduction node)
        {
            return HandleAProduction(node);
        }
        public virtual Result HandleAProduction(AProduction node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AProdtranslation node)
        {
            return HandleAProdtranslation(node);
        }
        public virtual Result HandleAProdtranslation(AProdtranslation node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AFullTranslation node)
        {
            return HandleAFullTranslation(node);
        }
        public virtual Result HandleAFullTranslation(AFullTranslation node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ANewTranslation node)
        {
            return HandleANewTranslation(node);
        }
        public virtual Result HandleANewTranslation(ANewTranslation node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ANewalternativeTranslation node)
        {
            return HandleANewalternativeTranslation(node);
        }
        public virtual Result HandleANewalternativeTranslation(ANewalternativeTranslation node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AListTranslation node)
        {
            return HandleAListTranslation(node);
        }
        public virtual Result HandleAListTranslation(AListTranslation node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ANullTranslation node)
        {
            return HandleANullTranslation(node);
        }
        public virtual Result HandleANullTranslation(ANullTranslation node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AIdTranslation node)
        {
            return HandleAIdTranslation(node);
        }
        public virtual Result HandleAIdTranslation(AIdTranslation node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AIddotidTranslation node)
        {
            return HandleAIddotidTranslation(node);
        }
        public virtual Result HandleAIddotidTranslation(AIddotidTranslation node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AAlternative node)
        {
            return HandleAAlternative(node);
        }
        public virtual Result HandleAAlternative(AAlternative node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AAlternativename node)
        {
            return HandleAAlternativename(node);
        }
        public virtual Result HandleAAlternativename(AAlternativename node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AElement node)
        {
            return HandleAElement(node);
        }
        public virtual Result HandleAElement(AElement node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AElementname node)
        {
            return HandleAElementname(node);
        }
        public virtual Result HandleAElementname(AElementname node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ACleanElementid node)
        {
            return HandleACleanElementid(node);
        }
        public virtual Result HandleACleanElementid(ACleanElementid node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ATokenElementid node)
        {
            return HandleATokenElementid(node);
        }
        public virtual Result HandleATokenElementid(ATokenElementid node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AProductionElementid node)
        {
            return HandleAProductionElementid(node);
        }
        public virtual Result HandleAProductionElementid(AProductionElementid node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AHighlightrule node)
        {
            return HandleAHighlightrule(node);
        }
        public virtual Result HandleAHighlightrule(AHighlightrule node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AItalicHighlightStyle node)
        {
            return HandleAItalicHighlightStyle(node);
        }
        public virtual Result HandleAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ABoldHighlightStyle node)
        {
            return HandleABoldHighlightStyle(node);
        }
        public virtual Result HandleABoldHighlightStyle(ABoldHighlightStyle node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ATextHighlightStyle node)
        {
            return HandleATextHighlightStyle(node);
        }
        public virtual Result HandleATextHighlightStyle(ATextHighlightStyle node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ABackgroundHighlightStyle node)
        {
            return HandleABackgroundHighlightStyle(node);
        }
        public virtual Result HandleABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            return HandleDefault(node);
        }
        public Result Visit(ARgbColor node)
        {
            return HandleARgbColor(node);
        }
        public virtual Result HandleARgbColor(ARgbColor node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AHsvColor node)
        {
            return HandleAHsvColor(node);
        }
        public virtual Result HandleAHsvColor(AHsvColor node)
        {
            return HandleDefault(node);
        }
        public Result Visit(AHexColor node)
        {
            return HandleAHexColor(node);
        }
        public virtual Result HandleAHexColor(AHexColor node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TNamespace node)
        {
            return HandleTNamespace(node);
        }
        public virtual Result HandleTNamespace(TNamespace node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TNamespacetoken node)
        {
            return HandleTNamespacetoken(node);
        }
        public virtual Result HandleTNamespacetoken(TNamespacetoken node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TStatestoken node)
        {
            return HandleTStatestoken(node);
        }
        public virtual Result HandleTStatestoken(TStatestoken node)
        {
            return HandleDefault(node);
        }
        public Result Visit(THelperstoken node)
        {
            return HandleTHelperstoken(node);
        }
        public virtual Result HandleTHelperstoken(THelperstoken node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TTokenstoken node)
        {
            return HandleTTokenstoken(node);
        }
        public virtual Result HandleTTokenstoken(TTokenstoken node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TIgnoredtoken node)
        {
            return HandleTIgnoredtoken(node);
        }
        public virtual Result HandleTIgnoredtoken(TIgnoredtoken node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TProductionstoken node)
        {
            return HandleTProductionstoken(node);
        }
        public virtual Result HandleTProductionstoken(TProductionstoken node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TAsttoken node)
        {
            return HandleTAsttoken(node);
        }
        public virtual Result HandleTAsttoken(TAsttoken node)
        {
            return HandleDefault(node);
        }
        public Result Visit(THighlighttoken node)
        {
            return HandleTHighlighttoken(node);
        }
        public virtual Result HandleTHighlighttoken(THighlighttoken node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TNew node)
        {
            return HandleTNew(node);
        }
        public virtual Result HandleTNew(TNew node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TNull node)
        {
            return HandleTNull(node);
        }
        public virtual Result HandleTNull(TNull node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TTokenSpecifier node)
        {
            return HandleTTokenSpecifier(node);
        }
        public virtual Result HandleTTokenSpecifier(TTokenSpecifier node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TProductionSpecifier node)
        {
            return HandleTProductionSpecifier(node);
        }
        public virtual Result HandleTProductionSpecifier(TProductionSpecifier node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TDot node)
        {
            return HandleTDot(node);
        }
        public virtual Result HandleTDot(TDot node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TDDot node)
        {
            return HandleTDDot(node);
        }
        public virtual Result HandleTDDot(TDDot node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TSemicolon node)
        {
            return HandleTSemicolon(node);
        }
        public virtual Result HandleTSemicolon(TSemicolon node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TEqual node)
        {
            return HandleTEqual(node);
        }
        public virtual Result HandleTEqual(TEqual node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TLBkt node)
        {
            return HandleTLBkt(node);
        }
        public virtual Result HandleTLBkt(TLBkt node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TRBkt node)
        {
            return HandleTRBkt(node);
        }
        public virtual Result HandleTRBkt(TRBkt node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TLPar node)
        {
            return HandleTLPar(node);
        }
        public virtual Result HandleTLPar(TLPar node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TRPar node)
        {
            return HandleTRPar(node);
        }
        public virtual Result HandleTRPar(TRPar node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TLBrace node)
        {
            return HandleTLBrace(node);
        }
        public virtual Result HandleTLBrace(TLBrace node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TRBrace node)
        {
            return HandleTRBrace(node);
        }
        public virtual Result HandleTRBrace(TRBrace node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TPlus node)
        {
            return HandleTPlus(node);
        }
        public virtual Result HandleTPlus(TPlus node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TMinus node)
        {
            return HandleTMinus(node);
        }
        public virtual Result HandleTMinus(TMinus node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TQMark node)
        {
            return HandleTQMark(node);
        }
        public virtual Result HandleTQMark(TQMark node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TStar node)
        {
            return HandleTStar(node);
        }
        public virtual Result HandleTStar(TStar node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TPipe node)
        {
            return HandleTPipe(node);
        }
        public virtual Result HandleTPipe(TPipe node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TComma node)
        {
            return HandleTComma(node);
        }
        public virtual Result HandleTComma(TComma node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TSlash node)
        {
            return HandleTSlash(node);
        }
        public virtual Result HandleTSlash(TSlash node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TArrow node)
        {
            return HandleTArrow(node);
        }
        public virtual Result HandleTArrow(TArrow node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TColon node)
        {
            return HandleTColon(node);
        }
        public virtual Result HandleTColon(TColon node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TIdentifier node)
        {
            return HandleTIdentifier(node);
        }
        public virtual Result HandleTIdentifier(TIdentifier node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TCharacter node)
        {
            return HandleTCharacter(node);
        }
        public virtual Result HandleTCharacter(TCharacter node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TDecChar node)
        {
            return HandleTDecChar(node);
        }
        public virtual Result HandleTDecChar(TDecChar node)
        {
            return HandleDefault(node);
        }
        public Result Visit(THexChar node)
        {
            return HandleTHexChar(node);
        }
        public virtual Result HandleTHexChar(THexChar node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TString node)
        {
            return HandleTString(node);
        }
        public virtual Result HandleTString(TString node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TBlank node)
        {
            return HandleTBlank(node);
        }
        public virtual Result HandleTBlank(TBlank node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TComment node)
        {
            return HandleTComment(node);
        }
        public virtual Result HandleTComment(TComment node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TItalic node)
        {
            return HandleTItalic(node);
        }
        public virtual Result HandleTItalic(TItalic node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TBold node)
        {
            return HandleTBold(node);
        }
        public virtual Result HandleTBold(TBold node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TText node)
        {
            return HandleTText(node);
        }
        public virtual Result HandleTText(TText node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TBackground node)
        {
            return HandleTBackground(node);
        }
        public virtual Result HandleTBackground(TBackground node)
        {
            return HandleDefault(node);
        }
        public Result Visit(TRgb node)
        {
            return HandleTRgb(node);
        }
        public virtual Result HandleTRgb(TRgb node)
        {
            return HandleDefault(node);
        }
        public Result Visit(THsv node)
        {
            return HandleTHsv(node);
        }
        public virtual Result HandleTHsv(THsv node)
        {
            return HandleDefault(node);
        }
        public Result Visit(THexColor node)
        {
            return HandleTHexColor(node);
        }
        public virtual Result HandleTHexColor(THexColor node)
        {
            return HandleDefault(node);
        }
    }
    public partial class ReturnAnalysisAdapter<T1, Result> : ReturnAdapter<T1, Result, PGrammar>
    {
        public Result Visit(AGrammar node, T1 arg1)
        {
            return HandleAGrammar(node, arg1);
        }
        public virtual Result HandleAGrammar(AGrammar node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ANamespaceSection node, T1 arg1)
        {
            return HandleANamespaceSection(node, arg1);
        }
        public virtual Result HandleANamespaceSection(ANamespaceSection node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AHelpersSection node, T1 arg1)
        {
            return HandleAHelpersSection(node, arg1);
        }
        public virtual Result HandleAHelpersSection(AHelpersSection node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AStatesSection node, T1 arg1)
        {
            return HandleAStatesSection(node, arg1);
        }
        public virtual Result HandleAStatesSection(AStatesSection node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ATokensSection node, T1 arg1)
        {
            return HandleATokensSection(node, arg1);
        }
        public virtual Result HandleATokensSection(ATokensSection node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AIgnoreSection node, T1 arg1)
        {
            return HandleAIgnoreSection(node, arg1);
        }
        public virtual Result HandleAIgnoreSection(AIgnoreSection node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AProductionsSection node, T1 arg1)
        {
            return HandleAProductionsSection(node, arg1);
        }
        public virtual Result HandleAProductionsSection(AProductionsSection node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AASTSection node, T1 arg1)
        {
            return HandleAASTSection(node, arg1);
        }
        public virtual Result HandleAASTSection(AASTSection node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AHighlightSection node, T1 arg1)
        {
            return HandleAHighlightSection(node, arg1);
        }
        public virtual Result HandleAHighlightSection(AHighlightSection node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AHelper node, T1 arg1)
        {
            return HandleAHelper(node, arg1);
        }
        public virtual Result HandleAHelper(AHelper node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AToken node, T1 arg1)
        {
            return HandleAToken(node, arg1);
        }
        public virtual Result HandleAToken(AToken node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ATokenlookahead node, T1 arg1)
        {
            return HandleATokenlookahead(node, arg1);
        }
        public virtual Result HandleATokenlookahead(ATokenlookahead node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ACharRegex node, T1 arg1)
        {
            return HandleACharRegex(node, arg1);
        }
        public virtual Result HandleACharRegex(ACharRegex node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ADecRegex node, T1 arg1)
        {
            return HandleADecRegex(node, arg1);
        }
        public virtual Result HandleADecRegex(ADecRegex node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AHexRegex node, T1 arg1)
        {
            return HandleAHexRegex(node, arg1);
        }
        public virtual Result HandleAHexRegex(AHexRegex node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AConcatenatedRegex node, T1 arg1)
        {
            return HandleAConcatenatedRegex(node, arg1);
        }
        public virtual Result HandleAConcatenatedRegex(AConcatenatedRegex node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AUnaryRegex node, T1 arg1)
        {
            return HandleAUnaryRegex(node, arg1);
        }
        public virtual Result HandleAUnaryRegex(AUnaryRegex node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ABinaryplusRegex node, T1 arg1)
        {
            return HandleABinaryplusRegex(node, arg1);
        }
        public virtual Result HandleABinaryplusRegex(ABinaryplusRegex node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ABinaryminusRegex node, T1 arg1)
        {
            return HandleABinaryminusRegex(node, arg1);
        }
        public virtual Result HandleABinaryminusRegex(ABinaryminusRegex node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AIntervalRegex node, T1 arg1)
        {
            return HandleAIntervalRegex(node, arg1);
        }
        public virtual Result HandleAIntervalRegex(AIntervalRegex node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AStringRegex node, T1 arg1)
        {
            return HandleAStringRegex(node, arg1);
        }
        public virtual Result HandleAStringRegex(AStringRegex node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AIdentifierRegex node, T1 arg1)
        {
            return HandleAIdentifierRegex(node, arg1);
        }
        public virtual Result HandleAIdentifierRegex(AIdentifierRegex node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AParenthesisRegex node, T1 arg1)
        {
            return HandleAParenthesisRegex(node, arg1);
        }
        public virtual Result HandleAParenthesisRegex(AParenthesisRegex node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AOrRegex node, T1 arg1)
        {
            return HandleAOrRegex(node, arg1);
        }
        public virtual Result HandleAOrRegex(AOrRegex node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AStarModifier node, T1 arg1)
        {
            return HandleAStarModifier(node, arg1);
        }
        public virtual Result HandleAStarModifier(AStarModifier node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AQuestionModifier node, T1 arg1)
        {
            return HandleAQuestionModifier(node, arg1);
        }
        public virtual Result HandleAQuestionModifier(AQuestionModifier node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(APlusModifier node, T1 arg1)
        {
            return HandleAPlusModifier(node, arg1);
        }
        public virtual Result HandleAPlusModifier(APlusModifier node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AState node, T1 arg1)
        {
            return HandleAState(node, arg1);
        }
        public virtual Result HandleAState(AState node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ATokenState node, T1 arg1)
        {
            return HandleATokenState(node, arg1);
        }
        public virtual Result HandleATokenState(ATokenState node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ATransitionTokenState node, T1 arg1)
        {
            return HandleATransitionTokenState(node, arg1);
        }
        public virtual Result HandleATransitionTokenState(ATransitionTokenState node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AProduction node, T1 arg1)
        {
            return HandleAProduction(node, arg1);
        }
        public virtual Result HandleAProduction(AProduction node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AProdtranslation node, T1 arg1)
        {
            return HandleAProdtranslation(node, arg1);
        }
        public virtual Result HandleAProdtranslation(AProdtranslation node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AFullTranslation node, T1 arg1)
        {
            return HandleAFullTranslation(node, arg1);
        }
        public virtual Result HandleAFullTranslation(AFullTranslation node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ANewTranslation node, T1 arg1)
        {
            return HandleANewTranslation(node, arg1);
        }
        public virtual Result HandleANewTranslation(ANewTranslation node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ANewalternativeTranslation node, T1 arg1)
        {
            return HandleANewalternativeTranslation(node, arg1);
        }
        public virtual Result HandleANewalternativeTranslation(ANewalternativeTranslation node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AListTranslation node, T1 arg1)
        {
            return HandleAListTranslation(node, arg1);
        }
        public virtual Result HandleAListTranslation(AListTranslation node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ANullTranslation node, T1 arg1)
        {
            return HandleANullTranslation(node, arg1);
        }
        public virtual Result HandleANullTranslation(ANullTranslation node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AIdTranslation node, T1 arg1)
        {
            return HandleAIdTranslation(node, arg1);
        }
        public virtual Result HandleAIdTranslation(AIdTranslation node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AIddotidTranslation node, T1 arg1)
        {
            return HandleAIddotidTranslation(node, arg1);
        }
        public virtual Result HandleAIddotidTranslation(AIddotidTranslation node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AAlternative node, T1 arg1)
        {
            return HandleAAlternative(node, arg1);
        }
        public virtual Result HandleAAlternative(AAlternative node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AAlternativename node, T1 arg1)
        {
            return HandleAAlternativename(node, arg1);
        }
        public virtual Result HandleAAlternativename(AAlternativename node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AElement node, T1 arg1)
        {
            return HandleAElement(node, arg1);
        }
        public virtual Result HandleAElement(AElement node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AElementname node, T1 arg1)
        {
            return HandleAElementname(node, arg1);
        }
        public virtual Result HandleAElementname(AElementname node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ACleanElementid node, T1 arg1)
        {
            return HandleACleanElementid(node, arg1);
        }
        public virtual Result HandleACleanElementid(ACleanElementid node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ATokenElementid node, T1 arg1)
        {
            return HandleATokenElementid(node, arg1);
        }
        public virtual Result HandleATokenElementid(ATokenElementid node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AProductionElementid node, T1 arg1)
        {
            return HandleAProductionElementid(node, arg1);
        }
        public virtual Result HandleAProductionElementid(AProductionElementid node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AHighlightrule node, T1 arg1)
        {
            return HandleAHighlightrule(node, arg1);
        }
        public virtual Result HandleAHighlightrule(AHighlightrule node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AItalicHighlightStyle node, T1 arg1)
        {
            return HandleAItalicHighlightStyle(node, arg1);
        }
        public virtual Result HandleAItalicHighlightStyle(AItalicHighlightStyle node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ABoldHighlightStyle node, T1 arg1)
        {
            return HandleABoldHighlightStyle(node, arg1);
        }
        public virtual Result HandleABoldHighlightStyle(ABoldHighlightStyle node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ATextHighlightStyle node, T1 arg1)
        {
            return HandleATextHighlightStyle(node, arg1);
        }
        public virtual Result HandleATextHighlightStyle(ATextHighlightStyle node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ABackgroundHighlightStyle node, T1 arg1)
        {
            return HandleABackgroundHighlightStyle(node, arg1);
        }
        public virtual Result HandleABackgroundHighlightStyle(ABackgroundHighlightStyle node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(ARgbColor node, T1 arg1)
        {
            return HandleARgbColor(node, arg1);
        }
        public virtual Result HandleARgbColor(ARgbColor node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AHsvColor node, T1 arg1)
        {
            return HandleAHsvColor(node, arg1);
        }
        public virtual Result HandleAHsvColor(AHsvColor node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(AHexColor node, T1 arg1)
        {
            return HandleAHexColor(node, arg1);
        }
        public virtual Result HandleAHexColor(AHexColor node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TNamespace node, T1 arg1)
        {
            return HandleTNamespace(node, arg1);
        }
        public virtual Result HandleTNamespace(TNamespace node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TNamespacetoken node, T1 arg1)
        {
            return HandleTNamespacetoken(node, arg1);
        }
        public virtual Result HandleTNamespacetoken(TNamespacetoken node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TStatestoken node, T1 arg1)
        {
            return HandleTStatestoken(node, arg1);
        }
        public virtual Result HandleTStatestoken(TStatestoken node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(THelperstoken node, T1 arg1)
        {
            return HandleTHelperstoken(node, arg1);
        }
        public virtual Result HandleTHelperstoken(THelperstoken node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TTokenstoken node, T1 arg1)
        {
            return HandleTTokenstoken(node, arg1);
        }
        public virtual Result HandleTTokenstoken(TTokenstoken node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TIgnoredtoken node, T1 arg1)
        {
            return HandleTIgnoredtoken(node, arg1);
        }
        public virtual Result HandleTIgnoredtoken(TIgnoredtoken node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TProductionstoken node, T1 arg1)
        {
            return HandleTProductionstoken(node, arg1);
        }
        public virtual Result HandleTProductionstoken(TProductionstoken node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TAsttoken node, T1 arg1)
        {
            return HandleTAsttoken(node, arg1);
        }
        public virtual Result HandleTAsttoken(TAsttoken node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(THighlighttoken node, T1 arg1)
        {
            return HandleTHighlighttoken(node, arg1);
        }
        public virtual Result HandleTHighlighttoken(THighlighttoken node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TNew node, T1 arg1)
        {
            return HandleTNew(node, arg1);
        }
        public virtual Result HandleTNew(TNew node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TNull node, T1 arg1)
        {
            return HandleTNull(node, arg1);
        }
        public virtual Result HandleTNull(TNull node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TTokenSpecifier node, T1 arg1)
        {
            return HandleTTokenSpecifier(node, arg1);
        }
        public virtual Result HandleTTokenSpecifier(TTokenSpecifier node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TProductionSpecifier node, T1 arg1)
        {
            return HandleTProductionSpecifier(node, arg1);
        }
        public virtual Result HandleTProductionSpecifier(TProductionSpecifier node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TDot node, T1 arg1)
        {
            return HandleTDot(node, arg1);
        }
        public virtual Result HandleTDot(TDot node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TDDot node, T1 arg1)
        {
            return HandleTDDot(node, arg1);
        }
        public virtual Result HandleTDDot(TDDot node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TSemicolon node, T1 arg1)
        {
            return HandleTSemicolon(node, arg1);
        }
        public virtual Result HandleTSemicolon(TSemicolon node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TEqual node, T1 arg1)
        {
            return HandleTEqual(node, arg1);
        }
        public virtual Result HandleTEqual(TEqual node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TLBkt node, T1 arg1)
        {
            return HandleTLBkt(node, arg1);
        }
        public virtual Result HandleTLBkt(TLBkt node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TRBkt node, T1 arg1)
        {
            return HandleTRBkt(node, arg1);
        }
        public virtual Result HandleTRBkt(TRBkt node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TLPar node, T1 arg1)
        {
            return HandleTLPar(node, arg1);
        }
        public virtual Result HandleTLPar(TLPar node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TRPar node, T1 arg1)
        {
            return HandleTRPar(node, arg1);
        }
        public virtual Result HandleTRPar(TRPar node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TLBrace node, T1 arg1)
        {
            return HandleTLBrace(node, arg1);
        }
        public virtual Result HandleTLBrace(TLBrace node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TRBrace node, T1 arg1)
        {
            return HandleTRBrace(node, arg1);
        }
        public virtual Result HandleTRBrace(TRBrace node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TPlus node, T1 arg1)
        {
            return HandleTPlus(node, arg1);
        }
        public virtual Result HandleTPlus(TPlus node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TMinus node, T1 arg1)
        {
            return HandleTMinus(node, arg1);
        }
        public virtual Result HandleTMinus(TMinus node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TQMark node, T1 arg1)
        {
            return HandleTQMark(node, arg1);
        }
        public virtual Result HandleTQMark(TQMark node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TStar node, T1 arg1)
        {
            return HandleTStar(node, arg1);
        }
        public virtual Result HandleTStar(TStar node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TPipe node, T1 arg1)
        {
            return HandleTPipe(node, arg1);
        }
        public virtual Result HandleTPipe(TPipe node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TComma node, T1 arg1)
        {
            return HandleTComma(node, arg1);
        }
        public virtual Result HandleTComma(TComma node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TSlash node, T1 arg1)
        {
            return HandleTSlash(node, arg1);
        }
        public virtual Result HandleTSlash(TSlash node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TArrow node, T1 arg1)
        {
            return HandleTArrow(node, arg1);
        }
        public virtual Result HandleTArrow(TArrow node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TColon node, T1 arg1)
        {
            return HandleTColon(node, arg1);
        }
        public virtual Result HandleTColon(TColon node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TIdentifier node, T1 arg1)
        {
            return HandleTIdentifier(node, arg1);
        }
        public virtual Result HandleTIdentifier(TIdentifier node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TCharacter node, T1 arg1)
        {
            return HandleTCharacter(node, arg1);
        }
        public virtual Result HandleTCharacter(TCharacter node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TDecChar node, T1 arg1)
        {
            return HandleTDecChar(node, arg1);
        }
        public virtual Result HandleTDecChar(TDecChar node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(THexChar node, T1 arg1)
        {
            return HandleTHexChar(node, arg1);
        }
        public virtual Result HandleTHexChar(THexChar node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TString node, T1 arg1)
        {
            return HandleTString(node, arg1);
        }
        public virtual Result HandleTString(TString node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TBlank node, T1 arg1)
        {
            return HandleTBlank(node, arg1);
        }
        public virtual Result HandleTBlank(TBlank node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TComment node, T1 arg1)
        {
            return HandleTComment(node, arg1);
        }
        public virtual Result HandleTComment(TComment node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TItalic node, T1 arg1)
        {
            return HandleTItalic(node, arg1);
        }
        public virtual Result HandleTItalic(TItalic node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TBold node, T1 arg1)
        {
            return HandleTBold(node, arg1);
        }
        public virtual Result HandleTBold(TBold node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TText node, T1 arg1)
        {
            return HandleTText(node, arg1);
        }
        public virtual Result HandleTText(TText node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TBackground node, T1 arg1)
        {
            return HandleTBackground(node, arg1);
        }
        public virtual Result HandleTBackground(TBackground node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(TRgb node, T1 arg1)
        {
            return HandleTRgb(node, arg1);
        }
        public virtual Result HandleTRgb(TRgb node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(THsv node, T1 arg1)
        {
            return HandleTHsv(node, arg1);
        }
        public virtual Result HandleTHsv(THsv node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
        public Result Visit(THexColor node, T1 arg1)
        {
            return HandleTHexColor(node, arg1);
        }
        public virtual Result HandleTHexColor(THexColor node, T1 arg1)
        {
            return HandleDefault(node, arg1);
        }
    }
    public partial class ReturnAnalysisAdapter<T1, T2, Result> : ReturnAdapter<T1, T2, Result, PGrammar>
    {
        public Result Visit(AGrammar node, T1 arg1, T2 arg2)
        {
            return HandleAGrammar(node, arg1, arg2);
        }
        public virtual Result HandleAGrammar(AGrammar node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ANamespaceSection node, T1 arg1, T2 arg2)
        {
            return HandleANamespaceSection(node, arg1, arg2);
        }
        public virtual Result HandleANamespaceSection(ANamespaceSection node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AHelpersSection node, T1 arg1, T2 arg2)
        {
            return HandleAHelpersSection(node, arg1, arg2);
        }
        public virtual Result HandleAHelpersSection(AHelpersSection node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AStatesSection node, T1 arg1, T2 arg2)
        {
            return HandleAStatesSection(node, arg1, arg2);
        }
        public virtual Result HandleAStatesSection(AStatesSection node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ATokensSection node, T1 arg1, T2 arg2)
        {
            return HandleATokensSection(node, arg1, arg2);
        }
        public virtual Result HandleATokensSection(ATokensSection node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AIgnoreSection node, T1 arg1, T2 arg2)
        {
            return HandleAIgnoreSection(node, arg1, arg2);
        }
        public virtual Result HandleAIgnoreSection(AIgnoreSection node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AProductionsSection node, T1 arg1, T2 arg2)
        {
            return HandleAProductionsSection(node, arg1, arg2);
        }
        public virtual Result HandleAProductionsSection(AProductionsSection node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AASTSection node, T1 arg1, T2 arg2)
        {
            return HandleAASTSection(node, arg1, arg2);
        }
        public virtual Result HandleAASTSection(AASTSection node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AHighlightSection node, T1 arg1, T2 arg2)
        {
            return HandleAHighlightSection(node, arg1, arg2);
        }
        public virtual Result HandleAHighlightSection(AHighlightSection node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AHelper node, T1 arg1, T2 arg2)
        {
            return HandleAHelper(node, arg1, arg2);
        }
        public virtual Result HandleAHelper(AHelper node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AToken node, T1 arg1, T2 arg2)
        {
            return HandleAToken(node, arg1, arg2);
        }
        public virtual Result HandleAToken(AToken node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ATokenlookahead node, T1 arg1, T2 arg2)
        {
            return HandleATokenlookahead(node, arg1, arg2);
        }
        public virtual Result HandleATokenlookahead(ATokenlookahead node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ACharRegex node, T1 arg1, T2 arg2)
        {
            return HandleACharRegex(node, arg1, arg2);
        }
        public virtual Result HandleACharRegex(ACharRegex node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ADecRegex node, T1 arg1, T2 arg2)
        {
            return HandleADecRegex(node, arg1, arg2);
        }
        public virtual Result HandleADecRegex(ADecRegex node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AHexRegex node, T1 arg1, T2 arg2)
        {
            return HandleAHexRegex(node, arg1, arg2);
        }
        public virtual Result HandleAHexRegex(AHexRegex node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AConcatenatedRegex node, T1 arg1, T2 arg2)
        {
            return HandleAConcatenatedRegex(node, arg1, arg2);
        }
        public virtual Result HandleAConcatenatedRegex(AConcatenatedRegex node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AUnaryRegex node, T1 arg1, T2 arg2)
        {
            return HandleAUnaryRegex(node, arg1, arg2);
        }
        public virtual Result HandleAUnaryRegex(AUnaryRegex node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ABinaryplusRegex node, T1 arg1, T2 arg2)
        {
            return HandleABinaryplusRegex(node, arg1, arg2);
        }
        public virtual Result HandleABinaryplusRegex(ABinaryplusRegex node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ABinaryminusRegex node, T1 arg1, T2 arg2)
        {
            return HandleABinaryminusRegex(node, arg1, arg2);
        }
        public virtual Result HandleABinaryminusRegex(ABinaryminusRegex node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AIntervalRegex node, T1 arg1, T2 arg2)
        {
            return HandleAIntervalRegex(node, arg1, arg2);
        }
        public virtual Result HandleAIntervalRegex(AIntervalRegex node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AStringRegex node, T1 arg1, T2 arg2)
        {
            return HandleAStringRegex(node, arg1, arg2);
        }
        public virtual Result HandleAStringRegex(AStringRegex node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AIdentifierRegex node, T1 arg1, T2 arg2)
        {
            return HandleAIdentifierRegex(node, arg1, arg2);
        }
        public virtual Result HandleAIdentifierRegex(AIdentifierRegex node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AParenthesisRegex node, T1 arg1, T2 arg2)
        {
            return HandleAParenthesisRegex(node, arg1, arg2);
        }
        public virtual Result HandleAParenthesisRegex(AParenthesisRegex node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AOrRegex node, T1 arg1, T2 arg2)
        {
            return HandleAOrRegex(node, arg1, arg2);
        }
        public virtual Result HandleAOrRegex(AOrRegex node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AStarModifier node, T1 arg1, T2 arg2)
        {
            return HandleAStarModifier(node, arg1, arg2);
        }
        public virtual Result HandleAStarModifier(AStarModifier node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AQuestionModifier node, T1 arg1, T2 arg2)
        {
            return HandleAQuestionModifier(node, arg1, arg2);
        }
        public virtual Result HandleAQuestionModifier(AQuestionModifier node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(APlusModifier node, T1 arg1, T2 arg2)
        {
            return HandleAPlusModifier(node, arg1, arg2);
        }
        public virtual Result HandleAPlusModifier(APlusModifier node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AState node, T1 arg1, T2 arg2)
        {
            return HandleAState(node, arg1, arg2);
        }
        public virtual Result HandleAState(AState node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ATokenState node, T1 arg1, T2 arg2)
        {
            return HandleATokenState(node, arg1, arg2);
        }
        public virtual Result HandleATokenState(ATokenState node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ATransitionTokenState node, T1 arg1, T2 arg2)
        {
            return HandleATransitionTokenState(node, arg1, arg2);
        }
        public virtual Result HandleATransitionTokenState(ATransitionTokenState node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AProduction node, T1 arg1, T2 arg2)
        {
            return HandleAProduction(node, arg1, arg2);
        }
        public virtual Result HandleAProduction(AProduction node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AProdtranslation node, T1 arg1, T2 arg2)
        {
            return HandleAProdtranslation(node, arg1, arg2);
        }
        public virtual Result HandleAProdtranslation(AProdtranslation node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AFullTranslation node, T1 arg1, T2 arg2)
        {
            return HandleAFullTranslation(node, arg1, arg2);
        }
        public virtual Result HandleAFullTranslation(AFullTranslation node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ANewTranslation node, T1 arg1, T2 arg2)
        {
            return HandleANewTranslation(node, arg1, arg2);
        }
        public virtual Result HandleANewTranslation(ANewTranslation node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ANewalternativeTranslation node, T1 arg1, T2 arg2)
        {
            return HandleANewalternativeTranslation(node, arg1, arg2);
        }
        public virtual Result HandleANewalternativeTranslation(ANewalternativeTranslation node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AListTranslation node, T1 arg1, T2 arg2)
        {
            return HandleAListTranslation(node, arg1, arg2);
        }
        public virtual Result HandleAListTranslation(AListTranslation node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ANullTranslation node, T1 arg1, T2 arg2)
        {
            return HandleANullTranslation(node, arg1, arg2);
        }
        public virtual Result HandleANullTranslation(ANullTranslation node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AIdTranslation node, T1 arg1, T2 arg2)
        {
            return HandleAIdTranslation(node, arg1, arg2);
        }
        public virtual Result HandleAIdTranslation(AIdTranslation node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AIddotidTranslation node, T1 arg1, T2 arg2)
        {
            return HandleAIddotidTranslation(node, arg1, arg2);
        }
        public virtual Result HandleAIddotidTranslation(AIddotidTranslation node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AAlternative node, T1 arg1, T2 arg2)
        {
            return HandleAAlternative(node, arg1, arg2);
        }
        public virtual Result HandleAAlternative(AAlternative node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AAlternativename node, T1 arg1, T2 arg2)
        {
            return HandleAAlternativename(node, arg1, arg2);
        }
        public virtual Result HandleAAlternativename(AAlternativename node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AElement node, T1 arg1, T2 arg2)
        {
            return HandleAElement(node, arg1, arg2);
        }
        public virtual Result HandleAElement(AElement node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AElementname node, T1 arg1, T2 arg2)
        {
            return HandleAElementname(node, arg1, arg2);
        }
        public virtual Result HandleAElementname(AElementname node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ACleanElementid node, T1 arg1, T2 arg2)
        {
            return HandleACleanElementid(node, arg1, arg2);
        }
        public virtual Result HandleACleanElementid(ACleanElementid node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ATokenElementid node, T1 arg1, T2 arg2)
        {
            return HandleATokenElementid(node, arg1, arg2);
        }
        public virtual Result HandleATokenElementid(ATokenElementid node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AProductionElementid node, T1 arg1, T2 arg2)
        {
            return HandleAProductionElementid(node, arg1, arg2);
        }
        public virtual Result HandleAProductionElementid(AProductionElementid node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AHighlightrule node, T1 arg1, T2 arg2)
        {
            return HandleAHighlightrule(node, arg1, arg2);
        }
        public virtual Result HandleAHighlightrule(AHighlightrule node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AItalicHighlightStyle node, T1 arg1, T2 arg2)
        {
            return HandleAItalicHighlightStyle(node, arg1, arg2);
        }
        public virtual Result HandleAItalicHighlightStyle(AItalicHighlightStyle node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ABoldHighlightStyle node, T1 arg1, T2 arg2)
        {
            return HandleABoldHighlightStyle(node, arg1, arg2);
        }
        public virtual Result HandleABoldHighlightStyle(ABoldHighlightStyle node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ATextHighlightStyle node, T1 arg1, T2 arg2)
        {
            return HandleATextHighlightStyle(node, arg1, arg2);
        }
        public virtual Result HandleATextHighlightStyle(ATextHighlightStyle node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ABackgroundHighlightStyle node, T1 arg1, T2 arg2)
        {
            return HandleABackgroundHighlightStyle(node, arg1, arg2);
        }
        public virtual Result HandleABackgroundHighlightStyle(ABackgroundHighlightStyle node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(ARgbColor node, T1 arg1, T2 arg2)
        {
            return HandleARgbColor(node, arg1, arg2);
        }
        public virtual Result HandleARgbColor(ARgbColor node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AHsvColor node, T1 arg1, T2 arg2)
        {
            return HandleAHsvColor(node, arg1, arg2);
        }
        public virtual Result HandleAHsvColor(AHsvColor node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(AHexColor node, T1 arg1, T2 arg2)
        {
            return HandleAHexColor(node, arg1, arg2);
        }
        public virtual Result HandleAHexColor(AHexColor node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TNamespace node, T1 arg1, T2 arg2)
        {
            return HandleTNamespace(node, arg1, arg2);
        }
        public virtual Result HandleTNamespace(TNamespace node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TNamespacetoken node, T1 arg1, T2 arg2)
        {
            return HandleTNamespacetoken(node, arg1, arg2);
        }
        public virtual Result HandleTNamespacetoken(TNamespacetoken node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TStatestoken node, T1 arg1, T2 arg2)
        {
            return HandleTStatestoken(node, arg1, arg2);
        }
        public virtual Result HandleTStatestoken(TStatestoken node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(THelperstoken node, T1 arg1, T2 arg2)
        {
            return HandleTHelperstoken(node, arg1, arg2);
        }
        public virtual Result HandleTHelperstoken(THelperstoken node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TTokenstoken node, T1 arg1, T2 arg2)
        {
            return HandleTTokenstoken(node, arg1, arg2);
        }
        public virtual Result HandleTTokenstoken(TTokenstoken node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TIgnoredtoken node, T1 arg1, T2 arg2)
        {
            return HandleTIgnoredtoken(node, arg1, arg2);
        }
        public virtual Result HandleTIgnoredtoken(TIgnoredtoken node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TProductionstoken node, T1 arg1, T2 arg2)
        {
            return HandleTProductionstoken(node, arg1, arg2);
        }
        public virtual Result HandleTProductionstoken(TProductionstoken node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TAsttoken node, T1 arg1, T2 arg2)
        {
            return HandleTAsttoken(node, arg1, arg2);
        }
        public virtual Result HandleTAsttoken(TAsttoken node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(THighlighttoken node, T1 arg1, T2 arg2)
        {
            return HandleTHighlighttoken(node, arg1, arg2);
        }
        public virtual Result HandleTHighlighttoken(THighlighttoken node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TNew node, T1 arg1, T2 arg2)
        {
            return HandleTNew(node, arg1, arg2);
        }
        public virtual Result HandleTNew(TNew node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TNull node, T1 arg1, T2 arg2)
        {
            return HandleTNull(node, arg1, arg2);
        }
        public virtual Result HandleTNull(TNull node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TTokenSpecifier node, T1 arg1, T2 arg2)
        {
            return HandleTTokenSpecifier(node, arg1, arg2);
        }
        public virtual Result HandleTTokenSpecifier(TTokenSpecifier node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TProductionSpecifier node, T1 arg1, T2 arg2)
        {
            return HandleTProductionSpecifier(node, arg1, arg2);
        }
        public virtual Result HandleTProductionSpecifier(TProductionSpecifier node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TDot node, T1 arg1, T2 arg2)
        {
            return HandleTDot(node, arg1, arg2);
        }
        public virtual Result HandleTDot(TDot node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TDDot node, T1 arg1, T2 arg2)
        {
            return HandleTDDot(node, arg1, arg2);
        }
        public virtual Result HandleTDDot(TDDot node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TSemicolon node, T1 arg1, T2 arg2)
        {
            return HandleTSemicolon(node, arg1, arg2);
        }
        public virtual Result HandleTSemicolon(TSemicolon node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TEqual node, T1 arg1, T2 arg2)
        {
            return HandleTEqual(node, arg1, arg2);
        }
        public virtual Result HandleTEqual(TEqual node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TLBkt node, T1 arg1, T2 arg2)
        {
            return HandleTLBkt(node, arg1, arg2);
        }
        public virtual Result HandleTLBkt(TLBkt node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TRBkt node, T1 arg1, T2 arg2)
        {
            return HandleTRBkt(node, arg1, arg2);
        }
        public virtual Result HandleTRBkt(TRBkt node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TLPar node, T1 arg1, T2 arg2)
        {
            return HandleTLPar(node, arg1, arg2);
        }
        public virtual Result HandleTLPar(TLPar node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TRPar node, T1 arg1, T2 arg2)
        {
            return HandleTRPar(node, arg1, arg2);
        }
        public virtual Result HandleTRPar(TRPar node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TLBrace node, T1 arg1, T2 arg2)
        {
            return HandleTLBrace(node, arg1, arg2);
        }
        public virtual Result HandleTLBrace(TLBrace node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TRBrace node, T1 arg1, T2 arg2)
        {
            return HandleTRBrace(node, arg1, arg2);
        }
        public virtual Result HandleTRBrace(TRBrace node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TPlus node, T1 arg1, T2 arg2)
        {
            return HandleTPlus(node, arg1, arg2);
        }
        public virtual Result HandleTPlus(TPlus node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TMinus node, T1 arg1, T2 arg2)
        {
            return HandleTMinus(node, arg1, arg2);
        }
        public virtual Result HandleTMinus(TMinus node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TQMark node, T1 arg1, T2 arg2)
        {
            return HandleTQMark(node, arg1, arg2);
        }
        public virtual Result HandleTQMark(TQMark node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TStar node, T1 arg1, T2 arg2)
        {
            return HandleTStar(node, arg1, arg2);
        }
        public virtual Result HandleTStar(TStar node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TPipe node, T1 arg1, T2 arg2)
        {
            return HandleTPipe(node, arg1, arg2);
        }
        public virtual Result HandleTPipe(TPipe node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TComma node, T1 arg1, T2 arg2)
        {
            return HandleTComma(node, arg1, arg2);
        }
        public virtual Result HandleTComma(TComma node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TSlash node, T1 arg1, T2 arg2)
        {
            return HandleTSlash(node, arg1, arg2);
        }
        public virtual Result HandleTSlash(TSlash node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TArrow node, T1 arg1, T2 arg2)
        {
            return HandleTArrow(node, arg1, arg2);
        }
        public virtual Result HandleTArrow(TArrow node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TColon node, T1 arg1, T2 arg2)
        {
            return HandleTColon(node, arg1, arg2);
        }
        public virtual Result HandleTColon(TColon node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TIdentifier node, T1 arg1, T2 arg2)
        {
            return HandleTIdentifier(node, arg1, arg2);
        }
        public virtual Result HandleTIdentifier(TIdentifier node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TCharacter node, T1 arg1, T2 arg2)
        {
            return HandleTCharacter(node, arg1, arg2);
        }
        public virtual Result HandleTCharacter(TCharacter node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TDecChar node, T1 arg1, T2 arg2)
        {
            return HandleTDecChar(node, arg1, arg2);
        }
        public virtual Result HandleTDecChar(TDecChar node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(THexChar node, T1 arg1, T2 arg2)
        {
            return HandleTHexChar(node, arg1, arg2);
        }
        public virtual Result HandleTHexChar(THexChar node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TString node, T1 arg1, T2 arg2)
        {
            return HandleTString(node, arg1, arg2);
        }
        public virtual Result HandleTString(TString node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TBlank node, T1 arg1, T2 arg2)
        {
            return HandleTBlank(node, arg1, arg2);
        }
        public virtual Result HandleTBlank(TBlank node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TComment node, T1 arg1, T2 arg2)
        {
            return HandleTComment(node, arg1, arg2);
        }
        public virtual Result HandleTComment(TComment node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TItalic node, T1 arg1, T2 arg2)
        {
            return HandleTItalic(node, arg1, arg2);
        }
        public virtual Result HandleTItalic(TItalic node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TBold node, T1 arg1, T2 arg2)
        {
            return HandleTBold(node, arg1, arg2);
        }
        public virtual Result HandleTBold(TBold node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TText node, T1 arg1, T2 arg2)
        {
            return HandleTText(node, arg1, arg2);
        }
        public virtual Result HandleTText(TText node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TBackground node, T1 arg1, T2 arg2)
        {
            return HandleTBackground(node, arg1, arg2);
        }
        public virtual Result HandleTBackground(TBackground node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(TRgb node, T1 arg1, T2 arg2)
        {
            return HandleTRgb(node, arg1, arg2);
        }
        public virtual Result HandleTRgb(TRgb node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(THsv node, T1 arg1, T2 arg2)
        {
            return HandleTHsv(node, arg1, arg2);
        }
        public virtual Result HandleTHsv(THsv node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
        public Result Visit(THexColor node, T1 arg1, T2 arg2)
        {
            return HandleTHexColor(node, arg1, arg2);
        }
        public virtual Result HandleTHexColor(THexColor node, T1 arg1, T2 arg2)
        {
            return HandleDefault(node, arg1, arg2);
        }
    }
    public partial class ReturnAnalysisAdapter<T1, T2, T3, Result> : ReturnAdapter<T1, T2, T3, Result, PGrammar>
    {
        public Result Visit(AGrammar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAGrammar(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAGrammar(AGrammar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ANamespaceSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleANamespaceSection(node, arg1, arg2, arg3);
        }
        public virtual Result HandleANamespaceSection(ANamespaceSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AHelpersSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAHelpersSection(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAHelpersSection(AHelpersSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AStatesSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAStatesSection(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAStatesSection(AStatesSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ATokensSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleATokensSection(node, arg1, arg2, arg3);
        }
        public virtual Result HandleATokensSection(ATokensSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AIgnoreSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAIgnoreSection(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAIgnoreSection(AIgnoreSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AProductionsSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAProductionsSection(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAProductionsSection(AProductionsSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AASTSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAASTSection(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAASTSection(AASTSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AHighlightSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAHighlightSection(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAHighlightSection(AHighlightSection node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AHelper node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAHelper(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAHelper(AHelper node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AToken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAToken(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAToken(AToken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ATokenlookahead node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleATokenlookahead(node, arg1, arg2, arg3);
        }
        public virtual Result HandleATokenlookahead(ATokenlookahead node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ACharRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleACharRegex(node, arg1, arg2, arg3);
        }
        public virtual Result HandleACharRegex(ACharRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ADecRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleADecRegex(node, arg1, arg2, arg3);
        }
        public virtual Result HandleADecRegex(ADecRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AHexRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAHexRegex(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAHexRegex(AHexRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AConcatenatedRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAConcatenatedRegex(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAConcatenatedRegex(AConcatenatedRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AUnaryRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAUnaryRegex(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAUnaryRegex(AUnaryRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ABinaryplusRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleABinaryplusRegex(node, arg1, arg2, arg3);
        }
        public virtual Result HandleABinaryplusRegex(ABinaryplusRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ABinaryminusRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleABinaryminusRegex(node, arg1, arg2, arg3);
        }
        public virtual Result HandleABinaryminusRegex(ABinaryminusRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AIntervalRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAIntervalRegex(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAIntervalRegex(AIntervalRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AStringRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAStringRegex(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAStringRegex(AStringRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AIdentifierRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAIdentifierRegex(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAIdentifierRegex(AIdentifierRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AParenthesisRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAParenthesisRegex(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAParenthesisRegex(AParenthesisRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AOrRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAOrRegex(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAOrRegex(AOrRegex node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AStarModifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAStarModifier(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAStarModifier(AStarModifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AQuestionModifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAQuestionModifier(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAQuestionModifier(AQuestionModifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(APlusModifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAPlusModifier(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAPlusModifier(APlusModifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AState node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAState(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAState(AState node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ATokenState node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleATokenState(node, arg1, arg2, arg3);
        }
        public virtual Result HandleATokenState(ATokenState node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ATransitionTokenState node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleATransitionTokenState(node, arg1, arg2, arg3);
        }
        public virtual Result HandleATransitionTokenState(ATransitionTokenState node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AProduction node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAProduction(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAProduction(AProduction node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AProdtranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAProdtranslation(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAProdtranslation(AProdtranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AFullTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAFullTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAFullTranslation(AFullTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ANewTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleANewTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result HandleANewTranslation(ANewTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ANewalternativeTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleANewalternativeTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result HandleANewalternativeTranslation(ANewalternativeTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AListTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAListTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAListTranslation(AListTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ANullTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleANullTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result HandleANullTranslation(ANullTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AIdTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAIdTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAIdTranslation(AIdTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AIddotidTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAIddotidTranslation(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAIddotidTranslation(AIddotidTranslation node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AAlternative node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAAlternative(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAAlternative(AAlternative node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AAlternativename node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAAlternativename(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAAlternativename(AAlternativename node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AElement node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAElement(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAElement(AElement node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AElementname node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAElementname(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAElementname(AElementname node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ACleanElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleACleanElementid(node, arg1, arg2, arg3);
        }
        public virtual Result HandleACleanElementid(ACleanElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ATokenElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleATokenElementid(node, arg1, arg2, arg3);
        }
        public virtual Result HandleATokenElementid(ATokenElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AProductionElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAProductionElementid(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAProductionElementid(AProductionElementid node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AHighlightrule node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAHighlightrule(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAHighlightrule(AHighlightrule node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AItalicHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAItalicHighlightStyle(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAItalicHighlightStyle(AItalicHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ABoldHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleABoldHighlightStyle(node, arg1, arg2, arg3);
        }
        public virtual Result HandleABoldHighlightStyle(ABoldHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ATextHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleATextHighlightStyle(node, arg1, arg2, arg3);
        }
        public virtual Result HandleATextHighlightStyle(ATextHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ABackgroundHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleABackgroundHighlightStyle(node, arg1, arg2, arg3);
        }
        public virtual Result HandleABackgroundHighlightStyle(ABackgroundHighlightStyle node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(ARgbColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleARgbColor(node, arg1, arg2, arg3);
        }
        public virtual Result HandleARgbColor(ARgbColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AHsvColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAHsvColor(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAHsvColor(AHsvColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(AHexColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleAHexColor(node, arg1, arg2, arg3);
        }
        public virtual Result HandleAHexColor(AHexColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TNamespace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTNamespace(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTNamespace(TNamespace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TNamespacetoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTNamespacetoken(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTNamespacetoken(TNamespacetoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TStatestoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTStatestoken(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTStatestoken(TStatestoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(THelperstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTHelperstoken(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTHelperstoken(THelperstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TTokenstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTTokenstoken(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTTokenstoken(TTokenstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TIgnoredtoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTIgnoredtoken(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTIgnoredtoken(TIgnoredtoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TProductionstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTProductionstoken(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTProductionstoken(TProductionstoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TAsttoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTAsttoken(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTAsttoken(TAsttoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(THighlighttoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTHighlighttoken(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTHighlighttoken(THighlighttoken node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TNew node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTNew(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTNew(TNew node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TNull node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTNull(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTNull(TNull node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TTokenSpecifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTTokenSpecifier(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTTokenSpecifier(TTokenSpecifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TProductionSpecifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTProductionSpecifier(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTProductionSpecifier(TProductionSpecifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TDot node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTDot(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTDot(TDot node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TDDot node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTDDot(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTDDot(TDDot node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TSemicolon node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTSemicolon(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTSemicolon(TSemicolon node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TEqual node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTEqual(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTEqual(TEqual node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TLBkt node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTLBkt(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTLBkt(TLBkt node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TRBkt node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTRBkt(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTRBkt(TRBkt node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TLPar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTLPar(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTLPar(TLPar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TRPar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTRPar(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTRPar(TRPar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TLBrace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTLBrace(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTLBrace(TLBrace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TRBrace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTRBrace(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTRBrace(TRBrace node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TPlus node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTPlus(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTPlus(TPlus node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TMinus node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTMinus(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTMinus(TMinus node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TQMark node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTQMark(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTQMark(TQMark node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TStar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTStar(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTStar(TStar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TPipe node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTPipe(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTPipe(TPipe node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TComma node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTComma(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTComma(TComma node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TSlash node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTSlash(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTSlash(TSlash node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TArrow node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTArrow(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTArrow(TArrow node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TColon node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTColon(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTColon(TColon node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TIdentifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTIdentifier(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTIdentifier(TIdentifier node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TCharacter node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTCharacter(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTCharacter(TCharacter node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TDecChar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTDecChar(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTDecChar(TDecChar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(THexChar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTHexChar(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTHexChar(THexChar node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TString node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTString(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTString(TString node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TBlank node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTBlank(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTBlank(TBlank node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TComment node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTComment(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTComment(TComment node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TItalic node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTItalic(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTItalic(TItalic node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TBold node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTBold(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTBold(TBold node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TText node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTText(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTText(TText node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TBackground node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTBackground(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTBackground(TBackground node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(TRgb node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTRgb(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTRgb(TRgb node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(THsv node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTHsv(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTHsv(THsv node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
        public Result Visit(THexColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleTHexColor(node, arg1, arg2, arg3);
        }
        public virtual Result HandleTHexColor(THexColor node, T1 arg1, T2 arg2, T3 arg3)
        {
            return HandleDefault(node, arg1, arg2, arg3);
        }
    }
    
    #endregion
}
