#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Uint", "Requires")]
    public sealed class RequiresUintTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Requires.ToBe(uint, condition)")]
        public void UintToBeSuccessful()
        {
            Given(() => 42u)
            .When(value => Requires.ToBe(value, v => v == 42u))
            .Then(value => value.Should().Be(42u));
        }

        [Fact(DisplayName = "Requires.ToBe(uint, condition)")]
        public void UintToBeFailed()
        {
            Given(() => 42u)
            .When(value => Requires.ToBe(value, v => v != 42u))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(uint, condition)")]
        public void UintToBeFailedWithCustomException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBe(value, v => v != 42u, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBe(uint, condition)")]
        public void UintToBeFailedWithParameterizedException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBe(value, v => v != 42u, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Requires.ToBeBetween(uint, min, max)")]
        public void UintToBeBetweenSuccessful()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeBetween(value, 1u, 100u))
            .Then(value => value.Should().Be(42u));
        }

        [Fact(DisplayName = "Requires.ToBeBetween(uint, max, min)")]
        public void UintToBeBetweenFailed()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeBetween(value, 100u, 1u))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(uint, max, min)")]
        public void UintToBeBetweenFailedWithCustomException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeBetween(value, 100u, 1u, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(uint, max, min)")]
        public void UintToBeBetweenFailedWithParameterizedException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeBetween(value, 100u, 1u, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Requires.ToBeGreaterThan(uint, min)")]
        public void UintToBeGreaterThanSuccessful()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeGreaterThan(value, 1u))
            .Then(value => value.Should().Be(42u));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(uint, max)")]
        public void UintToBeGreaterThanFailed()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeGreaterThan(value, 100u))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(uint, max)")]
        public void UintToBeGreaterThanFailedWithCustomException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeGreaterThan(value, 100u, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(uint, max)")]
        public void UintToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeGreaterThan(value, 100u, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(uint, min)")]
        public void UintToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 1u))
            .Then(value => value.Should().Be(42u));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(uint, max)")]
        public void UintToBeGreaterThanOrEqualToFailed()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100u))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(uint, max)")]
        public void UintToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100u, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(uint, max)")]
        public void UintToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, 100u, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Requires.ToBeLessThan(uint, max)")]
        public void UintToBeLessThanSuccessful()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeLessThan(value, 100u))
            .Then(value => value.Should().Be(42u));
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(uint, min)")]
        public void UintToBeLessThanFailed()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeLessThan(value, 1u))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(uint, min)")]
        public void UintToBeLessThanFailedWithCustomException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeLessThan(value, 1u, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(uint, min)")]
        public void UintToBeLessThanFailedWithParameterizedException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeLessThan(value, 1u, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(uint, max)")]
        public void UintToBeLessThanOrEqualToSuccessful()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 100u))
            .Then(value => value.Should().Be(42u));
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(uint, min)")]
        public void UintToBeLessThanOrEqualToFailed()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1u))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(uint, min)")]
        public void UintToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1u, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(uint, min)")]
        public void UintToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, 1u, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Requires.ToBeOneOf(uint, others[])")]
        public void UintToBeOneOfSuccessful()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeOneOf(value, new[] { 1u, 2u, 42u }))
            .Then(value => value.Should().Be(42u));
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(uint, others[])")]
        public void UintToBeOneOfFailed()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeOneOf(value, new[] { 1u, 2u }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(uint, others[])")]
        public void UintToBeOneOfFailedWithCustomException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeOneOf(value, new[] { 1u, 2u }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(uint, others[])")]
        public void UintToBeOneOfFailedWithParameterizedException()
        {
            Given(() => 42u)
            .When(value => Requires.ToBeOneOf(value, new[] { 1u, 2u }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}