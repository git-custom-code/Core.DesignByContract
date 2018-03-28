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
    public partial class ShortBenchmarks
    {
        [Benchmark(Baseline = true, Description = "Requires.ToBe throws (short)")]
        public void RequiresToBe()
        {
            short @short = 0;

            try
            {
                Requires.ToBe(@short, (i) => i > 42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@short, (i) => i > 42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@short, (i) => i > 42, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeBetween throws (short)")]
        public void RequiresToBeBetween()
        {
            short @short = 0;

            try
            {
                Requires.ToBeBetween(@short, (short)1, (short)42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@short, (short)1, (short)42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@short, (short)1, (short)42, (i, min, max) => new Exception($"Parameterized exception: {i}, {min}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThan throws (short)")]
        public void RequiresToBeGreaterThan()
        {
            short @short = 0;

            try
            {
                Requires.ToBeGreaterThan(@short, (short)42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@short, (short)42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@short, (short)42, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThanOrEqualTo throws (short)")]
        public void RequiresToBeGreaterThanOrEqualTo()
        {
            short @short = 0;

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@short, (short)42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@short, (short)42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@short, (short)42, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThan throws (short)")]
        public void RequiresToBeLessThan()
        {
            short @short = 42;

            try
            {
                Requires.ToBeLessThan(@short, (short)1);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@short, (short)1, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@short, (short)1, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThanOrEqualTo throws (short)")]
        public void RequiresToBeLessThanOrEqualTo()
        {
            short @short = 42;

            try
            {
                Requires.ToBeLessThanOrEqualTo(@short, (short)1);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@short, (short)1, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@short, (short)1, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeNegative throws (short)")]
        public void RequiresToBeNegative()
        {
            short @short = 42;

            try
            {
                Requires.ToBeNegative(@short);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeNegative(@short, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeNegative(@short, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeOneOf throws (short)")]
        public void RequiresToBeOneOf()
        {
            short @short = 42;

            try
            {
                Requires.ToBeOneOf(@short, new[] { 1, 2, 3 });
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@short, new[] { 1, 2, 3 }, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@short, new[] { 1, 2, 3 }, (i, ev) => new Exception($"Parameterized exception: {i}, {ev}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBePositive throws (short)")]
        public void RequiresToBePositive()
        {
            short @short = -42;

            try
            {
                Requires.ToBePositive(@short);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBePositive(@short, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBePositive(@short, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}