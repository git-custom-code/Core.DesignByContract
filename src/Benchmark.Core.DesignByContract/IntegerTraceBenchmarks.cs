#define contracts_trace
#undef contracts_throw

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
    public partial class IntegerTraceBenchmarks
    {
        [Benchmark(Baseline = true, Description = "Requires.ToBe throws (int)")]
        public void RequireseToBe()
        {
            var @int = 0;
            Requires.ToBe(@int, (i) => i > 42);
            Requires.ToBe(@int, (i) => i > 42, () => new Exception("Custom exception"));
            Requires.ToBe(@int, (i) => i > 42, (i) => new Exception($"Parameterized exception: {i}"));
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeBetween throws (int)")]
        public void RequireseToBeBetween()
        {
            var @int = 0;
            Requires.ToBeBetween(@int, 1, 42);
            Requires.ToBeBetween(@int, 1, 42, () => new Exception("Custom exception"));
            Requires.ToBeBetween(@int, 1, 42, (i, min, max) => new Exception($"Parameterized exception: {i}, {min}, {max}"));
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThan throws (int)")]
        public void RequireseToBeGreaterThan()
        {
            var @int = 0;
            Requires.ToBeGreaterThan(@int, 42);
            Requires.ToBeGreaterThan(@int, 42, () => new Exception("Custom exception"));
            Requires.ToBeGreaterThan(@int, 42, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeGreaterThanOrEqualTo throws (int)")]
        public void RequireseToBeGreaterThanOrEqualTo()
        {
            var @int = 0;
            Requires.ToBeGreaterThanOrEqualTo(@int, 42);
            Requires.ToBeGreaterThanOrEqualTo(@int, 42, () => new Exception("Custom exception"));
            Requires.ToBeGreaterThanOrEqualTo(@int, 42, (i, min) => new Exception($"Parameterized exception: {i}, {min}"));
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThan throws (int)")]
        public void RequireseToBeLessThan()
        {
            var @int = 42;
            Requires.ToBeLessThan(@int, 1);
            Requires.ToBeLessThan(@int, 1, () => new Exception("Custom exception"));
            Requires.ToBeLessThan(@int, 1, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeLessThanOrEqualTo throws (int)")]
        public void RequireseToBeLessThanOrEqualTo()
        {
            var @int = 42;
            Requires.ToBeLessThanOrEqualTo(@int, 1);
            Requires.ToBeLessThanOrEqualTo(@int, 1, () => new Exception("Custom exception"));
            Requires.ToBeLessThanOrEqualTo(@int, 1, (i, max) => new Exception($"Parameterized exception: {i}, {max}"));
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeNegative throws (int)")]
        public void RequireseToBeNegative()
        {
            var @int = 42;
            Requires.ToBeNegative(@int);
            Requires.ToBeNegative(@int, () => new Exception("Custom exception"));
            Requires.ToBeNegative(@int, (i) => new Exception($"Parameterized exception: {i}"));
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBeOneOf throws (int)")]
        public void RequireseToBeOneOf()
        {
            var @int = 42;
            Requires.ToBeOneOf(@int, new[] { 1, 2, 3 });
            Requires.ToBeOneOf(@int, new[] { 1, 2, 3 }, () => new Exception("Custom exception"));
            Requires.ToBeOneOf(@int, new[] { 1, 2, 3 }, (i, ev) => new Exception($"Parameterized exception: {i}, {ev}"));
        }

        [Benchmark(Baseline = false, Description = "Requires.ToBePositive throws (int)")]
        public void RequireseToBePositive()
        {
            var @int = -42;
            Requires.ToBePositive(@int);
            Requires.ToBePositive(@int, () => new Exception("Custom exception"));
            Requires.ToBePositive(@int, (i) => new Exception($"Parameterized exception: {i}"));
        }
    }
}