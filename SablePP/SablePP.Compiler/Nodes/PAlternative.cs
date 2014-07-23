using System;

namespace SablePP.Compiler.Nodes
{
    public partial class PAlternative
    {
        public PProduction Production
        {
            get { return GetFirstParent<PProduction>(); }
        }

        public string ClassName
        {
            get
            {
                string productionName = Production.ClassName.Substring(1);

                if (this.HasAlternativename)
                    return "A" + Alternativename.Name.Text.ToCamelCase() + productionName;
                else
                    return "A" + productionName;
            }
        }
    }
}
