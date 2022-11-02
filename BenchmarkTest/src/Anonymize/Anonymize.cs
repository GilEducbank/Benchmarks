using System;
using System.Linq;

namespace BenchmarkTest
{
    public static class Anonymize
    {
        public static string Anonymize1(this string name) => name == null ? "" : String.Join(" ", name.Split(' ').Select(AnonymizeSingle));

        private static string AnonymizeSingle(string s) => s == null ? "" : s.Trim().Length > 0 ? $"{s.First()}***" : "";
    }
}