using System.Numerics;
using BenchmarkDotNet.Attributes;

namespace BenchmarkTest
{
    [MemoryDiagnoser]
    public class Fibonacci
    {
        private static int ValueToTest = 10000;
        
        public BigInteger BruteForceResult()
        {
            return BruteForce(ValueToTest);
        }
       
        [Benchmark]
        public BigInteger MemoResult()
        {
            return Memo(ValueToTest);
        }
        [Benchmark]
        public BigInteger MemoTwoResult()
        {
            return Memo2(ValueToTest);
        }
        
        [Benchmark]
        public BigInteger LogNResult()
        {
            return LogN(ValueToTest);
        }
        
        public static BigInteger BruteForce(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            return BruteForce(n - 1) + BruteForce(n - 2);
        }
        
        public static BigInteger Memo(int n)
        {

            BigInteger[] memo = new BigInteger[n + 1];
            memo[0] = 0;
            if (n > 0)
                memo[1] = 1;

            for (int i = 2; i <= n; i++)
                memo[i] = memo[i - 1] + memo[i - 2];

            return memo[n];
        }
        
        public static BigInteger Memo2(int n)
        {
            if (n == 0)
                return 0;
            BigInteger a = 0;
            BigInteger b = 1;

            for (int i = 2; i <= n; i++)
            {
                BigInteger c = a + b;
                a = b;
                b = c;
            }

            return b;
        }

        public static BigInteger Matrix(int n)
        {
            return 0;
        }

        // ----------- LOG OF N SOLUTION  -----------
        private static BigInteger[][] baseFibonacci = new BigInteger[][]
        {
            new BigInteger[] { 1, 1 },
            new BigInteger[] { 1, 0 }
        };
        public static BigInteger LogN(int n) => n < 2 ? n : NthMatrix(baseFibonacci, n - 1)[0][0];

        private static BigInteger[][] NthMatrix(BigInteger[][] matrix, int pot)
        {
            if (pot == 0) //
            {
                return new BigInteger[][]
                {
                    //Identity matrix. 
                    new BigInteger[] { 1, 0 },
                    new BigInteger[] { 0, 1 }
                };
            }

            if (pot == 1)
            {
                return matrix;
            }

            BigInteger[][] halfMatrix = NthMatrix(matrix, pot / 2);
            BigInteger[][] result = MatrixMultiplier(halfMatrix, halfMatrix);
            if (pot % 2 == 0)
            {
                return result;
            }
            else
            {
                return MatrixMultiplier(matrix, result);
            }
        }

        private static BigInteger[][] MatrixMultiplier(BigInteger[][] a, BigInteger[][] b)
        {
            BigInteger[][] ans =
            {
                new BigInteger[] { 0, 0 },
                new BigInteger[] { 0, 0 }
            };

            ans[0][0] = a[0][0] * b[0][0] + a[0][1] * b[1][0];
            ans[0][1] = a[0][0] * b[0][1] + a[0][1] * b[1][1];
            ans[1][0] = a[1][0] * b[0][0] + a[1][1] * b[1][0];
            ans[1][1] = a[1][0] * b[0][1] + a[1][1] * b[1][1];

            return ans;

        }
    }
}


