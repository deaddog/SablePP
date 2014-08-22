using SablePP.Generate.RegularExpressions;
using System;

namespace SablePP.Generate
{
   public class Helper
    {
        private string name;
        private RegExp expression;

        public Helper(string name, RegExp expression)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (expression == null)
                throw new ArgumentNullException("expression");

            this.name = name;
            this.expression = expression;
        }

        public string Name
        {
            get { return name; }
        }

        public RegExp Expression
        {
            get { return expression; }
        }
    }
}
