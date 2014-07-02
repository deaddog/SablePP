using System;

namespace SablePP.Compiler.Nodes
{
    public partial class AAlternative
    {
        public string ProductionName
        {
            get
            {
                var production = GetFirstParent<PProduction>();
                return "P" + production.Identifier.Text.ToCamelCase();
            }
        }

        public string ClassName
        {
            get
            {
                var production = GetFirstParent<PProduction>();

                string productionName = production.Identifier.Text.ToCamelCase();

                if (this.HasAlternativename)
                    return "A" + Alternativename.Name.Text.ToCamelCase() + productionName;
                else
                    return "A" + productionName;
            }
        }
    }
}
