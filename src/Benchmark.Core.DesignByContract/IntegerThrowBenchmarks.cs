#define contracts_throw
#undef contracts_trace

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
    public partial class IntegerThrowBenchmarks
    {
        [Benchmark(Baseline = true, Description = "Requires.ToBe throws (int)")]
        public void RequireseToBe()
        {
            var @int = 0;

            try
            {
                Requires.ToBe(@int, (i) => i > 42);
            }
            catch (ArgumentNullException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@int, (i) => i > 42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBe(@int, (i) => i > 42, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeBetween throws (int)")]
        public void RequireseToBeBetween()
        {
            var @int = 0;

            try
            {
                Requires.ToBeBetween(@int, 1, 42);
            }
            catch (ArgumentNullException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@int, 1, 42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeBetween(@int, 1, 42, (i, min, max) => new Exception($"Parameterized exception: {i}, {min}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThan throws (int)")]
        public void RequireseToBeGreaterThan()
        {
            var @int = 0;

            try
            {
                Requires.ToBeGreaterThan(@int, 42);
            }
            catch (ArgumentNullException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@int, 42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThan(@int, 42, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThanOrEqualTo throws (int)")]
        public void RequireseToBeGreaterThanOrEqualTo()
        {
            var @int = 0;

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@int, 42);
            }
            catch (ArgumentNullException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@int, 42, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeGreaterThanOrEqualTo(@int, 42, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThan throws (int)")]
        public void RequireseToBeLessThan()
        {
            var @int = 42;

            try
            {
                Requires.ToBeLessThan(@int, 1);
            }
            catch (ArgumentNullException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@int, 1, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThan(@int, 1, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThanOrEqualTo throws (int)")]
        public void RequireseToBeLessThanOrEqualTo()
        {
            var @int = 42;

            try
            {
                Requires.ToBeLessThanOrEqualTo(@int, 1);
            }
            catch (ArgumentNullException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@int, 1, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeLessThanOrEqualTo(@int, 1, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeNegative throws (int)")]
        public void RequireseToBeNegative()
        {
            var @int = 42;

            try
            {
                Requires.ToBeNegative(@int);
            }
            catch (ArgumentNullException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeNegative(@int, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeNegative(@int, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeOneOf throws (int)")]
        public void RequireseToBeOneOf()
        {
            var @int = 42;

            try
            {
                Requires.ToBeOneOf(@int, new[] { 1, 2, 3 });
            }
            catch (ArgumentNullException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@int, new[] { 1, 2, 3 }, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBeOneOf(@int, new[] { 1, 2, 3 }, (i, ev) => new Exception($"Parameterized exception: {i}, {ev}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBePositive throws (int)")]
        public void RequireseToBePositive()
        {
            var @int = -42;

            try
            {
                Requires.ToBePositive(@int);
            }
            catch (ArgumentNullException)
            {
                // do nothing
            }

            try
            {
                Requires.ToBePositive(@int, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.ToBePositive(@int, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}