#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Sbyte", "Ensures")]
    public sealed class EnsuresSbyteTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Ensures.ToBe(sbyte, condition)")]
        public void SbyteToBeSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBe(sbyte, condition)")]
        public void SbyteToBeFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(sbyte, condition)")]
        public void SbyteToBeFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(sbyte, condition)")]
        public void SbyteToBeFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Ensures.ToBeBetween(sbyte, min, max)")]
        public void SbyteToBeBetweenSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeBetween(value, (sbyte)1, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(sbyte, max, min)")]
        public void SbyteToBeBetweenFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeBetween(value, (sbyte)100, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(sbyte, max, min)")]
        public void SbyteToBeBetweenFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeBetween(value, (sbyte)100, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(sbyte, max, min)")]
        public void SbyteToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeBetween(value, (sbyte)100, (sbyte)1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(sbyte, min)")]
        public void SbyteToBeGreaterThanSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThan(value, (sbyte)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(sbyte, max)")]
        public void SbyteToBeGreaterThanFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThan(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(sbyte, max)")]
        public void SbyteToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThan(value, (sbyte)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(sbyte, max)")]
        public void SbyteToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThan(value, (sbyte)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(sbyte, min)")]
        public void SbyteToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (sbyte)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(sbyte, max)")]
        public void SbyteToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(sbyte, max)")]
        public void SbyteToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (sbyte)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(sbyte, max)")]
        public void SbyteToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (sbyte)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Ensures.ToBeLessThan(sbyte, max)")]
        public void SbyteToBeLessThanSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThan(value, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(sbyte, min)")]
        public void SbyteToBeLessThanFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThan(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(sbyte, min)")]
        public void SbyteToBeLessThanFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThan(value, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(sbyte, min)")]
        public void SbyteToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThan(value, (sbyte)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(sbyte, max)")]
        public void SbyteToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(sbyte, min)")]
        public void SbyteToBeLessThanOrEqualToFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(sbyte, min)")]
        public void SbyteToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(sbyte, min)")]
        public void SbyteToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (sbyte)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Ensures.ToBeNegative(sbyte)")]
        public void SbyteToBeNegativeSuccessful()
        {
            Given(() => (sbyte)-42)
            .When(value => Ensures.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(sbyte)")]
        public void SbyteToBeNegativeFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(sbyte)")]
        public void SbyteToBeNegativeFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(sbyte)")]
        public void SbyteToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Ensures.ToBeOneOf(sbyte, others[])")]
        public void SbyteToBeOneOfSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(sbyte, others[])")]
        public void SbyteToBeOneOfFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(sbyte, others[])")]
        public void SbyteToBeOneOfFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(sbyte, others[])")]
        public void SbyteToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Ensures.ToBePositive(sbyte)")]
        public void SbyteToBePositiveSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBePositive(sbyte)")]
        public void SbyteToBePositiveFailed()
        {
            Given(() => (sbyte)-42)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(sbyte)")]
        public void SbyteToBePositiveFailedWithCustomException()
        {
            Given(() => (sbyte)-42)
            .When(value => Ensures.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(sbyte)")]
        public void SbyteToBePositiveFailedWithParameterizedException()
        {
            Given(() => (sbyte)-42)
            .When(value => Ensures.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}