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
        public void ShortToBeSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBe(sbyte, condition)")]
        public void ShortToBeFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(sbyte, condition)")]
        public void ShortToBeFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(sbyte, condition)")]
        public void ShortToBeFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Ensures.ToBeBetween(sbyte, min, max)")]
        public void ShortToBeBetweenSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeBetween(value, (sbyte)1, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(sbyte, max, min)")]
        public void ShortToBeBetweenFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeBetween(value, (sbyte)100, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(sbyte, max, min)")]
        public void ShortToBeBetweenFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeBetween(value, (sbyte)100, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(sbyte, max, min)")]
        public void ShortToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeBetween(value, (sbyte)100, (sbyte)1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(sbyte, min)")]
        public void ShortToBeGreaterThanSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThan(value, (sbyte)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(sbyte, max)")]
        public void ShortToBeGreaterThanFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThan(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(sbyte, max)")]
        public void ShortToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThan(value, (sbyte)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(sbyte, max)")]
        public void ShortToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThan(value, (sbyte)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(sbyte, min)")]
        public void ShortToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (sbyte)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(sbyte, max)")]
        public void ShortToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(sbyte, max)")]
        public void ShortToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (sbyte)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(sbyte, max)")]
        public void ShortToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (sbyte)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Ensures.ToBeLessThan(sbyte, max)")]
        public void ShortToBeLessThanSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThan(value, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(sbyte, min)")]
        public void ShortToBeLessThanFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThan(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(sbyte, min)")]
        public void ShortToBeLessThanFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThan(value, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(sbyte, min)")]
        public void ShortToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThan(value, (sbyte)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(sbyte, max)")]
        public void ShortToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(sbyte, min)")]
        public void ShortToBeLessThanOrEqualToFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(sbyte, min)")]
        public void ShortToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(sbyte, min)")]
        public void ShortToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (sbyte)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Ensures.ToBeNegative(sbyte)")]
        public void ShortToBeNegativeSuccessful()
        {
            Given(() => (sbyte)-42)
            .When(value => Ensures.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(sbyte)")]
        public void ShortToBeNegativeFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(sbyte)")]
        public void ShortToBeNegativeFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(sbyte)")]
        public void ShortToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Ensures.ToBeOneOf(sbyte, others[])")]
        public void ShortToBeOneOfSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(sbyte, others[])")]
        public void ShortToBeOneOfFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(sbyte, others[])")]
        public void ShortToBeOneOfFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(sbyte, others[])")]
        public void ShortToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Ensures.ToBePositive(sbyte)")]
        public void ShortToBePositiveSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Ensures.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBePositive(sbyte)")]
        public void ShortToBePositiveFailed()
        {
            Given(() => (sbyte)-42)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(sbyte)")]
        public void ShortToBePositiveFailedWithCustomException()
        {
            Given(() => (sbyte)-42)
            .When(value => Ensures.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(sbyte)")]
        public void ShortToBePositiveFailedWithParameterizedException()
        {
            Given(() => (sbyte)-42)
            .When(value => Ensures.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}