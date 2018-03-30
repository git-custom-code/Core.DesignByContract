#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Decimal", "Requires")]
    public sealed class RequiresNullableDecimalTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Requires.ToBe(decimal?, condition)")]
        public void NullableDecimalToBeSuccessful()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBe(decimal?, condition)")]
        public void NullableDecimalToBeNullSuccessful()
        {
            Given(() => (decimal?)null)
            .When(value => Requires.ToBe(value, v => v == null))
            .Then(value => value.Should().Be(null));
        }

        [Fact(DisplayName = "Requires.ToBe(decimal?, condition)")]
        public void NullableDecimalToBeFailed()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(decimal?, condition)")]
        public void NullableDecimalToBeNullFailed()
        {
            Given(() => (decimal?)null)
            .When(value => Requires.ToBe(value, v => v != null))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(decimal?, condition)")]
        public void NullableDecimalToBeFailedWithCustomException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBe(decimal?, condition)")]
        public void NullableDecimalToBeFailedWithParameterizedException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Requires.ToBeBetween(decimal?, min, max)")]
        public void NullableDecimalToBeBetweenSuccessful()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeBetween(value, 1, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeBetween(decimal?, max, min)")]
        public void NullableDecimalToBeBetweenFailed()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeBetween(value, 100, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(decimal?, max, min)")]
        public void NullableDecimalToBeBetweenNullFailed()
        {
            Given(() => (decimal?)null)
            .When(value => Requires.ToBeBetween(value, 100, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(decimal?, max, min)")]
        public void NullableDecimalToBeBetweenFailedWithCustomException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeBetween(value, 100, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(decimal?, max, min)")]
        public void NullableDecimalToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeBetween(value, 100, 1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Requires.ToBeGreaterThan(decimal?, min)")]
        public void NullableDecimalToBeGreaterThanSuccessful()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeGreaterThan(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(decimal?, max)")]
        public void NullableDecimalToBeGreaterThanFailed()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeGreaterThan(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(decimal?, max)")]
        public void NullableDecimalToBeGreaterThanNullFailed()
        {
            Given(() => (decimal?)null)
            .When(value => Requires.ToBeGreaterThan(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(decimal?, max)")]
        public void NullableDecimalToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeGreaterThan(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(decimal?, max)")]
        public void NullableDecimalToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeGreaterThan(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(decimal?, min)")]
        public void NullableDecimalToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(decimal?, max)")]
        public void NullableDecimalToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(decimal?, max)")]
        public void NullableDecimalToBeGreaterThanOrEqualToNullFailed()
        {
            Given(() => (decimal?)null)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(decimal?, max)")]
        public void NullableDecimalToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(decimal?, max)")]
        public void NullableDecimalToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Requires.ToBeLessThan(decimal?, max)")]
        public void NullableDecimalToBeLessThanSuccessful()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeLessThan(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(decimal?, min)")]
        public void NullableDecimalToBeLessThanFailed()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeLessThan(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(decimal?, min)")]
        public void NullableDecimalToBeLessThanNullFailed()
        {
            Given(() => (decimal?)null)
            .When(value => Requires.ToBeLessThan(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(decimal?, min)")]
        public void NullableDecimalToBeLessThanFailedWithCustomException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeLessThan(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(decimal?, min)")]
        public void NullableDecimalToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeLessThan(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(decimal?, max)")]
        public void NullableDecimalToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(decimal?, min)")]
        public void NullableDecimalToBeLessThanOrEqualToFailed()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(decimal?, min)")]
        public void NullableDecimalToBeLessThanOrEqualToNullFailed()
        {
            Given(() => (decimal?)null)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(decimal?, min)")]
        public void NullableDecimalToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(decimal?, min)")]
        public void NullableDecimalToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Requires.ToBeNegative(decimal?)")]
        public void NullableDecimalToBeNegativeSuccessful()
        {
            Given(() => (decimal?)-42)
            .When(value => Requires.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Requires.ToBeNegative(decimal?)")]
        public void NullableDecimalToBeNegativeFailed()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(decimal?)")]
        public void NullableDecimalToBeNegativeNullFailed()
        {
            Given(() => (decimal?)null)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(decimal?)")]
        public void NullableDecimalToBeNegativeFailedWithCustomException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(decimal?)")]
        public void NullableDecimalToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Requires.ToBeOneOf(decimal?, others[])")]
        public void NullableDecimalToBeOneOfSuccessful()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeOneOf(value, new decimal?[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(decimal?, others[])")]
        public void NullableDecimalToBeOneOfFailed()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeOneOf(value, new decimal?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(decimal?, others[])")]
        public void NullableDecimalToBeOneOfNullFailed()
        {
            Given(() => (decimal?)null)
            .When(value => Requires.ToBeOneOf(value, new decimal?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(decimal?, others[])")]
        public void NullableDecimalToBeOneOfFailedWithCustomException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeOneOf(value, new decimal?[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(decimal?, others[])")]
        public void NullableDecimalToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBeOneOf(value, new decimal?[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Requires.ToBePositive(decimal?)")]
        public void NullableDecimalToBePositiveSuccessful()
        {
            Given(() => (decimal?)42)
            .When(value => Requires.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBePositive(decimal?)")]
        public void NullableDecimalToBePositiveFailed()
        {
            Given(() => (decimal?)-42)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(decimal?)")]
        public void NullableDecimalToBePositiveNullFailed()
        {
            Given(() => (decimal?)null)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(decimal?)")]
        public void NullableDecimalToBePositiveFailedWithCustomException()
        {
            Given(() => (decimal?)-42)
            .When(value => Requires.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(decimal?)")]
        public void NullableDecimalToBePositiveFailedWithParameterizedException()
        {
            Given(() => (decimal?)-42)
            .When(value => Requires.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}