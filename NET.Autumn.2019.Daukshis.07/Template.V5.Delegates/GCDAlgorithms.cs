using System;
using System.Diagnostics;

namespace Template.V5.Delegates
{
    public static class GCDAlgorithms
    {
        #region Euclidean Algorithms (API)

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>Calculates GCD of 2 numbers by Euclidean</returns>
        public static int FindGcdByEuclidean(int first, int second)
            => Gcd(first, second, euclideanAlgorithm);
        
        /// <summary>
        /// Finds the GCD by stain.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>Calculates GCD of 2 numbers by stain</returns>
        public static int FindGcdByStain(int first, int second)
            => Gcd(first, second, stainAlgorithm);

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>Calculates GCD of 2 numbers by Euclidean and returns algorithm execution time</returns>
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, euclideanAlgorithm);
        
        /// <summary>
        /// Finds the GCD by satin.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>Calculates GCD of 2 numbers by stain and returns algorithm execution time</returns>
        public static int FindGcdByStain(out long milliseconds, int first, int second)
            => Gcd(first, second, out milliseconds, stainAlgorithm);

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="third">The third.</param>
        /// <returns>Calculates GCD of 3 numbers by Euclidean</returns>
        public static int FindGcdByEuclidean(int first, int second, int third)
            => Gcd(first, second, third, euclideanAlgorithm);
        
        /// <summary>
        /// Finds the GCD by stain.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="third">The third.</param>
        /// <returns>Calculates GCD of 3 numbers by stain</returns>
        public static int FindGcdByStain(int first, int second, int third)
            => Gcd(first, second, third, stainAlgorithm);

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="third">The third.</param>
        /// <returns>Calculates GCD of 3 numbers by Euclidean and returns algorithm execution time</returns>
        public static int FindGcdByEuclidean(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, euclideanAlgorithm);
        
        /// <summary>
        /// Finds the GCD by stain.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="third">The third.</param>
        /// <returns>Calculates GCD of 3 numbers by stain and returns algorithm execution time</returns>
        public static int FindGcdByStain(out long milliseconds, int first, int second, int third)
            => Gcd(first, second, third, out milliseconds, stainAlgorithm);

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Calculates GCD of numbers by Euclidean</returns>
        public static int FindGcdByEuclidean(params int[] numbers)
            => Gcd(euclideanAlgorithm, numbers);
        
        /// <summary>
        /// Finds the GCD by stain.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Calculates GCD of numbers by Stain</returns>
        public static int FindGcdByStain(params int[] numbers)
            => Gcd(stainAlgorithm, numbers);

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Calculates GCD of numbers by Euclidean and returns algorithm execution time</returns>
        public static int FindGcdByEuclidean(out long milliseconds, params int[] numbers)
            => Gcd(euclideanAlgorithm, out milliseconds, numbers);
        
        /// <summary>
        /// Finds the GCD by stain.
        /// </summary>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Calculates GCD of numbers by stain and returns algorithm execution time</returns>
        public static int FindGcdByStain(out long milliseconds, params int[] numbers)
            => Gcd(stainAlgorithm, out milliseconds, numbers);

        #endregion

        private static Func<int, int, int> stainAlgorithm = delegate (int number1, int number2)
        {  
            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);

            if (number1 == 0)
                return number2;
            if (number2 == 0)
                return number1;
            if (number1 == 1 & number2 != number1)
                return 1;
            if (number2 == 1 & number2 != number1)
                return 1;
            
            int k = 1;
            while (number1 != 0 & number2 != 0)
            {
                while (number1 % 2 == 0 & number2 % 2 == 0)
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
        
        private static Func<int, int, int> euclideanAlgorithm = delegate (int number1, int number2)
        {  
            if (number1 == 0 & number2 != 0)
                return Math.Abs(number2);
            if (number2 == 0 & number1 != 0)
                return Math.Abs(number1);
            if (number1 == number2 & number1 == 0)
                return 0;
            
            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);
            while (number1 != number2)
            {
                if (number1 > number2)
                    number1 -= number2;
                else
                    number2 -= number1;
            }

            return number1 > number2 ? number1 : number2;
        };
        #region Helper methods

        private static int Gcd(int first, int second, Func<int, int, int> algorithm)
            => algorithm(first,second);

        private static int Gcd(int first, int second, out long milliseconds, Func<int, int, int> algorithm)
        {
            Stopwatch time = Stopwatch.StartNew();
            int result = algorithm(first, second);
            time.Stop();
            milliseconds = time.ElapsedMilliseconds;
            return result;
        }
        
        private static int Gcd(int first, int second, int third, Func<int, int, int> algorithm)
            =>algorithm(algorithm(first,second),third);

        private static int Gcd(int first, int second, int third, out long milliseconds, Func<int, int, int> algorithm)
        {
            Stopwatch time = Stopwatch.StartNew();
            int result  = algorithm(algorithm(first,second),third);
            time.Stop();
            milliseconds = time.ElapsedMilliseconds;
            return result;
        }
        
        private static int Gcd(Func<int, int, int> algorithm, params int[] numbers)
        {
            int result = numbers[0];
            for(int i = 1 ; i < numbers.Length; i++)
                result = algorithm(result, numbers[i]);
            return result;
        }
        private static int Gcd(Func<int, int, int> algorithm, out long milliseconds, params int[] numbers)
        { 
            int result = numbers[0];
            Stopwatch time = Stopwatch.StartNew();
            for(int i = 1 ; i < numbers.Length; i++)
                result = algorithm(result, numbers[i]);
            time.Stop();
            milliseconds = time.ElapsedMilliseconds;
            return result;
        }
        #endregion
    }
}