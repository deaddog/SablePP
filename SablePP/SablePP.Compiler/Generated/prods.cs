using System;
using System.Collections.Generic;
using SablePP.Tools.Nodes;
using SablePP.Compiler.Analysis;

namespace SablePP.Compiler.Nodes
{
    public abstract partial class PGrammar : Production<PGrammar>
    {
        private PPackage _package_;
        private PHelpers _helpers_;
        private PStates _states_;
        private PTokens _tokens_;
        private PIgnoredtokens _ignoredtokens_;
        private PProductions _productions_;
        private PAstproductions _astproductions_;
        private PHighlightrules _highlightrules_;
        
        public PGrammar(PPackage _package_, PHelpers _helpers_, PStates _states_, PTokens _tokens_, PIgnoredtokens _ignoredtokens_, PProductions _productions_, PAstproductions _astproductions_, PHighlightrules _highlightrules_)
        {
            this.Package = _package_;
            this.Helpers = _helpers_;
            this.States = _states_;
            this.Tokens = _tokens_;
            this.Ignoredtokens = _ignoredtokens_;
            this.Productions = _productions_;
            this.Astproductions = _astproductions_;
            this.Highlightrules = _highlightrules_;
        }
        
        public PPackage Package
        {
            get { return _package_; }
            set
            {
                if (_package_ != null)
                    SetParent(_package_, null);
                if (value != null)
                    SetParent(value, this);
                
                _package_ = value;
            }
        }
        public bool HasPackage
        {
            get { return _package_ != null; }
        }
        public PHelpers Helpers
        {
            get { return _helpers_; }
            set
            {
                if (_helpers_ != null)
                    SetParent(_helpers_, null);
                if (value != null)
                    SetParent(value, this);
                
                _helpers_ = value;
            }
        }
        public bool HasHelpers
        {
            get { return _helpers_ != null; }
        }
        public PStates States
        {
            get { return _states_; }
            set
            {
                if (_states_ != null)
                    SetParent(_states_, null);
                if (value != null)
                    SetParent(value, this);
                
                _states_ = value;
            }
        }
        public bool HasStates
        {
            get { return _states_ != null; }
        }
        public PTokens Tokens
        {
            get { return _tokens_; }
            set
            {
                if (_tokens_ != null)
                    SetParent(_tokens_, null);
                if (value != null)
                    SetParent(value, this);
                
                _tokens_ = value;
            }
        }
        public bool HasTokens
        {
            get { return _tokens_ != null; }
        }
        public PIgnoredtokens Ignoredtokens
        {
            get { return _ignoredtokens_; }
            set
            {
                if (_ignoredtokens_ != null)
                    SetParent(_ignoredtokens_, null);
                if (value != null)
                    SetParent(value, this);
                
                _ignoredtokens_ = value;
            }
        }
        public bool HasIgnoredtokens
        {
            get { return _ignoredtokens_ != null; }
        }
        public PProductions Productions
        {
            get { return _productions_; }
            set
            {
                if (_productions_ != null)
                    SetParent(_productions_, null);
                if (value != null)
                    SetParent(value, this);
                
                _productions_ = value;
            }
        }
        public bool HasProductions
        {
            get { return _productions_ != null; }
        }
        public PAstproductions Astproductions
        {
            get { return _astproductions_; }
            set
            {
                if (_astproductions_ != null)
                    SetParent(_astproductions_, null);
                if (value != null)
                    SetParent(value, this);
                
                _astproductions_ = value;
            }
        }
        public bool HasAstproductions
        {
            get { return _astproductions_ != null; }
        }
        public PHighlightrules Highlightrules
        {
            get { return _highlightrules_; }
            set
            {
                if (_highlightrules_ != null)
                    SetParent(_highlightrules_, null);
                if (value != null)
                    SetParent(value, this);
                
                _highlightrules_ = value;
            }
        }
        public bool HasHighlightrules
        {
            get { return _highlightrules_ != null; }
        }
        
    }
    public partial class AGrammar : PGrammar
    {
        public AGrammar(PPackage _package_, PHelpers _helpers_, PStates _states_, PTokens _tokens_, PIgnoredtokens _ignoredtokens_, PProductions _productions_, PAstproductions _astproductions_, PHighlightrules _highlightrules_)
            : base(_package_, _helpers_, _states_, _tokens_, _ignoredtokens_, _productions_, _astproductions_, _highlightrules_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Package == oldChild)
            {
                if (!(newChild is PPackage) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Package = newChild as PPackage;
            }
            else if (Helpers == oldChild)
            {
                if (!(newChild is PHelpers) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Helpers = newChild as PHelpers;
            }
            else if (States == oldChild)
            {
                if (!(newChild is PStates) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                States = newChild as PStates;
            }
            else if (Tokens == oldChild)
            {
                if (!(newChild is PTokens) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Tokens = newChild as PTokens;
            }
            else if (Ignoredtokens == oldChild)
            {
                if (!(newChild is PIgnoredtokens) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Ignoredtokens = newChild as PIgnoredtokens;
            }
            else if (Productions == oldChild)
            {
                if (!(newChild is PProductions) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Productions = newChild as PProductions;
            }
            else if (Astproductions == oldChild)
            {
                if (!(newChild is PAstproductions) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Astproductions = newChild as PAstproductions;
            }
            else if (Highlightrules == oldChild)
            {
                if (!(newChild is PHighlightrules) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Highlightrules = newChild as PHighlightrules;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasPackage)
                yield return Package;
            if (HasHelpers)
                yield return Helpers;
            if (HasStates)
                yield return States;
            if (HasTokens)
                yield return Tokens;
            if (HasIgnoredtokens)
                yield return Ignoredtokens;
            if (HasProductions)
                yield return Productions;
            if (HasAstproductions)
                yield return Astproductions;
            if (HasHighlightrules)
                yield return Highlightrules;
        }
        
        public override PGrammar Clone()
        {
            return new AGrammar(Package.Clone(), Helpers.Clone(), States.Clone(), Tokens.Clone(), Ignoredtokens.Clone(), Productions.Clone(), Astproductions.Clone(), Highlightrules.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7}", Package, Helpers, States, Tokens, Ignoredtokens, Productions, Astproductions, Highlightrules);
        }
    }
    public abstract partial class PPackage : Production<PPackage>
    {
        private TPackagetoken _packagetoken_;
        private TPackagename _packagename_;
        private TSemicolon _semicolon_;
        
        public PPackage(TPackagetoken _packagetoken_, TPackagename _packagename_, TSemicolon _semicolon_)
        {
            this.Packagetoken = _packagetoken_;
            this.Packagename = _packagename_;
            this.Semicolon = _semicolon_;
        }
        
        public TPackagetoken Packagetoken
        {
            get { return _packagetoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Packagetoken in PPackage cannot be null.", "value");
                
                if (_packagetoken_ != null)
                    SetParent(_packagetoken_, null);
                SetParent(value, this);
                
                _packagetoken_ = value;
            }
        }
        public TPackagename Packagename
        {
            get { return _packagename_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Packagename in PPackage cannot be null.", "value");
                
                if (_packagename_ != null)
                    SetParent(_packagename_, null);
                SetParent(value, this);
                
                _packagename_ = value;
            }
        }
        public TSemicolon Semicolon
        {
            get { return _semicolon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Semicolon in PPackage cannot be null.", "value");
                
                if (_semicolon_ != null)
                    SetParent(_semicolon_, null);
                SetParent(value, this);
                
                _semicolon_ = value;
            }
        }
        
    }
    public partial class APackage : PPackage
    {
        public APackage(TPackagetoken _packagetoken_, TPackagename _packagename_, TSemicolon _semicolon_)
            : base(_packagetoken_, _packagename_, _semicolon_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Packagetoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Packagetoken in APackage cannot be null.", "newChild");
                if (!(newChild is TPackagetoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Packagetoken = newChild as TPackagetoken;
            }
            else if (Packagename == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Packagename in APackage cannot be null.", "newChild");
                if (!(newChild is TPackagename) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Packagename = newChild as TPackagename;
            }
            else if (Semicolon == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Semicolon in APackage cannot be null.", "newChild");
                if (!(newChild is TSemicolon) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Semicolon = newChild as TSemicolon;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Packagetoken;
            yield return Packagename;
            yield return Semicolon;
        }
        
        public override PPackage Clone()
        {
            return new APackage(Packagetoken.Clone(), Packagename.Clone(), Semicolon.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Packagetoken, Packagename, Semicolon);
        }
    }
    public abstract partial class PHelpers : Production<PHelpers>
    {
        private THelperstoken _helperstoken_;
        private NodeList<PHelper> _helpers_;
        
        public PHelpers(THelperstoken _helperstoken_, IEnumerable<PHelper> _helpers_)
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
                    throw new ArgumentException("Helperstoken in PHelpers cannot be null.", "value");
                
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
        
    }
    public partial class AHelpers : PHelpers
    {
        public AHelpers(THelperstoken _helperstoken_, IEnumerable<PHelper> _helpers_)
            : base(_helperstoken_, _helpers_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Helperstoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Helperstoken in AHelpers cannot be null.", "newChild");
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
        
        public override PHelpers Clone()
        {
            return new AHelpers(Helperstoken.Clone(), Helpers);
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Helperstoken, Helpers);
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
    public abstract partial class PTokens : Production<PTokens>
    {
        private TTokenstoken _tokenstoken_;
        private NodeList<PToken> _tokens_;
        
        public PTokens(TTokenstoken _tokenstoken_, IEnumerable<PToken> _tokens_)
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
                    throw new ArgumentException("Tokenstoken in PTokens cannot be null.", "value");
                
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
        
    }
    public partial class ATokens : PTokens
    {
        public ATokens(TTokenstoken _tokenstoken_, IEnumerable<PToken> _tokens_)
            : base(_tokenstoken_, _tokens_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Tokenstoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Tokenstoken in ATokens cannot be null.", "newChild");
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
        
        public override PTokens Clone()
        {
            return new ATokens(Tokenstoken.Clone(), Tokens);
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Tokenstoken, Tokens);
        }
    }
    public abstract partial class PToken : Production<PToken>
    {
        private PTokenstateList _statelist_;
        private TIdentifier _identifier_;
        private TEqual _equal_;
        private PRegex _regex_;
        private PTokenlookahead _tokenlookahead_;
        private TSemicolon _semicolon_;
        
        public PToken(PTokenstateList _statelist_, TIdentifier _identifier_, TEqual _equal_, PRegex _regex_, PTokenlookahead _tokenlookahead_, TSemicolon _semicolon_)
        {
            this.Statelist = _statelist_;
            this.Identifier = _identifier_;
            this.Equal = _equal_;
            this.Regex = _regex_;
            this.Tokenlookahead = _tokenlookahead_;
            this.Semicolon = _semicolon_;
        }
        
        public PTokenstateList Statelist
        {
            get { return _statelist_; }
            set
            {
                if (_statelist_ != null)
                    SetParent(_statelist_, null);
                if (value != null)
                    SetParent(value, this);
                
                _statelist_ = value;
            }
        }
        public bool HasStatelist
        {
            get { return _statelist_ != null; }
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
        public AToken(PTokenstateList _statelist_, TIdentifier _identifier_, TEqual _equal_, PRegex _regex_, PTokenlookahead _tokenlookahead_, TSemicolon _semicolon_)
            : base(_statelist_, _identifier_, _equal_, _regex_, _tokenlookahead_, _semicolon_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Statelist == oldChild)
            {
                if (!(newChild is PTokenstateList) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Statelist = newChild as PTokenstateList;
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
            if (HasStatelist)
                yield return Statelist;
            yield return Identifier;
            yield return Equal;
            yield return Regex;
            if (HasTokenlookahead)
                yield return Tokenlookahead;
            yield return Semicolon;
        }
        
        public override PToken Clone()
        {
            return new AToken(Statelist.Clone(), Identifier.Clone(), Equal.Clone(), Regex.Clone(), Tokenlookahead.Clone(), Semicolon.Clone());
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
        private NodeList<POrpart> _parts_;
        
        public PRegex(IEnumerable<POrpart> _parts_)
        {
            this._parts_ = new NodeList<POrpart>(this, _parts_, false);
        }
        
        public NodeList<POrpart> Parts
        {
            get { return _parts_; }
        }
        
    }
    public partial class ARegex : PRegex
    {
        public ARegex(IEnumerable<POrpart> _parts_)
            : base(_parts_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (oldChild is POrpart && Parts.Contains(oldChild as POrpart))
            {
                if (!(newChild is POrpart) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Parts.IndexOf(oldChild as POrpart);
                if (newChild == null)
                    Parts.RemoveAt(index);
                else
                    Parts[index] = newChild as POrpart;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            {
                POrpart[] temp = new POrpart[Parts.Count];
                Parts.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PRegex Clone()
        {
            return new ARegex(Parts);
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Parts);
        }
    }
    public abstract partial class POrpart : Production<POrpart>
    {
        private TPipe _pipe_;
        private NodeList<PRegexpart> _regexpart_;
        
        public POrpart(TPipe _pipe_, IEnumerable<PRegexpart> _regexpart_)
        {
            this.Pipe = _pipe_;
            this._regexpart_ = new NodeList<PRegexpart>(this, _regexpart_, false);
        }
        
        public TPipe Pipe
        {
            get { return _pipe_; }
            set
            {
                if (_pipe_ != null)
                    SetParent(_pipe_, null);
                if (value != null)
                    SetParent(value, this);
                
                _pipe_ = value;
            }
        }
        public bool HasPipe
        {
            get { return _pipe_ != null; }
        }
        public NodeList<PRegexpart> Regexpart
        {
            get { return _regexpart_; }
        }
        
    }
    public partial class ARegexOrpart : POrpart
    {
        public ARegexOrpart(TPipe _pipe_, IEnumerable<PRegexpart> _regexpart_)
            : base(_pipe_, _regexpart_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Pipe == oldChild)
            {
                if (!(newChild is TPipe) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Pipe = newChild as TPipe;
            }
            else if (oldChild is PRegexpart && Regexpart.Contains(oldChild as PRegexpart))
            {
                if (!(newChild is PRegexpart) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Regexpart.IndexOf(oldChild as PRegexpart);
                if (newChild == null)
                    Regexpart.RemoveAt(index);
                else
                    Regexpart[index] = newChild as PRegexpart;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasPipe)
                yield return Pipe;
            {
                PRegexpart[] temp = new PRegexpart[Regexpart.Count];
                Regexpart.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override POrpart Clone()
        {
            return new ARegexOrpart(Pipe.Clone(), Regexpart);
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Pipe, Regexpart);
        }
    }
    public abstract partial class PRegexpart : Production<PRegexpart>
    {
        public PRegexpart()
        {
        }
        
    }
    public partial class ACharRegexpart : PRegexpart
    {
        private TCharacter _character_;
        
        public ACharRegexpart(TCharacter _character_)
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
                    throw new ArgumentException("Character in ACharRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Character in ACharRegexpart cannot be null.", "newChild");
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
        
        public override PRegexpart Clone()
        {
            return new ACharRegexpart(Character.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Character);
        }
    }
    public partial class ADecRegexpart : PRegexpart
    {
        private TDecChar _dec_char_;
        
        public ADecRegexpart(TDecChar _dec_char_)
            : base()
        {
            this.DecChar = _dec_char_;
        }
        
        public TDecChar DecChar
        {
            get { return _dec_char_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("DecChar in ADecRegexpart cannot be null.", "value");
                
                if (_dec_char_ != null)
                    SetParent(_dec_char_, null);
                SetParent(value, this);
                
                _dec_char_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (DecChar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("DecChar in ADecRegexpart cannot be null.", "newChild");
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
        
        public override PRegexpart Clone()
        {
            return new ADecRegexpart(DecChar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", DecChar);
        }
    }
    public partial class AHexRegexpart : PRegexpart
    {
        private THexChar _hex_char_;
        
        public AHexRegexpart(THexChar _hex_char_)
            : base()
        {
            this.HexChar = _hex_char_;
        }
        
        public THexChar HexChar
        {
            get { return _hex_char_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("HexChar in AHexRegexpart cannot be null.", "value");
                
                if (_hex_char_ != null)
                    SetParent(_hex_char_, null);
                SetParent(value, this);
                
                _hex_char_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (HexChar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("HexChar in AHexRegexpart cannot be null.", "newChild");
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
        
        public override PRegexpart Clone()
        {
            return new AHexRegexpart(HexChar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", HexChar);
        }
    }
    public partial class AUnarystarRegexpart : PRegexpart
    {
        private PRegexpart _regexpart_;
        private TStar _star_;
        
        public AUnarystarRegexpart(PRegexpart _regexpart_, TStar _star_)
            : base()
        {
            this.Regexpart = _regexpart_;
            this.Star = _star_;
        }
        
        public PRegexpart Regexpart
        {
            get { return _regexpart_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Regexpart in AUnarystarRegexpart cannot be null.", "value");
                
                if (_regexpart_ != null)
                    SetParent(_regexpart_, null);
                SetParent(value, this);
                
                _regexpart_ = value;
            }
        }
        public TStar Star
        {
            get { return _star_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Star in AUnarystarRegexpart cannot be null.", "value");
                
                if (_star_ != null)
                    SetParent(_star_, null);
                SetParent(value, this);
                
                _star_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Regexpart == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Regexpart in AUnarystarRegexpart cannot be null.", "newChild");
                if (!(newChild is PRegexpart) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Regexpart = newChild as PRegexpart;
            }
            else if (Star == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Star in AUnarystarRegexpart cannot be null.", "newChild");
                if (!(newChild is TStar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Star = newChild as TStar;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Regexpart;
            yield return Star;
        }
        
        public override PRegexpart Clone()
        {
            return new AUnarystarRegexpart(Regexpart.Clone(), Star.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Regexpart, Star);
        }
    }
    public partial class AUnaryquestionRegexpart : PRegexpart
    {
        private PRegexpart _regexpart_;
        private TQMark _question_;
        
        public AUnaryquestionRegexpart(PRegexpart _regexpart_, TQMark _question_)
            : base()
        {
            this.Regexpart = _regexpart_;
            this.Question = _question_;
        }
        
        public PRegexpart Regexpart
        {
            get { return _regexpart_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Regexpart in AUnaryquestionRegexpart cannot be null.", "value");
                
                if (_regexpart_ != null)
                    SetParent(_regexpart_, null);
                SetParent(value, this);
                
                _regexpart_ = value;
            }
        }
        public TQMark Question
        {
            get { return _question_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Question in AUnaryquestionRegexpart cannot be null.", "value");
                
                if (_question_ != null)
                    SetParent(_question_, null);
                SetParent(value, this);
                
                _question_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Regexpart == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Regexpart in AUnaryquestionRegexpart cannot be null.", "newChild");
                if (!(newChild is PRegexpart) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Regexpart = newChild as PRegexpart;
            }
            else if (Question == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Question in AUnaryquestionRegexpart cannot be null.", "newChild");
                if (!(newChild is TQMark) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Question = newChild as TQMark;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Regexpart;
            yield return Question;
        }
        
        public override PRegexpart Clone()
        {
            return new AUnaryquestionRegexpart(Regexpart.Clone(), Question.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Regexpart, Question);
        }
    }
    public partial class AUnaryplusRegexpart : PRegexpart
    {
        private PRegexpart _regexpart_;
        private TPlus _plus_;
        
        public AUnaryplusRegexpart(PRegexpart _regexpart_, TPlus _plus_)
            : base()
        {
            this.Regexpart = _regexpart_;
            this.Plus = _plus_;
        }
        
        public PRegexpart Regexpart
        {
            get { return _regexpart_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Regexpart in AUnaryplusRegexpart cannot be null.", "value");
                
                if (_regexpart_ != null)
                    SetParent(_regexpart_, null);
                SetParent(value, this);
                
                _regexpart_ = value;
            }
        }
        public TPlus Plus
        {
            get { return _plus_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Plus in AUnaryplusRegexpart cannot be null.", "value");
                
                if (_plus_ != null)
                    SetParent(_plus_, null);
                SetParent(value, this);
                
                _plus_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Regexpart == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Regexpart in AUnaryplusRegexpart cannot be null.", "newChild");
                if (!(newChild is PRegexpart) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Regexpart = newChild as PRegexpart;
            }
            else if (Plus == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Plus in AUnaryplusRegexpart cannot be null.", "newChild");
                if (!(newChild is TPlus) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Plus = newChild as TPlus;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Regexpart;
            yield return Plus;
        }
        
        public override PRegexpart Clone()
        {
            return new AUnaryplusRegexpart(Regexpart.Clone(), Plus.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Regexpart, Plus);
        }
    }
    public partial class ABinaryplusRegexpart : PRegexpart
    {
        private TLBkt _lpar_;
        private PRegexpart _left_;
        private TPlus _plus_;
        private PRegexpart _right_;
        private TRBkt _rpar_;
        
        public ABinaryplusRegexpart(TLBkt _lpar_, PRegexpart _left_, TPlus _plus_, PRegexpart _right_, TRBkt _rpar_)
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
                    throw new ArgumentException("Lpar in ABinaryplusRegexpart cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public PRegexpart Left
        {
            get { return _left_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Left in ABinaryplusRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Plus in ABinaryplusRegexpart cannot be null.", "value");
                
                if (_plus_ != null)
                    SetParent(_plus_, null);
                SetParent(value, this);
                
                _plus_ = value;
            }
        }
        public PRegexpart Right
        {
            get { return _right_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Right in ABinaryplusRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Rpar in ABinaryplusRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Lpar in ABinaryplusRegexpart cannot be null.", "newChild");
                if (!(newChild is TLBkt) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBkt;
            }
            else if (Left == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Left in ABinaryplusRegexpart cannot be null.", "newChild");
                if (!(newChild is PRegexpart) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Left = newChild as PRegexpart;
            }
            else if (Plus == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Plus in ABinaryplusRegexpart cannot be null.", "newChild");
                if (!(newChild is TPlus) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Plus = newChild as TPlus;
            }
            else if (Right == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Right in ABinaryplusRegexpart cannot be null.", "newChild");
                if (!(newChild is PRegexpart) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Right = newChild as PRegexpart;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in ABinaryplusRegexpart cannot be null.", "newChild");
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
        
        public override PRegexpart Clone()
        {
            return new ABinaryplusRegexpart(Lpar.Clone(), Left.Clone(), Plus.Clone(), Right.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Lpar, Left, Plus, Right, Rpar);
        }
    }
    public partial class ABinaryminusRegexpart : PRegexpart
    {
        private TLBkt _lpar_;
        private PRegexpart _left_;
        private TMinus _minus_;
        private PRegexpart _right_;
        private TRBkt _rpar_;
        
        public ABinaryminusRegexpart(TLBkt _lpar_, PRegexpart _left_, TMinus _minus_, PRegexpart _right_, TRBkt _rpar_)
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
                    throw new ArgumentException("Lpar in ABinaryminusRegexpart cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public PRegexpart Left
        {
            get { return _left_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Left in ABinaryminusRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Minus in ABinaryminusRegexpart cannot be null.", "value");
                
                if (_minus_ != null)
                    SetParent(_minus_, null);
                SetParent(value, this);
                
                _minus_ = value;
            }
        }
        public PRegexpart Right
        {
            get { return _right_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Right in ABinaryminusRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Rpar in ABinaryminusRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Lpar in ABinaryminusRegexpart cannot be null.", "newChild");
                if (!(newChild is TLBkt) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBkt;
            }
            else if (Left == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Left in ABinaryminusRegexpart cannot be null.", "newChild");
                if (!(newChild is PRegexpart) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Left = newChild as PRegexpart;
            }
            else if (Minus == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Minus in ABinaryminusRegexpart cannot be null.", "newChild");
                if (!(newChild is TMinus) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Minus = newChild as TMinus;
            }
            else if (Right == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Right in ABinaryminusRegexpart cannot be null.", "newChild");
                if (!(newChild is PRegexpart) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Right = newChild as PRegexpart;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in ABinaryminusRegexpart cannot be null.", "newChild");
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
        
        public override PRegexpart Clone()
        {
            return new ABinaryminusRegexpart(Lpar.Clone(), Left.Clone(), Minus.Clone(), Right.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Lpar, Left, Minus, Right, Rpar);
        }
    }
    public partial class AIntervalRegexpart : PRegexpart
    {
        private TLBkt _lpar_;
        private PRegexpart _left_;
        private TDDot _dots_;
        private PRegexpart _right_;
        private TRBkt _rpar_;
        
        public AIntervalRegexpart(TLBkt _lpar_, PRegexpart _left_, TDDot _dots_, PRegexpart _right_, TRBkt _rpar_)
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
                    throw new ArgumentException("Lpar in AIntervalRegexpart cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public PRegexpart Left
        {
            get { return _left_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Left in AIntervalRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Dots in AIntervalRegexpart cannot be null.", "value");
                
                if (_dots_ != null)
                    SetParent(_dots_, null);
                SetParent(value, this);
                
                _dots_ = value;
            }
        }
        public PRegexpart Right
        {
            get { return _right_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Right in AIntervalRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Rpar in AIntervalRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Lpar in AIntervalRegexpart cannot be null.", "newChild");
                if (!(newChild is TLBkt) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBkt;
            }
            else if (Left == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Left in AIntervalRegexpart cannot be null.", "newChild");
                if (!(newChild is PRegexpart) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Left = newChild as PRegexpart;
            }
            else if (Dots == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Dots in AIntervalRegexpart cannot be null.", "newChild");
                if (!(newChild is TDDot) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Dots = newChild as TDDot;
            }
            else if (Right == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Right in AIntervalRegexpart cannot be null.", "newChild");
                if (!(newChild is PRegexpart) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Right = newChild as PRegexpart;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in AIntervalRegexpart cannot be null.", "newChild");
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
        
        public override PRegexpart Clone()
        {
            return new AIntervalRegexpart(Lpar.Clone(), Left.Clone(), Dots.Clone(), Right.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Lpar, Left, Dots, Right, Rpar);
        }
    }
    public partial class AStringRegexpart : PRegexpart
    {
        private TString _string_;
        
        public AStringRegexpart(TString _string_)
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
                    throw new ArgumentException("String in AStringRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("String in AStringRegexpart cannot be null.", "newChild");
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
        
        public override PRegexpart Clone()
        {
            return new AStringRegexpart(String.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", String);
        }
    }
    public partial class AIdentifierRegexpart : PRegexpart
    {
        private TIdentifier _identifier_;
        
        public AIdentifierRegexpart(TIdentifier _identifier_)
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
                    throw new ArgumentException("Identifier in AIdentifierRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Identifier in AIdentifierRegexpart cannot be null.", "newChild");
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
        
        public override PRegexpart Clone()
        {
            return new AIdentifierRegexpart(Identifier.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Identifier);
        }
    }
    public partial class AParenthesisRegexpart : PRegexpart
    {
        private TLPar _lpar_;
        private PRegex _regex_;
        private TRPar _rpar_;
        
        public AParenthesisRegexpart(TLPar _lpar_, PRegex _regex_, TRPar _rpar_)
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
                    throw new ArgumentException("Lpar in AParenthesisRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Regex in AParenthesisRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Rpar in AParenthesisRegexpart cannot be null.", "value");
                
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
                    throw new ArgumentException("Lpar in AParenthesisRegexpart cannot be null.", "newChild");
                if (!(newChild is TLPar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLPar;
            }
            else if (Regex == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Regex in AParenthesisRegexpart cannot be null.", "newChild");
                if (!(newChild is PRegex) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Regex = newChild as PRegex;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in AParenthesisRegexpart cannot be null.", "newChild");
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
        
        public override PRegexpart Clone()
        {
            return new AParenthesisRegexpart(Lpar.Clone(), Regex.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Lpar, Regex, Rpar);
        }
    }
    public abstract partial class PStates : Production<PStates>
    {
        private TStatestoken _statestoken_;
        private NodeList<PIdentifierListitem> _states_;
        private TSemicolon _semicolon_;
        
        public PStates(TStatestoken _statestoken_, IEnumerable<PIdentifierListitem> _states_, TSemicolon _semicolon_)
        {
            this.Statestoken = _statestoken_;
            this._states_ = new NodeList<PIdentifierListitem>(this, _states_, false);
            this.Semicolon = _semicolon_;
        }
        
        public TStatestoken Statestoken
        {
            get { return _statestoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Statestoken in PStates cannot be null.", "value");
                
                if (_statestoken_ != null)
                    SetParent(_statestoken_, null);
                SetParent(value, this);
                
                _statestoken_ = value;
            }
        }
        public NodeList<PIdentifierListitem> States
        {
            get { return _states_; }
        }
        public TSemicolon Semicolon
        {
            get { return _semicolon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Semicolon in PStates cannot be null.", "value");
                
                if (_semicolon_ != null)
                    SetParent(_semicolon_, null);
                SetParent(value, this);
                
                _semicolon_ = value;
            }
        }
        
    }
    public partial class AStates : PStates
    {
        public AStates(TStatestoken _statestoken_, IEnumerable<PIdentifierListitem> _states_, TSemicolon _semicolon_)
            : base(_statestoken_, _states_, _semicolon_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Statestoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Statestoken in AStates cannot be null.", "newChild");
                if (!(newChild is TStatestoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Statestoken = newChild as TStatestoken;
            }
            else if (oldChild is PIdentifierListitem && States.Contains(oldChild as PIdentifierListitem))
            {
                if (!(newChild is PIdentifierListitem) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = States.IndexOf(oldChild as PIdentifierListitem);
                if (newChild == null)
                    States.RemoveAt(index);
                else
                    States[index] = newChild as PIdentifierListitem;
            }
            else if (Semicolon == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Semicolon in AStates cannot be null.", "newChild");
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
                PIdentifierListitem[] temp = new PIdentifierListitem[States.Count];
                States.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Semicolon;
        }
        
        public override PStates Clone()
        {
            return new AStates(Statestoken.Clone(), States, Semicolon.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Statestoken, States, Semicolon);
        }
    }
    public abstract partial class PIgnoredtokens : Production<PIgnoredtokens>
    {
        private TIgnoredtoken _ignoredtoken_;
        private TTokenstoken _tokenstoken_;
        private NodeList<PIdentifierListitem> _tokens_;
        private TSemicolon _semicolon_;
        
        public PIgnoredtokens(TIgnoredtoken _ignoredtoken_, TTokenstoken _tokenstoken_, IEnumerable<PIdentifierListitem> _tokens_, TSemicolon _semicolon_)
        {
            this.Ignoredtoken = _ignoredtoken_;
            this.Tokenstoken = _tokenstoken_;
            this._tokens_ = new NodeList<PIdentifierListitem>(this, _tokens_, false);
            this.Semicolon = _semicolon_;
        }
        
        public TIgnoredtoken Ignoredtoken
        {
            get { return _ignoredtoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Ignoredtoken in PIgnoredtokens cannot be null.", "value");
                
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
                    throw new ArgumentException("Tokenstoken in PIgnoredtokens cannot be null.", "value");
                
                if (_tokenstoken_ != null)
                    SetParent(_tokenstoken_, null);
                SetParent(value, this);
                
                _tokenstoken_ = value;
            }
        }
        public NodeList<PIdentifierListitem> Tokens
        {
            get { return _tokens_; }
        }
        public TSemicolon Semicolon
        {
            get { return _semicolon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Semicolon in PIgnoredtokens cannot be null.", "value");
                
                if (_semicolon_ != null)
                    SetParent(_semicolon_, null);
                SetParent(value, this);
                
                _semicolon_ = value;
            }
        }
        
    }
    public partial class AIgnoredtokens : PIgnoredtokens
    {
        public AIgnoredtokens(TIgnoredtoken _ignoredtoken_, TTokenstoken _tokenstoken_, IEnumerable<PIdentifierListitem> _tokens_, TSemicolon _semicolon_)
            : base(_ignoredtoken_, _tokenstoken_, _tokens_, _semicolon_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Ignoredtoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Ignoredtoken in AIgnoredtokens cannot be null.", "newChild");
                if (!(newChild is TIgnoredtoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Ignoredtoken = newChild as TIgnoredtoken;
            }
            else if (Tokenstoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Tokenstoken in AIgnoredtokens cannot be null.", "newChild");
                if (!(newChild is TTokenstoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Tokenstoken = newChild as TTokenstoken;
            }
            else if (oldChild is PIdentifierListitem && Tokens.Contains(oldChild as PIdentifierListitem))
            {
                if (!(newChild is PIdentifierListitem) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Tokens.IndexOf(oldChild as PIdentifierListitem);
                if (newChild == null)
                    Tokens.RemoveAt(index);
                else
                    Tokens[index] = newChild as PIdentifierListitem;
            }
            else if (Semicolon == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Semicolon in AIgnoredtokens cannot be null.", "newChild");
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
                PIdentifierListitem[] temp = new PIdentifierListitem[Tokens.Count];
                Tokens.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Semicolon;
        }
        
        public override PIgnoredtokens Clone()
        {
            return new AIgnoredtokens(Ignoredtoken.Clone(), Tokenstoken.Clone(), Tokens, Semicolon.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Ignoredtoken, Tokenstoken, Tokens, Semicolon);
        }
    }
    public abstract partial class PIdentifierListitem : Production<PIdentifierListitem>
    {
        private TComma _comma_;
        private TIdentifier _identifier_;
        
        public PIdentifierListitem(TComma _comma_, TIdentifier _identifier_)
        {
            this.Comma = _comma_;
            this.Identifier = _identifier_;
        }
        
        public TComma Comma
        {
            get { return _comma_; }
            set
            {
                if (_comma_ != null)
                    SetParent(_comma_, null);
                if (value != null)
                    SetParent(value, this);
                
                _comma_ = value;
            }
        }
        public bool HasComma
        {
            get { return _comma_ != null; }
        }
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in PIdentifierListitem cannot be null.", "value");
                
                if (_identifier_ != null)
                    SetParent(_identifier_, null);
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        
    }
    public partial class AIdentifierListitem : PIdentifierListitem
    {
        public AIdentifierListitem(TComma _comma_, TIdentifier _identifier_)
            : base(_comma_, _identifier_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Comma == oldChild)
            {
                if (!(newChild is TComma) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Comma = newChild as TComma;
            }
            else if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in AIdentifierListitem cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasComma)
                yield return Comma;
            yield return Identifier;
        }
        
        public override PIdentifierListitem Clone()
        {
            return new AIdentifierListitem(Comma.Clone(), Identifier.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Comma, Identifier);
        }
    }
    public abstract partial class PTokenstateList : Production<PTokenstateList>
    {
        private TLBrace _lpar_;
        private NodeList<PTokenstateListitem> _states_;
        private TRBrace _rpar_;
        
        public PTokenstateList(TLBrace _lpar_, IEnumerable<PTokenstateListitem> _states_, TRBrace _rpar_)
        {
            this.Lpar = _lpar_;
            this._states_ = new NodeList<PTokenstateListitem>(this, _states_, false);
            this.Rpar = _rpar_;
        }
        
        public TLBrace Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in PTokenstateList cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public NodeList<PTokenstateListitem> States
        {
            get { return _states_; }
        }
        public TRBrace Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in PTokenstateList cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        
    }
    public partial class ATokenstateList : PTokenstateList
    {
        public ATokenstateList(TLBrace _lpar_, IEnumerable<PTokenstateListitem> _states_, TRBrace _rpar_)
            : base(_lpar_, _states_, _rpar_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in ATokenstateList cannot be null.", "newChild");
                if (!(newChild is TLBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBrace;
            }
            else if (oldChild is PTokenstateListitem && States.Contains(oldChild as PTokenstateListitem))
            {
                if (!(newChild is PTokenstateListitem) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = States.IndexOf(oldChild as PTokenstateListitem);
                if (newChild == null)
                    States.RemoveAt(index);
                else
                    States[index] = newChild as PTokenstateListitem;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in ATokenstateList cannot be null.", "newChild");
                if (!(newChild is TRBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBrace;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            {
                PTokenstateListitem[] temp = new PTokenstateListitem[States.Count];
                States.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Rpar;
        }
        
        public override PTokenstateList Clone()
        {
            return new ATokenstateList(Lpar.Clone(), States, Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Lpar, States, Rpar);
        }
    }
    public abstract partial class PTokenstateListitem : Production<PTokenstateListitem>
    {
        private TComma _comma_;
        
        public PTokenstateListitem(TComma _comma_)
        {
            this.Comma = _comma_;
        }
        
        public TComma Comma
        {
            get { return _comma_; }
            set
            {
                if (_comma_ != null)
                    SetParent(_comma_, null);
                if (value != null)
                    SetParent(value, this);
                
                _comma_ = value;
            }
        }
        public bool HasComma
        {
            get { return _comma_ != null; }
        }
        
    }
    public partial class ATokenstateListitem : PTokenstateListitem
    {
        private TIdentifier _identifier_;
        
        public ATokenstateListitem(TComma _comma_, TIdentifier _identifier_)
            : base(_comma_)
        {
            this.Identifier = _identifier_;
        }
        
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in ATokenstateListitem cannot be null.", "value");
                
                if (_identifier_ != null)
                    SetParent(_identifier_, null);
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Comma == oldChild)
            {
                if (!(newChild is TComma) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Comma = newChild as TComma;
            }
            else if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in ATokenstateListitem cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasComma)
                yield return Comma;
            yield return Identifier;
        }
        
        public override PTokenstateListitem Clone()
        {
            return new ATokenstateListitem(Comma.Clone(), Identifier.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Comma, Identifier);
        }
    }
    public partial class ATransitionTokenstateListitem : PTokenstateListitem
    {
        private TIdentifier _from_;
        private TArrow _arrow_;
        private TIdentifier _to_;
        
        public ATransitionTokenstateListitem(TComma _comma_, TIdentifier _from_, TArrow _arrow_, TIdentifier _to_)
            : base(_comma_)
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
                    throw new ArgumentException("From in ATransitionTokenstateListitem cannot be null.", "value");
                
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
                    throw new ArgumentException("Arrow in ATransitionTokenstateListitem cannot be null.", "value");
                
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
                    throw new ArgumentException("To in ATransitionTokenstateListitem cannot be null.", "value");
                
                if (_to_ != null)
                    SetParent(_to_, null);
                SetParent(value, this);
                
                _to_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Comma == oldChild)
            {
                if (!(newChild is TComma) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Comma = newChild as TComma;
            }
            else if (From == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("From in ATransitionTokenstateListitem cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                From = newChild as TIdentifier;
            }
            else if (Arrow == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Arrow in ATransitionTokenstateListitem cannot be null.", "newChild");
                if (!(newChild is TArrow) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Arrow = newChild as TArrow;
            }
            else if (To == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("To in ATransitionTokenstateListitem cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                To = newChild as TIdentifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasComma)
                yield return Comma;
            yield return From;
            yield return Arrow;
            yield return To;
        }
        
        public override PTokenstateListitem Clone()
        {
            return new ATransitionTokenstateListitem(Comma.Clone(), From.Clone(), Arrow.Clone(), To.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Comma, From, Arrow, To);
        }
    }
    public abstract partial class PTranslationListitem : Production<PTranslationListitem>
    {
        private TComma _comma_;
        private PTranslation _translation_;
        
        public PTranslationListitem(TComma _comma_, PTranslation _translation_)
        {
            this.Comma = _comma_;
            this.Translation = _translation_;
        }
        
        public TComma Comma
        {
            get { return _comma_; }
            set
            {
                if (_comma_ != null)
                    SetParent(_comma_, null);
                if (value != null)
                    SetParent(value, this);
                
                _comma_ = value;
            }
        }
        public bool HasComma
        {
            get { return _comma_ != null; }
        }
        public PTranslation Translation
        {
            get { return _translation_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Translation in PTranslationListitem cannot be null.", "value");
                
                if (_translation_ != null)
                    SetParent(_translation_, null);
                SetParent(value, this);
                
                _translation_ = value;
            }
        }
        
    }
    public partial class ATranslationListitem : PTranslationListitem
    {
        public ATranslationListitem(TComma _comma_, PTranslation _translation_)
            : base(_comma_, _translation_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Comma == oldChild)
            {
                if (!(newChild is TComma) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Comma = newChild as TComma;
            }
            else if (Translation == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Translation in ATranslationListitem cannot be null.", "newChild");
                if (!(newChild is PTranslation) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Translation = newChild as PTranslation;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasComma)
                yield return Comma;
            yield return Translation;
        }
        
        public override PTranslationListitem Clone()
        {
            return new ATranslationListitem(Comma.Clone(), Translation.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Comma, Translation);
        }
    }
    public abstract partial class PStyleListitem : Production<PStyleListitem>
    {
        private TComma _comma_;
        private PHighlightStyle _highlight_style_;
        
        public PStyleListitem(TComma _comma_, PHighlightStyle _highlight_style_)
        {
            this.Comma = _comma_;
            this.HighlightStyle = _highlight_style_;
        }
        
        public TComma Comma
        {
            get { return _comma_; }
            set
            {
                if (_comma_ != null)
                    SetParent(_comma_, null);
                if (value != null)
                    SetParent(value, this);
                
                _comma_ = value;
            }
        }
        public bool HasComma
        {
            get { return _comma_ != null; }
        }
        public PHighlightStyle HighlightStyle
        {
            get { return _highlight_style_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("HighlightStyle in PStyleListitem cannot be null.", "value");
                
                if (_highlight_style_ != null)
                    SetParent(_highlight_style_, null);
                SetParent(value, this);
                
                _highlight_style_ = value;
            }
        }
        
    }
    public partial class AStyleListitem : PStyleListitem
    {
        public AStyleListitem(TComma _comma_, PHighlightStyle _highlight_style_)
            : base(_comma_, _highlight_style_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Comma == oldChild)
            {
                if (!(newChild is TComma) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Comma = newChild as TComma;
            }
            else if (HighlightStyle == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("HighlightStyle in AStyleListitem cannot be null.", "newChild");
                if (!(newChild is PHighlightStyle) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                HighlightStyle = newChild as PHighlightStyle;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasComma)
                yield return Comma;
            yield return HighlightStyle;
        }
        
        public override PStyleListitem Clone()
        {
            return new AStyleListitem(Comma.Clone(), HighlightStyle.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Comma, HighlightStyle);
        }
    }
    public abstract partial class PProductions : Production<PProductions>
    {
        private TProductionstoken _productionstoken_;
        private NodeList<PProduction> _productions_;
        
        public PProductions(TProductionstoken _productionstoken_, IEnumerable<PProduction> _productions_)
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
                    throw new ArgumentException("Productionstoken in PProductions cannot be null.", "value");
                
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
        
    }
    public partial class AProductions : PProductions
    {
        public AProductions(TProductionstoken _productionstoken_, IEnumerable<PProduction> _productions_)
            : base(_productionstoken_, _productions_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Productionstoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Productionstoken in AProductions cannot be null.", "newChild");
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
        
        public override PProductions Clone()
        {
            return new AProductions(Productionstoken.Clone(), Productions);
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Productionstoken, Productions);
        }
    }
    public abstract partial class PAstproductions : Production<PAstproductions>
    {
        private TAsttoken _asttoken_;
        private NodeList<PProduction> _productions_;
        
        public PAstproductions(TAsttoken _asttoken_, IEnumerable<PProduction> _productions_)
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
                    throw new ArgumentException("Asttoken in PAstproductions cannot be null.", "value");
                
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
        
    }
    public partial class AAstproductions : PAstproductions
    {
        public AAstproductions(TAsttoken _asttoken_, IEnumerable<PProduction> _productions_)
            : base(_asttoken_, _productions_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Asttoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Asttoken in AAstproductions cannot be null.", "newChild");
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
        
        public override PAstproductions Clone()
        {
            return new AAstproductions(Asttoken.Clone(), Productions);
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Asttoken, Productions);
        }
    }
    public abstract partial class PProduction : Production<PProduction>
    {
        private TIdentifier _identifier_;
        private PProdtranslation _prodtranslation_;
        private TEqual _equal_;
        private PProductionrule _productionrule_;
        private TSemicolon _semicolon_;
        
        public PProduction(TIdentifier _identifier_, PProdtranslation _prodtranslation_, TEqual _equal_, PProductionrule _productionrule_, TSemicolon _semicolon_)
        {
            this.Identifier = _identifier_;
            this.Prodtranslation = _prodtranslation_;
            this.Equal = _equal_;
            this.Productionrule = _productionrule_;
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
        public PProductionrule Productionrule
        {
            get { return _productionrule_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Productionrule in PProduction cannot be null.", "value");
                
                if (_productionrule_ != null)
                    SetParent(_productionrule_, null);
                SetParent(value, this);
                
                _productionrule_ = value;
            }
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
        public AProduction(TIdentifier _identifier_, PProdtranslation _prodtranslation_, TEqual _equal_, PProductionrule _productionrule_, TSemicolon _semicolon_)
            : base(_identifier_, _prodtranslation_, _equal_, _productionrule_, _semicolon_)
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
            else if (Productionrule == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Productionrule in AProduction cannot be null.", "newChild");
                if (!(newChild is PProductionrule) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Productionrule = newChild as PProductionrule;
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
            yield return Productionrule;
            yield return Semicolon;
        }
        
        public override PProduction Clone()
        {
            return new AProduction(Identifier.Clone(), Prodtranslation.Clone(), Equal.Clone(), Productionrule.Clone(), Semicolon.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Identifier, Prodtranslation, Equal, Productionrule, Semicolon);
        }
    }
    public abstract partial class PProdtranslation : Production<PProdtranslation>
    {
        private TLBrace _lpar_;
        private TArrow _arrow_;
        private TIdentifier _identifier_;
        private TRBrace _rpar_;
        
        public PProdtranslation(TLBrace _lpar_, TArrow _arrow_, TIdentifier _identifier_, TRBrace _rpar_)
        {
            this.Lpar = _lpar_;
            this.Arrow = _arrow_;
            this.Identifier = _identifier_;
            this.Rpar = _rpar_;
        }
        
        public TLBrace Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in PProdtranslation cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
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
        public TRBrace Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in PProdtranslation cannot be null.", "value");
                
                if (_rpar_ != null)
                    SetParent(_rpar_, null);
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        
    }
    public partial class ACleanProdtranslation : PProdtranslation
    {
        public ACleanProdtranslation(TLBrace _lpar_, TArrow _arrow_, TIdentifier _identifier_, TRBrace _rpar_)
            : base(_lpar_, _arrow_, _identifier_, _rpar_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in ACleanProdtranslation cannot be null.", "newChild");
                if (!(newChild is TLBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBrace;
            }
            else if (Arrow == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Arrow in ACleanProdtranslation cannot be null.", "newChild");
                if (!(newChild is TArrow) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Arrow = newChild as TArrow;
            }
            else if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in ACleanProdtranslation cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in ACleanProdtranslation cannot be null.", "newChild");
                if (!(newChild is TRBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBrace;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            yield return Arrow;
            yield return Identifier;
            yield return Rpar;
        }
        
        public override PProdtranslation Clone()
        {
            return new ACleanProdtranslation(Lpar.Clone(), Arrow.Clone(), Identifier.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Lpar, Arrow, Identifier, Rpar);
        }
    }
    public partial class AStarProdtranslation : PProdtranslation
    {
        private TStar _star_;
        
        public AStarProdtranslation(TLBrace _lpar_, TArrow _arrow_, TIdentifier _identifier_, TStar _star_, TRBrace _rpar_)
            : base(_lpar_, _arrow_, _identifier_, _rpar_)
        {
            this.Star = _star_;
        }
        
        public TStar Star
        {
            get { return _star_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Star in AStarProdtranslation cannot be null.", "value");
                
                if (_star_ != null)
                    SetParent(_star_, null);
                SetParent(value, this);
                
                _star_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in AStarProdtranslation cannot be null.", "newChild");
                if (!(newChild is TLBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBrace;
            }
            else if (Arrow == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Arrow in AStarProdtranslation cannot be null.", "newChild");
                if (!(newChild is TArrow) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Arrow = newChild as TArrow;
            }
            else if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in AStarProdtranslation cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else if (Star == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Star in AStarProdtranslation cannot be null.", "newChild");
                if (!(newChild is TStar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Star = newChild as TStar;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in AStarProdtranslation cannot be null.", "newChild");
                if (!(newChild is TRBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBrace;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            yield return Arrow;
            yield return Identifier;
            yield return Star;
            yield return Rpar;
        }
        
        public override PProdtranslation Clone()
        {
            return new AStarProdtranslation(Lpar.Clone(), Arrow.Clone(), Identifier.Clone(), Star.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Lpar, Arrow, Identifier, Star, Rpar);
        }
    }
    public partial class APlusProdtranslation : PProdtranslation
    {
        private TPlus _plus_;
        
        public APlusProdtranslation(TLBrace _lpar_, TArrow _arrow_, TIdentifier _identifier_, TPlus _plus_, TRBrace _rpar_)
            : base(_lpar_, _arrow_, _identifier_, _rpar_)
        {
            this.Plus = _plus_;
        }
        
        public TPlus Plus
        {
            get { return _plus_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Plus in APlusProdtranslation cannot be null.", "value");
                
                if (_plus_ != null)
                    SetParent(_plus_, null);
                SetParent(value, this);
                
                _plus_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in APlusProdtranslation cannot be null.", "newChild");
                if (!(newChild is TLBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBrace;
            }
            else if (Arrow == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Arrow in APlusProdtranslation cannot be null.", "newChild");
                if (!(newChild is TArrow) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Arrow = newChild as TArrow;
            }
            else if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in APlusProdtranslation cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else if (Plus == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Plus in APlusProdtranslation cannot be null.", "newChild");
                if (!(newChild is TPlus) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Plus = newChild as TPlus;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in APlusProdtranslation cannot be null.", "newChild");
                if (!(newChild is TRBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBrace;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            yield return Arrow;
            yield return Identifier;
            yield return Plus;
            yield return Rpar;
        }
        
        public override PProdtranslation Clone()
        {
            return new APlusProdtranslation(Lpar.Clone(), Arrow.Clone(), Identifier.Clone(), Plus.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Lpar, Arrow, Identifier, Plus, Rpar);
        }
    }
    public partial class AQuestionProdtranslation : PProdtranslation
    {
        private TQMark _q_mark_;
        
        public AQuestionProdtranslation(TLBrace _lpar_, TArrow _arrow_, TIdentifier _identifier_, TQMark _q_mark_, TRBrace _rpar_)
            : base(_lpar_, _arrow_, _identifier_, _rpar_)
        {
            this.QMark = _q_mark_;
        }
        
        public TQMark QMark
        {
            get { return _q_mark_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("QMark in AQuestionProdtranslation cannot be null.", "value");
                
                if (_q_mark_ != null)
                    SetParent(_q_mark_, null);
                SetParent(value, this);
                
                _q_mark_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in AQuestionProdtranslation cannot be null.", "newChild");
                if (!(newChild is TLBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBrace;
            }
            else if (Arrow == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Arrow in AQuestionProdtranslation cannot be null.", "newChild");
                if (!(newChild is TArrow) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Arrow = newChild as TArrow;
            }
            else if (Identifier == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Identifier in AQuestionProdtranslation cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Identifier = newChild as TIdentifier;
            }
            else if (QMark == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("QMark in AQuestionProdtranslation cannot be null.", "newChild");
                if (!(newChild is TQMark) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                QMark = newChild as TQMark;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in AQuestionProdtranslation cannot be null.", "newChild");
                if (!(newChild is TRBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBrace;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            yield return Arrow;
            yield return Identifier;
            yield return QMark;
            yield return Rpar;
        }
        
        public override PProdtranslation Clone()
        {
            return new AQuestionProdtranslation(Lpar.Clone(), Arrow.Clone(), Identifier.Clone(), QMark.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Lpar, Arrow, Identifier, QMark, Rpar);
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
        private TLBrace _lpar_;
        private TArrow _arrow_;
        private PTranslation _translation_;
        private TRBrace _rpar_;
        
        public AFullTranslation(TLBrace _lpar_, TArrow _arrow_, PTranslation _translation_, TRBrace _rpar_)
            : base()
        {
            this.Lpar = _lpar_;
            this.Arrow = _arrow_;
            this.Translation = _translation_;
            this.Rpar = _rpar_;
        }
        
        public TLBrace Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in AFullTranslation cannot be null.", "value");
                
                if (_lpar_ != null)
                    SetParent(_lpar_, null);
                SetParent(value, this);
                
                _lpar_ = value;
            }
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
        public TRBrace Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in AFullTranslation cannot be null.", "value");
                
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
                    throw new ArgumentException("Lpar in AFullTranslation cannot be null.", "newChild");
                if (!(newChild is TLBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBrace;
            }
            else if (Arrow == oldChild)
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
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in AFullTranslation cannot be null.", "newChild");
                if (!(newChild is TRBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBrace;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Lpar;
            yield return Arrow;
            yield return Translation;
            yield return Rpar;
        }
        
        public override PTranslation Clone()
        {
            return new AFullTranslation(Lpar.Clone(), Arrow.Clone(), Translation.Clone(), Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Lpar, Arrow, Translation, Rpar);
        }
    }
    public partial class ANewTranslation : PTranslation
    {
        private TNew _new_;
        private TIdentifier _production_;
        private TLPar _lpar_;
        private NodeList<PTranslationListitem> _arguments_;
        private TRPar _rpar_;
        
        public ANewTranslation(TNew _new_, TIdentifier _production_, TLPar _lpar_, IEnumerable<PTranslationListitem> _arguments_, TRPar _rpar_)
            : base()
        {
            this.New = _new_;
            this.Production = _production_;
            this.Lpar = _lpar_;
            this._arguments_ = new NodeList<PTranslationListitem>(this, _arguments_, false);
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
        public NodeList<PTranslationListitem> Arguments
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
            else if (oldChild is PTranslationListitem && Arguments.Contains(oldChild as PTranslationListitem))
            {
                if (!(newChild is PTranslationListitem) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Arguments.IndexOf(oldChild as PTranslationListitem);
                if (newChild == null)
                    Arguments.RemoveAt(index);
                else
                    Arguments[index] = newChild as PTranslationListitem;
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
                PTranslationListitem[] temp = new PTranslationListitem[Arguments.Count];
                Arguments.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Rpar;
        }
        
        public override PTranslation Clone()
        {
            return new ANewTranslation(New.Clone(), Production.Clone(), Lpar.Clone(), Arguments, Rpar.Clone());
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
        private NodeList<PTranslationListitem> _arguments_;
        private TRPar _rpar_;
        
        public ANewalternativeTranslation(TNew _new_, TIdentifier _production_, TDot _dot_, TIdentifier _alternative_, TLPar _lpar_, IEnumerable<PTranslationListitem> _arguments_, TRPar _rpar_)
            : base()
        {
            this.New = _new_;
            this.Production = _production_;
            this.Dot = _dot_;
            this.Alternative = _alternative_;
            this.Lpar = _lpar_;
            this._arguments_ = new NodeList<PTranslationListitem>(this, _arguments_, false);
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
        public NodeList<PTranslationListitem> Arguments
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
            else if (oldChild is PTranslationListitem && Arguments.Contains(oldChild as PTranslationListitem))
            {
                if (!(newChild is PTranslationListitem) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Arguments.IndexOf(oldChild as PTranslationListitem);
                if (newChild == null)
                    Arguments.RemoveAt(index);
                else
                    Arguments[index] = newChild as PTranslationListitem;
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
                PTranslationListitem[] temp = new PTranslationListitem[Arguments.Count];
                Arguments.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Rpar;
        }
        
        public override PTranslation Clone()
        {
            return new ANewalternativeTranslation(New.Clone(), Production.Clone(), Dot.Clone(), Alternative.Clone(), Lpar.Clone(), Arguments, Rpar.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6}", New, Production, Dot, Alternative, Lpar, Arguments, Rpar);
        }
    }
    public partial class AListTranslation : PTranslation
    {
        private TLBkt _lpar_;
        private NodeList<PTranslationListitem> _elements_;
        private TRBkt _rpar_;
        
        public AListTranslation(TLBkt _lpar_, IEnumerable<PTranslationListitem> _elements_, TRBkt _rpar_)
            : base()
        {
            this.Lpar = _lpar_;
            this._elements_ = new NodeList<PTranslationListitem>(this, _elements_, false);
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
        public NodeList<PTranslationListitem> Elements
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
            else if (oldChild is PTranslationListitem && Elements.Contains(oldChild as PTranslationListitem))
            {
                if (!(newChild is PTranslationListitem) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Elements.IndexOf(oldChild as PTranslationListitem);
                if (newChild == null)
                    Elements.RemoveAt(index);
                else
                    Elements[index] = newChild as PTranslationListitem;
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
                PTranslationListitem[] temp = new PTranslationListitem[Elements.Count];
                Elements.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Rpar;
        }
        
        public override PTranslation Clone()
        {
            return new AListTranslation(Lpar.Clone(), Elements, Rpar.Clone());
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
    public abstract partial class PProductionrule : Production<PProductionrule>
    {
        private NodeList<PAlternative> _alternatives_;
        
        public PProductionrule(IEnumerable<PAlternative> _alternatives_)
        {
            this._alternatives_ = new NodeList<PAlternative>(this, _alternatives_, false);
        }
        
        public NodeList<PAlternative> Alternatives
        {
            get { return _alternatives_; }
        }
        
    }
    public partial class AProductionrule : PProductionrule
    {
        public AProductionrule(IEnumerable<PAlternative> _alternatives_)
            : base(_alternatives_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (oldChild is PAlternative && Alternatives.Contains(oldChild as PAlternative))
            {
                if (!(newChild is PAlternative) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Alternatives.IndexOf(oldChild as PAlternative);
                if (newChild == null)
                    Alternatives.RemoveAt(index);
                else
                    Alternatives[index] = newChild as PAlternative;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            {
                PAlternative[] temp = new PAlternative[Alternatives.Count];
                Alternatives.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PProductionrule Clone()
        {
            return new AProductionrule(Alternatives);
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Alternatives);
        }
    }
    public abstract partial class PAlternative : Production<PAlternative>
    {
        private TPipe _pipe_;
        private PAlternativename _alternativename_;
        private PElements _elements_;
        private PTranslation _translation_;
        
        public PAlternative(TPipe _pipe_, PAlternativename _alternativename_, PElements _elements_, PTranslation _translation_)
        {
            this.Pipe = _pipe_;
            this.Alternativename = _alternativename_;
            this.Elements = _elements_;
            this.Translation = _translation_;
        }
        
        public TPipe Pipe
        {
            get { return _pipe_; }
            set
            {
                if (_pipe_ != null)
                    SetParent(_pipe_, null);
                if (value != null)
                    SetParent(value, this);
                
                _pipe_ = value;
            }
        }
        public bool HasPipe
        {
            get { return _pipe_ != null; }
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
        public PElements Elements
        {
            get { return _elements_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Elements in PAlternative cannot be null.", "value");
                
                if (_elements_ != null)
                    SetParent(_elements_, null);
                SetParent(value, this);
                
                _elements_ = value;
            }
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
        public AAlternative(TPipe _pipe_, PAlternativename _alternativename_, PElements _elements_, PTranslation _translation_)
            : base(_pipe_, _alternativename_, _elements_, _translation_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Pipe == oldChild)
            {
                if (!(newChild is TPipe) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Pipe = newChild as TPipe;
            }
            else if (Alternativename == oldChild)
            {
                if (!(newChild is PAlternativename) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Alternativename = newChild as PAlternativename;
            }
            else if (Elements == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Elements in AAlternative cannot be null.", "newChild");
                if (!(newChild is PElements) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Elements = newChild as PElements;
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
            if (HasPipe)
                yield return Pipe;
            if (HasAlternativename)
                yield return Alternativename;
            yield return Elements;
            if (HasTranslation)
                yield return Translation;
        }
        
        public override PAlternative Clone()
        {
            return new AAlternative(Pipe.Clone(), Alternativename.Clone(), Elements.Clone(), Translation.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Pipe, Alternativename, Elements, Translation);
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
    public abstract partial class PElements : Production<PElements>
    {
        private NodeList<PElement> _element_;
        
        public PElements(IEnumerable<PElement> _element_)
        {
            this._element_ = new NodeList<PElement>(this, _element_, false);
        }
        
        public NodeList<PElement> Element
        {
            get { return _element_; }
        }
        
    }
    public partial class AElements : PElements
    {
        public AElements(IEnumerable<PElement> _element_)
            : base(_element_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (oldChild is PElement && Element.Contains(oldChild as PElement))
            {
                if (!(newChild is PElement) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Element.IndexOf(oldChild as PElement);
                if (newChild == null)
                    Element.RemoveAt(index);
                else
                    Element[index] = newChild as PElement;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            {
                PElement[] temp = new PElement[Element.Count];
                Element.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PElements Clone()
        {
            return new AElements(Element);
        }
        
        public override string ToString()
        {
            return string.Format("{0}", Element);
        }
    }
    public abstract partial class PElement : Production<PElement>
    {
        private PElementname _elementname_;
        private PElementid _elementid_;
        
        public PElement(PElementname _elementname_, PElementid _elementid_)
        {
            this.Elementname = _elementname_;
            this.Elementid = _elementid_;
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
        
    }
    public partial class ASimpleElement : PElement
    {
        public ASimpleElement(PElementname _elementname_, PElementid _elementid_)
            : base(_elementname_, _elementid_)
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
                    throw new ArgumentException("Elementid in ASimpleElement cannot be null.", "newChild");
                if (!(newChild is PElementid) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Elementid = newChild as PElementid;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasElementname)
                yield return Elementname;
            yield return Elementid;
        }
        
        public override PElement Clone()
        {
            return new ASimpleElement(Elementname.Clone(), Elementid.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Elementname, Elementid);
        }
    }
    public partial class AStarElement : PElement
    {
        private TStar _star_;
        
        public AStarElement(PElementname _elementname_, PElementid _elementid_, TStar _star_)
            : base(_elementname_, _elementid_)
        {
            this.Star = _star_;
        }
        
        public TStar Star
        {
            get { return _star_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Star in AStarElement cannot be null.", "value");
                
                if (_star_ != null)
                    SetParent(_star_, null);
                SetParent(value, this);
                
                _star_ = value;
            }
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
                    throw new ArgumentException("Elementid in AStarElement cannot be null.", "newChild");
                if (!(newChild is PElementid) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Elementid = newChild as PElementid;
            }
            else if (Star == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Star in AStarElement cannot be null.", "newChild");
                if (!(newChild is TStar) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Star = newChild as TStar;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasElementname)
                yield return Elementname;
            yield return Elementid;
            yield return Star;
        }
        
        public override PElement Clone()
        {
            return new AStarElement(Elementname.Clone(), Elementid.Clone(), Star.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Elementname, Elementid, Star);
        }
    }
    public partial class AQuestionElement : PElement
    {
        private TQMark _q_mark_;
        
        public AQuestionElement(PElementname _elementname_, PElementid _elementid_, TQMark _q_mark_)
            : base(_elementname_, _elementid_)
        {
            this.QMark = _q_mark_;
        }
        
        public TQMark QMark
        {
            get { return _q_mark_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("QMark in AQuestionElement cannot be null.", "value");
                
                if (_q_mark_ != null)
                    SetParent(_q_mark_, null);
                SetParent(value, this);
                
                _q_mark_ = value;
            }
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
                    throw new ArgumentException("Elementid in AQuestionElement cannot be null.", "newChild");
                if (!(newChild is PElementid) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Elementid = newChild as PElementid;
            }
            else if (QMark == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("QMark in AQuestionElement cannot be null.", "newChild");
                if (!(newChild is TQMark) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                QMark = newChild as TQMark;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasElementname)
                yield return Elementname;
            yield return Elementid;
            yield return QMark;
        }
        
        public override PElement Clone()
        {
            return new AQuestionElement(Elementname.Clone(), Elementid.Clone(), QMark.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Elementname, Elementid, QMark);
        }
    }
    public partial class APlusElement : PElement
    {
        private TPlus _plus_;
        
        public APlusElement(PElementname _elementname_, PElementid _elementid_, TPlus _plus_)
            : base(_elementname_, _elementid_)
        {
            this.Plus = _plus_;
        }
        
        public TPlus Plus
        {
            get { return _plus_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Plus in APlusElement cannot be null.", "value");
                
                if (_plus_ != null)
                    SetParent(_plus_, null);
                SetParent(value, this);
                
                _plus_ = value;
            }
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
                    throw new ArgumentException("Elementid in APlusElement cannot be null.", "newChild");
                if (!(newChild is PElementid) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Elementid = newChild as PElementid;
            }
            else if (Plus == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Plus in APlusElement cannot be null.", "newChild");
                if (!(newChild is TPlus) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Plus = newChild as TPlus;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasElementname)
                yield return Elementname;
            yield return Elementid;
            yield return Plus;
        }
        
        public override PElement Clone()
        {
            return new APlusElement(Elementname.Clone(), Elementid.Clone(), Plus.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Elementname, Elementid, Plus);
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
        private TTokenSpecifier _token_specifier_;
        private TDot _dot_;
        
        public ATokenElementid(TTokenSpecifier _token_specifier_, TDot _dot_, TIdentifier _identifier_)
            : base(_identifier_)
        {
            this.TokenSpecifier = _token_specifier_;
            this.Dot = _dot_;
        }
        
        public TTokenSpecifier TokenSpecifier
        {
            get { return _token_specifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("TokenSpecifier in ATokenElementid cannot be null.", "value");
                
                if (_token_specifier_ != null)
                    SetParent(_token_specifier_, null);
                SetParent(value, this);
                
                _token_specifier_ = value;
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
        private TProductionSpecifier _production_specifier_;
        private TDot _dot_;
        
        public AProductionElementid(TProductionSpecifier _production_specifier_, TDot _dot_, TIdentifier _identifier_)
            : base(_identifier_)
        {
            this.ProductionSpecifier = _production_specifier_;
            this.Dot = _dot_;
        }
        
        public TProductionSpecifier ProductionSpecifier
        {
            get { return _production_specifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("ProductionSpecifier in AProductionElementid cannot be null.", "value");
                
                if (_production_specifier_ != null)
                    SetParent(_production_specifier_, null);
                SetParent(value, this);
                
                _production_specifier_ = value;
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
    public abstract partial class PHighlightrules : Production<PHighlightrules>
    {
        private THighlighttoken _highlighttoken_;
        private NodeList<PHighlightrule> _highlightrule_;
        
        public PHighlightrules(THighlighttoken _highlighttoken_, IEnumerable<PHighlightrule> _highlightrule_)
        {
            this.Highlighttoken = _highlighttoken_;
            this._highlightrule_ = new NodeList<PHighlightrule>(this, _highlightrule_, false);
        }
        
        public THighlighttoken Highlighttoken
        {
            get { return _highlighttoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Highlighttoken in PHighlightrules cannot be null.", "value");
                
                if (_highlighttoken_ != null)
                    SetParent(_highlighttoken_, null);
                SetParent(value, this);
                
                _highlighttoken_ = value;
            }
        }
        public NodeList<PHighlightrule> Highlightrule
        {
            get { return _highlightrule_; }
        }
        
    }
    public partial class AHighlightrules : PHighlightrules
    {
        public AHighlightrules(THighlighttoken _highlighttoken_, IEnumerable<PHighlightrule> _highlightrule_)
            : base(_highlighttoken_, _highlightrule_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Highlighttoken == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Highlighttoken in AHighlightrules cannot be null.", "newChild");
                if (!(newChild is THighlighttoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Highlighttoken = newChild as THighlighttoken;
            }
            else if (oldChild is PHighlightrule && Highlightrule.Contains(oldChild as PHighlightrule))
            {
                if (!(newChild is PHighlightrule) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Highlightrule.IndexOf(oldChild as PHighlightrule);
                if (newChild == null)
                    Highlightrule.RemoveAt(index);
                else
                    Highlightrule[index] = newChild as PHighlightrule;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return Highlighttoken;
            {
                PHighlightrule[] temp = new PHighlightrule[Highlightrule.Count];
                Highlightrule.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PHighlightrules Clone()
        {
            return new AHighlightrules(Highlighttoken.Clone(), Highlightrule);
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1}", Highlighttoken, Highlightrule);
        }
    }
    public abstract partial class PHighlightrule : Production<PHighlightrule>
    {
        private TIdentifier _name_;
        private TLBrace _lpar_;
        private NodeList<PIdentifierListitem> _tokens_;
        private TRBrace _rpar_;
        private NodeList<PStyleListitem> _styles_;
        private TSemicolon _semicolon_;
        
        public PHighlightrule(TIdentifier _name_, TLBrace _lpar_, IEnumerable<PIdentifierListitem> _tokens_, TRBrace _rpar_, IEnumerable<PStyleListitem> _styles_, TSemicolon _semicolon_)
        {
            this.Name = _name_;
            this.Lpar = _lpar_;
            this._tokens_ = new NodeList<PIdentifierListitem>(this, _tokens_, false);
            this.Rpar = _rpar_;
            this._styles_ = new NodeList<PStyleListitem>(this, _styles_, false);
            this.Semicolon = _semicolon_;
        }
        
        public TIdentifier Name
        {
            get { return _name_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Name in PHighlightrule cannot be null.", "value");
                
                if (_name_ != null)
                    SetParent(_name_, null);
                SetParent(value, this);
                
                _name_ = value;
            }
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
        public NodeList<PIdentifierListitem> Tokens
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
        public NodeList<PStyleListitem> Styles
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
        public AHighlightrule(TIdentifier _name_, TLBrace _lpar_, IEnumerable<PIdentifierListitem> _tokens_, TRBrace _rpar_, IEnumerable<PStyleListitem> _styles_, TSemicolon _semicolon_)
            : base(_name_, _lpar_, _tokens_, _rpar_, _styles_, _semicolon_)
        {
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Name == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Name in AHighlightrule cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Name = newChild as TIdentifier;
            }
            else if (Lpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Lpar in AHighlightrule cannot be null.", "newChild");
                if (!(newChild is TLBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Lpar = newChild as TLBrace;
            }
            else if (oldChild is PIdentifierListitem && Tokens.Contains(oldChild as PIdentifierListitem))
            {
                if (!(newChild is PIdentifierListitem) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Tokens.IndexOf(oldChild as PIdentifierListitem);
                if (newChild == null)
                    Tokens.RemoveAt(index);
                else
                    Tokens[index] = newChild as PIdentifierListitem;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in AHighlightrule cannot be null.", "newChild");
                if (!(newChild is TRBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBrace;
            }
            else if (oldChild is PStyleListitem && Styles.Contains(oldChild as PStyleListitem))
            {
                if (!(newChild is PStyleListitem) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = Styles.IndexOf(oldChild as PStyleListitem);
                if (newChild == null)
                    Styles.RemoveAt(index);
                else
                    Styles[index] = newChild as PStyleListitem;
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
            yield return Name;
            yield return Lpar;
            {
                PIdentifierListitem[] temp = new PIdentifierListitem[Tokens.Count];
                Tokens.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Rpar;
            {
                PStyleListitem[] temp = new PStyleListitem[Styles.Count];
                Styles.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return Semicolon;
        }
        
        public override PHighlightrule Clone()
        {
            return new AHighlightrule(Name.Clone(), Lpar.Clone(), Tokens, Rpar.Clone(), Styles, Semicolon.Clone());
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", Name, Lpar, Tokens, Rpar, Styles, Semicolon);
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
        private TLPar _l_par_;
        private TDecChar _red_;
        private TComma _comma1_;
        private TDecChar _green_;
        private TComma _comma2_;
        private TDecChar _blue_;
        private TRPar _r_par_;
        
        public ARgbColor(TRgb _rgb_, TLPar _l_par_, TDecChar _red_, TComma _comma1_, TDecChar _green_, TComma _comma2_, TDecChar _blue_, TRPar _r_par_)
            : base()
        {
            this.Rgb = _rgb_;
            this.LPar = _l_par_;
            this.Red = _red_;
            this.Comma1 = _comma1_;
            this.Green = _green_;
            this.Comma2 = _comma2_;
            this.Blue = _blue_;
            this.RPar = _r_par_;
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
            get { return _l_par_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("LPar in ARgbColor cannot be null.", "value");
                
                if (_l_par_ != null)
                    SetParent(_l_par_, null);
                SetParent(value, this);
                
                _l_par_ = value;
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
            get { return _r_par_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("RPar in ARgbColor cannot be null.", "value");
                
                if (_r_par_ != null)
                    SetParent(_r_par_, null);
                SetParent(value, this);
                
                _r_par_ = value;
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
        private TLPar _l_par_;
        private TDecChar _hue_;
        private TComma _comma1_;
        private TDecChar _saturation_;
        private TComma _comma2_;
        private TDecChar _brightness_;
        private TRPar _r_par_;
        
        public AHsvColor(THsv _hsv_, TLPar _l_par_, TDecChar _hue_, TComma _comma1_, TDecChar _saturation_, TComma _comma2_, TDecChar _brightness_, TRPar _r_par_)
            : base()
        {
            this.Hsv = _hsv_;
            this.LPar = _l_par_;
            this.Hue = _hue_;
            this.Comma1 = _comma1_;
            this.Saturation = _saturation_;
            this.Comma2 = _comma2_;
            this.Brightness = _brightness_;
            this.RPar = _r_par_;
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
            get { return _l_par_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("LPar in AHsvColor cannot be null.", "value");
                
                if (_l_par_ != null)
                    SetParent(_l_par_, null);
                SetParent(value, this);
                
                _l_par_ = value;
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
            get { return _r_par_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("RPar in AHsvColor cannot be null.", "value");
                
                if (_r_par_ != null)
                    SetParent(_r_par_, null);
                SetParent(value, this);
                
                _r_par_ = value;
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
