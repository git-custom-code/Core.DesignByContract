#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Sbyte", "Ensures")]
    public sealed class EnsuresNullableSbyteTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Ensures.ToBe(sbyte?, condition)")]
        public void NullableSbyteToBeSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBe(value, v => v == 42))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBe(sbyte?, condition)")]
        public void NullableSbyteToBeNullSuccessful()
        {
            Given(() => (sbyte?)null)
            .When(value => Ensures.ToBe(value, v => v == null))
            .Then(value => value.Should().Be(null));
        }

        [Fact(DisplayName = "Ensures.ToBe(sbyte?, condition)")]
        public void NullableSbyteToBeFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBe(value, v => v != 42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(sbyte?, condition)")]
        public void NullableSbyteToBeNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Ensures.ToBe(value, v => v != null))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(sbyte?, condition)")]
        public void NullableSbyteToBeFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBe(value, v => v != 42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(sbyte?, condition)")]
        public void NullableSbyteToBeFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBe(value, v => v != 42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Ensures.ToBeBetween(sbyte?, min, max)")]
        public void NullableSbyteToBeBetweenSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeBetween(value, (sbyte)1, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(sbyte?, max, min)")]
        public void NullableSbyteToBeBetweenFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeBetween(value, (sbyte)100, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(sbyte?, max, min)")]
        public void NullableSbyteToBeBetweenNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Ensures.ToBeBetween(value, (sbyte)100, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(sbyte?, max, min)")]
        public void NullableSbyteToBeBetweenFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeBetween(value, (sbyte)100, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(sbyte?, max, min)")]
        public void NullableSbyteToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeBetween(value, (sbyte)100, (sbyte)1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(sbyte?, min)")]
        public void NullableSbyteToBeGreaterThanSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeGreaterThan(value, (sbyte)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeGreaterThan(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Ensures.ToBeGreaterThan(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeGreaterThan(value, (sbyte)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeGreaterThan(value, (sbyte)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(sbyte?, min)")]
        public void NullableSbyteToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (sbyte)1))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanOrEqualToNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (sbyte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (sbyte)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(sbyte?, max)")]
        public void NullableSbyteToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (sbyte)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Ensures.ToBeLessThan(sbyte?, max)")]
        public void NullableSbyteToBeLessThanSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeLessThan(value, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(sbyte?, min)")]
        public void NullableSbyteToBeLessThanFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeLessThan(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(sbyte?, min)")]
        public void NullableSbyteToBeLessThanNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Ensures.ToBeLessThan(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(sbyte?, min)")]
        public void NullableSbyteToBeLessThanFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeLessThan(value, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(sbyte?, min)")]
        public void NullableSbyteToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeLessThan(value, (sbyte)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(sbyte?, max)")]
        public void NullableSbyteToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (sbyte)100))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(sbyte?, min)")]
        public void NullableSbyteToBeLessThanOrEqualToFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(sbyte?, min)")]
        public void NullableSbyteToBeLessThanOrEqualToNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (sbyte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(sbyte?, min)")]
        public void NullableSbyteToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (sbyte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(sbyte?, min)")]
        public void NullableSbyteToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (sbyte)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeNegative

        [Fact(DisplayName = "Ensures.ToBeNegative(sbyte?)")]
        public void NullableSbyteToBeNegativeSuccessful()
        {
            Given(() => (sbyte?)-42)
            .When(value => Ensures.ToBeNegative(value))
            .Then(value => value.Should().Be(-42));
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(sbyte?)")]
        public void NullableSbyteToBeNegativeFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(sbyte?)")]
        public void NullableSbyteToBeNegativeNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Ensures.ToBeNegative(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(sbyte?)")]
        public void NullableSbyteToBeNegativeFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeNegative(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeNegative(sbyte?)")]
        public void NullableSbyteToBeNegativeFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeNegative(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Ensures.ToBeOneOf(sbyte?, others[])")]
        public void NullableSbyteToBeOneOfSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeOneOf(value, new sbyte?[] { 1, 2, 42 }))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(sbyte?, others[])")]
        public void NullableSbyteToBeOneOfFailed()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeOneOf(value, new sbyte?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(sbyte?, others[])")]
        public void NullableSbyteToBeOneOfNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Ensures.ToBeOneOf(value, new sbyte?[] { 1, 2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(sbyte?, others[])")]
        public void NullableSbyteToBeOneOfFailedWithCustomException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeOneOf(value, new sbyte?[] { 1, 2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(sbyte?, others[])")]
        public void NullableSbyteToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBeOneOf(value, new sbyte?[] { 1, 2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBePositive

        [Fact(DisplayName = "Ensures.ToBePositive(sbyte?)")]
        public void NullableSbyteToBePositiveSuccessful()
        {
            Given(() => (sbyte?)42)
            .When(value => Ensures.ToBePositive(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.ToBePositive(sbyte?)")]
        public void NullableSbyteToBePositiveFailed()
        {
            Given(() => (sbyte?)-42)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(sbyte?)")]
        public void NullableSbyteToBePositiveNullFailed()
        {
            Given(() => (sbyte?)null)
            .When(value => Ensures.ToBePositive(value))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(sbyte?)")]
        public void NullableSbyteToBePositiveFailedWithCustomException()
        {
            Given(() => (sbyte?)-42)
            .When(value => Ensures.ToBePositive(value, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBePositive(sbyte?)")]
        public void NullableSbyteToBePositiveFailedWithParameterizedException()
        {
            Given(() => (sbyte?)-42)
            .When(value => Ensures.ToBePositive(value, (v) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}