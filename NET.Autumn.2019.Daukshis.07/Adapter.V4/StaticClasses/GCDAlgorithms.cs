using Algorithms.V4.Adapter;
using Algorithms.V4.GcdImplementations;
using Algorithms.V4.LoggerImplementation;
using Algorithms.V4.StopWatcherImplementation;

namespace Algorithms.V4.StaticClasses
{
    public static class GcdAlgorithms
    {
       #region Euclidean Algorithms (API)
        
        public static int FindGcdByEuclidean(int first, int second)
            => Gcd(first, second, new EuclideanAlgorithmDecorator(new EuclideanAlgorithm(), new Logger()));
        
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, new TimerAdapter(new StopWatcher()));
        
        public static int FindGcdByEuclidean(int first, int second, int third)
            => Gcd(first, second, third, new EuclideanAlgorithmDecorator(new EuclideanAlgorithm(), new Logger()));
        
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, new TimerAdapter(new StopWatcher()));
        
        public static int FindGcdByEuclidean(params int[] numbers)
            => Gcd(new EuclideanAlgorithmDecorator(new EuclideanAlgorithm(), new Logger()), numbers);
        
        public static int FindGcdByEuclidean(out long milliseconds, params int[] numbers)
            => Gcd(new TimerAdapter(new StopWatcher()), out milliseconds, numbers); 

        #endregion

        #region Helper methods

        private static int Gcd(int first, int second, EuclideanAlgorithm algorithm)
            => algorithm.Calculate(first,second);
        
        private static int Gcd(int first, int second,out long milliseconds, TimerAdapter algorithm)
            => algorithm.Calculate(first, second, out milliseconds);

        private static int Gcd(int first, int second, int third, EuclideanAlgorithm algorithm)
        {
            int result = algorithm.Calculate(first, second);
            return algorithm.Calculate(result, third);
        }
        private static int Gcd(int first, int second, int third, out long milliseconds, TimerAdapter algorithm)
        { 
            int result = algorithm.Calculate(first, second, out milliseconds);
            return algorithm.Calculate(result, third, out milliseconds);
        }
        
        private static int Gcd(EuclideanAlgorithm algorithm, params int[] numbers)
        {
            int result = algorithm.Calculate(numbers[0], numbers[1]);
            for(int i = 2 ; i < numbers.Length-2; i++)
                algorithm.Calculate(result, numbers[i]);
            return algorithm.Calculate(result, numbers[numbers.Length-1]);
        }
        private static int Gcd(TimerAdapter algorithm, out long milliseconds, params int[] numbers)
        { 
            int result = algorithm.Calculate(numbers[0], numbers[1], out milliseconds);
            for(int i = 2 ; i < numbers.Length-2; i++)
                algorithm.Calculate(result, numbers[i], out milliseconds);
            return algorithm.Calculate(result, numbers[numbers.Length-1], out milliseconds);
        }

        #endregion

    }
}