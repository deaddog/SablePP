using SablePP.Compiler.Analysis;
using SablePP.Compiler.Nodes;
using SablePP.Tools.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Validation.SymbolLinking
{
    public class TranslationTargetVisitor : ErrorVisitor
    {
        public TranslationTargetVisitor(ErrorManager errorManager)
            : base(errorManager)
        {
        }

        public override void CaseAAlternative(AAlternative node)
        {
            base.CaseAAlternative(node);
        }

        public PAlternative.Target GetTarget(PTranslation node)
        {
            var target = GetTarget((dynamic)node);
            node.Target = target;
            return target;
        }
        public PAlternative.Target GetTarget(AFullTranslation node)
        {
            throw new NotImplementedException();
        }
        public PAlternative.Target GetTarget(ANewTranslation node)
        {
            throw new NotImplementedException();
        }
        public PAlternative.Target GetTarget(ANewalternativeTranslation node)
        {
            throw new NotImplementedException();
        }
        public PAlternative.Target GetTarget(AListTranslation node)
        {
            throw new NotImplementedException();
        }
        public PAlternative.Target GetTarget(ANullTranslation node)
        {
            throw new NotImplementedException();
        }
        public PAlternative.Target GetTarget(AIdTranslation node)
        {
            throw new NotImplementedException();
        }
        public PAlternative.Target GetTarget(AIddotidTranslation node)
        {
            throw new NotImplementedException();
        }
    }
}
