using System;
using BenchmarkDotNet.Running;

namespace BenchmarkTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("### Usando BenchmarkDotNet  ###\n");
            Console.WriteLine("Pressione algo para iniciar\n");
            Console.ReadLine();
            var resultado = BenchmarkRunner.Run<Anonymize_Benchmark>();
        }
    }
}