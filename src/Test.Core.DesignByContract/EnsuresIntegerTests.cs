#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Integer", "Ensures")]
    public sealed class EnsuresIntegerTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Ensures.ToBe(int, condition)")]
        public void IntegerToBeSuccessful()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBe(int, condition)")]
        public void IntegerToBeFailed()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(int, condition)")]
        public void IntegerToBeFailedWithCustomException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(int, condition)")]
        public void IntegerToBeFailedWithParameterizedException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBe(value, v => v == 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Ensures.ToBeBetween(int, min, max)")]
        public void IntegerToBeBetweenSuccessful()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeBetween(value, 1, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(int, max, min)")]
        public void IntegerToBeBetweenFailed()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeBetween(value, 100, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(int, max, min)")]
        public void IntegerToBeBetweenFailedWithCustomException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeBetween(value, 100, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(int, max, min)")]
        public void IntegerToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeBetween(value, 100, 1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(int, min)")]
        public void IntegerToBeGreaterThanSuccessful()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeGreaterThan(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(int, max)")]
        public void IntegerToBeGreaterThanFailed()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeGreaterThan(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(int, max)")]
        public void IntegerToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeGreaterThan(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(int, max)")]
        public void IntegerToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeGreaterThan(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(int, min)")]
        public void IntegerToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(int, max)")]
        public void IntegerToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(int, max)")]
        public void IntegerToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(int, max)")]
        public void IntegerToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Ensures.ToBeLessThan(int, max)")]
        public void IntegerToBeLessThanSuccessful()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeLessThan(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(int, min)")]
        public void IntegerToBeLessThanFailed()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeLessThan(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(int, min)")]
        public void IntegerToBeLessThanFailedWithCustomException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeLessThan(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(int, min)")]
        public void IntegerToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeLessThan(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(int, max)")]
        public void IntegerToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(int, min)")]
        public void IntegerToBeLessThanOrEqualToFailed()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(int, min)")]
        public void IntegerToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(int, min)")]
        public void IntegerToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Ensures.ToBeNegative(int)")]
        public void IntegerToBeNegativeSuccessful()
        {
            Given(() => (int)-42)
            .When(value => Ensures.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(int)")]
        public void IntegerToBeNegativeFailed()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(int)")]
        public void IntegerToBeNegativeFailedWithCustomException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(int)")]
        public void IntegerToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Ensures.ToBeOneOf(int, others[])")]
        public void IntegerToBeOneOfSuccessful()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(int, others[])")]
        public void IntegerToBeOneOfFailed()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(int, others[])")]
        public void IntegerToBeOneOfFailedWithCustomException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(int, others[])")]
        public void IntegerToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Ensures.ToBePositive(int)")]
        public void IntegerToBePositiveSuccessful()
        {
            Given(() => (int)42)
            .When(value => Ensures.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBePositive(int)")]
        public void IntegerToBePositiveFailed()
        {
            Given(() => (int)-42)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(int)")]
        public void IntegerToBePositiveFailedWithCustomException()
        {
            Given(() => (int)-42)
            .When(value => Ensures.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(int)")]
        public void IntegerToBePositiveFailedWithParameterizedException()
        {
            Given(() => (int)-42)
            .When(value => Ensures.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}