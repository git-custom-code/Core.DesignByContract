#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Ulong", "Ensures")]
    public sealed class EnsuresUlongTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Ensures.ToBe(ulong, condition)")]
        public void UlongToBeSuccessful()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBe(value, v => v == 42ul))
            .Then(value => value.Should().Be(42ul));
        }

        [Fact(DisplayName = "Ensures.ToBe(ulong, condition)")]
        public void UlongToBeFailed()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBe(value, v => v != 42ul))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(ulong, condition)")]
        public void UlongToBeFailedWithCustomException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBe(value, v => v != 42ul, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(ulong, condition)")]
        public void UlongToBeFailedWithParameterizedException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBe(value, v => v != 42ul, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Ensures.ToBeBetween(ulong, min, max)")]
        public void UlongToBeBetweenSuccessful()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeBetween(value, 1ul, 100ul))
            .Then(value => value.Should().Be(42ul));
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(ulong, max, min)")]
        public void UlongToBeBetweenFailed()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeBetween(value, 100ul, 1ul))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(ulong, max, min)")]
        public void UlongToBeBetweenFailedWithCustomException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeBetween(value, 100ul, 1ul, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(ulong, max, min)")]
        public void UlongToBeBetweenFailedWithParameterizedException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeBetween(value, 100ul, 1ul, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(ulong, min)")]
        public void UlongToBeGreaterThanSuccessful()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeGreaterThan(value, 1ul))
            .Then(value => value.Should().Be(42ul));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(ulong, max)")]
        public void UlongToBeGreaterThanFailed()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeGreaterThan(value, 100ul))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(ulong, max)")]
        public void UlongToBeGreaterThanFailedWithCustomException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeGreaterThan(value, 100ul, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(ulong, max)")]
        public void UlongToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeGreaterThan(value, 100ul, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(ulong, min)")]
        public void UlongToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 1ul))
            .Then(value => value.Should().Be(42ul));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(ulong, max)")]
        public void UlongToBeGreaterThanOrEqualToFailed()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100ul))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(ulong, max)")]
        public void UlongToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100ul, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(ulong, max)")]
        public void UlongToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, 100ul, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Ensures.ToBeLessThan(ulong, max)")]
        public void UlongToBeLessThanSuccessful()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeLessThan(value, 100ul))
            .Then(value => value.Should().Be(42ul));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(ulong, min)")]
        public void UlongToBeLessThanFailed()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeLessThan(value, 1ul))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(ulong, min)")]
        public void UlongToBeLessThanFailedWithCustomException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeLessThan(value, 1ul, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(ulong, min)")]
        public void UlongToBeLessThanFailedWithParameterizedException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeLessThan(value, 1ul, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(ulong, max)")]
        public void UlongToBeLessThanOrEqualToSuccessful()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 100ul))
            .Then(value => value.Should().Be(42ul));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(ulong, min)")]
        public void UlongToBeLessThanOrEqualToFailed()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1ul))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(ulong, min)")]
        public void UlongToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1ul, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(ulong, min)")]
        public void UlongToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, 1ul, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Ensures.ToBeOneOf(ulong, others[])")]
        public void UlongToBeOneOfSuccessful()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1ul, 2ul, 42ul }))
            .Then(value => value.Should().Be(42ul));
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(ulong, others[])")]
        public void UlongToBeOneOfFailed()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1ul, 2ul }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(ulong, others[])")]
        public void UlongToBeOneOfFailedWithCustomException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1ul, 2ul }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(ulong, others[])")]
        public void UlongToBeOneOfFailedWithParameterizedException()
        {
            Given(() => 42ul)
            .When(value => Ensures.ToBeOneOf(value, new[] { 1ul, 2ul }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}