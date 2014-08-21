using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SablePP.Generate
{
    public abstract class RegularExpression
    {
        public static RegularExpression FromChar(char content)
        {
            return new LiteralRegularExpression(content);
        }
        public static RegularExpression FromString(string content)
        {
            return new LiteralRegularExpression(content);
        }
    }
}
