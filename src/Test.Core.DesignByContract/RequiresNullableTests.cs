#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    /// <summary>
    /// Test cases for preconditions related to <see cref="Nullable{T}"/> data types.
    /// </summary>
    [UnitTest]
    [Category("Nullable", "Requires")]
    public sealed class RequiresNullableTests : TestCase
    {
        [Fact(DisplayName = "Requires.NotToBeNull(nullable)")]
        public void NullableNotToBeNullSuccessful()
        {
            Given(() => (int?)42)
            .When(value => Requires.NotToBeNull(value))
            .Then(value => value.Should().Be(42));
        }

        [Fact(DisplayName = "Requires.NotToBeNull(null)")]
        public void NullableNotToBeNullFailed()
        {
            Given(() => (int?)null)
            .When(value => Requires.NotToBeNull(value))
            .ThenThrow<ArgumentNullException>();
        }

        [Fact(DisplayName = "Requires.NotToBeNull(null)")]
        public void NullableNotToBeNullFailedWithCustomExeption()
        {
            Given(() => (int?)null)
            .When(value => Requires.NotToBeNull(value, () => new ArgumentException()))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.NotToBeNull(null)")]
        public void NullableNotToBeNullFailedWithCustomParameterException()
        {
            Given(() => (int?)null)
            .When(value => Requires.NotToBeNull(value, v => new ArgumentException($"Invalid value: {v}")))
            .ThenThrow<ArgumentException>();
        }
    }
}