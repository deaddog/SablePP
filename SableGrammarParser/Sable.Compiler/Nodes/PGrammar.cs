using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sable.Compiler.node
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
                        if (ag.GetPackage() != null && ag.GetPackage() is APackage)
                        {
                            APackage pack = ag.GetPackage() as APackage;
                            packagename = pack.GetPackagename().Text;
                        }
                    }

                    if (packagename == null)
                        packagename = defaultName;
                }

                return packagename;
            }
        }
    }
}
