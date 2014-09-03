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
            if (node.HasTranslation)
                node.AstTarget = GetTarget(node.Translation);
            else
                throw new NotImplementedException();
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
            var alt = node.Production.AsPProduction.UnnamedAlternative;

            if (alt.Elements.Count != node.Arguments.Count)
            {
                RegisterError(node.Production, "The number of arguments for {0} did not match its definition ({1} parameter(s)).",
                    node.Production, alt.Elements.Count);
            }

            for (int i = 0; i < node.Arguments.Count; i++)
                ValidateArgument(alt.Elements[i], node.Arguments[i], node.Production.Text, i + 1);

            return new PAlternative.Target(alt, Modifiers.Single);
        }
        public PAlternative.Target GetTarget(ANewalternativeTranslation node)
        {
            var alt = node.Alternative.AsPAlternative;

            if (alt.Elements.Count != node.Arguments.Count)
            {
                RegisterError(node.Alternative, "The number of arguments for {0}.{1} did not match its definition ({2} parameter(s)).",
                    node.Production, node.Alternative, alt.Elements.Count);
            }

            for (int i = 0; i < node.Arguments.Count; i++)
                ValidateArgument(alt.Elements[i], node.Arguments[i], string.Format("{0}.{1}", node.Production.Text, node.Alternative.Text), i + 1);

            return new PAlternative.Target(alt, Modifiers.Single);
        }

        private bool ValidateArgument(PElement parameter, PTranslation argument, string alternativeName, int argumentNum)
        {
            var argumentTarget = GetTarget(argument);
            var parTarget = parameter.Elementid.Identifier.IsPToken ?
                new PAlternative.Target(parameter.Elementid.Identifier.AsPToken, parameter.Modifier.GetModifier()) :
                new PAlternative.Target(parameter.Elementid.Identifier.AsPProduction, parameter.Modifier.GetModifier());

            if (argumentTarget.IsUnknown)
                return true;

            if (argumentTarget.IsNull)
            {
                if (parTarget.Modifier == Modifiers.Optional)
                    return true;
                else
                {
                    RegisterError(argument, "Null can only be used as an argument for optional elements.");
                    return false;
                }
            }

            if (argumentTarget.IsEmptyList)
            {
                if (parTarget.Modifier == Modifiers.ZeroOrMany)
                    return true;
                else
                {
                    RegisterError(argument, "An empty list can only be used as an argument for zero-or-many (*) elements.");
                    return false;
                }
            }

            var argMod = argumentTarget.Modifier;
            bool orderMatch =
                (argMod == Modifiers.Single && parTarget.Modifier == Modifiers.Optional) ||
                (argMod == Modifiers.OneOrMany && parTarget.Modifier == Modifiers.ZeroOrMany) ||
                argMod == parTarget.Modifier;

            if (!orderMatch)
            {
                RegisterError(argument, "Argument {2} for alternative {3} must be {0}. {1} was found.",
                    parTarget.Modifier, argMod,
                    argumentNum, alternativeName);
                return false;
            }

            if (parTarget.IsToken)
            {
                if (argumentTarget.IsAlternative)
                {
                    RegisterError(argument, "Argument {2} for alternative {3} must be a {0} token. A production ({1}) was found.",
                        parTarget.Token.Identifier, argumentTarget.Alternative.Production.Identifier,
                        argumentNum, alternativeName);
                    return false;
                }
                else if (argumentTarget.IsProduction)
                {
                    RegisterError(argument, "Argument {2} for alternative {3} must be a {0} token. A production ({1}) was found.",
                        parTarget.Token.Identifier, argumentTarget.Production.Identifier,
                        argumentNum, alternativeName);
                    return false;
                }
                else if (argumentTarget.IsToken)
                {
                    if (argumentTarget.Token != parTarget.Token)
                    {
                        RegisterError(argument, "Argument {2} for alternative {3} must be a {0} token - a {1} token was found.",
                            parTarget.Token.Identifier, argumentTarget.Token.Identifier,
                            argumentNum, alternativeName);
                        return false;
                    }
                    else
                        return true;
                }
                else
                    throw new InvalidOperationException();
            }

            if (parTarget.IsProduction)
            {
                if (argumentTarget.IsAlternative)
                {
                    if (argumentTarget.Alternative.Production != parTarget.Production)
                    {
                        RegisterError(argument, "Argument {2} for alternative {3} must be a {0} production - a {1} production was found.",
                            parTarget.Production.Identifier, argumentTarget.Alternative.Production.Identifier,
                            argumentNum, alternativeName);
                        return false;
                    }
                    else
                        return true;
                }
                else if (argumentTarget.IsProduction)
                {
                    if (argumentTarget.Production != parTarget.Production)
                    {
                        RegisterError(argument, "Argument {2} for alternative {3} must be a {0} production - a {1} production was found.",
                            parTarget.Production.Identifier, argumentTarget.Production.Identifier,
                            argumentNum, alternativeName);
                        return false;
                    }
                    else
                        return true;
                }
                else if (argumentTarget.IsToken)
                {
                    RegisterError(argument, "Argument {2} for alternative {3} must be a {0} production. A token ({1}) was found.",
                        parTarget.Production.Identifier, argumentTarget.Token.Identifier,
                        argumentNum, alternativeName);
                    return false;
                }
                else
                    throw new InvalidOperationException();
            }

            throw new InvalidOperationException();
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
            return PAlternative.Target.Null;
        }
        public PAlternative.Target GetTarget(AIdTranslation node)
        {
            var element = node.Identifier.AsPElement;
            var id = element.Elementid.Identifier;
            var mod = element.Modifier.GetModifier();

            if (id.IsPProduction)
            {
                if (id.AsPProduction.AstTarget.IsProduction)
                    id = id.AsPProduction.AstTarget.Production.Identifier;
                else if (id.AsPProduction.AstTarget.IsToken)
                    id = id.AsPProduction.AstTarget.Token.Identifier;
                else
                    return PAlternative.Target.Unknown;
            }

            if (id.IsPProduction)
                return new PAlternative.Target(id.AsPProduction, mod);
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
