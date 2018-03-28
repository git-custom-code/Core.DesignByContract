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
    public partial class NullableBenchmarks
    {
        [Benchmark(Baseline = true, Description = "Requires.NotToBeNull throws (int?)")]
        public void RequiresNotToBeNull()
        {
            int? @int = null;

            try
            {
                Requires.NotToBeNull(@int);
            }
            catch (ArgumentNullException)
            {
                // do nothing
            }

            try
            {
                Requires.NotToBeNull(@int, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.NotToBeNull(@int, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}