namespace CustomCode.Core.DesignByContract
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Preconditions for <see cref="Nullable{T}"/> value types.
    /// </summary>
    /// <remarks>
    /// https://stackoverflow.com/questions/15319025/methodimploptions-aggressiveinlining-vs-targetedpatchingoptout
    /// https://stackoverflow.com/questions/14937647/method-inlining-across-native-images-of-assemblies/14982340#14982340
    /// </remarks>
    public partial class Requires
    {
        #region Dependencies

        /// <summary>
        /// Creates a new instance of the <see cref="Requires"/> type.
        /// </summary>
        /// <remarks>
        /// Hidden so that this class cannot be instanciated directly (since it contains only static methods).
        /// </remarks>
        protected Requires()
        { }

        #endregion

        #region Logic

        /// <summary>
        /// Precondition that requires a <see cref="Nullable{T}"/> value type to have a non-null value.
        /// </summary>
        /// <typeparam name="T"> The type of the <see cref="Nullable{T}"/> generic argument. </typeparam>
        /// <param name="value"> The value to be checked for null. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> is null. </param>
        /// <example>
        /// Requires.NotNull(value);
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotNull<T>(T? value, string parameterName = "Value", string errorMessage = "Value cannot be null")
            where T : struct
        {
#if contracts_throw
            if (value == null)
            {
                throw new ArgumentNullException(parameterName, errorMessage);
            }
#elif contracts_trace
            if (value == null)
            {
                Debug.WriteLine($"{parameterName}: {errorMessage}");
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires a <see cref="Nullable{T}"/> value type to have a non-null value.
        /// </summary>
        /// <typeparam name="T"> The type of the <see cref="Nullable{T}"/> generic argument. </typeparam>
        /// <typeparam name="E">
        /// The type of the <see cref="Exception"/> that is raised when the <paramref name="value"/> is null.
        /// </typeparam>
        /// <param name="value"> The value to be checked for null. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.NotNull(value, () => new ArgumentNullException("Value", "Value cannot be null."));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotNull<T, E>(T? value, Func<E> exceptionFactory)
            where T : struct
            where E : Exception
        {
#if contracts_throw
            if (value == null)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value == null)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires a <see cref="Nullable{T}"/> value type to have a non-null value.
        /// </summary>
        /// <typeparam name="T"> The type of the <see cref="Nullable{T}"/> generic argument. </typeparam>
        /// <typeparam name="E">
        /// The type of the <see cref="Exception"/> that is raised when the <paramref name="value"/> is null.
        /// </typeparam>
        /// <param name="value"> The value to be checked for null. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.NotNull(value, (v) => new ArgumentNullException("Value", "Value cannot be null."));
        /// </example>
        [Conditional("contracts_compile")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotNull<T, E>(Nullable<T> value, Func<Nullable<T>, E> exceptionFactory)
            where T : struct
            where E : Exception
        {
#if contracts_throw
            if (value == null)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value == null)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        #endregion
    }
}