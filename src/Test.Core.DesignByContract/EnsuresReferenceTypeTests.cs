#define contracts_throw

namespace CustomCode.Core.DesignByContract.Tests
{
    using System;
    using Test.BehaviorDrivenDevelopment;
    using Xunit;

    /// <summary>
    /// Test cases for postconditions related to reference types.
    /// </summary>
    [UnitTest]
    [Category("ReferenceType", "Ensures")]
    public sealed class EnsuresReferenceTypeTests : TestCase
    {
        [Fact(DisplayName = "Ensures.NotToBeNull(object)")]
        public void ReferenceTypeNotToBeNullSuccessful()
        {
            Given(() => new object())
            .When(value => Ensures.NotToBeNull(value))
            .Then(value => value.ShouldNot().BeNull());
        }

        [Fact(DisplayName = "Ensures.NotToBeNull(null)")]
        public void ReferenceTypeNotToBeNullFailed()
        {
            Given(() => (object)null)
            .When(value => Ensures.NotToBeNull(value))
            .ThenThrow<ArgumentNullException>();
        }

        [Fact(DisplayName = "Ensures.NotToBeNull(null)")]
        public void ReferenceTypeNotToBeNullFailedWithCustomExeption()
        {
            Given(() => (object)null)
            .When(value => Ensures.NotToBeNull(value, () => new ArgumentException()))
            .ThenThrow<ArgumentException>();
        }

        [Fact(DisplayName = "Ensures.NotToBeNull(null)")]
        public void ReferenceTypeNotToBeNullFailedWithCustomParameterException()
        {
            Given(() => (object)null)
            .When(value => Ensures.NotToBeNull(value, v => new ArgumentException($"Invalid value: {v}")))
            .ThenThrow<ArgumentException>();
        }
    }
}