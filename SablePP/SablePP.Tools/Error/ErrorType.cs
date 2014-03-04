namespace SablePP.Tools.Error
{
    /// <summary>
    /// Describes different types of compiler 'error's
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// Denotes an error that indicates that code is not able to compile.
        /// </summary>
        Error,
        /// <summary>
        /// Denotes an error that should be fixed, but would still allow code to compile.
        /// </summary>
        Warning,
        /// <summary>
        /// Denotes something that is not considered an error, but only information for the user.
        /// </summary>
        Message
    }
}
