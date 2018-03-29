#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Ushort", "Requires")]
    public sealed class RequiresUshortTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Requires.ToBe(ushort, condition)")]
        public void UshortToBeSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBe(value, v => v == (ushort)42))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Requires.ToBe(ushort, condition)")]
        public void UshortToBeFailed()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBe(value, v => v != (ushort)42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(ushort, condition)")]
        public void UshortToBeFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBe(value, v => v != (ushort)42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBe(ushort, condition)")]
        public void UshortToBeFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBe(value, v => v != (ushort)42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Requires.ToBeBetween(ushort, min, max)")]
        public void UshortToBeBetweenSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeBetween(value, (ushort)1, (ushort)100))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Requires.ToBeBetween(ushort, max, min)")]
        public void UshortToBeBetweenFailed()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeBetween(value, (ushort)100, (ushort)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(ushort, max, min)")]
        public void UshortToBeBetweenFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeBetween(value, (ushort)100, (ushort)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(ushort, max, min)")]
        public void UshortToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeBetween(value, (ushort)100, (ushort)1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Requires.ToBeGreaterThan(ushort, min)")]
        public void UshortToBeGreaterThanSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeGreaterThan(value, (ushort)1))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(ushort, max)")]
        public void UshortToBeGreaterThanFailed()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeGreaterThan(value, (ushort)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(ushort, max)")]
        public void UshortToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeGreaterThan(value, (ushort)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(ushort, max)")]
        public void UshortToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeGreaterThan(value, (ushort)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(ushort, min)")]
        public void UshortToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (ushort)1))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(ushort, max)")]
        public void UshortToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (ushort)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(ushort, max)")]
        public void UshortToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (ushort)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(ushort, max)")]
        public void UshortToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (ushort)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Requires.ToBeLessThan(ushort, max)")]
        public void UshortToBeLessThanSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeLessThan(value, (ushort)100))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(ushort, min)")]
        public void UshortToBeLessThanFailed()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeLessThan(value, (ushort)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(ushort, min)")]
        public void UshortToBeLessThanFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeLessThan(value, (ushort)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(ushort, min)")]
        public void UshortToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeLessThan(value, (ushort)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(ushort, max)")]
        public void UshortToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (ushort)100))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(ushort, min)")]
        public void UshortToBeLessThanOrEqualToFailed()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (ushort)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(ushort, min)")]
        public void UshortToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (ushort)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(ushort, min)")]
        public void UshortToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (ushort)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Requires.ToBeOneOf(ushort, others[])")]
        public void UshortToBeOneOfSuccessful()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeOneOf(value, new[] { (ushort)1, (ushort)2, (ushort)42 }))
            .Then(value => value.Should().Be((ushort)42));
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(ushort, others[])")]
        public void UshortToBeOneOfFailed()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeOneOf(value, new[] { (ushort)1, (ushort)2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(ushort, others[])")]
        public void UshortToBeOneOfFailedWithCustomException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeOneOf(value, new[] { (ushort)1, (ushort)2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(ushort, others[])")]
        public void UshortToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (ushort)42)
            .When(value => Requires.ToBeOneOf(value, new[] { (ushort)1, (ushort)2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}