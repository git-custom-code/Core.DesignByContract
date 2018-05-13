namespace CustomCode.Core.DesignByContract
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Preconditions for <see cref="Nullable{Int32}"/> types.
    /// </summary>
    /// <remarks>
    /// https://stackoverflow.com/questions/15319025/methodimploptions-aggressiveinlining-vs-targetedpatchingoptout
    /// https://stackoverflow.com/questions/14937647/method-inlining-across-native-images-of-assemblies/14982340#14982340
    /// </remarks>
    public partial class Requires
    {
        #region Logic

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to fullfill the specified
        /// boolean <paramref name="condition"/>.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="condition"> A boolean condition that must be fullfilled by the specified value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeNegative(value);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBe(int? value, Func<int?, bool> condition,
            string parameterName = "Value", string errorMessage = "Value is invalid")
        {
            if (new Lazy<bool>(() => condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to fullfill the specified
        /// boolean <paramref name="condition"/>.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="condition"> A boolean condition that must be fullfilled by the specified value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeNegative(value, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBe<E>(int? value, Func<int?, bool> condition, Func<E> exceptionFactory)
            where E : Exception
        {
            if (new Lazy<bool>(() => condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to fullfill the specified
        /// boolean <paramref name="condition"/>.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="condition"> A boolean condition that must be fullfilled by the specified value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeNegative(value, (v) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBe<E>(int? value, Func<int?, bool> condition, Func<int?, E> exceptionFactory)
            where E : Exception
        {
            if (new Lazy<bool>(() => condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be between the specified
        /// <paramref name="minimum"/> and <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeBetween(value, 1, 10);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeBetween(int? value, int minimum, int maximum,
            string parameterName = "Value", string errorMessage = "Value must be between the specified minimum and maximum")
        {
            if (value == null || value < minimum || value > maximum)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be between the specified
        /// <paramref name="minimum"/> and <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeBetween(value, 1, 10, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeBetween<E>(int? value, int minimum, int maximum, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value < minimum || value > maximum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be between the specified
        /// <paramref name="minimum"/> and <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeBetween(value, 1, 10, (v, min, max) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeBetween<E>(int? value, int minimum, int maximum, Func<int?, int, int, E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value < minimum || value > maximum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, minimum, maximum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be greater than the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThan(int? value, int minimum,
            string parameterName = "Value", string errorMessage = "Value must be greater than the specified minimum")
        {
            if (value == null || value <= minimum)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be greater than the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThan<E>(int? value, int minimum, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value <= minimum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be greater than the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1, (v, min) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThan<E>(int? value, int minimum, Func<int?, int, E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value <= minimum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, minimum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be greater than or equal to the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThanOrEqualTo(int? value, int minimum,
            string parameterName = "Value", string errorMessage = "Value must be greater than or equal to the specified minimum")
        {
            if (value == null || value < minimum)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be greater than or equal to the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThanOrEqualTo<E>(int? value, int minimum, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value < minimum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be greater than or equal to the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1, (v, min) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThanOrEqualTo<E>(int? value, int minimum, Func<int?, int, E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value < minimum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, minimum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be less than the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThan(int? value, int maximum,
            string parameterName = "Value", string errorMessage = "Value must be less than the specified maximum")
        {
            if (value == null || value >= maximum)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be less than the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThan<E>(int? value, int maximum, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value >= maximum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be less than the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10, (v, max) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThan<E>(int? value, int maximum, Func<int?, int, E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value >= maximum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, maximum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be less than or equal to the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThanOrEqualTo(int? value, int maximum,
            string parameterName = "Value", string errorMessage = "Value must be less than or equal to the specified maximum")
        {
            if (value == null || value > maximum)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be less than or equal to the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThanOrEqualTo<E>(int? value, int maximum, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value > maximum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be less than or equal to the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10, (v, max) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThanOrEqualTo<E>(int? value, int maximum, Func<int?, int, E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value > maximum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, maximum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be negative.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeNegative(value);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeNegative(int? value, string parameterName = "Value", string errorMessage = "Value must be negative")
        {
            if (value == null || value >= 0)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be negative.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeNegative(value, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeNegative<E>(int? value, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value >= 0)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be negative.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeNegative(value, (v) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeNegative<E>(int? value, Func<int?, E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value >= 0)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be one of the expected values.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="expectedValues"> The expected values. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeOneOf(value, new[] { 1, 2, 10 });
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeOneOf(int? value, IEnumerable<int?> expectedValues,
            string parameterName = "Value", string errorMessage = "Value is invalid")
        {
            if (expectedValues.Any(v => v == value) == false)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be one of the expected values.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="expectedValues"> The expected values. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeOneOf(value, new[] { 1, 2, 10 }, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeOneOf<E>(int? value, IEnumerable<int?> expectedValues, Func<E> exceptionFactory)
            where E : Exception
        {
            if (expectedValues.Any(v => v == value) == false)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be one of the expected values.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="expectedValues"> The expected values. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeOneOf(value, new[] { 1, 2, 10 }, (v) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeOneOf<E>(int? value, IEnumerable<int?> expectedValues, Func<int?, IEnumerable<int?>, E> exceptionFactory)
            where E : Exception
        {
            if (expectedValues.Any(v => v == value) == false)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, expectedValues)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be positive.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBePositive(value);
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBePositive(int? value, string parameterName = "Value", string errorMessage = "Value must be positive")
        {
            if (value == null || value < 0)
            {
                throw new ArgumentException(errorMessage, parameterName);
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be positive.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBePositive(value, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBePositive<E>(int? value, Func<E> exceptionFactory)
            where E : Exception
        {
            if (value == null || value < 0)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
        }

        /// <summary>
        /// Precondition that requires a nullable integer <paramref name="value"/> to be positive.
        /// </summary>
        /// <param name="value"> The <see cref="Nullable{Int32}"/> value to be checked. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBePositive(value, (v) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBePositive<E>(int? value, Func<int?, E> exceptionFactory)
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