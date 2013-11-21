﻿using System;

namespace SablePP.Compiler.Nodes
{
    public partial class AAlternative
    {
        public string ProductionName
        {
            get
            {
                PProductionrule rule = this.GetParent() as PProductionrule;
                AProduction production = rule.GetParent() as AProduction;

                return "P" + production.Identifier.Text.ToCamelCase();
            }
        }

        public string ClassName
        {
            get
            {
                PProductionrule rule = this.GetParent() as PProductionrule;
                AProduction production = rule.GetParent() as AProduction;

                string productionName = production.Identifier.Text.ToCamelCase();

                if (this.HasAlternativename)
                    return "A" + (Alternativename as AAlternativename).Name.Text.ToCamelCase() + productionName;
                else
                    return "A" + productionName;
            }
        }
    }
}
