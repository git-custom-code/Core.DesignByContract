#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Short", "Requires")]
    public sealed class RequiresNullableShortTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Requires.ToBe(short?, condition)")]
        public void NullableShortToBeSuccessful()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBe(short?, condition)")]
        public void NullableShortToBeNullSuccessful()
        {
            Given(() => (short?)null)
            .When(value => Requires.ToBe(value, v => v == null))
            .Then(value => value.Should().Be(null));
        }

        [Fact(DisplayName = "Requires.ToBe(short?, condition)")]
        public void NullableShortToBeFailed()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(short?, condition)")]
        public void NullableShortToBeNullFailed()
        {
            Given(() => (short?)null)
            .When(value => Requires.ToBe(value, v => v != null))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(short?, condition)")]
        public void NullableShortToBeFailedWithCustomException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBe(short?, condition)")]
        public void NullableShortToBeFailedWithParameterizedException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Requires.ToBeBetween(short?, min, max)")]
        public void NullableShortToBeBetweenSuccessful()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeBetween(value, (short)1, (short)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeBetween(short?, max, min)")]
        public void NullableShortToBeBetweenFailed()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeBetween(value, (short)100, (short)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(short?, max, min)")]
        public void NullableShortToBeBetweenNullFailed()
        {
            Given(() => (short?)null)
            .When(value => Requires.ToBeBetween(value, (short)100, (short)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(short?, max, min)")]
        public void NullableShortToBeBetweenFailedWithCustomException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeBetween(value, (short)100, (short)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(short?, max, min)")]
        public void NullableShortToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeBetween(value, (short)100, (short)1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Requires.ToBeGreaterThan(short?, min)")]
        public void NullableShortToBeGreaterThanSuccessful()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeGreaterThan(value, (short)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(short?, max)")]
        public void NullableShortToBeGreaterThanFailed()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeGreaterThan(value, (short)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(short?, max)")]
        public void NullableShortToBeGreaterThanNullFailed()
        {
            Given(() => (short?)null)
            .When(value => Requires.ToBeGreaterThan(value, (short)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(short?, max)")]
        public void NullableShortToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeGreaterThan(value, (short)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(short?, max)")]
        public void NullableShortToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeGreaterThan(value, (short)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(short?, min)")]
        public void NullableShortToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (short)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(short?, max)")]
        public void NullableShortToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (short)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(short?, max)")]
        public void NullableShortToBeGreaterThanOrEqualToNullFailed()
        {
            Given(() => (short?)null)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (short)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(short?, max)")]
        public void NullableShortToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (short)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(short?, max)")]
        public void NullableShortToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (short)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Requires.ToBeLessThan(short?, max)")]
        public void NullableShortToBeLessThanSuccessful()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeLessThan(value, (short)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(short?, min)")]
        public void NullableShortToBeLessThanFailed()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeLessThan(value, (short)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(short?, min)")]
        public void NullableShortToBeLessThanNullFailed()
        {
            Given(() => (short?)null)
            .When(value => Requires.ToBeLessThan(value, (short)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(short?, min)")]
        public void NullableShortToBeLessThanFailedWithCustomException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeLessThan(value, (short)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(short?, min)")]
        public void NullableShortToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeLessThan(value, (short)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(short?, max)")]
        public void NullableShortToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (short)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(short?, min)")]
        public void NullableShortToBeLessThanOrEqualToFailed()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (short)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(short?, min)")]
        public void NullableShortToBeLessThanOrEqualToNullFailed()
        {
            Given(() => (short?)null)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (short)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(short?, min)")]
        public void NullableShortToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (short)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(short?, min)")]
        public void NullableShortToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (short)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Requires.ToBeNegative(short?)")]
        public void NullableShortToBeNegativeSuccessful()
        {
            Given(() => (short?)-42)
            .When(value => Requires.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Requires.ToBeNegative(short?)")]
        public void NullableShortToBeNegativeFailed()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(short?)")]
        public void NullableShortToBeNegativeNullFailed()
        {
            Given(() => (short?)null)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(short?)")]
        public void NullableShortToBeNegativeFailedWithCustomException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(short?)")]
        public void NullableShortToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Requires.ToBeOneOf(short?, others[])")]
        public void NullableShortToBeOneOfSuccessful()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeOneOf(value, new short?[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(short?, others[])")]
        public void NullableShortToBeOneOfFailed()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeOneOf(value, new short?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(short?, others[])")]
        public void NullableShortToBeOneOfNullFailed()
        {
            Given(() => (short?)null)
            .When(value => Requires.ToBeOneOf(value, new short?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(short?, others[])")]
        public void NullableShortToBeOneOfFailedWithCustomException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeOneOf(value, new short?[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(short?, others[])")]
        public void NullableShortToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBeOneOf(value, new short?[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Requires.ToBePositive(short?)")]
        public void NullableShortToBePositiveSuccessful()
        {
            Given(() => (short?)42)
            .When(value => Requires.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBePositive(short?)")]
        public void NullableShortToBePositiveFailed()
        {
            Given(() => (short?)-42)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(short?)")]
        public void NullableShortToBePositiveNullFailed()
        {
            Given(() => (short?)null)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(short?)")]
        public void NullableShortToBePositiveFailedWithCustomException()
        {
            Given(() => (short?)-42)
            .When(value => Requires.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(short?)")]
        public void NullableShortToBePositiveFailedWithParameterizedException()
        {
            Given(() => (short?)-42)
            .When(value => Requires.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}