namespace CustomCode.Core.DesignByContract
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Preconditions for <see cref="Enum"/> types.
    /// </summary>
    /// <remarks>
    /// https://stackoverflow.com/questions/15319025/methodimploptions-aggressiveinlining-vs-targetedpatchingoptout
    /// https://stackoverflow.com/questions/14937647/method-inlining-across-native-images-of-assemblies/14982340#14982340
    /// </remarks>
    public partial class Requires
    {
        #region Logic

        /// <summary>
        /// Precondition that requires an enumeration <paramref name="value"/> to fullfill the specified
        /// boolean <paramref name="condition"/>.
        /// </summary>
        /// <param name="value"> The <see cref="Enum"/> value to be checked. </param>
        /// <param name="condition"> A boolean condition that must be fullfilled by the specified value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBe(value, (v) => v == MyEnum.Value);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBe<T>(T value, Func<T, bool> condition,
            string parameterName = "Value", string errorMessage = "Value is invalid")
            where T : Enum
        {
            if (new Lazy<bool>(() => condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires an enumeration <paramref name="value"/> to fullfill the specified
        /// boolean <paramref name="condition"/>.
        /// </summary>
        /// <typeparam name="E"> The type of the exception to be thrown. </typeparam>
        /// <typeparam name="T"> The type of the enumeration to be checked. </typeparam>
        /// <param name="value"> The <see cref="Enum"/> value to be checked. </param>
        /// <param name="condition"> A boolean condition that must be fullfilled by the specified value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBe(value, (v) => v == MyEnum.Value, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBe<T, E>(T value, Func<T, bool> condition, Func<E> exceptionFactory)
            where T : Enum
            where E : Exception
        {
            if (new Lazy<bool>(() => condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires an enumeration <paramref name="value"/> to fullfill the specified
        /// boolean <paramref name="condition"/>.
        /// </summary>
        /// <typeparam name="E"> The type of the exception to be thrown. </typeparam>
        /// <typeparam name="T"> The type of the enumeration to be checked. </typeparam>
        /// <param name="value"> The <see cref="Enum"/> value to be checked. </param>
        /// <param name="condition"> A boolean condition that must be fullfilled by the specified value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBe(value, (v) => v == MyEnum.Value, (v) => new ArgumentException($"Invalid value: {v}", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBe<T, E>(T value, Func<T, bool> condition, Func<T, E> exceptionFactory)
            where T : Enum
            where E : Exception
        {
            if (new Lazy<bool>(() => condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /*
        /// <summary>
        /// Precondition that requires an unsigned long <paramref name="value"/> to be one of the expected values.
        /// </summary>
        /// <param name="value"> The <see cref="byte"/> value to be checked. </param>
        /// <param name="expectedValues"> The expected values. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeOneOf(value, new[] { 1, 2, 10 });
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeOneOf(byte value, IEnumerable<byte> expectedValues,
            string parameterName = "Value", string errorMessage = "Value is invalid")
        {
            if (expectedValues.Any(v => v==value)==false)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires an unsigned long <paramref name="value"/> to be one of the expected values.
        /// </summary>
        /// <param name="value"> The <see cref="byte"/> value to be checked. </param>
        /// <param name="expectedValues"> The expected values. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeOneOf(value, new[] { 1, 2, 10 }, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeOneOf<E>(byte value, IEnumerable<byte> expectedValues, Func<E> exceptionFactory)
            where E : Exception
        {
            if (expectedValues.Any(v => v==value)==false)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires an unsigned long <paramref name="value"/> to be one of the expected values.
        /// </summary>
        /// <param name="value"> The <see cref="byte"/> value to be checked. </param>
        /// <param name="expectedValues"> The expected values. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeOneOf(value, new[] { 1, 2, 10 }, (v) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeOneOf<E>(byte value, IEnumerable<byte> expectedValues, Func<byte, IEnumerable<byte>, E> exceptionFactory)
            where E : Exception
        {
            if (expectedValues.Any(v => v==value)==false)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, expectedValues)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }*/

        #endregion
    }
}