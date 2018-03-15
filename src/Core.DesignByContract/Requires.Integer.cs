namespace CustomCode.Core.DesignByContract
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
#if contracts_throw || contracts_trace
    using System.Linq;
#endif
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Preconditions for <see cref="int"/> types.
    /// </summary>
    /// <remarks>
    /// https://stackoverflow.com/questions/15319025/methodimploptions-aggressiveinlining-vs-targetedpatchingoptout
    /// https://stackoverflow.com/questions/14937647/method-inlining-across-native-images-of-assemblies/14982340#14982340
    /// </remarks>
    public partial class Requires
    {
#region Logic

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to fullfill the specified
        /// boolean <paramref name="condition"/>.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="condition"> A boolean condition that must be fullfilled by the specified value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeNegative(value);
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBe(int value, Func<int, bool> condition,
            string parameterName = "Value", string errorMessage = null)
        {
#if contracts_throw
            if (new Lazy<bool>(condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                throw new ArgumentException(errorMessage ?? $"{value} must be negative", parameterName);
            }
#elif contracts_trace
            if (new Lazy<bool>(condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                Debug.WriteLine($"{parameterName}: {errorMessage ?? $"{value} must be negative"}");
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to fullfill the specified
        /// boolean <paramref name="condition"/>.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="condition"> A boolean condition that must be fullfilled by the specified value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeNegative(value, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBe<E>(int value, Func<int, bool> condition, Func<E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (new Lazy<bool>(condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (new Lazy<bool>(condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to fullfill the specified
        /// boolean <paramref name="condition"/>.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="condition"> A boolean condition that must be fullfilled by the specified value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeNegative(value, (v) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBe<E>(int value, Func<int, bool> condition, Func<int, E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (new Lazy<bool>(condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (new Lazy<bool>(condition(value)).Value == false) // invoking the delegate directly will prevent inlining
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be between the specified
        /// <paramref name="minimum"/> and <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeBetween(value, 1, 10);
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeBetween(int value, int minimum, int maximum,
            string parameterName = "Value", string errorMessage = null)
        {
#if contracts_throw
            if (value < minimum || value > maximum)
            {
                throw new ArgumentException(errorMessage ?? $"{value} must be between {minimum} and {maximum}", parameterName);
            }
#elif contracts_trace
            if (value < minimum || value > maximum)
            {
                Debug.WriteLine($"{parameterName}: {errorMessage ?? $"{value} must be between {minimum} and {maximum}"}");
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be between the specified
        /// <paramref name="minimum"/> and <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeBetween(value, 1, 10, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeBetween<E>(int value, int minimum, int maximum, Func<E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value < minimum || value > maximum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value < minimum || value > maximum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be between the specified
        /// <paramref name="minimum"/> and <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeBetween(value, 1, 10, (v, min, max) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeBetween<E>(int value, int minimum, int maximum, Func<int, int, int, E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value < minimum || value > maximum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, minimum, maximum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value < minimum || value > maximum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, minimum, maximum)); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be greater than the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1);
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThan(int value, int minimum,
            string parameterName = "Value", string errorMessage = null)
        {
#if contracts_throw
            if (value <= minimum)
            {
                throw new ArgumentException(errorMessage ?? $"{value} must be greater than {minimum}", parameterName);
            }
#elif contracts_trace
            if (value <= minimum)
            {
                Debug.WriteLine($"{parameterName}: {errorMessage ?? $"{value} must be greater than {minimum}"}");
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be greater than the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThan<E>(int value, int minimum, Func<E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value <= minimum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value <= minimum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be greater than the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1, (v, min) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThan<E>(int value, int minimum, Func<int, int, E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value <= minimum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, minimum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value <= minimum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, minimum)); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be greater than or equal to the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1);
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThanOrEqualTo(int value, int minimum,
            string parameterName = "Value", string errorMessage = null)
        {
#if contracts_throw
            if (value < minimum)
            {
                throw new ArgumentException(errorMessage ?? $"{value} must be greater than or equal to {minimum}", parameterName);
            }
#elif contracts_trace
            if (value < minimum)
            {
                Debug.WriteLine($"{parameterName}: {errorMessage ?? $"{value} must be greater than or equal to {minimum}"}");
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be greater than or equal to the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThanOrEqualTo<E>(int value, int minimum, Func<E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value < minimum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value < minimum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be greater than or equal to the specified
        /// <paramref name="minimum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="minimum"> The allowed minimum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeGreaterThan(value, 1, (v, min) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeGreaterThanOrEqualTo<E>(int value, int minimum, Func<int, int, E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value < minimum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, minimum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value < minimum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, minimum)); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be less than the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10);
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThan(int value, int maximum,
            string parameterName = "Value", string errorMessage = null)
        {
#if contracts_throw
            if (value >= maximum)
            {
                throw new ArgumentException(errorMessage ?? $"{value} must be less than {maximum}", parameterName);
            }
#elif contracts_trace
            if (value >= maximum)
            {
                Debug.WriteLine($"{parameterName}: {errorMessage ?? $"{value} must be less than {maximum}"}");
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be less than the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThan<E>(int value, int maximum, Func<E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value >= maximum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value >= maximum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be less than the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10, (v, max) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThan<E>(int value, int maximum, Func<int, int, E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value >= maximum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, maximum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value >= maximum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, maximum)); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be less than or equal to the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10);
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThanOrEqualTo(int value, int maximum,
            string parameterName = "Value", string errorMessage = null)
        {
#if contracts_throw
            if (value > maximum)
            {
                throw new ArgumentException(errorMessage ?? $"{value} must be less than or equal to {maximum}", parameterName);
            }
#elif contracts_trace
            if (value > maximum)
            {
                Debug.WriteLine($"{parameterName}: {errorMessage ?? $"{value} must be less than or equal to {maximum}"}");
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be less than or equal to the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThanOrEqualTo<E>(int value, int maximum, Func<E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value > maximum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value > maximum)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be less than or equal to the specified
        /// <paramref name="maximum"/> value.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="maximum"> The allowed maximum value. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeLessThan(value, 10, (v, max) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeLessThanOrEqualTo<E>(int value, int maximum, Func<int, int, E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value > maximum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, maximum)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value > maximum)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, maximum)); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be negative.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeNegative(value);
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeNegative(int value, string parameterName = "Value", string errorMessage = null)
        {
#if contracts_throw
            if (value >= 0)
            {
                throw new ArgumentException(errorMessage ?? $"{value} must be negative", parameterName);
            }
#elif contracts_trace
            if (value >= 0)
            {
                Debug.WriteLine($"{parameterName}: {errorMessage ?? $"{value} must be negative"}");
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be negative.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeNegative(value, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeNegative<E>(int value, Func<E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value >= 0)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value >= 0)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be negative.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeNegative(value, (v) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeNegative<E>(int value, Func<int, E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value >= 0)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value >= 0)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be one of the expected values.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="expectedValues"> The expected values. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBeOneOf(value, new[] { 1, 2, 10 });
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeOneOf(int value, IEnumerable<int> expectedValues,
            string parameterName = "Value", string errorMessage = null)
        {
#if contracts_throw
            if (expectedValues.Any(v => v == value) == false)
            {
                throw new ArgumentException(errorMessage ?? $"{value} must be one of the following values: {string.Join("\", \"", expectedValues)}", parameterName);
            }
#elif contracts_trace
            if (expectedValues.Any(v => v == value) == false)
            {
                Debug.WriteLine($"{parameterName}: {errorMessage ?? $"{value} must be one of the following values: {string.Join("\", \"", expectedValues)}"}");
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be one of the expected values.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="expectedValues"> The expected values. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeOneOf(value, new[] { 1, 2, 10 }, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeOneOf<E>(int value, IEnumerable<int> expectedValues, Func<E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (expectedValues.Any(v => v == value) == false)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (expectedValues.Any(v => v == value) == false)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be one of the expected values.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="expectedValues"> The expected values. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBeOneOf(value, new[] { 1, 2, 10 }, (v) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBeOneOf<E>(int value, IEnumerable<int> expectedValues, Func<int, IEnumerable<int>, E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (expectedValues.Any(v => v == value) == false)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, expectedValues)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (expectedValues.Any(v => v == value) == false)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value, expectedValues)); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be positive.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="parameterName"> The name of the parameter to be checked. </param>
        /// <param name="errorMessage"> The error message that is shown when the <paramref name="value"/> check is not successfull. </param>
        /// <example>
        /// Requires.ToBePositive(value);
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBePositive(int value, string parameterName = "Value", string errorMessage = null)
        {
#if contracts_throw
            if (value < 0)
            {
                throw new ArgumentException(errorMessage ?? $"{value} must be positive", parameterName);
            }
#elif contracts_trace
            if (value < 0)
            {
                Debug.WriteLine($"{parameterName}: {errorMessage ?? $"{value} must be positive"}");
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be positive.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBePositive(value, () => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBePositive<E>(int value, Func<E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value < 0)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value < 0)
            {
                var factory = new Lazy<E>(exceptionFactory); // invoking the delegate directly will prevent inlining
                Debug.WriteLine(factory.Value.Message);
            }
#else
            return;
#endif
        }

        /// <summary>
        /// Precondition that requires an integer <paramref name="value"/> to be positive.
        /// </summary>
        /// <param name="value"> The <see cref="int"/> value to be checked. </param>
        /// <param name="exceptionFactory"> A delegate that creates the exception to be thrown. </param>
        /// <example>
        /// Requires.ToBePositive(value, (v) => new ArgumentException("Invalid value", "value"));
        /// </example>
        [Conditional("contracts_throw"), Conditional("contracts_trace")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ToBePositive<E>(int value, Func<int, E> exceptionFactory)
            where E : Exception
        {
#if contracts_throw
            if (value < 0)
            {
                var factory = new Lazy<E>(() => exceptionFactory(value)); // invoking the delegate directly will prevent inlining
                throw factory.Value;
            }
#elif contracts_trace
            if (value < 0)
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