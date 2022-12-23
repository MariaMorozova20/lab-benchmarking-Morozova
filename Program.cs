using System;
using System.IO;
namespace lab_benchmark_Morozova
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter file = new StreamWriter("Output.txt");
            int[] razm = new int[] { 1000, 10000, 100000, 1000000 };
            Benchmarking benchM = new Benchmarking(razm);
            benchM.Benchmark();
            file.WriteLine(benchM.ResultOut());
            file.Close();
            Console.WriteLine(benchM.ResultOut());
        }
    }
}
