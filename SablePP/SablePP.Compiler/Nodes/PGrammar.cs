using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SablePP.Compiler.Nodes
{
    public partial class PGrammar
    {
        public static readonly string DefaultName = "SableCCPP";
        private string packagename = null;
        public string PackageName
        {
            get
            {
                if (packagename == null)
                {
                    if (HasPackage)
                        packagename = Package.Packagename.Text;
                    else
                        packagename = DefaultName;
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
                    var prod = HasAstproductions ? Astproductions.Productions : Productions.Productions;
                    rootProduction = "P" + prod[0].Identifier.Text.ToCamelCase();
                }
                return rootProduction;
            }
        }
    }
}
