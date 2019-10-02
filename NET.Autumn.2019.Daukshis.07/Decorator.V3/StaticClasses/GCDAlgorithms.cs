using Algorithms.V3.GcdImplementations;

namespace Algorithms.V3.StaticClasses
{
    public static class GCDAlgorithms
    {
        #region Euclidean Algorithms (API)
        
        public static int FindGcdByEuclidean(int first, int second)
            => Gcd(first, second, new EuclideanAlgorithm());
        
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, new EuclideanAlgorithmDecorator(new EuclideanAlgorithm()));
        
        public static int FindGcdByEuclidean(int first, int second, int third)
            => Gcd(first, second, third, new EuclideanAlgorithm());
        
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, new EuclideanAlgorithmDecorator(new EuclideanAlgorithm()));
        
        public static int FindGcdByEuclidean(params int[] numbers)
            => Gcd(new EuclideanAlgorithm(), numbers);
        
        public static int FindGcdByEuclidean(out long milliseconds, params int[] numbers)
            => Gcd(new EuclideanAlgorithmDecorator(new EuclideanAlgorithm()), out milliseconds, numbers);
        
        #endregion

        #region Helper methods

        private static int Gcd(int first, int second, EuclideanAlgorithm algorithm)
            => algorithm.Calculate(first,second);

        private static int Gcd(int first, int second, out long milliseconds, EuclideanAlgorithmDecorator algorithm)
        {
            int result = algorithm.Calculate(first, second);
            milliseconds = algorithm.Milliseconds;
            return result;
        }
        
        private static int Gcd(int first, int second, int third, EuclideanAlgorithm algorithm)
            =>algorithm.Calculate(algorithm.Calculate(first,second),third);
        
        private static int Gcd(int first, int second, int third, out long milliseconds, EuclideanAlgorithmDecorator algorithm)
        {
            int result = algorithm.Calculate(algorithm.Calculate(first, second), third);
            milliseconds = algorithm.Milliseconds;
            return result;
        }
        private static int Gcd(EuclideanAlgorithm algorithm, params int[] numbers)
        {
            int result = numbers[0];
            for(int i = 1 ; i < numbers.Length; i++)
                result = algorithm.Calculate(result, numbers[i]);
            return result;
        }
        private static int Gcd(EuclideanAlgorithmDecorator algorithm, out long milliseconds, params int[] numbers)
        { 
            int result = numbers[0];
            for(int i = 1 ; i < numbers.Length; i++)
                result = algorithm.Calculate(result, numbers[i]);
            milliseconds = algorithm.Milliseconds;
            return result;
        }
        #endregion
    }
}