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
            if (node.Elements.Count == 0)
                return PAlternative.Target.EmptyList;

            var targetElement = node.Elements.FirstOrDefault(t => !GetTarget(t).IsUnknown && !GetTarget(t).IsNull && !GetTarget(t).IsEmptyList);
            if (targetElement == null)
                return PAlternative.Target.EmptyList;

            Modifiers mod = GetListModifier(node.Elements);

            var tempTarget = GetTarget(targetElement);
            if (tempTarget.IsToken)
            {
                if (TestTokenTarget(node, tempTarget.Token))
                    return new PAlternative.Target(tempTarget.Token, mod);
                else
                    return PAlternative.Target.Unknown;
            }

            else if (tempTarget.IsAlternative)
            {
                if (TestProductionTarget(node, tempTarget.Alternative.Production))
                    return new PAlternative.Target(tempTarget.Alternative.Production, mod);
                else
                    return PAlternative.Target.Unknown;
            }

            else if (tempTarget.IsProduction)
            {
                if (TestProductionTarget(node, tempTarget.Production))
                    return new PAlternative.Target(tempTarget.Production, mod);
                else
                    return PAlternative.Target.Unknown;
            }
            else
                throw new InvalidOperationException("Unknown translation target.");
        }
        private Modifiers GetListModifier(IEnumerable<PTranslation> collection)
        {
            foreach (var t in collection)
            {
                var target = GetTarget(t);
                if (!target.IsUnknown && !target.IsNull && !target.IsEmptyList && (target.Modifier == Modifiers.Single || target.Modifier == Modifiers.OneOrMany))
                    return Modifiers.OneOrMany;
            }
            return Modifiers.ZeroOrMany;
        }
        private bool TestTokenTarget(AListTranslation node, PToken token)
        {
            bool ok = true;
            for (int i = 0; i < node.Elements.Count; i++)
            {
                var target = GetTarget(node.Elements[i]);
                if (target.IsToken)
                {
                    if (target.Token != token)
                    {
                        RegisterError(node.Elements[i],
                            "All elements in a list translation must be translated to the same element type. A {0} token cannot be part of a {1} list.",
                            target.Token.Identifier,
                            token.Identifier);
                        ok = false;
                    }
                }

                else if (!target.IsUnknown)
                {
                    RegisterError(node.Elements[i],
                        "All elements in a list translation must be translated to the same element type.");
                    ok = false;
                }
            }

            return ok;
        }
        private bool TestProductionTarget(AListTranslation node, PProduction production)
        {
            bool ok = true;
            for (int i = 0; i < node.Elements.Count; i++)
            {
                var target = GetTarget(node.Elements[i]);
                var prod = target.IsAlternative ? target.Alternative.Production : target.Production;
                if (prod != null)
                {
                    if (prod != production)
                    {
                        RegisterError(node.Elements[i],
                            "All elements in a list translation must be translated to the same element type. A {0} production cannot be part of a {1} list.",
                            prod.Identifier,
                            production.Identifier);
                        ok = false;
                    }
                }

                else if (!target.IsUnknown)
                {
                    RegisterError(node.Elements[i],
                        "All elements in a list translation must be translated to the same element type.");
                    ok = false;
                }
            }

            return ok;
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
