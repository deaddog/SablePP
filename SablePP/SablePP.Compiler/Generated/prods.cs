using System;
using System.Collections.Generic;
using SablePP.Tools.Nodes;
using SablePP.Compiler.Analysis;

namespace SablePP.Compiler.Nodes
{
    public abstract partial class PGrammar : Production<PGrammar>
    {
        private NodeList<PSection> _sections_;
        
        public PGrammar(IEnumerable<PSection> _sections_)
        {
            this._sections_ = new NodeList<PSection>(this, _sections_, true);
        }
        
        public NodeList<PSection> Sections
        {
            get { return _sections_; }
        }
        
    }
    public partial class AGrammar : PGrammar
    {
        public AGrammar(IEnumerable<PSection> _sections_)
            : base(_sections_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (oldChild is PSection && Sections.Contains(oldChild as PSection))
            {
                if (!(newChild is PSection) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Sections.IndexOf(oldChild as PSection);
                if (newChild == null)
                    Sections.RemoveAt(index);
                else
                    Sections[index] = newChild as PSection;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            {
                PSection[] temp = new PSection[Sections.Count];
                Sections.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PGrammar Clone()
        {
            return new AGrammar(Sections.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Sections);
        }
    }
    public abstract partial class PSection : Production<PSection>
    {
        public PSection()
        {
        }
        
    }
    public partial class ANamespaceSection : PSection
    {
        private TNamespacetoken _namespacetoken_;
        private TNamespace _namespace_;
        private TSemicolon _semicolon_;
        
        public ANamespaceSection(TNamespacetoken _namespacetoken_, TNamespace _namespace_, TSemicolon _semicolon_)
            : base()
        {
            this.Namespacetoken = _namespacetoken_;
            this.Namespace = _namespace_;
            this.Semicolon = _semicolon_;
        }
        
        public TNamespacetoken Namespacetoken
        {
            get { return _namespacetoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Namespacetoken in ANamespaceSection cannot be null.", "value");
                
                if (_namespacetoken_ != null)
                    SetParent(_namespacetoken_, null);
                SetParent(value, this);
                
                _namespacetoken_ = value;
            }
        }
        public TNamespace Namespace
        {
            get { return _namespace_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Namespace in ANamespaceSection cannot be null.", "value");
                
                if (_namespace_ != null)
                    SetParent(_namespace_, null);
                SetParent(value, this);
                
                _namespace_ = value;
            }
        }
        public TSemicolon Semicolon
        {
            get { return _semicolon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Semicolon in ANamespaceSection cannot be null.", "value");
                
                if (_semicolon_ != null)
                    SetParent(_semicolon_, null);
                SetParent(value, this);
                
                _semicolon_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Namespacetoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Namespacetoken in ANamespaceSection cannot be null.", "newChild");
                if (!(newChild is TNamespacetoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Namespacetoken = newChild as TNamespacetoken;
            }
            else if (Namespace == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Namespace in ANamespaceSection cannot be null.", "newChild");
                if (!(newChild is TNamespace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Namespace = newChild as TNamespace;
            }
            else if (Semicolon == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Semicolon in ANamespaceSection cannot be null.", "newChild");
                if (!(newChild is TSemicolon) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Semicolon = newChild as TSemicolon;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Namespacetoken;
            yield return Namespace;
            yield return Semicolon;
        }
        
        public override PSection Clone()
        {
            return new ANamespaceSection(Namespacetoken.Clone(), Namespace.Clone(), Semicolon.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Namespacetoken, Namespace, Semicolon);
        }
    }
    public partial class AHelpersSection : PSection
    {
        private THelperstoken _helperstoken_;
        private NodeList<PHelper> _helpers_;
        
        public AHelpersSection(THelperstoken _helperstoken_, IEnumerable<PHelper> _helpers_)
            : base()
        {
            this.Helperstoken = _helperstoken_;
            this._helpers_ = new NodeList<PHelper>(this, _helpers_, true);
        }
        
        public THelperstoken Helperstoken
        {
            get { return _helperstoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Helperstoken in AHelpersSection cannot be null.", "value");
                
                if (_helperstoken_ != null)
                    SetParent(_helperstoken_, null);
                SetParent(value, this);
                
                _helperstoken_ = value;
            }
        }
        public NodeList<PHelper> Helpers
        {
            get { return _helpers_; }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Helperstoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Helperstoken in AHelpersSection cannot be null.", "newChild");
                if (!(newChild is THelperstoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Helperstoken = newChild as THelperstoken;
            }
            else if (oldChild is PHelper && Helpers.Contains(oldChild as PHelper))
            {
                if (!(newChild is PHelper) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Helpers.IndexOf(oldChild as PHelper);
                if (newChild == null)
                    Helpers.RemoveAt(index);
                else
                    Helpers[index] = newChild as PHelper;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Helperstoken;
            {
                PHelper[] temp = new PHelper[Helpers.Count];
                Helpers.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PSection Clone()
        {
            return new AHelpersSection(Helperstoken.Clone(), Helpers.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Helperstoken, Helpers);
        }
    }
    public partial class AStatesSection : PSection
    {
        private TStatestoken _statestoken_;
        private NodeList<PState> _states_;
        private TSemicolon _semicolon_;
        
        public AStatesSection(TStatestoken _statestoken_, IEnumerable<PState> _states_, TSemicolon _semicolon_)
            : base()
        {
            this.Statestoken = _statestoken_;
            this._states_ = new NodeList<PState>(this, _states_, false);
            this.Semicolon = _semicolon_;
        }
        
        public TStatestoken Statestoken
        {
            get { return _statestoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Statestoken in AStatesSection cannot be null.", "value");
                
                if (_statestoken_ != null)
                    SetParent(_statestoken_, null);
                SetParent(value, this);
                
                _statestoken_ = value;
            }
        }
        public NodeList<PState> States
        {
            get { return _states_; }
        }
        public TSemicolon Semicolon
        {
            get { return _semicolon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Semicolon in AStatesSection cannot be null.", "value");
                
                if (_semicolon_ != null)
                    SetParent(_semicolon_, null);
                SetParent(value, this);
                
                _semicolon_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Statestoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Statestoken in AStatesSection cannot be null.", "newChild");
                if (!(newChild is TStatestoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Statestoken = newChild as TStatestoken;
            }
            else if (oldChild is PState && States.Contains(oldChild as PState))
            {
                if (!(newChild is PState) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = States.IndexOf(oldChild as PState);
                if (newChild == null)
                    States.RemoveAt(index);
                else
                    States[index] = newChild as PState;
            }
            else if (Semicolon == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Semicolon in AStatesSection cannot be null.", "newChild");
                if (!(newChild is TSemicolon) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Semicolon = newChild as TSemicolon;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Statestoken;
            {
                PState[] temp = new PState[States.Count];
                States.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Semicolon;
        }
        
        public override PSection Clone()
        {
            return new AStatesSection(Statestoken.Clone(), States.Clone(), Semicolon.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Statestoken, States, Semicolon);
        }
    }
    public partial class ATokensSection : PSection
    {
        private TTokenstoken _tokenstoken_;
        private NodeList<PToken> _tokens_;
        
        public ATokensSection(TTokenstoken _tokenstoken_, IEnumerable<PToken> _tokens_)
            : base()
        {
            this.Tokenstoken = _tokenstoken_;
            this._tokens_ = new NodeList<PToken>(this, _tokens_, true);
        }
        
        public TTokenstoken Tokenstoken
        {
            get { return _tokenstoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Tokenstoken in ATokensSection cannot be null.", "value");
                
                if (_tokenstoken_ != null)
                    SetParent(_tokenstoken_, null);
                SetParent(value, this);
                
                _tokenstoken_ = value;
            }
        }
        public NodeList<PToken> Tokens
        {
            get { return _tokens_; }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Tokenstoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Tokenstoken in ATokensSection cannot be null.", "newChild");
                if (!(newChild is TTokenstoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Tokenstoken = newChild as TTokenstoken;
            }
            else if (oldChild is PToken && Tokens.Contains(oldChild as PToken))
            {
                if (!(newChild is PToken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Tokens.IndexOf(oldChild as PToken);
                if (newChild == null)
                    Tokens.RemoveAt(index);
                else
                    Tokens[index] = newChild as PToken;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Tokenstoken;
            {
                PToken[] temp = new PToken[Tokens.Count];
                Tokens.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PSection Clone()
        {
            return new ATokensSection(Tokenstoken.Clone(), Tokens.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Tokenstoken, Tokens);
        }
    }
    public partial class AIgnoreSection : PSection
    {
        private TIgnoredtoken _ignoredtoken_;
        private TTokenstoken _tokenstoken_;
        private NodeList<TIdentifier> _tokens_;
        private TSemicolon _semicolon_;
        
        public AIgnoreSection(TIgnoredtoken _ignoredtoken_, TTokenstoken _tokenstoken_, IEnumerable<TIdentifier> _tokens_, TSemicolon _semicolon_)
            : base()
        {
            this.Ignoredtoken = _ignoredtoken_;
            this.Tokenstoken = _tokenstoken_;
            this._tokens_ = new NodeList<TIdentifier>(this, _tokens_, false);
            this.Semicolon = _semicolon_;
        }
        
        public TIgnoredtoken Ignoredtoken
        {
            get { return _ignoredtoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Ignoredtoken in AIgnoreSection cannot be null.", "value");
                
                if (_ignoredtoken_ != null)
                    SetParent(_ignoredtoken_, null);
                SetParent(value, this);
                
                _ignoredtoken_ = value;
            }
        }
        public TTokenstoken Tokenstoken
        {
            get { return _tokenstoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Tokenstoken in AIgnoreSection cannot be null.", "value");
                
                if (_tokenstoken_ != null)
                    SetParent(_tokenstoken_, null);
                SetParent(value, this);
                
                _tokenstoken_ = value;
            }
        }
        public NodeList<TIdentifier> Tokens
        {
            get { return _tokens_; }
        }
        public TSemicolon Semicolon
        {
            get { return _semicolon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Semicolon in AIgnoreSection cannot be null.", "value");
                
                if (_semicolon_ != null)
                    SetParent(_semicolon_, null);
                SetParent(value, this);
                
                _semicolon_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Ignoredtoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Ignoredtoken in AIgnoreSection cannot be null.", "newChild");
                if (!(newChild is TIgnoredtoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Ignoredtoken = newChild as TIgnoredtoken;
            }
            else if (Tokenstoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Tokenstoken in AIgnoreSection cannot be null.", "newChild");
                if (!(newChild is TTokenstoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Tokenstoken = newChild as TTokenstoken;
            }
            else if (oldChild is TIdentifier && Tokens.Contains(oldChild as TIdentifier))
            {
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Tokens.IndexOf(oldChild as TIdentifier);
                if (newChild == null)
                    Tokens.RemoveAt(index);
                else
                    Tokens[index] = newChild as TIdentifier;
            }
            else if (Semicolon == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Semicolon in AIgnoreSection cannot be null.", "newChild");
                if (!(newChild is TSemicolon) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Semicolon = newChild as TSemicolon;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Ignoredtoken;
            yield return Tokenstoken;
            {
                TIdentifier[] temp = new TIdentifier[Tokens.Count];
                Tokens.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Semicolon;
        }
        
        public override PSection Clone()
        {
            return new AIgnoreSection(Ignoredtoken.Clone(), Tokenstoken.Clone(), Tokens.Clone(), Semicolon.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Ignoredtoken, Tokenstoken, Tokens, Semicolon);
        }
    }
    public partial class AProductionsSection : PSection
    {
        private TProductionstoken _productionstoken_;
        private NodeList<PProduction> _productions_;
        
        public AProductionsSection(TProductionstoken _productionstoken_, IEnumerable<PProduction> _productions_)
            : base()
        {
            this.Productionstoken = _productionstoken_;
            this._productions_ = new NodeList<PProduction>(this, _productions_, false);
        }
        
        public TProductionstoken Productionstoken
        {
            get { return _productionstoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Productionstoken in AProductionsSection cannot be null.", "value");
                
                if (_productionstoken_ != null)
                    SetParent(_productionstoken_, null);
                SetParent(value, this);
                
                _productionstoken_ = value;
            }
        }
        public NodeList<PProduction> Productions
        {
            get { return _productions_; }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Productionstoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Productionstoken in AProductionsSection cannot be null.", "newChild");
                if (!(newChild is TProductionstoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Productionstoken = newChild as TProductionstoken;
            }
            else if (oldChild is PProduction && Productions.Contains(oldChild as PProduction))
            {
                if (!(newChild is PProduction) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Productions.IndexOf(oldChild as PProduction);
                if (newChild == null)
                    Productions.RemoveAt(index);
                else
                    Productions[index] = newChild as PProduction;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Productionstoken;
            {
                PProduction[] temp = new PProduction[Productions.Count];
                Productions.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PSection Clone()
        {
            return new AProductionsSection(Productionstoken.Clone(), Productions.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Productionstoken, Productions);
        }
    }
    public partial class AASTSection : PSection
    {
        private TAsttoken _asttoken_;
        private NodeList<PProduction> _productions_;
        
        public AASTSection(TAsttoken _asttoken_, IEnumerable<PProduction> _productions_)
            : base()
        {
            this.Asttoken = _asttoken_;
            this._productions_ = new NodeList<PProduction>(this, _productions_, false);
        }
        
        public TAsttoken Asttoken
        {
            get { return _asttoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Asttoken in AASTSection cannot be null.", "value");
                
                if (_asttoken_ != null)
                    SetParent(_asttoken_, null);
                SetParent(value, this);
                
                _asttoken_ = value;
            }
        }
        public NodeList<PProduction> Productions
        {
            get { return _productions_; }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Asttoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Asttoken in AASTSection cannot be null.", "newChild");
                if (!(newChild is TAsttoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Asttoken = newChild as TAsttoken;
            }
            else if (oldChild is PProduction && Productions.Contains(oldChild as PProduction))
            {
                if (!(newChild is PProduction) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Productions.IndexOf(oldChild as PProduction);
                if (newChild == null)
                    Productions.RemoveAt(index);
                else
                    Productions[index] = newChild as PProduction;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Asttoken;
            {
                PProduction[] temp = new PProduction[Productions.Count];
                Productions.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PSection Clone()
        {
            return new AASTSection(Asttoken.Clone(), Productions.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Asttoken, Productions);
        }
    }
    public partial class AHighlightSection : PSection
    {
        private THighlighttoken _highlighttoken_;
        private NodeList<PHighlightrule> _highlightrules_;
        
        public AHighlightSection(THighlighttoken _highlighttoken_, IEnumerable<PHighlightrule> _highlightrules_)
            : base()
        {
            this.Highlighttoken = _highlighttoken_;
            this._highlightrules_ = new NodeList<PHighlightrule>(this, _highlightrules_, false);
        }
        
        public THighlighttoken Highlighttoken
        {
            get { return _highlighttoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Highlighttoken in AHighlightSection cannot be null.", "value");
                
                if (_highlighttoken_ != null)
                    SetParent(_highlighttoken_, null);
                SetParent(value, this);
                
                _highlighttoken_ = value;
            }
        }
        public NodeList<PHighlightrule> Highlightrules
        {
            get { return _highlightrules_; }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Highlighttoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Highlighttoken in AHighlightSection cannot be null.", "newChild");
                if (!(newChild is THighlighttoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Highlighttoken = newChild as THighlighttoken;
            }
            else if (oldChild is PHighlightrule && Highlightrules.Contains(oldChild as PHighlightrule))
            {
                if (!(newChild is PHighlightrule) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Highlightrules.IndexOf(oldChild as PHighlightrule);
                if (newChild == null)
                    Highlightrules.RemoveAt(index);
                else
                    Highlightrules[index] = newChild as PHighlightrule;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Highlighttoken;
            {
                PHighlightrule[] temp = new PHighlightrule[Highlightrules.Count];
                Highlightrules.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PSection Clone()
        {
            return new AHighlightSection(Highlighttoken.Clone(), Highlightrules.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Highlighttoken, Highlightrules);
        }
    }
    public abstract partial class PHelper : Production<PHelper>
    {
        private TIdentifier _identifier_;
        private TEqual _equal_;
        private PRegex _regex_;
        private TSemicolon _semicolon_;
        
        public PHelper(TIdentifier _identifier_, TEqual _equal_, PRegex _regex_, TSemicolon _semicolon_)
        {
            this.Identifier = _identifier_;
            this.Equal = _equal_;
            this.Regex = _regex_;
            this.Semicolon = _semicolon_;
        }
        
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in PHelper cannot be null.", "value");
                
                if (_identifier_ != null)
                    SetParent(_identifier_, null);
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        public TEqual Equal
        {
            get { return _equal_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Equal in PHelper cannot be null.", "value");
                
                if (_equal_ != null)
                    SetParent(_equal_, null);
                SetParent(value, this);
                
                _equal_ = value;
            }
        }
        public PRegex Regex
        {
            get { return _regex_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Regex in PHelper cannot be null.", "value");
                
                if (_regex_ != null)
                    SetParent(_regex_, null);
                SetParent(value, this);
                
                _regex_ = value;
            }
        }
        public TSemicolon Semicolon
        {
            get { return _semicolon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Semicolon in PHelper cannot be null.", "value");
                
                if (_semicolon_ != null)
                    SetParent(_semicolon_, null);
                SetParent(value, this);
                
                _semicolon_ = value;
            }
        }
        
    }
    public partial class AHelper : PHelper
    {
        public AHelper(TIdentifier _identifier_, TEqual _equal_, PRegex _regex_, TSemicolon _semicolon_)
            : base(_identifier_, _equal_, _regex_, _semicolon_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in AHelper cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else if (Equal == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Equal in AHelper cannot be null.", "newChild");
                if (!(newChild is TEqual) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Equal = newChild as TEqual;
            }
            else if (Regex == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Regex in AHelper cannot be null.", "newChild");
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Regex = newChild as PRegex;
            }
            else if (Semicolon == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Semicolon in AHelper cannot be null.", "newChild");
                if (!(newChild is TSemicolon) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Semicolon = newChild as TSemicolon;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Identifier;
            yield return Equal;
            yield return Regex;
            yield return Semicolon;
        }
        
        public override PHelper Clone()
        {
            return new AHelper(Identifier.Clone(), Equal.Clone(), Regex.Clone(), Semicolon.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Identifier, Equal, Regex, Semicolon);
        }
    }
    public abstract partial class PToken : Production<PToken>
    {
        private NodeList<PTokenState> _statelist_;
        private TIdentifier _identifier_;
        private TEqual _equal_;
        private PRegex _regex_;
        private PTokenlookahead _tokenlookahead_;
        private TSemicolon _semicolon_;
        
        public PToken(IEnumerable<PTokenState> _statelist_, TIdentifier _identifier_, TEqual _equal_, PRegex _regex_, PTokenlookahead _tokenlookahead_, TSemicolon _semicolon_)
        {
            this._statelist_ = new NodeList<PTokenState>(this, _statelist_, true);
            this.Identifier = _identifier_;
            this.Equal = _equal_;
            this.Regex = _regex_;
            this.Tokenlookahead = _tokenlookahead_;
            this.Semicolon = _semicolon_;
        }
        
        public NodeList<PTokenState> Statelist
        {
            get { return _statelist_; }
        }
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in PToken cannot be null.", "value");
                
                if (_identifier_ != null)
                    SetParent(_identifier_, null);
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        public TEqual Equal
        {
            get { return _equal_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Equal in PToken cannot be null.", "value");
                
                if (_equal_ != null)
                    SetParent(_equal_, null);
                SetParent(value, this);
                
                _equal_ = value;
            }
        }
        public PRegex Regex
        {
            get { return _regex_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Regex in PToken cannot be null.", "value");
                
                if (_regex_ != null)
                    SetParent(_regex_, null);
                SetParent(value, this);
                
                _regex_ = value;
            }
        }
        public PTokenlookahead Tokenlookahead
        {
            get { return _tokenlookahead_; }
            set
            {
                if (_tokenlookahead_ != null)
                    SetParent(_tokenlookahead_, null);
                if (value != null)
                    SetParent(value, this);
                
                _tokenlookahead_ = value;
            }
        }
        public bool HasTokenlookahead
        {
            get { return _tokenlookahead_ != null; }
        }
        public TSemicolon Semicolon
        {
            get { return _semicolon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Semicolon in PToken cannot be null.", "value");
                
                if (_semicolon_ != null)
                    SetParent(_semicolon_, null);
                SetParent(value, this);
                
                _semicolon_ = value;
            }
        }
        
    }
    public partial class AToken : PToken
    {
        public AToken(IEnumerable<PTokenState> _statelist_, TIdentifier _identifier_, TEqual _equal_, PRegex _regex_, PTokenlookahead _tokenlookahead_, TSemicolon _semicolon_)
            : base(_statelist_, _identifier_, _equal_, _regex_, _tokenlookahead_, _semicolon_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (oldChild is PTokenState && Statelist.Contains(oldChild as PTokenState))
            {
                if (!(newChild is PTokenState) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Statelist.IndexOf(oldChild as PTokenState);
                if (newChild == null)
                    Statelist.RemoveAt(index);
                else
                    Statelist[index] = newChild as PTokenState;
            }
            else if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in AToken cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else if (Equal == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Equal in AToken cannot be null.", "newChild");
                if (!(newChild is TEqual) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Equal = newChild as TEqual;
            }
            else if (Regex == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Regex in AToken cannot be null.", "newChild");
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Regex = newChild as PRegex;
            }
            else if (Tokenlookahead == oldChild)
            {
                if (!(newChild is PTokenlookahead) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Tokenlookahead = newChild as PTokenlookahead;
            }
            else if (Semicolon == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Semicolon in AToken cannot be null.", "newChild");
                if (!(newChild is TSemicolon) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Semicolon = newChild as TSemicolon;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            {
                PTokenState[] temp = new PTokenState[Statelist.Count];
                Statelist.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Identifier;
            yield return Equal;
            yield return Regex;
            if (HasTokenlookahead)
                yield return Tokenlookahead;
            yield return Semicolon;
        }
        
        public override PToken Clone()
        {
            return new AToken(Statelist.Clone(), Identifier.Clone(), Equal.Clone(), Regex.Clone(), Tokenlookahead?.Clone(), Semicolon.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", Statelist, Identifier, Equal, Regex, Tokenlookahead, Semicolon);
        }
    }
    public abstract partial class PTokenlookahead : Production<PTokenlookahead>
    {
        private TSlash _slash_;
        private PRegex _regex_;
        
        public PTokenlookahead(TSlash _slash_, PRegex _regex_)
        {
            this.Slash = _slash_;
            this.Regex = _regex_;
        }
        
        public TSlash Slash
        {
            get { return _slash_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Slash in PTokenlookahead cannot be null.", "value");
                
                if (_slash_ != null)
                    SetParent(_slash_, null);
                SetParent(value, this);
                
                _slash_ = value;
            }
        }
        public PRegex Regex
        {
            get { return _regex_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Regex in PTokenlookahead cannot be null.", "value");
                
                if (_regex_ != null)
                    SetParent(_regex_, null);
                SetParent(value, this);
                
                _regex_ = value;
            }
        }
        
    }
    public partial class ATokenlookahead : PTokenlookahead
    {
        public ATokenlookahead(TSlash _slash_, PRegex _regex_)
            : base(_slash_, _regex_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Slash == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Slash in ATokenlookahead cannot be null.", "newChild");
                if (!(newChild is TSlash) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Slash = newChild as TSlash;
            }
            else if (Regex == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Regex in ATokenlookahead cannot be null.", "newChild");
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Regex = newChild as PRegex;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Slash;
            yield return Regex;
        }
        
        public override PTokenlookahead Clone()
        {
            return new ATokenlookahead(Slash.Clone(), Regex.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Slash, Regex);
        }
    }
    public abstract partial class PRegex : Production<PRegex>
    {
        public PRegex()
        {
        }
        
    }
    public partial class ACharRegex : PRegex
    {
        private TCharacter _character_;
        
        public ACharRegex(TCharacter _character_)
            : base()
        {
            this.Character = _character_;
        }
        
        public TCharacter Character
        {
            get { return _character_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Character in ACharRegex cannot be null.", "value");
                
                if (_character_ != null)
                    SetParent(_character_, null);
                SetParent(value, this);
                
                _character_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Character == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Character in ACharRegex cannot be null.", "newChild");
                if (!(newChild is TCharacter) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Character = newChild as TCharacter;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Character;
        }
        
        public override PRegex Clone()
        {
            return new ACharRegex(Character.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Character);
        }
    }
    public partial class ADecRegex : PRegex
    {
        private TDecChar _decchar_;
        
        public ADecRegex(TDecChar _decchar_)
            : base()
        {
            this.DecChar = _decchar_;
        }
        
        public TDecChar DecChar
        {
            get { return _decchar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("DecChar in ADecRegex cannot be null.", "value");
                
                if (_decchar_ != null)
                    SetParent(_decchar_, null);
                SetParent(value, this);
                
                _decchar_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (DecChar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("DecChar in ADecRegex cannot be null.", "newChild");
                if (!(newChild is TDecChar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                DecChar = newChild as TDecChar;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return DecChar;
        }
        
        public override PRegex Clone()
        {
            return new ADecRegex(DecChar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", DecChar);
        }
    }
    public partial class AHexRegex : PRegex
    {
        private THexChar _hexchar_;
        
        public AHexRegex(THexChar _hexchar_)
            : base()
        {
            this.HexChar = _hexchar_;
        }
        
        public THexChar HexChar
        {
            get { return _hexchar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("HexChar in AHexRegex cannot be null.", "value");
                
                if (_hexchar_ != null)
                    SetParent(_hexchar_, null);
                SetParent(value, this);
                
                _hexchar_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (HexChar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("HexChar in AHexRegex cannot be null.", "newChild");
                if (!(newChild is THexChar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                HexChar = newChild as THexChar;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return HexChar;
        }
        
        public override PRegex Clone()
        {
            return new AHexRegex(HexChar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", HexChar);
        }
    }
    public partial class AConcatenatedRegex : PRegex
    {
        private NodeList<PRegex> _regexs_;
        
        public AConcatenatedRegex(IEnumerable<PRegex> _regexs_)
            : base()
        {
            this._regexs_ = new NodeList<PRegex>(this, _regexs_, false);
        }
        
        public NodeList<PRegex> Regexs
        {
            get { return _regexs_; }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (oldChild is PRegex && Regexs.Contains(oldChild as PRegex))
            {
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Regexs.IndexOf(oldChild as PRegex);
                if (newChild == null)
                    Regexs.RemoveAt(index);
                else
                    Regexs[index] = newChild as PRegex;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            {
                PRegex[] temp = new PRegex[Regexs.Count];
                Regexs.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PRegex Clone()
        {
            return new AConcatenatedRegex(Regexs.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Regexs);
        }
    }
    public partial class AUnaryRegex : PRegex
    {
        private PRegex _regex_;
        private PModifier _modifier_;
        
        public AUnaryRegex(PRegex _regex_, PModifier _modifier_)
            : base()
        {
            this.Regex = _regex_;
            this.Modifier = _modifier_;
        }
        
        public PRegex Regex
        {
            get { return _regex_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Regex in AUnaryRegex cannot be null.", "value");
                
                if (_regex_ != null)
                    SetParent(_regex_, null);
                SetParent(value, this);
                
                _regex_ = value;
            }
        }
        public PModifier Modifier
        {
            get { return _modifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Modifier in AUnaryRegex cannot be null.", "value");
                
                if (_modifier_ != null)
                    SetParent(_modifier_, null);
                SetParent(value, this);
                
                _modifier_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Regex == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Regex in AUnaryRegex cannot be null.", "newChild");
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Regex = newChild as PRegex;
            }
            else if (Modifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Modifier in AUnaryRegex cannot be null.", "newChild");
                if (!(newChild is PModifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Modifier = newChild as PModifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Regex;
            yield return Modifier;
        }
        
        public override PRegex Clone()
        {
            return new AUnaryRegex(Regex.Clone(), Modifier.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Regex, Modifier);
        }
    }
    public partial class ABinaryplusRegex : PRegex
    {
        private TLBkt _lpar_;
        private PRegex _left_;
        private TPlus _plus_;
        private PRegex _right_;
        private TRBkt _rpar_;
        
        public ABinaryplusRegex(TLBkt _lpar_, PRegex _left_, TPlus _plus_, PRegex _right_, TRBkt _rpar_)
            : base()
        {
            this.Lpar = _lpar_;
            this.Left = _left_;
            this.Plus = _plus_;
            this.Right = _right_;
            this.Rpar = _rpar_;
        }
        
        public TLBkt Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in ABinaryplusRegex cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public PRegex Left
        {
            get { return _left_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Left in ABinaryplusRegex cannot be null.", "value");
                
                if (_left_ != null)
                    SetParent(_left_, null);
                SetParent(value, this);
                
                _left_ = value;
            }
        }
        public TPlus Plus
        {
            get { return _plus_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Plus in ABinaryplusRegex cannot be null.", "value");
                
                if (_plus_ != null)
                    SetParent(_plus_, null);
                SetParent(value, this);
                
                _plus_ = value;
            }
        }
        public PRegex Right
        {
            get { return _right_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Right in ABinaryplusRegex cannot be null.", "value");
                
                if (_right_ != null)
                    SetParent(_right_, null);
                SetParent(value, this);
                
                _right_ = value;
            }
        }
        public TRBkt Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in ABinaryplusRegex cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in ABinaryplusRegex cannot be null.", "newChild");
                if (!(newChild is TLBkt) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBkt;
            }
            else if (Left == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Left in ABinaryplusRegex cannot be null.", "newChild");
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Left = newChild as PRegex;
            }
            else if (Plus == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Plus in ABinaryplusRegex cannot be null.", "newChild");
                if (!(newChild is TPlus) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Plus = newChild as TPlus;
            }
            else if (Right == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Right in ABinaryplusRegex cannot be null.", "newChild");
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Right = newChild as PRegex;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in ABinaryplusRegex cannot be null.", "newChild");
                if (!(newChild is TRBkt) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBkt;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            yield return Left;
            yield return Plus;
            yield return Right;
            yield return Rpar;
        }
        
        public override PRegex Clone()
        {
            return new ABinaryplusRegex(Lpar.Clone(), Left.Clone(), Plus.Clone(), Right.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Lpar, Left, Plus, Right, Rpar);
        }
    }
    public partial class ABinaryminusRegex : PRegex
    {
        private TLBkt _lpar_;
        private PRegex _left_;
        private TMinus _minus_;
        private PRegex _right_;
        private TRBkt _rpar_;
        
        public ABinaryminusRegex(TLBkt _lpar_, PRegex _left_, TMinus _minus_, PRegex _right_, TRBkt _rpar_)
            : base()
        {
            this.Lpar = _lpar_;
            this.Left = _left_;
            this.Minus = _minus_;
            this.Right = _right_;
            this.Rpar = _rpar_;
        }
        
        public TLBkt Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in ABinaryminusRegex cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public PRegex Left
        {
            get { return _left_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Left in ABinaryminusRegex cannot be null.", "value");
                
                if (_left_ != null)
                    SetParent(_left_, null);
                SetParent(value, this);
                
                _left_ = value;
            }
        }
        public TMinus Minus
        {
            get { return _minus_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Minus in ABinaryminusRegex cannot be null.", "value");
                
                if (_minus_ != null)
                    SetParent(_minus_, null);
                SetParent(value, this);
                
                _minus_ = value;
            }
        }
        public PRegex Right
        {
            get { return _right_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Right in ABinaryminusRegex cannot be null.", "value");
                
                if (_right_ != null)
                    SetParent(_right_, null);
                SetParent(value, this);
                
                _right_ = value;
            }
        }
        public TRBkt Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in ABinaryminusRegex cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in ABinaryminusRegex cannot be null.", "newChild");
                if (!(newChild is TLBkt) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBkt;
            }
            else if (Left == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Left in ABinaryminusRegex cannot be null.", "newChild");
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Left = newChild as PRegex;
            }
            else if (Minus == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Minus in ABinaryminusRegex cannot be null.", "newChild");
                if (!(newChild is TMinus) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Minus = newChild as TMinus;
            }
            else if (Right == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Right in ABinaryminusRegex cannot be null.", "newChild");
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Right = newChild as PRegex;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in ABinaryminusRegex cannot be null.", "newChild");
                if (!(newChild is TRBkt) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBkt;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            yield return Left;
            yield return Minus;
            yield return Right;
            yield return Rpar;
        }
        
        public override PRegex Clone()
        {
            return new ABinaryminusRegex(Lpar.Clone(), Left.Clone(), Minus.Clone(), Right.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Lpar, Left, Minus, Right, Rpar);
        }
    }
    public partial class AIntervalRegex : PRegex
    {
        private TLBkt _lpar_;
        private PRegex _left_;
        private TDDot _dots_;
        private PRegex _right_;
        private TRBkt _rpar_;
        
        public AIntervalRegex(TLBkt _lpar_, PRegex _left_, TDDot _dots_, PRegex _right_, TRBkt _rpar_)
            : base()
        {
            this.Lpar = _lpar_;
            this.Left = _left_;
            this.Dots = _dots_;
            this.Right = _right_;
            this.Rpar = _rpar_;
        }
        
        public TLBkt Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in AIntervalRegex cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public PRegex Left
        {
            get { return _left_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Left in AIntervalRegex cannot be null.", "value");
                
                if (_left_ != null)
                    SetParent(_left_, null);
                SetParent(value, this);
                
                _left_ = value;
            }
        }
        public TDDot Dots
        {
            get { return _dots_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Dots in AIntervalRegex cannot be null.", "value");
                
                if (_dots_ != null)
                    SetParent(_dots_, null);
                SetParent(value, this);
                
                _dots_ = value;
            }
        }
        public PRegex Right
        {
            get { return _right_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Right in AIntervalRegex cannot be null.", "value");
                
                if (_right_ != null)
                    SetParent(_right_, null);
                SetParent(value, this);
                
                _right_ = value;
            }
        }
        public TRBkt Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in AIntervalRegex cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in AIntervalRegex cannot be null.", "newChild");
                if (!(newChild is TLBkt) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBkt;
            }
            else if (Left == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Left in AIntervalRegex cannot be null.", "newChild");
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Left = newChild as PRegex;
            }
            else if (Dots == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Dots in AIntervalRegex cannot be null.", "newChild");
                if (!(newChild is TDDot) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Dots = newChild as TDDot;
            }
            else if (Right == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Right in AIntervalRegex cannot be null.", "newChild");
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Right = newChild as PRegex;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in AIntervalRegex cannot be null.", "newChild");
                if (!(newChild is TRBkt) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBkt;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            yield return Left;
            yield return Dots;
            yield return Right;
            yield return Rpar;
        }
        
        public override PRegex Clone()
        {
            return new AIntervalRegex(Lpar.Clone(), Left.Clone(), Dots.Clone(), Right.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Lpar, Left, Dots, Right, Rpar);
        }
    }
    public partial class AStringRegex : PRegex
    {
        private TString _string_;
        
        public AStringRegex(TString _string_)
            : base()
        {
            this.String = _string_;
        }
        
        public TString String
        {
            get { return _string_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("String in AStringRegex cannot be null.", "value");
                
                if (_string_ != null)
                    SetParent(_string_, null);
                SetParent(value, this);
                
                _string_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (String == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("String in AStringRegex cannot be null.", "newChild");
                if (!(newChild is TString) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                String = newChild as TString;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return String;
        }
        
        public override PRegex Clone()
        {
            return new AStringRegex(String.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", String);
        }
    }
    public partial class AIdentifierRegex : PRegex
    {
        private TIdentifier _identifier_;
        
        public AIdentifierRegex(TIdentifier _identifier_)
            : base()
        {
            this.Identifier = _identifier_;
        }
        
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in AIdentifierRegex cannot be null.", "value");
                
                if (_identifier_ != null)
                    SetParent(_identifier_, null);
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in AIdentifierRegex cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Identifier;
        }
        
        public override PRegex Clone()
        {
            return new AIdentifierRegex(Identifier.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Identifier);
        }
    }
    public partial class AParenthesisRegex : PRegex
    {
        private TLPar _lpar_;
        private PRegex _regex_;
        private TRPar _rpar_;
        
        public AParenthesisRegex(TLPar _lpar_, PRegex _regex_, TRPar _rpar_)
            : base()
        {
            this.Lpar = _lpar_;
            this.Regex = _regex_;
            this.Rpar = _rpar_;
        }
        
        public TLPar Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in AParenthesisRegex cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public PRegex Regex
        {
            get { return _regex_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Regex in AParenthesisRegex cannot be null.", "value");
                
                if (_regex_ != null)
                    SetParent(_regex_, null);
                SetParent(value, this);
                
                _regex_ = value;
            }
        }
        public TRPar Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in AParenthesisRegex cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in AParenthesisRegex cannot be null.", "newChild");
                if (!(newChild is TLPar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLPar;
            }
            else if (Regex == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Regex in AParenthesisRegex cannot be null.", "newChild");
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Regex = newChild as PRegex;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in AParenthesisRegex cannot be null.", "newChild");
                if (!(newChild is TRPar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRPar;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            yield return Regex;
            yield return Rpar;
        }
        
        public override PRegex Clone()
        {
            return new AParenthesisRegex(Lpar.Clone(), Regex.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Lpar, Regex, Rpar);
        }
    }
    public partial class AOrRegex : PRegex
    {
        private NodeList<PRegex> _regexs_;
        
        public AOrRegex(IEnumerable<PRegex> _regexs_)
            : base()
        {
            this._regexs_ = new NodeList<PRegex>(this, _regexs_, false);
        }
        
        public NodeList<PRegex> Regexs
        {
            get { return _regexs_; }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (oldChild is PRegex && Regexs.Contains(oldChild as PRegex))
            {
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Regexs.IndexOf(oldChild as PRegex);
                if (newChild == null)
                    Regexs.RemoveAt(index);
                else
                    Regexs[index] = newChild as PRegex;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            {
                PRegex[] temp = new PRegex[Regexs.Count];
                Regexs.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PRegex Clone()
        {
            return new AOrRegex(Regexs.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Regexs);
        }
    }
    public abstract partial class PModifier : Production<PModifier>
    {
        public PModifier()
        {
        }
        
    }
    public partial class AStarModifier : PModifier
    {
        private TStar _star_;
        
        public AStarModifier(TStar _star_)
            : base()
        {
            this.Star = _star_;
        }
        
        public TStar Star
        {
            get { return _star_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Star in AStarModifier cannot be null.", "value");
                
                if (_star_ != null)
                    SetParent(_star_, null);
                SetParent(value, this);
                
                _star_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Star == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Star in AStarModifier cannot be null.", "newChild");
                if (!(newChild is TStar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Star = newChild as TStar;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Star;
        }
        
        public override PModifier Clone()
        {
            return new AStarModifier(Star.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Star);
        }
    }
    public partial class AQuestionModifier : PModifier
    {
        private TQMark _qmark_;
        
        public AQuestionModifier(TQMark _qmark_)
            : base()
        {
            this.QMark = _qmark_;
        }
        
        public TQMark QMark
        {
            get { return _qmark_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("QMark in AQuestionModifier cannot be null.", "value");
                
                if (_qmark_ != null)
                    SetParent(_qmark_, null);
                SetParent(value, this);
                
                _qmark_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (QMark == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("QMark in AQuestionModifier cannot be null.", "newChild");
                if (!(newChild is TQMark) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                QMark = newChild as TQMark;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return QMark;
        }
        
        public override PModifier Clone()
        {
            return new AQuestionModifier(QMark.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", QMark);
        }
    }
    public partial class APlusModifier : PModifier
    {
        private TPlus _plus_;
        
        public APlusModifier(TPlus _plus_)
            : base()
        {
            this.Plus = _plus_;
        }
        
        public TPlus Plus
        {
            get { return _plus_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Plus in APlusModifier cannot be null.", "value");
                
                if (_plus_ != null)
                    SetParent(_plus_, null);
                SetParent(value, this);
                
                _plus_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Plus == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Plus in APlusModifier cannot be null.", "newChild");
                if (!(newChild is TPlus) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Plus = newChild as TPlus;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Plus;
        }
        
        public override PModifier Clone()
        {
            return new APlusModifier(Plus.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Plus);
        }
    }
    public abstract partial class PState : Production<PState>
    {
        private TIdentifier _identifier_;
        
        public PState(TIdentifier _identifier_)
        {
            this.Identifier = _identifier_;
        }
        
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in PState cannot be null.", "value");
                
                if (_identifier_ != null)
                    SetParent(_identifier_, null);
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        
    }
    public partial class AState : PState
    {
        public AState(TIdentifier _identifier_)
            : base(_identifier_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in AState cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Identifier;
        }
        
        public override PState Clone()
        {
            return new AState(Identifier.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Identifier);
        }
    }
    public abstract partial class PTokenState : Production<PTokenState>
    {
        public PTokenState()
        {
        }
        
    }
    public partial class ATokenState : PTokenState
    {
        private TIdentifier _identifier_;
        
        public ATokenState(TIdentifier _identifier_)
            : base()
        {
            this.Identifier = _identifier_;
        }
        
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in ATokenState cannot be null.", "value");
                
                if (_identifier_ != null)
                    SetParent(_identifier_, null);
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in ATokenState cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Identifier;
        }
        
        public override PTokenState Clone()
        {
            return new ATokenState(Identifier.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Identifier);
        }
    }
    public partial class ATransitionTokenState : PTokenState
    {
        private TIdentifier _from_;
        private TArrow _arrow_;
        private TIdentifier _to_;
        
        public ATransitionTokenState(TIdentifier _from_, TArrow _arrow_, TIdentifier _to_)
            : base()
        {
            this.From = _from_;
            this.Arrow = _arrow_;
            this.To = _to_;
        }
        
        public TIdentifier From
        {
            get { return _from_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("From in ATransitionTokenState cannot be null.", "value");
                
                if (_from_ != null)
                    SetParent(_from_, null);
                SetParent(value, this);
                
                _from_ = value;
            }
        }
        public TArrow Arrow
        {
            get { return _arrow_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Arrow in ATransitionTokenState cannot be null.", "value");
                
                if (_arrow_ != null)
                    SetParent(_arrow_, null);
                SetParent(value, this);
                
                _arrow_ = value;
            }
        }
        public TIdentifier To
        {
            get { return _to_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("To in ATransitionTokenState cannot be null.", "value");
                
                if (_to_ != null)
                    SetParent(_to_, null);
                SetParent(value, this);
                
                _to_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (From == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("From in ATransitionTokenState cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                From = newChild as TIdentifier;
            }
            else if (Arrow == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Arrow in ATransitionTokenState cannot be null.", "newChild");
                if (!(newChild is TArrow) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Arrow = newChild as TArrow;
            }
            else if (To == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("To in ATransitionTokenState cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                To = newChild as TIdentifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return From;
            yield return Arrow;
            yield return To;
        }
        
        public override PTokenState Clone()
        {
            return new ATransitionTokenState(From.Clone(), Arrow.Clone(), To.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", From, Arrow, To);
        }
    }
    public abstract partial class PProduction : Production<PProduction>
    {
        private TIdentifier _identifier_;
        private PProdtranslation _prodtranslation_;
        private TEqual _equal_;
        private NodeList<PAlternative> _alternatives_;
        private TSemicolon _semicolon_;
        
        public PProduction(TIdentifier _identifier_, PProdtranslation _prodtranslation_, TEqual _equal_, IEnumerable<PAlternative> _alternatives_, TSemicolon _semicolon_)
        {
            this.Identifier = _identifier_;
            this.Prodtranslation = _prodtranslation_;
            this.Equal = _equal_;
            this._alternatives_ = new NodeList<PAlternative>(this, _alternatives_, false);
            this.Semicolon = _semicolon_;
        }
        
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in PProduction cannot be null.", "value");
                
                if (_identifier_ != null)
                    SetParent(_identifier_, null);
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        public PProdtranslation Prodtranslation
        {
            get { return _prodtranslation_; }
            set
            {
                if (_prodtranslation_ != null)
                    SetParent(_prodtranslation_, null);
                if (value != null)
                    SetParent(value, this);
                
                _prodtranslation_ = value;
            }
        }
        public bool HasProdtranslation
        {
            get { return _prodtranslation_ != null; }
        }
        public TEqual Equal
        {
            get { return _equal_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Equal in PProduction cannot be null.", "value");
                
                if (_equal_ != null)
                    SetParent(_equal_, null);
                SetParent(value, this);
                
                _equal_ = value;
            }
        }
        public NodeList<PAlternative> Alternatives
        {
            get { return _alternatives_; }
        }
        public TSemicolon Semicolon
        {
            get { return _semicolon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Semicolon in PProduction cannot be null.", "value");
                
                if (_semicolon_ != null)
                    SetParent(_semicolon_, null);
                SetParent(value, this);
                
                _semicolon_ = value;
            }
        }
        
    }
    public partial class AProduction : PProduction
    {
        public AProduction(TIdentifier _identifier_, PProdtranslation _prodtranslation_, TEqual _equal_, IEnumerable<PAlternative> _alternatives_, TSemicolon _semicolon_)
            : base(_identifier_, _prodtranslation_, _equal_, _alternatives_, _semicolon_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in AProduction cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else if (Prodtranslation == oldChild)
            {
                if (!(newChild is PProdtranslation) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Prodtranslation = newChild as PProdtranslation;
            }
            else if (Equal == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Equal in AProduction cannot be null.", "newChild");
                if (!(newChild is TEqual) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Equal = newChild as TEqual;
            }
            else if (oldChild is PAlternative && Alternatives.Contains(oldChild as PAlternative))
            {
                if (!(newChild is PAlternative) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Alternatives.IndexOf(oldChild as PAlternative);
                if (newChild == null)
                    Alternatives.RemoveAt(index);
                else
                    Alternatives[index] = newChild as PAlternative;
            }
            else if (Semicolon == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Semicolon in AProduction cannot be null.", "newChild");
                if (!(newChild is TSemicolon) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Semicolon = newChild as TSemicolon;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Identifier;
            if (HasProdtranslation)
                yield return Prodtranslation;
            yield return Equal;
            {
                PAlternative[] temp = new PAlternative[Alternatives.Count];
                Alternatives.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Semicolon;
        }
        
        public override PProduction Clone()
        {
            return new AProduction(Identifier.Clone(), Prodtranslation?.Clone(), Equal.Clone(), Alternatives.Clone(), Semicolon.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Identifier, Prodtranslation, Equal, Alternatives, Semicolon);
        }
    }
    public abstract partial class PProdtranslation : Production<PProdtranslation>
    {
        private TArrow _arrow_;
        private TIdentifier _identifier_;
        private PModifier _modifier_;
        
        public PProdtranslation(TArrow _arrow_, TIdentifier _identifier_, PModifier _modifier_)
        {
            this.Arrow = _arrow_;
            this.Identifier = _identifier_;
            this.Modifier = _modifier_;
        }
        
        public TArrow Arrow
        {
            get { return _arrow_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Arrow in PProdtranslation cannot be null.", "value");
                
                if (_arrow_ != null)
                    SetParent(_arrow_, null);
                SetParent(value, this);
                
                _arrow_ = value;
            }
        }
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in PProdtranslation cannot be null.", "value");
                
                if (_identifier_ != null)
                    SetParent(_identifier_, null);
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        public PModifier Modifier
        {
            get { return _modifier_; }
            set
            {
                if (_modifier_ != null)
                    SetParent(_modifier_, null);
                if (value != null)
                    SetParent(value, this);
                
                _modifier_ = value;
            }
        }
        public bool HasModifier
        {
            get { return _modifier_ != null; }
        }
        
    }
    public partial class AProdtranslation : PProdtranslation
    {
        public AProdtranslation(TArrow _arrow_, TIdentifier _identifier_, PModifier _modifier_)
            : base(_arrow_, _identifier_, _modifier_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Arrow == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Arrow in AProdtranslation cannot be null.", "newChild");
                if (!(newChild is TArrow) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Arrow = newChild as TArrow;
            }
            else if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in AProdtranslation cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else if (Modifier == oldChild)
            {
                if (!(newChild is PModifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Modifier = newChild as PModifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Arrow;
            yield return Identifier;
            if (HasModifier)
                yield return Modifier;
        }
        
        public override PProdtranslation Clone()
        {
            return new AProdtranslation(Arrow.Clone(), Identifier.Clone(), Modifier?.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Arrow, Identifier, Modifier);
        }
    }
    public abstract partial class PTranslation : Production<PTranslation>
    {
        public PTranslation()
        {
        }
        
    }
    public partial class AFullTranslation : PTranslation
    {
        private TArrow _arrow_;
        private PTranslation _translation_;
        
        public AFullTranslation(TArrow _arrow_, PTranslation _translation_)
            : base()
        {
            this.Arrow = _arrow_;
            this.Translation = _translation_;
        }
        
        public TArrow Arrow
        {
            get { return _arrow_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Arrow in AFullTranslation cannot be null.", "value");
                
                if (_arrow_ != null)
                    SetParent(_arrow_, null);
                SetParent(value, this);
                
                _arrow_ = value;
            }
        }
        public PTranslation Translation
        {
            get { return _translation_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Translation in AFullTranslation cannot be null.", "value");
                
                if (_translation_ != null)
                    SetParent(_translation_, null);
                SetParent(value, this);
                
                _translation_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Arrow == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Arrow in AFullTranslation cannot be null.", "newChild");
                if (!(newChild is TArrow) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Arrow = newChild as TArrow;
            }
            else if (Translation == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Translation in AFullTranslation cannot be null.", "newChild");
                if (!(newChild is PTranslation) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Translation = newChild as PTranslation;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Arrow;
            yield return Translation;
        }
        
        public override PTranslation Clone()
        {
            return new AFullTranslation(Arrow.Clone(), Translation.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Arrow, Translation);
        }
    }
    public partial class ANewTranslation : PTranslation
    {
        private TNew _new_;
        private TIdentifier _production_;
        private TLPar _lpar_;
        private NodeList<PTranslation> _arguments_;
        private TRPar _rpar_;
        
        public ANewTranslation(TNew _new_, TIdentifier _production_, TLPar _lpar_, IEnumerable<PTranslation> _arguments_, TRPar _rpar_)
            : base()
        {
            this.New = _new_;
            this.Production = _production_;
            this.Lpar = _lpar_;
            this._arguments_ = new NodeList<PTranslation>(this, _arguments_, true);
            this.Rpar = _rpar_;
        }
        
        public TNew New
        {
            get { return _new_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("New in ANewTranslation cannot be null.", "value");
                
                if (_new_ != null)
                    SetParent(_new_, null);
                SetParent(value, this);
                
                _new_ = value;
            }
        }
        public TIdentifier Production
        {
            get { return _production_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Production in ANewTranslation cannot be null.", "value");
                
                if (_production_ != null)
                    SetParent(_production_, null);
                SetParent(value, this);
                
                _production_ = value;
            }
        }
        public TLPar Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in ANewTranslation cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public NodeList<PTranslation> Arguments
        {
            get { return _arguments_; }
        }
        public TRPar Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in ANewTranslation cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (New == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("New in ANewTranslation cannot be null.", "newChild");
                if (!(newChild is TNew) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                New = newChild as TNew;
            }
            else if (Production == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Production in ANewTranslation cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Production = newChild as TIdentifier;
            }
            else if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in ANewTranslation cannot be null.", "newChild");
                if (!(newChild is TLPar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLPar;
            }
            else if (oldChild is PTranslation && Arguments.Contains(oldChild as PTranslation))
            {
                if (!(newChild is PTranslation) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Arguments.IndexOf(oldChild as PTranslation);
                if (newChild == null)
                    Arguments.RemoveAt(index);
                else
                    Arguments[index] = newChild as PTranslation;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in ANewTranslation cannot be null.", "newChild");
                if (!(newChild is TRPar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRPar;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return New;
            yield return Production;
            yield return Lpar;
            {
                PTranslation[] temp = new PTranslation[Arguments.Count];
                Arguments.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Rpar;
        }
        
        public override PTranslation Clone()
        {
            return new ANewTranslation(New.Clone(), Production.Clone(), Lpar.Clone(), Arguments.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", New, Production, Lpar, Arguments, Rpar);
        }
    }
    public partial class ANewalternativeTranslation : PTranslation
    {
        private TNew _new_;
        private TIdentifier _production_;
        private TDot _dot_;
        private TIdentifier _alternative_;
        private TLPar _lpar_;
        private NodeList<PTranslation> _arguments_;
        private TRPar _rpar_;
        
        public ANewalternativeTranslation(TNew _new_, TIdentifier _production_, TDot _dot_, TIdentifier _alternative_, TLPar _lpar_, IEnumerable<PTranslation> _arguments_, TRPar _rpar_)
            : base()
        {
            this.New = _new_;
            this.Production = _production_;
            this.Dot = _dot_;
            this.Alternative = _alternative_;
            this.Lpar = _lpar_;
            this._arguments_ = new NodeList<PTranslation>(this, _arguments_, true);
            this.Rpar = _rpar_;
        }
        
        public TNew New
        {
            get { return _new_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("New in ANewalternativeTranslation cannot be null.", "value");
                
                if (_new_ != null)
                    SetParent(_new_, null);
                SetParent(value, this);
                
                _new_ = value;
            }
        }
        public TIdentifier Production
        {
            get { return _production_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Production in ANewalternativeTranslation cannot be null.", "value");
                
                if (_production_ != null)
                    SetParent(_production_, null);
                SetParent(value, this);
                
                _production_ = value;
            }
        }
        public TDot Dot
        {
            get { return _dot_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Dot in ANewalternativeTranslation cannot be null.", "value");
                
                if (_dot_ != null)
                    SetParent(_dot_, null);
                SetParent(value, this);
                
                _dot_ = value;
            }
        }
        public TIdentifier Alternative
        {
            get { return _alternative_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Alternative in ANewalternativeTranslation cannot be null.", "value");
                
                if (_alternative_ != null)
                    SetParent(_alternative_, null);
                SetParent(value, this);
                
                _alternative_ = value;
            }
        }
        public TLPar Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in ANewalternativeTranslation cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public NodeList<PTranslation> Arguments
        {
            get { return _arguments_; }
        }
        public TRPar Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in ANewalternativeTranslation cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (New == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("New in ANewalternativeTranslation cannot be null.", "newChild");
                if (!(newChild is TNew) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                New = newChild as TNew;
            }
            else if (Production == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Production in ANewalternativeTranslation cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Production = newChild as TIdentifier;
            }
            else if (Dot == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Dot in ANewalternativeTranslation cannot be null.", "newChild");
                if (!(newChild is TDot) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Dot = newChild as TDot;
            }
            else if (Alternative == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Alternative in ANewalternativeTranslation cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Alternative = newChild as TIdentifier;
            }
            else if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in ANewalternativeTranslation cannot be null.", "newChild");
                if (!(newChild is TLPar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLPar;
            }
            else if (oldChild is PTranslation && Arguments.Contains(oldChild as PTranslation))
            {
                if (!(newChild is PTranslation) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Arguments.IndexOf(oldChild as PTranslation);
                if (newChild == null)
                    Arguments.RemoveAt(index);
                else
                    Arguments[index] = newChild as PTranslation;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in ANewalternativeTranslation cannot be null.", "newChild");
                if (!(newChild is TRPar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRPar;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return New;
            yield return Production;
            yield return Dot;
            yield return Alternative;
            yield return Lpar;
            {
                PTranslation[] temp = new PTranslation[Arguments.Count];
                Arguments.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Rpar;
        }
        
        public override PTranslation Clone()
        {
            return new ANewalternativeTranslation(New.Clone(), Production.Clone(), Dot.Clone(), Alternative.Clone(), Lpar.Clone(), Arguments.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6}", New, Production, Dot, Alternative, Lpar, Arguments, Rpar);
        }
    }
    public partial class AListTranslation : PTranslation
    {
        private TLBkt _lpar_;
        private NodeList<PTranslation> _elements_;
        private TRBkt _rpar_;
        
        public AListTranslation(TLBkt _lpar_, IEnumerable<PTranslation> _elements_, TRBkt _rpar_)
            : base()
        {
            this.Lpar = _lpar_;
            this._elements_ = new NodeList<PTranslation>(this, _elements_, true);
            this.Rpar = _rpar_;
        }
        
        public TLBkt Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in AListTranslation cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public NodeList<PTranslation> Elements
        {
            get { return _elements_; }
        }
        public TRBkt Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in AListTranslation cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in AListTranslation cannot be null.", "newChild");
                if (!(newChild is TLBkt) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBkt;
            }
            else if (oldChild is PTranslation && Elements.Contains(oldChild as PTranslation))
            {
                if (!(newChild is PTranslation) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Elements.IndexOf(oldChild as PTranslation);
                if (newChild == null)
                    Elements.RemoveAt(index);
                else
                    Elements[index] = newChild as PTranslation;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in AListTranslation cannot be null.", "newChild");
                if (!(newChild is TRBkt) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBkt;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            {
                PTranslation[] temp = new PTranslation[Elements.Count];
                Elements.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Rpar;
        }
        
        public override PTranslation Clone()
        {
            return new AListTranslation(Lpar.Clone(), Elements.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Lpar, Elements, Rpar);
        }
    }
    public partial class ANullTranslation : PTranslation
    {
        private TNull _null_;
        
        public ANullTranslation(TNull _null_)
            : base()
        {
            this.Null = _null_;
        }
        
        public TNull Null
        {
            get { return _null_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Null in ANullTranslation cannot be null.", "value");
                
                if (_null_ != null)
                    SetParent(_null_, null);
                SetParent(value, this);
                
                _null_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Null == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Null in ANullTranslation cannot be null.", "newChild");
                if (!(newChild is TNull) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Null = newChild as TNull;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Null;
        }
        
        public override PTranslation Clone()
        {
            return new ANullTranslation(Null.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Null);
        }
    }
    public partial class AIdTranslation : PTranslation
    {
        private TIdentifier _identifier_;
        
        public AIdTranslation(TIdentifier _identifier_)
            : base()
        {
            this.Identifier = _identifier_;
        }
        
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in AIdTranslation cannot be null.", "value");
                
                if (_identifier_ != null)
                    SetParent(_identifier_, null);
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in AIdTranslation cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Identifier;
        }
        
        public override PTranslation Clone()
        {
            return new AIdTranslation(Identifier.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Identifier);
        }
    }
    public partial class AIddotidTranslation : PTranslation
    {
        private TIdentifier _identifier_;
        private TDot _dot_;
        private TIdentifier _production_;
        
        public AIddotidTranslation(TIdentifier _identifier_, TDot _dot_, TIdentifier _production_)
            : base()
        {
            this.Identifier = _identifier_;
            this.Dot = _dot_;
            this.Production = _production_;
        }
        
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in AIddotidTranslation cannot be null.", "value");
                
                if (_identifier_ != null)
                    SetParent(_identifier_, null);
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        public TDot Dot
        {
            get { return _dot_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Dot in AIddotidTranslation cannot be null.", "value");
                
                if (_dot_ != null)
                    SetParent(_dot_, null);
                SetParent(value, this);
                
                _dot_ = value;
            }
        }
        public TIdentifier Production
        {
            get { return _production_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Production in AIddotidTranslation cannot be null.", "value");
                
                if (_production_ != null)
                    SetParent(_production_, null);
                SetParent(value, this);
                
                _production_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in AIddotidTranslation cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else if (Dot == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Dot in AIddotidTranslation cannot be null.", "newChild");
                if (!(newChild is TDot) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Dot = newChild as TDot;
            }
            else if (Production == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Production in AIddotidTranslation cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Production = newChild as TIdentifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Identifier;
            yield return Dot;
            yield return Production;
        }
        
        public override PTranslation Clone()
        {
            return new AIddotidTranslation(Identifier.Clone(), Dot.Clone(), Production.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Identifier, Dot, Production);
        }
    }
    public abstract partial class PAlternative : Production<PAlternative>
    {
        private PAlternativename _alternativename_;
        private NodeList<PElement> _elements_;
        private PTranslation _translation_;
        
        public PAlternative(PAlternativename _alternativename_, IEnumerable<PElement> _elements_, PTranslation _translation_)
        {
            this.Alternativename = _alternativename_;
            this._elements_ = new NodeList<PElement>(this, _elements_, true);
            this.Translation = _translation_;
        }
        
        public PAlternativename Alternativename
        {
            get { return _alternativename_; }
            set
            {
                if (_alternativename_ != null)
                    SetParent(_alternativename_, null);
                if (value != null)
                    SetParent(value, this);
                
                _alternativename_ = value;
            }
        }
        public bool HasAlternativename
        {
            get { return _alternativename_ != null; }
        }
        public NodeList<PElement> Elements
        {
            get { return _elements_; }
        }
        public PTranslation Translation
        {
            get { return _translation_; }
            set
            {
                if (_translation_ != null)
                    SetParent(_translation_, null);
                if (value != null)
                    SetParent(value, this);
                
                _translation_ = value;
            }
        }
        public bool HasTranslation
        {
            get { return _translation_ != null; }
        }
        
    }
    public partial class AAlternative : PAlternative
    {
        public AAlternative(PAlternativename _alternativename_, IEnumerable<PElement> _elements_, PTranslation _translation_)
            : base(_alternativename_, _elements_, _translation_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Alternativename == oldChild)
            {
                if (!(newChild is PAlternativename) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Alternativename = newChild as PAlternativename;
            }
            else if (oldChild is PElement && Elements.Contains(oldChild as PElement))
            {
                if (!(newChild is PElement) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Elements.IndexOf(oldChild as PElement);
                if (newChild == null)
                    Elements.RemoveAt(index);
                else
                    Elements[index] = newChild as PElement;
            }
            else if (Translation == oldChild)
            {
                if (!(newChild is PTranslation) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Translation = newChild as PTranslation;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasAlternativename)
                yield return Alternativename;
            {
                PElement[] temp = new PElement[Elements.Count];
                Elements.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            if (HasTranslation)
                yield return Translation;
        }
        
        public override PAlternative Clone()
        {
            return new AAlternative(Alternativename?.Clone(), Elements.Clone(), Translation?.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Alternativename, Elements, Translation);
        }
    }
    public abstract partial class PAlternativename : Production<PAlternativename>
    {
        private TLBrace _lpar_;
        private TIdentifier _name_;
        private TRBrace _rpar_;
        
        public PAlternativename(TLBrace _lpar_, TIdentifier _name_, TRBrace _rpar_)
        {
            this.Lpar = _lpar_;
            this.Name = _name_;
            this.Rpar = _rpar_;
        }
        
        public TLBrace Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in PAlternativename cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public TIdentifier Name
        {
            get { return _name_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Name in PAlternativename cannot be null.", "value");
                
                if (_name_ != null)
                    SetParent(_name_, null);
                SetParent(value, this);
                
                _name_ = value;
            }
        }
        public TRBrace Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in PAlternativename cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        
    }
    public partial class AAlternativename : PAlternativename
    {
        public AAlternativename(TLBrace _lpar_, TIdentifier _name_, TRBrace _rpar_)
            : base(_lpar_, _name_, _rpar_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in AAlternativename cannot be null.", "newChild");
                if (!(newChild is TLBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBrace;
            }
            else if (Name == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Name in AAlternativename cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Name = newChild as TIdentifier;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in AAlternativename cannot be null.", "newChild");
                if (!(newChild is TRBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBrace;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            yield return Name;
            yield return Rpar;
        }
        
        public override PAlternativename Clone()
        {
            return new AAlternativename(Lpar.Clone(), Name.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Lpar, Name, Rpar);
        }
    }
    public abstract partial class PElement : Production<PElement>
    {
        private PElementname _elementname_;
        private PElementid _elementid_;
        private PModifier _modifier_;
        
        public PElement(PElementname _elementname_, PElementid _elementid_, PModifier _modifier_)
        {
            this.Elementname = _elementname_;
            this.Elementid = _elementid_;
            this.Modifier = _modifier_;
        }
        
        public PElementname Elementname
        {
            get { return _elementname_; }
            set
            {
                if (_elementname_ != null)
                    SetParent(_elementname_, null);
                if (value != null)
                    SetParent(value, this);
                
                _elementname_ = value;
            }
        }
        public bool HasElementname
        {
            get { return _elementname_ != null; }
        }
        public PElementid Elementid
        {
            get { return _elementid_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Elementid in PElement cannot be null.", "value");
                
                if (_elementid_ != null)
                    SetParent(_elementid_, null);
                SetParent(value, this);
                
                _elementid_ = value;
            }
        }
        public PModifier Modifier
        {
            get { return _modifier_; }
            set
            {
                if (_modifier_ != null)
                    SetParent(_modifier_, null);
                if (value != null)
                    SetParent(value, this);
                
                _modifier_ = value;
            }
        }
        public bool HasModifier
        {
            get { return _modifier_ != null; }
        }
        
    }
    public partial class AElement : PElement
    {
        public AElement(PElementname _elementname_, PElementid _elementid_, PModifier _modifier_)
            : base(_elementname_, _elementid_, _modifier_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Elementname == oldChild)
            {
                if (!(newChild is PElementname) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Elementname = newChild as PElementname;
            }
            else if (Elementid == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Elementid in AElement cannot be null.", "newChild");
                if (!(newChild is PElementid) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Elementid = newChild as PElementid;
            }
            else if (Modifier == oldChild)
            {
                if (!(newChild is PModifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Modifier = newChild as PModifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasElementname)
                yield return Elementname;
            yield return Elementid;
            if (HasModifier)
                yield return Modifier;
        }
        
        public override PElement Clone()
        {
            return new AElement(Elementname?.Clone(), Elementid.Clone(), Modifier?.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Elementname, Elementid, Modifier);
        }
    }
    public abstract partial class PElementname : Production<PElementname>
    {
        private TLBkt _lpar_;
        private TIdentifier _name_;
        private TRBkt _rpar_;
        private TColon _colon_;
        
        public PElementname(TLBkt _lpar_, TIdentifier _name_, TRBkt _rpar_, TColon _colon_)
        {
            this.Lpar = _lpar_;
            this.Name = _name_;
            this.Rpar = _rpar_;
            this.Colon = _colon_;
        }
        
        public TLBkt Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in PElementname cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public TIdentifier Name
        {
            get { return _name_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Name in PElementname cannot be null.", "value");
                
                if (_name_ != null)
                    SetParent(_name_, null);
                SetParent(value, this);
                
                _name_ = value;
            }
        }
        public TRBkt Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in PElementname cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        public TColon Colon
        {
            get { return _colon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Colon in PElementname cannot be null.", "value");
                
                if (_colon_ != null)
                    SetParent(_colon_, null);
                SetParent(value, this);
                
                _colon_ = value;
            }
        }
        
    }
    public partial class AElementname : PElementname
    {
        public AElementname(TLBkt _lpar_, TIdentifier _name_, TRBkt _rpar_, TColon _colon_)
            : base(_lpar_, _name_, _rpar_, _colon_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in AElementname cannot be null.", "newChild");
                if (!(newChild is TLBkt) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBkt;
            }
            else if (Name == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Name in AElementname cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Name = newChild as TIdentifier;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in AElementname cannot be null.", "newChild");
                if (!(newChild is TRBkt) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBkt;
            }
            else if (Colon == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Colon in AElementname cannot be null.", "newChild");
                if (!(newChild is TColon) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Colon = newChild as TColon;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            yield return Name;
            yield return Rpar;
            yield return Colon;
        }
        
        public override PElementname Clone()
        {
            return new AElementname(Lpar.Clone(), Name.Clone(), Rpar.Clone(), Colon.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Lpar, Name, Rpar, Colon);
        }
    }
    public abstract partial class PElementid : Production<PElementid>
    {
        private TIdentifier _identifier_;
        
        public PElementid(TIdentifier _identifier_)
        {
            this.Identifier = _identifier_;
        }
        
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in PElementid cannot be null.", "value");
                
                if (_identifier_ != null)
                    SetParent(_identifier_, null);
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        
    }
    public partial class ACleanElementid : PElementid
    {
        public ACleanElementid(TIdentifier _identifier_)
            : base(_identifier_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in ACleanElementid cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Identifier;
        }
        
        public override PElementid Clone()
        {
            return new ACleanElementid(Identifier.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Identifier);
        }
    }
    public partial class ATokenElementid : PElementid
    {
        private TTokenSpecifier _tokenspecifier_;
        private TDot _dot_;
        
        public ATokenElementid(TTokenSpecifier _tokenspecifier_, TDot _dot_, TIdentifier _identifier_)
            : base(_identifier_)
        {
            this.TokenSpecifier = _tokenspecifier_;
            this.Dot = _dot_;
        }
        
        public TTokenSpecifier TokenSpecifier
        {
            get { return _tokenspecifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("TokenSpecifier in ATokenElementid cannot be null.", "value");
                
                if (_tokenspecifier_ != null)
                    SetParent(_tokenspecifier_, null);
                SetParent(value, this);
                
                _tokenspecifier_ = value;
            }
        }
        public TDot Dot
        {
            get { return _dot_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Dot in ATokenElementid cannot be null.", "value");
                
                if (_dot_ != null)
                    SetParent(_dot_, null);
                SetParent(value, this);
                
                _dot_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (TokenSpecifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("TokenSpecifier in ATokenElementid cannot be null.", "newChild");
                if (!(newChild is TTokenSpecifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                TokenSpecifier = newChild as TTokenSpecifier;
            }
            else if (Dot == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Dot in ATokenElementid cannot be null.", "newChild");
                if (!(newChild is TDot) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Dot = newChild as TDot;
            }
            else if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in ATokenElementid cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return TokenSpecifier;
            yield return Dot;
            yield return Identifier;
        }
        
        public override PElementid Clone()
        {
            return new ATokenElementid(TokenSpecifier.Clone(), Dot.Clone(), Identifier.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", TokenSpecifier, Dot, Identifier);
        }
    }
    public partial class AProductionElementid : PElementid
    {
        private TProductionSpecifier _productionspecifier_;
        private TDot _dot_;
        
        public AProductionElementid(TProductionSpecifier _productionspecifier_, TDot _dot_, TIdentifier _identifier_)
            : base(_identifier_)
        {
            this.ProductionSpecifier = _productionspecifier_;
            this.Dot = _dot_;
        }
        
        public TProductionSpecifier ProductionSpecifier
        {
            get { return _productionspecifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("ProductionSpecifier in AProductionElementid cannot be null.", "value");
                
                if (_productionspecifier_ != null)
                    SetParent(_productionspecifier_, null);
                SetParent(value, this);
                
                _productionspecifier_ = value;
            }
        }
        public TDot Dot
        {
            get { return _dot_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Dot in AProductionElementid cannot be null.", "value");
                
                if (_dot_ != null)
                    SetParent(_dot_, null);
                SetParent(value, this);
                
                _dot_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (ProductionSpecifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("ProductionSpecifier in AProductionElementid cannot be null.", "newChild");
                if (!(newChild is TProductionSpecifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                ProductionSpecifier = newChild as TProductionSpecifier;
            }
            else if (Dot == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Dot in AProductionElementid cannot be null.", "newChild");
                if (!(newChild is TDot) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Dot = newChild as TDot;
            }
            else if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in AProductionElementid cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return ProductionSpecifier;
            yield return Dot;
            yield return Identifier;
        }
        
        public override PElementid Clone()
        {
            return new AProductionElementid(ProductionSpecifier.Clone(), Dot.Clone(), Identifier.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", ProductionSpecifier, Dot, Identifier);
        }
    }
    public abstract partial class PHighlightrule : Production<PHighlightrule>
    {
        private TLBrace _lpar_;
        private NodeList<TIdentifier> _tokens_;
        private TRBrace _rpar_;
        private NodeList<PHighlightStyle> _styles_;
        private TSemicolon _semicolon_;
        
        public PHighlightrule(TLBrace _lpar_, IEnumerable<TIdentifier> _tokens_, TRBrace _rpar_, IEnumerable<PHighlightStyle> _styles_, TSemicolon _semicolon_)
        {
            this.Lpar = _lpar_;
            this._tokens_ = new NodeList<TIdentifier>(this, _tokens_, false);
            this.Rpar = _rpar_;
            this._styles_ = new NodeList<PHighlightStyle>(this, _styles_, false);
            this.Semicolon = _semicolon_;
        }
        
        public TLBrace Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in PHighlightrule cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public NodeList<TIdentifier> Tokens
        {
            get { return _tokens_; }
        }
        public TRBrace Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in PHighlightrule cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        public NodeList<PHighlightStyle> Styles
        {
            get { return _styles_; }
        }
        public TSemicolon Semicolon
        {
            get { return _semicolon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Semicolon in PHighlightrule cannot be null.", "value");
                
                if (_semicolon_ != null)
                    SetParent(_semicolon_, null);
                SetParent(value, this);
                
                _semicolon_ = value;
            }
        }
        
    }
    public partial class AHighlightrule : PHighlightrule
    {
        public AHighlightrule(TLBrace _lpar_, IEnumerable<TIdentifier> _tokens_, TRBrace _rpar_, IEnumerable<PHighlightStyle> _styles_, TSemicolon _semicolon_)
            : base(_lpar_, _tokens_, _rpar_, _styles_, _semicolon_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in AHighlightrule cannot be null.", "newChild");
                if (!(newChild is TLBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBrace;
            }
            else if (oldChild is TIdentifier && Tokens.Contains(oldChild as TIdentifier))
            {
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Tokens.IndexOf(oldChild as TIdentifier);
                if (newChild == null)
                    Tokens.RemoveAt(index);
                else
                    Tokens[index] = newChild as TIdentifier;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in AHighlightrule cannot be null.", "newChild");
                if (!(newChild is TRBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBrace;
            }
            else if (oldChild is PHighlightStyle && Styles.Contains(oldChild as PHighlightStyle))
            {
                if (!(newChild is PHighlightStyle) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Styles.IndexOf(oldChild as PHighlightStyle);
                if (newChild == null)
                    Styles.RemoveAt(index);
                else
                    Styles[index] = newChild as PHighlightStyle;
            }
            else if (Semicolon == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Semicolon in AHighlightrule cannot be null.", "newChild");
                if (!(newChild is TSemicolon) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Semicolon = newChild as TSemicolon;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            {
                TIdentifier[] temp = new TIdentifier[Tokens.Count];
                Tokens.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Rpar;
            {
                PHighlightStyle[] temp = new PHighlightStyle[Styles.Count];
                Styles.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Semicolon;
        }
        
        public override PHighlightrule Clone()
        {
            return new AHighlightrule(Lpar.Clone(), Tokens.Clone(), Rpar.Clone(), Styles.Clone(), Semicolon.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Lpar, Tokens, Rpar, Styles, Semicolon);
        }
    }
    public abstract partial class PHighlightStyle : Production<PHighlightStyle>
    {
        public PHighlightStyle()
        {
        }
        
    }
    public partial class AItalicHighlightStyle : PHighlightStyle
    {
        private TItalic _italic_;
        
        public AItalicHighlightStyle(TItalic _italic_)
            : base()
        {
            this.Italic = _italic_;
        }
        
        public TItalic Italic
        {
            get { return _italic_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Italic in AItalicHighlightStyle cannot be null.", "value");
                
                if (_italic_ != null)
                    SetParent(_italic_, null);
                SetParent(value, this);
                
                _italic_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Italic == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Italic in AItalicHighlightStyle cannot be null.", "newChild");
                if (!(newChild is TItalic) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Italic = newChild as TItalic;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Italic;
        }
        
        public override PHighlightStyle Clone()
        {
            return new AItalicHighlightStyle(Italic.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Italic);
        }
    }
    public partial class ABoldHighlightStyle : PHighlightStyle
    {
        private TBold _bold_;
        
        public ABoldHighlightStyle(TBold _bold_)
            : base()
        {
            this.Bold = _bold_;
        }
        
        public TBold Bold
        {
            get { return _bold_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Bold in ABoldHighlightStyle cannot be null.", "value");
                
                if (_bold_ != null)
                    SetParent(_bold_, null);
                SetParent(value, this);
                
                _bold_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Bold == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Bold in ABoldHighlightStyle cannot be null.", "newChild");
                if (!(newChild is TBold) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Bold = newChild as TBold;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Bold;
        }
        
        public override PHighlightStyle Clone()
        {
            return new ABoldHighlightStyle(Bold.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Bold);
        }
    }
    public partial class ATextHighlightStyle : PHighlightStyle
    {
        private TText _text_;
        private TColon _colon_;
        private PColor _color_;
        
        public ATextHighlightStyle(TText _text_, TColon _colon_, PColor _color_)
            : base()
        {
            this.Text = _text_;
            this.Colon = _colon_;
            this.Color = _color_;
        }
        
        public TText Text
        {
            get { return _text_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Text in ATextHighlightStyle cannot be null.", "value");
                
                if (_text_ != null)
                    SetParent(_text_, null);
                SetParent(value, this);
                
                _text_ = value;
            }
        }
        public TColon Colon
        {
            get { return _colon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Colon in ATextHighlightStyle cannot be null.", "value");
                
                if (_colon_ != null)
                    SetParent(_colon_, null);
                SetParent(value, this);
                
                _colon_ = value;
            }
        }
        public PColor Color
        {
            get { return _color_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Color in ATextHighlightStyle cannot be null.", "value");
                
                if (_color_ != null)
                    SetParent(_color_, null);
                SetParent(value, this);
                
                _color_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Text == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Text in ATextHighlightStyle cannot be null.", "newChild");
                if (!(newChild is TText) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Text = newChild as TText;
            }
            else if (Colon == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Colon in ATextHighlightStyle cannot be null.", "newChild");
                if (!(newChild is TColon) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Colon = newChild as TColon;
            }
            else if (Color == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Color in ATextHighlightStyle cannot be null.", "newChild");
                if (!(newChild is PColor) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Color = newChild as PColor;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Text;
            yield return Colon;
            yield return Color;
        }
        
        public override PHighlightStyle Clone()
        {
            return new ATextHighlightStyle(Text.Clone(), Colon.Clone(), Color.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Text, Colon, Color);
        }
    }
    public partial class ABackgroundHighlightStyle : PHighlightStyle
    {
        private TBackground _background_;
        private TColon _colon_;
        private PColor _color_;
        
        public ABackgroundHighlightStyle(TBackground _background_, TColon _colon_, PColor _color_)
            : base()
        {
            this.Background = _background_;
            this.Colon = _colon_;
            this.Color = _color_;
        }
        
        public TBackground Background
        {
            get { return _background_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Background in ABackgroundHighlightStyle cannot be null.", "value");
                
                if (_background_ != null)
                    SetParent(_background_, null);
                SetParent(value, this);
                
                _background_ = value;
            }
        }
        public TColon Colon
        {
            get { return _colon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Colon in ABackgroundHighlightStyle cannot be null.", "value");
                
                if (_colon_ != null)
                    SetParent(_colon_, null);
                SetParent(value, this);
                
                _colon_ = value;
            }
        }
        public PColor Color
        {
            get { return _color_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Color in ABackgroundHighlightStyle cannot be null.", "value");
                
                if (_color_ != null)
                    SetParent(_color_, null);
                SetParent(value, this);
                
                _color_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Background == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Background in ABackgroundHighlightStyle cannot be null.", "newChild");
                if (!(newChild is TBackground) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Background = newChild as TBackground;
            }
            else if (Colon == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Colon in ABackgroundHighlightStyle cannot be null.", "newChild");
                if (!(newChild is TColon) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Colon = newChild as TColon;
            }
            else if (Color == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Color in ABackgroundHighlightStyle cannot be null.", "newChild");
                if (!(newChild is PColor) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Color = newChild as PColor;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Background;
            yield return Colon;
            yield return Color;
        }
        
        public override PHighlightStyle Clone()
        {
            return new ABackgroundHighlightStyle(Background.Clone(), Colon.Clone(), Color.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Background, Colon, Color);
        }
    }
    public abstract partial class PColor : Production<PColor>
    {
        public PColor()
        {
        }
        
    }
    public partial class ARgbColor : PColor
    {
        private TRgb _rgb_;
        private TLPar _lpar_;
        private TDecChar _red_;
        private TComma _comma1_;
        private TDecChar _green_;
        private TComma _comma2_;
        private TDecChar _blue_;
        private TRPar _rpar_;
        
        public ARgbColor(TRgb _rgb_, TLPar _lpar_, TDecChar _red_, TComma _comma1_, TDecChar _green_, TComma _comma2_, TDecChar _blue_, TRPar _rpar_)
            : base()
        {
            this.Rgb = _rgb_;
            this.LPar = _lpar_;
            this.Red = _red_;
            this.Comma1 = _comma1_;
            this.Green = _green_;
            this.Comma2 = _comma2_;
            this.Blue = _blue_;
            this.RPar = _rpar_;
        }
        
        public TRgb Rgb
        {
            get { return _rgb_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rgb in ARgbColor cannot be null.", "value");
                
                if (_rgb_ != null)
                    SetParent(_rgb_, null);
                SetParent(value, this);
                
                _rgb_ = value;
            }
        }
        public TLPar LPar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("LPar in ARgbColor cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public TDecChar Red
        {
            get { return _red_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Red in ARgbColor cannot be null.", "value");
                
                if (_red_ != null)
                    SetParent(_red_, null);
                SetParent(value, this);
                
                _red_ = value;
            }
        }
        public TComma Comma1
        {
            get { return _comma1_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Comma1 in ARgbColor cannot be null.", "value");
                
                if (_comma1_ != null)
                    SetParent(_comma1_, null);
                SetParent(value, this);
                
                _comma1_ = value;
            }
        }
        public TDecChar Green
        {
            get { return _green_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Green in ARgbColor cannot be null.", "value");
                
                if (_green_ != null)
                    SetParent(_green_, null);
                SetParent(value, this);
                
                _green_ = value;
            }
        }
        public TComma Comma2
        {
            get { return _comma2_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Comma2 in ARgbColor cannot be null.", "value");
                
                if (_comma2_ != null)
                    SetParent(_comma2_, null);
                SetParent(value, this);
                
                _comma2_ = value;
            }
        }
        public TDecChar Blue
        {
            get { return _blue_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Blue in ARgbColor cannot be null.", "value");
                
                if (_blue_ != null)
                    SetParent(_blue_, null);
                SetParent(value, this);
                
                _blue_ = value;
            }
        }
        public TRPar RPar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("RPar in ARgbColor cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Rgb == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rgb in ARgbColor cannot be null.", "newChild");
                if (!(newChild is TRgb) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rgb = newChild as TRgb;
            }
            else if (LPar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("LPar in ARgbColor cannot be null.", "newChild");
                if (!(newChild is TLPar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                LPar = newChild as TLPar;
            }
            else if (Red == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Red in ARgbColor cannot be null.", "newChild");
                if (!(newChild is TDecChar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Red = newChild as TDecChar;
            }
            else if (Comma1 == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Comma1 in ARgbColor cannot be null.", "newChild");
                if (!(newChild is TComma) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Comma1 = newChild as TComma;
            }
            else if (Green == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Green in ARgbColor cannot be null.", "newChild");
                if (!(newChild is TDecChar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Green = newChild as TDecChar;
            }
            else if (Comma2 == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Comma2 in ARgbColor cannot be null.", "newChild");
                if (!(newChild is TComma) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Comma2 = newChild as TComma;
            }
            else if (Blue == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Blue in ARgbColor cannot be null.", "newChild");
                if (!(newChild is TDecChar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Blue = newChild as TDecChar;
            }
            else if (RPar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("RPar in ARgbColor cannot be null.", "newChild");
                if (!(newChild is TRPar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                RPar = newChild as TRPar;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Rgb;
            yield return LPar;
            yield return Red;
            yield return Comma1;
            yield return Green;
            yield return Comma2;
            yield return Blue;
            yield return RPar;
        }
        
        public override PColor Clone()
        {
            return new ARgbColor(Rgb.Clone(), LPar.Clone(), Red.Clone(), Comma1.Clone(), Green.Clone(), Comma2.Clone(), Blue.Clone(), RPar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7}", Rgb, LPar, Red, Comma1, Green, Comma2, Blue, RPar);
        }
    }
    public partial class AHsvColor : PColor
    {
        private THsv _hsv_;
        private TLPar _lpar_;
        private TDecChar _hue_;
        private TComma _comma1_;
        private TDecChar _saturation_;
        private TComma _comma2_;
        private TDecChar _brightness_;
        private TRPar _rpar_;
        
        public AHsvColor(THsv _hsv_, TLPar _lpar_, TDecChar _hue_, TComma _comma1_, TDecChar _saturation_, TComma _comma2_, TDecChar _brightness_, TRPar _rpar_)
            : base()
        {
            this.Hsv = _hsv_;
            this.LPar = _lpar_;
            this.Hue = _hue_;
            this.Comma1 = _comma1_;
            this.Saturation = _saturation_;
            this.Comma2 = _comma2_;
            this.Brightness = _brightness_;
            this.RPar = _rpar_;
        }
        
        public THsv Hsv
        {
            get { return _hsv_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Hsv in AHsvColor cannot be null.", "value");
                
                if (_hsv_ != null)
                    SetParent(_hsv_, null);
                SetParent(value, this);
                
                _hsv_ = value;
            }
        }
        public TLPar LPar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("LPar in AHsvColor cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public TDecChar Hue
        {
            get { return _hue_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Hue in AHsvColor cannot be null.", "value");
                
                if (_hue_ != null)
                    SetParent(_hue_, null);
                SetParent(value, this);
                
                _hue_ = value;
            }
        }
        public TComma Comma1
        {
            get { return _comma1_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Comma1 in AHsvColor cannot be null.", "value");
                
                if (_comma1_ != null)
                    SetParent(_comma1_, null);
                SetParent(value, this);
                
                _comma1_ = value;
            }
        }
        public TDecChar Saturation
        {
            get { return _saturation_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Saturation in AHsvColor cannot be null.", "value");
                
                if (_saturation_ != null)
                    SetParent(_saturation_, null);
                SetParent(value, this);
                
                _saturation_ = value;
            }
        }
        public TComma Comma2
        {
            get { return _comma2_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Comma2 in AHsvColor cannot be null.", "value");
                
                if (_comma2_ != null)
                    SetParent(_comma2_, null);
                SetParent(value, this);
                
                _comma2_ = value;
            }
        }
        public TDecChar Brightness
        {
            get { return _brightness_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Brightness in AHsvColor cannot be null.", "value");
                
                if (_brightness_ != null)
                    SetParent(_brightness_, null);
                SetParent(value, this);
                
                _brightness_ = value;
            }
        }
        public TRPar RPar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("RPar in AHsvColor cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Hsv == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Hsv in AHsvColor cannot be null.", "newChild");
                if (!(newChild is THsv) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Hsv = newChild as THsv;
            }
            else if (LPar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("LPar in AHsvColor cannot be null.", "newChild");
                if (!(newChild is TLPar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                LPar = newChild as TLPar;
            }
            else if (Hue == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Hue in AHsvColor cannot be null.", "newChild");
                if (!(newChild is TDecChar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Hue = newChild as TDecChar;
            }
            else if (Comma1 == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Comma1 in AHsvColor cannot be null.", "newChild");
                if (!(newChild is TComma) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Comma1 = newChild as TComma;
            }
            else if (Saturation == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Saturation in AHsvColor cannot be null.", "newChild");
                if (!(newChild is TDecChar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Saturation = newChild as TDecChar;
            }
            else if (Comma2 == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Comma2 in AHsvColor cannot be null.", "newChild");
                if (!(newChild is TComma) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Comma2 = newChild as TComma;
            }
            else if (Brightness == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Brightness in AHsvColor cannot be null.", "newChild");
                if (!(newChild is TDecChar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Brightness = newChild as TDecChar;
            }
            else if (RPar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("RPar in AHsvColor cannot be null.", "newChild");
                if (!(newChild is TRPar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                RPar = newChild as TRPar;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Hsv;
            yield return LPar;
            yield return Hue;
            yield return Comma1;
            yield return Saturation;
            yield return Comma2;
            yield return Brightness;
            yield return RPar;
        }
        
        public override PColor Clone()
        {
            return new AHsvColor(Hsv.Clone(), LPar.Clone(), Hue.Clone(), Comma1.Clone(), Saturation.Clone(), Comma2.Clone(), Brightness.Clone(), RPar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7}", Hsv, LPar, Hue, Comma1, Saturation, Comma2, Brightness, RPar);
        }
    }
    public partial class AHexColor : PColor
    {
        private THexColor _color_;
        
        public AHexColor(THexColor _color_)
            : base()
        {
            this.Color = _color_;
        }
        
        public THexColor Color
        {
            get { return _color_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Color in AHexColor cannot be null.", "value");
                
                if (_color_ != null)
                    SetParent(_color_, null);
                SetParent(value, this);
                
                _color_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Color == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Color in AHexColor cannot be null.", "newChild");
                if (!(newChild is THexColor) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Color = newChild as THexColor;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Color;
        }
        
        public override PColor Clone()
        {
            return new AHexColor(Color.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Color);
        }
    }
}
