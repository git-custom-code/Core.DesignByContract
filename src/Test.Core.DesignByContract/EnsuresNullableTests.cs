#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    /// <summary>
    /// Test cases for postconditions related to <see cref="Nullable{T}"/> data types.
    /// </summary>
    [UnitTest]
    [Category("Nullable", "Ensures")]
    public sealed class EnsuresNullableTests : TestCase
    {
        [Fact(DisplayName = "Ensures.NotToBeNull(nullable)")]
        public void NullableNotToBeNullSuccessful()
        {
            Given(() => (int?)42)
            .When(value => Ensures.NotToBeNull(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Ensures.NotToBeNull(null)")]
        public void NullableNotToBeNullFailed()
        {
            Given(() => (int?)null)
            .When(value => Ensures.NotToBeNull(value))
            .ThenThrow<ArgumentNullException>();
        }

        [Fact(DisplayName = "Ensures.NotToBeNull(null)")]
        public void NullableNotToBeNullFailedWithCustomExeption()
        {
            Given(() => (int?)null)
            .When(value => Ensures.NotToBeNull(value, () => new ArgumentException()))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.NotToBeNull(null)")]
        public void NullableNotToBeNullFailedWithCustomParameterException()
        {
            Given(() => (int?)null)
            .When(value => Ensures.NotToBeNull(value, v => new ArgumentException($"Invalid value: {v}")))
            .ThenThrow<ArgumentException>();
        }
    }
}