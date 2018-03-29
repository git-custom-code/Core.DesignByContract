#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Float", "Ensures")]
    public sealed class EnsuresFloatTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Ensures.ToBe(float, condition)")]
        public void FloatToBeSuccessful()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBe(value, v => v == 42f))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Ensures.ToBe(float, condition)")]
        public void FloatToBeFailed()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBe(value, v => v != 42f))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(float, condition)")]
        public void FloatToBeFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBe(value, v => v != 42f, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(float, condition)")]
        public void FloatToBeFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBe(value, v => v != 42f, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Ensures.ToBeBetween(float, min, max)")]
        public void FloatToBeBetweenSuccessful()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeBetween(value, 1f, 100f))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(float, max, min)")]
        public void FloatToBeBetweenFailed()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeBetween(value, 100f, 1f))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(float, max, min)")]
        public void FloatToBeBetweenFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeBetween(value, 100f, 1f, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(float, max, min)")]
        public void FloatToBeBetweenFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeBetween(value, 100f, 1f, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(float, min)")]
        public void FloatToBeGreaterThanSuccessful()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeGreaterThan(value, 1f))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(float, max)")]
        public void FloatToBeGreaterThanFailed()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeGreaterThan(value, 100f))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(float, max)")]
        public void FloatToBeGreaterThanFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeGreaterThan(value, 100f, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(float, max)")]
        public void FloatToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeGreaterThan(value, 100f, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(float, min)")]
        public void FloatToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 1f))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(float, max)")]
        public void FloatToBeGreaterThanOrEqualToFailed()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100f))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(float, max)")]
        public void FloatToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100f, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(float, max)")]
        public void FloatToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100f, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Ensures.ToBeLessThan(float, max)")]
        public void FloatToBeLessThanSuccessful()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeLessThan(value, 100f))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(float, min)")]
        public void FloatToBeLessThanFailed()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeLessThan(value, 1f))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(float, min)")]
        public void FloatToBeLessThanFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeLessThan(value, 1f, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(float, min)")]
        public void FloatToBeLessThanFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeLessThan(value, 1f, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(float, max)")]
        public void FloatToBeLessThanOrEqualToSuccessful()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 100f))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(float, min)")]
        public void FloatToBeLessThanOrEqualToFailed()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1f))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(float, min)")]
        public void FloatToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1f, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(float, min)")]
        public void FloatToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1f, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Ensures.ToBeNegative(float)")]
        public void FloatToBeNegativeSuccessful()
        {
            Given(() => (float)-42f)
            .When(value => Ensures.ToBeNegative(value))
            .Then(value => value.Should().Be(-42f));
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(float)")]
        public void FloatToBeNegativeFailed()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(float)")]
        public void FloatToBeNegativeFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(float)")]
        public void FloatToBeNegativeFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Ensures.ToBeOneOf(float, others[])")]
        public void FloatToBeOneOfSuccessful()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1f, 2f, 42f }))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(float, others[])")]
        public void FloatToBeOneOfFailed()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1f, 2f }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(float, others[])")]
        public void FloatToBeOneOfFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1f, 2f }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(float, others[])")]
        public void FloatToBeOneOfFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1f, 2f }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Ensures.ToBePositive(float)")]
        public void FloatToBePositiveSuccessful()
        {
            Given(() => 42f)
            .When(value => Ensures.ToBePositive(value))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Ensures.ToBePositive(float)")]
        public void FloatToBePositiveFailed()
        {
            Given(() => (float)-42f)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(float)")]
        public void FloatToBePositiveFailedWithCustomException()
        {
            Given(() => (float)-42f)
            .When(value => Ensures.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(float)")]
        public void FloatToBePositiveFailedWithParameterizedException()
        {
            Given(() => (float)-42f)
            .When(value => Ensures.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}