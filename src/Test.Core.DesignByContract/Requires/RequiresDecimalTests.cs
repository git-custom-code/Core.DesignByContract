#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Decimal", "Requires")]
    public sealed class RequiresDecimalTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Requires.ToBe(decimal, condition)")]
        public void DecimalToBeSuccessful()
        {
            Given(() => 42m)
            .When(value => Requires.ToBe(value, v => v == 42m))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Requires.ToBe(decimal, condition)")]
        public void DecimalToBeFailed()
        {
            Given(() => 42m)
            .When(value => Requires.ToBe(value, v => v != 42m))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(decimal, condition)")]
        public void DecimalToBeFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBe(value, v => v != 42m, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBe(decimal, condition)")]
        public void DecimalToBeFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBe(value, v => v != 42m, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Requires.ToBeBetween(decimal, min, max)")]
        public void DecimalToBeBetweenSuccessful()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeBetween(value, 1m, 100m))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Requires.ToBeBetween(decimal, max, min)")]
        public void DecimalToBeBetweenFailed()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeBetween(value, 100m, 1m))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(decimal, max, min)")]
        public void DecimalToBeBetweenFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeBetween(value, 100m, 1m, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(decimal, max, min)")]
        public void DecimalToBeBetweenFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeBetween(value, 100m, 1m, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Requires.ToBeGreaterThan(decimal, min)")]
        public void DecimalToBeGreaterThanSuccessful()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeGreaterThan(value, 1m))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(decimal, max)")]
        public void DecimalToBeGreaterThanFailed()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeGreaterThan(value, 100m))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(decimal, max)")]
        public void DecimalToBeGreaterThanFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeGreaterThan(value, 100m, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(decimal, max)")]
        public void DecimalToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeGreaterThan(value, 100m, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(decimal, min)")]
        public void DecimalToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 1m))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(decimal, max)")]
        public void DecimalToBeGreaterThanOrEqualToFailed()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100m))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(decimal, max)")]
        public void DecimalToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100m, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(decimal, max)")]
        public void DecimalToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100m, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Requires.ToBeLessThan(decimal, max)")]
        public void DecimalToBeLessThanSuccessful()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeLessThan(value, 100m))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(decimal, min)")]
        public void DecimalToBeLessThanFailed()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeLessThan(value, 1m))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(decimal, min)")]
        public void DecimalToBeLessThanFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeLessThan(value, 1m, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(decimal, min)")]
        public void DecimalToBeLessThanFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeLessThan(value, 1m, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(decimal, max)")]
        public void DecimalToBeLessThanOrEqualToSuccessful()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 100m))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(decimal, min)")]
        public void DecimalToBeLessThanOrEqualToFailed()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1m))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(decimal, min)")]
        public void DecimalToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1m, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(decimal, min)")]
        public void DecimalToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1m, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Requires.ToBeNegative(decimal)")]
        public void DecimalToBeNegativeSuccessful()
        {
            Given(() => (decimal)-42m)
            .When(value => Requires.ToBeNegative(value))
            .Then(value => value.Should().Be(-42m));
        }

        [Fact(DisplayName = "Requires.ToBeNegative(decimal)")]
        public void DecimalToBeNegativeFailed()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(decimal)")]
        public void DecimalToBeNegativeFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(decimal)")]
        public void DecimalToBeNegativeFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Requires.ToBeOneOf(decimal, others[])")]
        public void DecimalToBeOneOfSuccessful()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeOneOf(value, new[] { 1m, 2m, 42m }))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(decimal, others[])")]
        public void DecimalToBeOneOfFailed()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeOneOf(value, new[] { 1m, 2m }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(decimal, others[])")]
        public void DecimalToBeOneOfFailedWithCustomException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeOneOf(value, new[] { 1m, 2m }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(decimal, others[])")]
        public void DecimalToBeOneOfFailedWithParameterizedException()
        {
            Given(() => 42m)
            .When(value => Requires.ToBeOneOf(value, new[] { 1m, 2m }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Requires.ToBePositive(decimal)")]
        public void DecimalToBePositiveSuccessful()
        {
            Given(() => 42m)
            .When(value => Requires.ToBePositive(value))
            .Then(value => value.Should().Be(42m));
        }

        [Fact(DisplayName = "Requires.ToBePositive(decimal)")]
        public void DecimalToBePositiveFailed()
        {
            Given(() => (decimal)-42m)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }


        [Fact(DisplayName = "Requires.ToBePositive(decimal)")]
        public void DecimalToBePositiveFailedWithCustomException()
        {
            Given(() => (decimal)-42m)
            .When(value => Requires.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(decimal)")]
        public void DecimalToBePositiveFailedWithParameterizedException()
        {
            Given(() => (decimal)-42m)
            .When(value => Requires.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}