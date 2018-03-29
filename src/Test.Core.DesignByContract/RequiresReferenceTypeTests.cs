#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    /// <summary>
    /// Test cases for preconditions related to reference types.
    /// </summary>
    [UnitTest]
    [Category("ReferenceType", "Requires")]
    public sealed class RequiresReferenceTypeTests : TestCase
    {
        [Fact(DisplayName = "Requires.NotToBeNull(object)")]
        public void NullableNotToBeNullSuccessful()
        {
            Given(() => new object())
            .When(value => Requires.NotToBeNull(value))
            .Then(value => value.ShouldNot().BeNull());
        }

        [Fact(DisplayName = "Requires.NotToBeNull(null)")]
        public void NullableNotToBeNullFailed()
        {
            Given(() => (object)null)
            .When(value => Requires.NotToBeNull(value))
            .ThenThrow<ArgumentNullException>();
        }

        [Fact(DisplayName = "Requires.NotToBeNull(null)")]
        public void NullableNotToBeNullFailedWithCustomExeption()
        {
            Given(() => (object)null)
            .When(value => Requires.NotToBeNull(value, () => new ArgumentException()))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Requires.NotToBeNull(null)")]
        public void NullableNotToBeNullFailedWithCustomParameterException()
        {
            Given(() => (object)null)
            .When(value => Requires.NotToBeNull(value, v => new ArgumentException($"Invalid value: {v}")))
            .ThenThrow<ArgumentException>();
        }
    }
}