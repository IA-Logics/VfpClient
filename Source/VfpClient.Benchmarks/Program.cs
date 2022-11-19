using BenchmarkDotNet.Running;

namespace VfpClient.Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
