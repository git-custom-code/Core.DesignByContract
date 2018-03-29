#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Ushort", "Ensures")]
    public sealed class EnsuresUshortTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Ensures.ToBe(ushort, condition)")]
        public void UshortToBeSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBe(value, v => v == (ushort)42))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Ensures.ToBe(ushort, condition)")]
        public void UshortToBeFailed()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBe(value, v => v != (ushort)42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(ushort, condition)")]
        public void UshortToBeFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBe(value, v => v != (ushort)42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(ushort, condition)")]
        public void UshortToBeFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBe(value, v => v != (ushort)42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Ensures.ToBeBetween(ushort, min, max)")]
        public void UshortToBeBetweenSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeBetween(value, (ushort)1, (ushort)100))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(ushort, max, min)")]
        public void UshortToBeBetweenFailed()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeBetween(value, (ushort)100, (ushort)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(ushort, max, min)")]
        public void UshortToBeBetweenFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeBetween(value, (ushort)100, (ushort)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(ushort, max, min)")]
        public void UshortToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeBetween(value, (ushort)100, (ushort)1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(ushort, min)")]
        public void UshortToBeGreaterThanSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeGreaterThan(value, (ushort)1))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(ushort, max)")]
        public void UshortToBeGreaterThanFailed()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeGreaterThan(value, (ushort)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(ushort, max)")]
        public void UshortToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeGreaterThan(value, (ushort)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(ushort, max)")]
        public void UshortToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeGreaterThan(value, (ushort)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(ushort, min)")]
        public void UshortToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (ushort)1))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(ushort, max)")]
        public void UshortToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (ushort)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(ushort, max)")]
        public void UshortToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (ushort)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(ushort, max)")]
        public void UshortToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (ushort)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Ensures.ToBeLessThan(ushort, max)")]
        public void UshortToBeLessThanSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeLessThan(value, (ushort)100))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(ushort, min)")]
        public void UshortToBeLessThanFailed()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeLessThan(value, (ushort)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(ushort, min)")]
        public void UshortToBeLessThanFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeLessThan(value, (ushort)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(ushort, min)")]
        public void UshortToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeLessThan(value, (ushort)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(ushort, max)")]
        public void UshortToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (ushort)100))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(ushort, min)")]
        public void UshortToBeLessThanOrEqualToFailed()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (ushort)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(ushort, min)")]
        public void UshortToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (ushort)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(ushort, min)")]
        public void UshortToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (ushort)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Ensures.ToBeOneOf(ushort, others[])")]
        public void UshortToBeOneOfSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { (ushort)1, (ushort)2, (ushort)42 }))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(ushort, others[])")]
        public void UshortToBeOneOfFailed()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { (ushort)1, (ushort)2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(ushort, others[])")]
        public void UshortToBeOneOfFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { (ushort)1, (ushort)2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(ushort, others[])")]
        public void UshortToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { (ushort)1, (ushort)2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}