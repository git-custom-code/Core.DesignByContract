#define contracts_throw

namespace CustomCode.Core.DesignByContract.Benchmarks
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Attributes.Jobs;
    using BenchmarkDotNet.Diagnostics.Windows.Configs;
    using BenchmarkDotNet.Engines;
    using CustomCode.Core.DesignByContract;
    using System;


    [InliningDiagnoser(logFailuresOnly: false)]
    [SimpleJob(runStrategy: RunStrategy.ColdStart, launchCount: 0, warmupCount: 0, targetCount: 1)]
    public partial class NullableSbyteBenchmarks
    {
        [Benchmark(Baseline = true, Description = "Requires.ToBe throws (sbyte?)")]
        public void RequiresToBe()
        {
            sbyte? @sbyte = 0;

            try
            {
                Requires.ToBe(@sbyte, (i) => i > 42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@sbyte, (i) => i > 42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@sbyte, (i) => i > 42, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeBetween throws (sbyte?)")]
        public void RequiresToBeBetween()
        {
            sbyte? @sbyte = 0;

            try
            {
                Requires.ToBeBetween(@sbyte, (sbyte)1, (sbyte)42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@sbyte, (sbyte)1, (sbyte)42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@sbyte, (sbyte)1, (sbyte)42, (i, min, max) => new Exception($"Parameterized exception: {i}, {min}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThan throws (sbyte?)")]
        public void RequiresToBeGreaterThan()
        {
            sbyte? @sbyte = 0;

            try
            {
                Requires.ToBeGreaterThan(@sbyte, (sbyte)42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@sbyte, (sbyte)42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@sbyte, (sbyte)42, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThanOrEqualTo throws (sbyte?)")]
        public void RequiresToBeGreaterThanOrEqualTo()
        {
            sbyte? @sbyte = 0;

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@sbyte, (sbyte)42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@sbyte, (sbyte)42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@sbyte, (sbyte)42, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThan throws (sbyte?)")]
        public void RequiresToBeLessThan()
        {
            sbyte? @sbyte = 42;

            try
            {
                Requires.ToBeLessThan(@sbyte, (sbyte)1);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@sbyte, (sbyte)1, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@sbyte, (sbyte)1, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThanOrEqualTo throws (sbyte?)")]
        public void RequiresToBeLessThanOrEqualTo()
        {
            sbyte? @sbyte = 42;

            try
            {
                Requires.ToBeLessThanOrEqualTo(@sbyte, (sbyte)1);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@sbyte, (sbyte)1, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@sbyte, (sbyte)1, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeNegative throws (sbyte?)")]
        public void RequiresToBeNegative()
        {
            sbyte? @sbyte = 42;

            try
            {
                Requires.ToBeNegative(@sbyte);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeNegative(@sbyte, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeNegative(@sbyte, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeOneOf throws (sbyte?)")]
        public void RequiresToBeOneOf()
        {
            sbyte? @sbyte = 42;

            try
            {
                Requires.ToBeOneOf(@sbyte, new sbyte?[] { 1, 2, 3 });
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@sbyte, new sbyte?[] { 1, 2, 3 }, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@sbyte, new sbyte?[] { 1, 2, 3 }, (i, ev) => new Exception($"Parameterized exception: {i}, {ev}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBePositive throws (sbyte?)")]
        public void RequiresToBePositive()
        {
            sbyte? @sbyte = -42;

            try
            {
                Requires.ToBePositive(@sbyte);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBePositive(@sbyte, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBePositive(@sbyte, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}