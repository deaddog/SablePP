namespace SablePP.Tools.Generate
{
    /// <summary>
    /// Provides a <see cref="ComplexElement"/> that contains another element to which code can be emitted.
    /// </summary>
    /// <typeparam name="Content">The type of the content element.</typeparam>
    public abstract class ContentElement<Content> : ComplexElement where Content : PatchElement
    {
        /// <summary>
        /// The content element to which code can be emitted.
        /// </summary>
        protected readonly Content content;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentElement{Content}"/> class.
        /// </summary>
        /// <param name="content">The element that should contain the exposed content contained in the element.</param>
        public ContentElement(Content content)
        {
            this.content = content;
        }
    }
}
