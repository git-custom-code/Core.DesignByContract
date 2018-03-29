#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Short", "Requires")]
    public sealed class RequiresShortTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Requires.ToBe(short, condition)")]
        public void ShortToBeSuccessful()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBe(short, condition)")]
        public void ShortToBeFailed()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(short, condition)")]
        public void ShortToBeFailedWithCustomException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBe(short, condition)")]
        public void ShortToBeFailedWithParameterizedException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Requires.ToBeBetween(short, min, max)")]
        public void ShortToBeBetweenSuccessful()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeBetween(value, (short)1, (short)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeBetween(short, max, min)")]
        public void ShortToBeBetweenFailed()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeBetween(value, (short)100, (short)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(short, max, min)")]
        public void ShortToBeBetweenFailedWithCustomException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeBetween(value, (short)100, (short)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(short, max, min)")]
        public void ShortToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeBetween(value, (short)100, (short)1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Requires.ToBeGreaterThan(short, min)")]
        public void ShortToBeGreaterThanSuccessful()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeGreaterThan(value, (short)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(short, max)")]
        public void ShortToBeGreaterThanFailed()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeGreaterThan(value, (short)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(short, max)")]
        public void ShortToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeGreaterThan(value, (short)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(short, max)")]
        public void ShortToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeGreaterThan(value, (short)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(short, min)")]
        public void ShortToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (short)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(short, max)")]
        public void ShortToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (short)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(short, max)")]
        public void ShortToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (short)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(short, max)")]
        public void ShortToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (short)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Requires.ToBeLessThan(short, max)")]
        public void ShortToBeLessThanSuccessful()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeLessThan(value, (short)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(short, min)")]
        public void ShortToBeLessThanFailed()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeLessThan(value, (short)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(short, min)")]
        public void ShortToBeLessThanFailedWithCustomException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeLessThan(value, (short)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(short, min)")]
        public void ShortToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeLessThan(value, (short)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(short, max)")]
        public void ShortToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (short)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(short, min)")]
        public void ShortToBeLessThanOrEqualToFailed()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (short)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(short, min)")]
        public void ShortToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (short)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(short, min)")]
        public void ShortToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (short)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Requires.ToBeNegative(short)")]
        public void ShortToBeNegativeSuccessful()
        {
            Given(() => (short)-42)
            .When(value => Requires.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Requires.ToBeNegative(short)")]
        public void ShortToBeNegativeFailed()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(short)")]
        public void ShortToBeNegativeFailedWithCustomException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(short)")]
        public void ShortToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Requires.ToBeOneOf(short, others[])")]
        public void ShortToBeOneOfSuccessful()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeOneOf(value, new[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(short, others[])")]
        public void ShortToBeOneOfFailed()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeOneOf(value, new[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(short, others[])")]
        public void ShortToBeOneOfFailedWithCustomException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeOneOf(value, new[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(short, others[])")]
        public void ShortToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBeOneOf(value, new[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Requires.ToBePositive(short)")]
        public void ShortToBePositiveSuccessful()
        {
            Given(() => (short)42)
            .When(value => Requires.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBePositive(short)")]
        public void ShortToBePositiveFailed()
        {
            Given(() => (short)-42)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(short)")]
        public void ShortToBePositiveFailedWithCustomException()
        {
            Given(() => (short)-42)
            .When(value => Requires.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(short)")]
        public void ShortToBePositiveFailedWithParameterizedException()
        {
            Given(() => (short)-42)
            .When(value => Requires.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}