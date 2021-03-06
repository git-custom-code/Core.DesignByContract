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
    public partial class NullableDoubleBenchmarks
    {
        [Benchmark(Baseline = true, Description = "Requires.ToBe throws (double?)")]
        public void RequiresToBe()
        {
            double? @double = 0;

            try
            {
                Requires.ToBe(@double, (i) => i > 42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@double, (i) => i > 42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@double, (i) => i > 42, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeBetween throws (double?)")]
        public void RequiresToBeBetween()
        {
            double? @double = 0;

            try
            {
                Requires.ToBeBetween(@double, 1, 42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@double, 1, 42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@double, 1, 42, (i, min, max) => new Exception($"Parameterized exception: {i}, {min}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThan throws (double?)")]
        public void RequiresToBeGreaterThan()
        {
            double? @double = 0;

            try
            {
                Requires.ToBeGreaterThan(@double, 42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@double, 42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@double, 42, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThanOrEqualTo throws (double?)")]
        public void RequiresToBeGreaterThanOrEqualTo()
        {
            double? @double = 0;

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@double, 42);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@double, 42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@double, 42, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThan throws (double?)")]
        public void RequiresToBeLessThan()
        {
            double? @double = 42;

            try
            {
                Requires.ToBeLessThan(@double, 1);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@double, 1, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@double, 1, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThanOrEqualTo throws (double?)")]
        public void RequiresToBeLessThanOrEqualTo()
        {
            double? @double = 42;

            try
            {
                Requires.ToBeLessThanOrEqualTo(@double, 1);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@double, 1, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@double, 1, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeNegative throws (double?)")]
        public void RequiresToBeNegative()
        {
            double? @double = 42;

            try
            {
                Requires.ToBeNegative(@double);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeNegative(@double, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeNegative(@double, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeOneOf throws (double?)")]
        public void RequiresToBeOneOf()
        {
            double? @double = 42;

            try
            {
                Requires.ToBeOneOf(@double, new double?[] { 1, 2, 3 });
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@double, new double?[] { 1, 2, 3 }, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@double, new double?[] { 1, 2, 3 }, (i, ev) => new Exception($"Parameterized exception: {i}, {ev}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBePositive throws (double?)")]
        public void RequiresToBePositive()
        {
            double? @double = -42;

            try
            {
                Requires.ToBePositive(@double);
            }
            catch (ArgumentException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBePositive(@double, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBePositive(@double, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}