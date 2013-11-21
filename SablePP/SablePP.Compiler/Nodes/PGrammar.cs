using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Nodes
{
    public partial class PGrammar
    {
        private static readonly string defaultName = "SableCCPP";
        private string packagename = null;
        public string PackageName
        {
            get
            {
                if (packagename == null)
                {
                    if (this is AGrammar)
                    {
                        AGrammar ag = this as AGrammar;
                        if (ag.HasPackage && ag.Package is APackage)
                        {
                            APackage pack = ag.Package as APackage;
                            packagename = pack.Packagename.Text;
                        }
                    }

                    if (packagename == null)
                        packagename = defaultName;
                }

                return packagename;
            }
        }

        private string rootProduction = null;
        public string RootProduction
        {
            get
            {
                if (rootProduction == null)
                {
                    var ast = (this as AGrammar).Astproductions as AAstproductions;
                    var pro = (this as AGrammar).Productions as AProductions;

                    AProduction prod = (ast == null ? pro.Productions : ast.Productions)[0] as AProduction;
                    rootProduction = "P" + prod.Identifier.Text.ToCamelCase();
                }
                return rootProduction;
            }
        }
    }
}
