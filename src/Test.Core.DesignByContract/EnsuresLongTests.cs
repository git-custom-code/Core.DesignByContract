#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Long", "Ensures")]
    public sealed class EnsuresLongTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Ensures.ToBe(long, condition)")]
        public void LongToBeSuccessful()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBe(long, condition)")]
        public void LongToBeFailed()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(long, condition)")]
        public void LongToBeFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(long, condition)")]
        public void LongToBeFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Ensures.ToBeBetween(long, min, max)")]
        public void LongToBeBetweenSuccessful()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeBetween(value, (long)1, (long)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(long, max, min)")]
        public void LongToBeBetweenFailed()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeBetween(value, (long)100, (long)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(long, max, min)")]
        public void LongToBeBetweenFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeBetween(value, (long)100, (long)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(long, max, min)")]
        public void LongToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeBetween(value, (long)100, (long)1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(long, min)")]
        public void LongToBeGreaterThanSuccessful()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeGreaterThan(value, (long)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(long, max)")]
        public void LongToBeGreaterThanFailed()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeGreaterThan(value, (long)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(long, max)")]
        public void LongToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeGreaterThan(value, (long)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(long, max)")]
        public void LongToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeGreaterThan(value, (long)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(long, min)")]
        public void LongToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (long)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(long, max)")]
        public void LongToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (long)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(long, max)")]
        public void LongToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (long)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(long, max)")]
        public void LongToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (long)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Ensures.ToBeLessThan(long, max)")]
        public void LongToBeLessThanSuccessful()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeLessThan(value, (long)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(long, min)")]
        public void LongToBeLessThanFailed()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeLessThan(value, (long)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(long, min)")]
        public void LongToBeLessThanFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeLessThan(value, (long)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(long, min)")]
        public void LongToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeLessThan(value, (long)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(long, max)")]
        public void LongToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (long)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(long, min)")]
        public void LongToBeLessThanOrEqualToFailed()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (long)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(long, min)")]
        public void LongToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (long)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(long, min)")]
        public void LongToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (long)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Ensures.ToBeNegative(long)")]
        public void LongToBeNegativeSuccessful()
        {
            Given(() => (long)-42)
            .When(value => Ensures.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(long)")]
        public void LongToBeNegativeFailed()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(long)")]
        public void LongToBeNegativeFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(long)")]
        public void LongToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Ensures.ToBeOneOf(long, others[])")]
        public void LongToBeOneOfSuccessful()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeOneOf(value, new long[] { 1L, 2L, 42L }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(long, others[])")]
        public void LongToBeOneOfFailed()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeOneOf(value, new long[] { 1L, 2L }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(long, others[])")]
        public void LongToBeOneOfFailedWithCustomException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeOneOf(value, new long[] { 1L, 2L }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(long, others[])")]
        public void LongToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBeOneOf(value, new long[] { 1L, 2L }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Ensures.ToBePositive(long)")]
        public void LongToBePositiveSuccessful()
        {
            Given(() => (long)42)
            .When(value => Ensures.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBePositive(long)")]
        public void LongToBePositiveFailed()
        {
            Given(() => (long)-42)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(long)")]
        public void LongToBePositiveFailedWithCustomException()
        {
            Given(() => (long)-42)
            .When(value => Ensures.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(long)")]
        public void LongToBePositiveFailedWithParameterizedException()
        {
            Given(() => (long)-42)
            .When(value => Ensures.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}