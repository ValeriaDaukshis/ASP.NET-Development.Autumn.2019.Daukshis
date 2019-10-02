using System.Diagnostics;
using Algorithms.V2.GcdImplementations;
using Algorithms.V2.Interfaces;

namespace Algorithms.V2.ExtensionMethods
{
    public static class GCDAlgorithms
    {
        #region Euclidean Algorithms (API)
        
        public static int FindGcdByEuclidean(int first, int second)
            => new EuclideanAlgorithm().Gcd(first, second); 
        
        public static int FindGcdByEuclidean(int first, int second, int third)
            => new EuclideanAlgorithm().Gcd(first, second, third);
        
        public static int FindGcdByEuclidean(params int[] numbers)
            => new EuclideanAlgorithm().Gcd( numbers); 
        
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second)
            => new EuclideanAlgorithm().Gcd(first, second, out milliseconds);
        
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second, int third)
            => new EuclideanAlgorithm().Gcd(first, second, third, out milliseconds);
        
        public static int FindGcdByEuclidean(out long milliseconds, params int[] numbers)
            => new EuclideanAlgorithm().Gcd(out milliseconds, numbers); 
        
        #endregion 
    }

    public static class MethodsExtension
    {
        public static int Gcd(this IAlgorithm algorithm, int first, int second)
            => algorithm.Calculate(first,second);
        
        public  static int Gcd(this IAlgorithm algorithm, int first, int second, int third)
        {
            int result = algorithm.Calculate(first, second);
            return algorithm.Calculate(result, third);
        }
        
        public static int Gcd(this IAlgorithm algorithm, params int[] numbers)
        {
            int result = numbers[0];
            for(int i = 1 ; i < numbers.Length; i++)
                result = algorithm.Calculate(result, numbers[i]);
            return result;
        } 
        
        public static int Gcd(this IAlgorithm algorithm, int first, int second, out long milliseconds)
        {
            Stopwatch time = Stopwatch.StartNew();
            int result = algorithm.Calculate(first, second);
            time.Stop();
            milliseconds = time.ElapsedMilliseconds;
            return result;
        }
        
        public static int Gcd(this IAlgorithm algorithm, int first, int second, int third, out long milliseconds)
        {
            Stopwatch time = Stopwatch.StartNew();
            int result  = algorithm.Calculate(algorithm.Calculate(first,second),third);
            time.Stop();
            milliseconds = time.ElapsedMilliseconds;
            return result;
        }
        
        public static int Gcd(this IAlgorithm algorithm, out long milliseconds, params int[] numbers)
        {
            int result = numbers[0];
            Stopwatch time = Stopwatch.StartNew();
            for(int i = 1 ; i < numbers.Length; i++)
                result = algorithm.Calculate(result, numbers[i]);
            time.Stop();
            milliseconds = time.ElapsedMilliseconds;
            return result;
        } 
    }
}