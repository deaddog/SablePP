using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SablePP.Generate
{
   public class Helper
    {
        private string name;
        private RegularExpression expression;

        public Helper(string name, RegularExpression expression)
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

        public RegularExpression Expression
        {
            get { return expression; }
        }
    }
}
