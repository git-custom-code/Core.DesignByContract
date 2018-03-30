#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Double", "Ensures")]
    public sealed class EnsuresNullableDoubleTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Ensures.ToBe(double?, condition)")]
        public void NullableDoubleToBeSuccessful()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBe(double?, condition)")]
        public void NullableDoubleToBeNullSuccessful()
        {
            Given(() => (double?)null)
            .When(value => Ensures.ToBe(value, v => v == null))
            .Then(value => value.Should().Be(null));
        }

        [Fact(DisplayName = "Ensures.ToBe(double?, condition)")]
        public void NullableDoubleToBeFailed()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(double?, condition)")]
        public void NullableDoubleToBeNullFailed()
        {
            Given(() => (double?)null)
            .When(value => Ensures.ToBe(value, v => v != null))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(double?, condition)")]
        public void NullableDoubleToBeFailedWithCustomException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(double?, condition)")]
        public void NullableDoubleToBeFailedWithParameterizedException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Ensures.ToBeBetween(double?, min, max)")]
        public void NullableDoubleToBeBetweenSuccessful()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeBetween(value, 1, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(double?, max, min)")]
        public void NullableDoubleToBeBetweenFailed()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeBetween(value, 100, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(double?, max, min)")]
        public void NullableDoubleToBeBetweenNullFailed()
        {
            Given(() => (double?)null)
            .When(value => Ensures.ToBeBetween(value, 100, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(double?, max, min)")]
        public void NullableDoubleToBeBetweenFailedWithCustomException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeBetween(value, 100, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(double?, max, min)")]
        public void NullableDoubleToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeBetween(value, 100, 1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(double?, min)")]
        public void NullableDoubleToBeGreaterThanSuccessful()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeGreaterThan(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(double?, max)")]
        public void NullableDoubleToBeGreaterThanFailed()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeGreaterThan(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(double?, max)")]
        public void NullableDoubleToBeGreaterThanNullFailed()
        {
            Given(() => (double?)null)
            .When(value => Ensures.ToBeGreaterThan(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(double?, max)")]
        public void NullableDoubleToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeGreaterThan(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(double?, max)")]
        public void NullableDoubleToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeGreaterThan(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(double?, min)")]
        public void NullableDoubleToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(double?, max)")]
        public void NullableDoubleToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(double?, max)")]
        public void NullableDoubleToBeGreaterThanOrEqualToNullFailed()
        {
            Given(() => (double?)null)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(double?, max)")]
        public void NullableDoubleToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(double?, max)")]
        public void NullableDoubleToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Ensures.ToBeLessThan(double?, max)")]
        public void NullableDoubleToBeLessThanSuccessful()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeLessThan(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(double?, min)")]
        public void NullableDoubleToBeLessThanFailed()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeLessThan(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(double?, min)")]
        public void NullableDoubleToBeLessThanNullFailed()
        {
            Given(() => (double?)null)
            .When(value => Ensures.ToBeLessThan(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(double?, min)")]
        public void NullableDoubleToBeLessThanFailedWithCustomException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeLessThan(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(double?, min)")]
        public void NullableDoubleToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeLessThan(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(double?, max)")]
        public void NullableDoubleToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(double?, min)")]
        public void NullableDoubleToBeLessThanOrEqualToFailed()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(double?, min)")]
        public void NullableDoubleToBeLessThanOrEqualToNullFailed()
        {
            Given(() => (double?)null)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(double?, min)")]
        public void NullableDoubleToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(double?, min)")]
        public void NullableDoubleToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Ensures.ToBeNegative(double?)")]
        public void NullableDoubleToBeNegativeSuccessful()
        {
            Given(() => (double?)-42)
            .When(value => Ensures.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(double?)")]
        public void NullableDoubleToBeNegativeFailed()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(double?)")]
        public void NullableDoubleToBeNegativeNullFailed()
        {
            Given(() => (double?)null)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(double?)")]
        public void NullableDoubleToBeNegativeFailedWithCustomException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(double?)")]
        public void NullableDoubleToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Ensures.ToBeOneOf(double?, others[])")]
        public void NullableDoubleToBeOneOfSuccessful()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeOneOf(value, new double?[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(double?, others[])")]
        public void NullableDoubleToBeOneOfFailed()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeOneOf(value, new double?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(double?, others[])")]
        public void NullableDoubleToBeOneOfNullFailed()
        {
            Given(() => (double?)null)
            .When(value => Ensures.ToBeOneOf(value, new double?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(double?, others[])")]
        public void NullableDoubleToBeOneOfFailedWithCustomException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeOneOf(value, new double?[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(double?, others[])")]
        public void NullableDoubleToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBeOneOf(value, new double?[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Ensures.ToBePositive(double?)")]
        public void NullableDoubleToBePositiveSuccessful()
        {
            Given(() => (double?)42)
            .When(value => Ensures.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBePositive(double?)")]
        public void NullableDoubleToBePositiveFailed()
        {
            Given(() => (double?)-42)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(double?)")]
        public void NullableDoubleToBePositiveNullFailed()
        {
            Given(() => (double?)null)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(double?)")]
        public void NullableDoubleToBePositiveFailedWithCustomException()
        {
            Given(() => (double?)-42)
            .When(value => Ensures.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(double?)")]
        public void NullableDoubleToBePositiveFailedWithParameterizedException()
        {
            Given(() => (double?)-42)
            .When(value => Ensures.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}