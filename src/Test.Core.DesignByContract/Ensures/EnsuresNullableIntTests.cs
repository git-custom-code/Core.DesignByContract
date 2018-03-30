#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Integer", "Ensures")]
    public sealed class EnsuresNullableIntTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Ensures.ToBe(int?, condition)")]
        public void NullableIntToBeSuccessful()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBe(int?, condition)")]
        public void NullableIntToBeNullSuccessful()
        {
            Given(() => (int?)null)
            .When(value => Ensures.ToBe(value, v => v == null))
            .Then(value => value.Should().Be(null));
        }

        [Fact(DisplayName = "Ensures.ToBe(int?, condition)")]
        public void NullableIntToBeFailed()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(int?, condition)")]
        public void NullableIntToBeNullFailed()
        {
            Given(() => (int?)null)
            .When(value => Ensures.ToBe(value, v => v != null))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(int?, condition)")]
        public void NullableIntToBeFailedWithCustomException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(int?, condition)")]
        public void NullableIntToBeFailedWithParameterizedException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Ensures.ToBeBetween(int?, min, max)")]
        public void NullableIntToBeBetweenSuccessful()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeBetween(value, 1, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(int?, max, min)")]
        public void NullableIntToBeBetweenFailed()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeBetween(value, 100, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(int?, max, min)")]
        public void NullableIntToBeBetweenNullFailed()
        {
            Given(() => (int?)null)
            .When(value => Ensures.ToBeBetween(value, 100, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(int?, max, min)")]
        public void NullableIntToBeBetweenFailedWithCustomException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeBetween(value, 100, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(int?, max, min)")]
        public void NullableIntToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeBetween(value, 100, 1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(int?, min)")]
        public void NullableIntToBeGreaterThanSuccessful()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeGreaterThan(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(int?, max)")]
        public void NullableIntToBeGreaterThanFailed()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeGreaterThan(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(int?, max)")]
        public void NullableIntToBeGreaterThanNullFailed()
        {
            Given(() => (int?)null)
            .When(value => Ensures.ToBeGreaterThan(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(int?, max)")]
        public void NullableIntToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeGreaterThan(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(int?, max)")]
        public void NullableIntToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeGreaterThan(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(int?, min)")]
        public void NullableIntToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(int?, max)")]
        public void NullableIntToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(int?, max)")]
        public void NullableIntToBeGreaterThanOrEqualToNullFailed()
        {
            Given(() => (int?)null)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(int?, max)")]
        public void NullableIntToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(int?, max)")]
        public void NullableIntToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Ensures.ToBeLessThan(int?, max)")]
        public void NullableIntToBeLessThanSuccessful()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeLessThan(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(int?, min)")]
        public void NullableIntToBeLessThanFailed()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeLessThan(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(int?, min)")]
        public void NullableIntToBeLessThanNullFailed()
        {
            Given(() => (int?)null)
            .When(value => Ensures.ToBeLessThan(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(int?, min)")]
        public void NullableIntToBeLessThanFailedWithCustomException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeLessThan(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(int?, min)")]
        public void NullableIntToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeLessThan(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(int?, max)")]
        public void NullableIntToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(int?, min)")]
        public void NullableIntToBeLessThanOrEqualToFailed()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(int?, min)")]
        public void NullableIntToBeLessThanOrEqualToNullFailed()
        {
            Given(() => (int?)null)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(int?, min)")]
        public void NullableIntToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(int?, min)")]
        public void NullableIntToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Ensures.ToBeNegative(int?)")]
        public void NullableIntToBeNegativeSuccessful()
        {
            Given(() => (int?)-42)
            .When(value => Ensures.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(int?)")]
        public void NullableIntToBeNegativeFailed()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(int?)")]
        public void NullableIntToBeNegativeNullFailed()
        {
            Given(() => (int?)null)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(int?)")]
        public void NullableIntToBeNegativeFailedWithCustomException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(int?)")]
        public void NullableIntToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Ensures.ToBeOneOf(int?, others[])")]
        public void NullableIntToBeOneOfSuccessful()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeOneOf(value, new int?[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(int?, others[])")]
        public void NullableIntToBeOneOfFailed()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeOneOf(value, new int?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(int?, others[])")]
        public void NullableIntToBeOneOfNullFailed()
        {
            Given(() => (int?)null)
            .When(value => Ensures.ToBeOneOf(value, new int?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(int?, others[])")]
        public void NullableIntToBeOneOfFailedWithCustomException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeOneOf(value, new int?[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(int?, others[])")]
        public void NullableIntToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBeOneOf(value, new int?[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Ensures.ToBePositive(int?)")]
        public void NullableIntToBePositiveSuccessful()
        {
            Given(() => (int?)42)
            .When(value => Ensures.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBePositive(int?)")]
        public void NullableIntToBePositiveFailed()
        {
            Given(() => (int?)-42)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(int?)")]
        public void NullableIntToBePositiveNullFailed()
        {
            Given(() => (int?)null)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(int?)")]
        public void NullableIntToBePositiveFailedWithCustomException()
        {
            Given(() => (int?)-42)
            .When(value => Ensures.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(int?)")]
        public void NullableIntToBePositiveFailedWithParameterizedException()
        {
            Given(() => (int?)-42)
            .When(value => Ensures.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}