using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SablePP.Generate
{
    public abstract class RegExp
    {
        public static RegExp FromChar(char content)
        {
            return new LiteralRegExp(content);
        }
        public static RegExp FromString(string content)
        {
            return new LiteralRegExp(content);
        }
    }
}
