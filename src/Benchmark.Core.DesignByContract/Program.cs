namespace CustomCode.Core.DesignByContract.Benchmarks
{
    using BenchmarkDotNet.Running;
    using System;

    /// <summary>
    /// Benchmark entry point.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// Benchmark entry point.
        /// </summary>
        /// <param name="args"> Optional console arguments. </param>
        private static void Main(string[] args)
        {
            var benchmarks = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly);
            benchmarks.Run(args);
            Console.ReadKey();
        }
    }
}