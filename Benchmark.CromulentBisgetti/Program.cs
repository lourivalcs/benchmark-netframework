using BenchmarkDotNet.Running;
using System;

namespace Benchmark.CromulentBisgetti
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkAlgorithm>();
            Console.Read();
        }
    }
}
