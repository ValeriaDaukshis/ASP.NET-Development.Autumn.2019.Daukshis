using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms.V5
{
    /// <summary>
    /// GCDAlgorithms.
    /// </summary>
    public static class GCDAlgorithms
    {
        #region GreatestCommonDivisior

        /// <summary>
        /// Greatest the common divisor.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>Calculates GCD of 2 numbers by Euclidean</returns>
        public static int GreatestCommonDivisor(int first, int second)
        => CommonDivisor2Params(EuclideanAlgorithm, first, second);

        /// <summary>
        /// Greatest the common divisor.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="elapsedTimeMilliSecs">The elapsed time milli secs.</param>
        /// <returns>Calculates GCD of 2 numbers by Euclidean</returns>
        public static int GreatestCommonDivisor(int first, int second, out long elapsedTimeMilliSecs) =>
            CommonDivisor2ParamsWithTime(EuclideanAlgorithm, first, second, out elapsedTimeMilliSecs);

        /// <summary>
        /// Greatest the common divisor.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="third">The third.</param>
        /// <returns>Calculates GCD of 3 numbers by Euclidean</returns>
        public static int GreatestCommonDivisor(int first, int second, int third) =>
            CommonDivisor3Params(EuclideanAlgorithm, first, second, third);

        /// <summary>
        /// Greatest the common divisor.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="third">The third.</param>
        /// <param name="elapsedTimeMilliSecs">The elapsed time milli secs.</param>
        /// <returns>Calculates GCD of 3 numbers by Euclidean</returns>
        public static int GreatestCommonDivisor(int first, int second, int third, out long elapsedTimeMilliSecs) =>
            CommonDivisor3ParamsWithTime(EuclideanAlgorithm, first, second, third, out elapsedTimeMilliSecs);

        /// <summary>
        /// Greatest the common divisor.
        /// </summary>
        /// <param name="arrayOfNumbers">The array of numbers.</param>
        /// <returns>Calculates GCD of array of numbers by Euclidean</returns>
        public static int GreatestCommonDivisor(params int[] arrayOfNumbers) =>
            CommonDivisorParams(EuclideanAlgorithm, arrayOfNumbers);

        /// <summary>
        /// Greatest the common divisor.
        /// </summary>
        /// <param name="elapsedTimeMilliSecs">The elapsed time milli secs.</param>
        /// <param name="arrayOfNumbers">The array of numbers.</param>
        /// <returns>Calculates GCD of array numbers by Euclidean</returns>
        public static int GreatestCommonDivisor(out long elapsedTimeMilliSecs, params int[] arrayOfNumbers) =>
            CommonDivisorParamsWithTime(out elapsedTimeMilliSecs, EuclideanAlgorithm, arrayOfNumbers);

        #endregion

        #region BinaryGreatestCommonDivisior

        /// <summary>
        /// Binaries the greatest common divisor.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>Calculates GCD of 2 numbers by Stain</returns>
        public static int BinaryGreatestCommonDivisor(int first, int second)
        => CommonDivisor2Params(StainAlgorithm, first, second);

        /// <summary>
        /// Binaries the greatest common divisor.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="elapsedTimeMilliSecs">The elapsed time milli secs.</param>
        /// <returns>Calculates GCD of 2 numbers by Stain</returns>
        public static int BinaryGreatestCommonDivisor(int first, int second, out long elapsedTimeMilliSecs) =>
            CommonDivisor2ParamsWithTime(StainAlgorithm, first, second, out elapsedTimeMilliSecs);

        /// <summary>
        /// Binaries the greatest common divisor.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="third">The third.</param>
        /// <returns>Calculates GCD of 3 numbers by Stain</returns>
        public static int BinaryGreatestCommonDivisor(int first, int second, int third) =>
            CommonDivisor3Params(StainAlgorithm, first, second, third);

        /// <summary>
        /// Binaries the greatest common divisor.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="third">The third.</param>
        /// <param name="elapsedTimeMilliSecs">The elapsed time milli secs.</param>
        /// <returns>Calculates GCD of 3 numbers by Stain</returns>
        public static int
            BinaryGreatestCommonDivisor(int first, int second, int third, out long elapsedTimeMilliSecs) =>
            CommonDivisor3ParamsWithTime(StainAlgorithm, first, second, third, out elapsedTimeMilliSecs);

        /// <summary>
        /// Binaries the greatest common divisor.
        /// </summary>
        /// <param name="arrayOfNumbers">The array of numbers.</param>
        /// <returns>Calculates GCD of array of numbers by Stain</returns>
        public static int BinaryGreatestCommonDivisor(params int[] arrayOfNumbers) =>
            CommonDivisorParams(StainAlgorithm, arrayOfNumbers);

        /// <summary>
        /// Binaries the greatest common divisor.
        /// </summary>
        /// <param name="elapsedTimeMilliSecs">The elapsed time milli secs.</param>
        /// <param name="arrayOfNumbers">The array of numbers.</param>
        /// <returns>Calculates GCD of array of numbers by Stain</returns>
        public static int BinaryGreatestCommonDivisor(out long elapsedTimeMilliSecs, params int[] arrayOfNumbers) =>
            CommonDivisorParamsWithTime(out elapsedTimeMilliSecs, StainAlgorithm, arrayOfNumbers);

        #endregion

        #region Helper methods

        private static int CommonDivisor2Params(Func<int, int, int> gcd, int first, int second)
        {
            if (first == 0 && second == 0)
            {
                throw new ArgumentException();
            }
            return gcd(first, second);
        }
        private static int CommonDivisor2ParamsWithTime(Func<int, int, int> algorithm, int first, int second,
            out long elapsedTimeMilliSecs)
        {
            if(first == 0 && second == 0)
            {
                throw new ArgumentException();
            }
            
            Stopwatch time = Stopwatch.StartNew();
            int result = algorithm(first, second);
            time.Stop();
            
            elapsedTimeMilliSecs = time.ElapsedMilliseconds;
            return result;
        }

        private static int CommonDivisor3Params(Func<int, int, int> gcd, int first, int second, int third)
        {
            if(first == 0 && third == 0 && second == 0)
            {
                throw new ArgumentException();
            }
            return gcd(gcd(first, second), third);
        }

        private static int CommonDivisor3ParamsWithTime(Func<int, int, int> gcd, int first, int second, int third,
            out long elapsedTimeMilliSecs)
        {
            if(first == 0 && third == 0 && second == 0)
            {
                throw new ArgumentException();
            }
            
            Stopwatch time = Stopwatch.StartNew();
            int result  = gcd(gcd(first,second),third);
            time.Stop();
            elapsedTimeMilliSecs = time.ElapsedMilliseconds;
            return result;
        }

        private static int CommonDivisorParams(Func<int, int, int> gcd, params int[] numbers)
        {
            HashSet<int> set = new HashSet<int>(numbers);
            if(set.Count == 1 && numbers[0] == 0)
            {
                throw new ArgumentException();
            }
            
            int result = numbers[0];
            for (int i = 1 ; i < numbers.Length; i++)
            {
                result = gcd(result, numbers[i]);
            }

            return result;
        }

        private static int CommonDivisorParamsWithTime(out long elapsedTimeMilliSecs, Func<int, int, int> gcd,
            params int[] numbers)
        {
            HashSet<int> set = new HashSet<int>(numbers);
            if(set.Count == 1 && numbers[0] == 0)
            {
                throw new ArgumentException();
            }
            
            int result = numbers[0];
            Stopwatch time = Stopwatch.StartNew();
            for(int i = 1 ; i < numbers.Length; i++)
                result = gcd(result, numbers[i]);
            time.Stop();
            elapsedTimeMilliSecs = time.ElapsedMilliseconds;
            return result;
        }

        #endregion
        
        private static Func<int, int, int> EuclideanAlgorithm = delegate (int number1, int number2)
        {  
            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);
            
            if (number1 == 0 && number2 != 0)
                return number2;
            if (number2 == 0 && number1 != 0)
                return number1;
            
            while (number1 != number2)
            {
                if (number1 > number2)
                    number1 -= number2;
                else
                    number2 -= number1;
            }

            return number1 > number2 ? number1 : number2;
        };
        
        private static Func<int, int, int> StainAlgorithm = delegate (int number1, int number2)
        {  
            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);

            if (number1 == 0 && number2 != 0)
                return number2;
            if (number2 == 0 && number1 != 0)
                return number1;
            
            int k = 1;
            while (number1 != 0 && number2 != 0)
            {
                while (number1 % 2 == 0 && number2 % 2 == 0)
                {
                    number1 >>= 1; // num/2
                    number2 >>= 1;
                    k *= 2;
                }
                while (number1 % 2 == 0) number1 >>= 1;
                while (number2 % 2 == 0) number2 >>= 1;

                if (number1 >= number2)
                    number1 -= number2;
                else
                    number2 -= number1;
            }

            return number2 * k;
        };
    }
}