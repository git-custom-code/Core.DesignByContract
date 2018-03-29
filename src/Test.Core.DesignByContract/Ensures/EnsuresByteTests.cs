#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    [UnitTest]
    [Category("Byte", "Ensures")]
    public sealed class EnsuresByteTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Ensures.ToBe(byte, condition)")]
        public void ByteToBeSuccessful()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBe(value, v => v == (byte)42))
            .Then(value => value.Should().Be((byte)42));
        }

        [Fact(DisplayName = "Ensures.ToBe(byte, condition)")]
        public void ByteToBeFailed()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBe(value, v => v != (byte)42))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(byte, condition)")]
        public void ByteToBeFailedWithCustomException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBe(value, v => v != (byte)42, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(byte, condition)")]
        public void ByteToBeFailedWithParameterizedException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBe(value, v => v != (byte)42, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeBetween

        [Fact(DisplayName = "Ensures.ToBeBetween(byte, min, max)")]
        public void ByteToBeBetweenSuccessful()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeBetween(value, (byte)1, (byte)100))
            .Then(value => value.Should().Be((byte)42));
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(byte, max, min)")]
        public void ByteToBeBetweenFailed()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeBetween(value, (byte)100, (byte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(byte, max, min)")]
        public void ByteToBeBetweenFailedWithCustomException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeBetween(value, (byte)100, (byte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeBetween(byte, max, min)")]
        public void ByteToBeBetweenFailedWithParameterizedException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeBetween(value, (byte)100, (byte)1, (v, min, max) => new ArgumentOutOfRangeException($"Invalid value: {v} not between {min} and {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThan

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(byte, min)")]
        public void ByteToBeGreaterThanSuccessful()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeGreaterThan(value, (byte)1))
            .Then(value => value.Should().Be((byte)42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(byte, max)")]
        public void ByteToBeGreaterThanFailed()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeGreaterThan(value, (byte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(byte, max)")]
        public void ByteToBeGreaterThanFailedWithCustomException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeGreaterThan(value, (byte)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThan(byte, max)")]
        public void ByteToBeGreaterThanFailedWithParameterizedException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeGreaterThan(value, (byte)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} <= {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeGreaterThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(byte, min)")]
        public void ByteToBeGreaterThanOrEqualToSuccessful()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (byte)1))
            .Then(value => value.Should().Be((byte)42));
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(byte, max)")]
        public void ByteToBeGreaterThanOrEqualToFailed()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (byte)100))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(byte, max)")]
        public void ByteToBeGreaterThanOrEqualToFailedWithCustomException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (byte)100, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeGreaterThanOrEqualTo(byte, max)")]
        public void ByteToBeGreaterThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeGreaterThanOrEqualTo(value, (byte)100, (v, min) => new ArgumentOutOfRangeException($"Invalid value: {v} < {min}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThan

        [Fact(DisplayName = "Ensures.ToBeLessThan(byte, max)")]
        public void ByteToBeLessThanSuccessful()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeLessThan(value, (byte)100))
            .Then(value => value.Should().Be((byte)42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(byte, min)")]
        public void ByteToBeLessThanFailed()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeLessThan(value, (byte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(byte, min)")]
        public void ByteToBeLessThanFailedWithCustomException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeLessThan(value, (byte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThan(byte, min)")]
        public void ByteToBeLessThanFailedWithParameterizedException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeLessThan(value, (byte)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} >= {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeLessThanOrEqualTo

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(byte, max)")]
        public void ByteToBeLessThanOrEqualToSuccessful()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (byte)100))
            .Then(value => value.Should().Be((byte)42));
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(byte, min)")]
        public void ByteToBeLessThanOrEqualToFailed()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (byte)1))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(byte, min)")]
        public void ByteToBeLessThanOrEqualToFailedWithCustomException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (byte)1, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeLessThanOrEqualTo(byte, min)")]
        public void ByteToBeLessThanOrEqualToFailedWithParameterizedException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeLessThanOrEqualTo(value, (byte)1, (v, max) => new ArgumentOutOfRangeException($"Invalid value: {v} > {max}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        #region ToBeOneOf

        [Fact(DisplayName = "Ensures.ToBeOneOf(byte, others[])")]
        public void ByteToBeOneOfSuccessful()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { (byte)1, (byte)2, (byte)42 }))
            .Then(value => value.Should().Be((byte)42));
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(byte, others[])")]
        public void ByteToBeOneOfFailed()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { (byte)1, (byte)2 }))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(byte, others[])")]
        public void ByteToBeOneOfFailedWithCustomException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { (byte)1, (byte)2 }, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBeOneOf(byte, others[])")]
        public void ByteToBeOneOfFailedWithParameterizedException()
        {
            Given(() => (byte)42)
            .When(value => Ensures.ToBeOneOf(value, new[] { (byte)1, (byte)2 }, (v, others) => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}