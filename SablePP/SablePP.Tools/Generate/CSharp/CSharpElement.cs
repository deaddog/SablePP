namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Provides an extension to the <see cref="ComplexElement"/> specific to C#.
    /// </summary>
    public abstract class CSharpElement<Content> : ContentElement<Content> where Content : PatchElement
    {
        public CSharpElement(Content content)
            :base(content)
        {
        }

        /// <summary>
        /// Emits the start of a region.
        /// </summary>
        /// <param name="text">The message displayed in the first line of the region.</param>
        /// <param name="addSpacers">if set to <c>true</c> a blank line is inserted before and after the start of the region.</param>
        public void EmitRegionStart(string text, bool addSpacers = true)
        {
            if (addSpacers)
                content.EmitNewLine();
            content.EmitLine("#region {0}", text);
            if (addSpacers)
                content.EmitNewLine();
        }
        /// <summary>
        /// Emits the end of a region.
        /// </summary>
        /// <param name="addSpacers">if set to <c>true</c> a blank line is inserted before and after the end of the region.</param>
        public void EmitRegionEnd(bool addSpacers = true)
        {
            if (addSpacers)
                content.EmitNewLine();
            content.EmitLine("#endregion");
            if (addSpacers)
                content.EmitNewLine();
        }
    }
}
