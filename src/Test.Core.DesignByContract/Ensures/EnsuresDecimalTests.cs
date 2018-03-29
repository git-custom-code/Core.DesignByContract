#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Decimal", "Ensures")]
    public sealed class EnsuresDecimalTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Ensures.ToBe(decimal, condition)")]
        public void DecimalToBeSuccessful()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBe(value, v => v == 42m))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Ensures.ToBe(decimal, condition)")]
        public void DecimalToBeFailed()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBe(value, v => v != 42m))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(decimal, condition)")]
        public void DecimalToBeFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBe(value, v => v != 42m, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(decimal, condition)")]
        public void DecimalToBeFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBe(value, v => v != 42m, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Ensures.ToBeBetween(decimal, min, max)")]
        public void DecimalToBeBetweenSuccessful()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeBetween(value, 1m, 100m))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(decimal, max, min)")]
        public void DecimalToBeBetweenFailed()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeBetween(value, 100m, 1m))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(decimal, max, min)")]
        public void DecimalToBeBetweenFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeBetween(value, 100m, 1m, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(decimal, max, min)")]
        public void DecimalToBeBetweenFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeBetween(value, 100m, 1m, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(decimal, min)")]
        public void DecimalToBeGreaterThanSuccessful()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeGreaterThan(value, 1m))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(decimal, max)")]
        public void DecimalToBeGreaterThanFailed()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeGreaterThan(value, 100m))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(decimal, max)")]
        public void DecimalToBeGreaterThanFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeGreaterThan(value, 100m, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(decimal, max)")]
        public void DecimalToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeGreaterThan(value, 100m, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(decimal, min)")]
        public void DecimalToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 1m))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(decimal, max)")]
        public void DecimalToBeGreaterThanOrEqualToFailed()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100m))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(decimal, max)")]
        public void DecimalToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100m, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(decimal, max)")]
        public void DecimalToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100m, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Ensures.ToBeLessThan(decimal, max)")]
        public void DecimalToBeLessThanSuccessful()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeLessThan(value, 100m))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(decimal, min)")]
        public void DecimalToBeLessThanFailed()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeLessThan(value, 1m))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(decimal, min)")]
        public void DecimalToBeLessThanFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeLessThan(value, 1m, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(decimal, min)")]
        public void DecimalToBeLessThanFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeLessThan(value, 1m, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(decimal, max)")]
        public void DecimalToBeLessThanOrEqualToSuccessful()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 100m))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(decimal, min)")]
        public void DecimalToBeLessThanOrEqualToFailed()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1m))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(decimal, min)")]
        public void DecimalToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1m, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(decimal, min)")]
        public void DecimalToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1m, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Ensures.ToBeNegative(decimal)")]
        public void DecimalToBeNegativeSuccessful()
        {
            Given(() => (decimal)-42m)
            .When(value => Ensures.ToBeNegative(value))
            .Then(value => value.Should().Be(-42m));
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(decimal)")]
        public void DecimalToBeNegativeFailed()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(decimal)")]
        public void DecimalToBeNegativeFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(decimal)")]
        public void DecimalToBeNegativeFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Ensures.ToBeOneOf(decimal, others[])")]
        public void DecimalToBeOneOfSuccessful()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1m, 2m, 42m }))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(decimal, others[])")]
        public void DecimalToBeOneOfFailed()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1m, 2m }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(decimal, others[])")]
        public void DecimalToBeOneOfFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1m, 2m }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(decimal, others[])")]
        public void DecimalToBeOneOfFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1m, 2m }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Ensures.ToBePositive(decimal)")]
        public void DecimalToBePositiveSuccessful()
        {
            Given(() => 42m)
            .When(value => Ensures.ToBePositive(value))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Ensures.ToBePositive(decimal)")]
        public void DecimalToBePositiveFailed()
        {
            Given(() => (decimal)-42m)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }


        [Fact(DisplayName = "Ensures.ToBePositive(decimal)")]
        public void DecimalToBePositiveFailedWithCustomException()
        {
            Given(() => (decimal)-42m)
            .When(value => Ensures.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(decimal)")]
        public void DecimalToBePositiveFailedWithParameterizedException()
        {
            Given(() => (decimal)-42m)
            .When(value => Ensures.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}