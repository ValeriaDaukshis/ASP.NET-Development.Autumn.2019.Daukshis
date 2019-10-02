
using Algorithms.V1.GcdImplementations;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.StaticClasses
{
    public static class GCDAlgorithms
    {
        #region Euclidean Algorithms (API)
        
        public static int FindGcdByEuclidean(int first, int second)
            => Gcd(first, second, new EuclideanAlgorithm());
        
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, new EuclideanAlgorithm());
        
        public static int FindGcdByEuclidean(int first, int second, int third)
            => Gcd(first, second, third, new EuclideanAlgorithm());
        
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, new EuclideanAlgorithm());
        
        public static int FindGcdByEuclidean(params int[] numbers)
            => Gcd(new EuclideanAlgorithm(), numbers);
        
        public static int FindGcdByEuclidean(out long milliseconds, params int[] numbers)
            => Gcd(new EuclideanAlgorithm(), out milliseconds, numbers);
        
        #endregion

        #region Helper methods

        private static int Gcd(int first, int second, Algorithm algorithm)
            => algorithm.Calculate(first,second);

        private static int Gcd(int first, int second, out long milliseconds, Algorithm algorithm)
            => algorithm.Calculate(first,second, out milliseconds);
        
        private static int Gcd(int first, int second, int third, Algorithm algorithm)
            =>algorithm.Calculate(algorithm.Calculate(first,second),third);
        
        private static int Gcd(int first, int second, int third, out long milliseconds, Algorithm algorithm)
            => algorithm.Calculate(algorithm.Calculate(first,second, out milliseconds),third, out milliseconds);
        
        private static int Gcd(Algorithm algorithm, params int[] numbers)
        {
            int result = numbers[0];
            for(int i = 1 ; i < numbers.Length; i++)
                result = algorithm.Calculate(result, numbers[i]);
            return result;
        }
        private static int Gcd(Algorithm algorithm, out long milliseconds, params int[] numbers)
        { 
            int result = numbers[0];
            for(int i = 1 ; i < numbers.Length-1; i++)
                result = algorithm.Calculate(result, numbers[i], out milliseconds);
            return algorithm.Calculate(result, numbers[numbers.Length-1], out milliseconds);
        }
        #endregion
    }
}