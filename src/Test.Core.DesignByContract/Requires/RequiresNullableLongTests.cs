#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Long", "Requires")]
    public sealed class RequiresNullableLongTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Requires.ToBe(long?, condition)")]
        public void NullableLongToBeSuccessful()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBe(long?, condition)")]
        public void NullableLongToBeNullSuccessful()
        {
            Given(() => (long?)null)
            .When(value => Requires.ToBe(value, v => v == null))
            .Then(value => value.Should().Be(null));
        }

        [Fact(DisplayName = "Requires.ToBe(long?, condition)")]
        public void NullableLongToBeFailed()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(long?, condition)")]
        public void NullableLongToBeNullFailed()
        {
            Given(() => (long?)null)
            .When(value => Requires.ToBe(value, v => v != null))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(long?, condition)")]
        public void NullableLongToBeFailedWithCustomException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBe(long?, condition)")]
        public void NullableLongToBeFailedWithParameterizedException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Requires.ToBeBetween(long?, min, max)")]
        public void NullableLongToBeBetweenSuccessful()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeBetween(value, 1, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeBetween(long?, max, min)")]
        public void NullableLongToBeBetweenFailed()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeBetween(value, 100, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(long?, max, min)")]
        public void NullableLongToBeBetweenNullFailed()
        {
            Given(() => (long?)null)
            .When(value => Requires.ToBeBetween(value, 100, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(long?, max, min)")]
        public void NullableLongToBeBetweenFailedWithCustomException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeBetween(value, 100, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(long?, max, min)")]
        public void NullableLongToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeBetween(value, 100, 1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Requires.ToBeGreaterThan(long?, min)")]
        public void NullableLongToBeGreaterThanSuccessful()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeGreaterThan(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(long?, max)")]
        public void NullableLongToBeGreaterThanFailed()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeGreaterThan(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(long?, max)")]
        public void NullableLongToBeGreaterThanNullFailed()
        {
            Given(() => (long?)null)
            .When(value => Requires.ToBeGreaterThan(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(long?, max)")]
        public void NullableLongToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeGreaterThan(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(long?, max)")]
        public void NullableLongToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeGreaterThan(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(long?, min)")]
        public void NullableLongToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(long?, max)")]
        public void NullableLongToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(long?, max)")]
        public void NullableLongToBeGreaterThanOrEqualToNullFailed()
        {
            Given(() => (long?)null)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(long?, max)")]
        public void NullableLongToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(long?, max)")]
        public void NullableLongToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Requires.ToBeLessThan(long?, max)")]
        public void NullableLongToBeLessThanSuccessful()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeLessThan(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(long?, min)")]
        public void NullableLongToBeLessThanFailed()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeLessThan(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(long?, min)")]
        public void NullableLongToBeLessThanNullFailed()
        {
            Given(() => (long?)null)
            .When(value => Requires.ToBeLessThan(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(long?, min)")]
        public void NullableLongToBeLessThanFailedWithCustomException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeLessThan(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(long?, min)")]
        public void NullableLongToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeLessThan(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(long?, max)")]
        public void NullableLongToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(long?, min)")]
        public void NullableLongToBeLessThanOrEqualToFailed()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(long?, min)")]
        public void NullableLongToBeLessThanOrEqualToNullFailed()
        {
            Given(() => (long?)null)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(long?, min)")]
        public void NullableLongToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(long?, min)")]
        public void NullableLongToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Requires.ToBeNegative(long?)")]
        public void NullableLongToBeNegativeSuccessful()
        {
            Given(() => (long?)-42)
            .When(value => Requires.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Requires.ToBeNegative(long?)")]
        public void NullableLongToBeNegativeFailed()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(long?)")]
        public void NullableLongToBeNegativeNullFailed()
        {
            Given(() => (long?)null)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(long?)")]
        public void NullableLongToBeNegativeFailedWithCustomException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(long?)")]
        public void NullableLongToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Requires.ToBeOneOf(long?, others[])")]
        public void NullableLongToBeOneOfSuccessful()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeOneOf(value, new long?[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(long?, others[])")]
        public void NullableLongToBeOneOfFailed()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeOneOf(value, new long?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(long?, others[])")]
        public void NullableLongToBeOneOfNullFailed()
        {
            Given(() => (long?)null)
            .When(value => Requires.ToBeOneOf(value, new long?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(long?, others[])")]
        public void NullableLongToBeOneOfFailedWithCustomException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeOneOf(value, new long?[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(long?, others[])")]
        public void NullableLongToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBeOneOf(value, new long?[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Requires.ToBePositive(long?)")]
        public void NullableLongToBePositiveSuccessful()
        {
            Given(() => (long?)42)
            .When(value => Requires.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBePositive(long?)")]
        public void NullableLongToBePositiveFailed()
        {
            Given(() => (long?)-42)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(long?)")]
        public void NullableLongToBePositiveNullFailed()
        {
            Given(() => (long?)null)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(long?)")]
        public void NullableLongToBePositiveFailedWithCustomException()
        {
            Given(() => (long?)-42)
            .When(value => Requires.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(long?)")]
        public void NullableLongToBePositiveFailedWithParameterizedException()
        {
            Given(() => (long?)-42)
            .When(value => Requires.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}