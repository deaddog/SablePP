using System;
using System.Collections.Generic;

using SablePP.Tools.Error;
using SablePP.Compiler.Nodes;

namespace SablePP.Compiler.Validation
{
    public class SyntaxHighlightValidator : ErrorVisitor
    {
        public SyntaxHighlightValidator(ErrorManager manager)
            : base(manager)
        {
        }

        public override void CaseAGrammar(AGrammar node)
        {
            if (node.HasHighlightrules)
                Visit((dynamic)node.Highlightrules);
        }

        public override void CaseAHighlightrule(AHighlightrule node)
        {
            rule = node;

            bold = null;
            italic = null;
            text = null;
            background = null;

            base.CaseAHighlightrule(node);
        }

        private AHighlightrule rule = null;

        private ABoldHighlightStyle bold = null;
        private AItalicHighlightStyle italic = null;
        private ATextHighlightStyle text = null;
        private ABackgroundHighlightStyle background = null;

        public override void CaseABoldHighlightStyle(ABoldHighlightStyle node)
        {
            if (bold != null)
                RegisterError(node, "Highlight rule is already set to bold.");
            else
                bold = node;
        }
        public override void CaseAItalicHighlightStyle(AItalicHighlightStyle node)
        {
            if (italic != null)
                RegisterError(node, "Highlight rule is already set to italic.");
            else
                italic = node;
        }
        public override void CaseATextHighlightStyle(ATextHighlightStyle node)
        {
            if (text != null)
                RegisterError(node, "Highlight rule has already been given a text color.");
            else
                text = node;
            base.CaseATextHighlightStyle(node);
        }
        public override void CaseABackgroundHighlightStyle(ABackgroundHighlightStyle node)
        {
            if (background != null)
                RegisterError(node, "Highlight rule has already been given a background color.");
            else
                background = node;
            base.CaseABackgroundHighlightStyle(node);
        }

        public override void CaseARgbColor(ARgbColor node)
        {
            if (node.Red.Value > 255)
                RegisterError(node.Red, "The first argument (red) in a rgb color must be in the range [0-255].");
            if (node.Green.Value > 255)
                RegisterError(node.Green, "The second argument (green) in a rgb color must be in the range [0-255].");
            if (node.Blue.Value > 255)
                RegisterError(node.Blue, "The third argument (blue) in a rgb color must be in the range [0-255].");
        }
        public override void CaseAHsvColor(AHsvColor node)
        {
            if (node.Hue.Value > 359)
                RegisterError(node.Hue, "The first argument (hue) in a {0} color must be in the range [0-359].", node.Hsv.Text);
            if (node.Saturation.Value > 100)
                RegisterError(node.Saturation, "The second argument (saturation) in a {0} color must be in the range [0-100].", node.Hsv.Text);
            if (node.Brightness.Value > 100)
                RegisterError(node.Brightness, "The third argument ({1}) in a {0} color must be in the range [0-100].", node.Hsv.Text, node.Hsv.Text == "hsv" ? "value" : "brightness");
        }
        public override void CaseAHexColor(AHexColor node)
        {
            string text = node.Color.Text.Substring(1);
            if (text.Length != 3 && text.Length != 6)
                RegisterError(node, "Hexadecimal colors must be declared using either 3 or 6 digits.");
        }
    }
}
