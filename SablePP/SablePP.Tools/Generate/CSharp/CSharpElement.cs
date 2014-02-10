namespace SablePP.Tools.Generate.CSharp
{
    /// <summary>
    /// The base element for C# code generation.
    /// </summary>
    public abstract class CSharpElement : ComplexElement
    {
        /// <summary>
        /// Emits newline, curly bracket, newline and increases indentation
        /// </summary>
        protected void emitBlockStart()
        {
            emitNewLine();
            emit("{", UseSpace.Never, UseSpace.Never);
            emitNewLine();
            increaseIndentation();
        }
        /// <summary>
        /// Decreases indentation, and emits curly bracket and newline
        /// </summary>
        protected void emitBlockEnd()
        {
            decreaseIndentation();
            emit("}", UseSpace.Never, UseSpace.Never);
            emitNewLine();
        }
    }
}
