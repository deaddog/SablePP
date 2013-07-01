using System;
using Sable.Compiler.node;

namespace Sable.Compiler.Generate.Tokens
{
    public class TokenVisitor : GenerateVisitor
    {
        protected string GetTokenName(PToken element)
        {
            if(element is AToken)
                return "T" + ToCamelCase((element as AToken).GetIdentifier().Text);
            else
                throw new NotImplementedException("Unknown token type.");
        }
    }
}
