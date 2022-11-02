using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using Bogus;

namespace BenchmarkTest
{
    [MemoryDiagnoser]
    public class Anonymize_Benchmark
    {
        private static List<string> _testCases = new List<string>();
        private static int count = 100;
        

        [Benchmark]
        public void Test1()
        {
            for (int i = 0; i < count; i++)
            { 
                var name = new Faker().Person.FullName;
                _testCases.Add(name);
            }

            _testCases.Add("");
            _testCases.Add("                    ");
            
            foreach (var name in _testCases)
            {
                Console.WriteLine(name.Anonymize1());
            }
        }
    }
}