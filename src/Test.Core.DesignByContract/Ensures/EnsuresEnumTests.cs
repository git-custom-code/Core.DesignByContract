#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Test.BehaviorDrivenDevelopment.Enum;
    using Xunit;

    [UnitTest]
    [Category("Enum", "Ensures")]
    public sealed class EnsuresEnumTests : TestCase
    {
        #region ToBe

        [Fact(DisplayName = "Ensures.ToBe(enum, condition)")]
        public void EnumToBeSuccessful()
        {
            Given(() => StringComparison.Ordinal)
            .When(value => Ensures.ToBe(value, v => v == StringComparison.Ordinal))
            .Then(value => value.Should().Be(StringComparison.Ordinal));
        }

        [Fact(DisplayName = "Ensures.ToBe(enum, condition)")]
        public void EnumToBeFailed()
        {
            Given(() => StringComparison.Ordinal)
            .When(value => Ensures.ToBe(value, v => v != StringComparison.Ordinal))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(enum, condition)")]
        public void EnumToBeFailedWithCustomException()
        {
            Given(() => StringComparison.Ordinal)
            .When(value => Ensures.ToBe(value, v => v != StringComparison.Ordinal, () => new ArgumentOutOfRangeException()))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        [Fact(DisplayName = "Ensures.ToBe(enum, condition)")]
        public void EnumToBeFailedWithParameterizedException()
        {
            Given(() => StringComparison.Ordinal)
            .When(value => Ensures.ToBe(value, v => v != StringComparison.Ordinal, v => new ArgumentOutOfRangeException($"Invalid value: {v}")))
            .ThenThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}