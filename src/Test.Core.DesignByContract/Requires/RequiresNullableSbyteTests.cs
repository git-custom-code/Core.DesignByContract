#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Sbyte", "Requires")]
    public sealed class RequiresNullableSbyteTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Requires.ToBe(sbyte?, condition)")]
        public void NullableSbyteToBeSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBe(sbyte?, condition)")]
        public void NullableSbyteToBeNullSuccessful()
        {
            Given(() => (sbyte?)null)
            .When(value => Requires.ToBe(value, v => v == null))
            .Then(value => value.Should().Be(null));
        }

        [Fact(DisplayName = "Requires.ToBe(sbyte?, condition)")]
        public void NullableSbyteToBeFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(sbyte?, condition)")]
        public void NullableSbyteToBeNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Requires.ToBe(value, v => v != null))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBe(sbyte?, condition)")]
        public void NullableSbyteToBeFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBe(sbyte?, condition)")]
        public void NullableSbyteToBeFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Requires.ToBeBetween(sbyte?, min, max)")]
        public void NullableSbyteToBeBetweenSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeBetween(value, (sbyte)1, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeBetween(sbyte?, max, min)")]
        public void NullableSbyteToBeBetweenFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeBetween(value, (sbyte)100, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(sbyte?, max, min)")]
        public void NullableSbyteToBeBetweenNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Requires.ToBeBetween(value, (sbyte)100, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(sbyte?, max, min)")]
        public void NullableSbyteToBeBetweenFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeBetween(value, (sbyte)100, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeBetween(sbyte?, max, min)")]
        public void NullableSbyteToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeBetween(value, (sbyte)100, (sbyte)1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Requires.ToBeGreaterThan(sbyte?, min)")]
        public void NullableSbyteToBeGreaterThanSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeGreaterThan(value, (sbyte)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeGreaterThan(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Requires.ToBeGreaterThan(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeGreaterThan(value, (sbyte)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThan(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeGreaterThan(value, (sbyte)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(sbyte?, min)")]
        public void NullableSbyteToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (sbyte)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanOrEqualToNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (sbyte)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeGreaterThanOrEqualTo(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeGreaterThanOrEqualTo(value, (sbyte)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Requires.ToBeLessThan(sbyte?, max)")]
        public void NullableSbyteToBeLessThanSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeLessThan(value, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(sbyte?, min)")]
        public void NullableSbyteToBeLessThanFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeLessThan(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(sbyte?, min)")]
        public void NullableSbyteToBeLessThanNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Requires.ToBeLessThan(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(sbyte?, min)")]
        public void NullableSbyteToBeLessThanFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeLessThan(value, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThan(sbyte?, min)")]
        public void NullableSbyteToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeLessThan(value, (sbyte)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(sbyte?, max)")]
        public void NullableSbyteToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(sbyte?, min)")]
        public void NullableSbyteToBeLessThanOrEqualToFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(sbyte?, min)")]
        public void NullableSbyteToBeLessThanOrEqualToNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(sbyte?, min)")]
        public void NullableSbyteToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeLessThanOrEqualTo(sbyte?, min)")]
        public void NullableSbyteToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeLessThanOrEqualTo(value, (sbyte)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Requires.ToBeNegative(sbyte?)")]
        public void NullableSbyteToBeNegativeSuccessful()
        {
            Given(() => (sbyte?)-42)
            .When(value => Requires.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Requires.ToBeNegative(sbyte?)")]
        public void NullableSbyteToBeNegativeFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(sbyte?)")]
        public void NullableSbyteToBeNegativeNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Requires.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(sbyte?)")]
        public void NullableSbyteToBeNegativeFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeNegative(sbyte?)")]
        public void NullableSbyteToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Requires.ToBeOneOf(sbyte?, others[])")]
        public void NullableSbyteToBeOneOfSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeOneOf(value, new sbyte?[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(sbyte?, others[])")]
        public void NullableSbyteToBeOneOfFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeOneOf(value, new sbyte?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(sbyte?, others[])")]
        public void NullableSbyteToBeOneOfNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Requires.ToBeOneOf(value, new sbyte?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(sbyte?, others[])")]
        public void NullableSbyteToBeOneOfFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeOneOf(value, new sbyte?[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBeOneOf(sbyte?, others[])")]
        public void NullableSbyteToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBeOneOf(value, new sbyte?[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Requires.ToBePositive(sbyte?)")]
        public void NullableSbyteToBePositiveSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Requires.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.ToBePositive(sbyte?)")]
        public void NullableSbyteToBePositiveFailed()
        {
            Given(() => (sbyte?)-42)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(sbyte?)")]
        public void NullableSbyteToBePositiveNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Requires.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(sbyte?)")]
        public void NullableSbyteToBePositiveFailedWithCustomException()
        {
            Given(() => (sbyte?)-42)
            .When(value => Requires.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Requires.ToBePositive(sbyte?)")]
        public void NullableSbyteToBePositiveFailedWithParameterizedException()
        {
            Given(() => (sbyte?)-42)
            .When(value => Requires.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}