namespace CustomCode.Core.DesignByContract
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Preconditions for reference types.
    /// </summary>
    /// <remarks>
    /// https://stackoverflow.com/questions/15319025/methodimploptions-aggressiveinlining-vs-targetedpatchingoptout
    /// https://stackoverflow.com/questions/14937647/method-inlining-across-native-images-of-assemblies/14982340#14982340
    /// </remarks>
    public partial class Requires
    {
        #region Logic

        /// <summary>
        /// Precondition that requires a reference type to have a non-null value.
        /// </summary>
        /// <typeparam name="T"> The type of the generic argument. </typeparam>
        /// <param name="value"> The value to be checked for null. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> is null. </param>
        /// <example>
        /// Requires.NotNull(value);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotToBeNull<T>(T value, string parameterName = "Value", string errorMessage = "Value cannot be null")
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName, errorMessage);
            }
        }

        /// <summary>
        /// Precondition that requires a reference type to have a non-null value.
        /// </summary>
        /// <typeparam name="T"> The type of the generic argument. </typeparam>
        /// <typeparam name="E">
        /// The type of the <see cref="Exception"/> that is raised when the <paramref name="value"/> is null.
        /// </typeparam>
        /// <param name="value"> The value to be checked for null. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.NotNull(value, () => new ArgumentNullException("Value", "Value cannot be null."));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotToBeNull<T, E>(T value, Func<E> exceptionFactory)
            where T : class
            where E : Exception
        {
            if (value == null)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a reference type to have a non-null value.
        /// </summary>
        /// <typeparam name="T"> The type of the generic argument. </typeparam>
        /// <typeparam name="E">
        /// The type of the <see cref="Exception"/> that is raised when the <paramref name="value"/> is null.
        /// </typeparam>
        /// <param name="value"> The value to be checked for null. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.NotNull(value, (v) => new ArgumentNullException("Value", "Value cannot be null."));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotToBeNull<T, E>(T value, Func<T, E> exceptionFactory)
            where T : class
            where E : Exception
        {
            if (value == null)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        #endregion
    }
}