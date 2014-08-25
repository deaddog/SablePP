using SablePP.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SablePP.Generate
{
    public class SableCCGenerator
    {
        public SableCCGenerator()
        { }

        public void Generate(Grammar grammar)
        { }

        private void Visit(Grammar node)
        { }

        private void Visit(Helper node)
        { }

        private void Visit(State node)
        { }

        private void Visit(Token node)
        { }

        private void Visit(Production node)
        { }

        private void Visit(Alternative node)
        { }

        private void Visit(AbstractProduction node)
        { }

        private void Visit(AbstractAlternative node)
        { }

        private void Visit(RegularExpressions.ConcatenatedRegExp node)
        { }
        private void Visit(RegularExpressions.LiteralRegExp node)
        { }
        private void Visit(RegularExpressions.ModifiedRegExp node)
        { }
        private void Visit(RegularExpressions.OrRegExp node)
        { }
        private void Visit(RegularExpressions.ReferenceRegExp node)
        { }
        private void Visit(RegularExpressions.SetRegExp node)
        { }

        private void Visit(Translations.ElementTranslation node)
        { }
        private void Visit(Translations.ListTranslation node)
        { }
        private void Visit(Translations.NewTranslation node)
        { }
        private void Visit(Translations.NullTranslation node)
        { }
    }
}
