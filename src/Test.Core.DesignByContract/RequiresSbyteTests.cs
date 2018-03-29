#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Sbyte", "Requires")]
    public sealed class RequiresSbyteTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Requires.ToBe(sbyte, condition)")]
        public void SbyteToBeSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBe(sbyte, condition)")]
        public void SbyteToBeFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(sbyte, condition)")]
        public void SbyteToBeFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBe(sbyte, condition)")]
        public void SbyteToBeFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Requires.ToBeBetween(sbyte, min, max)")]
        public void SbyteToBeBetweenSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeBetween(value, (sbyte)1, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeBetween(sbyte, max, min)")]
        public void SbyteToBeBetweenFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeBetween(value, (sbyte)100, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(sbyte, max, min)")]
        public void SbyteToBeBetweenFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeBetween(value, (sbyte)100, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(sbyte, max, min)")]
        public void SbyteToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeBetween(value, (sbyte)100, (sbyte)1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Requires.ToBeGreaterThan(sbyte, min)")]
        public void SbyteToBeGreaterThanSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeGreaterThan(value, (sbyte)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(sbyte, max)")]
        public void SbyteToBeGreaterThanFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeGreaterThan(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(sbyte, max)")]
        public void SbyteToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeGreaterThan(value, (sbyte)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(sbyte, max)")]
        public void SbyteToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeGreaterThan(value, (sbyte)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(sbyte, min)")]
        public void SbyteToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (sbyte)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(sbyte, max)")]
        public void SbyteToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(sbyte, max)")]
        public void SbyteToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (sbyte)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(sbyte, max)")]
        public void SbyteToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (sbyte)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Requires.ToBeLessThan(sbyte, max)")]
        public void SbyteToBeLessThanSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeLessThan(value, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(sbyte, min)")]
        public void SbyteToBeLessThanFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeLessThan(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(sbyte, min)")]
        public void SbyteToBeLessThanFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeLessThan(value, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(sbyte, min)")]
        public void SbyteToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeLessThan(value, (sbyte)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(sbyte, max)")]
        public void SbyteToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(sbyte, min)")]
        public void SbyteToBeLessThanOrEqualToFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(sbyte, min)")]
        public void SbyteToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(sbyte, min)")]
        public void SbyteToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (sbyte)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Requires.ToBeNegative(sbyte)")]
        public void SbyteToBeNegativeSuccessful()
        {
            Given(() => (sbyte)-42)
            .When(value => Requires.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Requires.ToBeNegative(sbyte)")]
        public void SbyteToBeNegativeFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(sbyte)")]
        public void SbyteToBeNegativeFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(sbyte)")]
        public void SbyteToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Requires.ToBeOneOf(sbyte, others[])")]
        public void SbyteToBeOneOfSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeOneOf(value, new[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(sbyte, others[])")]
        public void SbyteToBeOneOfFailed()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeOneOf(value, new[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(sbyte, others[])")]
        public void SbyteToBeOneOfFailedWithCustomException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeOneOf(value, new[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(sbyte, others[])")]
        public void SbyteToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBeOneOf(value, new[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Requires.ToBePositive(sbyte)")]
        public void SbyteToBePositiveSuccessful()
        {
            Given(() => (sbyte)42)
            .When(value => Requires.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBePositive(sbyte)")]
        public void SbyteToBePositiveFailed()
        {
            Given(() => (sbyte)-42)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(sbyte)")]
        public void SbyteToBePositiveFailedWithCustomException()
        {
            Given(() => (sbyte)-42)
            .When(value => Requires.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(sbyte)")]
        public void SbyteToBePositiveFailedWithParameterizedException()
        {
            Given(() => (sbyte)-42)
            .When(value => Requires.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}