using System;
using System.Collections.Generic;
using SablePP.Tools.Nodes;
using SablePP.Compiler.Analysis;

namespace SablePP.Compiler.Nodes
{
    public abstract partial class PGrammar : Production<PGrammar>
    {
    }
    public partial class AGrammar : PGrammar
    {
        private PPackage _package_;
        private PHelpers _helpers_;
        private PStates _states_;
        private PTokens _tokens_;
        private PIgnoredtokens _ignoredtokens_;
        private PProductions _productions_;
        private PAstproductions _astproductions_;
        
        public AGrammar(PPackage _package_, PHelpers _helpers_, PStates _states_, PTokens _tokens_, PIgnoredtokens _ignoredtokens_, PProductions _productions_, PAstproductions _astproductions_)
        {
            this.Package = _package_;
            this.Helpers = _helpers_;
            this.States = _states_;
            this.Tokens = _tokens_;
            this.Ignoredtokens = _ignoredtokens_;
            this.Productions = _productions_;
            this.Astproductions = _astproductions_;
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
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasPackage)
                yield return _package_;
            if (HasHelpers)
                yield return _helpers_;
            if (HasStates)
                yield return _states_;
            if (HasTokens)
                yield return _tokens_;
            if (HasIgnoredtokens)
                yield return _ignoredtokens_;
            if (HasProductions)
                yield return _productions_;
            if (HasAstproductions)
                yield return _astproductions_;
        }
        
        public override PGrammar Clone()
        {
            return new AGrammar(_package_.Clone(), _helpers_.Clone(), _states_.Clone(), _tokens_.Clone(), _ignoredtokens_.Clone(), _productions_.Clone(), _astproductions_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6}", _package_, _helpers_, _states_, _tokens_, _ignoredtokens_, _productions_, _astproductions_);
        }
    }
    public abstract partial class PPackage : Production<PPackage>
    {
    }
    public partial class APackage : PPackage
    {
        private TPackagetoken _packagetoken_;
        private TPackagename _packagename_;
        private TSemicolon _semicolon_;
        
        public APackage(TPackagetoken _packagetoken_, TPackagename _packagename_, TSemicolon _semicolon_)
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
                    throw new ArgumentException("Packagetoken in APackage cannot be null.", "value");
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
                    throw new ArgumentException("Packagename in APackage cannot be null.", "value");
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
                    throw new ArgumentException("Semicolon in APackage cannot be null.", "value");
                SetParent(value, this);
                
                _semicolon_ = value;
            }
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
            yield return _packagetoken_;
            yield return _packagename_;
            yield return _semicolon_;
        }
        
        public override PPackage Clone()
        {
            return new APackage(_packagetoken_.Clone(), _packagename_.Clone(), _semicolon_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _packagetoken_, _packagename_, _semicolon_);
        }
    }
    public abstract partial class PHelpers : Production<PHelpers>
    {
    }
    public partial class AHelpers : PHelpers
    {
        private THelperstoken _helperstoken_;
        private NodeList<PHelper> _helpers_;
        
        public AHelpers(THelperstoken _helperstoken_, IEnumerable<PHelper> _helpers_)
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
                    throw new ArgumentException("Helperstoken in AHelpers cannot be null.", "value");
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
                    throw new ArgumentException("Helperstoken in AHelpers cannot be null.", "newChild");
                if (!(newChild is THelperstoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Helperstoken = newChild as THelperstoken;
            }
            else if (oldChild is PHelper && _helpers_.Contains(oldChild as PHelper))
            {
                if (!(newChild is PHelper) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = _helpers_.IndexOf(oldChild as PHelper);
                if (newChild == null)
                    _helpers_.RemoveAt(index);
                else
                    _helpers_[index] = newChild as PHelper;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return _helperstoken_;
            {
                PHelper[] temp = new PHelper[_helpers_.Count];
                _helpers_.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PHelpers Clone()
        {
            return new AHelpers(_helperstoken_.Clone(), _helpers_);
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _helperstoken_, _helpers_);
        }
    }
    public abstract partial class PHelper : Production<PHelper>
    {
    }
    public partial class AHelper : PHelper
    {
        private TIdentifier _identifier_;
        private TEqual _equal_;
        private PRegex _regex_;
        private TSemicolon _semicolon_;
        
        public AHelper(TIdentifier _identifier_, TEqual _equal_, PRegex _regex_, TSemicolon _semicolon_)
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
                    throw new ArgumentException("Identifier in AHelper cannot be null.", "value");
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
                    throw new ArgumentException("Equal in AHelper cannot be null.", "value");
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
                    throw new ArgumentException("Regex in AHelper cannot be null.", "value");
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
                    throw new ArgumentException("Semicolon in AHelper cannot be null.", "value");
                SetParent(value, this);
                
                _semicolon_ = value;
            }
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
            yield return _identifier_;
            yield return _equal_;
            yield return _regex_;
            yield return _semicolon_;
        }
        
        public override PHelper Clone()
        {
            return new AHelper(_identifier_.Clone(), _equal_.Clone(), _regex_.Clone(), _semicolon_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", _identifier_, _equal_, _regex_, _semicolon_);
        }
    }
    public abstract partial class PTokens : Production<PTokens>
    {
    }
    public partial class ATokens : PTokens
    {
        private TTokenstoken _tokenstoken_;
        private NodeList<PToken> _tokens_;
        
        public ATokens(TTokenstoken _tokenstoken_, IEnumerable<PToken> _tokens_)
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
                    throw new ArgumentException("Tokenstoken in ATokens cannot be null.", "value");
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
                    throw new ArgumentException("Tokenstoken in ATokens cannot be null.", "newChild");
                if (!(newChild is TTokenstoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Tokenstoken = newChild as TTokenstoken;
            }
            else if (oldChild is PToken && _tokens_.Contains(oldChild as PToken))
            {
                if (!(newChild is PToken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = _tokens_.IndexOf(oldChild as PToken);
                if (newChild == null)
                    _tokens_.RemoveAt(index);
                else
                    _tokens_[index] = newChild as PToken;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return _tokenstoken_;
            {
                PToken[] temp = new PToken[_tokens_.Count];
                _tokens_.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PTokens Clone()
        {
            return new ATokens(_tokenstoken_.Clone(), _tokens_);
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _tokenstoken_, _tokens_);
        }
    }
    public abstract partial class PToken : Production<PToken>
    {
    }
    public partial class AToken : PToken
    {
        private PList _statelist_;
        private TIdentifier _identifier_;
        private TEqual _equal_;
        private PRegex _regex_;
        private PTokenlookahead _tokenlookahead_;
        private TSemicolon _semicolon_;
        
        public AToken(PList _statelist_, TIdentifier _identifier_, TEqual _equal_, PRegex _regex_, PTokenlookahead _tokenlookahead_, TSemicolon _semicolon_)
        {
            this.Statelist = _statelist_;
            this.Identifier = _identifier_;
            this.Equal = _equal_;
            this.Regex = _regex_;
            this.Tokenlookahead = _tokenlookahead_;
            this.Semicolon = _semicolon_;
        }
        
        public PList Statelist
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
                    throw new ArgumentException("Identifier in AToken cannot be null.", "value");
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
                    throw new ArgumentException("Equal in AToken cannot be null.", "value");
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
                    throw new ArgumentException("Regex in AToken cannot be null.", "value");
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
                    throw new ArgumentException("Semicolon in AToken cannot be null.", "value");
                SetParent(value, this);
                
                _semicolon_ = value;
            }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Statelist == oldChild)
            {
                if (!(newChild is PList) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Statelist = newChild as PList;
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
                yield return _statelist_;
            yield return _identifier_;
            yield return _equal_;
            yield return _regex_;
            if (HasTokenlookahead)
                yield return _tokenlookahead_;
            yield return _semicolon_;
        }
        
        public override PToken Clone()
        {
            return new AToken(_statelist_.Clone(), _identifier_.Clone(), _equal_.Clone(), _regex_.Clone(), _tokenlookahead_.Clone(), _semicolon_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", _statelist_, _identifier_, _equal_, _regex_, _tokenlookahead_, _semicolon_);
        }
    }
    public abstract partial class PTokenlookahead : Production<PTokenlookahead>
    {
    }
    public partial class ATokenlookahead : PTokenlookahead
    {
        private TSlash _slash_;
        private PRegex _regex_;
        
        public ATokenlookahead(TSlash _slash_, PRegex _regex_)
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
                    throw new ArgumentException("Slash in ATokenlookahead cannot be null.", "value");
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
                    throw new ArgumentException("Regex in ATokenlookahead cannot be null.", "value");
                SetParent(value, this);
                
                _regex_ = value;
            }
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
            yield return _slash_;
            yield return _regex_;
        }
        
        public override PTokenlookahead Clone()
        {
            return new ATokenlookahead(_slash_.Clone(), _regex_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _slash_, _regex_);
        }
    }
    public abstract partial class PRegex : Production<PRegex>
    {
    }
    public partial class ARegex : PRegex
    {
        private NodeList<POrpart> _parts_;
        
        public ARegex(IEnumerable<POrpart> _parts_)
        {
            this._parts_ = new NodeList<POrpart>(this, _parts_, false);
        }
        
        public NodeList<POrpart> Parts
        {
            get { return _parts_; }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (oldChild is POrpart && _parts_.Contains(oldChild as POrpart))
            {
                if (!(newChild is POrpart) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = _parts_.IndexOf(oldChild as POrpart);
                if (newChild == null)
                    _parts_.RemoveAt(index);
                else
                    _parts_[index] = newChild as POrpart;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            {
                POrpart[] temp = new POrpart[_parts_.Count];
                _parts_.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PRegex Clone()
        {
            return new ARegex(_parts_);
        }
        public override string ToString()
        {
            return string.Format("{0}", _parts_);
        }
    }
    public abstract partial class POrpart : Production<POrpart>
    {
    }
    public partial class ARegexOrpart : POrpart
    {
        private TPipe _pipe_;
        private NodeList<PRegexpart> _regexpart_;
        
        public ARegexOrpart(TPipe _pipe_, IEnumerable<PRegexpart> _regexpart_)
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
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (Pipe == oldChild)
            {
                if (!(newChild is TPipe) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Pipe = newChild as TPipe;
            }
            else if (oldChild is PRegexpart && _regexpart_.Contains(oldChild as PRegexpart))
            {
                if (!(newChild is PRegexpart) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = _regexpart_.IndexOf(oldChild as PRegexpart);
                if (newChild == null)
                    _regexpart_.RemoveAt(index);
                else
                    _regexpart_[index] = newChild as PRegexpart;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasPipe)
                yield return _pipe_;
            {
                PRegexpart[] temp = new PRegexpart[_regexpart_.Count];
                _regexpart_.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override POrpart Clone()
        {
            return new ARegexOrpart(_pipe_.Clone(), _regexpart_);
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _pipe_, _regexpart_);
        }
    }
    public abstract partial class PRegexpart : Production<PRegexpart>
    {
    }
    public partial class ACharRegexpart : PRegexpart
    {
        private TCharacter _character_;
        
        public ACharRegexpart(TCharacter _character_)
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
            yield return _character_;
        }
        
        public override PRegexpart Clone()
        {
            return new ACharRegexpart(_character_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0}", _character_);
        }
    }
    public partial class ADecRegexpart : PRegexpart
    {
        private TDecChar _dec_char_;
        
        public ADecRegexpart(TDecChar _dec_char_)
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
            yield return _dec_char_;
        }
        
        public override PRegexpart Clone()
        {
            return new ADecRegexpart(_dec_char_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0}", _dec_char_);
        }
    }
    public partial class AHexRegexpart : PRegexpart
    {
        private THexChar _hex_char_;
        
        public AHexRegexpart(THexChar _hex_char_)
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
            yield return _hex_char_;
        }
        
        public override PRegexpart Clone()
        {
            return new AHexRegexpart(_hex_char_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0}", _hex_char_);
        }
    }
    public partial class AUnarystarRegexpart : PRegexpart
    {
        private PRegexpart _regexpart_;
        private TStar _star_;
        
        public AUnarystarRegexpart(PRegexpart _regexpart_, TStar _star_)
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
            yield return _regexpart_;
            yield return _star_;
        }
        
        public override PRegexpart Clone()
        {
            return new AUnarystarRegexpart(_regexpart_.Clone(), _star_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _regexpart_, _star_);
        }
    }
    public partial class AUnaryquestionRegexpart : PRegexpart
    {
        private PRegexpart _regexpart_;
        private TQMark _question_;
        
        public AUnaryquestionRegexpart(PRegexpart _regexpart_, TQMark _question_)
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
            yield return _regexpart_;
            yield return _question_;
        }
        
        public override PRegexpart Clone()
        {
            return new AUnaryquestionRegexpart(_regexpart_.Clone(), _question_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _regexpart_, _question_);
        }
    }
    public partial class AUnaryplusRegexpart : PRegexpart
    {
        private PRegexpart _regexpart_;
        private TPlus _plus_;
        
        public AUnaryplusRegexpart(PRegexpart _regexpart_, TPlus _plus_)
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
            yield return _regexpart_;
            yield return _plus_;
        }
        
        public override PRegexpart Clone()
        {
            return new AUnaryplusRegexpart(_regexpart_.Clone(), _plus_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _regexpart_, _plus_);
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
            yield return _lpar_;
            yield return _left_;
            yield return _plus_;
            yield return _right_;
            yield return _rpar_;
        }
        
        public override PRegexpart Clone()
        {
            return new ABinaryplusRegexpart(_lpar_.Clone(), _left_.Clone(), _plus_.Clone(), _right_.Clone(), _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", _lpar_, _left_, _plus_, _right_, _rpar_);
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
            yield return _lpar_;
            yield return _left_;
            yield return _minus_;
            yield return _right_;
            yield return _rpar_;
        }
        
        public override PRegexpart Clone()
        {
            return new ABinaryminusRegexpart(_lpar_.Clone(), _left_.Clone(), _minus_.Clone(), _right_.Clone(), _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", _lpar_, _left_, _minus_, _right_, _rpar_);
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
            yield return _lpar_;
            yield return _left_;
            yield return _dots_;
            yield return _right_;
            yield return _rpar_;
        }
        
        public override PRegexpart Clone()
        {
            return new AIntervalRegexpart(_lpar_.Clone(), _left_.Clone(), _dots_.Clone(), _right_.Clone(), _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", _lpar_, _left_, _dots_, _right_, _rpar_);
        }
    }
    public partial class AStringRegexpart : PRegexpart
    {
        private TString _string_;
        
        public AStringRegexpart(TString _string_)
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
            yield return _string_;
        }
        
        public override PRegexpart Clone()
        {
            return new AStringRegexpart(_string_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0}", _string_);
        }
    }
    public partial class AIdentifierRegexpart : PRegexpart
    {
        private TIdentifier _identifier_;
        
        public AIdentifierRegexpart(TIdentifier _identifier_)
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
            yield return _identifier_;
        }
        
        public override PRegexpart Clone()
        {
            return new AIdentifierRegexpart(_identifier_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0}", _identifier_);
        }
    }
    public partial class AParenthesisRegexpart : PRegexpart
    {
        private TLPar _lpar_;
        private PRegex _regex_;
        private TRPar _rpar_;
        
        public AParenthesisRegexpart(TLPar _lpar_, PRegex _regex_, TRPar _rpar_)
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
            yield return _lpar_;
            yield return _regex_;
            yield return _rpar_;
        }
        
        public override PRegexpart Clone()
        {
            return new AParenthesisRegexpart(_lpar_.Clone(), _regex_.Clone(), _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _lpar_, _regex_, _rpar_);
        }
    }
    public abstract partial class PStates : Production<PStates>
    {
    }
    public partial class AStates : PStates
    {
        private TStatestoken _statestoken_;
        private PList _list_;
        private TSemicolon _semicolon_;
        
        public AStates(TStatestoken _statestoken_, PList _list_, TSemicolon _semicolon_)
        {
            this.Statestoken = _statestoken_;
            this.List = _list_;
            this.Semicolon = _semicolon_;
        }
        
        public TStatestoken Statestoken
        {
            get { return _statestoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Statestoken in AStates cannot be null.", "value");
                SetParent(value, this);
                
                _statestoken_ = value;
            }
        }
        public PList List
        {
            get { return _list_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("List in AStates cannot be null.", "value");
                SetParent(value, this);
                
                _list_ = value;
            }
        }
        public TSemicolon Semicolon
        {
            get { return _semicolon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Semicolon in AStates cannot be null.", "value");
                SetParent(value, this);
                
                _semicolon_ = value;
            }
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
            else if (List == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("List in AStates cannot be null.", "newChild");
                if (!(newChild is PList) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                List = newChild as PList;
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
            yield return _statestoken_;
            yield return _list_;
            yield return _semicolon_;
        }
        
        public override PStates Clone()
        {
            return new AStates(_statestoken_.Clone(), _list_.Clone(), _semicolon_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _statestoken_, _list_, _semicolon_);
        }
    }
    public abstract partial class PIgnoredtokens : Production<PIgnoredtokens>
    {
    }
    public partial class AIgnoredtokens : PIgnoredtokens
    {
        private TIgnoredtoken _ignoredtoken_;
        private TTokenstoken _tokenstoken_;
        private PList _list_;
        private TSemicolon _semicolon_;
        
        public AIgnoredtokens(TIgnoredtoken _ignoredtoken_, TTokenstoken _tokenstoken_, PList _list_, TSemicolon _semicolon_)
        {
            this.Ignoredtoken = _ignoredtoken_;
            this.Tokenstoken = _tokenstoken_;
            this.List = _list_;
            this.Semicolon = _semicolon_;
        }
        
        public TIgnoredtoken Ignoredtoken
        {
            get { return _ignoredtoken_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Ignoredtoken in AIgnoredtokens cannot be null.", "value");
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
                    throw new ArgumentException("Tokenstoken in AIgnoredtokens cannot be null.", "value");
                SetParent(value, this);
                
                _tokenstoken_ = value;
            }
        }
        public PList List
        {
            get { return _list_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("List in AIgnoredtokens cannot be null.", "value");
                SetParent(value, this);
                
                _list_ = value;
            }
        }
        public TSemicolon Semicolon
        {
            get { return _semicolon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Semicolon in AIgnoredtokens cannot be null.", "value");
                SetParent(value, this);
                
                _semicolon_ = value;
            }
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
            else if (List == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("List in AIgnoredtokens cannot be null.", "newChild");
                if (!(newChild is PList) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                List = newChild as PList;
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
            yield return _ignoredtoken_;
            yield return _tokenstoken_;
            yield return _list_;
            yield return _semicolon_;
        }
        
        public override PIgnoredtokens Clone()
        {
            return new AIgnoredtokens(_ignoredtoken_.Clone(), _tokenstoken_.Clone(), _list_.Clone(), _semicolon_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", _ignoredtoken_, _tokenstoken_, _list_, _semicolon_);
        }
    }
    public abstract partial class PList : Production<PList>
    {
    }
    public partial class AIdentifierList : PList
    {
        private NodeList<PListitem> _listitem_;
        
        public AIdentifierList(IEnumerable<PListitem> _listitem_)
        {
            this._listitem_ = new NodeList<PListitem>(this, _listitem_, false);
        }
        
        public NodeList<PListitem> Listitem
        {
            get { return _listitem_; }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (oldChild is PListitem && _listitem_.Contains(oldChild as PListitem))
            {
                if (!(newChild is PListitem) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = _listitem_.IndexOf(oldChild as PListitem);
                if (newChild == null)
                    _listitem_.RemoveAt(index);
                else
                    _listitem_[index] = newChild as PListitem;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            {
                PListitem[] temp = new PListitem[_listitem_.Count];
                _listitem_.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PList Clone()
        {
            return new AIdentifierList(_listitem_);
        }
        public override string ToString()
        {
            return string.Format("{0}", _listitem_);
        }
    }
    public partial class ATokenstateList : PList
    {
        private TLBrace _lpar_;
        private NodeList<PListitem> _listitem_;
        private TRBrace _rpar_;
        
        public ATokenstateList(TLBrace _lpar_, IEnumerable<PListitem> _listitem_, TRBrace _rpar_)
        {
            this.Lpar = _lpar_;
            this._listitem_ = new NodeList<PListitem>(this, _listitem_, false);
            this.Rpar = _rpar_;
        }
        
        public TLBrace Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in ATokenstateList cannot be null.", "value");
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public NodeList<PListitem> Listitem
        {
            get { return _listitem_; }
        }
        public TRBrace Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in ATokenstateList cannot be null.", "value");
                SetParent(value, this);
                
                _rpar_ = value;
            }
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
            else if (oldChild is PListitem && _listitem_.Contains(oldChild as PListitem))
            {
                if (!(newChild is PListitem) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = _listitem_.IndexOf(oldChild as PListitem);
                if (newChild == null)
                    _listitem_.RemoveAt(index);
                else
                    _listitem_[index] = newChild as PListitem;
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
            yield return _lpar_;
            {
                PListitem[] temp = new PListitem[_listitem_.Count];
                _listitem_.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
            yield return _rpar_;
        }
        
        public override PList Clone()
        {
            return new ATokenstateList(_lpar_.Clone(), _listitem_, _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _lpar_, _listitem_, _rpar_);
        }
    }
    public partial class ATranslationList : PList
    {
        private NodeList<PListitem> _listitem_;
        
        public ATranslationList(IEnumerable<PListitem> _listitem_)
        {
            this._listitem_ = new NodeList<PListitem>(this, _listitem_, false);
        }
        
        public NodeList<PListitem> Listitem
        {
            get { return _listitem_; }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (oldChild is PListitem && _listitem_.Contains(oldChild as PListitem))
            {
                if (!(newChild is PListitem) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = _listitem_.IndexOf(oldChild as PListitem);
                if (newChild == null)
                    _listitem_.RemoveAt(index);
                else
                    _listitem_[index] = newChild as PListitem;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            {
                PListitem[] temp = new PListitem[_listitem_.Count];
                _listitem_.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PList Clone()
        {
            return new ATranslationList(_listitem_);
        }
        public override string ToString()
        {
            return string.Format("{0}", _listitem_);
        }
    }
    public partial class AStyleList : PList
    {
        private NodeList<PListitem> _listitem_;
        
        public AStyleList(IEnumerable<PListitem> _listitem_)
        {
            this._listitem_ = new NodeList<PListitem>(this, _listitem_, false);
        }
        
        public NodeList<PListitem> Listitem
        {
            get { return _listitem_; }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (oldChild is PListitem && _listitem_.Contains(oldChild as PListitem))
            {
                if (!(newChild is PListitem) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = _listitem_.IndexOf(oldChild as PListitem);
                if (newChild == null)
                    _listitem_.RemoveAt(index);
                else
                    _listitem_[index] = newChild as PListitem;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            {
                PListitem[] temp = new PListitem[_listitem_.Count];
                _listitem_.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PList Clone()
        {
            return new AStyleList(_listitem_);
        }
        public override string ToString()
        {
            return string.Format("{0}", _listitem_);
        }
    }
    public abstract partial class PListitem : Production<PListitem>
    {
    }
    public partial class AIdentifierListitem : PListitem
    {
        private TComma _comma_;
        private TIdentifier _identifier_;
        
        public AIdentifierListitem(TComma _comma_, TIdentifier _identifier_)
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
                    throw new ArgumentException("Identifier in AIdentifierListitem cannot be null.", "value");
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
                yield return _comma_;
            yield return _identifier_;
        }
        
        public override PListitem Clone()
        {
            return new AIdentifierListitem(_comma_.Clone(), _identifier_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _comma_, _identifier_);
        }
    }
    public partial class ATokenstateListitem : PListitem
    {
        private TComma _comma_;
        private TIdentifier _identifier_;
        
        public ATokenstateListitem(TComma _comma_, TIdentifier _identifier_)
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
                    throw new ArgumentException("Identifier in ATokenstateListitem cannot be null.", "value");
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
                yield return _comma_;
            yield return _identifier_;
        }
        
        public override PListitem Clone()
        {
            return new ATokenstateListitem(_comma_.Clone(), _identifier_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _comma_, _identifier_);
        }
    }
    public partial class ATokenstatetransitionListitem : PListitem
    {
        private TComma _comma_;
        private TIdentifier _from_;
        private TArrow _arrow_;
        private TIdentifier _to_;
        
        public ATokenstatetransitionListitem(TComma _comma_, TIdentifier _from_, TArrow _arrow_, TIdentifier _to_)
        {
            this.Comma = _comma_;
            this.From = _from_;
            this.Arrow = _arrow_;
            this.To = _to_;
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
        public TIdentifier From
        {
            get { return _from_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("From in ATokenstatetransitionListitem cannot be null.", "value");
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
                    throw new ArgumentException("Arrow in ATokenstatetransitionListitem cannot be null.", "value");
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
                    throw new ArgumentException("To in ATokenstatetransitionListitem cannot be null.", "value");
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
                    throw new ArgumentException("From in ATokenstatetransitionListitem cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                From = newChild as TIdentifier;
            }
            else if (Arrow == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Arrow in ATokenstatetransitionListitem cannot be null.", "newChild");
                if (!(newChild is TArrow) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Arrow = newChild as TArrow;
            }
            else if (To == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("To in ATokenstatetransitionListitem cannot be null.", "newChild");
                if (!(newChild is TIdentifier) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                To = newChild as TIdentifier;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            if (HasComma)
                yield return _comma_;
            yield return _from_;
            yield return _arrow_;
            yield return _to_;
        }
        
        public override PListitem Clone()
        {
            return new ATokenstatetransitionListitem(_comma_.Clone(), _from_.Clone(), _arrow_.Clone(), _to_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", _comma_, _from_, _arrow_, _to_);
        }
    }
    public partial class ATranslationListitem : PListitem
    {
        private TComma _comma_;
        private PTranslation _translation_;
        
        public ATranslationListitem(TComma _comma_, PTranslation _translation_)
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
                    throw new ArgumentException("Translation in ATranslationListitem cannot be null.", "value");
                SetParent(value, this);
                
                _translation_ = value;
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
                yield return _comma_;
            yield return _translation_;
        }
        
        public override PListitem Clone()
        {
            return new ATranslationListitem(_comma_.Clone(), _translation_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _comma_, _translation_);
        }
    }
    public partial class AStyleListitem : PListitem
    {
        private TComma _comma_;
        private PHighlightStyle _highlight_style_;
        
        public AStyleListitem(TComma _comma_, PHighlightStyle _highlight_style_)
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
                    throw new ArgumentException("HighlightStyle in AStyleListitem cannot be null.", "value");
                SetParent(value, this);
                
                _highlight_style_ = value;
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
                yield return _comma_;
            yield return _highlight_style_;
        }
        
        public override PListitem Clone()
        {
            return new AStyleListitem(_comma_.Clone(), _highlight_style_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _comma_, _highlight_style_);
        }
    }
    public abstract partial class PProductions : Production<PProductions>
    {
    }
    public partial class AProductions : PProductions
    {
        private TProductionstoken _productionstoken_;
        private NodeList<PProduction> _productions_;
        
        public AProductions(TProductionstoken _productionstoken_, IEnumerable<PProduction> _productions_)
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
                    throw new ArgumentException("Productionstoken in AProductions cannot be null.", "value");
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
                    throw new ArgumentException("Productionstoken in AProductions cannot be null.", "newChild");
                if (!(newChild is TProductionstoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Productionstoken = newChild as TProductionstoken;
            }
            else if (oldChild is PProduction && _productions_.Contains(oldChild as PProduction))
            {
                if (!(newChild is PProduction) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = _productions_.IndexOf(oldChild as PProduction);
                if (newChild == null)
                    _productions_.RemoveAt(index);
                else
                    _productions_[index] = newChild as PProduction;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return _productionstoken_;
            {
                PProduction[] temp = new PProduction[_productions_.Count];
                _productions_.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PProductions Clone()
        {
            return new AProductions(_productionstoken_.Clone(), _productions_);
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _productionstoken_, _productions_);
        }
    }
    public abstract partial class PAstproductions : Production<PAstproductions>
    {
    }
    public partial class AAstproductions : PAstproductions
    {
        private TAsttoken _asttoken_;
        private NodeList<PProduction> _productions_;
        
        public AAstproductions(TAsttoken _asttoken_, IEnumerable<PProduction> _productions_)
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
                    throw new ArgumentException("Asttoken in AAstproductions cannot be null.", "value");
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
                    throw new ArgumentException("Asttoken in AAstproductions cannot be null.", "newChild");
                if (!(newChild is TAsttoken) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Asttoken = newChild as TAsttoken;
            }
            else if (oldChild is PProduction && _productions_.Contains(oldChild as PProduction))
            {
                if (!(newChild is PProduction) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = _productions_.IndexOf(oldChild as PProduction);
                if (newChild == null)
                    _productions_.RemoveAt(index);
                else
                    _productions_[index] = newChild as PProduction;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return _asttoken_;
            {
                PProduction[] temp = new PProduction[_productions_.Count];
                _productions_.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PAstproductions Clone()
        {
            return new AAstproductions(_asttoken_.Clone(), _productions_);
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _asttoken_, _productions_);
        }
    }
    public abstract partial class PProduction : Production<PProduction>
    {
    }
    public partial class AProduction : PProduction
    {
        private TIdentifier _identifier_;
        private PProdtranslation _prodtranslation_;
        private TEqual _equal_;
        private PProductionrule _productionrule_;
        private TSemicolon _semicolon_;
        
        public AProduction(TIdentifier _identifier_, PProdtranslation _prodtranslation_, TEqual _equal_, PProductionrule _productionrule_, TSemicolon _semicolon_)
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
                    throw new ArgumentException("Identifier in AProduction cannot be null.", "value");
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
                    throw new ArgumentException("Equal in AProduction cannot be null.", "value");
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
                    throw new ArgumentException("Productionrule in AProduction cannot be null.", "value");
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
                    throw new ArgumentException("Semicolon in AProduction cannot be null.", "value");
                SetParent(value, this);
                
                _semicolon_ = value;
            }
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
            yield return _identifier_;
            if (HasProdtranslation)
                yield return _prodtranslation_;
            yield return _equal_;
            yield return _productionrule_;
            yield return _semicolon_;
        }
        
        public override PProduction Clone()
        {
            return new AProduction(_identifier_.Clone(), _prodtranslation_.Clone(), _equal_.Clone(), _productionrule_.Clone(), _semicolon_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", _identifier_, _prodtranslation_, _equal_, _productionrule_, _semicolon_);
        }
    }
    public abstract partial class PProdtranslation : Production<PProdtranslation>
    {
    }
    public partial class ACleanProdtranslation : PProdtranslation
    {
        private TLBrace _lpar_;
        private TArrow _arrow_;
        private TIdentifier _identifier_;
        private TRBrace _rpar_;
        
        public ACleanProdtranslation(TLBrace _lpar_, TArrow _arrow_, TIdentifier _identifier_, TRBrace _rpar_)
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
                    throw new ArgumentException("Lpar in ACleanProdtranslation cannot be null.", "value");
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
                    throw new ArgumentException("Arrow in ACleanProdtranslation cannot be null.", "value");
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
                    throw new ArgumentException("Identifier in ACleanProdtranslation cannot be null.", "value");
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
                    throw new ArgumentException("Rpar in ACleanProdtranslation cannot be null.", "value");
                SetParent(value, this);
                
                _rpar_ = value;
            }
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
            yield return _lpar_;
            yield return _arrow_;
            yield return _identifier_;
            yield return _rpar_;
        }
        
        public override PProdtranslation Clone()
        {
            return new ACleanProdtranslation(_lpar_.Clone(), _arrow_.Clone(), _identifier_.Clone(), _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", _lpar_, _arrow_, _identifier_, _rpar_);
        }
    }
    public partial class AStarProdtranslation : PProdtranslation
    {
        private TLBrace _lpar_;
        private TArrow _arrow_;
        private TIdentifier _identifier_;
        private TStar _star_;
        private TRBrace _rpar_;
        
        public AStarProdtranslation(TLBrace _lpar_, TArrow _arrow_, TIdentifier _identifier_, TStar _star_, TRBrace _rpar_)
        {
            this.Lpar = _lpar_;
            this.Arrow = _arrow_;
            this.Identifier = _identifier_;
            this.Star = _star_;
            this.Rpar = _rpar_;
        }
        
        public TLBrace Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in AStarProdtranslation cannot be null.", "value");
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
                    throw new ArgumentException("Arrow in AStarProdtranslation cannot be null.", "value");
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
                    throw new ArgumentException("Identifier in AStarProdtranslation cannot be null.", "value");
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        public TStar Star
        {
            get { return _star_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Star in AStarProdtranslation cannot be null.", "value");
                SetParent(value, this);
                
                _star_ = value;
            }
        }
        public TRBrace Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in AStarProdtranslation cannot be null.", "value");
                SetParent(value, this);
                
                _rpar_ = value;
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
            yield return _lpar_;
            yield return _arrow_;
            yield return _identifier_;
            yield return _star_;
            yield return _rpar_;
        }
        
        public override PProdtranslation Clone()
        {
            return new AStarProdtranslation(_lpar_.Clone(), _arrow_.Clone(), _identifier_.Clone(), _star_.Clone(), _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", _lpar_, _arrow_, _identifier_, _star_, _rpar_);
        }
    }
    public partial class APlusProdtranslation : PProdtranslation
    {
        private TLBrace _lpar_;
        private TArrow _arrow_;
        private TIdentifier _identifier_;
        private TPlus _plus_;
        private TRBrace _rpar_;
        
        public APlusProdtranslation(TLBrace _lpar_, TArrow _arrow_, TIdentifier _identifier_, TPlus _plus_, TRBrace _rpar_)
        {
            this.Lpar = _lpar_;
            this.Arrow = _arrow_;
            this.Identifier = _identifier_;
            this.Plus = _plus_;
            this.Rpar = _rpar_;
        }
        
        public TLBrace Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in APlusProdtranslation cannot be null.", "value");
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
                    throw new ArgumentException("Arrow in APlusProdtranslation cannot be null.", "value");
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
                    throw new ArgumentException("Identifier in APlusProdtranslation cannot be null.", "value");
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        public TPlus Plus
        {
            get { return _plus_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Plus in APlusProdtranslation cannot be null.", "value");
                SetParent(value, this);
                
                _plus_ = value;
            }
        }
        public TRBrace Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in APlusProdtranslation cannot be null.", "value");
                SetParent(value, this);
                
                _rpar_ = value;
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
            yield return _lpar_;
            yield return _arrow_;
            yield return _identifier_;
            yield return _plus_;
            yield return _rpar_;
        }
        
        public override PProdtranslation Clone()
        {
            return new APlusProdtranslation(_lpar_.Clone(), _arrow_.Clone(), _identifier_.Clone(), _plus_.Clone(), _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", _lpar_, _arrow_, _identifier_, _plus_, _rpar_);
        }
    }
    public partial class AQuestionProdtranslation : PProdtranslation
    {
        private TLBrace _lpar_;
        private TArrow _arrow_;
        private TIdentifier _identifier_;
        private TQMark _q_mark_;
        private TRBrace _rpar_;
        
        public AQuestionProdtranslation(TLBrace _lpar_, TArrow _arrow_, TIdentifier _identifier_, TQMark _q_mark_, TRBrace _rpar_)
        {
            this.Lpar = _lpar_;
            this.Arrow = _arrow_;
            this.Identifier = _identifier_;
            this.QMark = _q_mark_;
            this.Rpar = _rpar_;
        }
        
        public TLBrace Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in AQuestionProdtranslation cannot be null.", "value");
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
                    throw new ArgumentException("Arrow in AQuestionProdtranslation cannot be null.", "value");
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
                    throw new ArgumentException("Identifier in AQuestionProdtranslation cannot be null.", "value");
                SetParent(value, this);
                
                _identifier_ = value;
            }
        }
        public TQMark QMark
        {
            get { return _q_mark_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("QMark in AQuestionProdtranslation cannot be null.", "value");
                SetParent(value, this);
                
                _q_mark_ = value;
            }
        }
        public TRBrace Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in AQuestionProdtranslation cannot be null.", "value");
                SetParent(value, this);
                
                _rpar_ = value;
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
            yield return _lpar_;
            yield return _arrow_;
            yield return _identifier_;
            yield return _q_mark_;
            yield return _rpar_;
        }
        
        public override PProdtranslation Clone()
        {
            return new AQuestionProdtranslation(_lpar_.Clone(), _arrow_.Clone(), _identifier_.Clone(), _q_mark_.Clone(), _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", _lpar_, _arrow_, _identifier_, _q_mark_, _rpar_);
        }
    }
    public abstract partial class PTranslation : Production<PTranslation>
    {
    }
    public partial class AFullTranslation : PTranslation
    {
        private TLBrace _lpar_;
        private TArrow _arrow_;
        private PTranslation _translation_;
        private TRBrace _rpar_;
        
        public AFullTranslation(TLBrace _lpar_, TArrow _arrow_, PTranslation _translation_, TRBrace _rpar_)
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
            yield return _lpar_;
            yield return _arrow_;
            yield return _translation_;
            yield return _rpar_;
        }
        
        public override PTranslation Clone()
        {
            return new AFullTranslation(_lpar_.Clone(), _arrow_.Clone(), _translation_.Clone(), _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", _lpar_, _arrow_, _translation_, _rpar_);
        }
    }
    public partial class ANewTranslation : PTranslation
    {
        private TNew _new_;
        private TIdentifier _production_;
        private TLPar _lpar_;
        private PList _arguments_;
        private TRPar _rpar_;
        
        public ANewTranslation(TNew _new_, TIdentifier _production_, TLPar _lpar_, PList _arguments_, TRPar _rpar_)
        {
            this.New = _new_;
            this.Production = _production_;
            this.Lpar = _lpar_;
            this.Arguments = _arguments_;
            this.Rpar = _rpar_;
        }
        
        public TNew New
        {
            get { return _new_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("New in ANewTranslation cannot be null.", "value");
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
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public PList Arguments
        {
            get { return _arguments_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Arguments in ANewTranslation cannot be null.", "value");
                SetParent(value, this);
                
                _arguments_ = value;
            }
        }
        public TRPar Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in ANewTranslation cannot be null.", "value");
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
            else if (Arguments == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Arguments in ANewTranslation cannot be null.", "newChild");
                if (!(newChild is PList) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Arguments = newChild as PList;
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
            yield return _new_;
            yield return _production_;
            yield return _lpar_;
            yield return _arguments_;
            yield return _rpar_;
        }
        
        public override PTranslation Clone()
        {
            return new ANewTranslation(_new_.Clone(), _production_.Clone(), _lpar_.Clone(), _arguments_.Clone(), _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", _new_, _production_, _lpar_, _arguments_, _rpar_);
        }
    }
    public partial class ANewalternativeTranslation : PTranslation
    {
        private TNew _new_;
        private TIdentifier _production_;
        private TDot _dot_;
        private TIdentifier _alternative_;
        private TLPar _lpar_;
        private PList _arguments_;
        private TRPar _rpar_;
        
        public ANewalternativeTranslation(TNew _new_, TIdentifier _production_, TDot _dot_, TIdentifier _alternative_, TLPar _lpar_, PList _arguments_, TRPar _rpar_)
        {
            this.New = _new_;
            this.Production = _production_;
            this.Dot = _dot_;
            this.Alternative = _alternative_;
            this.Lpar = _lpar_;
            this.Arguments = _arguments_;
            this.Rpar = _rpar_;
        }
        
        public TNew New
        {
            get { return _new_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("New in ANewalternativeTranslation cannot be null.", "value");
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
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public PList Arguments
        {
            get { return _arguments_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Arguments in ANewalternativeTranslation cannot be null.", "value");
                SetParent(value, this);
                
                _arguments_ = value;
            }
        }
        public TRPar Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in ANewalternativeTranslation cannot be null.", "value");
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
            else if (Arguments == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Arguments in ANewalternativeTranslation cannot be null.", "newChild");
                if (!(newChild is PList) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Arguments = newChild as PList;
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
            yield return _new_;
            yield return _production_;
            yield return _dot_;
            yield return _alternative_;
            yield return _lpar_;
            yield return _arguments_;
            yield return _rpar_;
        }
        
        public override PTranslation Clone()
        {
            return new ANewalternativeTranslation(_new_.Clone(), _production_.Clone(), _dot_.Clone(), _alternative_.Clone(), _lpar_.Clone(), _arguments_.Clone(), _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6}", _new_, _production_, _dot_, _alternative_, _lpar_, _arguments_, _rpar_);
        }
    }
    public partial class AListTranslation : PTranslation
    {
        private TLBkt _lpar_;
        private PList _elements_;
        private TRBkt _rpar_;
        
        public AListTranslation(TLBkt _lpar_, PList _elements_, TRBkt _rpar_)
        {
            this.Lpar = _lpar_;
            this.Elements = _elements_;
            this.Rpar = _rpar_;
        }
        
        public TLBkt Lpar
        {
            get { return _lpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Lpar in AListTranslation cannot be null.", "value");
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public PList Elements
        {
            get { return _elements_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Elements in AListTranslation cannot be null.", "value");
                SetParent(value, this);
                
                _elements_ = value;
            }
        }
        public TRBkt Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in AListTranslation cannot be null.", "value");
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
            else if (Elements == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Elements in AListTranslation cannot be null.", "newChild");
                if (!(newChild is PList) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Elements = newChild as PList;
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
            yield return _lpar_;
            yield return _elements_;
            yield return _rpar_;
        }
        
        public override PTranslation Clone()
        {
            return new AListTranslation(_lpar_.Clone(), _elements_.Clone(), _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _lpar_, _elements_, _rpar_);
        }
    }
    public partial class ANullTranslation : PTranslation
    {
        private TNull _null_;
        
        public ANullTranslation(TNull _null_)
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
            yield return _null_;
        }
        
        public override PTranslation Clone()
        {
            return new ANullTranslation(_null_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0}", _null_);
        }
    }
    public partial class AIdTranslation : PTranslation
    {
        private TIdentifier _identifier_;
        
        public AIdTranslation(TIdentifier _identifier_)
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
            yield return _identifier_;
        }
        
        public override PTranslation Clone()
        {
            return new AIdTranslation(_identifier_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0}", _identifier_);
        }
    }
    public partial class AIddotidTranslation : PTranslation
    {
        private TIdentifier _identifier_;
        private TDot _dot_;
        private TIdentifier _production_;
        
        public AIddotidTranslation(TIdentifier _identifier_, TDot _dot_, TIdentifier _production_)
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
            yield return _identifier_;
            yield return _dot_;
            yield return _production_;
        }
        
        public override PTranslation Clone()
        {
            return new AIddotidTranslation(_identifier_.Clone(), _dot_.Clone(), _production_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _identifier_, _dot_, _production_);
        }
    }
    public abstract partial class PProductionrule : Production<PProductionrule>
    {
    }
    public partial class AProductionrule : PProductionrule
    {
        private NodeList<PAlternative> _alternatives_;
        
        public AProductionrule(IEnumerable<PAlternative> _alternatives_)
        {
            this._alternatives_ = new NodeList<PAlternative>(this, _alternatives_, false);
        }
        
        public NodeList<PAlternative> Alternatives
        {
            get { return _alternatives_; }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (oldChild is PAlternative && _alternatives_.Contains(oldChild as PAlternative))
            {
                if (!(newChild is PAlternative) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = _alternatives_.IndexOf(oldChild as PAlternative);
                if (newChild == null)
                    _alternatives_.RemoveAt(index);
                else
                    _alternatives_[index] = newChild as PAlternative;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            {
                PAlternative[] temp = new PAlternative[_alternatives_.Count];
                _alternatives_.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PProductionrule Clone()
        {
            return new AProductionrule(_alternatives_);
        }
        public override string ToString()
        {
            return string.Format("{0}", _alternatives_);
        }
    }
    public abstract partial class PAlternative : Production<PAlternative>
    {
    }
    public partial class AAlternative : PAlternative
    {
        private TPipe _pipe_;
        private PAlternativename _alternativename_;
        private PElements _elements_;
        private PTranslation _translation_;
        
        public AAlternative(TPipe _pipe_, PAlternativename _alternativename_, PElements _elements_, PTranslation _translation_)
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
                    throw new ArgumentException("Elements in AAlternative cannot be null.", "value");
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
                yield return _pipe_;
            if (HasAlternativename)
                yield return _alternativename_;
            yield return _elements_;
            if (HasTranslation)
                yield return _translation_;
        }
        
        public override PAlternative Clone()
        {
            return new AAlternative(_pipe_.Clone(), _alternativename_.Clone(), _elements_.Clone(), _translation_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", _pipe_, _alternativename_, _elements_, _translation_);
        }
    }
    public abstract partial class PAlternativename : Production<PAlternativename>
    {
    }
    public partial class AAlternativename : PAlternativename
    {
        private TLBrace _lpar_;
        private TIdentifier _name_;
        private TRBrace _rpar_;
        
        public AAlternativename(TLBrace _lpar_, TIdentifier _name_, TRBrace _rpar_)
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
                    throw new ArgumentException("Lpar in AAlternativename cannot be null.", "value");
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
                    throw new ArgumentException("Name in AAlternativename cannot be null.", "value");
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
                    throw new ArgumentException("Rpar in AAlternativename cannot be null.", "value");
                SetParent(value, this);
                
                _rpar_ = value;
            }
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
            yield return _lpar_;
            yield return _name_;
            yield return _rpar_;
        }
        
        public override PAlternativename Clone()
        {
            return new AAlternativename(_lpar_.Clone(), _name_.Clone(), _rpar_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _lpar_, _name_, _rpar_);
        }
    }
    public abstract partial class PElements : Production<PElements>
    {
    }
    public partial class AElements : PElements
    {
        private NodeList<PElement> _element_;
        
        public AElements(IEnumerable<PElement> _element_)
        {
            this._element_ = new NodeList<PElement>(this, _element_, false);
        }
        
        public NodeList<PElement> Element
        {
            get { return _element_; }
        }
        
        public override void ReplaceChild(Node oldChild, Node newChild)
        {
            if (oldChild is PElement && _element_.Contains(oldChild as PElement))
            {
                if (!(newChild is PElement) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = _element_.IndexOf(oldChild as PElement);
                if (newChild == null)
                    _element_.RemoveAt(index);
                else
                    _element_[index] = newChild as PElement;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            {
                PElement[] temp = new PElement[_element_.Count];
                _element_.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PElements Clone()
        {
            return new AElements(_element_);
        }
        public override string ToString()
        {
            return string.Format("{0}", _element_);
        }
    }
    public abstract partial class PElement : Production<PElement>
    {
    }
    public partial class ASimpleElement : PElement
    {
        private PElementname _elementname_;
        private PElementid _elementid_;
        
        public ASimpleElement(PElementname _elementname_, PElementid _elementid_)
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
                    throw new ArgumentException("Elementid in ASimpleElement cannot be null.", "value");
                SetParent(value, this);
                
                _elementid_ = value;
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
                yield return _elementname_;
            yield return _elementid_;
        }
        
        public override PElement Clone()
        {
            return new ASimpleElement(_elementname_.Clone(), _elementid_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _elementname_, _elementid_);
        }
    }
    public partial class AStarElement : PElement
    {
        private PElementname _elementname_;
        private PElementid _elementid_;
        private TStar _star_;
        
        public AStarElement(PElementname _elementname_, PElementid _elementid_, TStar _star_)
        {
            this.Elementname = _elementname_;
            this.Elementid = _elementid_;
            this.Star = _star_;
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
                    throw new ArgumentException("Elementid in AStarElement cannot be null.", "value");
                SetParent(value, this);
                
                _elementid_ = value;
            }
        }
        public TStar Star
        {
            get { return _star_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Star in AStarElement cannot be null.", "value");
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
                yield return _elementname_;
            yield return _elementid_;
            yield return _star_;
        }
        
        public override PElement Clone()
        {
            return new AStarElement(_elementname_.Clone(), _elementid_.Clone(), _star_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _elementname_, _elementid_, _star_);
        }
    }
    public partial class AQuestionElement : PElement
    {
        private PElementname _elementname_;
        private PElementid _elementid_;
        private TQMark _q_mark_;
        
        public AQuestionElement(PElementname _elementname_, PElementid _elementid_, TQMark _q_mark_)
        {
            this.Elementname = _elementname_;
            this.Elementid = _elementid_;
            this.QMark = _q_mark_;
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
                    throw new ArgumentException("Elementid in AQuestionElement cannot be null.", "value");
                SetParent(value, this);
                
                _elementid_ = value;
            }
        }
        public TQMark QMark
        {
            get { return _q_mark_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("QMark in AQuestionElement cannot be null.", "value");
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
                yield return _elementname_;
            yield return _elementid_;
            yield return _q_mark_;
        }
        
        public override PElement Clone()
        {
            return new AQuestionElement(_elementname_.Clone(), _elementid_.Clone(), _q_mark_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _elementname_, _elementid_, _q_mark_);
        }
    }
    public partial class APlusElement : PElement
    {
        private PElementname _elementname_;
        private PElementid _elementid_;
        private TPlus _plus_;
        
        public APlusElement(PElementname _elementname_, PElementid _elementid_, TPlus _plus_)
        {
            this.Elementname = _elementname_;
            this.Elementid = _elementid_;
            this.Plus = _plus_;
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
                    throw new ArgumentException("Elementid in APlusElement cannot be null.", "value");
                SetParent(value, this);
                
                _elementid_ = value;
            }
        }
        public TPlus Plus
        {
            get { return _plus_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Plus in APlusElement cannot be null.", "value");
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
                yield return _elementname_;
            yield return _elementid_;
            yield return _plus_;
        }
        
        public override PElement Clone()
        {
            return new APlusElement(_elementname_.Clone(), _elementid_.Clone(), _plus_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _elementname_, _elementid_, _plus_);
        }
    }
    public abstract partial class PElementname : Production<PElementname>
    {
    }
    public partial class AElementname : PElementname
    {
        private TLBkt _lpar_;
        private TIdentifier _name_;
        private TRBkt _rpar_;
        private TColon _colon_;
        
        public AElementname(TLBkt _lpar_, TIdentifier _name_, TRBkt _rpar_, TColon _colon_)
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
                    throw new ArgumentException("Lpar in AElementname cannot be null.", "value");
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
                    throw new ArgumentException("Name in AElementname cannot be null.", "value");
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
                    throw new ArgumentException("Rpar in AElementname cannot be null.", "value");
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
                    throw new ArgumentException("Colon in AElementname cannot be null.", "value");
                SetParent(value, this);
                
                _colon_ = value;
            }
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
            yield return _lpar_;
            yield return _name_;
            yield return _rpar_;
            yield return _colon_;
        }
        
        public override PElementname Clone()
        {
            return new AElementname(_lpar_.Clone(), _name_.Clone(), _rpar_.Clone(), _colon_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", _lpar_, _name_, _rpar_, _colon_);
        }
    }
    public abstract partial class PElementid : Production<PElementid>
    {
    }
    public partial class ACleanElementid : PElementid
    {
        private TIdentifier _identifier_;
        
        public ACleanElementid(TIdentifier _identifier_)
        {
            this.Identifier = _identifier_;
        }
        
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in ACleanElementid cannot be null.", "value");
                SetParent(value, this);
                
                _identifier_ = value;
            }
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
            yield return _identifier_;
        }
        
        public override PElementid Clone()
        {
            return new ACleanElementid(_identifier_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0}", _identifier_);
        }
    }
    public partial class ATokenElementid : PElementid
    {
        private TTokenSpecifier _token_specifier_;
        private TDot _dot_;
        private TIdentifier _identifier_;
        
        public ATokenElementid(TTokenSpecifier _token_specifier_, TDot _dot_, TIdentifier _identifier_)
        {
            this.TokenSpecifier = _token_specifier_;
            this.Dot = _dot_;
            this.Identifier = _identifier_;
        }
        
        public TTokenSpecifier TokenSpecifier
        {
            get { return _token_specifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("TokenSpecifier in ATokenElementid cannot be null.", "value");
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
                SetParent(value, this);
                
                _dot_ = value;
            }
        }
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in ATokenElementid cannot be null.", "value");
                SetParent(value, this);
                
                _identifier_ = value;
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
            yield return _token_specifier_;
            yield return _dot_;
            yield return _identifier_;
        }
        
        public override PElementid Clone()
        {
            return new ATokenElementid(_token_specifier_.Clone(), _dot_.Clone(), _identifier_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _token_specifier_, _dot_, _identifier_);
        }
    }
    public partial class AProductionElementid : PElementid
    {
        private TProductionSpecifier _production_specifier_;
        private TDot _dot_;
        private TIdentifier _identifier_;
        
        public AProductionElementid(TProductionSpecifier _production_specifier_, TDot _dot_, TIdentifier _identifier_)
        {
            this.ProductionSpecifier = _production_specifier_;
            this.Dot = _dot_;
            this.Identifier = _identifier_;
        }
        
        public TProductionSpecifier ProductionSpecifier
        {
            get { return _production_specifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("ProductionSpecifier in AProductionElementid cannot be null.", "value");
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
                SetParent(value, this);
                
                _dot_ = value;
            }
        }
        public TIdentifier Identifier
        {
            get { return _identifier_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Identifier in AProductionElementid cannot be null.", "value");
                SetParent(value, this);
                
                _identifier_ = value;
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
            yield return _production_specifier_;
            yield return _dot_;
            yield return _identifier_;
        }
        
        public override PElementid Clone()
        {
            return new AProductionElementid(_production_specifier_.Clone(), _dot_.Clone(), _identifier_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _production_specifier_, _dot_, _identifier_);
        }
    }
    public abstract partial class PHighlightrules : Production<PHighlightrules>
    {
    }
    public partial class AHighlightrules : PHighlightrules
    {
        private THighlighttoken _highlighttoken_;
        private NodeList<PHighlightrule> _highlightrule_;
        
        public AHighlightrules(THighlighttoken _highlighttoken_, IEnumerable<PHighlightrule> _highlightrule_)
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
                    throw new ArgumentException("Highlighttoken in AHighlightrules cannot be null.", "value");
                SetParent(value, this);
                
                _highlighttoken_ = value;
            }
        }
        public NodeList<PHighlightrule> Highlightrule
        {
            get { return _highlightrule_; }
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
            else if (oldChild is PHighlightrule && _highlightrule_.Contains(oldChild as PHighlightrule))
            {
                if (!(newChild is PHighlightrule) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                
                int index = _highlightrule_.IndexOf(oldChild as PHighlightrule);
                if (newChild == null)
                    _highlightrule_.RemoveAt(index);
                else
                    _highlightrule_[index] = newChild as PHighlightrule;
            }
            else throw new ArgumentException("Node to be replaced is not a child in this production.");
        }
        protected override IEnumerable<Node> GetChildren()
        {
            yield return _highlighttoken_;
            {
                PHighlightrule[] temp = new PHighlightrule[_highlightrule_.Count];
                _highlightrule_.CopyTo(temp, 0);
                for (int i = 0; i < temp.Length; i++)
                    yield return temp[i];
            }
        }
        
        public override PHighlightrules Clone()
        {
            return new AHighlightrules(_highlighttoken_.Clone(), _highlightrule_);
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", _highlighttoken_, _highlightrule_);
        }
    }
    public abstract partial class PHighlightrule : Production<PHighlightrule>
    {
    }
    public partial class AHighlightrule : PHighlightrule
    {
        private TIdentifier _name_;
        private TLBrace _lpar_;
        private PList _tokens_;
        private TRBrace _rpar_;
        private PList _list_;
        private TSemicolon _semicolon_;
        
        public AHighlightrule(TIdentifier _name_, TLBrace _lpar_, PList _tokens_, TRBrace _rpar_, PList _list_, TSemicolon _semicolon_)
        {
            this.Name = _name_;
            this.Lpar = _lpar_;
            this.Tokens = _tokens_;
            this.Rpar = _rpar_;
            this.List = _list_;
            this.Semicolon = _semicolon_;
        }
        
        public TIdentifier Name
        {
            get { return _name_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Name in AHighlightrule cannot be null.", "value");
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
                    throw new ArgumentException("Lpar in AHighlightrule cannot be null.", "value");
                SetParent(value, this);
                
                _lpar_ = value;
            }
        }
        public PList Tokens
        {
            get { return _tokens_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Tokens in AHighlightrule cannot be null.", "value");
                SetParent(value, this);
                
                _tokens_ = value;
            }
        }
        public TRBrace Rpar
        {
            get { return _rpar_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Rpar in AHighlightrule cannot be null.", "value");
                SetParent(value, this);
                
                _rpar_ = value;
            }
        }
        public PList List
        {
            get { return _list_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("List in AHighlightrule cannot be null.", "value");
                SetParent(value, this);
                
                _list_ = value;
            }
        }
        public TSemicolon Semicolon
        {
            get { return _semicolon_; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Semicolon in AHighlightrule cannot be null.", "value");
                SetParent(value, this);
                
                _semicolon_ = value;
            }
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
            else if (Tokens == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Tokens in AHighlightrule cannot be null.", "newChild");
                if (!(newChild is PList) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Tokens = newChild as PList;
            }
            else if (Rpar == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("Rpar in AHighlightrule cannot be null.", "newChild");
                if (!(newChild is TRBrace) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                Rpar = newChild as TRBrace;
            }
            else if (List == oldChild)
            {
                if (newChild == null)
                    throw new ArgumentException("List in AHighlightrule cannot be null.", "newChild");
                if (!(newChild is PList) && newChild != null)
                    throw new ArgumentException("Child replaced must be of same type as child being replaced with.");
                List = newChild as PList;
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
            yield return _name_;
            yield return _lpar_;
            yield return _tokens_;
            yield return _rpar_;
            yield return _list_;
            yield return _semicolon_;
        }
        
        public override PHighlightrule Clone()
        {
            return new AHighlightrule(_name_.Clone(), _lpar_.Clone(), _tokens_.Clone(), _rpar_.Clone(), _list_.Clone(), _semicolon_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5}", _name_, _lpar_, _tokens_, _rpar_, _list_, _semicolon_);
        }
    }
    public abstract partial class PHighlightStyle : Production<PHighlightStyle>
    {
    }
    public partial class AItalicHighlightStyle : PHighlightStyle
    {
        private TItalic _italic_;
        
        public AItalicHighlightStyle(TItalic _italic_)
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
            yield return _italic_;
        }
        
        public override PHighlightStyle Clone()
        {
            return new AItalicHighlightStyle(_italic_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0}", _italic_);
        }
    }
    public partial class ABoldHighlightStyle : PHighlightStyle
    {
        private TBold _bold_;
        
        public ABoldHighlightStyle(TBold _bold_)
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
            yield return _bold_;
        }
        
        public override PHighlightStyle Clone()
        {
            return new ABoldHighlightStyle(_bold_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0}", _bold_);
        }
    }
    public partial class ATextHighlightStyle : PHighlightStyle
    {
        private TText _text_;
        private TColon _colon_;
        private PColor _color_;
        
        public ATextHighlightStyle(TText _text_, TColon _colon_, PColor _color_)
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
            yield return _text_;
            yield return _colon_;
            yield return _color_;
        }
        
        public override PHighlightStyle Clone()
        {
            return new ATextHighlightStyle(_text_.Clone(), _colon_.Clone(), _color_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _text_, _colon_, _color_);
        }
    }
    public partial class ABackgroundHighlightStyle : PHighlightStyle
    {
        private TBackground _background_;
        private TColon _colon_;
        private PColor _color_;
        
        public ABackgroundHighlightStyle(TBackground _background_, TColon _colon_, PColor _color_)
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
            yield return _background_;
            yield return _colon_;
            yield return _color_;
        }
        
        public override PHighlightStyle Clone()
        {
            return new ABackgroundHighlightStyle(_background_.Clone(), _colon_.Clone(), _color_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _background_, _colon_, _color_);
        }
    }
    public abstract partial class PColor : Production<PColor>
    {
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
            yield return _rgb_;
            yield return _l_par_;
            yield return _red_;
            yield return _comma1_;
            yield return _green_;
            yield return _comma2_;
            yield return _blue_;
            yield return _r_par_;
        }
        
        public override PColor Clone()
        {
            return new ARgbColor(_rgb_.Clone(), _l_par_.Clone(), _red_.Clone(), _comma1_.Clone(), _green_.Clone(), _comma2_.Clone(), _blue_.Clone(), _r_par_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7}", _rgb_, _l_par_, _red_, _comma1_, _green_, _comma2_, _blue_, _r_par_);
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
            yield return _hsv_;
            yield return _l_par_;
            yield return _hue_;
            yield return _comma1_;
            yield return _saturation_;
            yield return _comma2_;
            yield return _brightness_;
            yield return _r_par_;
        }
        
        public override PColor Clone()
        {
            return new AHsvColor(_hsv_.Clone(), _l_par_.Clone(), _hue_.Clone(), _comma1_.Clone(), _saturation_.Clone(), _comma2_.Clone(), _brightness_.Clone(), _r_par_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7}", _hsv_, _l_par_, _hue_, _comma1_, _saturation_, _comma2_, _brightness_, _r_par_);
        }
    }
    public partial class AHexColor : PColor
    {
        private THexColor _color_;
        
        public AHexColor(THexColor _color_)
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
            yield return _color_;
        }
        
        public override PColor Clone()
        {
            return new AHexColor(_color_.Clone());
        }
        public override string ToString()
        {
            return string.Format("{0}", _color_);
        }
    }
}
