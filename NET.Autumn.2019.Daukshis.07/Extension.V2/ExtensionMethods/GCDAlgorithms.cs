using System.Diagnostics;
using Algorithms.V2.GcdImplementations;
using Algorithms.V2.Interfaces;

namespace Algorithms.V2.ExtensionMethods
{
    public static class GCDAlgorithms
    {
        /// <summary>
        /// GCDs the specified first.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>Calculates GCD of 2 numbers by Euclidean</returns>
        public static int Gcd(this IAlgorithm algorithm, int first, int second)
            => algorithm.Calculate(first, second);

        /// <summary>
        /// GCDs the specified first.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="third">The third.</param>
        /// <returns>Calculates GCD of 2 numbers by Euclidean and returns algorithm execution time</returns>
        public static int Gcd(this IAlgorithm algorithm, int first, int second, int third)
        {
            int result = algorithm.Calculate(first, second);
            return algorithm.Calculate(result, third);
        }

        /// <summary>
        /// GCDs the specified numbers.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Calculates GCD of 3 numbers by Euclidean</returns>
        public static int Gcd(this IAlgorithm algorithm, params int[] numbers)
        {
            int result = numbers[0];
            for(int i = 1 ; i < numbers.Length; i++)
                result = algorithm.Calculate(result, numbers[i]);
            return result;
        }

        /// <summary>
        /// GCDs the specified first.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <returns>Calculates GCD of 3 numbers by Euclidean and returns algorithm execution time</returns>
        public static int Gcd(this IAlgorithm algorithm, int first, int second, out long milliseconds)
        {
            Stopwatch time = Stopwatch.StartNew();
            int result = algorithm.Calculate(first, second);
            time.Stop();
            milliseconds = time.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// GCDs the specified first.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="third">The third.</param>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <returns>Calculates GCD of numbers by Euclidean</returns>
        public static int Gcd(this IAlgorithm algorithm, int first, int second, int third, out long milliseconds)
        {
            Stopwatch time = Stopwatch.StartNew();
            int result  = algorithm.Calculate(algorithm.Calculate(first,second),third);
            time.Stop();
            milliseconds = time.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// GCDs the specified milliseconds.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Calculates GCD of numbers by Euclidean and returns algorithm execution time</returns>
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