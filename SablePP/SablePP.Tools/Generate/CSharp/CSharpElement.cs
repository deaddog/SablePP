namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// Provides an extension to the <see cref="ComplexElement"/> specific to C#.
    /// </summary>
    public abstract class CSharpElement : ComplexElement
    {
        /// <summary>
        /// Emits the start of a region.
        /// </summary>
        /// <param name="text">The message displayed in the first line of the region.</param>
        public void EmitRegionStart(string text)
        {
            base.emitLine("#region {0}", text);
        }
        /// <summary>
        /// Emits the end of a region.
        /// </summary>
        public void EmitRegionEnd()
        {
            base.emitLine("#endregion");
        }
    }
}
