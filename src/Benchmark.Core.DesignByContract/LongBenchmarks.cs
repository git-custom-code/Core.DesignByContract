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
    public partial class LongBenchmarks
    {
        [Benchmark(Baseline = true, Description = "Requires.ToBe throws (long)")]
        public void RequiresToBe()
        {
            long @long = 0;

            try
            {
                Requires.ToBe(@long, (i) => i > 42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@long, (i) => i > 42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@long, (i) => i > 42, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeBetween throws (long)")]
        public void RequiresToBeBetween()
        {
            long @long = 0;

            try
            {
                Requires.ToBeBetween(@long, 1L, 42L);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@long, 1L, 42L, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@long, 1L, 42L, (i, min, max) => new Exception($"Parameterized exception: {i}, {min}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThan throws (long)")]
        public void RequiresToBeGreaterThan()
        {
            long @long = 0;

            try
            {
                Requires.ToBeGreaterThan(@long, 42L);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@long, 42L, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@long, 42L, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThanOrEqualTo throws (long)")]
        public void RequiresToBeGreaterThanOrEqualTo()
        {
            long @long = 0;

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@long, 42L);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@long, 42L, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@long, 42L, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThan throws (long)")]
        public void RequiresToBeLessThan()
        {
            long @long = 42;

            try
            {
                Requires.ToBeLessThan(@long, 1L);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@long, 1L, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@long, 1L, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThanOrEqualTo throws (long)")]
        public void RequiresToBeLessThanOrEqualTo()
        {
            long @long = 42;

            try
            {
                Requires.ToBeLessThanOrEqualTo(@long, 1L);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@long, 1L, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@long, 1L, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeNegative throws (long)")]
        public void RequiresToBeNegative()
        {
            long @long = 42;

            try
            {
                Requires.ToBeNegative(@long);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeNegative(@long, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeNegative(@long, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeOneOf throws (long)")]
        public void RequiresToBeOneOf()
        {
            long @long = 42;

            try
            {
                Requires.ToBeOneOf(@long, new long[] { 1L, 2L, 3L });
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@long, new long[] { 1L, 2L, 3L }, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@long, new long[] { 1L, 2L, 3L }, (i, ev) => new Exception($"Parameterized exception: {i}, {ev}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBePositive throws (long)")]
        public void RequiresToBePositive()
        {
            long @long = -42;

            try
            {
                Requires.ToBePositive(@long);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBePositive(@long, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBePositive(@long, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}