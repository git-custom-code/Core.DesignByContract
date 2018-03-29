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
    public partial class UshortBenchmarks
    {
        [Benchmark(Baseline = true, Description = "Requires.ToBe throws (ushort)")]
        public void RequiresToBe()
        {
            ushort @ushort = 0;

            try
            {
                Requires.ToBe(@ushort, (i) => i > (ushort)42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@ushort, (i) => i > (ushort)42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@ushort, (i) => i > (ushort)42, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeBetween throws (ushort)")]
        public void RequiresToBeBetween()
        {
            ushort @ushort = 0;

            try
            {
                Requires.ToBeBetween(@ushort, (ushort)1, (ushort)42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@ushort, (ushort)1, (ushort)42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@ushort, (ushort)1, (ushort)42, (i, min, max) => new Exception($"Parameterized exception: {i}, {min}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThan throws (ushort)")]
        public void RequiresToBeGreaterThan()
        {
            ushort @ushort = 0;

            try
            {
                Requires.ToBeGreaterThan(@ushort, (ushort)42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@ushort, (ushort)42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@ushort, (ushort)42, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThanOrEqualTo throws (ushort)")]
        public void RequiresToBeGreaterThanOrEqualTo()
        {
            ushort @ushort = 0;

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@ushort, (ushort)42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@ushort, (ushort)42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@ushort, (ushort)42, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThan throws (ushort)")]
        public void RequiresToBeLessThan()
        {
            ushort @ushort = 42;

            try
            {
                Requires.ToBeLessThan(@ushort, (ushort)1);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@ushort, (ushort)1, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@ushort, (ushort)1, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThanOrEqualTo throws (ushort)")]
        public void RequiresToBeLessThanOrEqualTo()
        {
            ushort @ushort = 42;

            try
            {
                Requires.ToBeLessThanOrEqualTo(@ushort, (ushort)1);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@ushort, (ushort)1, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@ushort, (ushort)1, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeOneOf throws (ushort)")]
        public void RequiresToBeOneOf()
        {
            ushort @ushort = 42;

            try
            {
                Requires.ToBeOneOf(@ushort, new ushort[] { (ushort)1, (ushort)2, (ushort)3 });
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@ushort, new ushort[] { (ushort)1, (ushort)2, (ushort)3 }, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@ushort, new ushort[] { (ushort)1, (ushort)2, (ushort)3 }, (i, ev) => new Exception($"Parameterized exception: {i}, {ev}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}