namespace CustomCode.Core.DesignByContract
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Preconditions for <see cref="Nullable{Int64}"/> types.
    /// </summary>
    /// <remarks>
    /// https://stackoverflow.com/questions/15319025/methodimploptions-aggressiveinlining-vs-targetedpatchingoptout
    /// https://stackoverflow.com/questions/14937647/method-inlining-across-native-images-of-assemblies/14982340#14982340
    /// </remarks>
    public partial class Requires
    {
        #region Logic

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to fullfill the specified
        /// boolean <paramref name="condition"/>.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="condition"> A boolean condition that must be fullfilled by the specified value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeNegative(value);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBe(long? value, Func<long?, bool> condition,
            string parameterName = "Value", string errorMessage = "Value is invalid")
        {
            if (new Lazy<bool>(() => condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to fullfill the specified
        /// boolean <paramref name="condition"/>.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="condition"> A boolean condition that must be fullfilled by the specified value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeNegative(value, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBe<E>(long? value, Func<long?, bool> condition, Func<E> exceptionFactory)
            where E : Exception
        {
            if (new Lazy<bool>(() => condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to fullfill the specified
        /// boolean <paramref name="condition"/>.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="condition"> A boolean condition that must be fullfilled by the specified value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeNegative(value, (v) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBe<E>(long? value, Func<long?, bool> condition, Func<long?, E> exceptionFactory)
            where E : Exception
        {
            if (new Lazy<bool>(() => condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be between the specified
        /// <paramref name="minimum"/> and <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeBetween(value, 1, 10);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeBetween(long? value, long minimum, long maximum,
            string parameterName = "Value", string errorMessage = "Value must be between the specified minimum and maximum")
        {
            if (value == null || value < minimum || value > maximum)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be between the specified
        /// <paramref name="minimum"/> and <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeBetween(value, 1, 10, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeBetween<E>(long? value, long minimum, long maximum, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value < minimum || value > maximum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be between the specified
        /// <paramref name="minimum"/> and <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeBetween(value, 1, 10, (v, min, max) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeBetween<E>(long? value, long minimum, long maximum, Func<long?, long, long, E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value < minimum || value > maximum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, minimum, maximum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be greater than the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThan(long? value, long minimum,
            string parameterName = "Value", string errorMessage = "Value must be greater than the specified minimum")
        {
            if (value == null || value <= minimum)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be greater than the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThan<E>(long? value, long minimum, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value <= minimum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be greater than the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1, (v, min) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThan<E>(long? value, long minimum, Func<long?, long, E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value <= minimum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, minimum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be greater than or equal to the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThanOrEqualTo(long? value, long minimum,
            string parameterName = "Value", string errorMessage = "Value must be greater than or equal to the specified minimum")
        {
            if (value == null || value < minimum)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be greater than or equal to the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThanOrEqualTo<E>(long? value, long minimum, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value < minimum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be greater than or equal to the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1, (v, min) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThanOrEqualTo<E>(long? value, long minimum, Func<long?, long, E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value < minimum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, minimum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be less than the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThan(long? value, long maximum,
            string parameterName = "Value", string errorMessage = "Value must be less than the specified maximum")
        {
            if (value == null || value >= maximum)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be less than the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThan<E>(long? value, long maximum, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value >= maximum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be less than the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10, (v, max) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThan<E>(long? value, long maximum, Func<long?, long, E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value >= maximum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, maximum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be less than or equal to the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThanOrEqualTo(long? value, long maximum,
            string parameterName = "Value", string errorMessage = "Value must be less than or equal to the specified maximum")
        {
            if (value == null || value > maximum)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be less than or equal to the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThanOrEqualTo<E>(long? value, long maximum, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value > maximum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be less than or equal to the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10, (v, max) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThanOrEqualTo<E>(long? value, long maximum, Func<long?, long, E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value > maximum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, maximum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be negative.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeNegative(value);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeNegative(long? value, string parameterName = "Value", string errorMessage = "Value must be negative")
        {
            if (value == null || value >= 0)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be negative.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeNegative(value, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeNegative<E>(long? value, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value >= 0)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be negative.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeNegative(value, (v) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeNegative<E>(long? value, Func<long?, E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value >= 0)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be one of the expected values.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="expectedValues"> The expected values. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeOneOf(value, new[] { 1, 2, 10 });
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeOneOf(long? value, IEnumerable<long?> expectedValues,
            string parameterName = "Value", string errorMessage = "Value is invalid")
        {
            if (expectedValues.Any(v => v == value) == false)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be one of the expected values.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="expectedValues"> The expected values. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeOneOf(value, new[] { 1, 2, 10 }, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeOneOf<E>(long? value, IEnumerable<long?> expectedValues, Func<E> exceptionFactory)
            where E : Exception
        {
            if (expectedValues.Any(v => v == value) == false)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be one of the expected values.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="expectedValues"> The expected values. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeOneOf(value, new[] { 1, 2, 10 }, (v) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeOneOf<E>(long? value, IEnumerable<long?> expectedValues, Func<long?, IEnumerable<long?>, E> exceptionFactory)
            where E : Exception
        {
            if (expectedValues.Any(v => v == value) == false)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, expectedValues)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be positive.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBePositive(value);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBePositive(long? value, string parameterName = "Value", string errorMessage = "Value must be positive")
        {
            if (value == null || value < 0)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be positive.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBePositive(value, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBePositive<E>(long? value, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value < 0)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable long <paramref name="value"/> to be positive.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int64}"/> value to be checked. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBePositive(value, (v) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBePositive<E>(long? value, Func<long?, E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value < 0)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        #endregion
    }
}