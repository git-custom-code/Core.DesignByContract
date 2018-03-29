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
    public partial class UlongBenchmarks
    {
        [Benchmark(Baseline = true, Description = "Requires.ToBe throws (ulong)")]
        public void RequiresToBe()
        {
            ulong @ulong = 0;

            try
            {
                Requires.ToBe(@ulong, (i) => i > 42ul);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@ulong, (i) => i > 42ul, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@ulong, (i) => i > 42ul, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeBetween throws (ulong)")]
        public void RequiresToBeBetween()
        {
            ulong @ulong = 0;

            try
            {
                Requires.ToBeBetween(@ulong, 1ul, 42ul);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@ulong, 1ul, 42ul, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@ulong, 1ul, 42ul, (i, min, max) => new Exception($"Parameterized exception: {i}, {min}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThan throws (ulong)")]
        public void RequiresToBeGreaterThan()
        {
            ulong @ulong = 0;

            try
            {
                Requires.ToBeGreaterThan(@ulong, 42ul);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@ulong, 42ul, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@ulong, 42ul, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThanOrEqualTo throws (ulong)")]
        public void RequiresToBeGreaterThanOrEqualTo()
        {
            ulong @ulong = 0;

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@ulong, 42ul);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@ulong, 42ul, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@ulong, 42ul, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThan throws (ulong)")]
        public void RequiresToBeLessThan()
        {
            ulong @ulong = 42;

            try
            {
                Requires.ToBeLessThan(@ulong, 1ul);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@ulong, 1ul, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@ulong, 1ul, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThanOrEqualTo throws (ulong)")]
        public void RequiresToBeLessThanOrEqualTo()
        {
            ulong @ulong = 42;

            try
            {
                Requires.ToBeLessThanOrEqualTo(@ulong, 1ul);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@ulong, 1ul, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@ulong, 1ul, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeOneOf throws (ulong)")]
        public void RequiresToBeOneOf()
        {
            ulong @ulong = 42;

            try
            {
                Requires.ToBeOneOf(@ulong, new ulong[] { 1ul, 2ul, 3ul });
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@ulong, new ulong[] { 1ul, 2ul, 3ul }, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@ulong, new ulong[] { 1ul, 2ul, 3ul }, (i, ev) => new Exception($"Parameterized exception: {i}, {ev}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}