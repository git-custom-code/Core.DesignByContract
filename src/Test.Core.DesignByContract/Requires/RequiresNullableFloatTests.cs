#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Float", "Requires")]
    public sealed class RequiresNullableFloatTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Requires.ToBe(float?, condition)")]
        public void NullableFloatToBeSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBe(float?, condition)")]
        public void NullableFloatToBeNullSuccessful()
        {
            Given(() => (float?)null)
            .When(value => Requires.ToBe(value, v => v == null))
            .Then(value => value.Should().Be(null));
        }

        [Fact(DisplayName = "Requires.ToBe(float?, condition)")]
        public void NullableFloatToBeFailed()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(float?, condition)")]
        public void NullableFloatToBeNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Requires.ToBe(value, v => v != null))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(float?, condition)")]
        public void NullableFloatToBeFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBe(float?, condition)")]
        public void NullableFloatToBeFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Requires.ToBeBetween(float?, min, max)")]
        public void NullableFloatToBeBetweenSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeBetween(value, 1, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeBetween(float?, max, min)")]
        public void NullableFloatToBeBetweenFailed()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeBetween(value, 100, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(float?, max, min)")]
        public void NullableFloatToBeBetweenNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Requires.ToBeBetween(value, 100, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(float?, max, min)")]
        public void NullableFloatToBeBetweenFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeBetween(value, 100, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(float?, max, min)")]
        public void NullableFloatToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeBetween(value, 100, 1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Requires.ToBeGreaterThan(float?, min)")]
        public void NullableFloatToBeGreaterThanSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeGreaterThan(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(float?, max)")]
        public void NullableFloatToBeGreaterThanFailed()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeGreaterThan(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(float?, max)")]
        public void NullableFloatToBeGreaterThanNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Requires.ToBeGreaterThan(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(float?, max)")]
        public void NullableFloatToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeGreaterThan(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(float?, max)")]
        public void NullableFloatToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeGreaterThan(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(float?, min)")]
        public void NullableFloatToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(float?, max)")]
        public void NullableFloatToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(float?, max)")]
        public void NullableFloatToBeGreaterThanOrEqualToNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(float?, max)")]
        public void NullableFloatToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(float?, max)")]
        public void NullableFloatToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Requires.ToBeLessThan(float?, max)")]
        public void NullableFloatToBeLessThanSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeLessThan(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(float?, min)")]
        public void NullableFloatToBeLessThanFailed()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeLessThan(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(float?, min)")]
        public void NullableFloatToBeLessThanNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Requires.ToBeLessThan(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(float?, min)")]
        public void NullableFloatToBeLessThanFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeLessThan(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(float?, min)")]
        public void NullableFloatToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeLessThan(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(float?, max)")]
        public void NullableFloatToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(float?, min)")]
        public void NullableFloatToBeLessThanOrEqualToFailed()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(float?, min)")]
        public void NullableFloatToBeLessThanOrEqualToNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(float?, min)")]
        public void NullableFloatToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(float?, min)")]
        public void NullableFloatToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Requires.ToBeNegative(float?)")]
        public void NullableFloatToBeNegativeSuccessful()
        {
            Given(() => (float?)-42)
            .When(value => Requires.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Requires.ToBeNegative(float?)")]
        public void NullableFloatToBeNegativeFailed()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(float?)")]
        public void NullableFloatToBeNegativeNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(float?)")]
        public void NullableFloatToBeNegativeFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(float?)")]
        public void NullableFloatToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Requires.ToBeOneOf(float?, others[])")]
        public void NullableFloatToBeOneOfSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeOneOf(value, new float?[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(float?, others[])")]
        public void NullableFloatToBeOneOfFailed()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeOneOf(value, new float?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(float?, others[])")]
        public void NullableFloatToBeOneOfNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Requires.ToBeOneOf(value, new float?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(float?, others[])")]
        public void NullableFloatToBeOneOfFailedWithCustomException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeOneOf(value, new float?[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(float?, others[])")]
        public void NullableFloatToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBeOneOf(value, new float?[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Requires.ToBePositive(float?)")]
        public void NullableFloatToBePositiveSuccessful()
        {
            Given(() => (float?)42)
            .When(value => Requires.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBePositive(float?)")]
        public void NullableFloatToBePositiveFailed()
        {
            Given(() => (float?)-42)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(float?)")]
        public void NullableFloatToBePositiveNullFailed()
        {
            Given(() => (float?)null)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(float?)")]
        public void NullableFloatToBePositiveFailedWithCustomException()
        {
            Given(() => (float?)-42)
            .When(value => Requires.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(float?)")]
        public void NullableFloatToBePositiveFailedWithParameterizedException()
        {
            Given(() => (float?)-42)
            .When(value => Requires.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}