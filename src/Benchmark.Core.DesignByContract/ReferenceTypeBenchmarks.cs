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
    public partial class ReferenceTypeBenchmarks
    {
        [Benchmark(Baseline = true, Description = "Requires.NotToBeNull throws (object)")]
        public void RequiresNotToBeNull()
        {
            object @object = null;

            try
            {
                Requires.NotToBeNull(@object);
            }
            catch (ArgumentNullException)
            {
                // do nothing
            }

            try
            {
                Requires.NotToBeNull(@object, () => new Exception("Custom exception"));
            }
            catch (Exception)
            {
                // do nothing
            }

            try
            {
                Requires.NotToBeNull(@object, (i) => new Exception($"Parameterized exception: {i}"));
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}