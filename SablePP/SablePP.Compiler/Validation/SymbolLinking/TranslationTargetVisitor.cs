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
            if (node.Target != null)
                return node.Target;

            var target = GetTarget((dynamic)node);
            node.Target = target;
            return target;
        }
        public PAlternative.Target GetTarget(AFullTranslation node)
        {
            return GetTarget(node.Translation);
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
            var element = node.Identifier.AsPElement;
            var id = element.Elementid.Identifier;
            var mod = element.Modifier.GetModifier();

            if (id.IsPProduction)
                return new PAlternative.Target(id.AsPProduction, mod);
            else if (id.IsPAlternative)
                return new PAlternative.Target(id.AsPAlternative, mod);
            else if (id.IsPToken)
                return new PAlternative.Target(id.AsPToken, mod);
            else
                return PAlternative.Target.Unknown;
        }
        public PAlternative.Target GetTarget(AIddotidTranslation node)
        {
            return new PAlternative.Target(node.Production.AsPProduction, node.Identifier.AsPElement.Modifier.GetModifier());
        }
    }
}
