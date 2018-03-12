namespace CustomCode.Core.DesignByContract
{
    /// <summary>
    /// Postconditions for types.
    /// </summary>
    /// <remarks>
    /// https://stackoverflow.com/questions/15319025/methodimploptions-aggressiveinlining-vs-targetedpatchingoptout
    /// https://stackoverflow.com/questions/14937647/method-inlining-across-native-images-of-assemblies/14982340#14982340
    /// </remarks>>
    public sealed class Ensures : Requires
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="Ensures"/> type.
        /// </summary>
        /// <remarks>
        /// Hidden so that this class cannot be instanciated directly (since it contains only static methods).
        /// </remarks>
        private Ensures()
        { }

        #endregion
    }
}