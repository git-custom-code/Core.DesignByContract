#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Float", "Requires")]
    public sealed class RequiresFloatTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Requires.ToBe(float, condition)")]
        public void FloatToBeSuccessful()
        {
            Given(() => 42f)
            .When(value => Requires.ToBe(value, v => v == 42f))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Requires.ToBe(float, condition)")]
        public void FloatToBeFailed()
        {
            Given(() => 42f)
            .When(value => Requires.ToBe(value, v => v != 42f))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(float, condition)")]
        public void FloatToBeFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBe(value, v => v != 42f, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBe(float, condition)")]
        public void FloatToBeFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBe(value, v => v != 42f, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Requires.ToBeBetween(float, min, max)")]
        public void FloatToBeBetweenSuccessful()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeBetween(value, 1f, 100f))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Requires.ToBeBetween(float, max, min)")]
        public void FloatToBeBetweenFailed()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeBetween(value, 100f, 1f))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(float, max, min)")]
        public void FloatToBeBetweenFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeBetween(value, 100f, 1f, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(float, max, min)")]
        public void FloatToBeBetweenFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeBetween(value, 100f, 1f, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Requires.ToBeGreaterThan(float, min)")]
        public void FloatToBeGreaterThanSuccessful()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeGreaterThan(value, 1f))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(float, max)")]
        public void FloatToBeGreaterThanFailed()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeGreaterThan(value, 100f))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(float, max)")]
        public void FloatToBeGreaterThanFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeGreaterThan(value, 100f, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(float, max)")]
        public void FloatToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeGreaterThan(value, 100f, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(float, min)")]
        public void FloatToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 1f))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(float, max)")]
        public void FloatToBeGreaterThanOrEqualToFailed()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100f))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(float, max)")]
        public void FloatToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100f, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(float, max)")]
        public void FloatToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100f, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Requires.ToBeLessThan(float, max)")]
        public void FloatToBeLessThanSuccessful()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeLessThan(value, 100f))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(float, min)")]
        public void FloatToBeLessThanFailed()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeLessThan(value, 1f))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(float, min)")]
        public void FloatToBeLessThanFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeLessThan(value, 1f, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(float, min)")]
        public void FloatToBeLessThanFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeLessThan(value, 1f, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(float, max)")]
        public void FloatToBeLessThanOrEqualToSuccessful()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 100f))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(float, min)")]
        public void FloatToBeLessThanOrEqualToFailed()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1f))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(float, min)")]
        public void FloatToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1f, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(float, min)")]
        public void FloatToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1f, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Requires.ToBeNegative(float)")]
        public void FloatToBeNegativeSuccessful()
        {
            Given(() => (float)-42f)
            .When(value => Requires.ToBeNegative(value))
            .Then(value => value.Should().Be(-42f));
        }

        [Fact(DisplayName = "Requires.ToBeNegative(float)")]
        public void FloatToBeNegativeFailed()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(float)")]
        public void FloatToBeNegativeFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(float)")]
        public void FloatToBeNegativeFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Requires.ToBeOneOf(float, others[])")]
        public void FloatToBeOneOfSuccessful()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeOneOf(value, new[] { 1f, 2f, 42f }))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(float, others[])")]
        public void FloatToBeOneOfFailed()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeOneOf(value, new[] { 1f, 2f }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(float, others[])")]
        public void FloatToBeOneOfFailedWithCustomException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeOneOf(value, new[] { 1f, 2f }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(float, others[])")]
        public void FloatToBeOneOfFailedWithParameterizedException()
        {
            Given(() => 42f)
            .When(value => Requires.ToBeOneOf(value, new[] { 1f, 2f }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Requires.ToBePositive(float)")]
        public void FloatToBePositiveSuccessful()
        {
            Given(() => 42f)
            .When(value => Requires.ToBePositive(value))
            .Then(value => value.Should().Be(42f));
        }

        [Fact(DisplayName = "Requires.ToBePositive(float)")]
        public void FloatToBePositiveFailed()
        {
            Given(() => (float)-42f)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(float)")]
        public void FloatToBePositiveFailedWithCustomException()
        {
            Given(() => (float)-42f)
            .When(value => Requires.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(float)")]
        public void FloatToBePositiveFailedWithParameterizedException()
        {
            Given(() => (float)-42f)
            .When(value => Requires.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}