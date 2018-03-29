#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Double", "Requires")]
    public sealed class RequiresDoubleTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Requires.ToBe(double, condition)")]
        public void DoubleToBeSuccessful()
        {
            Given(() => 42d)
            .When(value => Requires.ToBe(value, v => v == 42d))
            .Then(value => value.Should().Be(42d));
        }

        [Fact(DisplayName = "Requires.ToBe(double, condition)")]
        public void DoubleToBeFailed()
        {
            Given(() => 42d)
            .When(value => Requires.ToBe(value, v => v != 42d))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(double, condition)")]
        public void DoubleToBeFailedWithCustomException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBe(value, v => v != 42d, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBe(double, condition)")]
        public void DoubleToBeFailedWithParameterizedException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBe(value, v => v != 42d, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Requires.ToBeBetween(double, min, max)")]
        public void DoubleToBeBetweenSuccessful()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeBetween(value, 1d, 100d))
            .Then(value => value.Should().Be(42d));
        }

        [Fact(DisplayName = "Requires.ToBeBetween(double, max, min)")]
        public void DoubleToBeBetweenFailed()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeBetween(value, 100d, 1d))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(double, max, min)")]
        public void DoubleToBeBetweenFailedWithCustomException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeBetween(value, 100d, 1d, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(double, max, min)")]
        public void DoubleToBeBetweenFailedWithParameterizedException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeBetween(value, 100d, 1d, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Requires.ToBeGreaterThan(double, min)")]
        public void DoubleToBeGreaterThanSuccessful()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeGreaterThan(value, 1d))
            .Then(value => value.Should().Be(42d));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(double, max)")]
        public void DoubleToBeGreaterThanFailed()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeGreaterThan(value, 100d))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(double, max)")]
        public void DoubleToBeGreaterThanFailedWithCustomException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeGreaterThan(value, 100d, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(double, max)")]
        public void DoubleToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeGreaterThan(value, 100d, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(double, min)")]
        public void DoubleToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 1d))
            .Then(value => value.Should().Be(42d));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(double, max)")]
        public void DoubleToBeGreaterThanOrEqualToFailed()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100d))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(double, max)")]
        public void DoubleToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100d, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(double, max)")]
        public void DoubleToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100d, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Requires.ToBeLessThan(double, max)")]
        public void DoubleToBeLessThanSuccessful()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeLessThan(value, 100d))
            .Then(value => value.Should().Be(42d));
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(double, min)")]
        public void DoubleToBeLessThanFailed()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeLessThan(value, 1d))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(double, min)")]
        public void DoubleToBeLessThanFailedWithCustomException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeLessThan(value, 1d, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(double, min)")]
        public void DoubleToBeLessThanFailedWithParameterizedException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeLessThan(value, 1d, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(double, max)")]
        public void DoubleToBeLessThanOrEqualToSuccessful()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 100d))
            .Then(value => value.Should().Be(42d));
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(double, min)")]
        public void DoubleToBeLessThanOrEqualToFailed()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1d))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(double, min)")]
        public void DoubleToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1d, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(double, min)")]
        public void DoubleToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1d, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Requires.ToBeNegative(double)")]
        public void DoubleToBeNegativeSuccessful()
        {
            Given(() => (double)-42d)
            .When(value => Requires.ToBeNegative(value))
            .Then(value => value.Should().Be(-42d));
        }

        [Fact(DisplayName = "Requires.ToBeNegative(double)")]
        public void DoubleToBeNegativeFailed()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(double)")]
        public void DoubleToBeNegativeFailedWithCustomException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(double)")]
        public void DoubleToBeNegativeFailedWithParameterizedException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Requires.ToBeOneOf(double, others[])")]
        public void DoubleToBeOneOfSuccessful()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeOneOf(value, new[] { 1d, 2d, 42d }))
            .Then(value => value.Should().Be(42d));
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(double, others[])")]
        public void DoubleToBeOneOfFailed()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeOneOf(value, new[] { 1d, 2d }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(double, others[])")]
        public void DoubleToBeOneOfFailedWithCustomException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeOneOf(value, new[] { 1d, 2d }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(double, others[])")]
        public void DoubleToBeOneOfFailedWithParameterizedException()
        {
            Given(() => 42d)
            .When(value => Requires.ToBeOneOf(value, new[] { 1d, 2d }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Requires.ToBePositive(double)")]
        public void DoubleToBePositiveSuccessful()
        {
            Given(() => 42d)
            .When(value => Requires.ToBePositive(value))
            .Then(value => value.Should().Be(42d));
        }

        [Fact(DisplayName = "Requires.ToBePositive(double)")]
        public void DoubleToBePositiveFailed()
        {
            Given(() => (double)-42d)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(double)")]
        public void DoubleToBePositiveFailedWithCustomException()
        {
            Given(() => (double)-42d)
            .When(value => Requires.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(double)")]
        public void DoubleToBePositiveFailedWithParameterizedException()
        {
            Given(() => (double)-42d)
            .When(value => Requires.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}