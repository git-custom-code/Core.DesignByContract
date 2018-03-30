#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Float", "Ensures")]
    public sealed class EnsuresNullableFloatTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Ensures.ToBe(float?, condition)")]
        public void NullableFloatToBeSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBe(float?, condition)")]
        public void NullableFloatToBeNullSuccessful()
        {
            Given(() => (float?)null)
            .When(value => Ensures.ToBe(value, v => v == null))
            .Then(value => value.Should().Be(null));
        }

        [Fact(DisplayName = "Ensures.ToBe(float?, condition)")]
        public void NullableFloatToBeFailed()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(float?, condition)")]
        public void NullableFloatToBeNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Ensures.ToBe(value, v => v != null))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(float?, condition)")]
        public void NullableFloatToBeFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(float?, condition)")]
        public void NullableFloatToBeFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Ensures.ToBeBetween(float?, min, max)")]
        public void NullableFloatToBeBetweenSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeBetween(value, 1, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(float?, max, min)")]
        public void NullableFloatToBeBetweenFailed()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeBetween(value, 100, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(float?, max, min)")]
        public void NullableFloatToBeBetweenNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Ensures.ToBeBetween(value, 100, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(float?, max, min)")]
        public void NullableFloatToBeBetweenFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeBetween(value, 100, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(float?, max, min)")]
        public void NullableFloatToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeBetween(value, 100, 1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(float?, min)")]
        public void NullableFloatToBeGreaterThanSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeGreaterThan(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(float?, max)")]
        public void NullableFloatToBeGreaterThanFailed()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeGreaterThan(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(float?, max)")]
        public void NullableFloatToBeGreaterThanNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Ensures.ToBeGreaterThan(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(float?, max)")]
        public void NullableFloatToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeGreaterThan(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(float?, max)")]
        public void NullableFloatToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeGreaterThan(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(float?, min)")]
        public void NullableFloatToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(float?, max)")]
        public void NullableFloatToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(float?, max)")]
        public void NullableFloatToBeGreaterThanOrEqualToNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(float?, max)")]
        public void NullableFloatToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(float?, max)")]
        public void NullableFloatToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Ensures.ToBeLessThan(float?, max)")]
        public void NullableFloatToBeLessThanSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeLessThan(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(float?, min)")]
        public void NullableFloatToBeLessThanFailed()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeLessThan(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(float?, min)")]
        public void NullableFloatToBeLessThanNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Ensures.ToBeLessThan(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(float?, min)")]
        public void NullableFloatToBeLessThanFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeLessThan(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(float?, min)")]
        public void NullableFloatToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeLessThan(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(float?, max)")]
        public void NullableFloatToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(float?, min)")]
        public void NullableFloatToBeLessThanOrEqualToFailed()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(float?, min)")]
        public void NullableFloatToBeLessThanOrEqualToNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(float?, min)")]
        public void NullableFloatToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(float?, min)")]
        public void NullableFloatToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Ensures.ToBeNegative(float?)")]
        public void NullableFloatToBeNegativeSuccessful()
        {
            Given(() => (float?)-42)
            .When(value => Ensures.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(float?)")]
        public void NullableFloatToBeNegativeFailed()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(float?)")]
        public void NullableFloatToBeNegativeNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(float?)")]
        public void NullableFloatToBeNegativeFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(float?)")]
        public void NullableFloatToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Ensures.ToBeOneOf(float?, others[])")]
        public void NullableFloatToBeOneOfSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeOneOf(value, new float?[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(float?, others[])")]
        public void NullableFloatToBeOneOfFailed()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeOneOf(value, new float?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(float?, others[])")]
        public void NullableFloatToBeOneOfNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Ensures.ToBeOneOf(value, new float?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(float?, others[])")]
        public void NullableFloatToBeOneOfFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeOneOf(value, new float?[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(float?, others[])")]
        public void NullableFloatToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBeOneOf(value, new float?[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Ensures.ToBePositive(float?)")]
        public void NullableFloatToBePositiveSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Ensures.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBePositive(float?)")]
        public void NullableFloatToBePositiveFailed()
        {
            Given(() => (float?)-42)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(float?)")]
        public void NullableFloatToBePositiveNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(float?)")]
        public void NullableFloatToBePositiveFailedWithCustomException()
        {
            Given(() => (float?)-42)
            .When(value => Ensures.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(float?)")]
        public void NullableFloatToBePositiveFailedWithParameterizedException()
        {
            Given(() => (float?)-42)
            .When(value => Ensures.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}