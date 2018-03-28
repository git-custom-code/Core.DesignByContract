#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Long", "Requires")]
    public sealed class RequiresLongTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Requires.ToBe(long, condition)")]
        public void LongToBeSuccessful()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBe(long, condition)")]
        public void LongToBeFailed()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(long, condition)")]
        public void LongToBeFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBe(long, condition)")]
        public void LongToBeFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Requires.ToBeBetween(long, min, max)")]
        public void LongToBeBetweenSuccessful()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeBetween(value, (long)1, (long)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeBetween(long, max, min)")]
        public void LongToBeBetweenFailed()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeBetween(value, (long)100, (long)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(long, max, min)")]
        public void LongToBeBetweenFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeBetween(value, (long)100, (long)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(long, max, min)")]
        public void LongToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeBetween(value, (long)100, (long)1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Requires.ToBeGreaterThan(long, min)")]
        public void LongToBeGreaterThanSuccessful()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeGreaterThan(value, (long)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(long, max)")]
        public void LongToBeGreaterThanFailed()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeGreaterThan(value, (long)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(long, max)")]
        public void LongToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeGreaterThan(value, (long)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(long, max)")]
        public void LongToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeGreaterThan(value, (long)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(long, min)")]
        public void LongToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (long)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(long, max)")]
        public void LongToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (long)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(long, max)")]
        public void LongToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (long)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(long, max)")]
        public void LongToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (long)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Requires.ToBeLessThan(long, max)")]
        public void LongToBeLessThanSuccessful()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeLessThan(value, (long)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(long, min)")]
        public void LongToBeLessThanFailed()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeLessThan(value, (long)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(long, min)")]
        public void LongToBeLessThanFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeLessThan(value, (long)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(long, min)")]
        public void LongToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeLessThan(value, (long)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(long, max)")]
        public void LongToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (long)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(long, min)")]
        public void LongToBeLessThanOrEqualToFailed()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (long)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(long, min)")]
        public void LongToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (long)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(long, min)")]
        public void LongToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (long)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Requires.ToBeNegative(long)")]
        public void LongToBeNegativeSuccessful()
        {
            Given(() => (long)-42)
            .When(value => Requires.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Requires.ToBeNegative(long)")]
        public void LongToBeNegativeFailed()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(long)")]
        public void LongToBeNegativeFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(long)")]
        public void LongToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Requires.ToBeOneOf(long, others[])")]
        public void LongToBeOneOfSuccessful()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeOneOf(value, new long[] { 1L, 2L, 42L }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(long, others[])")]
        public void LongToBeOneOfFailed()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeOneOf(value, new long[] { 1L, 2L }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(long, others[])")]
        public void LongToBeOneOfFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeOneOf(value, new long[] { 1L, 2L }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(long, others[])")]
        public void LongToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBeOneOf(value, new long[] { 1L, 2L }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Requires.ToBePositive(long)")]
        public void LongToBePositiveSuccessful()
        {
            Given(() => (long)42)
            .When(value => Requires.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBePositive(long)")]
        public void LongToBePositiveFailed()
        {
            Given(() => (long)-42)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(long)")]
        public void LongToBePositiveFailedWithCustomException()
        {
            Given(() => (long)-42)
            .When(value => Requires.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(long)")]
        public void LongToBePositiveFailedWithParameterizedException()
        {
            Given(() => (long)-42)
            .When(value => Requires.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}